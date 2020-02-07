using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStoreContracts.Contracts
{
    public class BookPurchase : Book
    {

        public int UserID { set; get; }
        public int StatusID { set; get; }
        public Nullable<int> Rating { set; get; }
        public string Review { set; get; }
        public Nullable<int> CreatedBy { set; get; }
        public Nullable<DateTime> CreatedDate { set; get; }
        public Nullable<int> ModifiedBy { set; get; }
        public Nullable<DateTime> ModifiedDate { set; get; }
    }


}
