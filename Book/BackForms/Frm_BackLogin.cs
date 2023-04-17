using Book.BackForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book
{
    public partial class Frm_BackLogin : Form
    {
        bool isClosed = true;
        public Frm_BackLogin()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            int acount;
            if (!int.TryParse(txtAcount.Text, out acount))
            {
                MessageBox.Show("帳號必須為數字");
                return;
            }

            CEmployeeManage em = new CEmployeeManage();
            CEmployee x = em.queryByAcount(acount);
            if (x != null)
            {
                if (x.password == txtPwd.Text)
                {
                    this.DialogResult = DialogResult.OK;
                    isClosed = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密碼輸入錯誤");
                }
            }
            else
            {
                MessageBox.Show("帳號不存在");
            }
        }

        private void Frm_BackLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isClosed;
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            isClosed = false;
            this.Close();
        }

        private void btn_backDemo_Click(object sender, EventArgs e)
        {
            txtAcount.Text = "951753";
            txtPwd.Text = "qaz951";
        }
    }
}
