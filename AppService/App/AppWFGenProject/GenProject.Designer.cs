
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl4);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(932, 418);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GenCode";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server:";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(13, 90);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(42, 15);
            this.lbl4.TabIndex = 1;
            this.lbl4.Text = "Server:";
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
            // GenProject
            // 
            this.ClientSize = new System.Drawing.Size(932, 429);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenProject";
            this.Text = "GenProjectNetCore";
            this.Load += new System.EventHandler(this.GenProject_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestConnec;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnLoadTable;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl7;
    }
}

