using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test10.Class.Book
{
    //要標記是可以序列畫的
    [Serializable]
    //書本資訊
    //身為一本書該有的資訊
    public class BookInfo
    {
        //建構
        public BookInfo()
        {
            PageInfoList = new List<Image>();
        }

        //身為一個書本的基本資料
        public string BookName;
        public string BookProductor;
        public string BookISBN;
        public string BookMemo;
        //是不是成人向
        public bool isAdult = false;
        //書本的每一頁 : )
        public List<Image> PageInfoList;

        //書本的folderName
        public string folderName="Book01";

        //檢查是不是完整
        public bool CheckPageIsComplete()
        {
            if (PageInfoList != null)
            {
                if (PageInfoList.Count > 0)
                {
                    for (int i = 0; i < PageInfoList.Count; i++)
                    {
                        //if (PageInfoList[i].ImageFeature == null)
                        //    return false;
                        return true;
                    }
                }
            }
            return false;
        }

        //複製物件
        public BookInfo Clone()
        {
            BookInfo info = new BookInfo();
            info.BookName = BookName;
            info.BookProductor = BookProductor;
            info.BookISBN = BookISBN;
            info.BookMemo = BookMemo;
            info.isAdult = isAdult;
            info.folderName = folderName;
            //info.PageInfoList = new List<PageInfo>(PageInfoList);
            if (PageInfoList.Count>0)
            {
                for (int i = 0; i < PageInfoList.Count; i++)
                {
                    info.PageInfoList.Add(PageInfoList[i]);
                }
            }
            return info;
        }

        public void Copy(BookInfo info)
        {
            BookName=info.BookName ;
            BookProductor = info.BookProductor;
            BookISBN = info.BookISBN;
            BookMemo = info.BookMemo;
            isAdult = info.isAdult;
            folderName = info.folderName;
            //info.PageInfoList = new List<PageInfo>(PageInfoList);
            if (info.PageInfoList.Count > 0)
            {
                for (int i = 0; i < info.PageInfoList.Count; i++)
                {
                    PageInfoList.Add(info.PageInfoList[i]);
                }
            }
        }
    }
}
