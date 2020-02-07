using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStoreContracts.Contracts
{
    public class Book
    {
        public int BookID { set; get; }
        public string BookName { set; get; }
        public string BookDescription { set; get; }
        public Nullable<float> Price { set; get; }
        public string Author { set; get; }
        public bool IsActive { set; get; }

    }

}
