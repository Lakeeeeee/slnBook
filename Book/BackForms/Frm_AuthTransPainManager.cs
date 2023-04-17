using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book.BackForms
{
    public partial class Frm_AuthTransPainManager : Form
    {
        BookShopEntities3 BScontent = new BookShopEntities3();
        //
        public Frm_AuthTransPainManager()
        {
            InitializeComponent();
            showGuyData();
            showDetailData();
        }

        private void showGuyData()
        {
            //讀入繪者
            var P = from p in this.BScontent.Painters
                    select new {繪者編號=p.PainterID,繪者名字=p.PainterName};
            this.dgvPi.DataSource= P.ToList();
            //讀入譯者
            var T = from t in this.BScontent.Translators
                    select new { 譯者編號=t.TranslatorID,譯者名字=t.TranslatorName};
            this.dataGridView3.DataSource=T.ToList();
            //讀入作者
            var A = from a in this.BScontent.Authors
                    select new { 作者編號=a.AuthorID,作者名字=a.AuthorName};
            this.dataGridView5.DataSource=A.ToList();
        }

        private void showDetailData()
        {
            //讀入繪者細節
            var PD = from pd in this.BScontent.PainterDetails
                     orderby pd.PainterID
                     select new { /*繪者清單編號=pd.PainterDetailID,*/繪者編號 = pd.PainterID, 繪者 = pd.Painter.PainterName, 作品編號 = pd.BookID, 書本名稱 = pd.Book.BookTitle };
            this.dgvPiDt.DataSource = PD.ToList();
            //讀入譯者細節
            var TD = from td in this.BScontent.TranslatorDetails
                     orderby td.TranslatorID
                     select new { /*譯者清單編號=td.TranslatorDetailID,*/譯者編號 = td.TranslatorID, 譯者 = td.Translator.TranslatorName, 作品編號 = td.BookID, 書本名稱 = td.Book.BookTitle };
            this.dataGridView4.DataSource = TD.ToList();
            //讀入作者細節
            var AD = from ad in this.BScontent.AuthorDetails
                     orderby ad.AuthorID
                     select new { /*作者清單編號=ad.AuthorDetailID,*/作者編號 = ad.AuthorID, 作者 = ad.Author.AuthorName, 作品編號 = ad.BookID, 書本名稱 = ad.Book.BookTitle };
            this.dataGridView6.DataSource = AD.ToList();
        }

        int transID;
        int authID;
        int paintID;

        private void senPainToDetail()
        {
            int cellvalue = dgvPi.SelectedCells[0].RowIndex;
            string PTD= dgvPi.Rows[cellvalue].Cells[0].Value.ToString();
            paintID=int.Parse(PTD);
            //
            var PD = from pd in this.BScontent.PainterDetails
                     where pd.PainterID == paintID
                     select new { 繪者編號 = pd.PainterID, 繪者 = pd.Painter.PainterName, 作品編號 = pd.BookID, 書本名稱 = pd.Book.BookTitle };
            //
            dgvPiDt.DataSource= PD.ToList();
        }

        private void sendAuthToDetail()
        {
            int cellvalue = dataGridView5.SelectedCells[0].RowIndex;
            string ATD = dataGridView5.Rows[cellvalue].Cells[0].Value.ToString();
            authID=int.Parse(ATD);
            //
            var AD = from ad in this.BScontent.AuthorDetails
                     where ad.AuthorID == authID
                     select new { 作者編號 = ad.AuthorID, 作者 = ad.Author.AuthorName, 作品編號 = ad.BookID, 書本名稱 = ad.Book.BookTitle };
            //
            dataGridView6.DataSource = AD.ToList();
        }

        private void sendTranToDetail()
        {
            try
            {
                int cellvalue = dataGridView3.SelectedCells[0].RowIndex;
                string TTD = dataGridView3.Rows[cellvalue].Cells[0].Value.ToString();
                transID = int.Parse(TTD);
                //
                var TD = from td in this.BScontent.TranslatorDetails
                         where td.TranslatorID == transID
                         select new { 譯者編號 = td.TranslatorID, 譯者 = td.Translator.TranslatorName, 作品編號 = td.BookID, 書本名稱 = td.Book.BookTitle };
                //
                dataGridView4.DataSource = TD.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPiInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Painter p = new Painter
                {
                    PainterName = txtPiName.Text,
                };
                this.BScontent.Painters.Add(p);
                this.BScontent.SaveChanges();
                MessageBox.Show("新增成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPiDel_Click(object sender, EventArgs e)
        {
            try
            {
                int painterID = int.Parse(txtPiID.Text);
                var painter = (from p in this.BScontent.Painters
                               where p.PainterID == painterID
                               select p).FirstOrDefault();
                //
                if (painter == null) return;
                this.BScontent.Painters.Remove(painter);
                this.BScontent.SaveChanges();
                MessageBox.Show("刪除成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPiUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int piid = int.Parse(txtPiID.Text);
                var paintername=(from pn in this.BScontent.Painters
                                 where pn.PainterID == piid
                                 select pn).FirstOrDefault();
                paintername.PainterName = txtPiName.Text;
                this.BScontent.SaveChanges();
                MessageBox.Show("修改成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            senPainToDetail();
            if (e.RowIndex >= 0) // 確認選取的不是欄位名稱列
            {
                var selectPainter = dgvPi.Rows[e.RowIndex];
                txtPiID.Text = selectPainter.Cells[0].Value.ToString();
                txtPiName.Text = selectPainter.Cells[1].Value.ToString();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sendTranToDetail();
            if (e.RowIndex >= 0) // 確認選取的不是欄位名稱列
            {
                var selectTrans = dataGridView3.Rows[e.RowIndex];
                textBox1.Text = selectTrans.Cells[0].Value.ToString();
                textBox2.Text = selectTrans.Cells[1].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Translator t = new Translator
                {
                    TranslatorName = textBox2.Text,
                };
                this.BScontent.Translators.Add(t);
                this.BScontent.SaveChanges();
                MessageBox.Show("新增成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int translatorID=int.Parse(textBox1.Text);
                var translator = (from t in this.BScontent.Translators
                                  where t.TranslatorID==translatorID
                                  select t).FirstOrDefault();
                if (translator == null) return;
                this.BScontent.Translators.Remove(translator);
                this.BScontent.SaveChanges();
                MessageBox.Show("刪除成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int tiid = int.Parse(textBox1.Text);
                var transname = (from t in this.BScontent.Translators
                                   where t.TranslatorID == tiid
                                 select t).FirstOrDefault();
                transname.TranslatorName = textBox2.Text;
                this.BScontent.SaveChanges();
                MessageBox.Show("修改成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Author a = new Author
                {
                    AuthorName = textBox4.Text,
                };
                this.BScontent.Authors.Add(a);
                this.BScontent.SaveChanges();
                MessageBox.Show("新增成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int authorID = int.Parse(textBox3.Text);
                var author = (from a in this.BScontent.Authors
                               where a.AuthorID == authorID
                              select a).FirstOrDefault();
                //
                if (author == null) return;
                this.BScontent.Authors.Remove(author);
                this.BScontent.SaveChanges();
                MessageBox.Show("刪除成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sendAuthToDetail();
            if (e.RowIndex >= 0) // 確認選取的不是欄位名稱列
            {
                var selectTrans = dataGridView5.Rows[e.RowIndex];
                textBox3.Text = selectTrans.Cells[0].Value.ToString();
                textBox4.Text = selectTrans.Cells[1].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int auid = int.Parse(textBox3.Text);
                var authorname = (from an in this.BScontent.Authors
                                   where an.AuthorID == auid
                                  select an).FirstOrDefault();
                authorname.AuthorName = textBox4.Text;
                this.BScontent.SaveChanges();
                MessageBox.Show("修改成功");
                showGuyData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            showDetailData();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            showDetailData();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            showDetailData();
        }
    }
}
