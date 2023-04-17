using Book.BackForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book.FrontForms
{
    public partial class Frm_ArticalArea : Form
    {
        public Frm_ArticalArea()
        {
            InitializeComponent();
            var AT = dbContext.Articals.Select(a => a.ArticalTitle);
          listBox2.DataSource= AT.ToList();
        }
        BookShopEntities3 dbContext = new BookShopEntities3();
        private void Frm_ArticalArea_Load(object sender, EventArgs e)
        {
            var Apic = dbContext.Articals;
            foreach (var g in Apic)
            {
                PictureBox p = new PictureBox();
                p.BorderStyle = BorderStyle.Fixed3D;
                p.BackColor = Color.White;
                p.Width = 200;
                p.Height = 150;
                if (g.ArticalPicture != null)
                {
                    byte[] bytes = g.ArticalPicture;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                    p.Image = Image.FromStream(ms);
                }
                else { p.Image = p.ErrorImage; }
                p.Tag = g.ArticalID;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                p.Click += P_Click;

                this.flowLayoutPanel1.Controls.Add(p);
            }
            listBox2.SelectedIndexChanged += ListBox2_SelectedIndexChanged;
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AT =( (ListBox)sender).Text;
            Frm_ArticalContent frm = new Frm_ArticalContent(AT);
            frm.Show();
        }

        private void P_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int aID = (int)((PictureBox)sender).Tag;

            var q = dbContext.Articals.Where(p => p.ArticalID == aID);
            int i = 1;
            foreach (var g in q)
            {
                textBox1.Text = g.ArticalTitle;
                var q2 = dbContext.ArticalToBookDetails.Where(d => d.ArticalID == g.ArticalID).Select(d => new { d.Book.BookTitle });
                foreach (var g2 in q2)
                {
                    string s2 = $"{i}. {g2.BookTitle}";
                    listBox1.Items.Add(s2);
                    i++;
                }
            }

            Frm_ArticalContent frm = new Frm_ArticalContent(aID);

            frm.Show();
        }

   
    }
}
