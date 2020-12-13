
namespace AppWFGenProject
{
    partial class GenProject
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chlTable = new System.Windows.Forms.CheckedListBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.btnLoadTable = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnTestConnec = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.rbtCMD = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.rbtRead = new System.Windows.Forms.RadioButton();
            this.rbtHtml = new System.Windows.Forms.RadioButton();
            this.tbcConfigGen = new System.Windows.Forms.TabControl();
            this.tbpCUDR = new System.Windows.Forms.TabPage();
            this.tbpHtml = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.tbcConfigGen.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.tbcConfigGen);
            this.groupBox1.Controls.Add(this.rbtHtml);
            this.groupBox1.Controls.Add(this.rbtRead);
            this.groupBox1.Controls.Add(this.rbtCMD);
            this.groupBox1.Controls.Add(this.chlTable);
            this.groupBox1.Controls.Add(this.lbl7);
            this.groupBox1.Controls.Add(this.txtDB);
            this.groupBox1.Controls.Add(this.lbl6);
            this.groupBox1.Controls.Add(this.btnLoadTable);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.btnTestConnec);
            this.groupBox1.Controls.Add(this.lbl2);
            this.groupBox1.Controls.Add(this.lbl3);
            this.groupBox1.Controls.Add(this.lbl4);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(932, 418);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GenCode";
            // 
            // chlTable
            // 
            this.chlTable.CheckOnClick = true;
            this.chlTable.FormattingEnabled = true;
            this.chlTable.Location = new System.Drawing.Point(13, 111);
            this.chlTable.Name = "chlTable";
            this.chlTable.Size = new System.Drawing.Size(166, 292);
            this.chlTable.TabIndex = 14;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(587, 41);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(25, 15);
            this.lbl7.TabIndex = 13;
            this.lbl7.Text = "DB:";
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(618, 37);
            this.txtDB.Name = "txtDB";
            this.txtDB.PlaceholderText = "QuanLyDuAn";
            this.txtDB.Size = new System.Drawing.Size(140, 23);
            this.txtDB.TabIndex = 11;
            // 
            // lbl6
            // 
            this.lbl6.Location = new System.Drawing.Point(0, 0);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(100, 23);
            this.lbl6.TabIndex = 12;
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.Location = new System.Drawing.Point(845, 37);
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTable.TabIndex = 9;
            this.btnLoadTable.Text = "Load Table";
            this.btnLoadTable.UseVisualStyleBackColor = false;
            this.btnLoadTable.Click += new System.EventHandler(this.btnLoadTable_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(247, 37);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "trienpc";
            this.txtUser.Size = new System.Drawing.Size(139, 23);
            this.txtUser.TabIndex = 8;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(431, 37);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(140, 23);
            this.txtPass.TabIndex = 7;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(61, 38);
            this.txtServer.Name = "txtServer";
            this.txtServer.PlaceholderText = "db.tayho.net.vn";
            this.txtServer.Size = new System.Drawing.Size(138, 23);
            this.txtServer.TabIndex = 6;
            // 
            // btnTestConnec
            // 
            this.btnTestConnec.Location = new System.Drawing.Point(764, 38);
            this.btnTestConnec.Name = "btnTestConnec";
            this.btnTestConnec.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnec.TabIndex = 5;
            this.btnTestConnec.Text = "Test Connect";
            this.btnTestConnec.UseVisualStyleBackColor = false;
            this.btnTestConnec.Click += new System.EventHandler(this.btnTestConnec_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(208, 41);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(33, 15);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "User:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(392, 41);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(33, 15);
            this.lbl3.TabIndex = 3;
            this.lbl3.Text = "Pass:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(13, 90);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(65, 15);
            this.lbl4.TabIndex = 1;
            this.lbl4.Text = "Danh sách:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(13, 41);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(42, 15);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Server:";
            // 
            // rbtCMD
            // 
            this.rbtCMD.AutoSize = true;
            this.rbtCMD.Location = new System.Drawing.Point(208, 122);
            this.rbtCMD.Name = "rbtCMD";
            this.rbtCMD.Size = new System.Drawing.Size(52, 19);
            this.rbtCMD.TabIndex = 15;
            this.rbtCMD.TabStop = true;
            this.rbtCMD.Text = "CMD";
            this.rbtCMD.UseVisualStyleBackColor = true;
            // 
            // rbtRead
            // 
            this.rbtRead.AutoSize = true;
            this.rbtRead.Location = new System.Drawing.Point(208, 156);
            this.rbtRead.Name = "rbtRead";
            this.rbtRead.Size = new System.Drawing.Size(51, 19);
            this.rbtRead.TabIndex = 16;
            this.rbtRead.TabStop = true;
            this.rbtRead.Text = "Read";
            this.rbtRead.UseVisualStyleBackColor = true;
            // 
            // rbtHtml
            // 
            this.rbtHtml.AutoSize = true;
            this.rbtHtml.Location = new System.Drawing.Point(208, 196);
            this.rbtHtml.Name = "rbtHtml";
            this.rbtHtml.Size = new System.Drawing.Size(57, 19);
            this.rbtHtml.TabIndex = 17;
            this.rbtHtml.TabStop = true;
            this.rbtHtml.Text = "HTML";
            this.rbtHtml.UseVisualStyleBackColor = true;
            // 
            // tbcConfigGen
            // 
            this.tbcConfigGen.Controls.Add(this.tbpCUDR);
            this.tbcConfigGen.Controls.Add(this.tbpHtml);
            this.tbcConfigGen.Location = new System.Drawing.Point(290, 122);
            this.tbcConfigGen.Name = "tbcConfigGen";
            this.tbcConfigGen.SelectedIndex = 0;
            this.tbcConfigGen.Size = new System.Drawing.Size(630, 281);
            this.tbcConfigGen.TabIndex = 18;
            // 
            // tbpCUDR
            // 
            this.tbpCUDR.Location = new System.Drawing.Point(4, 24);
            this.tbpCUDR.Name = "tbpCUDR";
            this.tbpCUDR.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCUDR.Size = new System.Drawing.Size(622, 253);
            this.tbpCUDR.TabIndex = 0;
            this.tbpCUDR.Text = "CUDR";
            this.tbpCUDR.UseVisualStyleBackColor = true;
            // 
            // tbpHtml
            // 
            this.tbpHtml.Location = new System.Drawing.Point(4, 24);
            this.tbpHtml.Name = "tbpHtml";
            this.tbpHtml.Padding = new System.Windows.Forms.Padding(3);
            this.tbpHtml.Size = new System.Drawing.Size(622, 253);
            this.tbpHtml.TabIndex = 1;
            this.tbpHtml.Text = "HTML";
            this.tbpHtml.UseVisualStyleBackColor = true;
            // 
            // GenProject
            // 
            this.ClientSize = new System.Drawing.Size(932, 429);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenProject";
            this.Text = "GenProjectNetCore";
            this.Load += new System.EventHandler(this.GenProject_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbcConfigGen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestConnec;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnLoadTable;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.CheckedListBox chlTable;
        private System.Windows.Forms.TabControl tbcConfigGen;
        private System.Windows.Forms.TabPage tbpCUDR;
        private System.Windows.Forms.TabPage tbpHtml;
        private System.Windows.Forms.RadioButton rbtHtml;
        private System.Windows.Forms.RadioButton rbtRead;
        private System.Windows.Forms.RadioButton rbtCMD;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

