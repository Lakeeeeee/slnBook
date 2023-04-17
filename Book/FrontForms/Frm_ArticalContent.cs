using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Book.BackForms
{
    public partial class Frm_ArticalContent : Form
    {
        public Frm_ArticalContent()
        {
            InitializeComponent();
        }
        
        BookShopEntities3 dbContext = new BookShopEntities3();

        public Frm_ArticalContent(int id)
        {
            InitializeComponent();

            int aID = id;
            
            var q = dbContext.Articals.Where(a => a.ArticalID == aID);
            foreach (var g in q)
            {
                System.Windows.Forms.Label labTitle = new Label();
                this.Text = g.ArticalTitle;
                labTitle.Text = $"{g.ArticalTitle}\r\n";
                labTitle.Font = new System.Drawing.Font("標楷體", 28, FontStyle.Bold);
                labTitle.AutoSize = true;
                tableLayoutPanel1.Controls.Add(labTitle);
                labTitle.Dock = DockStyle.Fill;
                labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                System.Windows.Forms.Label labDate = new Label();
                labDate.Text = $"更新日期：{g.ArticalDate.ToString()}\r\n\r\n";
                labDate.Font = new System.Drawing.Font("Time New Roman", 12, FontStyle.Italic);
                labDate.ForeColor = Color.Gray;
                labDate.AutoSize = true;
                tableLayoutPanel1.Controls.Add(labDate);
                labDate.Dock = DockStyle.Fill;
                labDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                PictureBox pictureBox = new PictureBox();
                pictureBox.BorderStyle = BorderStyle.Fixed3D;
                pictureBox.Width = 600;
                pictureBox.Height = 200;
                if (g.ArticalPicture != null)
                {
                    byte[] bytes = g.ArticalPicture;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                    pictureBox.Image = Image.FromStream(ms);
                }
                else { pictureBox.Image = pictureBox.ErrorImage; }
                tableLayoutPanel1.Controls.Add(pictureBox);
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
              

                Label labAD = new Label();
                labAD.Text = $"\r\n\r\n{g.ArticalDescription}\r\n\r\n";
                labAD.Font = new System.Drawing.Font("標楷體", 16, FontStyle.Regular);
                labAD.AutoSize = true;
                tableLayoutPanel1.Controls.Add(labAD);
                var q2 = dbContext.ArticalToBookDetails.Where(d => d.ArticalID == g.ArticalID).Select(d => new
                {
                    d.Book.BookTitle,
                    d.Book.ISBN,
                    d.Book.UnitPrice,
                    d.Book.Introduction,
                    d.Book.CoverPath,
                    d.Book.BookID,
                });

                foreach (var d in q2)
                {
                    PictureBox picBook = new PictureBox();
                    picBook.BorderStyle = BorderStyle.Fixed3D;
                    picBook.Width = 120;
                    picBook.Height = 150;
                    if (d.CoverPath != null)
                    {
                        string path = Directory.GetCurrentDirectory();
                        string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
                        string imgPath = "";
                        imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"{d.CoverPath}"));
                        picBook.Image = System.Drawing.Image.FromFile(imgPath);
                    }
                    else { picBook.Image = pictureBox.ErrorImage; }
                    tableLayoutPanel1.Controls.Add(picBook);
                    picBook.SizeMode = PictureBoxSizeMode.Zoom;
                    picBook.Tag = d.BookID;
                    picBook.Click += PicBook_Click; 
                    var q3 = dbContext.AuthorDetails.Where(a => a.BookID == d.BookID).Select(a => new { a.Author.AuthorName });
                    string s = "";
                    foreach (var item in q3) {s += item.AuthorName + "\r\n\t";}

                    Label labBook = new Label();
                    labBook.Text = $"書名：{d.BookTitle}\r\n\n作者：{s}\nISBN：{d.ISBN}\r\n\n單價：{d.UnitPrice:c0}\r\n\n書本簡介：";
                    labBook.Font = new System.Drawing.Font("標楷體", 14, FontStyle.Regular);
                    labBook.AutoSize = true;
                    tableLayoutPanel1.Controls.Add(labBook);

                    System.Windows.Forms.TextBox box = new System.Windows.Forms.TextBox();
                    box.Text = $"    {d.Introduction}";
                    box.Font = new System.Drawing.Font("標楷體", 12, FontStyle.Regular);
                    box.ReadOnly = true;
                    box.Multiline = true;
                    box.TabStop = false;
                    box.Height = 100;
                    box.ScrollBars = ScrollBars.Vertical;
                    tableLayoutPanel1.Controls.Add(box);
                    box.Dock = DockStyle.Fill;
                    //空行區隔
                    Label lab= new Label();
                    tableLayoutPanel1.Controls.Add(lab);
                }
            }
        }

        private void PicBook_Click(object sender, EventArgs e)
        {
            int bID =(int) ((PictureBox)sender).Tag;
            Form_ShowBookInformation show = new Form_ShowBookInformation(bID);
            show.ShowDialog();
        }

        public Frm_ArticalContent(string at)
        {
            InitializeComponent();

            string AT = at;

            var q = dbContext.Articals.Where(a => a.ArticalTitle == AT);
            foreach (var g in q)
            {
                System.Windows.Forms.Label labTitle = new Label();
                this.Text = g.ArticalTitle;
                labTitle.Text = $"{g.ArticalTitle}\r\n";
                labTitle.Font = new System.Drawing.Font("標楷體", 28, FontStyle.Bold);
                labTitle.AutoSize = true;
                tableLayoutPanel1.Controls.Add(labTitle);
                labTitle.Dock = DockStyle.Fill;
                labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                System.Windows.Forms.Label labDate = new Label();
                labDate.Text = $"更新日期：{g.ArticalDate.ToString()}\r\n\r\n";
                labDate.Font = new System.Drawing.Font("Time New Roman", 12, FontStyle.Italic);
                labDate.ForeColor = Color.Gray;
                labDate.AutoSize = true;
                tableLayoutPanel1.Controls.Add(labDate);
                labDate.Dock = DockStyle.Fill;
                labDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                PictureBox pictureBox = new PictureBox();
                pictureBox.BorderStyle = BorderStyle.Fixed3D;
                pictureBox.Width = 600;
                pictureBox.Height = 200;
                if (g.ArticalPicture != null)
                {
                    byte[] bytes = g.ArticalPicture;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                    pictureBox.Image = Image.FromStream(ms);
                }
                else { pictureBox.Image = pictureBox.ErrorImage; }
                tableLayoutPanel1.Controls.Add(pictureBox);
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
             

                Label labAD = new Label();
                labAD.Text = $"\r\n\r\n{g.ArticalDescription}\r\n\r\n";
                labAD.Font = new System.Drawing.Font("標楷體", 16, FontStyle.Regular);
                labAD.AutoSize = true;
                tableLayoutPanel1.Controls.Add(labAD);
                var q2 = dbContext.ArticalToBookDetails.Where(d => d.ArticalID == g.ArticalID).Select(d => new
                {
                    d.Book.BookTitle,
                    d.Book.ISBN,
                    d.Book.UnitPrice,
                    d.Book.Introduction,
                    d.Book.CoverPath,
                    d.Book.BookID,
                });

                foreach (var d in q2)
                {
                    PictureBox picBook = new PictureBox();
                    picBook.BorderStyle = BorderStyle.Fixed3D;
                    picBook.Width = 120;
                    picBook.Height = 150;
                    if (d.CoverPath != null)
                    {
                        string path = Directory.GetCurrentDirectory();
                        string dirPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
                        string imgPath = "";
                        imgPath = Path.GetFullPath(Path.Combine(dirPath, $@"{d.CoverPath}"));
                        picBook.Image = System.Drawing.Image.FromFile(imgPath);
                    }
                    else { picBook.Image = pictureBox.ErrorImage; }
                    tableLayoutPanel1.Controls.Add(picBook);
                    picBook.SizeMode = PictureBoxSizeMode.Zoom;
                    picBook.Tag = d.BookID;
                    picBook.Click += PicBook_Click;

                    var q3 = dbContext.AuthorDetails.Where(a => a.BookID == d.BookID).Select(a => new { a.Author.AuthorName });
                    string s="";
                    foreach (var item in q3)
                    {
                        s += item.AuthorName+"\r\n\t";
                    }

                    Label labBook = new Label();
                    labBook.Text = $"書名：{d.BookTitle}\r\n\n作者：{s}\nISBN：{d.ISBN}\r\n\n單價：{d.UnitPrice:c0}\r\n\n書本簡介：";
                    labBook.Font = new System.Drawing.Font("標楷體", 14, FontStyle.Regular);
                    labBook.AutoSize = true;
                    tableLayoutPanel1.Controls.Add(labBook);

                    System.Windows.Forms.TextBox box = new System.Windows.Forms.TextBox();
                    box.Text = $"    {d.Introduction}";
                    box.Font = new System.Drawing.Font("標楷體", 12, FontStyle.Regular);
                    box.ReadOnly = true;
                    box.Multiline = true;
                    box.TabStop = false;
                    box.Height = 100;
                    box.ScrollBars = ScrollBars.Vertical;
                    tableLayoutPanel1.Controls.Add(box);
                    box.Dock = DockStyle.Fill;
                    //空行區隔
                    Label lab = new Label();
                    tableLayoutPanel1.Controls.Add(lab);
                }
            }
        }
    }
}
