//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Book
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoryDetail
    {
        public int CategoryDetailID { get; set; }
        public int BookID { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}