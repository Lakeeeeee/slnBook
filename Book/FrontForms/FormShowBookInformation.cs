using Book.BackForms;
using Book.FrontForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Book
{
    public partial class Form_ShowBookInformation : Form
    {
        private Frm_Main M;
        public int _memberID; public List<CCart> _cart;
        public Form_ShowBookInformation(List<CInformation> newbooks, int index, List<CCart> incart, int memID = -1)
        {
            InitializeComponent();
            LoadCover(newbooks, index);
            LoadBook(newbooks, index);
            LoadMember(memID);
            loadcart(incart);
        }
        BookShopEntities3 dbContent = new BookShopEntities3();
        List<string> authorNames; int bookid;

        #region
        private void loadcart(List<CCart> indata)
        {
            _cart = indata;
        }

        private void LoadMember(int memID)
        {
            _memberID = memID;
            if (_memberID != -1)
            {
                btn_addauthor.Visible = true;
                btn_addpub.Visible = true;
                btn_addchart.Visible = true;
                btn_comment.Visible = true;
                this.numericUpDown1.Visible = true; this.label1.Visible = true;
            }
        }
        #endregion
        private void LoadBook(List<CInformation> newbooks, int index)
        {
            this.labBookTitle.Text = newbooks[index].book.BookTitle;
            this.labISBNRight.Text = newbooks[index].book.ISBN;
            this.labPagesRight.Text = newbooks[index].book.Pages.Replace(" ", string.Empty);
            this.labUnitInStockRight.Text = newbooks[index].book.UnitInStock.ToString();
            this.labUnitPriceRight.Text = newbooks[index].book.UnitPrice.ToString();
            this.labPublicateDateRight.Text = newbooks[index].book.PublicationDate.ToShortDateString();
            this.labCategoryRight.Text = newbooks[index].category.CategoryName;
            this.labLanguageRight.Text = newbooks[index].language.LanguageName;
            this.labPublisherNameRight.Text = newbooks[index].publisher.PublisherName;

            //var authors = dbContent.Books.Select(x => x.AuthorDetails.Where(y => y.BookID  == newbooks[index].book.BookID));
            var authors = from ad in dbContent.AuthorDetails.AsEnumerable()
                          join a in dbContent.Authors on ad.AuthorID equals a.AuthorID
                          where ad.BookID == newbooks[index].book.BookID
                          select new { 作者名 = ad.Author.AuthorName };
            this.labAuthorRight.Text = "";
            authorNames = new List<string>();
            foreach (var item in authors)
            {
                this.labAuthorRight.Text += item.作者名.ToString();
                this.labAuthorRight.Text += " ";
                authorNames.Add(item.作者名.ToString());
            }
            bookid = newbooks[index].book.BookID;
        }
        private void LoadCover(List<CInformation> newbooks, int index)
        {
            string path = Directory.GetCurrentDirectory();
            string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            string imgPath = "";
            imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"{newbooks[index].book.CoverPath}"));
            this.picBook.Image = System.Drawing.Image.FromFile(imgPath);
        }
        public Form_ShowBookInformation(int bID, int memID = -1)  //可以用-1控制  不一定要用建構子重建表單
        {
            InitializeComponent(); LoadMember(memID);
            var q = dbContent.Books.Where(b => b.BookID == bID);
            foreach (var b in q)
            {
                string path = Directory.GetCurrentDirectory();
                string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
                string imgPath = "";
                imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"{b.CoverPath}"));
                this.picBook.Image = System.Drawing.Image.FromFile(imgPath);
                this.labBookTitle.Text = b.BookTitle;
                this.labISBNRight.Text = b.ISBN;
                this.labPagesRight.Text = b.Pages.Replace(" ", string.Empty);
                this.labUnitInStockRight.Text = b.UnitInStock.ToString();
                this.labUnitPriceRight.Text = $"{b.UnitPrice:c0}";
                this.labPublicateDateRight.Text = b.PublicationDate.ToShortDateString();
                var q3 = dbContent.AuthorDetails.Where(a => a.BookID == b.BookID).Select(a => new { a.Author.AuthorName });
                string author = "";
                int fontsize = 16; authorNames = new List<string>(); //update
                foreach (var item in q3) { author += item.AuthorName + "\r\t"; fontsize--; authorNames.Add(item.AuthorName); } //update
                this.labAuthorRight.Text = author;
                labAuthorRight.Font = new System.Drawing.Font("微軟正黑體", fontsize, FontStyle.Regular);

                var q2 = dbContent.CategoryDetails.Where(a => a.BookID == b.BookID).Select(a => new { a.SubCategory.SubCategoryName, a.SubCategory.Category.CategoryName });
                string category = "";
                foreach (var item in q2) { category += item.CategoryName + ">"; }
                foreach (var item in q2) { category += item.SubCategoryName; }
                this.labCategoryRight.Text = category;
                var q4 = dbContent.Languages.Where(a => a.LanguageID == b.LanguageID);
                foreach (var item in q4) { this.labLanguageRight.Text = item.LanguageName; }
                var q5 = dbContent.Publishers.Where(a => a.PublisherID == b.PublisherID);
                foreach (var item in q5) { this.labPublisherNameRight.Text = item.PublisherName; }
                bookid = b.BookID;
            }
        }
        private void btn_addauthor_Click(object sender, EventArgs e)
        {
            var updatecollectedaurthor = dbContent.Members.Find(_memberID);
            var q = dbContent.Authors.Join(authorNames, x => x.AuthorName, y => y, (x, y) => x.AuthorID);
            foreach (var item in q)
            {
                CollectedAuthor a = new CollectedAuthor() { MemberID = _memberID, AuthorID = item };
                updatecollectedaurthor.CollectedAuthors.Add(a);
            }
            dbContent.SaveChanges();
            MessageBox.Show("已經關注作者");
        }
        private void btn_addpub_Click(object sender, EventArgs e)
        {
            var updatecollectedaurthor = dbContent.Members.Find(_memberID);
            var q = dbContent.Publishers.Where(x => x.PublisherName == labPublisherNameRight.Text).Select(x => x.PublisherID).ToList();
            foreach (var item in q)
            {
                CollectedPublisher p = new CollectedPublisher() { MemberID = _memberID, PublisherID = item };
                updatecollectedaurthor.CollectedPublishers.Add(p);
            }
            dbContent.SaveChanges();
            MessageBox.Show("已經關注出版社");
        }

        private void btn_comment_Click(object sender, EventArgs e)
        {
            var member = dbContent.Members.Find(_memberID);
            var q = from c in dbContent.Comments
                    where c.MemberID == _memberID && c.BookID == bookid
                    select c;
            if (q.Count() > 0)
            {
                MessageBox.Show("已經評論過了");
            }
            else
            {
                Frm_Browse comment = new Frm_Browse(member, sender, bookid);
                comment.ShowDialog();
                if (comment.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("感謝評論");
                }
            }
        }

        private void btn_addchart_Click(object sender, EventArgs e)
        {
            int qun = 0;
            bool check = int.TryParse(numericUpDown1.Value.ToString(), out qun);
            if (numericUpDown1.Value >= 0)
            {
                if (check == true && qun < dbContent.Books.Where(x => x.BookID == bookid).Select(x => x.UnitInStock).FirstOrDefault())
                {
                    CCart detail = new CCart()
                    {
                        Book = dbContent.Books.Where(x => x.BookID == bookid).FirstOrDefault(),
                        Quntity = (int)numericUpDown1.Value
                    };
                    _cart.Add(detail);
                    MessageBox.Show("已經加入購物車");

                    Frm_Main M = Application.OpenForms.OfType<Frm_Main>().FirstOrDefault(); //更新main的DGV1
                    if (M != null)
                    {
                        M.UpdateDataGridView(_cart);
                    }
                }
                else
                {
                    MessageBox.Show("庫存不足");
                }
            }
            else
            {
                MessageBox.Show("請輸入正確的數量！");
            }

        }
    }
}
