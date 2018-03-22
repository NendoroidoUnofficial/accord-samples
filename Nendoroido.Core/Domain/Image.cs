using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test10.Class.Book
{
    //要標記是可以序列畫的
    [Serializable]
    //每個頁面會有的資料
    public class Image
    {
        /// <summary>
        /// 路徑 : 圖片名稱 + 格式 ex : 15.jpg
        /// </summary>
        public string ImagePath;

        /// <summary>
        /// 特徵碼，在Loading進來時已經掃好了
        /// </summary>
        //public Matrix<float> ImageFeature;

        /// <summary>
        /// VectorOfKeyPoint
        /// </summary>
        //public VectorOfKeyPoint VectorOfKeyPoint;

        public Image Clone()
        {
            Image image = new Image();
            image.ImagePath = ImagePath;
            //image.ImageFeature = this.ImageFeature.Clone();
            //image.VectorOfKeyPoint = VectorOfKeyPoint;
            return image;
        }
    }
}
