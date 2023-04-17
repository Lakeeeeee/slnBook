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
using System.Web;
using Book.FrontForms;
using Book.ClassModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Net;

namespace Book
{
    public partial class Frm_Main : Form
    {
        CMember _cm = new CMember();
        public List<CCart> cartlist = new List<CCart>();
        BookShopEntities3 BScontent =new BookShopEntities3();
        BindingSource bindingSource = new BindingSource();
        public Frm_Main()
        {
            InitializeComponent(); 
            groupBox1.Visible = false;
            Frm_BookShop bkfm = new Frm_BookShop(cartlist);
            addfrm(bkfm);
            dataGridView1.Visible = false;
            labTPrice.Visible = false;
            btn_check.Visible = false;
        }
        bool isloggedin = false; //以布林判斷是否登入
        private void ToggleLoginControls(bool show)
        {            
            //顯示會員登入控制項
            lablogin.Visible = show;
            labaccount.Visible = show;
            labpassword.Visible = show;
            txtaccount.Visible = show;
            txtpassword.Visible = show;
            btnlogin.Visible = show;
            btncancel.Visible = show;
            label1.Visible = show;
            linkLabel1.Visible = show;
            //隱藏，登入後的問候語與登出按鈕
            labHello.Visible = !show;
            lablogout.Visible = !show;
            dataGridView1.Visible = true;
            labTPrice.Visible = true;
            btn_check.Visible = true;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Member loginMem = BScontent.Members.FirstOrDefault(m => m.MemberEmail == txtaccount.Text && m.MemberPassword == txtpassword.Text);
            if (loginMem != null)      //資料相符，登入成功
            {
                _cm.member = loginMem; 
                MessageBox.Show("log in success");
                ToggleLoginControls(false);  // 顯示其他物件取代上面被隱藏的物件
                labHello.Location = lablogin.Location;
                labHello.Size = lablogin.Size;  //相同尺寸
                labHello.Text = $"Hello, {loginMem.MemberName}"; // 將label物件的Text屬性設為登入者的名稱
                lablogout.Location = labaccount.Location;   //相同位置
                isloggedin = true;   //判斷為登入
                this.splitContainer2.Panel1.Controls.Clear();
                Frm_BookShop bkfm= new Frm_BookShop(cartlist, _cm.member.MemberID); addfrm(bkfm);
            }
            else
            {
                MessageBox.Show("pls check your mail or password");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            //清空textbox
            txtaccount.Clear();
            txtpassword.Clear();
        }

        private void lablogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("您已經成功登出!");
            ToggleLoginControls(true);  // 顯示登入後可使用的物件
            _cm.member = null;  
            btncancel_Click(sender,e);
            isloggedin = false;  //判斷為登出
            this.splitContainer2.Panel1.Controls.Clear();
            Frm_BookShop bkfm = new Frm_BookShop(cartlist);
            addfrm(bkfm);
            dataGridView1.Visible = false;
            labTPrice.Visible = false;
            btn_check.Visible = false;
        }

        private void addfrm(Form infrm)
        {
            infrm.Parent = null; infrm.TopLevel = false;
            this.splitContainer2.Panel1.Controls.Clear();
            this.splitContainer2.Panel1.Controls.Add(infrm);
            infrm.Show();  infrm.Dock=DockStyle.Fill;
        }
        private void btn_bkshop_Click(object sender, EventArgs e)
        {
            if (_cm.member != null)
            {
                Frm_BookShop bkfm = new Frm_BookShop(cartlist, _cm.member.MemberID);
                addfrm(bkfm);
            }
            else
            {
                Frm_BookShop bkfm = new Frm_BookShop(cartlist);
                addfrm(bkfm);
            }
        }
        private void btn_member_Click(object sender, EventArgs e)
        {
            if (isloggedin)     //判斷是否登入，登入了才能使用
            {
                Frm_Member myMember = new Frm_Member(_cm);
                addfrm(myMember);
                    }
            else
            {
                MessageBox.Show("請先登入");
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new Frm_registered_member()).Show();
        }
        bool isLoginSuccessful = false;
        private void btnback_Click(object sender, EventArgs e)
        {
            if (!isLoginSuccessful)
            {
                DialogResult result = (new Frm_BackLogin()).ShowDialog();
                if (result == DialogResult.OK)
                {
                    groupBox1.Visible = true;
                    btnback.Text = "後台登出";
                    isLoginSuccessful = true;
                    this.splitContainer2.Panel2Collapsed = !this.splitContainer2.Panel2Collapsed;
                }
            }
            else
            {
                groupBox1.Visible = false;
                btnback.Text = "後台登入";
                isLoginSuccessful = false;
                this.splitContainer2.Panel1.Controls.Clear();
                Frm_BookShop bkfm = new Frm_BookShop(cartlist);  //可做一個傳遞後臺管理id的東西
                addfrm(bkfm);
                this.splitContainer2.Panel2Collapsed = !this.splitContainer2.Panel2Collapsed;
            }
        }

        private void btn_Demo_Click(object sender, EventArgs e)
        {
            txtaccount.Text = "colton2099@gmail.com";
            txtpassword.Text = "FX5Pw28d";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm_ArticalManage myArtical = new Frm_ArticalManage();
            addfrm(myArtical);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frm_MemberManage myMemMana = new Frm_MemberManage();
            addfrm(myMemMana);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_BookManage myBookMana = new Frm_BookManage();
            addfrm(myBookMana);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = bindingSource;  // 綁定 BindingSource 和 DataGridView
            var q = from bk in cartlist
                    select new
                    {
                        書名 = bk.Book.BookTitle,
                        數量 = bk.Quntity,
                        價格 = bk.Book.UnitPrice,
                    };
            bindingSource.DataSource = q.ToList();  // 將集合設為 BindingSource 的 DataSource
            bindingSource.ResetBindings(false);  // 通知 BindingSource 和 DataGridView，資料已經變化
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Frm_PublisherManage myPublishMana = new Frm_PublisherManage();
            addfrm(myPublishMana);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_OdersManage myOrderMana = new Frm_OdersManage();
            addfrm(myOrderMana);
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            Frm_Check myCheck = new Frm_Check(cartlist, _cm.member.MemberID);
            myCheck.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Frm_DiscountManage myDiscount = new Frm_DiscountManage();
            addfrm(myDiscount);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_AuthTransPainManager myAurthor = new Frm_AuthTransPainManager();
            addfrm(myAurthor);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Frm_CategoryManage myCateMana = new Frm_CategoryManage();
            addfrm(myCateMana);
        }
        public void UpdateDataGridView(object dataSource)
        {
            this.dataGridView1.DataSource = bindingSource;
            var q = from bk in cartlist
                    select new
                    {
                        書名 = bk.Book.BookTitle,
                        數量 = bk.Quntity,
                        價格 = bk.Book.UnitPrice,
                        小計 = (bk.Quntity) * (bk.Book.UnitPrice)
                    };
            bindingSource.DataSource = q.ToList();  // 將集合設為 BindingSource 的 DataSource
            bindingSource.ResetBindings(false);
            var total = cartlist.Sum(bk => bk.Quntity * bk.Book.UnitPrice);
            labTPrice.Text = $"目前金額：{string.Format("{0:0}", total)} 元";

        }
    }
}
