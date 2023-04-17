using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Book
{
    public partial class Frm_OdersManage : Form
    {
        public Frm_OdersManage()
        {
            InitializeComponent();
            //getOrder();
        }

        BookShopEntities3 BScontent = new BookShopEntities3();
        private void getOrder()
        {
            var q = from p in BScontent.Orders
                    select new
                    {
                        訂單編號 = p.OrderID,
                        會員編號 = p.MemberID,
                        訂購時間 = p.OrderDate,
                        付款狀態 = p.PayStatu.PayStatusName,
                        付款方式 = p.Payment.PaymentName,
                        配送方式 = p.Shipment.ShipmentName,
                        配送狀態 = p.ShippingStatu.ShippingStatusName,
                        配送地址 = p.ShipAddr,
                        折扣 = p.Discount.DiscountAmount
                    };
            dataGVOrder.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getOrder();
        }
        int OrderID;
        private void getODetail()
        {
            try
            {
                int od = dataGVOrder.SelectedCells[0].RowIndex;
                string x = dataGVOrder.Rows[od].Cells[0].Value.ToString();
                OrderID = int.Parse(x);

                var q = from o in BScontent.OrderDetails
                        where o.OrderID == OrderID
                        select new
                        {
                            明細編號 = o.OrderDetailID,
                            書籍編號 = o.BookID,
                            訂購數量 = o.Quantity,
                            書籍價格 = o.UnitPrice,
                            書籍名稱 = o.Book.BookTitle

                        };

                dataGVODetail.DataSource = q.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderSearch();           
        }

        private void orderSearch()
        {
            if (string.IsNullOrEmpty(txtOrderID.Text) && string.IsNullOrEmpty(txtMID.Text))
            {
                MessageBox.Show("請輸入正確編號!");
                txtOrderID.Text = "";
                txtOrderID.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtOrderID.Text) && !string.IsNullOrEmpty(txtMID.Text))
            {
                int OID = int.Parse(txtOrderID.Text);
                int MID = int.Parse(txtMID.Text);

                //var q = dbContent.Orders.Where(x => (OID == 0 || x.OrderID == OID) && (MID == 0 || x.MemberID == MID)).
                var q = BScontent.Orders.Where(x => x.OrderID == OID && x.MemberID == MID).
                Select(x => new
                {
                    訂單編號 = x.OrderID,
                    會員編號 = x.MemberID,
                    訂購時間 = x.OrderDate,
                    付款狀態 = x.Payment.PaymentName,
                    付款方式 = x.PayStatu.PayStatusName,
                    配送方式 = x.Shipment.ShipmentName,
                    配送狀態 = x.ShippingStatu.ShippingStatusName,
                    配送地址 = x.ShipAddr,
                    折扣 = x.DiscountID
                });
                dataGVOrder.DataSource = q.ToList();
                if (this.dataGVOrder.RowCount == 0)
                {
                    dataGVOrder.DataSource = null;
                    dataGVODetail.DataSource = null;
                    MessageBox.Show("查無資料");
                }
            }
            else if (!string.IsNullOrEmpty(txtMID.Text))
            {
                int MID = int.Parse(txtMID.Text);
                var q = BScontent.Orders.Where(x => x.MemberID == MID).
                   Select(x => new
                   {
                       訂單編號 = x.OrderID,
                       會員編號 = x.MemberID,
                       訂購時間 = x.OrderDate,
                       付款狀態 = x.Payment.PaymentName,
                       付款方式 = x.PayStatu.PayStatusName,
                       配送方式 = x.Shipment.ShipmentName,
                       配送狀態 = x.ShippingStatu.ShippingStatusName,
                       配送地址 = x.ShipAddr,
                       折扣 = x.DiscountID
                   });
                dataGVOrder.DataSource = q.ToList();
                if (this.dataGVOrder.RowCount == 0)
                {
                    dataGVOrder.DataSource = null;
                    dataGVODetail.DataSource = null;
                    MessageBox.Show("查無資料");
                }
            }
            else if (!string.IsNullOrEmpty(txtOrderID.Text))
            {
                int OID = int.Parse(txtOrderID.Text);
                var q = BScontent.Orders.Where(x => x.OrderID == OID).
                   Select(x => new
                   {
                       訂單編號 = x.OrderID,
                       會員編號 = x.MemberID,
                       訂購時間 = x.OrderDate,
                       付款狀態 = x.Payment.PaymentName,
                       付款方式 = x.PayStatu.PayStatusName,
                       配送方式 = x.Shipment.ShipmentName,
                       配送狀態 = x.ShippingStatu.ShippingStatusName,
                       配送地址 = x.ShipAddr,
                       折扣 = x.DiscountID
                   });
                dataGVOrder.DataSource = q.ToList();
                if (this.dataGVOrder.RowCount == 0)
                {
                    dataGVOrder.DataSource = null;
                    dataGVODetail.DataSource = null;
                    MessageBox.Show("查無資料");
                }
            }
            else
            {
                dataGVOrder.DataSource = null;
                dataGVODetail.DataSource = null;
                MessageBox.Show("查無資料");
            }
        }

        private string Ship()
        {
            int OrID = int.Parse(txtOrderID.Text);
            var shipment = (from o in BScontent.Orders
                            join p in BScontent.Shipments
                            on o.ShipmentID equals p.ShipmentID
                            where o.OrderID == OrID
                            select p.ShipmentID).FirstOrDefault();
            if (shipment == 1)
            {
                return "宅配";
            }
            else if (shipment == 2)
            {
                return "超商取貨";
            }
            else { return "查無資料"; }

        }

        private string Pay()
        {
            int OrID = int.Parse(txtOrderID.Text);
            var payment = (from o in BScontent.Orders
                           join p in BScontent.Payments
                           on o.PaymentID equals p.PaymentID
                           where o.OrderID == OrID
                           select p.PaymentID).FirstOrDefault();
            if (payment == 1)
            {
                return "信用卡";
            }
            else if (payment == 2)
            {
                return "貨到付款";
            }
            else if (payment == 3)
            {
                return "超商取貨付款";
            }
            else if (payment == 4)
            {
                return "第三方支付";
            }
            else if (payment == 5)
            {
                return "行動支付";
            }
            else { return "查無資料"; }
        }

        private string Paystatus()
        {
            int OrID = int.Parse(txtOrderID.Text);
            var paystatus = (from o in BScontent.Orders
                             join p in BScontent.PayStatus
                             on o.PayStatusID equals p.PayStatusID
                             where o.OrderID == OrID
                             select p.PayStatusID).FirstOrDefault();
            if (paystatus == 1)
            {
                return "等待付款";
            }
            else if (paystatus == 2)
            {
                return "取消";
            }
            else if (paystatus == 3)
            {
                return "訂單不成立";
            }
            else if (paystatus == 4)
            {
                return "退貨/退款";
            }
            else if (paystatus == 5)
            {
                return "付款完成";
            }
            else { return "查無資料"; }
        }

        private string Shipstatus()
        {
            int OrID = int.Parse(txtOrderID.Text);
            var shipstatus = (from o in BScontent.Orders
                               join p in BScontent.ShippingStatus
                               on o.ShippingStatusID equals p.ShippingStatusID
                               where o.OrderID == OrID
                               select p.ShippingStatusID).FirstOrDefault();

            if (shipstatus == 1)
            {
                return "調貨中";
            }
            else if (shipstatus == 2)
            {
                return "出貨準備中";
            }
            else if (shipstatus == 3)
            {
                return "寄送中";
            }
            else if (shipstatus == 4)
            {
                return "已送達";
            }
            else if (shipstatus == 5)
            {
                return "取消";
            }
            else { return "查無資料"; }
        }

        private void dataGVOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getODetail();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGVOrder.Rows[e.RowIndex];


                txtOrderID.Text = row.Cells["訂單編號"]?.Value?.ToString() ?? "";
                txtMID.Text = row.Cells["會員編號"]?.Value?.ToString() ?? "";
                labODate.Text = row.Cells["訂購時間"]?.Value?.ToString() ?? "";
                txtOPM.Text = Pay();
                txtOPS.Text = Paystatus();
                txtOSS.Text = Shipstatus();
                txtOSW.Text = Ship();
                txtOAddr.Text = row.Cells["配送地址"]?.Value?.ToString() ?? "";
                txtODis.Text = row.Cells["折扣"]?.Value?.ToString() ?? "";
                
            }
        }

      
        private void dataGVODetail_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGVODetail.Rows[e.RowIndex];
                labODID.Text = row.Cells["明細編號"]?.Value?.ToString() ?? "";
                labBID.Text = row.Cells["書籍編號"]?.Value?.ToString() ?? "";
                txtQuan.Text = row.Cells["訂購數量"]?.Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["書籍價格"]?.Value?.ToString() ?? "";
                labBookName.Text = row.Cells["書籍名稱"]?.Value?.ToString() ?? "";
                //  明細編號 = o.OrderDetailID,
                // 書籍編號 = o.BookID,
                //訂購數量 = o.Quantity,
                //   書籍價格 = o.UnitPrice
            }
        }

        private void btnOUpdate_Click(object sender, EventArgs e)
        {
           
            try
            {
                int OID = int.Parse(txtOrderID.Text);
                var Oup = BScontent.Orders.Where(p => p.OrderID == OID).FirstOrDefault(); //回傳數值跟顯示項目要調整
                //Oup.PaymentID = int.Parse(txtOPM.Text);
                //Oup.ShipmentID = int.Parse(txtOSW.Text);
                //Oup.ShippingStatusID = int.Parse(txtOSS.Text);
                //Oup.PayStatusID = int.Parse(txtOPS.Text);
                //Oup.DiscountID = int.Parse(txtODis.Text);
                Oup.ShipAddr = txtOAddr.Text;
                BScontent.SaveChanges();
                MessageBox.Show("修改成功");
                orderSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnODelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dataGVOrder.SelectedRows.Count == 1)
                //{

                    int site = this.dataGVOrder.SelectedCells[0].RowIndex;
                    int delO = int.Parse(this.dataGVOrder.Rows[site].Cells["訂單編號"].Value.ToString());
                    var q = BScontent.Orders.Find(delO);
                var q2 = BScontent.OrderDetails.Where(x => x.OrderID == delO);
                    BScontent.Orders.Remove(q);
                BScontent.OrderDetails.RemoveRange(q2);
                    MessageBox.Show("刪除成功");
                    BScontent.SaveChanges();
                    getOrder();

                //}
                //else
                //{
                //    MessageBox.Show("請選擇要刪除的訂單");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnODUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int OdID = int.Parse(labODID.Text);
                var Oup = BScontent.OrderDetails.Where(p => p.OrderDetailID == OdID).FirstOrDefault(); //回傳數值跟顯示項目要調整
                Oup.Quantity = int.Parse(txtQuan.Text);
                BScontent.SaveChanges();
                MessageBox.Show("修改成功");
                getODetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnODdelette_Click(object sender, EventArgs e)
        {
            try
            {
                int site = this.dataGVODetail.SelectedCells[0].RowIndex;
                int delOD = int.Parse(this.dataGVODetail.Rows[site].Cells["明細編號"].Value.ToString());
                var q = BScontent.OrderDetails.Find(delOD);
                BScontent.OrderDetails.Remove(q);
                MessageBox.Show("刪除成功");
                BScontent.SaveChanges();
                getODetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGVODetail.DataSource = null;
            dataGVOrder.DataSource = null;
            txtMID.Clear();
            txtOrderID.Clear();
            txtOPS.Clear();
            txtOPM.Clear();
            txtOSS.Clear();
            txtOSW.Clear();
            txtODis.Clear();
            txtOAddr.Clear();
        }
    }
}
