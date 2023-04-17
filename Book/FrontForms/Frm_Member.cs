using Book.BackForms;
using Book.ClassModel;
using Book.FrontForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Book
{
    public partial class Frm_Member : Form
    {
        List<CCart> _cart;
        public Frm_Member(CMember cm)
        {
            InitializeComponent();
            cmm.loadMember(cm.member);
            loadCus(); 
            loadOrdersPage();
            loadBuyNext();
        }
        CMemberManager cmm = new CMemberManager();
        BookShopEntities3 dbContent = new BookShopEntities3();
        #region(loadformat)
        private void Frm_Member_Load(object sender, EventArgs e)
        {
            foreach (var data in cmm.usingMemCARs) //loadcollectedaurthors
            { lB_aurthor.Items.Add(data.Author.AuthorName); }
            foreach (var data in cmm.usingMemCPs) //loadcollectedpublishers
            { lB_publisher.Items.Add(data.Publisher.PublisherName); }

            DataGridViewButtonColumn satisfaction = new DataGridViewButtonColumn();
            satisfaction.UseColumnTextForButtonValue = true;
            satisfaction.Name = "滿意度調查"; satisfaction.Text = "點我填寫";
            dGV8.Columns.Add(satisfaction);

            System.Windows.Forms.ToolTip address = new System.Windows.Forms.ToolTip() ; address.SetToolTip(this.label2, "點擊可更新郵寄地址");

            foreach (var item in dbContent.Payments.Select(x => x.PaymentName).ToList())
            {
                cB_payment.Items.Add(item);
            }

            DataGridViewButtonColumn num = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Name = "檢視詳細",
                Text = "檢視詳細"
            };
            DataGridViewButtonColumn cancle = new DataGridViewButtonColumn()
            {
                UseColumnTextForButtonValue = true,
                Name = "取消訂單",
                Text = "取消"
            };
            this.dGV1.Columns.Insert(1, num); this.dGV1.Columns.Add(cancle);
            //DataGridViewButtonColumn addchart = new DataGridViewButtonColumn()
            //{
            //    UseColumnTextForButtonValue = true,
            //    Name = "加入購物車",
            //    Text = "Add"
            //};
            //dGV3.Columns.Add(addchart);
            loadProfile();
        }
        public void loadcart(List<CCart> indata)  //還沒用到
        {
            _cart = indata;
        }

        #endregion
        private void loadProfile()
        {
            this.splitContainer5.Panel2Collapsed = true;
            label21.Text = dbContent.Members.Find(cmm.usingMember.MemberID).MemberEmail;
            label20.Text = dbContent.Members.Find(cmm.usingMember.MemberID).MemberName;
            label19.Text = dbContent.Members.Find(cmm.usingMember.MemberID).MemberBrithDate?.ToString("yyyy年MM月dd日");
            label2.Text = dbContent.Members.Find(cmm.usingMember.MemberID).MemberAddress?.ToString() ?? "";
            cB_payment.Text = dbContent.Members.Find(cmm.usingMember.MemberID).Payment.PaymentName;
        }
        private void loadOrdersPage()
        {
            try
            {
                this.lab_count.Text = $"您的訂單紀錄共有 {dbContent.Members.Find(cmm.usingMember.MemberID).Orders.Count} 筆：";
                var q = dbContent.Orders.Where(o => o.MemberID == cmm.usingMember.MemberID).Select(x => new
                {
                    訂單編號 = x.OrderID,
                    訂單日期 = x.OrderDate,
                    //優惠 = x.Discount.DiscountAmount,
                    支付方法 = x.Payment.PaymentName,
                    支付狀態 = x.PayStatu.PayStatusName,
                    運貨方式 = x.Shipment.ShipmentName,
                    運貨狀態 = x.ShippingStatu.ShippingStatusName,
                    //運費 = x.Freight,
                    //小計 = (x.OrderDetails.Sum(y => y.UnitPrice * y.Quantity)) + (x.Freight ?? 0)
                }); this.dGV1.DataSource = q.ToList();

            }
            catch (Exception ex) { }
        }
        private void loadBuyNext()
        {
            var q = dbContent.ActionDetials.Where(x => x.MemberID == cmm.usingMember.MemberID && x.ActionID == 2).Select(x => new
            {
                ActionToBookDetailID = x.ActionToBookID,
                theBookID = x.BookID,
                商品名稱 = x.Book.BookTitle,
                折扣 = x.Book.Discount_Detail.Select(y => y.Discount.DiscountAmount).FirstOrDefault() ?? 1.00m,
                優惠價 = x.Book.UnitPrice * (x.Book.Discount_Detail.Select(y => y.Discount.DiscountAmount).FirstOrDefault() ?? 1m),
                出版社 = x.Book.Publisher.PublisherName,
                庫存 = x.Book.UnitInStock > 0 ? "可供貨" : "缺貨"
            });
            dGV3.DataSource = q.ToList(); dGV3.DefaultCellStyle.Format = "0.00";
            dGV3.Columns["theBookID"].Visible = false; dGV3.Columns["ActionToBookDetailID"].Visible = false;
            dGV3.Columns["優惠價"].DefaultCellStyle.Format = "c2";
        }
        private void loadCus()
        {
            var q = dbContent.CustomerServices.Where(x => x.MemberID == cmm.usingMember.MemberID).Select(x => new
            {
                序號 = x.CRMID,
                訊息 = x.CContent,
                回覆 = x.ReplyContent,
                發送時間 = x.UpdateDate,
                處理狀態 = x.Status.StatusDescription,
                ID = x.StatusID
            });
            
            dGV8.DataSource = q.ToList();
            dGV8.Columns["ID"].Visible = false;
        }

        private void dGV1_CellContentClick(object sender, DataGridViewCellEventArgs e) //
        {
            DataGridViewRow row= dGV1.Rows[e.RowIndex];  int selectedID = int.Parse(row.Cells["訂單編號"].Value.ToString());
            Order selectedOrder =  dbContent.Members.Find(cmm.usingMember.MemberID).Orders.Where(x => x.OrderID == selectedID).FirstOrDefault() ;
            if (dGV1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && 
                dGV1.Columns[e.ColumnIndex].Name == "檢視詳細" && e.RowIndex >= 0)
            {
                Frm_OrderDetail frmod = new Frm_OrderDetail(selectedOrder);
                frmod.Show();
            }
            else if (dGV1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && 
                dGV1.Columns[e.ColumnIndex].Name == "取消訂單" && e.RowIndex >= 0)
            {
                string statue = selectedOrder.PayStatu.PayStatusName;
                if (statue == "等待付款" || statue == "訂單不成立")
                {
                    var q = dbContent.OrderDetails.Where(x => x.OrderID == selectedID);
                    dbContent.OrderDetails.RemoveRange(q); 
                    dbContent.Orders.Remove(selectedOrder);
                    dbContent.SaveChanges();
                    loadOrdersPage();
                    //發送信件到客服:todo
                    MessageBox.Show("取消成功");
                }
                else
                {
                    MessageBox.Show("訂單已支付，無法取消");
                    MessageBox.Show("如需退貨，請聯絡客服");
                }
            }
        }
        private void dGV3_CellContentClick(object sender, DataGridViewCellEventArgs e)  //
        {
            if (dGV3.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dGV3.Columns[e.ColumnIndex].Name == "加入購物車" && e.RowIndex >= 0)
            {
                DataGridViewRow row = dGV3.Rows[e.RowIndex];
                int theActionToBookDetailID = (int) row.Cells["ActionToBookDetailID"].Value;

                //刪除下次再買
                var q = cmm.dbContent.ActionDetials.Where(x => x.ActionToBookID == theActionToBookDetailID);
                cmm.dbContent.ActionDetials.RemoveRange(q);
                cmm.dbContent.SaveChanges();
                //加入購物車: todo
            }

        }
        private void lB_aurthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lB_aubook.Items.Clear();
            var q = from bk in dbContent.Books 
                    join a in dbContent.AuthorDetails on bk.BookID equals a.BookID
                    where a.Author.AuthorName==lB_aurthor.Text
                    select bk.BookTitle;
                    
            foreach (var item in q.ToList())
            {
                lB_aubook.Items.Add(item);
            }
        }
        private void lB_publisher_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.lB_pubbook.Items.Clear();
            var q =  cmm.dbContent.Books.Where(x => x.Publisher.PublisherName == lB_publisher.Text);
            foreach (var item in q.ToList())
            {
                lB_pubbook.Items.Add(item.BookTitle);
            }
        }
        private void lB_aubook_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from bk in dbContent.Books.AsEnumerable() 
                    join a in dbContent.AuthorDetails on bk.BookID equals a.BookID
                    where a.Book.BookTitle == lB_aubook.Text
                    select   new  
                    {   書名 = bk.BookTitle,
                        作者簡介 = bk.AboutAuthor,
                        出版社 = bk.Publisher.PublisherName,
                        售價 = bk.UnitPrice,
                        折扣 = bk.Discount_Detail.Select(y => y.Discount.DiscountAmount).FirstOrDefault() ?? 1.00m,
                        優惠價 = bk.UnitPrice * (bk.Discount_Detail.Select(y => y.Discount.DiscountAmount).FirstOrDefault() ?? 1m),
                        優惠截止日 = bk.Discount_Detail.FirstOrDefault()?.Discount.EndDate?.ToString("d") ?? "無"
                    }).Distinct();

            this.dataGridView1.DataSource= q.ToList();
        }
        private void dGV8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
            if (dGV8.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                dGV8.Columns[e.ColumnIndex].Name == "滿意度調查" && e.RowIndex >= 0)
            {
                DataGridViewRow row = dGV8.Rows[e.RowIndex]; int selectedID = int.Parse(row.Cells["序號"].Value.ToString());
                DataGridViewCell cell = dGV8.Rows[e.RowIndex].Cells["ID"]; CustomerService selectedCs = cmm.dbContent.CustomerServices.Find(selectedID);
                if (int.Parse(cell.Value.ToString()) == 5 || int.Parse(cell.Value.ToString()) == 6)
                {
                    Frm_SatisSearch frm_Satis = new Frm_SatisSearch(selectedCs);
                    frm_Satis.ShowDialog();
                    if (frm_Satis.DialogResult == DialogResult.OK)
                    {
                        loadCus();
                    }
                } else { MessageBox.Show("滿意度調查未開放"); };
            }
        }
        private void btn_csquery_Click(object sender, EventArgs e)
        {
            CustomerService newcustomerquery = new CustomerService();
            newcustomerquery.StatusID = 1;
            newcustomerquery.CContent = textBox1.Text;
            newcustomerquery.UpdateDate = DateTime.Now;
            newcustomerquery.MemberID = cmm.usingMember.MemberID;
            cmm.dbContent.CustomerServices.Add(newcustomerquery);
            cmm.dbContent.SaveChanges();
            loadCus();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            var upatetool = dbContent.Members.Find(cmm.usingMember.MemberID);
            var paymentid = dbContent.Payments.Where(x => x.PaymentName == this.cB_payment.Text).Select(x=>x.PaymentID);
            upatetool.PaymentID= paymentid.FirstOrDefault();
            dbContent.SaveChanges(); MessageBox.Show("修改成功"); loadProfile();
        }
        private void btn_ask_Click(object sender, EventArgs e)
        {
            this.splitContainer5.Panel2Collapsed = !this.splitContainer5.Panel2Collapsed;
        }

        private void lB_pubbook_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = (from bk in dbContent.Books.AsEnumerable()
                    where bk.BookTitle.Equals(lB_pubbook.Text)
                    select new
                    {
                        書名 = bk.BookTitle,
                        作者簡介 = bk.AboutAuthor,
                        出版社 = bk.Publisher.PublisherName,
                        售價 = bk.UnitPrice,
                        折扣 = bk.Discount_Detail.Select(x => x.Discount.DiscountAmount).FirstOrDefault() ?? 1.00m,
                        優惠價 = bk.UnitPrice * (bk.Discount_Detail.Select(x => x.Discount.DiscountAmount).FirstOrDefault() ?? 1m),
                        優惠截止日 = bk.Discount_Detail.FirstOrDefault()?.Discount.EndDate?.ToString("d") ?? "無"
                    }).Distinct();
            this.dataGridView1.DataSource = q.ToList();
        }

        private void btn_passwordadict_Click(object sender, EventArgs e)
        {
            Frm_Browse mInfoAddict = new Frm_Browse(cmm.usingMember, sender);
            mInfoAddict.ShowDialog();
            if (mInfoAddict.DialogResult == DialogResult.OK)
            {
                loadProfile();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Frm_Browse mInfoAddict = new Frm_Browse(cmm.usingMember, sender);
            mInfoAddict.ShowDialog();
            if (mInfoAddict.DialogResult == DialogResult.OK)
            {
                loadProfile();
            }
        }

    }
}
