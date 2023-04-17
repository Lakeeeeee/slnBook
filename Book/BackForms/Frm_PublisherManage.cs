using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.Spatial;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Book.BackForms
{
    public partial class Frm_PublisherManage : Form
    {
        public Frm_PublisherManage()
        {
            InitializeComponent();
            loadPub();
            getPurDetAll();
        }
       //entity
        BookShopEntities3 BScontect = new BookShopEntities3();

        private void loadPub()
        {
            var q = from p in BScontect.Publishers
                    select new
                    {
                        出版社編號 = p.PublisherID,
                        出版社統一編號 = p.taxIDnumber,
                        出版社名稱 = p.PublisherName,
                        出版社電話 = p.PublisherPhone,
                        出版社地址 = p.PublisherAddress
                    };
            dataGVPub.DataSource = q.ToList();
        }
        private void btInsert_Click(object sender, EventArgs e)         //出版商
        {
            try
            {
                Publisher pu = new Publisher();
                pu.PublisherName = txtPuName.Text;
                pu.taxIDnumber = int.Parse(txttaxIDNum.Text);
                pu.PublisherName = txtPuName.Text;
                pu.PublisherAddress = txtPuAddr.Text;
                pu.PublisherPhone = txtPuPho.Text;
                BScontect.Publishers.Add(pu);
                BScontect.SaveChanges();
                MessageBox.Show("新增成功");
                loadPub();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUp_Click(object sender, EventArgs e)            //出版商
        {
            try
            {
                var pu = BScontect.Publishers.Where(p => p.PublisherName == txtPuName.Text).FirstOrDefault();
                pu.taxIDnumber = int.Parse(txttaxIDNum.Text);
                pu.PublisherAddress = txtPuAddr.Text;
                pu.PublisherPhone = txtPuPho.Text;
                BScontect.SaveChanges();
                MessageBox.Show("修改成功");
                loadPub();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)         //出版商
        {
            txttaxIDNum.Clear();
            txtPuName.Clear();
            txttaxIDNum.Clear();
            txtPuAddr.Clear();
            txtPuPho.Clear();
            dataGVPub.ClearSelection();
        }
        private void btnDemo_Click(object sender, EventArgs e)          //出版商
        {
            txttaxIDNum.Text = "123456789";
            txtPuName.Text = "這是出版社名字";
            txtPuAddr.Text = "這是出版社地址";
            txtPuPho.Text = "123456789";
        }

        private void btnDel_Click(object sender, EventArgs e)           //出版商
        {
            try
            {
                if (dataGVPub.SelectedRows.Count == 1)
                {
                    int pubID = Convert.ToInt32(dataGVPub.SelectedRows[0].Cells["出版社編號"].Value);
                    var pu = BScontect.Publishers.Where(p => p.PublisherID == pubID).FirstOrDefault();
                    BScontect.Publishers.Remove(pu);
                    BScontect.SaveChanges();
                    loadPub();
                }
                else
                {
                    MessageBox.Show("請選擇要刪除的出版社");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGVPub_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGVPub.Rows[e.RowIndex];

                // 將選擇的值輸出到textbutton控制項中
                txtPuID.Text = row.Cells["出版社編號"].Value.ToString();
                txttaxIDNum.Text = row.Cells["出版社統一編號"]?.Value?.ToString() ?? "";
                txtPuName.Text = row.Cells["出版社名稱"]?.Value?.ToString() ?? "";
                txtPuAddr.Text = row.Cells["出版社地址"]?.Value?.ToString() ?? "";
                txtPuPho.Text = row.Cells["出版社電話"]?.Value?.ToString() ?? "";
            }
        }
       int purchaseID;
        private void getselectedPurdetail(int index)
        {
            try
            {
                var q = from p in BScontect.PurchaseDetails
                        where p.PurchaseID == index
                        select new
                        {
                            進貨明細表編號 = p.PurchaseDetailID,
                            出版社編號 = p.PublisherID,
                            書籍編號 = p.BookID,
                            書名 = p.Book.BookTitle,
                            進貨數量 = p.Quantity,
                            書籍價格 = p.UnitPrice
                        };
                dGVPurDet.DataSource = q.ToList();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Purchase pc = new Purchase
            {
                PurchaseDate = dtpPurDate.Value,
                ArrivedData = dtpArrDate.Value,
            };
            this.BScontect.Purchases.Add(pc);
            this.BScontect.SaveChanges();
            //
            MessageBox.Show("訂單已新增");
            //
            getPurDetAll();
        } //insert
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int purchaseid = int.Parse(textBox1.Text);
                var purchaseprof = (from pc in this.BScontect.Purchases
                                    where pc.PurchaseID == purchaseid
                                    select pc).FirstOrDefault();
                purchaseprof.PurchaseDate = dtpPurDate.Value;
                purchaseprof.ArrivedData = dtpArrDate.Value;
                this.BScontect.SaveChanges();
                MessageBox.Show("修改成功");
                getPurDetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //update
        private void btnPurDel_Click(object sender, EventArgs e)
        {
            try
            {
                int purchaseID = int.Parse(textBox1.Text);
                var purchase = (from p in this.BScontect.Purchases
                                where p.PurchaseID == purchaseID
                                select p).FirstOrDefault();
                if (purchase == null) return;
                this.BScontect.Purchases.Remove(purchase);
                this.BScontect.SaveChanges();
                MessageBox.Show("訂單已刪除");
                getPurDetAll();  // 重新載入資料
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dGVPur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int cellvalue = dGVPur.SelectedCells[0].RowIndex;
                string sPTD = dGVPur.Rows[cellvalue].Cells[0].Value.ToString();
                int selectPurchaseID = int.Parse(sPTD);

                var q = BScontect.PurchaseDetails.Where(x=>x.PurchaseID== selectPurchaseID).Select(x => new
                {
                    進貨明細表編號 = x.PurchaseDetailID,
                    出版社編號 = x.PublisherID,
                    進貨單號 = x.PurchaseID,
                    書籍編號 = x.BookID,
                    書名 = x.Book.BookTitle,
                    進貨數量 = x.Quantity,
                    書籍價格 = x.UnitPrice
                });
                this.textBox1.Text = sPTD;
                dGVPurDet.DataSource = q.ToList();
                dGVPurDet.Columns["進貨明細表編號"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void dGVPurDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pur = dGVPurDet.SelectedCells[0].RowIndex;
            string x = dGVPurDet.Rows[pur].Cells[1].Value.ToString();
            purchaseID = int.Parse(x);
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dGVPurDet.Rows[e.RowIndex];
                cmbPurDPbID.Text = row.Cells["出版社編號"]?.Value?.ToString() ?? "";
                cmbPurDBookID.Text = row.Cells["書籍編號"]?.Value?.ToString() ?? "";
                txtPurDQuan.Text = row.Cells["進貨數量"].Value.ToString();
                txtPurDUnityPrice.Text = row.Cells["書籍價格"].Value.ToString();
            }
        }

        private void getPurDetAll()         //純讀取用的，完整的purchasedetail、purchase表單
        {
            try
            {
                //purchasedetail
                var PD = from p in BScontect.PurchaseDetails
                         orderby p.PublisherID
                         select new
                         {
                             進貨明細表編號 = p.PurchaseDetailID,
                             出版社編號 = p.PublisherID,
                             書籍編號 = p.BookID,
                             書名 = p.Book.BookTitle,
                             進貨數量 = p.Quantity,
                             書籍價格 = p.UnitPrice
                         };
                dGVPurDet.DataSource = PD.ToList();
                dGVPurDet.Columns["進貨明細表編號"].Visible = false;
                //puchase
                var Pu = from p in BScontect.Purchases
                         orderby p.PurchaseID
                         select new
                         {
                             進貨單號 = p.PurchaseID,
                             進貨日期 = p.PurchaseDate,
                             到貨日期 = p.ArrivedData,
                         };
                dGVPur.DataSource = Pu.ToList();
                //
                // PurchaseID進combobox
                var q = from p in this.BScontect.Purchases
                        select p.PurchaseID;
                this.cmbPurID.DataSource = q.ToList();
                //publisherID進combobox
                var PL = from pl in this.BScontect.Publishers
                         select pl.PublisherName;
                this.cmbPurDPbID.DataSource=PL.ToList();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void btnPurClear_Click(object sender, EventArgs e)
        {
            dtpPurDate.Value = DateTime.Now;
            txtPurDQuan.Clear();
            txtPurDUnityPrice.Clear();
            dGVPurDet.ClearSelection();
            //
            cmbPurID.DataSource = null;
            cmbPurID.Items.Clear();
        }

        private void btnPurInsert_Click(object sender, EventArgs e)
        {
                var publisher = BScontect.Publishers.Where(x => x.PublisherName == cmbPurDPbID.Text).Select(x=>x).FirstOrDefault();
                var bk = BScontect.Books.Where(x => x.BookTitle == cmbPurDBookID.Text).Select(x => x).FirstOrDefault();
                PurchaseDetail pcdetail = new PurchaseDetail
                {
                    PurchaseID = int.Parse(cmbPurID.Text),
                    PublisherID = publisher.PublisherID,
                    BookID = bk.BookID,
                    ISBN = bk.ISBN,
                    Quantity = int.Parse(txtPurDQuan.Text),
                    UnitPrice = decimal.Parse(txtPurDUnityPrice.Text),
                };
                this.BScontect.PurchaseDetails.Add(pcdetail);
                this.BScontect.SaveChanges();
                MessageBox.Show("新增成功");
                getselectedPurdetail(int.Parse(cmbPurID.Text));
        }
        private void btnPurDetAll_Click(object sender, EventArgs e)
        {
            getPurDetAll();
        }

        private void btnPurUp_Click(object sender, EventArgs e)
        {
            try
            {
                int purID=int.Parse(cmbPurID.Text);
                var purDetailprof = (from x in this.BScontect.PurchaseDetails
                                     where x.PurchaseID== purID
                                     select x).FirstOrDefault();

                BScontect.SaveChanges();
                MessageBox.Show("修改成功");
                getPurDetAll();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }  //先拿掉

        private void btnPurDDel_Click(object sender, EventArgs e)
        {
            try
            {
                int site = this.dGVPurDet.SelectedCells[0].RowIndex;
                int purchaseDetailID = (int) this.dGVPurDet.Rows[site].Cells["進貨明細表編號"].Value;
                var deletool=this.BScontect.PurchaseDetails.Find(purchaseDetailID);
                //
                this.BScontect.PurchaseDetails.Remove(deletool);
                this.BScontect.SaveChanges();
                MessageBox.Show("該項目已刪除");
                getselectedPurdetail(int.Parse(cmbPurID.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //puchase
            var Pu = from p in BScontect.Purchases
                     orderby p.PurchaseID
                     select new
                     {
                         進貨單號 = p.PurchaseID,
                         進貨日期 = p.PurchaseDate,
                         到貨日期 = p.ArrivedData,
                     };
            dGVPur.DataSource = Pu.ToList();
        }


        private void cmbPurDPbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from p in this.BScontect.Books
                    where p.Publisher.PublisherName == cmbPurDPbID.Text
                    select p.BookTitle;
            this.cmbPurDBookID.DataSource = q.ToList();
        }

        private void cmbPurID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = int.Parse(cmbPurID.Text);
            var q = from p in this.BScontect.Purchases
                    where p.PurchaseID == index
                     orderby p.PurchaseID
                    select p;
            this.dGVPur.DataSource = q.ToList();

            var q2 = this.BScontect.PurchaseDetails.Where(x => x.PurchaseID == index).Select(x => new
            {
                進貨明細表編號 = x.PurchaseDetailID,
                出版社編號 = x.PublisherID,
                書籍編號 = x.BookID,
                書名 = x.Book.BookTitle,
                進貨數量 = x.Quantity,
                書籍價格 = x.UnitPrice
            });
            this.dGVPurDet.DataSource = q2.ToList();

        }

        private void cmbPurDBookID_TextChanged(object sender, EventArgs e)
        {
            var price = BScontect.Books.Where(x => x.BookTitle == cmbPurDBookID.Text).Select(x => x.UnitPrice).FirstOrDefault();
            txtPurDUnityPrice.Text = price.ToString();
        }
    }
}
