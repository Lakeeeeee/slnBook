using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book
{
    public class CMemberManager
    {
        public BookShopEntities3 dbContent  =new BookShopEntities3();
        public Member usingMember;
        public List<Order> usingMemOS;
        public List<CollectedAuthor> usingMemCARs;
        public List<CollectedPublisher> usingMemCPs;
        public List<ActionDetial> usingMemACDs;
        public List<CustomerService> usingMemCSs;
        public void loadMember(Member member)
        {
            usingMember = member; 
            usingMemOS = member.Orders.ToList(); 
            usingMemCARs = member.CollectedAuthors.ToList();
            usingMemCPs = member.CollectedPublishers.ToList();
            usingMemACDs = member.ActionDetials.ToList();
            usingMemCSs = member.CustomerServices.ToList();
        }
        public void loadDetailData(int orderid, DataGridView sender)
        {
            var q = from od in dbContent.OrderDetails
                    where od.OrderID == orderid
                    select new
                    {
                        商品名稱 = od.Book.BookTitle,
                        優惠價 = od.UnitPrice * (od.Book.Discount_Detail.Select(x => x.Discount.DiscountAmount).FirstOrDefault() ?? 1m),   //折扣需要有預設1
                        數量 = od.Quantity,
                        小計 = od.UnitPrice * od.Quantity * (od.Book.Discount_Detail.Select(x => x.Discount.DiscountAmount).FirstOrDefault() ?? 1m),
                        客戶名稱 = od.Order.Member.MemberName,
                        處理狀態 = od.Order.ShippingStatu.ShippingStatusName
                    };
            sender.DataSource = q.ToList();
        }

    }
}
