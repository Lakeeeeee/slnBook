using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Book.FrontForms
{
    public partial class Frm_registered_member : Form
    {
        BookShopEntities3 dbContent = new BookShopEntities3();
        //
        public Frm_registered_member()
        {
            InitializeComponent();
        }
        private void Frm_registered_member_Load(object sender, EventArgs e)
        {
            var payment = dbContent.Payments.Select(x => x);
            foreach(string item in payment.Select(x=>x.PaymentName))
            {
                this.comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = 5;
        }

        private void cleartextbox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = 5;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cleartextbox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Member m = new Member
            {
                MemberEmail = textBox1.Text,
                MemberPassword = textBox2.Text,
                MemberName = textBox3.Text,
                MemberBrithDate = dateTimePicker1.Value,
                Memberphone = textBox4.Text,
                MemberAddress = textBox5.Text,
                 PaymentID= comboBox1.SelectedIndex+1
            };
            this.dbContent.Members.Add(m);
            this.dbContent.SaveChanges();
            MessageBox.Show("註冊成功");
            this.Close();
        }
    }
}
