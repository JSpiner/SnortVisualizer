using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{

    public partial class Ruleedit : MaterialForm
    {
        public MainForm main;
        public ListView listview;
        public Ruleedit()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme =// new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
            new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        public void rule_set()
        {
            String str = "/root/snort_rule";
            main.socketManager.sendMessage(2, str);
        }
        public void new_rule(int count) {
            String str = null;
            if (!tb_Action.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].action=" + tb_Action.Text;
                main.socketManager.sendMessage(4, str);
            }
            if (!tb_Protocol.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].protocol=" + tb_Protocol.Text;
                main.socketManager.sendMessage(4, str);
            }
            if (!tb_SrcIP.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].srcip=" + tb_SrcIP.Text;
                main.socketManager.sendMessage(4, str);
            }
            if (!tb_SrcPort.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].srcport=" + tb_SrcPort.Text;
                main.socketManager.sendMessage(4, str);
            }
            if (!tb_DestIP.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].destip=" + tb_DestIP.Text;
                main.socketManager.sendMessage(4, str);
            }
            if (!tb_DestPort.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].destport=" + tb_DestPort.Text;
                main.socketManager.sendMessage(4, str);
            }
            if (!tb_Msg.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].msg='" + tb_Msg.Text +"'";
                main.socketManager.sendMessage(4, str);
            }
            if (!tb_Content.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].content='" + tb_Content.Text +"'";
                main.socketManager.sendMessage(4, str);
            }
            if (!tb_Sid.Text.Equals(""))
            {
                str = "uci set snort_rule.@rule[" + count.ToString() + "].sid=" + tb_Sid.Text;
                main.socketManager.sendMessage(4, str);
            }
            rule_set();
        }
        private void register_bt_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = this.listview.Items.Count;
            ListViewItem item = null;

            item = new ListViewItem(tb_Action.Text);
            item.SubItems.Add(tb_Protocol.Text);
            item.SubItems.Add(tb_SrcIP.Text);
            item.SubItems.Add(tb_SrcPort.Text);
            item.SubItems.Add(tb_DestIP.Text);
            item.SubItems.Add(tb_DestPort.Text);
            item.SubItems.Add(tb_Msg.Text);
            item.SubItems.Add(tb_Content.Text);
            item.SubItems.Add(tb_Sid.Text);

            //main.Rule_listView.Items.Add(item);
            listview.Items.Add(item);
            /*String str = tb_Action.Text + " " + tb_Protocol.Text + " " + tb_SrcIP.Text + " " + tb_SrcPort.Text + " -> " + tb_DestIP.Text + " " + tb_DestPort.Text + " (msg:\"" + tb_Msg.Text + "\"; content:\"" + tb_Content.Text + "\"; sid:" + tb_Sid.Text + ";)";
            MessageBox.Show(str);
            main.socketManager.sendMessage(4, str);*/
            String str = "uci add snort_rule rule";
            main.socketManager.sendMessage(4, str);
            new_rule(count);
        }


    }
}
