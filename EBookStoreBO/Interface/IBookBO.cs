using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookStoreContracts.Contracts;
using EBookStoreDAL.DAL;

namespace EBookStoreBO.Interface
{
    public interface IBookBO
    {
        List<Book> GetBookDetails();
        List<BookPurchase> GetBookPurchaseDetails(BookPurchase bookPurchase);
        string SaveBookDetails(BookPurchase[] bookPurchase);

    }
}
