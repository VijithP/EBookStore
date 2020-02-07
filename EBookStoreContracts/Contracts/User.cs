using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStoreContracts.Contracts
{
    public class User
    {

        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }

    }
}
