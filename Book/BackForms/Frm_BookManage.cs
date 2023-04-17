using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Status;

namespace Book.BackForms
{
    public partial class Frm_BookManage : Form
    {
        CBookManager cm;
        public Frm_BookManage()
        {
            InitializeComponent();
            cm = new CBookManager();
            LoadCobSearch();
        }
        private void LoadCobSearch()
        {
            foreach (var name in cm.CobSearchRangeList)
            {
                this.cobSearchRange.Items.Add(name.Item1);
            }
            foreach (var name in cm.CobSearchList)
            {
                this.cobSearch.Items.Add(name.Item1);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            cm.LoadAllData();
            LoadCobLanguageName();
            LoadCobPublisherName();
            LoadCobSearchcategory();
            LoadCobAuthor();
            LoadCobTranslator();
            LoadCobPainter();
            LoadCobCategory();
            ShowBookDetail(this.cm.newBooks, 0);
            this.cobLanguageName.SelectedIndex = 0;
            this.cobPublisherName.SelectedIndex = 0;
            this.dataGridView1.DataSource = cm.Query.ToList();
        }
        private void LoadCobSearchcategory()
        {
            this.cobSearchCategory.Items.Clear();
            var q = cm.dbContent.Categories.Select(x=>x.CategoryName).ToList();
            foreach (string name in q)
            {
                this.cobSearchCategory.Items.Add(name);
            }
        }
        private void LoadCobLanguageName()
        {
            this.cobLanguageName.Items.Clear();
            var q = cm.dbContent.Languages.Select(p => p.LanguageName).ToList();
            foreach (string name in q)
            {
                this.cobLanguageName.Items.Add(name);
            }
        }
        private void LoadCobAuthor()
        {
            this.cobAuthor.Items.Clear();
            var q = cm.dbContent.Authors.Select(p => p.AuthorName).ToList();
            foreach(string name in q)
            {
                this.cobAuthor.Items.Add(name);
            }
        }
        private void LoadCobTranslator()
        {
            this.cobTranslator.Items.Clear();
            var q = cm.dbContent.Translators.Select(p => p.TranslatorName).ToList();
            foreach (string name in q)
            {
                this.cobTranslator.Items.Add(name);
            }
        }
        private void LoadCobPainter()
        {
            this.cobPainter.Items.Clear();
            var q = cm.dbContent.Painters.Select(p => p.PainterName).ToList();
            foreach(string name in q)
            {
                this.cobPainter.Items.Add(name);
            }
        }

        private void LoadCobCategory()
        {
            this.cobCategory.Items.Clear();
            var q = cm.dbContent.Categories.Select(p => p.CategoryName).ToList();
            foreach(string name in q)
            {
                this.cobCategory.Items.Add(name);
            }
        }


        private void LoadCobPublisherName()
        {
            this.cobPublisherName.Items.Clear();
            var q = cm.dbContent.Publishers.Select(p => p.PublisherName).ToList();
            foreach (string name in q)
            {
                this.cobPublisherName.Items.Add(name);
            }
        }

        private void ShowBookDetail(List<CInformation> book,int i)
        {
            this.txtBookTitle.Text = book[i].book.BookTitle;
            this.txtAboutAuthor.Text = book[i].book.AboutAuthor;
            this.txtPublicationDate.Text = book[i].book.PublicationDate.ToShortDateString();
            this.txtUnitPrice.Text = book[i].book.UnitPrice.ToString();
            this.txtIntroduction.Text = book[i].book.Introduction;
            this.txtISBN.Text = book[i].book.ISBN;
            this.txtBindingMethod.Text = book[i].book.BindingMethod;
            this.txtPages.Text = book[i].book.Pages;
            this.txtDimensions.Text = book[i].book.Dimensions;
            this.txtUnitInStock.Text = book[i].book.UnitInStock.ToString();
            this.txtCoverPath.Text = book[i].book.CoverPath;
            this.cobLanguageName.Text = book[i].language.LanguageName;
            this.cobPublisherName.Text = book[i].publisher.PublisherName;
            this.cobAuthor.Text = book[i].author.AuthorName;
            this.cobTranslator.Text = book[i].translator.TranslatorName;
            this.cobPainter.Text = book[i].painter.PainterName;
            this.cobCategory.Text = book[i].category.CategoryName;
            this.cobSubCategory.Text = book[i].subCategory.SubCategoryName;
            //this.cobLanguageName.SelectedIndex = (int)book[i].LanguageID - 1;
            //this.cobPublisherName.SelectedIndex = (int)book[i].PublisherID - 1;
            ShowCover(book,i);
        }
        private void ShowCover(List<CInformation> book, int i)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
                string imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"{book[i].book.CoverPath}"));
                System.Drawing.Image image = System.Drawing.Image.FromFile(imgPath);
                pictureBox1.Image = image;
            }
            catch (Exception ex)
            {
                string path = Directory.GetCurrentDirectory();
                string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
                string imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"cover/error.png"));
                System.Drawing.Image image = System.Drawing.Image.FromFile(imgPath);
                pictureBox1.Image = image;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowBookDetail(this.cm.newBooks,this.dataGridView1.CurrentCell.RowIndex);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtBookTitle.Clear();
            this.txtAboutAuthor.Clear();
            this.cobAuthor.SelectedIndex = -1;
            this.cobTranslator.SelectedIndex = -1;
            this.cobPainter.SelectedIndex = -1;
            this.cobLanguageName.SelectedIndex = -1;
            this.txtPublicationDate.Clear();
            this.cobPublisherName.SelectedIndex = -1;
            this.txtUnitPrice.Clear();
            this.txtIntroduction.Clear();
            this.txtISBN.Clear();
            this.txtBindingMethod.Clear();
            this.txtPages.Clear();
            this.txtDimensions.Clear();
            this.txtUnitInStock.Clear();
            this.txtCoverPath.Clear();
            this.cobCategory.SelectedIndex = -1;
            this.cobSubCategory.SelectedIndex = -1;
            this.pictureBox1.Image = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string select = this.cobSearch.Text;
            string text = this.txtSearch.Text;
            switch (select)//switch (比對的運算式)
            {
                case "書名":
                    cm.LoadSearchTitle(text);
                    break;
                case "出版社":
                    cm.LoadSearchPublisherName(text);
                    break;
                case "語言":
                    cm.LoadSearchLanguageName(text);
                    break;
                case "ISBN":
                    cm.LoadSearchISBN(text);
                    break;
                case "封裝方式":
                    cm.LoadSearchBindingMethod(text);
                    break;
                default://以上都不符合走這個
                    break;
            }
            this.dataGridView1.DataSource = cm.Query.ToList();
            BeforeShowBookDetail();
        }

        private void btnSearchRange_Click(object sender, EventArgs e)
        {
            string select = this.cobSearchRange.Text;
            string front = this.txtSearchRangeFront.Text;
            string back = this.txtSearchRangeBack.Text;
            System.DateTime timeFront = this.dateTimePicker1.Value.Date;
            System.DateTime timeBack = this.dateTimePicker2.Value.Date;
            switch (select)//switch (比對的運算式)
            {
                case "出版日期":
                    cm.LoadSearchRangePublicationDate(timeFront, timeBack);
                    break;
                case "定價":
                    cm.LoadSearchRangeUnitPrice(front, back);
                    break;
                case "庫存":
                    cm.LoadSearchRangeUnitInStock(front, back);
                    break;
                default://以上都不符合走這個
                    break;
            }
            this.dataGridView1.DataSource = cm.Query.ToList();
            BeforeShowBookDetail();
        }
        private void BeforeShowBookDetail()
        {
            if (cm.newBooks.Count > 0)
            {
                ShowBookDetail(this.cm.newBooks, this.dataGridView1.CurrentCell.RowIndex);
            }
            else
            {
                this.dataGridView1.DataSource = null;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                this.txtCoverPath.Text = $"cover/new/{cm.NewCoverCount + 1}.png";
            }
        }
        BookShopEntities3 entities3 = new BookShopEntities3();
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null)
            {
                MessageBox.Show("請插入封面圖片!");
            }
            else
            {
                cm.InsertBook(this.txtBookTitle.Text,
                this.txtAboutAuthor.Text,
                this.cobPublisherName.Text,
                this.cobAuthor.Text,
                this.cobTranslator.Text,
                this.cobPainter.Text,
                this.txtPublicationDate.Text,
                this.txtPages.Text,
                this.txtIntroduction.Text,
                this.txtISBN.Text,
                this.txtDimensions.Text,
                this.cobLanguageName.Text,
                this.cobCategory.Text,
                this.cobSubCategory.Text,
                this.txtBindingMethod.Text,
                this.txtUnitPrice.Text,
                this.txtUnitInStock.Text,
                this.txtCoverPath.Text);
                cm.AfterBrowse(pictureBox1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deleteID = cm.newBooks[this.dataGridView1.CurrentCell.RowIndex].book.BookID;
            cm.DeleteBook(deleteID);
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            this.txtBookTitle.Text = DateTime.Now.ToLongTimeString();
            this.txtAboutAuthor.Text = "這是一本Demo書的作者介紹";
            this.cobAuthor.SelectedIndex = 20;
            this.cobTranslator.SelectedIndex = -1;
            this.cobPainter.SelectedIndex = -1;
            this.cobCategory.SelectedIndex = 0;
            this.cobPublisherName.SelectedIndex = 0;
            this.txtPublicationDate.Text = DateTime.Now.ToShortDateString();
            this.cobLanguageName.SelectedIndex = 0;
            this.txtUnitPrice.Text = "10000";
            this.txtIntroduction.Text = "這是一本Demo書的詳細資料";
            this.txtISBN.Text = "1234567890";
            this.txtBindingMethod.Text = "精裝";
            this.txtPages.Text = "300頁";
            this.txtDimensions.Text = "1920*1080";
            this.txtUnitInStock.Text = "3";
            this.txtCoverPath.Text = "";
            this.cobSubCategory.SelectedIndex = -1;
            this.pictureBox1.Image = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updateID = cm.newBooks[this.dataGridView1.CurrentCell.RowIndex].book.BookID;
            cm.EditBook(updateID,
                this.txtBookTitle.Text,
                 this.txtAboutAuthor.Text,
                 this.cobPublisherName.Text,
                 this.cobAuthor.Text,
                 this.cobTranslator.Text,
                 this.cobPainter.Text,
                 this.txtPublicationDate.Text,
                 this.txtPages.Text,
                 this.txtIntroduction.Text,
                 this.txtISBN.Text,
                 this.txtDimensions.Text,
                 this.cobLanguageName.Text,
                 this.cobCategory.Text,
                 this.cobSubCategory.Text,
                 this.txtBindingMethod.Text,
                 this.txtUnitPrice.Text,
                 this.txtUnitInStock.Text,
                 this.txtCoverPath.Text);
        }
        private void LoadCobSearchSubcategory(int i)
        {
            this.cobSearchSubcategory.Items.Clear();
            var q = cm.dbContent.SubCategories.Where(x => x.CategoryID == i).Select(x => x.SubCategoryName);
            foreach (string name in q)
            {
                if (name != null)
                {
                    this.cobSearchSubcategory.Items.Add(name);
                }
            }
        }

        private void cobSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cobSearchSubcategory.SelectedIndex = -1;
            LoadCobSearchSubcategory(this.cobSearchCategory.SelectedIndex + 1);
        }

        private void btnCateSearch_Click(object sender, EventArgs e)
        {
            string category = this.cobSearchCategory.Text;
            string subcategory = this.cobSearchSubcategory.Text;
            cm.LoadSearchCate(category,subcategory);
            this.dataGridView1.DataSource = cm.Query.ToList();
            BeforeShowBookDetail();
        }
        private void LoadCobSubCategory(int i)
        {
            this.cobSubCategory.Items.Clear();
            var q = cm.dbContent.SubCategories.Where(x => x.CategoryID == i).Select(x => x.SubCategoryName);
            foreach (string name in q)
            {
                if (name != null)
                {
                    this.cobSubCategory.Items.Add(name);
                }
            }
        }
        private void cobCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cobSubCategory.SelectedIndex = -1;
            LoadCobSubCategory(this.cobCategory.SelectedIndex + 1);
        }
    }
}
