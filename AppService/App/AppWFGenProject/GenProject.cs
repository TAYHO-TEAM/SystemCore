using AppWFGenProject.Extensions;
using AppWFGenProject.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWFGenProject
{
    public partial class GenProject : Form
    {
        public GenProject()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
            txtServer.Text = "db.tayho.net.vn";
            txtUser.Text = "trienpc";
            txtDB.Text = "QuanLyDuAn";
        }



        private void GenProject_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show("Kết nối không thành công!","Lỗi kết nối", MessageBoxButtons.OK);
            }

        }

        private void btnLoadTable_Click(object sender, EventArgs e)
        {
            Connection newConn = new Connection();
            var listTB = newConn.GetAllTable(txtServer.Text, txtUser.Text, txtPass.Text, txtDB.Text);
            foreach(string TB in listTB)
            {
                chlTable.Items.Add(TB,false);
            }    
           
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            GenOB genOB = new GenOB();

            //FileHelper fileHelper = new FileHelper();
            //fileHelper.ChangeTxtToCS(@"C:\Users\poka\Desktop\testChange.txt");
        }
    }
}
