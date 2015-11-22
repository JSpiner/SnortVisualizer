using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using WindowsFormsApplication4.Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication4
{
    public partial class MainForm : MaterialForm
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

        public List<LogModel> logList;

        public MainForm()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme =// new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                init();
            }

            SerialTest t = new SerialTest();
        }

        private void init()
        {

            listView1.Columns[0].Width = 50;
            listView1.Columns[1].Width = 80;
            listView1.Columns[2].Width = 120;
            listView1.Columns[3].Width = 120;
            listView1.Columns[4].Width = 300;


            Panel  p = panel1;
           
                  
            foreach (String log in logs)
            {
                LogModel model = LogModel.parse(log);
                this.logList.Add(model);
                String[] datas = {
                                        "log",
                                        model.logBody.ipHeader.protocol.ToString(),
                                        model.logBody.senderIp,
                                        model.logBody.receiverIp,
                                        model.logHeader.alertSig.alertMsg};

                ListViewItem item=null;
                foreach (String data in datas)
                {
                    if (item == null)
                    {
                        item = new ListViewItem(data);
                    }
                    else
                    {
                        item.SubItems.Add(data);
                    }

                }
                

                listView1.Items.Add(item);

            }

            for (int i = 0; i < 20; i++)
            {
                Label label = new Label();
                label.Text = "asdfasdf";
                p.Controls.Add(label);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            int[] intValue = { 1,2,3,4,5,6,7,8,9 };
            String[] stringValue = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };

            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
;

            series.Name = (stringValue[0]);
            for (int i = 0; i < 9; i++)
            {
                series.Points.Add(intValue[i]);

               
            }
            chart1.Series.Add(series);


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {


        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            materialTabSelector1.Size = new Size(Width, materialTabSelector1.Size.Height);
            tabPage1.Size = new Size(Width, Height);
            tabPage2.Size = new Size(Width, Height);
            tabPage3.Size = new Size(Width, Height);
            listView1.Size = new Size(Width-100, Height-100);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://192.168.0.2");
        }

        private void analysis()
        {


            List<AnalData> ipList = new List<AnalData>();
            List<AnalData> portList = new List<AnalData>();
            List<AnalData> dateList = new List<AnalData>();

            foreach (LogModel model in logList)
            {

                Boolean sw = false;
                foreach (AnalData data in ipList)
                {
                    if (data.name == model.logBody.receiverIp)
                    {
                        sw = true;
                        data.count++;
                        break;
                    }
                }
                if (!sw)
                {
                    AnalData tmp = new AnalData();
                    tmp.name = model.logBody.receiverIp;
                    ipList.Add(tmp);
                }

                sw = false;
                foreach (AnalData data in portList)
                {
                    if (data.name == model.logBody.receiverPort)
                    {
                        sw = true;
                        data.count++;
                        break;
                    }
                }
                if (!sw)
                {
                    AnalData tmp = new AnalData();
                    tmp.name = model.logBody.receiverPort;
                    portList.Add(tmp);
                }

                sw = false;
                foreach (AnalData data in dateList)
                {

                }

            }


        }

        class AnalData
        {
            public String name;
            public int count;
        }
    }
}
