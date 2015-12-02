using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using WindowsFormsApplication4.Model;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Json;

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
            Thread initThread = new Thread(initSocket);
            initThread.Start();

            String str = "{ \"type\": 1, \"raw\": \"[**] [1:5:0] icmp in packet!! [**] \n[Priority: 0]\n 10/23-19:52:59.979665 192.168.1.2 -> 192.168.1.1 \n ICMP TTL:64 TOS:0x0 ID:60363 IpLen:20 DgmLen:84 DF\nType:8  Code:0  ID:23811   Seq:2  ECHO \" }";
            init();
            procData(str);
//            SerialTest t = new SerialTest();
        }


        private void init()
        {

            listView1.Columns[0].Width = 50;
            listView1.Columns[1].Width = 80;
            listView1.Columns[2].Width = 120;
            listView1.Columns[3].Width = 120;
            listView1.Columns[4].Width = 300;


            Panel p = panel1;

            logList = new List<LogModel>();

            foreach (String log in logs)
            {
                LogModel model = LogModel.parse(log);
                this.logList.Add(model);

            }

            /*      
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
*/

            for (int i = 0; i < 20; i++)
            {
                Label label = new Label();
                label.Text = "asdfasdf";
                p.Controls.Add(label);
            }



        }

        Socket sender;

        void receiveData()
        {

            StringBuilder builder = new StringBuilder();

            while (true)
            {


                byte[] bytes = new byte[1024];


                int bytesRec = sender.Receive(bytes);

                if (bytesRec != 0)
                {
                    Console.WriteLine("Receive : {0} {1}",
                       Encoding.ASCII.GetString(bytes, 0, bytesRec),
                       bytesRec);
                    String result = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    builder.Append(result);

                    if (result.IndexOf("}") != -1)
                    {
                        procData(builder.ToString());
                        builder.Clear();
                    }
                }
            }
        }

        delegate void DelegateFunction(ListViewItem item);

        void addItem(ListViewItem item)
        {
            listView1.Items.Add(item);
        }

        void procData(String str)
        {

            try
            {
                JEParser parser = JEParser.getInstance(typeof(SocketModel));
                SocketModel obj = (SocketModel)parser.parse(str);

                switch (obj.type)
                {
                    case 1:

                        //String log = base64Decode(obj.raw);//.Split(new[] { "\n" }, StringSplitOptions.None);
                        String log = obj.raw;
                        //foreach (String log in logs)
                        //{
                        LogModel model = LogModel.parse(log);
                        this.logList.Add(model);
                        String[] datas = {
                     "log",
                     model.logBody.ipHeader.protocol.ToString(),
                     model.logBody.senderIp,
                     model.logBody.receiverIp,
                     model.logHeader.alertSig.alertMsg};

                        ListViewItem item = null;
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
                        listView1.Invoke(new DelegateFunction(addItem), new object[] { item});
//                        listView1.Items.Add(item);

                        //}
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;

                }
            }
            catch (Exception e)
            {
//                sendMessage("{\"type\":3, \"msg\":\"error\"");
                Console.WriteLine("parse error"+e.Message);
            }
        }

        public void sendMessage(int type, String str)
        {
            JsonObjectCollection res = new JsonObjectCollection();
            res.Add(new JsonStringValue("type", type.ToString()));
            res.Add(new JsonStringValue("raw", str));
            byte[] msg = Encoding.ASCII.GetBytes(res.ToString());


            MessageBox.Show(str);

            switch (type)
            {
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
            int bytesSent = sender.Send(msg);
            Console.WriteLine("send data {0}", bytesSent);
        }

        String base64Decode(String str)
        {
            Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(System.Convert.FromBase64String(str));
        }

        void initSocket()
        {

            String ip = "192.168.1.1";
            String port = "9999";


            IPHostEntry ipHost = Dns.Resolve(ip);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, Convert.ToInt32(port));


            Console.WriteLine("Try to connect {0}", (ip + ":" + port));

            try
            {
                sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(ipEndPoint);

                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
            }
            catch (Exception err)
            {
                Console.WriteLine("error : " + err.Message);
                initSocket();
                return;
            }

            receiveData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            analysis();

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
            listView1.Size = new Size(Width - 100, Height - 100);
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
                foreach (AnalData data in ipList)
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

            }


            initIPChart(ipList);
            initPortChart(portList);
            initDateList(dateList);
        }

        void initIPChart(List<AnalData> ipList)
        {

            chart1.Series.Clear();

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            series.Name = "ipList";
            for (int i = 0; i < 9; i++)
            {
                if (i >= ipList.Count) break;
                series.Points.Add(ipList[i].count);
                series.Points.Add(ipList[i].count);
            }
            chart1.Series.Add(series);
//            chart2.Series.Add(series);
//            chart3.Series.Add(series);

        }

        void initPortChart(List<AnalData> portList)
        {

            chart2.Series.Clear();

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            series.Name = "portList";
            for (int i = 0; i < 9; i++)
            {
                if (i >= portList.Count) break;
                series.Points.Add(portList[i].count);
                series.Points.Add(portList[i].count);
            }
            chart2.Series.Add(series);

        }

        void initDateList(List<AnalData> dateList)
        {

            chart3.Series.Clear();

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            series.Name = "dateList";
            for (int i = 0; i < 9; i++)
            {
                if (i >= dateList.Count) break;
                series.Points.Add(dateList[i].count);
                series.Points.Add(dateList[i].count);
            }
            chart3.Series.Add(series);

        } 

        class AnalData
        {
            public String name;
            public int count;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.button11.Visible = true;
            this.button12.Visible = false;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.button13.Visible = true;
            this.button14.Visible = false;

            Home_net.ReadOnly = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.button15.Visible = true;
            this.button16.Visible = false;

            Rule_dir.ReadOnly = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.button17.Visible = true;
            this.button18.Visible = false;

            Max_tcp.ReadOnly = false;
            Max_udp.ReadOnly = false;
        }





        private void button11_Click(object sender, EventArgs e)
        {
            this.button12.Visible = true;
            this.button11.Visible = false;

            String item = (String)Interface.SelectedItem;
            sendMessage(3, item);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.button14.Visible = true;
            this.button13.Visible = false;

            String item = "uci set snort.home.HOME_NET=" + Home_net.Text;
            sendMessage(3, item);
            Home_net.ReadOnly = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.button16.Visible = true;
            this.button15.Visible = false;

            String item = "uci set snort.home.RULE_DIR=" + Rule_dir.Text;
            sendMessage(3, item);
            Rule_dir.ReadOnly = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.button18.Visible = true;
            this.button17.Visible = false;

            String item = "uci set snort.preprocessors.stream5_global=':max_tcp " + Max_tcp.Text + ", max_udp " + Max_udp.Text + "'";
            sendMessage(3, item);
            Max_tcp.ReadOnly = true;
            Max_udp.ReadOnly = true;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }



        private void rule_add_bt_Click(object sender, EventArgs e)
        {
            Ruleedit rule_edit = new Ruleedit();
            rule_edit.main = this;
            rule_edit.listview = this.Rule_listView;
            rule_edit.Show();
        }

        private void Snort_button_Click(object sender, EventArgs e)
        {
            //String str = "/etc/init.d/snort restart";
            //sendMessage(2, str);
            fw_Log fwlog = new fw_Log("Nov 28 17:13:01 OpenWrt [  812.000000] Black_List Deny : IN=br-lan OUT= MAC=01:00:5e:00:00:01:4c:5e:0c:39:42:63:08:00 SRC=0.0.0.0 DST=224.0.0.1 LEN=32 TOS=0x00 PREC=0xC0 TTL=1 ID=0 DF PROTO=2");
            MessageBox.Show("sip:" + fwlog.Src_ip + " dip:" + fwlog.Dest_ip);
            ListViewItem item = new ListViewItem(fwlog.Src_ip);
            item.SubItems.Add(fwlog.Dest_ip);
            item.SubItems.Add(fwlog.raw);
            fw_log_listview.Items.Add(item);
        }

        private void fw_rule_add_bt_Click(object sender, EventArgs e)
        {
            fw_Ruleedit fw_rule_edit = new fw_Ruleedit();
            fw_rule_edit.main = this;
            fw_rule_edit.listview = this.fw_Rule_listView;
            fw_rule_edit.Show();
        }

    }
}