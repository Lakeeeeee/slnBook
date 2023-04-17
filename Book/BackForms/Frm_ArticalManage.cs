using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Book.BackForms
{
    public partial class Frm_ArticalManage : Form
    {
        public Frm_ArticalManage()
        {
            InitializeComponent();

            var AT = dbContext.Articals.Select(a => a.ArticalTitle);
            cmbATitle.DataSource = AT.ToList();
            var bISBN = dbContext.Books.Select(b => b.ISBN);
            cmbISBN.DataSource = bISBN.ToList();
            var BT = dbContext.Books.Select(b => b.BookTitle);
            cmbBTitle.DataSource = BT.ToList();

            articalPicturePictureBox.AllowDrop = true;
            articalPicturePictureBox.DragEnter += ArticalPicturePictureBox_DragEnter; 
            articalPicturePictureBox.DragDrop += ArticalPicturePictureBox_DragDrop;
        }

        private void ArticalPicturePictureBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            articalPicturePictureBox.Image = Image.FromFile(files[0]);
        }

        private void ArticalPicturePictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                // 檢查檔案副檔名是否為 .jpg 或 .jpeg
                if (Path.GetExtension(files[0]).ToLower() == ".jpg" || Path.GetExtension(files[0]).ToLower() == ".jpeg")
                {
                    // 允許拖曳
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    // 不允許拖曳，顯示錯誤訊息
                    e.Effect = DragDropEffects.None;
                    MessageBox.Show("只能拖曳 JPG 檔案！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        BookShopEntities3 dbContext = new BookShopEntities3();

        private void Frm_ArticalManage_Load(object sender, EventArgs e)
        {
            Read_RefreshDataGridView();
        }

        private void textClear()
        {
            articalIDTextBox.Clear();
            articalTitleTextBox.Clear();
            articalDateDateTimePicker.Value = DateTime.Now;
            articalDetailTextBox.Clear();
            articalPicturePictureBox.Image = null;
            articalDetailIDTextBox.Clear();
            articalIDTextBox1.Clear();
            bookIDTextBox.Clear();
        }

        void Read_RefreshDataGridView()
        {
            this.dgvArtical.DataSource = null;
            this.dgvADetail.DataSource = null;

            this.dgvArtical.DataSource = this.dbContext.Articals.Select(a => new { a.ArticalID, a.ArticalDate, a.ArticalTitle, a.ArticalDescription, a.ArticalPicture }).ToList();
            this.dgvADetail.DataSource = this.dbContext.ArticalToBookDetails.Select(d => new { d.ArticalDetailID, d.ArticalID, d.BookID }).ToList();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG files (*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                articalPicturePictureBox.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (articalTitleTextBox.Text.Length == 0 || articalDetailTextBox.Text.Length == 0 || articalPicturePictureBox.Image == null)
                {
                    MessageBox.Show("請確認\n\r標題、內容、圖 \n\r皆不為空", "請確認輸入資訊", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult result = MessageBox.Show($"新增內容確認 \r\n ArticalTitle：{articalTitleTextBox.Text}", "確認新增項目", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        byte[] bytes;
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        articalPicturePictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bytes = ms.GetBuffer();
                        Artical a = new Artical
                        {
                            ArticalTitle = articalTitleTextBox.Text,
                            ArticalDate = DateTime.Now,
                            ArticalDescription = articalDetailTextBox.Text,
                            ArticalPicture = bytes
                        };
                        dbContext.Articals.Add(a);
                        dbContext.SaveChanges();
                        textClear();
                    }
                    this.Read_RefreshDataGridView();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int aID = int.Parse(articalIDTextBox.Text);
            var artical = dbContext.Articals.Where(a => a.ArticalID == aID).FirstOrDefault();

            if (artical == null) return; //exit method
            else if (articalTitleTextBox.Text.Length == 0 || articalDetailTextBox.Text.Length == 0 || articalPicturePictureBox.Image == null)
            {
                MessageBox.Show("請確認\n\r標題、內容、圖 \n\r皆不為空", "請確認輸入資訊", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult result = MessageBox.Show($"是否修改 \r\n ArticalID：{aID} 資料行", "確認修改項目", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    byte[] bytes;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    articalPicturePictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bytes = ms.GetBuffer();

                    artical.ArticalTitle = articalTitleTextBox.Text;
                    if (artical.ArticalDate != DateTime.Now)
                    { artical.ArticalDate = articalDateDateTimePicker.Value; }
                    artical.ArticalDescription = articalDetailTextBox.Text;
                    artical.ArticalPicture = bytes;
                    this.dbContext.SaveChanges();
                    textClear();
                }
            }
            this.Read_RefreshDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int aID = int.Parse(articalIDTextBox.Text);
            var artical = dbContext.Articals.Where(a=> a.ArticalID == aID).FirstOrDefault();

            if (artical == null) return;
            DialogResult result = MessageBox.Show($"是否刪除 \r\nArticalID：{aID} 資料行", "確認刪除項目", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.dbContext.Articals.Remove(artical);
                this.dbContext.SaveChanges();
                textClear();
            }
            this.Read_RefreshDataGridView();
        }

        private void btnInsertAD_Click(object sender, EventArgs e)
        {
            try
            {
                int aID, bID;
                bool idA = int.TryParse(articalIDTextBox1.Text, out aID);
                bool idB = int.TryParse(bookIDTextBox.Text, out bID);
                var qA = dbContext.Articals.Where(a => a.ArticalID == aID).FirstOrDefault();
                var qB = dbContext.Books.Where(a => a.BookID == bID).FirstOrDefault();
                if (idA == false || qA == null)
                { MessageBox.Show("請確認文章ID"); }
                else if (idB == false || qB == null)
                { MessageBox.Show("請確認書本ID"); }
                else
                {
                    DialogResult result = MessageBox.Show($"新增內容確認 \r\n ArticalID：{aID}\r\nBookID：{bID}", "確認新增項目", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        ArticalToBookDetail adetail = new ArticalToBookDetail
                        {
                            ArticalID = aID,
                            BookID = bID
                        };
                        dbContext.ArticalToBookDetails.Add(adetail);
                        dbContext.SaveChanges();
                        textClear();
                    }
                    this.Read_RefreshDataGridView();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnUpdateAD_Click(object sender, EventArgs e)
        {
            try
            {
                int adID = int.Parse(articalDetailIDTextBox.Text);
                var artical = dbContext.ArticalToBookDetails.Where (a=>a.ArticalDetailID == adID).FirstOrDefault();
                              
                if (artical == null) return; //exit method
                else
                {
                    int aID, bID;
                    bool idA = int.TryParse(articalIDTextBox1.Text, out aID);
                    bool idB = int.TryParse(bookIDTextBox.Text, out bID);
                    var qA = dbContext.Articals.Where(a => a.ArticalID == aID).FirstOrDefault();
                    var qB = dbContext.Books.Where(a => a.BookID == bID).FirstOrDefault();
                    if (idA == false || qA == null)
                    { MessageBox.Show("請確認文章ID"); }
                    else if (idB == false || qB == null)
                    { MessageBox.Show("請確認書本ID"); }
                    else
                    {
                        DialogResult result = MessageBox.Show($"是否修改 \r\n ArticalDetailID：{adID} 資料行", "確認修改項目", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            artical.ArticalID = aID;
                            artical.BookID = bID;
                            this.dbContext.SaveChanges();
                            textClear();
                        }
                    }
                }
                this.Read_RefreshDataGridView();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteAD_Click(object sender, EventArgs e)
        {
            int adID = int.Parse(articalDetailIDTextBox.Text);
            var artical = dbContext.ArticalToBookDetails.Where(a=>a.ArticalDetailID == adID).FirstOrDefault();                       
            if (artical == null) return;
            DialogResult result = MessageBox.Show($"是否刪除 \r\nArticalDetailID：{adID} 資料行", "確認刪除項目", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.dbContext.ArticalToBookDetails.Remove(artical);
                this.dbContext.SaveChanges();
                textClear();
            }
            this.Read_RefreshDataGridView();
        }

        private void cmbATitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ATitle = cmbATitle.Text;
            var AT = dbContext.Articals.Where(a => a.ArticalTitle == ATitle).GroupBy(a => a.ArticalID);
            foreach (var g in AT) { articalIDTextBox1.Text = g.Key.ToString(); }
        }

        private void cmbISBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ISBN = cmbISBN.Text;
            var bISBN = dbContext.Books.Where(b => b.ISBN == ISBN).GroupBy(b => b.BookID);
            foreach (var g in bISBN) { bookIDTextBox.Text = g.Key.ToString(); }
            int bID = int.Parse(bookIDTextBox.Text);
            var BT = dbContext.Books.Where(b => b.BookID == bID).GroupBy(b => b.BookTitle);
            foreach (var g in BT) { cmbBTitle.Text = g.Key; }
        }

        private void cmbBTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string BTitle = cmbBTitle.Text;
            var BT = dbContext.Books.Where(b => b.BookTitle == BTitle).GroupBy(b => b.BookID);
            foreach (var g in BT) { bookIDTextBox.Text = g.Key.ToString(); }
            int bID = int.Parse(bookIDTextBox.Text);
            var bISBN = dbContext.Books.Where(b => b.BookID == bID).GroupBy(b => b.ISBN);
            foreach (var g in bISBN) { cmbISBN.Text = g.Key; }
        }

        private void dgvArtical_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int site = dgvArtical.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvArtical.Rows[site];
            articalIDTextBox.Text = row.Cells["ArticalID"].Value.ToString();
            articalTitleTextBox.Text = row.Cells["ArticalTitle"].Value.ToString();
            articalDateDateTimePicker.Value = (DateTime)row.Cells["ArticalDate"].Value;
            articalDetailTextBox.Text = row.Cells["ArticalDescription"].Value.ToString();

            byte[] bytes = (byte[])row.Cells["ArticalPicture"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            articalPicturePictureBox.Image = Image.FromStream(ms);
        }

        private void dgvADetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int site = dgvADetail.SelectedCells[0].RowIndex;
            DataGridViewRow row = dgvADetail.Rows[site];
            articalDetailIDTextBox.Text = row.Cells["ArticalDetailID"].Value.ToString();
            articalIDTextBox1.Text = row.Cells["ArticalID"].Value.ToString();
            bookIDTextBox.Text = row.Cells["BookID"].Value.ToString();
            int aID = int.Parse(articalIDTextBox1.Text);
            int bID = int.Parse(bookIDTextBox.Text);

            var AT = dbContext.Articals.Where(a => a.ArticalID == aID).GroupBy(a => a.ArticalTitle);
            foreach (var g in AT) { cmbATitle.Text = g.Key; }

            var bISBN = dbContext.Books.Where(b => b.BookID == bID).GroupBy(b => b.ISBN);
            foreach (var g in bISBN) { cmbISBN.Text = g.Key; }

            var BT = dbContext.Books.Where(b => b.BookID == bID).GroupBy(b => b.BookTitle);
            foreach (var g in BT) { cmbBTitle.Text = g.Key; }
        }
    }
}
