using Book.BackForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class CInformation
    {
        public Book book { get; set; }
        public Language language { get; set; }
        public Publisher publisher { get; set; }
        public Category category { get; set; }
        public SubCategory subCategory { get; set; }
        public Translator translator { get; set; }
        public Painter painter { get; set; }
        public Author author { get; set; }
    }
}
