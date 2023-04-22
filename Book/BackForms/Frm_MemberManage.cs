using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Book.BackForms
{
    public partial class Frm_MemberManage : Form
    {
        public Frm_MemberManage()
        {
            InitializeComponent();
            refreshMem();
            getCStatue();
        }
        BookShopEntities3 BScontent = new BookShopEntities3();
        int memberID;
        private void Frm_MemberManage_Load(object sender, EventArgs e)
        {
            List<string> payment = BScontent.Payments.Select(x => x.PaymentName).ToList();
            foreach (string item in payment)
            {
                this.comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void refreshMem()
        {
            var q = from m in BScontent.Members
                    select new
                    {
                        會員編號 = m.MemberID,
                        會員姓名 = m.MemberName,
                        累積消費 = m.CostAmount,
                        會員等級 = m.LevelID,
                        會員電子信箱 = m.MemberEmail,
                        會員出生年月日 = m.MemberBrithDate,
                        會員行動電話 = m.Memberphone,
                        會員地址 = m.MemberAddress,
                        付款方式 = m.Payment.PaymentName,
                    };


            dGV_mem.DataSource = q.ToList();
        }
        private void geteachCs(DataGridView dGV)
        {
            int site = dGV.SelectedCells[0].RowIndex;
            string x = dGV.Rows[site].Cells["會員編號"].Value.ToString();
            memberID = int.Parse(x);

            var q = BScontent.CustomerServices.Where(y => y.MemberID == memberID).Select(y => new
            {
                序號 = y.CRMID,
                會員編號 = y.MemberID,
                內容 = y.CContent,
                回覆 = y.ReplyContent,
                處理狀態 = y.Status.StatusName,
                更新日期 = y.UpdateDate,
                客戶滿意度 = y.Satisfaction

            });
            dGV_cs.DataSource = q.ToList();
        }
        private void geteachMem(DataGridView dGV)
        {
            int site = dGV.SelectedCells[0].RowIndex; string x = dGV.Rows[site].Cells["會員編號"].Value.ToString();
            memberID = int.Parse(x);

            var q = BScontent.Members.Where(y => y.MemberID == memberID).Select(y => y);

            this.textBox2.Text = q.Select(y => y.MemberEmail).FirstOrDefault().ToString();
            this.textBox3.Text = q.Select(y => y.MemberPassword).FirstOrDefault().ToString();
            this.textBox4.Text = q.Select(y => y.MemberName).FirstOrDefault().ToString();
            this.dateTimePicker1.Value = (DateTime)q.Select(y => y.MemberBrithDate).FirstOrDefault();
            this.textBox6.Text = q.Select(y => y.Memberphone).FirstOrDefault().ToString();
            this.textBox7.Text = q.Select(y => y.MemberAddress).FirstOrDefault().ToString();
            this.comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }
        private void getCStatue()
        {
            var q = BScontent.Status.Select(x=>x.StatusName);
            foreach (var x in q.ToList())
            {
                cB_csstatue.Items.Add(x);
                cB_updatestatu.Items.Add(x);
            }
            var q2 = BScontent.CustomerServices.Select(x => x.Satisfaction).Distinct();
            foreach (var x in q2.ToList()) 
            { cB_satisfaction.Items.Add(x!=null? x.ToString():"無"); }
            this.cB_satisfaction.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btn_member_Click(object sender, EventArgs e)
        {
            refreshMem();
        }
        private void btn_cs_Click(object sender, EventArgs e)
        {
            dGV_cs.DataSource = BScontent.CustomerServices.Select(x => new
            {
                序號 = x.CRMID,
                會員編號 = x.MemberID,
                內容 = x.CContent,
                回覆 = x.ReplyContent,
                處理狀態 = x.Status.StatusName,
                更新日期 = x.UpdateDate,
                客戶滿意度 = x.Satisfaction
            }).ToList();
        }
        private void cB_csstatue_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = BScontent.CustomerServices.Where(c => c.Status.StatusName == cB_csstatue.Text).
                    Select(c => new
                    {
                        序號 = c.CRMID,
                        會員編號 = c.MemberID,
                        內容 = c.CContent,
                        回覆 = c.ReplyContent,
                        處理狀態 = c.Status.StatusName,
                        更新日期 = c.UpdateDate,
                        客戶滿意度 = c.Satisfaction
                    });

            this.dGV_cs.DataSource = q.ToList();
        }
        private void cB_satisfaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0; bool check = int.TryParse(cB_satisfaction.Text, out x);

            if (check)
            {
                var q = BScontent.CustomerServices.Where(c => c.Satisfaction == x).Select(c => new
                        {
                            序號 = c.CRMID,
                            會員編號 = c.MemberID,
                            內容 = c.CContent,
                            回覆 = c.ReplyContent,
                            處理狀態 = c.Status.StatusName,
                            更新日期 = c.UpdateDate,
                            客戶滿意度 = c.Satisfaction
                        });
                this.dGV_cs.DataSource = q.ToList();
            }
            else
            {
                var q = BScontent.CustomerServices.Where(c=> c.Satisfaction == null).Select(c=> new
                        {
                            序號 = c.CRMID,
                            會員編號 = c.MemberID,
                            內容 = c.CContent,
                            回覆 = c.ReplyContent,
                            處理狀態 = c.Status.StatusName,
                            更新日期 = c.UpdateDate,
                            客戶滿意度 = c.Satisfaction
                        });
                this.dGV_cs.DataSource = q.ToList();
            };
            
        }
        private void dGV_mem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            geteachCs(this.dGV_mem);
            geteachMem(dGV_mem);
        }
        private void btn_statuesupdate_Click(object sender, EventArgs e)
        {
            int site = dGV_cs.SelectedCells[0].RowIndex;
            string index = dGV_cs.Rows[site].Cells[0].Value.ToString();
            var updatetool = BScontent.CustomerServices.Find(int.Parse(index));
            var q = BScontent.Status.Where(x => x.StatusName == cB_updatestatu.Text).
                Select(x => x.StatusID).FirstOrDefault();
            updatetool.StatusID = q; updatetool.UpdateDate = DateTime.Now;

            BScontent.SaveChanges();
            MessageBox.Show("更新成功");
            geteachCs(this.dGV_cs);
        }
        private void btn_reply_Click(object sender, EventArgs e)
        {
            int site = dGV_cs.SelectedCells[0].RowIndex;
            string index = dGV_cs.Rows[site].Cells[0].Value.ToString();
            var updatetool = BScontent.CustomerServices.Find(int.Parse(index));
            updatetool.ReplyContent = textBox1.Text; updatetool.UpdateDate = DateTime.Now;

            BScontent.SaveChanges();
            MessageBox.Show("更新成功");
            geteachCs(this.dGV_cs);
            dGV_cs.CurrentCell = dGV_cs.Rows[site].Cells["處理狀態"];
        }
        private void btn_newmem_Click(object sender, EventArgs e)
        {
            int payid = BScontent.Payments.Where(x => x.PaymentName == comboBox1.Text).
                Select(x => x.PaymentID).FirstOrDefault();
            Member newMember = new Member()
            {
                MemberEmail = textBox2.Text,
                MemberPassword = textBox3.Text,
                MemberName = textBox4.Text,
                MemberBrithDate = (DateTime)this.dateTimePicker1.Value,
                Memberphone = textBox6.Text,
                MemberAddress = textBox7.Text,
                PaymentID = payid
            };
            Member check =BScontent.Members.Where(x => x.MemberEmail == newMember.MemberEmail).FirstOrDefault();
            if (check!=null)
            {
                MessageBox.Show("這個信箱已經註冊過");
            }
            else
            {
                BScontent.Members.Add(newMember);
                BScontent.SaveChanges();
                refreshMem();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int payid = BScontent.Payments.Where(x => x.PaymentName == comboBox1.Text).
                Select(x => x.PaymentID).FirstOrDefault();
            Member updateMember = BScontent.Members.Where(x => x.MemberEmail == textBox2.Text).FirstOrDefault();
            if (updateMember != null)
            {
                if (!string.IsNullOrEmpty(textBox3.Text)) { updateMember.MemberPassword = textBox3.Text; }
                if (!string.IsNullOrEmpty(textBox4.Text)) { updateMember.MemberName = textBox4.Text; }
                updateMember.MemberBrithDate = (DateTime)this.dateTimePicker1.Value;
                if (!string.IsNullOrEmpty(textBox6.Text)) { updateMember.Memberphone = textBox6.Text; } 
                if(!string.IsNullOrEmpty(textBox7.Text)){ updateMember.MemberAddress = textBox7.Text; }
                updateMember.PaymentID = payid;
                int newCostAmount;
                if (int.TryParse(tB_costAmount.Text, out newCostAmount))
                    updateMember.CostAmount = newCostAmount;
                else updateMember.CostAmount = updateMember.CostAmount;
                BScontent.SaveChanges(); refreshMem();
            }
            else
            {
                MessageBox.Show("請輸入完整資料");
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            int site = this.dGV_mem.SelectedCells[0].RowIndex;
            int delememid = int.Parse(this.dGV_mem.Rows[site].Cells["會員編號"].Value.ToString());
            var q2 = BScontent.OrderDetails.Where(x => x.Order.MemberID == delememid); //od o acd ca cp cs 
            var q3 = BScontent.Orders.Where(x => x.OrderID == delememid);
            var q4 = BScontent.ActionDetials.Where(x => x.MemberID == delememid);
            var q5 = BScontent.CollectedAuthors.Where(x => x.MemberID == delememid);
            var q6 = BScontent.CollectedPublishers.Where(x => x.MemberID == delememid);
            var q7 = BScontent.CustomerServices.Where(x => x.MemberID == delememid);
            var q8 = BScontent.Comments.Where(x => x.MemberID == delememid);
            var q = BScontent.Members.Find(delememid);
            foreach (Comment item in q8) { item.MemberID = null; }
            BScontent.OrderDetails.RemoveRange(q2); BScontent.Orders.RemoveRange(q3);
            BScontent.ActionDetials.RemoveRange(q4); BScontent.CollectedAuthors.RemoveRange(q5);
            BScontent.CollectedPublishers.RemoveRange(q6); BScontent.CustomerServices.RemoveRange(q7);
            BScontent.Members.Remove(q); MessageBox.Show("ok");
            BScontent.SaveChanges(); refreshMem();
        }

        private void btn_cssearch_Click(object sender, EventArgs e)
        {
            Member nameSearch = BScontent.Members.Where(x => x.MemberName == tB_search1.Text).FirstOrDefault();
            Member phoneSearch = BScontent.Members.Where(x => x.Memberphone == tB_search2.Text).FirstOrDefault();
            if (nameSearch != null && phoneSearch != null)
            {
                var target = BScontent.Members.Where(x => x.MemberName == tB_search1.Text && x.Memberphone == tB_search2.Text).
                    Select(x => new
                    {
                        會員編號 = x.MemberID, 會員姓名 = x.MemberName,
                        會員電子信箱 = x.MemberEmail, 會員出生年月日 = x.MemberBrithDate,
                        會員行動電話 = x.Memberphone, 會員地址 = x.MemberAddress,
                        付款方式 = x.Payment.PaymentName
                    });
                this.dGV_mem.DataSource = target.ToList();
            }
            else if (nameSearch != null)
            {
                var target = BScontent.Members.Where(x => x.MemberName == tB_search1.Text).Select(x => new
                {
                    會員編號 = x.MemberID,
                    會員姓名 = x.MemberName,
                    會員電子信箱 = x.MemberEmail,
                    會員出生年月日 = x.MemberBrithDate,
                    會員行動電話 = x.Memberphone,
                    會員地址 = x.MemberAddress,
                    付款方式 = x.Payment.PaymentName
                });
                this.dGV_mem.DataSource = target.ToList();
            }
            else if (phoneSearch != null)
            {
                var target = BScontent.Members.Where(x => x.Memberphone == tB_search2.Text).Select(x => new
                {
                    會員編號 = x.MemberID,
                    會員姓名 = x.MemberName,
                    會員電子信箱 = x.MemberEmail,
                    會員出生年月日 = x.MemberBrithDate,
                    會員行動電話 = x.Memberphone,
                    會員地址 = x.MemberAddress,
                    付款方式 = x.Payment.PaymentName
                });
                this.dGV_mem.DataSource = target.ToList();
            }
            else
            {
                MessageBox.Show("沒有資料");
            }
        }


    }
}
