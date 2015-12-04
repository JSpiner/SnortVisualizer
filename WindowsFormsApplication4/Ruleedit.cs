using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{

    public partial class Ruleedit : Form
    {
        public MainForm main;
        public ListView listview;
        public Ruleedit()
        {
            InitializeComponent();
        }

        private void register_bt_Click(object sender, EventArgs e)
        {
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
            String str = tb_Action.Text + " " + tb_Protocol.Text + " " + tb_SrcIP.Text + " " + tb_SrcPort.Text + " -> " + tb_DestIP.Text + " " + tb_DestPort.Text + " (msg:\"" + tb_Msg.Text + "\"; content:\"" + tb_Content.Text + "\"; sid:" + tb_Sid.Text + ";)";
            MessageBox.Show(str);
            main.socketManager.sendMessage(4, str);
        }


    }
}
