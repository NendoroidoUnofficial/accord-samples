using System;
using System.Collections.Generic;

namespace Nendoroido.Core.Domain.Book
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
