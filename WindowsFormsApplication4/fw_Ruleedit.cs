using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class fw_Ruleedit : Form
    {
        public MainForm main;
        public ListView listview;

        public fw_Ruleedit()
        {
            InitializeComponent();
        }
        public void new_rule(int count)
        {
            String str = "uci set firewall.@rule["+count.ToString()+"].name="+tb_fw_Name.Text;
            main.sendMessage(5, str);
            str = "uci set firewall.@rule[" + count.ToString() + "].src=" + tb_fw_Src.Text;
            main.sendMessage(5, str);
            str = "uci set firewall.@rule[" + count.ToString() + "].proto=" + tb_fw_Proto.Text;
            main.sendMessage(5, str);
            str = "uci set firewall.@rule[" + count.ToString() + "].src_ip=" + tb_fw_SrcIP.Text;
            main.sendMessage(5, str);
            str = "uci set firewall.@rule[" + count.ToString() + "].src_port=" + tb_fw_SrcPort.Text;
            main.sendMessage(5, str);
            str = "uci set firewall.@rule[" + count.ToString() + "].dest_ip=" + tb_fw_DestIP.Text;
            main.sendMessage(5, str);
            str = "uci set firewall.@rule[" + count.ToString() + "].dest_port=" + tb_fw_DestPort.Text;
            main.sendMessage(5, str);
            str = "uci set firewall.@rule[" + count.ToString() + "].family=" + tb_fw_Family.Text;
            main.sendMessage(5, str);
            str = "uci set firewall.@rule[" + count.ToString() + "].target=" + tb_fw_Target.Text;
            main.sendMessage(5, str);
        }

        private void fw_register_bt_Click(object sender, EventArgs e)
        {
            int count = 0; ;
            count = listview.Items.Count;
            ListViewItem item = null;

            item = new ListViewItem(tb_fw_Name.Text);
            /*item.SubItems.Add(tb_fw_Src.Text);
            item.SubItems.Add(tb_fw_Proto.Text);
            item.SubItems.Add(tb_fw_SrcIP.Text);
            item.SubItems.Add(tb_fw_SrcPort.Text);
            item.SubItems.Add(tb_fw_DestIP.Text);
            item.SubItems.Add(tb_fw_DestPort.Text);
            item.SubItems.Add(tb_fw_Family.Text);
            item.SubItems.Add(tb_fw_Target.Text);*/

            listview.Items.Add(item);
            String str = "uci add firewall rule";
            main.sendMessage(5, str);
            new_rule(count);

        }
    }
}
