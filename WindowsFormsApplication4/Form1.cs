using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Model;
using MaterialSkin.Controls;
using MaterialSkin;

namespace WindowsFormsApplication4
{
    public partial class Form1 : MaterialForm
    {


        public static String[] rules = {
			"alert tcp 192.168.1.35 any -> any any (msg:\"Traffic from 192.168.1.35\";)",
			"alert tcp any any -> any any (msg:\"Possible  exploit\"; content:\"|90|\";)",
			"alert tcp any any -> any any (msg:\"Possible  exploit\"; content:\"|90|\";  offset:40; depth:75;)"
		};

        public static String[] logs = {
			"[**] [1:105:5]  <\\Device\\NPF_{416E2ED0-46A1-4868-957A-E0811C91C17D}> rule 1 BACKDOOR - Dagger_1.4.0 [**]\n[Classification: Misc activity] [Priority: 3] \n03/04-21:24:27.692778 172.16.1.2:2589 -> 137.207.234.252:1024\nTCP TTL:128 TOS:0x0 ID:0 IpLen:20 DgmLen:56 DF\n***A**** Seq: 0x437ADF84  Ack: 0x4566878A  Win: 0x4000  TcpLen: 20\n[Xref => http://www.tlsecurity.net/backdoor/Dagger.1.4.html][Xref => http://www.whitehats.com/info/IDS484]\n\n",
			"[**] [1:214:4]  <\\Device\\NPF_{416E2ED0-46A1-4868-957A-E0811C91C17D}> rule 2 BACKDOOR MISC Linux rootkit attempt lrkr0x [**]\n[Classification: Attempted Administrator Privilege Gain] [Priority: 1] \n03/04-21:24:33.330860 137.207.234.252:19058 -> 172.16.1.2:23\nTCP TTL:128 TOS:0x0 ID:0 IpLen:20 DgmLen:56 DF\n******S* Seq: 0x7083DA13  Ack: 0xD7AC7E0B  Win: 0x4000  TcpLen: 20\n\n",
			"[**] [1:375:4]  <\\Device\\NPF_{416E2ED0-46A1-4868-957A-E0811C91C17D}> Rule 3 ICMP PING LINUX/*BSD [**]\n[Classification: Misc activity] [Priority: 3] \n03/04-21:24:34.344933 137.207.234.252 -> 172.16.1.2\nICMP TTL:128 TOS:0x0 ID:13170 IpLen:20 DgmLen:36\nType:8  Code:0  ID:34835   Seq:7412  ECHO\n[Xref => http://www.whitehats.com/info/IDS447]\n\n",
			"[**] [1:598:11]  <\\Device\\NPF_{416E2ED0-46A1-4868-957A-E0811C91C17D}> Rule 4 RPC portmap listing TCP 111 [**]\n[Classification: Decode of an RPC Query] [Priority: 2] \n03/04-21:24:35.302060 137.207.234.252:49609 -> 172.16.1.2:111\nTCP TTL:128 TOS:0x0 ID:0 IpLen:20 DgmLen:60 DF\n***A**** Seq: 0x1207EB67  Ack: 0x283C2A4F  Win: 0x4000  TcpLen: 20\n[Xref =>  arachnids 428]\n\n",
		
			"[**] [1:668:4]  <\\Device\\NPF_{416E2ED0-46A1-4868-957A-E0811C91C17D}> Rule 5 SMTP sendmail 8.6.10 exploit [**]\n[Classification: Attempted User Privilege Gain] [Priority: 1] \n03/04-21:24:36.349398 137.207.234.252:49842 -> 172.16.1.2:25\nTCP TTL:128 TOS:0x0 ID:0 IpLen:20 DgmLen:80 DF\n***A**** Seq: 0x32345B52  Ack: 0x5CDD2EB0  Win: 0x4000  TcpLen: 20\n[Xref => http://www.whitehats.com/info/IDS124]\n\n",
			"[**] [1:888:4]  <\\Device\\NPF_{416E2ED0-46A1-4868-957A-E0811C91C17D}> Rule 6 WEB-CGI wwwadmin.pl access [**]\n[Classification: Attempted Information Leak] [Priority: 2] \n03/04-21:24:37.309912 137.207.234.252:63781 -> 172.16.1.2:80\nTCP TTL:128 TOS:0x0 ID:0 IpLen:20 DgmLen:353 DF\n***AP*** Seq: 0x1  Ack: 0x1  Win: 0x4000  TcpLen: 20\n\n",
			"[**] [1:978:7]  <\\Device\\NPF_{416E2ED0-46A1-4868-957A-E0811C91C17D}> Rule 7 WEB-IIS ASP contents view [**]\n[Classification: Web Application Attack] [Priority: 1] \n03/04-21:24:38.344937 137.207.234.252:13873 -> 172.16.1.2:80\nTCP TTL:128 TOS:0x0 ID:0 IpLen:20 DgmLen:88 DF\n***A**** Seq: 0xE6475973  Ack: 0x6158E1E9  Win: 0x4000  TcpLen: 20\n[Xref => http://www.securityfocus.com/bid/1084][Xref => http://cve.mitre.org/cgi-bin/cvename.cgi?name=CAN-2000-0302]"

		};

        public Form1()
        {
            InitializeComponent();


            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (String rule in rules)
            {
                RuleModel ruleModel = RuleModel.parse(rule);

            }

            foreach (String log in logs)
            {
                LogModel logModel = LogModel.parse(log);
            }
            /*
            String[] lines = textBox1.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);

            foreach (String line in lines)
            {
                RuleModel rule = RuleModel.parse(line);
            }*/
        }
        
    }



}
