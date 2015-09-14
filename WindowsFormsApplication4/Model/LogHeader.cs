using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication4.Model
{
    public class LogHeader
    {
        public String raw;
        public AlertSig alertSig;
        public String clasific; //Classification
        public String priority;
        public List<String> xrefList;

        public LogHeader(String header)
        {
            this.raw = header;

            //Alert sig Line 
            int sigIndex = header.IndexOf("[**]");
            String sig = header.Substring(sigIndex + 4,
                header.LastIndexOf("[**]") - sigIndex - 4).Trim();

            this.alertSig = new AlertSig(sig);

            //Alert 
            MatchCollection sigInfos = Regex.Matches(
                header.Substring(header.LastIndexOf("[**]")), "\\[(.*?)\\]");

            foreach (Match sigInfo in sigInfos)
            {
                String sigStr =
                    sigInfo.Value.Substring(1, sigInfo.Value.Length - 2);

                if (sigStr.IndexOf(":") != -1)
                {
                    int optionIndex = sigStr.IndexOf(":");
                    String optionKey = sigStr.Substring(0, optionIndex).Trim();
                    String optionValue = sigStr.Substring(optionIndex + 1).Trim();

                    switch (optionKey.ToLower())
                    {
                        case "classification":
                            this.clasific = optionValue;
                            break;
                        case "priority":
                            this.priority = optionValue;
                            break;
                    }

                }

                if (sigStr.IndexOf("=>") != -1)
                {
                    int optionIndex = sigStr.IndexOf("=>");
                    String optionKey = sigStr.Substring(0, optionIndex).Trim();
                    String optionValue = sigStr.Substring(optionIndex + 2).Trim();

                    switch (optionKey.ToLower())
                    {
                        case "xref":
                            if (xrefList == null)
                            {
                                xrefList = new List<String>();
                            }
                            xrefList.Add(optionValue);
                            break;
                    }

                }

            }

        }

        public class AlertSig
        {
            public long sigGenerator;
            public long sigId;
            public long sigRev;

            public String alertInterface;
            public String alertMsg;

            public AlertSig(String sig)
            {

                //sig
                int sigIndex = sig.IndexOf("]");
                String eventSig = sig.Substring(1, sigIndex - 1).Trim();

                String[] sigs = eventSig.Split(new[] { ":" }, StringSplitOptions.None);

                sigGenerator = (long)Convert.ToDouble(sigs[0]);
                sigId = (long)Convert.ToDouble(sigs[1]);
                sigRev = (long)Convert.ToDouble(sigs[2]);

                //inteface
                int ifIndex = sig.IndexOf(">"); //inteface index
                this.alertInterface = sig.Substring(
                    sigIndex + 1, ifIndex - sigIndex - 1).Trim();

                //msg
                this.alertMsg = sig.Substring(ifIndex + 1).Trim();


            }
        }
    }


}
