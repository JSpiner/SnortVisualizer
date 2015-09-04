using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Model
{

    class RuleHeader
    {
        public enum ACTION { ALERT, LOG, PASS, ACTIVATE, DYNAMIC };
        public enum PROTOCOL { TCP, UDP, ICMP, IP };

        public String raw;
        public ACTION ruleAction;
        public PROTOCOL ruleProtocol;
        public String ruleSenderip;
        public String ruleSenderport;
        public String ruleDirect;
        public String ruleReceiveip;
        public String ruleReceiveport;

        public RuleHeader(String header)
        {
            this.raw = header;

            String[] headers = header.Split(new[] { " " }, StringSplitOptions.None);

            if (headers.Length != 7)
            {
                throw new Exception("not correct argument");
            }

            //action
            ACTION parseAction;
            if (!Enum.TryParse(headers[0].ToUpper(), out parseAction))
            {
                throw new Exception("no match action");
            }
            this.ruleAction = parseAction;

            //rule Protocol;
            PROTOCOL parseProtocol;
            if (!Enum.TryParse(headers[1].ToUpper(), out parseProtocol))
            {
                throw new Exception("no match protocol");
            }
            this.ruleProtocol = parseProtocol;

            //rule Senderip
            this.ruleSenderip = headers[2];

            //rule Senderport
            this.ruleSenderport = headers[3];

            //rule Direct
            this.ruleDirect = headers[4];

            //rule Receiveip
            this.ruleReceiveip = headers[5];

            //rule Receiveport
            this.ruleReceiveport = headers[6];


        }
    }

}
