namespace WindowsFormsApplication4
{
    partial class Ruleedit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Action = new System.Windows.Forms.Label();
            this.Protocol = new System.Windows.Forms.Label();
            this.SrcIP = new System.Windows.Forms.Label();
            this.SrcPort = new System.Windows.Forms.Label();
            this.DestIP = new System.Windows.Forms.Label();
            this.DestPort = new System.Windows.Forms.Label();
            this.Msg = new System.Windows.Forms.Label();
            this.Content = new System.Windows.Forms.Label();
            this.Sid = new System.Windows.Forms.Label();
            this.tb_Action = new System.Windows.Forms.TextBox();
            this.tb_Protocol = new System.Windows.Forms.TextBox();
            this.tb_SrcIP = new System.Windows.Forms.TextBox();
            this.tb_SrcPort = new System.Windows.Forms.TextBox();
            this.tb_DestIP = new System.Windows.Forms.TextBox();
            this.tb_DestPort = new System.Windows.Forms.TextBox();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.tb_Content = new System.Windows.Forms.TextBox();
            this.tb_Sid = new System.Windows.Forms.TextBox();
            this.register_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Action
            // 
            this.Action.AutoSize = true;
            this.Action.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Action.Location = new System.Drawing.Point(13, 12);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(51, 13);
            this.Action.TabIndex = 0;
            this.Action.Text = "Action";
            // 
            // Protocol
            // 
            this.Protocol.AutoSize = true;
            this.Protocol.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Protocol.Location = new System.Drawing.Point(13, 43);
            this.Protocol.Name = "Protocol";
            this.Protocol.Size = new System.Drawing.Size(67, 13);
            this.Protocol.TabIndex = 1;
            this.Protocol.Text = "Protocol";
            // 
            // SrcIP
            // 
            this.SrcIP.AutoSize = true;
            this.SrcIP.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SrcIP.Location = new System.Drawing.Point(13, 74);
            this.SrcIP.Name = "SrcIP";
            this.SrcIP.Size = new System.Drawing.Size(46, 13);
            this.SrcIP.TabIndex = 2;
            this.SrcIP.Text = "SrcIP";
            // 
            // SrcPort
            // 
            this.SrcPort.AutoSize = true;
            this.SrcPort.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SrcPort.Location = new System.Drawing.Point(13, 105);
            this.SrcPort.Name = "SrcPort";
            this.SrcPort.Size = new System.Drawing.Size(61, 13);
            this.SrcPort.TabIndex = 3;
            this.SrcPort.Text = "SrcPort";
            // 
            // DestIP
            // 
            this.DestIP.AutoSize = true;
            this.DestIP.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DestIP.Location = new System.Drawing.Point(13, 136);
            this.DestIP.Name = "DestIP";
            this.DestIP.Size = new System.Drawing.Size(53, 13);
            this.DestIP.TabIndex = 4;
            this.DestIP.Text = "DestIP";
            // 
            // DestPort
            // 
            this.DestPort.AutoSize = true;
            this.DestPort.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DestPort.Location = new System.Drawing.Point(13, 167);
            this.DestPort.Name = "DestPort";
            this.DestPort.Size = new System.Drawing.Size(68, 13);
            this.DestPort.TabIndex = 5;
            this.DestPort.Text = "DestPort";
            // 
            // Msg
            // 
            this.Msg.AutoSize = true;
            this.Msg.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Msg.Location = new System.Drawing.Point(13, 198);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(37, 13);
            this.Msg.TabIndex = 6;
            this.Msg.Text = "Msg";
            // 
            // Content
            // 
            this.Content.AutoSize = true;
            this.Content.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Content.Location = new System.Drawing.Point(13, 229);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(61, 13);
            this.Content.TabIndex = 7;
            this.Content.Text = "Content";
            // 
            // Sid
            // 
            this.Sid.AutoSize = true;
            this.Sid.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Sid.Location = new System.Drawing.Point(13, 260);
            this.Sid.Name = "Sid";
            this.Sid.Size = new System.Drawing.Size(30, 13);
            this.Sid.TabIndex = 8;
            this.Sid.Text = "Sid";
            // 
            // tb_Action
            // 
            this.tb_Action.Location = new System.Drawing.Point(93, 9);
            this.tb_Action.Name = "tb_Action";
            this.tb_Action.Size = new System.Drawing.Size(190, 21);
            this.tb_Action.TabIndex = 9;
            // 
            // tb_Protocol
            // 
            this.tb_Protocol.Location = new System.Drawing.Point(93, 40);
            this.tb_Protocol.Name = "tb_Protocol";
            this.tb_Protocol.Size = new System.Drawing.Size(190, 21);
            this.tb_Protocol.TabIndex = 10;
            // 
            // tb_SrcIP
            // 
            this.tb_SrcIP.Location = new System.Drawing.Point(93, 71);
            this.tb_SrcIP.Name = "tb_SrcIP";
            this.tb_SrcIP.Size = new System.Drawing.Size(190, 21);
            this.tb_SrcIP.TabIndex = 11;
            // 
            // tb_SrcPort
            // 
            this.tb_SrcPort.Location = new System.Drawing.Point(93, 102);
            this.tb_SrcPort.Name = "tb_SrcPort";
            this.tb_SrcPort.Size = new System.Drawing.Size(190, 21);
            this.tb_SrcPort.TabIndex = 12;
            // 
            // tb_DestIP
            // 
            this.tb_DestIP.Location = new System.Drawing.Point(93, 133);
            this.tb_DestIP.Name = "tb_DestIP";
            this.tb_DestIP.Size = new System.Drawing.Size(190, 21);
            this.tb_DestIP.TabIndex = 13;
            // 
            // tb_DestPort
            // 
            this.tb_DestPort.Location = new System.Drawing.Point(93, 166);
            this.tb_DestPort.Name = "tb_DestPort";
            this.tb_DestPort.Size = new System.Drawing.Size(190, 21);
            this.tb_DestPort.TabIndex = 14;
            // 
            // tb_Msg
            // 
            this.tb_Msg.Location = new System.Drawing.Point(93, 195);
            this.tb_Msg.Name = "tb_Msg";
            this.tb_Msg.Size = new System.Drawing.Size(190, 21);
            this.tb_Msg.TabIndex = 15;
            // 
            // tb_Content
            // 
            this.tb_Content.Location = new System.Drawing.Point(93, 226);
            this.tb_Content.Name = "tb_Content";
            this.tb_Content.Size = new System.Drawing.Size(190, 21);
            this.tb_Content.TabIndex = 16;
            // 
            // tb_Sid
            // 
            this.tb_Sid.Location = new System.Drawing.Point(93, 257);
            this.tb_Sid.Name = "tb_Sid";
            this.tb_Sid.Size = new System.Drawing.Size(190, 21);
            this.tb_Sid.TabIndex = 17;
            // 
            // register_bt
            // 
            this.register_bt.Location = new System.Drawing.Point(208, 284);
            this.register_bt.Name = "register_bt";
            this.register_bt.Size = new System.Drawing.Size(75, 23);
            this.register_bt.TabIndex = 18;
            this.register_bt.Text = "button1";
            this.register_bt.UseVisualStyleBackColor = true;
            this.register_bt.Click += new System.EventHandler(this.register_bt_Click);
            // 
            // Ruleedit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 316);
            this.Controls.Add(this.register_bt);
            this.Controls.Add(this.tb_Sid);
            this.Controls.Add(this.tb_Content);
            this.Controls.Add(this.tb_Msg);
            this.Controls.Add(this.tb_DestPort);
            this.Controls.Add(this.tb_DestIP);
            this.Controls.Add(this.tb_SrcPort);
            this.Controls.Add(this.tb_SrcIP);
            this.Controls.Add(this.tb_Protocol);
            this.Controls.Add(this.tb_Action);
            this.Controls.Add(this.Sid);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.DestPort);
            this.Controls.Add(this.DestIP);
            this.Controls.Add(this.SrcPort);
            this.Controls.Add(this.SrcIP);
            this.Controls.Add(this.Protocol);
            this.Controls.Add(this.Action);
            this.Name = "Ruleedit";
            this.Text = "Ruleedit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Action;
        private System.Windows.Forms.Label Protocol;
        private System.Windows.Forms.Label SrcIP;
        private System.Windows.Forms.Label SrcPort;
        private System.Windows.Forms.Label DestIP;
        private System.Windows.Forms.Label DestPort;
        private System.Windows.Forms.Label Msg;
        private System.Windows.Forms.Label Content;
        private System.Windows.Forms.Label Sid;
        private System.Windows.Forms.TextBox tb_Action;
        private System.Windows.Forms.TextBox tb_Protocol;
        private System.Windows.Forms.TextBox tb_SrcIP;
        private System.Windows.Forms.TextBox tb_SrcPort;
        private System.Windows.Forms.TextBox tb_DestIP;
        private System.Windows.Forms.TextBox tb_DestPort;
        private System.Windows.Forms.TextBox tb_Msg;
        private System.Windows.Forms.TextBox tb_Content;
        private System.Windows.Forms.TextBox tb_Sid;
        private System.Windows.Forms.Button register_bt;
    }
}