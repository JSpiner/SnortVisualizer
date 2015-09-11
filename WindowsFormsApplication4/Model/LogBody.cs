using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace WindowsFormsApplication4.Model
{

    public class LogBody
    {
        enum PROTOCOL { TCP, UDP, ICMP };

        public String raw;
        public DateTime time;
        public String senderIp;
        public String senderPort;
        public String receiverIp;
        public String receiverPort;

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
            senderIp = seps[1].Substring(0, sendIndex);
            senderPort = seps[1].Substring(sendIndex + 1);

            int receiveIndex = seps[3].IndexOf(":");
            receiverIp = seps[3].Substring(0, receiveIndex);
            receiverPort = seps[3].Substring(receiveIndex + 1);


            //line2 : protocol type
            String ptype = lines[1].Substring(0, lines[1].IndexOf(" "));

            switch (ptype)
            {
                case "TCP":
                    parseTCP(lines);
                    break;
                case "UDP":
                    break;
                case "ICMP":
                    break;

            }

        }

        private void parseTCP(String[] lines)
        {

        }

        private void parseUDP(String[] lines)
        {

        }

        private void parseICMP(String[] lines)
        {

        }

    }
}
