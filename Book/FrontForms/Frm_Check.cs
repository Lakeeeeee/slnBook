using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Book.FrontForms
{
    public partial class Frm_Check : Form
    {
        private Frm_Main M;
        public int _memberID; public List<CCart> _cart;
        public Frm_Check(List<CCart> incart, int memID = -1)
        {
            InitializeComponent();
            loadcart(incart); LoadMember(memID);
        }
        BookShopEntities3 dbContent = new BookShopEntities3();
        #region
        private void loadcart(List<CCart> indata)
        {
            _cart = indata;
        }
        private void LoadMember(int memID)
        {
            _memberID = memID;
        }
        #endregion
        private void Frm_Check_Load(object sender, EventArgs e)
        {
            var q = from bk in _cart
                    select new
                    {
                        書名 = bk.Book.BookTitle,
                        數量 = bk.Quntity,
                        價格 = bk.Book.UnitPrice,
                        小計 = (bk.Quntity) * (bk.Book.UnitPrice)
                    };
            this.dataGridView1.DataSource = q.ToList();

            var total = _cart.Sum(bk => bk.Quntity * bk.Book.UnitPrice);
            labTPrice.Text = $"目前金額：{string.Format("{0:0}", total)} 元";

            var q2 = dbContent.Shipments.Select(x => x.ShipmentName);
            foreach (string item in q2.ToList())
            {
                cB_Ship.Items.Add(item.ToString());
            }
            var q3 = dbContent.Payments.Select(x => x.PaymentName);
            foreach (string item in q3.ToList())
            {
                cB_pay.Items.Add(item.ToString());
            }
            label5.Text = dbContent.Members.Where(x => x.MemberID == _memberID).Select(x => x.MemberName).FirstOrDefault().ToString();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order()
                {
                    MemberID = _memberID,
                    OrderDate = DateTime.Now,
                    ShipmentID = dbContent.Shipments.Where(x => x.ShipmentName == cB_Ship.Text).Select(x => x.ShipmentID).FirstOrDefault(),
                    PaymentID = dbContent.Payments.Where(x => x.PaymentName == cB_pay.Text).Select(x => x.PaymentID).FirstOrDefault(),
                    PayStatusID = 1,
                    ShippingStatusID = 1,
                    ShipAddr = textBox1.Text
                };
                dbContent.Orders.Add(order); dbContent.SaveChanges();
                int orderid = order.OrderID;
                foreach (CCart bk in _cart)
                {
                    OrderDetail detail = new OrderDetail()
                    {
                        OrderID = orderid,
                        BookID = bk.Book.BookID,
                        Quantity = bk.Quntity,
                        UnitPrice = bk.Book.UnitPrice
                    };
                    dbContent.OrderDetails.Add(detail); dbContent.SaveChanges();
                }
                MessageBox.Show("訂購成功");
                _cart.Clear();
                Frm_Main M = Application.OpenForms.OfType<Frm_Main>().FirstOrDefault(); //更新main的DGV1
                if (M != null)
                {
                    M.UpdateDataGridView(_cart);
                }
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (CCart bk in _cart)
            {
                ActionDetial buynext = new ActionDetial()
                {
                    BookID = bk.Book.BookID,
                    ActionID = 2,
                    MemberID = _memberID
                };
                dbContent.ActionDetials.Add(buynext); dbContent.SaveChanges();
            }
            _cart.Clear();
            Frm_Main M = Application.OpenForms.OfType<Frm_Main>().FirstOrDefault(); //更新main的DGV1
            if (M != null)
            {
                M.UpdateDataGridView(_cart);
            }
        }
    }
}
