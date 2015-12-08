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
    public partial class SocketForm : MaterialForm
    {

        Socket sender;

        MainForm parent;

        public SocketForm(MainForm parent)
        {
            this.parent = parent;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme =// new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void SocketForm_Load(object sender, EventArgs e)
        {
            init();
        }

        void init()
        {


        }


        void initSocket()
        {

            String ip = "192.168.1.1";
            String port = "9999";


            IPHostEntry ipHost = Dns.Resolve(ip);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, Convert.ToInt32(port));


            WriteLine("Try to connect "+ip+":"+port);

            try
            {
                sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(ipEndPoint);

                WriteLine("Socket connected to "+ sender.RemoteEndPoint.ToString());
            }
            catch (Exception err)
            {
                WriteLine("error : " + err.Message);
                initSocket();
                return;
            }

            receiveData();

        }

        void receiveData()
        {

            StringBuilder builder = new StringBuilder();

            while (true)
            {


                byte[] bytes = new byte[1024];


                int bytesRec = sender.Receive(bytes);

                if (bytesRec != 0)
                {
                    WriteLine("Receive "+
                       Encoding.ASCII.GetString(bytes, 0, bytesRec)+" "+
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
                        parent.logList.Add(model);
                        String[] datas = {
                     "log",
                     model.logBody.ipHeader.protocol.ToString(),
                     model.logBody.senderIp,
                     model.logBody.receiverIp,
                     model.logHeader.alertSig.alertMsg};
                        /*
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
                        listView1.Invoke(new DelegateFunction(addItem), new object[] { item });
                        //                        listView1.Items.Add(item);
                        */
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
                    case 6:

                        FLogModel flog = new FLogModel(obj.raw);
                        MainForm.fLogList.Add(flog);
                        
                        ListViewItem fw_item = null;
                        fw_item = new ListViewItem(flog.IN);
                        fw_item.SubItems.Add(flog.OUT);
                        fw_item.SubItems.Add(flog.msg); 
                        
                        parent.listView1.Invoke(new MainForm.DelegateFunction(fw_addItem), new object[] { fw_item });

                        fw_Log fwlog = new fw_Log(obj.raw);
                        //MessageBox.Show("sip:" + fwlog.Src_ip + " dip:" + fwlog.Dest_ip);
                        //MessageBox.Show(fwlog.raw);
                        fw_item = null;
                        fw_item = new ListViewItem(fwlog.Src_ip);
                        fw_item.SubItems.Add(fwlog.Dest_ip);
                        fw_item.SubItems.Add(fwlog.raw); 
                        
                        parent.fw_log_listview.Invoke(new MainForm.DelegateFunction(fw_addItem), new object[] { fw_item });
                        //fw_log_listview.Items.Add(fw_item);
                        break;

                }
            }
            catch (Exception e)
            {
                //                sendMessage("{\"type\":3, \"msg\":\"error\"");
                WriteLine("parse error" + e.Message);
            }
        }


        void fw_addItem(ListViewItem item)
        {
            parent.fw_log_listview.Items.Add(item);
        }

        void WriteLine(String str)
        {

            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(WriteLine), new object[] { str });
                return;
            }
            textBox1.AppendText(str+"\n");
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

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            WriteLine("connection start");
            Thread initThread = new Thread(initSocket);
            initThread.Start();
        }

    }
}