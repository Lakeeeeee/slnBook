using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Book.BackForms
{
    public partial class Frm_DiscountManage : Form
    {
        public Frm_DiscountManage()
        {
            InitializeComponent();

            var DN = db.Discounts.Select(d => d.DiscountName);
            cmbDName.DataSource = DN.ToList();
            var bISBN = db.Books.Select(b => b.ISBN);
            cmbISBN.DataSource = bISBN.ToList();
            var BT = db.Books.Select(b => b.BookTitle);
            cmbBTitle.DataSource = BT.ToList();
        }

        BookShopEntities3 db = new BookShopEntities3();

        private void Frm_DiscountManage_Load(object sender, EventArgs e)
        {
            Read_RefreshDataGridView();
        }

        private void Read_RefreshDataGridView()
        {
            this.dgvDiscount.DataSource = this.db.Discounts.Select(d => new {d.DiscountID,d.DiscountName,d.DiscounDescription,d.DiscountAmount,d.StartDate,d.EndDate,d.IsActive}).ToList();
            this.dgvDiscountDetail.DataSource = this.db.Discount_Detail.Select(dd => new {dd.DiscountDetailID,dd.DiscountID,dd.BookID,dd.CategoryID}).ToList();
        }

        private void textClear()
        {
            discountIDTextBox.Clear();
            discountNameTextBox.Clear();
            discounDescriptionTextBox.Clear();
            discountAmountTextBox.Clear();
            startDateDateTimePicker.Value = DateTime.Now;
            endDateDateTimePicker.Value = DateTime.Now.AddMonths(1); 
            isActiveTextBox.Clear();
            discountDetailIDTextBox.Clear();
            discountIDTextBox1.Clear();
            bookIDTextBox.Clear();
            categoryIDTextBox.Clear();
        }

        private void dgvDiscount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int site = dgvDiscount.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvDiscount.Rows[site];
            discountIDTextBox.Text = row.Cells["DiscountID"].Value.ToString();
            discountNameTextBox.Text = row.Cells["DiscountName"].Value.ToString();
            discounDescriptionTextBox.Text = row.Cells["DiscounDescription"].Value.ToString();
            discountAmountTextBox.Text = row.Cells["DiscountAmount"].Value.ToString();
            if (row.Cells["StartDate"].Value == null) { startDateDateTimePicker.Value = DateTime.Now; }
            else { startDateDateTimePicker.Value = (DateTime)row.Cells["StartDate"].Value;}
            if (row.Cells["EndDate"].Value == null) { endDateDateTimePicker.Value = DateTime.Now.AddMonths(1); }
            else { endDateDateTimePicker.Value = (DateTime)row.Cells["EndDate"].Value ;}
            isActiveTextBox.Text = row.Cells["IsActive"].Value.ToString();
        }

        private void dgvDiscountDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int site = dgvDiscountDetail.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvDiscountDetail.Rows[site];
            discountDetailIDTextBox.Text = row.Cells["DiscountDetailID"].Value.ToString();
            discountIDTextBox1.Text = row.Cells["DiscountID"].Value.ToString();
            bookIDTextBox.Text = row.Cells["BookID"].Value.ToString();
            categoryIDTextBox.Text = row.Cells["CategoryID"].Value.ToString();
            int dID = int.Parse(discountIDTextBox1.Text);
            int bID = int.Parse(bookIDTextBox.Text);
            var DN = db.Discounts.Where(d => d.DiscountID == dID).GroupBy(d => d.DiscountName);
            foreach (var g in DN) { cmbDName.Text = g.Key.ToString(); }
            var bISBN = db.Books.Where(b => b.BookID == bID).GroupBy(b => b.ISBN);
            foreach (var g in bISBN) { cmbISBN.Text = g.Key; }
            var BT = db.Books.Where(b => b.BookID == bID).GroupBy(b => b.BookTitle);
            foreach (var g in BT) { cmbBTitle.Text = g.Key; }
        }

        private void btnDInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (discountNameTextBox.Text.Length == 0 || discounDescriptionTextBox.Text.Length == 0 || discountAmountTextBox.Text.Length == 0)
                {
                    MessageBox.Show("請確認\n\r各欄位 \n\r皆不為空", "請確認輸入資訊", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (decimal.Parse(discountAmountTextBox.Text) > 1)
                { MessageBox.Show("discountAmount折扣係數應<=1"); discountAmountTextBox.Focus(); }
                else
                {
                    DialogResult result = MessageBox.Show($"新增內容確認 \r\n " +
                        $"DiscountName：{discountNameTextBox.Text}\r\n" +
                        $"DiscounDescription：{discounDescriptionTextBox.Text}\r\n" +
                        $"DiscountAmount：{discountAmountTextBox.Text}\r\n...", "確認新增項目", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        DateTime start = DateTime.Now;
                        DateTime end = DateTime.Now.AddMonths(1);
                        int IsAct = 0;
                        if (startDateDateTimePicker.Value != DateTime.Now)
                        { start = startDateDateTimePicker.Value; }
                        if (endDateDateTimePicker.Value != DateTime.Now.AddMonths(1))
                        { end = endDateDateTimePicker.Value; }
                        //判斷區間
                        if (DateTime.Now >= start && DateTime.Now < end)
                        { IsAct = 1; }
                        Discount d = new Discount
                        {
                            DiscountName = discountNameTextBox.Text,
                            DiscounDescription = discounDescriptionTextBox.Text,
                            DiscountAmount = decimal.Parse(discountAmountTextBox.Text),
                            StartDate = start,
                            EndDate = end,
                            IsActive = IsAct,
                        };
                        db.Discounts.Add(d);
                        this.db.SaveChanges();
                        textClear();
                    }
                    this.Read_RefreshDataGridView();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDUpdate_Click(object sender, EventArgs e)
        {
            int dID = int.Parse(discountIDTextBox.Text);
            var discount = db.Discounts.Where(d=>d.DiscountID==dID).FirstOrDefault();
            if (discount == null) return;
            //確認欄位不為空
            else if (discountIDTextBox.Text.Length == 0 || discounDescriptionTextBox.Text.Length == 0 || discountAmountTextBox.Text.Length == 0)
            {
                MessageBox.Show("請確認\n\r欄位內容\n\r皆不為空", "請確認輸入資訊", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (decimal.Parse(discountAmountTextBox.Text)>1)
            { MessageBox.Show("discountAmount折扣係數應<=1"); discountAmountTextBox.Focus(); }
            else
            {
                DialogResult result=MessageBox.Show($"是否修改 \r\nDiscountID：{dID} 資料行", "確認修改項目", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    discount.DiscountName = discountNameTextBox.Text;
                    discount.DiscounDescription = discounDescriptionTextBox.Text;
                    discount.DiscountAmount = decimal.Parse(discountAmountTextBox.Text);
                    discount.StartDate = (DateTime)startDateDateTimePicker.Value;
                    discount.EndDate = (DateTime)endDateDateTimePicker.Value;
                    //判斷區間
                    if (DateTime.Now >= discount.StartDate && DateTime.Now < discount.EndDate)
                    { discount.IsActive = 1; }
                    else { discount.IsActive = 0; }
                    this.db.SaveChanges();
                    textClear();
                }
            }
            this.Read_RefreshDataGridView();
        }

        private void btnDDelete_Click(object sender, EventArgs e)
        {
            int dID = int.Parse(discountIDTextBox.Text);
            var discount = db.Discounts.Where(d => d.DiscountID == dID).FirstOrDefault();
            if (discount == null) { return; }
            else
            {
                DialogResult result = MessageBox.Show($"是否刪除 \r\nDiscountID：{dID} 資料行", "確認刪除項目", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    this.db.Discounts.Remove(discount);
                    this.db.SaveChanges();
                    textClear();
                }
            }
            this.Read_RefreshDataGridView();
        }

        private void cmbISBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ISBN = cmbISBN.Text;
            var bISBN = db.Books.Where(b => b.ISBN == ISBN).GroupBy(b => b.BookID);
            foreach (var g in bISBN) { bookIDTextBox.Text = g.Key.ToString(); }
            int bID = int.Parse(bookIDTextBox.Text);
            var BT = db.Books.Where(b => b.BookID == bID).GroupBy(b => b.BookTitle);
            foreach (var g in BT) { cmbBTitle.Text = g.Key; }
            var cID = db.CategoryDetails.Where(a => a.BookID == bID).GroupBy(a => new { a.SubCategory.Category.CategoryID });
            foreach (var g in cID) { categoryIDTextBox.Text = g.Key.CategoryID.ToString(); }
        }

        private void cmbBTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string BTitle = cmbBTitle.Text;
            var BT = db.Books.Where(b => b.BookTitle == BTitle).GroupBy(b => b.BookID);
            foreach (var g in BT) { bookIDTextBox.Text = g.Key.ToString(); }
            int bID = int.Parse(bookIDTextBox.Text);
            var bISBN = db.Books.Where(b => b.BookID == bID).GroupBy(b => b.ISBN);
            foreach (var g in bISBN) { cmbISBN.Text = g.Key; }
            var cID = db.CategoryDetails.Where(a => a.BookID == bID).GroupBy(a => new { a.SubCategory.Category.CategoryID });
            foreach (var g in cID) { categoryIDTextBox.Text = g.Key.CategoryID.ToString(); }
        }

        private void cmbDName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DName = cmbDName.Text;
            var DN = db.Discounts.Where(d => d.DiscountName == DName).GroupBy(d => d.DiscountID);
            foreach (var g in DN) { discountIDTextBox1.Text = g.Key.ToString(); }
        }

        private void btnInsertDD_Click(object sender, EventArgs e)
        {
            try
            {
                int dID, bID,cID;
                bool idD = int.TryParse(discountIDTextBox1.Text, out dID);
                bool idB = int.TryParse(bookIDTextBox.Text, out bID);
                var qC = db.CategoryDetails.Where(a => a.BookID == bID).GroupBy(a => new { a.SubCategory.Category.CategoryID });
                 foreach (var g in qC) { categoryIDTextBox.Text = g.Key.CategoryID.ToString(); }
                bool idC = int.TryParse(categoryIDTextBox.Text, out cID);
                var qA = db.Discounts.Where(d => d.DiscountID == dID).FirstOrDefault();
                var qB = db.Discount_Detail.Where(a => a.BookID == bID).FirstOrDefault();
                if (idD == false || qA == null)
                { MessageBox.Show("請確認優惠ID"); }
                else if (qB != null)
                { MessageBox.Show("此書已設優惠，請確認書本ID"); }
                else
                {
                    Discount_Detail ddetail = new Discount_Detail
                    {
                        DiscountID = dID,
                        BookID = bID,
                        CategoryID=cID
                    };
                    db.Discount_Detail.Add(ddetail);
                    db.SaveChanges();
                    textClear();
                    this.Read_RefreshDataGridView();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnUpdateDD_Click(object sender, EventArgs e)
        {
            try
            {
                int ddID = int.Parse(discountDetailIDTextBox.Text);
                var DD = db.Discount_Detail.Where(d => d.DiscountDetailID == ddID).FirstOrDefault();
                if (DD == null) return; 
                else
                {
                    int dID, bID, cID;
                    bool idD = int.TryParse(discountIDTextBox1.Text, out dID);
                    bool idB = int.TryParse(bookIDTextBox.Text, out bID);
                    var qC = db.CategoryDetails.Where(a => a.BookID == bID).GroupBy(a => new { a.SubCategory.Category.CategoryID });
                    foreach (var g in qC) { categoryIDTextBox.Text = g.Key.CategoryID.ToString(); }
                    bool idC = int.TryParse(categoryIDTextBox.Text, out cID);
                    var qA = db.Discounts.Where(d => d.DiscountID == dID).FirstOrDefault();
                    var qB = db.Discount_Detail.Where(a => a.BookID == bID).GroupBy(a=>a.DiscountDetailID);

                    foreach (var g in qB)
                    {//書本單一優惠
                        if (ddID != g.Key) { MessageBox.Show("此書已設優惠，請確認書本ID"); return; }
                    }
                    if (idD == false || qA == null)
                    { MessageBox.Show("請確認優惠ID"); }
                    else
                    {
                        DialogResult result = MessageBox.Show($"是否修改 \r\n DiscountDetailID：{ddID} 資料行", "確認修改項目", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            DD.DiscountID = dID;
                            DD.BookID = bID;
                            DD.CategoryID = cID;
                            this.db.SaveChanges();
                            textClear();
                        }
                    }
                }
                this.Read_RefreshDataGridView();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteDD_Click(object sender, EventArgs e)
        {
            int ddID = int.Parse(discountDetailIDTextBox.Text);
            var DD = db.Discount_Detail.Where(d => d.DiscountDetailID == ddID).FirstOrDefault();
            if (DD == null) { return; }
            else
            {
                DialogResult result = MessageBox.Show($"是否刪除 \r\nDiscountDetailID：{ddID} 資料行", "確認刪除項目", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    this.db.Discount_Detail.Remove(DD);
                    this.db.SaveChanges();
                    textClear();
                }
            }
            this.Read_RefreshDataGridView();
        }

        private void discountAmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == '.' && !discountAmountTextBox.Text.Contains("."))
                {
                    // 允許輸入小數點
                }
                else
                {
                    e.Handled = true; // 取消事件
                }
            }
        }
    }
}
