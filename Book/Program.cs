using Book.BackForms;
using Book.FrontForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book
{
    public static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Frm_ArticalArea());
            // Application.Run(new Frm_Member());
            //Application.Run(new Frm_MemberManage());
            //Application.Run(new Frm_ArticalManage());
            //Application.Run(new Frm_BookManage());
            //Application.Run(new Frm_BookShop());
            Application.Run(new Frm_Main());
            // Application.Run(new Frm_PublisherManage());

        }
    }
}
