using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Book.BackForms
{
    public class CBookManager
    {
        public BookShopEntities3 dbContent = new BookShopEntities3();
        public IQueryable<dynamic> Query = null;
        public List<CInformation> newBooks = new List<CInformation>();
        public List<Tuple<string, string>> CobSearchRangeList { get; set; }
        public List<Tuple<string, string>> CobSearchList { get; set; }
        public int NewCoverCount { get; set; }
        public CBookManager()
        {
            CobSearchList = new List<Tuple<string, string>> ();
            CobSearchRangeList = new List<Tuple<string, string>>();
            FillCobSearch();
            SetNewCoverCount();
        }
        private void FillCobSearch()
        {
            var names = typeof(Book).GetProperties()
                        .Select(p => p.Name).ToList();
            List<string> cobSearchChinese = new List<string> {"BookID","書名","作者介紹","出版社","出版日期","語言","定價","詳細資料","ISBN","封裝方式","頁數","規格","庫存","封面圖片路徑"};
            for(int i = 0; i < names.Count; i++)
            {
                if(i == 4 || i == 6 || i == 12)
                {
                    this.CobSearchRangeList.Add(Tuple.Create(cobSearchChinese[i], names[i]));
                }
                else if(i == 1 || i == 3 || i == 5 || i == 8 || i == 9)
                {
                    this.CobSearchList.Add(Tuple.Create(cobSearchChinese[i], names[i]));
                }
            }
        }
        private void EditBooksMoneySign(CInformation newBook)
        {
            newBook.book.Introduction = EditMoneySign(newBook.book.Introduction);
            newBook.book.AboutAuthor = EditMoneySign(newBook.book.AboutAuthor);
            newBook.book.BookTitle = EditMoneySign(newBook.book.BookTitle);
        }
        private string EditMoneySign(string text)
        {
            if (text != null)
            {
                string after = "";
                foreach (char s in text)
                {
                    if (s == '$')
                    {
                        after += ' ';
                    }
                    else
                    {
                        after += s;
                    }
                }
                return after;
            }
            return text;
        }
        public void LoadDataByID(List<int> bookIDs)
        {
            Query = from b in dbContent.Books
                    where bookIDs.Contains(b.BookID)
                    select new
                    {
                        書本ID = b.BookID,
                        書名 = b.BookTitle,
                        ISBN = b.ISBN,
                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                        出版社 = b.Publisher.PublisherName,
                        出版日期 = b.PublicationDate,
                        語言 = b.Language.LanguageName,
                        定價 = b.UnitPrice,
                        封裝方法 = b.BindingMethod,
                        頁數 = b.Pages,
                        規格 = b.Dimensions,
                        庫存 = b.UnitInStock,
                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                        路徑 = b.CoverPath,
                        詳細資料 = b.Introduction,
                        作者介紹 = b.AboutAuthor,
                    };
            UpdateNewBook();
        }
        private void UpdateNewBook()
        {
            this.newBooks.Clear();
            foreach (var item in Query)
            {
                Book b = new Book
                {
                    BookID = item.書本ID,
                    BookTitle = item.書名,
                    PublicationDate = item.出版日期,
                    UnitPrice = item.定價,
                    ISBN = item.ISBN,
                    BindingMethod = item.封裝方法,
                    Pages = item.頁數,
                    Dimensions = item.規格,
                    UnitInStock = item.庫存,
                    CoverPath = item.路徑,
                    Introduction = item.詳細資料,
                    AboutAuthor = item.作者介紹,
                };
                Publisher p = new Publisher { PublisherName = item.出版社 };
                Language l = new Language { LanguageName = item.語言 };
                Category c = new Category { CategoryName = item.分類 };
                SubCategory sc = new SubCategory { SubCategoryName = item.子分類 };
                Translator t = new Translator { TranslatorName = item.譯者 };
                Painter pt = new Painter { PainterName = item.繪者 };
                Author a = new Author { AuthorName = item.作者 };

                CInformation newBook = new CInformation
                {
                    book = b,
                    publisher = p,
                    language = l,
                    category = c,
                    subCategory = sc,
                    author = a,
                    translator = t,
                    painter = pt,
                };
                EditBooksMoneySign(newBook);
                this.newBooks.Add(newBook);
            }
        }
        public void LoadAllData()
        {
            Query = from b in dbContent.Books
                    select new
                    {
                        書本ID = b.BookID,
                        書名 = b.BookTitle,
                        ISBN = b.ISBN,
                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                        出版社 = b.Publisher.PublisherName,
                        出版日期 = b.PublicationDate,
                        語言 = b.Language.LanguageName,
                        定價 = b.UnitPrice,
                        封裝方法 = b.BindingMethod,
                        頁數 = b.Pages,
                        規格 = b.Dimensions,
                        庫存 = b.UnitInStock,
                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                        路徑 = b.CoverPath,
                        詳細資料 = b.Introduction,
                        作者介紹 = b.AboutAuthor,
                    };
            UpdateNewBook();
        }
        public void LoadSearchTitle(string bookTtile)
        {
            Query = from b in dbContent.Books
                                    where b.BookTitle.Contains(bookTtile)
                                    select new
                                    {
                                        書本ID = b.BookID,
                                        書名 = b.BookTitle,
                                        ISBN = b.ISBN,
                                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                                        出版社 = b.Publisher.PublisherName,
                                        出版日期 = b.PublicationDate,
                                        語言 = b.Language.LanguageName,
                                        定價 = b.UnitPrice,
                                        封裝方法 = b.BindingMethod,
                                        頁數 = b.Pages,
                                        規格 = b.Dimensions,
                                        庫存 = b.UnitInStock,
                                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                                        路徑 = b.CoverPath,
                                        詳細資料 = b.Introduction,
                                        作者介紹 = b.AboutAuthor,
                                    };
            UpdateNewBook();
        }
        public void LoadSearchPublisherName(string publisherName)
        {
            Query = from b in dbContent.Books
                                    where b.Publisher.PublisherName == publisherName
                                    select new
                                    {
                                        書本ID = b.BookID,
                                        書名 = b.BookTitle,
                                        ISBN = b.ISBN,
                                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                                        出版社 = b.Publisher.PublisherName,
                                        出版日期 = b.PublicationDate,
                                        語言 = b.Language.LanguageName,
                                        定價 = b.UnitPrice,
                                        封裝方法 = b.BindingMethod,
                                        頁數 = b.Pages,
                                        規格 = b.Dimensions,
                                        庫存 = b.UnitInStock,
                                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                                        路徑 = b.CoverPath,
                                        詳細資料 = b.Introduction,
                                        作者介紹 = b.AboutAuthor,
                                    };
            UpdateNewBook();
        }
        public void LoadSearchLanguageName(string languageName)
        {
            Query = from b in dbContent.Books
                                    where b.Language.LanguageName == languageName
                                    select new
                                    {
                                        書本ID = b.BookID,
                                        書名 = b.BookTitle,
                                        ISBN = b.ISBN,
                                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                                        出版社 = b.Publisher.PublisherName,
                                        出版日期 = b.PublicationDate,
                                        語言 = b.Language.LanguageName,
                                        定價 = b.UnitPrice,
                                        封裝方法 = b.BindingMethod,
                                        頁數 = b.Pages,
                                        規格 = b.Dimensions,
                                        庫存 = b.UnitInStock,
                                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                                        路徑 = b.CoverPath,
                                        詳細資料 = b.Introduction,
                                        作者介紹 = b.AboutAuthor,
                                    };
            UpdateNewBook();
        }
        public void LoadSearchISBN(string isbn)
        {
            Query = from b in dbContent.Books
                                    where b.ISBN == isbn
                                    select new
                                    {
                                        書本ID = b.BookID,
                                        書名 = b.BookTitle,
                                        ISBN = b.ISBN,
                                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                                        出版社 = b.Publisher.PublisherName,
                                        出版日期 = b.PublicationDate,
                                        語言 = b.Language.LanguageName,
                                        定價 = b.UnitPrice,
                                        封裝方法 = b.BindingMethod,
                                        頁數 = b.Pages,
                                        規格 = b.Dimensions,
                                        庫存 = b.UnitInStock,
                                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                                        路徑 = b.CoverPath,
                                        詳細資料 = b.Introduction,
                                        作者介紹 = b.AboutAuthor,
                                    };
            UpdateNewBook();
        }
        public void LoadSearchBindingMethod(string bindingMethod)
        {
            Query = from b in dbContent.Books
                                    where b.BindingMethod == bindingMethod
                                    select new
                                    {
                                        書本ID = b.BookID,
                                        書名 = b.BookTitle,
                                        ISBN = b.ISBN,
                                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                                        出版社 = b.Publisher.PublisherName,
                                        出版日期 = b.PublicationDate,
                                        語言 = b.Language.LanguageName,
                                        定價 = b.UnitPrice,
                                        封裝方法 = b.BindingMethod,
                                        頁數 = b.Pages,
                                        規格 = b.Dimensions,
                                        庫存 = b.UnitInStock,
                                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                                        路徑 = b.CoverPath,
                                        詳細資料 = b.Introduction,
                                        作者介紹 = b.AboutAuthor,
                                    };
            UpdateNewBook();
        }
        public void LoadSearchRangePublicationDate(System.DateTime timeFront, System.DateTime timeBack)
        {
            Query = from b in dbContent.Books
                                    where b.PublicationDate >= timeFront && b.PublicationDate <= timeBack
                                    orderby b.PublicationDate
                                    select new
                                    {
                                        書本ID = b.BookID,
                                        書名 = b.BookTitle,
                                        ISBN = b.ISBN,
                                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                                        出版社 = b.Publisher.PublisherName,
                                        出版日期 = b.PublicationDate,
                                        語言 = b.Language.LanguageName,
                                        定價 = b.UnitPrice,
                                        封裝方法 = b.BindingMethod,
                                        頁數 = b.Pages,
                                        規格 = b.Dimensions,
                                        庫存 = b.UnitInStock,
                                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                                        路徑 = b.CoverPath,
                                        詳細資料 = b.Introduction,
                                        作者介紹 = b.AboutAuthor,
                                    };
            UpdateNewBook();
        }
        public void LoadSearchRangeUnitPrice(string front,string back)
        {
            int frontPrice = int.Parse(front);
            int backPrice = int.Parse(back);
            Query = from b in dbContent.Books
                                    where b.UnitPrice >= frontPrice && b.UnitPrice <= backPrice
                                    orderby b.UnitPrice
                                    select new
                                    {
                                        書本ID = b.BookID,
                                        書名 = b.BookTitle,
                                        ISBN = b.ISBN,
                                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                                        出版社 = b.Publisher.PublisherName,
                                        出版日期 = b.PublicationDate,
                                        語言 = b.Language.LanguageName,
                                        定價 = b.UnitPrice,
                                        封裝方法 = b.BindingMethod,
                                        頁數 = b.Pages,
                                        規格 = b.Dimensions,
                                        庫存 = b.UnitInStock,
                                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                                        路徑 = b.CoverPath,
                                        詳細資料 = b.Introduction,
                                        作者介紹 = b.AboutAuthor,
                                    };
            UpdateNewBook();
        }


        public void LoadSearchRangeUnitInStock(string front, string back)
        {
            int frontStock = int.Parse(front);
            int backStock = int.Parse(back);
            Query = from b in dbContent.Books
                                    where b.UnitInStock >= frontStock && b.UnitInStock <= backStock
                                    orderby b.UnitInStock
                                    select new
                                    {
                                        書本ID = b.BookID,
                                        書名 = b.BookTitle,
                                        ISBN = b.ISBN,
                                        作者 = b.AuthorDetails.Select(x => x.Author.AuthorName).FirstOrDefault(),
                                        譯者 = b.TranslatorDetails.Select(x => x.Translator.TranslatorName).FirstOrDefault(),
                                        繪者 = b.PainterDetails.Select(x => x.Painter.PainterName).FirstOrDefault(),
                                        出版社 = b.Publisher.PublisherName,
                                        出版日期 = b.PublicationDate,
                                        語言 = b.Language.LanguageName,
                                        定價 = b.UnitPrice,
                                        封裝方法 = b.BindingMethod,
                                        頁數 = b.Pages,
                                        規格 = b.Dimensions,
                                        庫存 = b.UnitInStock,
                                        分類 = b.CategoryDetails.Select(x => x.SubCategory.Category.CategoryName).FirstOrDefault(),
                                        子分類 = b.CategoryDetails.Select(x => x.SubCategory.SubCategoryName).FirstOrDefault(),
                                        路徑 = b.CoverPath,
                                        詳細資料 = b.Introduction,
                                        作者介紹 = b.AboutAuthor,
                                    };
            UpdateNewBook();
           
        }
        public void SetNewCoverCount()
        {
            string path = Directory.GetCurrentDirectory();
            string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\cover\new"));
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(dirPath);
            this.NewCoverCount = dir.GetFiles().Length;
        }
        public void AfterBrowse(PictureBox picture)
        {
            this.NewCoverCount += 1;
            string path = Directory.GetCurrentDirectory();
            string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\cover\new"));
            string fileName = $@"{dirPath}/{this.NewCoverCount}.png";
            picture.Image.Save(fileName, ImageFormat.Png);
        }

        public void InsertBook(string BookTitle,
                string AboutAuthor,
                string PublisherName,
                string Author,
                string Translator,
                string Painter,
                string PublicationDate,
                string Pages,
                string Introduction,
                string ISBN,
                string Dimensions,
                string LanguageName,
                string Category,
                string Subcategory,
                string BindingMethod,
                string UnitPrice,
                string UnitInStock,
                string CoverPath)
        {
                Book b = new Book
                {
                    BookTitle = BookTitle,
                    AboutAuthor = AboutAuthor,
                    PublicationDate = Convert.ToDateTime(PublicationDate),
                    UnitPrice = decimal.Parse(UnitPrice),
                    Introduction = Introduction,
                    ISBN = ISBN,
                    BindingMethod = BindingMethod,
                    Pages = Pages,
                    Dimensions = Dimensions,
                    UnitInStock = int.Parse(UnitInStock),
                    CoverPath = CoverPath,
                };
                Author a = new Author
                {
                    AuthorName = Author,
                };
                Publisher p = new Publisher
                {
                    PublisherName = PublisherName,
                };
                Category c = new Category
                {
                    CategoryName = Category,
                };
                SubCategory sc = new SubCategory
                {
                    SubCategoryName = Subcategory,
                };
                Painter pt = new Painter
                {
                    PainterName = Painter,
                };
                Translator t = new Translator
                {
                    TranslatorName = Translator,
                };
                Language l = new Language
                {
                    LanguageName = LanguageName,
                };
                CInformation newBook = new CInformation
                {
                    book = b,
                    publisher = p,
                    language = l,
                    translator = t,
                    category = c,
                    subCategory = sc,
                    author = a,
                    painter = pt,
                };
                var pID = dbContent.Publishers.Where(x => x.PublisherName == PublisherName).FirstOrDefault();
                b.PublisherID = pID.PublisherID;
                var lID = dbContent.Languages.Where(x => x.LanguageName == LanguageName).FirstOrDefault();
                b.LanguageID = lID.LanguageID;
                dbContent.Books.Add(b);
                dbContent.SaveChanges();

                var BookID = b.BookID;
                var aID = dbContent.Authors.Where(x => x.AuthorName == Author).FirstOrDefault();
                if (aID != null)
                {
                    AuthorDetail ad = new AuthorDetail
                    {
                        AuthorID = aID.AuthorID,
                        BookID = BookID,
                    };
                    dbContent.AuthorDetails.Add(ad);
                }
                var tID = dbContent.Translators.Where(x => x.TranslatorName == Translator).FirstOrDefault();
                if (tID != null)
                {
                    TranslatorDetail td = new TranslatorDetail
                    {
                        TranslatorID = tID.TranslatorID,
                        BookID = BookID,
                    };
                    dbContent.TranslatorDetails.Add(td);
                }
                var ptID = dbContent.Painters.Where(x => x.PainterName == Painter).FirstOrDefault();
                if (ptID != null)
                {
                    PainterDetail pd = new PainterDetail
                    {
                        PainterID = ptID.PainterID,
                        BookID = BookID,
                    };
                    dbContent.PainterDetails.Add(pd);
                }
                if (Subcategory == "")
                {
                    var cID = dbContent.Categories.Where(x => x.CategoryName == Category).FirstOrDefault();
                    var scID = dbContent.SubCategories.Where(x => x.CategoryID == cID.CategoryID).FirstOrDefault();
                    CategoryDetail cd = new CategoryDetail
                    {
                        BookID = BookID,
                        SubCategoryID = scID.SubCategoryID,
                    };
                    dbContent.CategoryDetails.Add(cd);
                    dbContent.SaveChanges();
                }
                else
                {
                    var scID = dbContent.SubCategories.Where(x => x.SubCategoryName == Subcategory).FirstOrDefault();
                    if (scID != null)
                    {
                        CategoryDetail cd = new CategoryDetail
                        {
                            BookID = BookID,
                            SubCategoryID = scID.SubCategoryID,
                        };
                        dbContent.CategoryDetails.Add(cd);
                        dbContent.SaveChanges();
                    }
                }

                this.newBooks.Add(newBook);
                MessageBox.Show("新增成功");
        }
        public void DeleteBook(int deleteID)
        {
            var authorDetail = (from ad in dbContent.AuthorDetails
                                where ad.BookID == deleteID
                                select ad).FirstOrDefault();
            if(authorDetail != null)
            {
                dbContent.AuthorDetails.Remove(authorDetail);
            }

            var translatorDetail = (from td in dbContent.TranslatorDetails
                                where td.BookID == deleteID
                                select td).FirstOrDefault();
            if(translatorDetail != null)
            {
                dbContent.TranslatorDetails.Remove(translatorDetail);
            }

            var painterDetail = (from pd in dbContent.PainterDetails
                                    where pd.BookID == deleteID
                                    select pd).FirstOrDefault();
            if(painterDetail != null)
            {
                dbContent.PainterDetails.Remove(painterDetail);
            }

            var categoryDetail = (from cd in dbContent.CategoryDetails
                                where cd.BookID == deleteID
                                select cd).FirstOrDefault();
            if(categoryDetail != null)
            {
                dbContent.CategoryDetails.Remove(categoryDetail);
            }

            var book = (from b in dbContent.Books
                        where b.BookID == deleteID
                        select b).FirstOrDefault();
            dbContent.Books.Remove(book);

            dbContent.SaveChanges();
            MessageBox.Show("刪除成功");
        }
        public void EditBook(int updateID,
                                string BookTitle,
                                string AboutAuthor,
                                string PublisherName,
                                string Author,
                                string Translator,
                                string Painter,
                                string PublicationDate,
                                string Pages,
                                string Introduction,
                                string ISBN,
                                string Dimensions,
                                string LanguageName,
                                string Category,
                                string Subcategory,
                                string BindingMethod,
                                string UnitPrice,
                                string UnitInStock,
                                string CoverPath)
        {
            //newBooks[updateID].book.BookTitle = BookTitle;
            //newBooks[updateID].book.AboutAuthor = AboutAuthor;
            //newBooks[updateID].publisher.PublisherName = PublisherName;
            //newBooks[updateID].author.AuthorName = Author;
            //newBooks[updateID].translator.TranslatorName = Translator;
            //newBooks[updateID].painter.PainterName = Painter;
            //newBooks[updateID].book.PublicationDate = Convert.ToDateTime(PublicationDate);
            //newBooks[updateID].book.Pages = Pages;
            //newBooks[updateID].book.Introduction = Introduction;
            //newBooks[updateID].book.ISBN = ISBN;
            //newBooks[updateID].book.Dimensions = Dimensions;
            //newBooks[updateID].category.CategoryName = Category;
            //newBooks[updateID].subCategory.SubCategoryName = Subcategory;
            //newBooks[updateID].book.BindingMethod = BindingMethod;
            //newBooks[updateID].book.UnitPrice = decimal.Parse(UnitPrice);
            //newBooks[updateID].book.UnitInStock = int.Parse(UnitInStock);
            //newBooks[updateID].book.CoverPath = CoverPath;
            var editCell = dbContent.Books.Where(x => x.BookID == updateID).FirstOrDefault();
            if (editCell != null)
            {
                editCell.BookTitle = BookTitle;
                editCell.AboutAuthor = AboutAuthor;
                editCell.PublicationDate = Convert.ToDateTime(PublicationDate);
                editCell.Pages = Pages;
                editCell.Introduction = Introduction;
                editCell.ISBN = ISBN;
                editCell.Dimensions = Dimensions;
                editCell.BindingMethod = BindingMethod;
                editCell.UnitPrice = decimal.Parse(UnitPrice);
                editCell.UnitInStock = int.Parse(UnitInStock);
                editCell.CoverPath = CoverPath;

                var pID = dbContent.Publishers.Where(x => x.PublisherName == PublisherName).FirstOrDefault();
                //newBooks[updateID].book.PublisherID = pID.PublisherID;
                editCell.PublisherID = pID.PublisherID;

                var lID = dbContent.Languages.Where(x => x.LanguageName == LanguageName).FirstOrDefault();
                //newBooks[updateID].book.LanguageID = lID.LanguageID;
                editCell.LanguageID = lID.LanguageID;


                var aID = dbContent.Authors.Where(x => x.AuthorName == Author).FirstOrDefault();
                if (aID != null)
                {
                    var ad = dbContent.AuthorDetails.Where(x => x.BookID == updateID).FirstOrDefault();
                    if (ad != null)
                    {
                        ad.AuthorID = aID.AuthorID;
                    }
                    else
                    {
                        AuthorDetail newAd = new AuthorDetail
                        {
                            AuthorID = aID.AuthorID,
                            BookID = updateID,
                        };
                        dbContent.AuthorDetails.Add(newAd);
                    }
                }
                var tID = dbContent.Translators.Where(x => x.TranslatorName ==Translator).FirstOrDefault();
                if (tID != null)
                {
                    var td = dbContent.TranslatorDetails.Where(x => x.BookID == updateID).FirstOrDefault();
                    if(td != null)
                    {
                        td.TranslatorID = tID.TranslatorID;
                    }
                    else
                    {
                        TranslatorDetail newTd = new TranslatorDetail
                        {
                            TranslatorID = tID.TranslatorID,
                            BookID = updateID,
                        };
                        dbContent.TranslatorDetails.Add(newTd);
                    }
                }
                var ptID = dbContent.Painters.Where(x => x.PainterName == Painter).FirstOrDefault();
                if (ptID != null)
                {
                    var pd = dbContent.PainterDetails.Where(x => x.BookID == updateID).FirstOrDefault();
                    if (pd != null)
                    {
                        pd.PainterID = ptID.PainterID;
                    }
                    else
                    {
                        PainterDetail newPd = new PainterDetail
                        {
                            PainterID = ptID.PainterID,
                            BookID = updateID,
                        };
                        dbContent.PainterDetails.Add(newPd);
                    }
                }
                if (Subcategory == "")
                {
                    var c = dbContent.Categories.Where(x => x.CategoryName == Category).FirstOrDefault();
                    MessageBox.Show(c.CategoryID.ToString());
                    var sc = dbContent.SubCategories.Where(x => x.CategoryID == c.CategoryID).FirstOrDefault();
                    var cd = dbContent.CategoryDetails.Where(x => x.BookID == updateID).FirstOrDefault();
                    cd.SubCategoryID = sc.SubCategoryID;
                }
                else
                {
                    var scID = dbContent.SubCategories.Where(x => x.SubCategoryName == Subcategory).FirstOrDefault();
                    var cd = dbContent.CategoryDetails.Where(x => x.BookID == updateID).FirstOrDefault();
                    cd.SubCategoryID = scID.SubCategoryID;
                }
                dbContent.SaveChanges();
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("找不到值");
            }
        }

        public void LoadSearchCate(string category, string subcategory)
        {
            if (subcategory == "")
            {
                var bookIds = from c in dbContent.Categories
                              where c.CategoryName == category
                              join sc in dbContent.SubCategories on c.CategoryID equals sc.CategoryID
                              join cd in dbContent.CategoryDetails on sc.SubCategoryID equals cd.SubCategoryID
                              select cd.BookID;
                LoadDataByID(bookIds.ToList());
            }
            else
            {
                var bookIds = from sc in dbContent.SubCategories
                              where sc.SubCategoryName == subcategory
                              join cd in dbContent.CategoryDetails on sc.SubCategoryID equals cd.SubCategoryID
                              select cd.BookID;
                LoadDataByID(bookIds.ToList());
            }
        }
    }

}
