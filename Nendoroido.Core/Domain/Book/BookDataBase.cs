using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test10.Class.Book
{
    //要標記是可以序列化的
    [Serializable]
    //存放所有書本
    public class BookDataBase
    {
        //建構
        public BookDataBase()
        {
            BookList = new List<BookInfo>();
        }
        public List<Book.BookInfo> BookList;

        
    }
}
