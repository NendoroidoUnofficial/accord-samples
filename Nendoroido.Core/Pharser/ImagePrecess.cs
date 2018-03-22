//using Emgu.CV;
//using Emgu.CV.Features2D;
//using Emgu.CV.Structure;
//using Emgu.CV.Util;
//using System;
//using Emgu.CV.CvEnum;

//namespace test10
//{
//    //處理圖片
//    class ImagePrecess
//    {
//        //圖片
//        Image<Gray, Byte> _modelImage;
//        //取得 VectorOfKeyPoint
//        VectorOfKeyPoint _modelKeyPoints;
//        //特徵點?
//        Matrix<float> _feature;

//        //建構
//        //把圖片調成希望的大小附近
//        public ImagePrecess(string bitmapImage,int expectWidth=320, int expectHeight = 240)
//        {
//            //開始處理
//            _modelImage = new Image<Gray, Byte>(0,10);
//            ProcessImage(_modelImage);

//            /*
//            //長+寬的倍率去換算 
//            float rate = (float)(expectWidth + expectHeight) / (float)(bitmapImage.Width + bitmapImage.Height);
//            int width = (int)(bitmapImage.Width * rate);
//            int height = (int)(bitmapImage.Height * rate);

//            //建立新的壓縮圖片

//            Bitmap resizedbitmap = new Bitmap(width, height);
//            Graphics g = Graphics.FromImage(resizedbitmap);
//            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
//            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
//            g.Clear(Color.Transparent);
//            g.DrawImage(bitmapImage, new Rectangle(0, 0, width, height), new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), GraphicsUnit.Pixel);

//            //開始處理
//            _modelImage = new Image<Gray, byte>(resizedbitmap);
//            ProcessImage(_modelImage);
//            */
//        }

//        //建構
//        public ImagePrecess(string bitmapImage)
//        {
//            //Mat mat = new Mat();
//            //mat.ToImage<Bgr, Byte>();

//            IntPtr inputImage = CvInvoke.cvLoadImage("C:\\Users\\...\\ClassPic1.jpg", LOAD_IMAGE_TYPE.CV_LOAD_IMAGE_COLOR);
//            _modelImage = new Image<Gray, byte>(10,10);
//            ProcessImage(_modelImage);
//        }

//        //建構
//        public ImagePrecess(Image<Gray, Byte> modelImage)
//        {
//            _modelImage = modelImage;
//            ProcessImage(_modelImage);
//        }

//        public void ProcessImage(Image<Gray, Byte> modelImage)
//        {
//            _modelKeyPoints = new VectorOfKeyPoint();
//            _modelImage = modelImage;
//            SURFDetector surfCPU = new SURFDetector(500, false);
//            _feature= surfCPU.DetectAndCompute(modelImage, null, _modelKeyPoints);
//        }


//        //丟入圖片，取得image 的 特稱點
//        public Matrix<float> GetImageFeature()
//        {
//            return _feature;
//        }

//        //丟入圖片，取得image 的 特稱點
//        public VectorOfKeyPoint GetImageVectorOfKeyPoint()
//        {
//            return _modelKeyPoints;
//        }

//        //取得寬度
//        public int GetImageWidth()
//        {
//            return _modelImage.Width;
//        }

//        //取得高度
//        public int GetImageHeight()
//        {
//            return _modelImage.Height;
//        }

//    }
//}
