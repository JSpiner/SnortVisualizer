using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class fw_Ruleedit : MaterialForm
    {
        public MainForm main;
        public ListView listview;

        public fw_Ruleedit()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme =// new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        public void fw_rule_set()
        {
            String str = "/etc/init.d/firewall restart";
            main.socketManager.sendMessage(2, str);
        }
        public void new_rule(int count)
        {
            String str = null;
            if (!tb_fw_Name.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].name=" + tb_fw_Name.Text;
                main.socketManager.sendMessage(5, str);
            }
            if (!tb_fw_Src.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].src=" + tb_fw_Src.Text;
                main.socketManager.sendMessage(5, str);
            }
            if (!tb_fw_Proto.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].proto=" + tb_fw_Proto.Text;
                main.socketManager.sendMessage(5, str);
            }
            if (!tb_fw_SrcIP.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].src_ip=" + tb_fw_SrcIP.Text;
                main.socketManager.sendMessage(5, str);
            }
            if (!tb_fw_SrcPort.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].src_port=" + tb_fw_SrcPort.Text;
                main.socketManager.sendMessage(5, str);
            }
            if (!tb_fw_DestIP.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].dest_ip=" + tb_fw_DestIP.Text;
                main.socketManager.sendMessage(5, str);
            }
            if (!tb_fw_DestPort.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].dest_port=" + tb_fw_DestPort.Text;
                main.socketManager.sendMessage(5, str);
            }
            if (!tb_fw_Family.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].family=" + tb_fw_Family.Text;
                main.socketManager.sendMessage(5, str);
            }
            if (!tb_fw_Target.Text.Equals(""))
            {
                str = "uci set firewall.@rule[" + count.ToString() + "].target=" + tb_fw_Target.Text;
                main.socketManager.sendMessage(5, str);
            }

            fw_rule_set();
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
            main.socketManager.sendMessage(5, str);
            new_rule(count);
        }
    }
}
