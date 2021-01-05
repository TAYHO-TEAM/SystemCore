using AppWFGenProject.Extensions;
using AppWFGenProject.FrameWork;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWFGenProject
{
    public partial class GenProject : Form
    {
        public IConfiguration _configuration;
        public GenProject(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializeComponent();
            Environment.GetEnvironmentVariable("Content");
            txtPass.PasswordChar = '*';
            txtServer.Text = "db.tayho.net.vn";
            txtUser.Text = "trienpc";
            txtDB.Text = "QuanLyDuAn";
            btnGen.Enabled = false;
        }

        private void GenProject_Load(object sender, EventArgs e)
        {
            ConfigExtenstions.GetValue<int>(_configuration, "appSettings", "DefaultItemsPerPage");
        }

        private void btnTestConnec_Click(object sender, EventArgs e)
        {
            Connection newConn = new Connection();
            if (newConn.ConnectTest(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text))
            {
                MessageBox.Show("Kết nối thành công!", "Thông tin kết nối", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Kết nối không thành công!", "Lỗi kết nối", MessageBoxButtons.OK);
            }

        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            Connection newConn = new Connection();
            var listTB = newConn.GetAllTable(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text);
            foreach (string TB in listTB)
            {
                chlTable.Items.Add(TB, false);
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            GenOB genOB = new GenOB();
            GenCode genCode = new GenCode();
            string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            List<string> listTable = new List<string>();
            ReadTemplate readTemplate = new ReadTemplate();
            // Set nameproject
            genOB.nameproject = txtNameProject.Text == "" ? "Test" : txtNameProject.Text;
            // Set rootDir
            genOB.rootDir = txtDir.Text==""?@"F:\Test\" : txtDir.Text;
            // Set common
            genOB.common = "Services.Common.APIs.Cmd.EF;"; // config setting tạo sau
            // Set db
            genOB.db = "QuanLyDuAnContext"; // config setting tạo sau
            // Set version 
            genOB.version = "1"; // config setting tạo sau


            int typeCreate = cbkOverWrite.Checked ? 1 : cbkOverWrite.Checked ? 2 : cbkBackUp.Checked ? 3 : -1;
            if (typeCreate <= 0)
                MessageBox.Show("Bạn chưa chọn cách tạo file. Vui lòng chọn cách tạo file", "Thông báo!");

            for (int i = 0; i < chlTable.Items.Count; i++)
            {
                if (chlTable.GetItemChecked(i))
                {
                    listTable.Add((string)chlTable.Items[i]);
                    genOB.Entity = (string)chlTable.Items[i];
                    // sert _entity
                    if (genOB.Entity != string.Empty && char.IsUpper(genOB.Entity[0]))
                    {
                        genOB._entity = "_"+(char.ToLower(genOB.Entity[0]) + genOB.Entity.Substring(1));
                    }
                    genCode.CreateGenOBCMD(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text, listTable[0], genOB);
                }
            }
           
            //FileHelper fileHelper = new FileHelper();
            //fileHelper.ChangeTxtToCS(@"C:\Users\poka\Desktop\testChange.txt");
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtDir.Text = fbd.SelectedPath;
                    btnGen.Enabled = true;
                }
            }
        }

        private void cbkOverWrite_CheckedChanged(object sender, EventArgs e)
        {
            cbkBackUp.Checked = false;
            cbkCreateNew.Checked = false;
        }

        private void cbkCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            cbkBackUp.Checked = false;
            cbkOverWrite.Checked = false;
        }

        private void cbkBackUp_CheckedChanged(object sender, EventArgs e)
        {
            cbkCreateNew.Checked = false;
            cbkOverWrite.Checked = false;
        }
    }
}
