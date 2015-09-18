using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace WindowsFormsApplication4.Model
{

    public class LogBody
    {
        public String raw;
        public DateTime time;
        public String senderIp;
        public String senderPort;
        public String receiverIp;
        public String receiverPort;

        public IPHeader ipHeader;

        public LogBody(String body)
        {
            this.raw = body;

            String[] lines = body.Split(new[] { "\n" }, StringSplitOptions.None);

            //line1 : time & ip sender receiver
            String[] seps = lines[0].Split(new[] { " " }, StringSplitOptions.None);

            this.time = DateTime.ParseExact(seps[0],
                "MM/dd-HH:mm:ss.ffffff",
                CultureInfo.InvariantCulture);

            int sendIndex = seps[1].IndexOf(":");
            if (sendIndex == -1)
            {
                senderIp = seps[1].Trim();
                senderPort = "";
            }
            else
            {
                senderIp = seps[1].Substring(0, sendIndex);
                senderPort = seps[1].Substring(sendIndex + 1);
            }

            int receiveIndex = seps[3].IndexOf(":");
            if (receiveIndex == -1)
            {
                senderIp = seps[3];
                senderPort = "";
            }
            else
            {
                receiverIp = seps[3].Substring(0, receiveIndex);
                receiverPort = seps[3].Substring(receiveIndex + 1);
            }

            //line2 : protocol type -> ip header
            String[] pheaders = lines[1].Split(new[] { " " }, StringSplitOptions.None);

            ipHeader = new IPHeader(pheaders);
            ipHeader.parseLine(lines);
        }


    }

    public class IPHeader
    {

        enum PROTOCOL { TCP, UDP, ICMP };
        enum IPFLAG { RB, DF, MF };

        PROTOCOL protocol;
        IPFLAG flag;

        public int TTL;
        public String TOS;
        public int ID;
        public int IpLen;
        public int DgmLen;

        public BaseProtocol protocolBody;

        public IPHeader(String[] headers)
        {

            /*
            headers 
            PROTOCOL TTL TOS ID IPLEN DGMLEN FLAG
            */

            switch (headers[0])
            {
                case "TCP":
                    protocol = PROTOCOL.TCP;
                    break;
                case "UDP":
                    protocol = PROTOCOL.UDP;
                    break;
                case "ICMP":
                    protocol = PROTOCOL.ICMP;
                    break;
            }

            TTL = Convert.ToInt32(getValue(headers[1]));
            TOS = getValue(headers[2]);
            ID = Convert.ToInt32(getValue(headers[3]));
            IpLen = Convert.ToInt32(getValue(headers[4]));
            DgmLen = Convert.ToInt32(getValue(headers[5]));


        }


        public void parseLine(String[] lines)
        {
            switch (protocol)
            {
                case PROTOCOL.TCP:
                    parseTCP(lines);
                    break;
                case PROTOCOL.UDP:
                    parseUDP(lines);
                    break;
                case PROTOCOL.ICMP:
                    parseICMP(lines);
                    break;
            }

        }

        //ipheader~ 2 line
        private void parseTCP(String[] lines)
        {
            String[] seps = lines[2].Split(new[] { " " }, StringSplitOptions.None);
            protocolBody = new TCP(seps);
            protocolBody.raw = lines[2];
        }

        private void parseUDP(String[] lines)
        {
            String[] seps = lines[2].Split(new[] { " " }, StringSplitOptions.None);
            protocolBody = new UDP(seps);
            protocolBody.raw = lines[2];
        }

        private void parseICMP(String[] lines)
        {
            String[] seps = lines[2].Split(new[] { " " }, StringSplitOptions.None);
            protocolBody = new ICMP(seps);
            protocolBody.raw = lines[2];
        }

        private String getValue(String pair)
        {
            int index = pair.IndexOf(":");
            //			String key = pair.Substring (0, index);
            String value = pair.Substring(index + 1);
            return value;
        }

        public class TCP : BaseProtocol
        {
            /*
            TH_RES1 1
            TH_RES2 2
            TH_URG U
            TH_ACK A
            TH_PUSH P
            TH_RST R
            TH_SYN S
            TH_FIN F
             */

            public String flagRaw;
            public List<String> flagList;
            private String[] flags = { "TH_RES1", "TH_RES2", "TH_URG", "TH_ACK", "TH_PUSH", "TH_RST", "TH_SYN", "TH_FIN" };

            public String Seq;
            public String Ack;
            public String Win;
            public int TcpLen;

            public TCP(String[] seps)
            {
                // seps  =>  flag seq ack win tcplen
                this.flagRaw = seps[0];
                this.Seq = seps[2];
                this.Ack = seps[5];
                this.Win = seps[8];
                this.TcpLen = Convert.ToInt32(seps[11]);

                parseFlag(flagRaw);
            }

            private void parseFlag(String flags)
            {
                char[] seps = flags.ToCharArray();

                flagList = new List<String>();
                for (int i = 0; i < seps.Length; i++)
                {
                    if (!seps[i].Equals('*')) flagList.Add(this.flags[i]);
                }
            }

        }

        public class UDP : BaseProtocol
        {

            public int Len;

            public UDP(String[] seps)
            {
                //seps => len
                this.Len = Convert.ToInt32(seps[1]);
            }

        }

        public class ICMP : BaseProtocol
        {

            public int Type;
            public int Code;
            //ICMP ECHOREPLY
            public int ID;
            public int Seq;

            public ICMP(String[] seps)
            {
                this.Type = Convert.ToInt32(getValue(seps[0]));
                this.Code = Convert.ToInt32(getValue(seps[2]));
                this.ID = Convert.ToInt32(getValue(seps[4]));
                this.Seq = Convert.ToInt32(getValue(seps[7]));
            }

            private String getValue(String pair)
            {
                int index = pair.IndexOf(":");
                //				String key = pair.Substring (0, index);
                String value = pair.Substring(index + 1);
                return value;
            }

        }

        public class BaseProtocol
        {
            public String raw;
        }
    }

}
