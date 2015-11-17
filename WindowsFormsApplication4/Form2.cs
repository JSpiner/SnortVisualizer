using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Thread initThread = new Thread(initSocket);
            initThread.Start();
//			initSocket ();

            //			while (true) {
			//	sendMessage ("{\"type\":1,\n\"raw\":\"VGhpcyBpcyBzbm9ydCB0ZXN0IGRhdGEgpHi4IEykuCBwdDA=\"}");
				//Thread.Sleep (10000);
			//}
        }

        
		Socket sender;



		void receiveData(){
			while (true) {


				byte[] bytes = new byte[1024];


				int bytesRec = sender.Receive(bytes);

				if (bytesRec != 0) {
					Console.WriteLine ("Receive : {0} {1}",
						Encoding.ASCII.GetString (bytes, 0,bytesRec),
						bytesRec);
				}
			}
		}

		void initSocket(){

            String ip = textBox1.Text;
            String port = textBox2.Text;

			IPHostEntry ipHost = Dns.Resolve(ip);
			IPAddress ipAddr = ipHost.AddressList[0];
			IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, Convert.ToInt32(port));

            
			Console.WriteLine("Try to connect {0}", (ip+":"+port));
			sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			sender.Connect(ipEndPoint);

			Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());


            receiveData();
		}

		void sendMessage(String str){


			byte[] msg = Encoding.ASCII.GetBytes(str);


			int bytesSent = sender.Send(msg);
			Console.WriteLine ("send data {0}",bytesSent);

		}
	}
    
}
