using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] lines = textBox1.Text.Split(new[]{"\r\n"}, StringSplitOptions.None);

            foreach (String line in lines)
            {
                RuleModel rule = RuleModel.parse(line);
            }
            
        }
    }

    class RuleModel
    {
        public String raw;
        public RuleHeader ruleHeader;
        public RuleOption ruleOption;

        public static RuleModel parse(String rule)
        {
            RuleModel ruleModel = new RuleModel();
            ruleModel.raw = rule;

            int headerIndex = rule.IndexOf("(");

            if (headerIndex == -1)
            {
                throw new Exception("not correct argument");
            }

            String strHeader = rule.Substring(0, headerIndex);
            String strOption = rule.Substring(headerIndex);

            ruleModel.ruleHeader = new RuleHeader(strHeader.Trim());
            ruleModel.ruleOption = new RuleOption(strOption.Trim());

            return ruleModel;
        }
    }

    class RuleHeader
    {
        public enum ACTION {ALERT,LOG,PASS,ACTIVATE,DYNAMIC};
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

    class RuleOption
    {
        Dictionary<String, String> ruleMap;

        public RuleOption(String option)
        {
            ruleMap = new Dictionary<string, string>();

            String[] options = option.Split(new[] { ";" }, StringSplitOptions.None);

            foreach (String ruleOption in options)
            {
                int keyIndex = ruleOption.IndexOf(":");
                ruleMap.Add(
                    ruleOption.Substring(0,keyIndex).Trim(),
                    ruleOption.Substring(keyIndex).Trim());
            }
        }

    }
}
