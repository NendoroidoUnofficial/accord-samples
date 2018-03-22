using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace test10.Class.fileManager
{
    [Serializable()]
    //負責管理資料的
    class FileManager
    {
        //所有書本都存在這邊喔 : )
        static string rootFolder = "_db";
        //dbName
        static string dbName = "_database.db";
        //圖片後面要加上副檔名
        static string imageFileFormat = ".png";


        //取得root資料夾 的路徑 ，可以存取資料夾的內容
        public static string GetRootDictionaryPath()
        {
            return rootFolder;
        }

        //取得DB的位置
        public static string GetDBPath()
        {
            return rootFolder + "/" + dbName;
        }

        //取得某本書裡面的資料夾路徑
        public static string GetBookDictionaryPath(string folderName)
        {
            return rootFolder + "/" + folderName;
        }

        //取得某書本 裡面的某頁圖片的位置
        public static string GetImagePath(string folderName, string ImagePath)
        {
            return rootFolder + "/" + folderName+"/"+ ImagePath + imageFileFormat;
        }

        /*
        //取得圖片
        public static Bitmap GetBookImage(string folderName, string ImagePath)
        {
            return new Bitmap(GetImagePath(folderName, ImagePath));
        }
        */

        
        //取得書本的list
        public static Class.Book.BookDataBase GetBookListFromFile()
        {


            Class.Book.BookDataBase obj = null;
            try
            {
                //IFormatter formatter = new BinaryFormatter();
                //Stream stream = new FileStream(GetDBPath(), FileMode.Open, FileAccess.Read, FileShare.Read);
                //obj = (Class.Book.BookDataBase)formatter.Deserialize(stream);
                //stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return obj;
        }

        //儲存 BookList成檔案
        public static bool SaveBookListToFile(Class.Book.BookDataBase bookList)
        {
            try
            {
                //IFormatter formatter = new BinaryFormatter();
                //Stream stream = new FileStream(GetDBPath(), FileMode.Create, FileAccess.Write, FileShare.None);
                //formatter.Serialize(stream, bookList);
                //stream.Close();
                //IFormatter binFmt = new BinaryFormatter();
                //Stream s = File.Open(GetDBPath(), FileMode.Create, FileAccess.Write, FileShare.None);
                //binFmt.Serialize(s, bookList);
                //s.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        //只取得最後面的檔名和副檔名
        public static string GetImageName(string fullPath)
        {
            string[] str = fullPath.Split('/');
            return str[str.Length - 1];
        }

        /*
        //把圖形存成image
        public static void SaveImageToFile(Image image,string folderName, string ImagePath)
        {
            //強制轉型
            //把所有圖形強制存成PNG
            if (!Directory.Exists(GetBookDictionaryPath(folderName)))
            {
                Directory.CreateDirectory(GetBookDictionaryPath(folderName));
            }

            using (System.Drawing.Image oOrgImg = (Bitmap)image.Clone())
            {
                using (System.Drawing.Image oTarImg = (Bitmap)image.Clone())
                {
                    using (System.IO.MemoryStream oMS = new System.IO.MemoryStream())
                    {
                        //將oTarImg儲存（指定）到記憶體串流中
                        oTarImg.Save(oMS, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //將串流整個讀到陣列中，寫入某個路徑中的某個檔案裡
                        using (System.IO.FileStream oFS = System.IO.File.Open(GetImagePath(folderName, ImagePath), System.IO.FileMode.OpenOrCreate))
                        { oFS.Write(oMS.ToArray(), 0, oMS.ToArray().Length); }
                    }
                }
            }



            ////要使用這種方法才不會因為重複存取出現 GDI的問題
            ////結果還是出現了ODO
            //using (Bitmap bitmap = (Bitmap)image.Clone())
            //{
            //    bitmap.Save(GetImagePath(folderName, ImagePath), System.Drawing.Imaging.ImageFormat.Png);
            //}
        }
        */
    }
}
