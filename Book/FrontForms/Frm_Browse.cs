using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book.FrontForms
{
    public partial class Frm_Browse : Form
    {
        public Frm_Browse(Member member, object sender, int bookid=-1)
        {
            InitializeComponent();
            cmm.loadMember(member);
            if (sender is Button)
            {
                Button btn = (Button)sender;
                if (btn.Name == "btn_passwordadict")
                {
                    tB1.TextChanged += tB1_TextChanged;
                    btn_check.Click += btn_passwordcheck_Click;
                }
                else if(btn.Name == "btn_comment")
                {
                    label1.Text= $"請留下您對「{dbContent.Books.Find(bookid).BookTitle}」的評價";
                    lab_title.Visible= false; label27.Visible = false; tB1.Multiline = true; tB1.Size = new Size(230, 100); 
                    tB1.ScrollBars= ScrollBars.Vertical; cb = new ComboBox(); cb.Items.AddRange(new object[] { 1, 2, 3, 4, 5 });
                    Label x = new Label(); x.Text = "評分"; x.Location = new Point(20, 60); this.Controls.Add(x); x.Font = new Font("微軟正黑體", 12);
                    cb.SelectedIndex= 0; cb.Location = new Point(20, 85); cb.Size = new Size(50,50); cb.Font = new Font("Verdana", 12);
                    cb.DropDownStyle = ComboBoxStyle.DropDownList; this.Controls.Add(cb); 
                    btn_check.Location = new Point(120, 170); btn_cancle.Location = new Point(220, 170);
                    btn_check.Click += btn_commentcheck_Click; bookID = bookid;
                }
            }
            else if(sender is Label)
            {
                label1.Visible= false;
                lab_title.Text ="地址:";
                label27.Visible= false;
                btn_check.Click += btn_addresscheck_Click;
            }
        }
        int bookID; ComboBox cb;
        private void btn_commentcheck_Click(object sender, EventArgs e)
        {
            Comment c = new Comment() {MemberID=cmm.usingMember.MemberID, BookID = bookID, CommentText=tB1.Text, Stars= cb.Text, CommentTime=DateTime.Now};
            dbContent.Comments.Add(c); dbContent.SaveChanges(); 
        }

        BookShopEntities3 dbContent = new BookShopEntities3();
        CMemberManager cmm = new CMemberManager();
        private void btn_addresscheck_Click(object sender, EventArgs e)
        {
            var updatetool = dbContent.Members.Find(cmm.usingMember.MemberID);
            updatetool.MemberAddress = tB1.Text;
            dbContent.SaveChanges(); MessageBox.Show("修改成功");
        }
        private void btn_passwordcheck_Click(object sender, EventArgs e)
        {
            var updatetool = dbContent.Members.Find(cmm.usingMember.MemberID);
            updatetool.MemberPassword = tB1.Text;
            dbContent.SaveChanges(); MessageBox.Show("修改成功");
        }

        private void tB1_TextChanged(object sender, EventArgs e)
        {
            string emailpattern = @"^(?=.*[A-Z])(?=.*[a-z])\w{8,10}$";

            if (Regex.IsMatch(tB1.Text, emailpattern))
            {
                label27.ForeColor = Color.Green;
                label27.Text = "密碼格式正確";
            }
            else
            {
                label27.ForeColor = Color.Red;
                label27.Text = "密碼格式不符";
            }
        }

    }
}
