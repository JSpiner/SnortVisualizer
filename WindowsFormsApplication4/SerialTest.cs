using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    class SerialTest
    {
        SerialPort serialPort;

        public SerialTest()
        {
            serialPort = new SerialPort("COM3");
            serialPort.Open();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String str = serialPort.ReadTo("\r\n");
            MessageBox.Show("msg : "+str);

        }


    }
}
