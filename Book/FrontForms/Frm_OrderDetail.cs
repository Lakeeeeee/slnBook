using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book.FrontForms
{
    public partial class Frm_OrderDetail : Form
    {
        public Frm_OrderDetail(Order selectedorder)
        {
            InitializeComponent();
            cmm.loadDetailData(selectedorder.OrderID, this.dGV_orderdetail);
        }
        BookShopEntities3 BScontent = new BookShopEntities3();
        CMemberManager cmm = new CMemberManager();

    }
}
