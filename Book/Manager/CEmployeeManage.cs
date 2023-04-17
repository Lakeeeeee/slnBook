using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Book.BackForms
{
    public class CEmployeeManage
    {
        List<CEmployee> _list = new List<CEmployee>();
        
        public CEmployeeManage()
        {
            loadData();
        }

        private void loadData()
        {
            CEmployee x = new CEmployee();
            x.employeeID = 951753;
            x.password = "qaz951";
            x.title = "管理者";
            _list.Add(x);
        }

        public CEmployee queryByAcount(int acount)
        {
            foreach (CEmployee e in _list)
            {
                if (e.employeeID == acount)
                {                   
                    return e;
                }                
            }
            return null;
        }
    }
}
