using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookStoreContracts.Contracts;
using System.Data;

namespace EBookStoreDAL.Interface
{
    public interface IBookDAL
    {
        List<Book> GetBookDetails();
        List<BookPurchase> GetBookPurchaseDetails(BookPurchase bookPurchase);
        String SaveBookDetails(DataTable emp_AppraisalTable);
    }
}
