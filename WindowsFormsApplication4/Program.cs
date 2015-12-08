using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

//            String test = "[**] [1:100001:0] ICMP packet!!!!! [**]\n[Priority: 0]\n12/06-14:48:29.604993 192.168.1.2 -> 192.168.1.1\nICMP TTL:64 TOS:0x0 ID:12012 IpLen:20 DgmLen:84 \nType:8  Code:0  ID:2556   Seq:2  ECHO";
            String test = "[**] [1:100001:0] ICMP packet!!!!! [**]\n[Priority: 0]\n12/06-14:48:29.605160 192.168.1.1 -> 192.168.1.2\nICMP TTL:64 TOS:0x0 ID:64650 IpLen:20 DgmLen:84\nType:0  Code:0  ID:2556  Seq:2  ECHO REPLY";
            LogModel model = LogModel.parse(test);

        }
    }
}
