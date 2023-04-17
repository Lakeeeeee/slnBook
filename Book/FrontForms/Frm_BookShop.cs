using Book.BackForms;
using Book.FrontForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;

namespace Book
{

    public partial class Frm_BookShop : Form
    {
        public CBookManager cm; bool IsFirstLoad = true;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<Label> labels = new List<Label>();
        List<string> imagePaths = new List<string>();
        public int _memID; public List<CCart> _cart;
        public Frm_BookShop(List<CCart> cart, int memID = -1 )
        {
            InitializeComponent();
            cm = new CBookManager();
            LoadCobSearch();
            LoadCobSearchcategory();
            LoadHotBooks();
            loadArtical(); 
            loadmemID(memID); loadcart(cart);
        }
        private void loadcart(List<CCart> indata)
        {
            _cart=indata;
        }
        private void loadmemID(int indata)  
        {
            _memID = indata;
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
        private List<int> GetRandomBook(int bookNums)
        {
            List<int> myRandomNumbers = new List<int>();
            for (int i = 0; i < bookNums; i++)
            {
                Random random = new Random();
                int tmp = random.Next(1,cm.dbContent.Books.Count());
                if (!myRandomNumbers.Contains(tmp))
                {
                    myRandomNumbers.Add(tmp);
                }
                else
                {
                    i--;
                }
            }
            return myRandomNumbers;
        }
        private void LoadHotBooks()
        {
            List<int> bookIDs = GetRandomBook(28);
            cm.LoadDataByID(bookIDs);
            string path = Directory.GetCurrentDirectory();
            string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            string imgPath = "";
            imagePaths.Clear();
            for (int i = 0; i < cm.newBooks.Count(); i++)
            {
                imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"{cm.newBooks[i].book.CoverPath}"));
                imagePaths.Add(imgPath);
            }
            ShowBooks();
        }
        private void ShowBooks()
        {
            if (IsFirstLoad)
            {
                for (int i = 0; i < imagePaths.Count(); i++)
                {
                    PictureBox tmp = new PictureBox();
                    tmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    //tmp.Location = new System.Drawing.Point(50 + 150 * (i % 7), 120 + 180 * (i / 7)); //size
                    tmp.Name = i.ToString();
                    tmp.BackColor = Color.Transparent;
                    tmp.Size = new System.Drawing.Size(180, 200);
                    tmp.TabIndex = i;
                    tmp.TabStop = false;
                    tmp.Image = System.Drawing.Image.FromFile(imagePaths[i]);
                    tmp.Click += new System.EventHandler((s, e) => show_image(s, e, tmp.TabIndex));
                    pictureBoxes.Add(tmp);

                    Label lab = new Label();
                    // lab.Location = new System.Drawing.Point(50 + 150 * (i % 7), 270 + 180 * (i / 7)); //size
                    lab.Name = i.ToString();
                    lab.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
                    //lab.Size = new Size(100, 25);
                    lab.TabIndex = i;
                    lab.TabStop = false;
                    lab.Text = "";
                    lab.ForeColor = Color.BlanchedAlmond;
                    lab.AutoSize = true;
                    lab.Padding = new Padding(0, 160, 10, 0);
                    labels.Add(lab);
                    this.flowLayoutPanel1.Controls.Add(tmp);
                    this.flowLayoutPanel1.Controls.Add(lab);
                }
                IsFirstLoad = false;
            }
            else
            {
                foreach (Control ctrl in this.flowLayoutPanel1.Controls)
                {
                    if (ctrl is PictureBox)
                        (ctrl as PictureBox).Image = null;
                    else if (ctrl is Label)
                        (ctrl as Label).Text = "";
                }
                for (int i = 0; i < imagePaths.Count(); i++)
                {
                    if (i > 27)
                    {
                        break;
                    }
                    try { pictureBoxes[i].Image = System.Drawing.Image.FromFile(imagePaths[i]); } catch (Exception ex) { }
                }
            }
        }
        private void show_image(object sender, EventArgs e, int index)  
        {
            if (_memID != -1)
            {
                Form_ShowBookInformation show = new Form_ShowBookInformation(cm.newBooks, index, _cart, _memID);
                show.Show();
            }
            else
            {
                Form_ShowBookInformation show = new Form_ShowBookInformation(cm.newBooks, index, _cart);
                show.Show();
            }
        }
        private List<int> GetBookIDs(List<CInformation> newbooks)
        {
            List<int> bookIDs = new List<int>();
            foreach (var item in newbooks)
            {
                bookIDs.Add(item.book.BookID);
            }
            string path = Directory.GetCurrentDirectory();
            string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            string imgPath = "";
            imagePaths.Clear();
            for (int i = 0; i < cm.newBooks.Count(); i++)
            {
                imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"{cm.newBooks[i].book.CoverPath}"));
                imagePaths.Add(imgPath);
            }
            return bookIDs;
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
            List<int> bookIDs = GetBookIDs(cm.newBooks);
            ShowBooks();
            ShowBookSearch(select, bookIDs);
            this.flowLayoutPanel1.ScrollControlIntoView(flowLayoutPanel1.Controls[0]);
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
            List<int> bookIDs = GetBookIDs(cm.newBooks);
            ShowBooks();
            ShowBookSearch(select, bookIDs);
            this.flowLayoutPanel1.ScrollControlIntoView(flowLayoutPanel1.Controls[0]);
        }
        private void ShowBookSearch(string select, List<int> bookIDs)
        {
            int booksCount = cm.newBooks.Count();
            for (int i = 0; i < booksCount; i++)
            {
                if (i < 28)
                {
                    switch (select)//switch (比對的運算式)
                    {
                        case "書名":
                            labels[i].Text = $"{select} : {cm.newBooks[i].book.BookTitle}";
                            break;
                        case "出版社":
                            labels[i].Text = $"{select} : {cm.newBooks[i].publisher.PublisherName}";
                            break;
                        case "語言":
                            labels[i].Text = $"{select} : {cm.newBooks[i].language.LanguageName}";
                            break;
                        case "ISBN":
                            labels[i].Text = $"{select} : {cm.newBooks[i].book.ISBN}";
                            break;
                        case "封裝方式":
                            labels[i].Text = $"{select} : {cm.newBooks[i].book.BindingMethod}";
                            break;
                        case "出版日期":
                            labels[i].Text = $"{select} : {cm.newBooks[i].book.PublicationDate.ToShortDateString()}";
                            break;
                        case "定價":
                            labels[i].Text = $"{select} : {cm.newBooks[i].book.UnitPrice}";
                            break;
                        case "庫存":
                            labels[i].Text = $"{select} : {cm.newBooks[i].book.UnitInStock}";
                            break;
                        case "分類":
                            labels[i].Text = $"{select} : {cm.newBooks[i].category.CategoryName}";
                            break;
                        default://以上都不符合走這個
                            break;
                    }
                }
            }
        }
        private void LoadCobSearchcategory()
        {
            this.cobSearchCategory.Items.Clear();
            var q = cm.dbContent.Categories.Select(x => x.CategoryName).ToList();
            foreach (string name in q)
            {
                this.cobSearchCategory.Items.Add(name);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadHotBooks();
        }
        private void LoadCobSearchSubcategory(int i)
        {
            this.cobSearchSubcategory.Items.Clear();
            var q = cm.dbContent.SubCategories.Where(x => x.CategoryID == i).Select(x => x.SubCategoryName);
            foreach (string name in q)
            {
                this.cobSearchSubcategory.Items.Add(name);
            }
        }

        private void loadArtical()   
        {
            this.flowLayoutPanel2.Controls.Clear();
            try
            {
                Random random = new Random();
                int aid = random.Next(1, cm.dbContent.Articals.Count());
                var a = cm.dbContent.Articals.Where(x => x.ArticalID == aid).FirstOrDefault();

                if (a.ArticalPicture != null)
                {
                    byte[] bytes = a.ArticalPicture;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                    pB_main.Image = Image.FromStream(ms);
                }
                else { pB_main.Image = pB_main.ErrorImage; }
                pB_main.Tag = a.ArticalID;

                var q2 = cm.dbContent.ArticalToBookDetails.Where(d => d.ArticalID == a.ArticalID).Select(d => new
                {
                    d.Book.BookTitle,  d.Book.ISBN,  d.Book.UnitPrice,
                    d.Book.Introduction, d.Book.CoverPath, d.Book.BookID,
                });

                foreach (var d in q2)
                {
                    PictureBox atpb = new PictureBox();
                    atpb.Size = new Size(180, 200); atpb.SizeMode = PictureBoxSizeMode.StretchImage;
                    atpb.Tag = d.BookID;
                    if (d.CoverPath != null)
                    {
                        string path = Directory.GetCurrentDirectory();
                        string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
                        string imgPath = "";
                        imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"{d.CoverPath}"));
                        atpb.Image = Image.FromFile(imgPath);
                    }
                    else { atpb.Image = atpb.ErrorImage; }
                    atpb.Click += Atpb_Click; ;
                    this.flowLayoutPanel2.Controls.Add(atpb);
                }
            }
            catch (Exception) { }
        }

        private void Atpb_Click(object sender, EventArgs e)
        {
            int bID = (int)((PictureBox)sender).Tag;
            if (_memID != -1)
            {
                Form_ShowBookInformation show = new Form_ShowBookInformation(bID, _memID);
                show.ShowDialog();
            }
            else
            {
                Form_ShowBookInformation show = new Form_ShowBookInformation(bID);
                show.ShowDialog();
            }
        }

        private void btn_recom_Click(object sender, EventArgs e)
        {
            loadArtical();
        }

        private void pB_main_Click(object sender, EventArgs e)
        {
            int AT = (int)((PictureBox)sender).Tag;
            Frm_ArticalContent frm = new Frm_ArticalContent(AT);
            frm.Show();
        }

        private void Frm_BookShop_Load(object sender, EventArgs e)
        {

            Frm_ArticalArea frm_Artical = new Frm_ArticalArea();
            frm_Artical.Parent = null; frm_Artical.TopLevel = false;
            this.tabPage2.Controls.Add(frm_Artical);
            frm_Artical.Show(); frm_Artical.Dock = DockStyle.Fill;

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
            cm.LoadSearchCate(category, subcategory);
            List<int> bookIDs = GetBookIDs(cm.newBooks);
            ShowBooks();
            ShowBookSearch("分類", bookIDs);
            this.flowLayoutPanel1.ScrollControlIntoView(flowLayoutPanel1.Controls[0]);
        }
    }
}
