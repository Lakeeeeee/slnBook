using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book.BackForms
{
    public partial class Frm_CategoryManage : Form
    {
        public Frm_CategoryManage()
        {
            InitializeComponent();
            comboxCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Frm_CategoryManage_Load(object sender, EventArgs e)
        {
            getCategory();
            getCategoryDetail();
            getSubCategory();
        }
        BookShopEntities3 BScontect = new BookShopEntities3();
        private void getCategoryDetail()//讀取全部主分類明細表單
        {
            var q = from c in BScontect.CategoryDetails
                    select new
                    {
                        書籍分類明細編號 = c.CategoryDetailID,
                        書籍編號 = c.BookID,
                        書籍子分類編號 = c.SubCategoryID,
                    };
            dGVCategoryDetail.DataSource = q.ToList();
        }

        private void getCategory()//讀取全部主分類表單
        {
            var q = from c in BScontect.Categories
                    select new
                    {
                        書籍主分類編號 = c.CategoryID,
                        書籍主分類名稱 = c.CategoryName
                    };
            dGVCategory.DataSource = q.ToList();   
        }
        private void getSubCategory()//讀取子分類全部表單
        {
            var q = from c in BScontect.SubCategories
                    select new
                    {
                        書籍子分類編號 = c.SubCategoryID,
                        書籍主分類編號 = c.CategoryID,
                        書籍子分類名稱 = c.SubCategoryName
                    };
            dGVSubCategory.DataSource = q.ToList();
            comboxCategoryID.Items.Clear();
            foreach (var item in q)
            {
                comboxCategoryID.Items.Add(item.書籍主分類編號);
            }
            
        }

        private void btInsert_Click(object sender, EventArgs e)//主分類新增功能
        {
            string newCategoryName = txtCategoryName.Text.Trim(); // 去除前後空白
            bool categoryExists = BScontect.Categories.Any(c => c.CategoryName == newCategoryName);
            if (categoryExists)
            {
                MessageBox.Show("已經存在相同名稱的分類");
            }
            else
            {
                try
                {
                    Category cat = new Category()
                    {
                        CategoryName = newCategoryName
                    };
                    BScontect.Categories.Add(cat);
                    BScontect.SaveChanges();
                    MessageBox.Show("新增成功");
                    getCategory();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dGVCategory_CellClick(object sender, DataGridViewCellEventArgs e)//將主分類選擇的值輸入編輯欄位
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dGVCategory.Rows[e.RowIndex];
                // 將選擇的值輸出到textbutton控制項中
                txtCategoryID.Text = row.Cells["書籍主分類編號"]?.Value?.ToString() ?? "";
                txtCategoryName.Text = row.Cells["書籍主分類名稱"]?.Value?.ToString() ?? "";
                getSubCategorySelect();
            }
        }

        private void getSubCategorySelect()
        {
            int selectedCategoryID = int.Parse(txtCategoryID.Text);
            var q = from c in BScontect.SubCategories
                    where c.CategoryID == selectedCategoryID
                    select new
                    {
                        書籍子分類編號=c.SubCategoryID,
                        書籍主分類編號 = c.CategoryID,
                        書籍子分類名稱 = c.SubCategoryName
                    };
            dGVSubCategory.DataSource = q.ToList();
            foreach (var item in q)
            {
                comboxCategoryID.Items.Add(item.書籍主分類編號);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryid;
                if (!int.TryParse(txtCategoryID.Text, out categoryid))
                {
                    MessageBox.Show("類別編號必須為數字");
                    return;
                }
                var cate = BScontect.Categories.Where(p => p.CategoryID == categoryid).FirstOrDefault();
                cate.CategoryName = txtCategoryName.Text;
                BScontect.SaveChanges();
                MessageBox.Show("修改成功");
                getCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dGVCategory.SelectedRows.Count == 1)
                {
                    int catID = (int)dGVCategory.SelectedRows[0].Cells["書籍主分類編號"].Value;
                    var cat = BScontect.Categories.Where(p => p.CategoryID == catID).FirstOrDefault();
                    BScontect.Categories.Remove(cat);
                    BScontect.SaveChanges();
                    getCategory();
                }
                else
                {
                    MessageBox.Show("請選擇要刪除的主分類");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategoryID.Clear();
            txtCategoryName.Clear();
            dGVCategory.ClearSelection();
            dGVSubCategory.DataSource = null;
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            txtCategoryName.Text = "其他";
        }

        private void btnSubRead_Click(object sender, EventArgs e)
        {
            comboxCategoryID.Items.Clear();
            txtSubCategoryName.Clear();
            getSubCategory();
        }
  
        private void btnSubAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 取得選擇的主分類編號
                if (comboxCategoryID.SelectedIndex == -1)
                {
                    MessageBox.Show("請選擇一個主分類");
                    return;
                }
                
                // 檢查是否已經存在相同名稱的子分類
                bool isDuplicate = BScontect.SubCategories.Any(s => s.SubCategoryName == txtSubCategoryName.Text);
                if (isDuplicate)
                {
                    MessageBox.Show("已經存在相同名稱的子分類");
                }
                else
                {
                    SubCategory sub = new SubCategory()
                    {
                        CategoryID = (int)comboxCategoryID.SelectedItem,
                        SubCategoryName = txtSubCategoryName.Text
                    };
                    BScontect.SubCategories.Add(sub);
                    BScontect.SaveChanges();
                    getSubCategory();
                    getCategoryDetail();
                    MessageBox.Show("新增成功");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dGVSubCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dGVSubCategory.Rows[e.RowIndex];
                comboxCategoryID.Items.Clear();
                // 將選擇的值輸出到textbutton控制項中
                comboxCategoryID.Items.Add(row.Cells["書籍主分類編號"].Value.ToString()) ;
                comboxCategoryID.SelectedItem = row.Cells["書籍主分類編號"].Value.ToString();
                txtSubCategoryName.Text = row.Cells["書籍子分類名稱"].Value ?.ToString() ?? "";
                getCategoryDetail();
            }
        }
        private void btnSunUp_Click(object sender, EventArgs e)
        {
            string newSubCategoryName = txtSubCategoryName.Text.Trim(); // 去除前後空白
            bool SubcategoryExists = BScontect.SubCategories.Any(c => c.SubCategoryName == newSubCategoryName);
            if (SubcategoryExists)
            {
                MessageBox.Show("已經存在相同名稱的分類");
            }
            else
            {
                try
                {
                    if (dGVSubCategory.SelectedRows.Count <= 0)// 確認選擇了要修改的子分類
                    {
                        MessageBox.Show("請選擇要修改的子分類");
                        return;
                    }
                    // 從資料庫中取得要修改的物件
                    int subCategoryId = (int)dGVSubCategory.SelectedRows[0].Cells["書籍子分類編號"].Value;
                    var subCategory = BScontect.SubCategories.Where(p => p.SubCategoryID == subCategoryId).FirstOrDefault();
                    subCategory.SubCategoryName = newSubCategoryName;
                    subCategory.CategoryID = int.Parse(comboxCategoryID.SelectedItem.ToString());
                    BScontect.SaveChanges();
                    MessageBox.Show("修改成功");
                    getSubCategory();
                    getCategoryDetail();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSubDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dGVSubCategory.SelectedRows.Count == 1)
                {
                    int subID = (int)dGVSubCategory.SelectedRows[0].Cells["書籍子分類編號"].Value;
                    var sub = BScontect.SubCategories.Where(p => p.SubCategoryID == subID).FirstOrDefault();
                    BScontect.SubCategories.Remove(sub);
                    BScontect.SaveChanges();
                    getSubCategory();
                    getCategoryDetail();
                }
                else
                {
                    MessageBox.Show("請選擇要刪除的子分類");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSubClear_Click(object sender, EventArgs e)
        {
            comboxCategoryID.Items.Clear();
            getSubCategory();
            txtSubCategoryName.Clear();
            dGVSubCategory.DataSource = null;
            dGVSubCategory.ClearSelection();
        }
        private void btnSubDemo_Click(object sender, EventArgs e)
        {
            comboxCategoryID.Items.Add(26);
            comboxCategoryID.SelectedItem = 26;
            txtSubCategoryName.Text = "點心";
        }
    }
}
