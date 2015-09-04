using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication4.Model;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] lines = textBox1.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);

            foreach (String line in lines)
            {
                RuleModel rule = RuleModel.parse(line);
            }
        }
        
    }



}
