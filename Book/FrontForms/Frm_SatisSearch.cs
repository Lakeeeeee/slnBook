using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book.FrontForms
{
    public partial class Frm_SatisSearch : Form
    {
        public Frm_SatisSearch(CustomerService cs)
        {
            InitializeComponent();
            getcs(cs);
        }
        CMemberManager cmm = new CMemberManager();
        CustomerService targer;
        private void getcs(CustomerService inx)
        {
            targer = inx;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            CustomerService upatetarget = cmm.dbContent.CustomerServices.Find(targer.CRMID);
            upatetarget.Satisfaction = int.Parse(comboBox1.Text);
            upatetarget.StatusID = 7;
            cmm.dbContent.SaveChanges();
            MessageBox.Show("感謝您的填寫");
        }
    }
}
