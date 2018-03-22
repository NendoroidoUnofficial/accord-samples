using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using test10.Class.FindMatch;

namespace test10
{
    ///// <summary>
    ///// 圖片轉換和掃描
    ///// 參考 : 
    ///// http://www.emgu.com/wiki/index.php/SURF_feature_detector_in_CSharp
    ///// http://www.pudn.com/Download/item/id/2659035.html
    ///// </summary>
    //class Matching
    //{
    //    public Matching() 
    //    {

    //    }

    //    //主要是在這端對比的
    //    public  void FindMatch(Image<Gray, Byte> modelImage, Image<Gray, byte> observedImage, out long matchTime, out VectorOfKeyPoint modelKeyPoints,
    //        out VectorOfKeyPoint observedKeyPoints, out Matrix<int> indices, out Matrix<byte> mask, out HomographyMatrix homography)
    //    {
    //        int k = 2;
    //        double uniquenessThreshold = 0.8;
    //        SURFDetector surfCPU = new SURFDetector(500, false); //設定處理特徵值的方式
    //        Stopwatch watch; //監看處理時間
    //        homography = null; //如果相同，取得四邊形
            
    //        //extract features from the object image
    //        modelKeyPoints = new VectorOfKeyPoint();
    //        Matrix<float> modelDescriptors = surfCPU.DetectAndCompute(modelImage, null, modelKeyPoints); //modelKeyPoints : 算出 特徵點? //modelDescriptors : 

            

    //        // extract features from the observed image
    //        observedKeyPoints = new VectorOfKeyPoint();
    //        Matrix<float> observedDescriptors = surfCPU.DetectAndCompute(observedImage, null, observedKeyPoints); //observedKeyPoints : 取得特徵點 //
    //        //ImagePrecess processor = new ImagePrecess(observedImage.ToBitmap(),320,240);
    //        //observedDescriptors = processor.GetImageFeature();
    //        //observedKeyPoints=processor.GetImageVectorOfKeyPoint();


    //        watch = Stopwatch.StartNew();
    //        //
    //        BruteForceMatcher<float> matcher = new BruteForceMatcher<float>(DistanceType.L2);
    //        matcher.Add(modelDescriptors);

    //        indices = new Matrix<int>(observedDescriptors.Rows, k);
    //        using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k))
    //        {
    //            matcher.KnnMatch(observedDescriptors, indices, dist, k, null); //取得對比
    //            mask = new Matrix<byte>(dist.Rows, 1);
    //            mask.SetValue(255);
    //            Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);//會把剛剛match完的結果抓來看是不是不明確或是不確定的，而跑完的結果放在mask中。
    //        }

    //        int nonZeroCount = CvInvoke.cvCountNonZero(mask);
    //        if (nonZeroCount >= 4)
    //        {
    //            nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
    //            if (nonZeroCount >= 4)
    //                homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
    //        }
    //        watch.Stop();
    //        matchTime = watch.ElapsedMilliseconds;                
    //    }

    //    //丟入對比圖，還有對比時間
    //    //可以算出結果
    //    public Image<Bgr, Byte> Draw(Image<Gray, Byte> modelImage, Image<Gray, byte> observedImage, out long matchTime)
    //    {
    //        //同形矩陣
    //        HomographyMatrix homography;
    //        VectorOfKeyPoint modelKeyPoints;
    //        VectorOfKeyPoint observedKeyPoints;
    //        Matrix<int> indices;
    //        Matrix<byte> mask;

    //        FindMatch(modelImage, observedImage, out matchTime, out modelKeyPoints, out observedKeyPoints, out indices, out mask, out homography);//會丟出尋找時間

    //        //Draw the matched keypoints
    //        Image<Bgr, Byte> result = Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints,
    //           indices, new Bgr(255, 255, 255), new Bgr(255, 255, 255), mask, Features2DToolbox.KeypointDrawType.DEFAULT);

    //        #region draw the projected region on the image
    //        if (homography != null)
    //        {  //draw a rectangle along the projected model
    //            //表示有對比到結過
    //            //System.Windows.Forms.MessageBox.Show("Match! ");
    //            Rectangle rect = modelImage.ROI;
    //            PointF[] pts = new PointF[] { 
    //           new PointF(rect.Left, rect.Bottom),
    //           new PointF(rect.Right, rect.Bottom),
    //           new PointF(rect.Right, rect.Top),
    //           new PointF(rect.Left, rect.Top)};
    //            homography.ProjectPoints(pts);
    //            Console.WriteLine("width : " + rect.Right + "height : " + rect.Bottom + "\n" + pts.Length + "Up : " + pts[0].X + "," + pts[0].Y + "\n Down : " + "Up : " + pts[1].X + "," + pts[1].Y + "\n Left : " + "Up : " + pts[2].X + "," + pts[2].Y + "\n right : " + "Up : " + pts[3].X + "," + pts[3].Y);
    //            result.DrawPolyline(Array.ConvertAll<PointF, Point>(pts, Point.Round), true, new Bgr(Color.Red), 5);
    //        }
    //        #endregion

    //        return result;
    //    }

    //    //====================底下都是重新整理的class=====================

    //    //找出兩張圖是不是一樣
    //    //model : 部分圖片(要找尋部分)
    //    //observe : 整體 ，model 可能在 observe裡面的其中一個區塊
    //    public bool TwoImageIsMatch(Matrix<float> modelDescriptors, Matrix<float> observedDescriptors,int width,int Height, VectorOfKeyPoint modelKeyPoints, VectorOfKeyPoint observedKeyPoints)
    //    {
    //        Matrix<byte> mask;
    //        int k = 2;
    //        double uniquenessThreshold = 0.8;
    //        Matrix<int> indices;
    //        //
    //        BruteForceMatcher<float> matcher = new BruteForceMatcher<float>(DistanceType.L2);
    //        matcher.Add(modelDescriptors);

    //        indices = new Matrix<int>(observedDescriptors.Rows, k);
    //        using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k))
    //        {
    //            matcher.KnnMatch(observedDescriptors, indices, dist, k, null); //取得對比
    //            mask = new Matrix<byte>(dist.Rows, 1);
    //            mask.SetValue(255);
    //            Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);
    //        }

    //        //indices = new Matrix<int>(observedDescriptors.Rows, k);
    //        HomographyMatrix homography = null;
    //        int nonZeroCount = CvInvoke.cvCountNonZero(mask);
    //        if (nonZeroCount >= 4)
    //        {
    //            nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
    //            if (nonZeroCount >= 4)
    //                homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
    //        }
    //        if (homography != null)
    //            if (HomographySizeIsLegal(homography, width, Height))
    //            {
    //                return true;
    //            }
                
    //        return false;
    //    }

    //    //去計算出 HomographyMatrix 裡面對應形狀的大小是不是
    //    public bool HomographySizeIsLegal(HomographyMatrix homography, int width, int height)
    //    {
    //        int Top = 0;
    //        int Bottom = height;
    //        int Left = 0;
    //        int Right = width;
    //        PointF[] pts = new PointF[] {new PointF(Left, Bottom),new PointF(Right, Bottom),new PointF(Right, Top),new PointF(Left, Top)};
    //        //把矩陣去做轉換
    //        homography.ProjectPoints(pts);
    //        //計算是不是正方形
    //        CheckRectangle check = new CheckRectangle(pts);
    //        //至少要是正方形形狀而且大於最小邊
    //        if (check.CheckMinBorder(width / 5, height/5)) //小圖片裡面至少要有一半的內容在大圖片裡
    //        {
    //            if (check.CheckMaxBorder(width, height))
    //            {
    //                if (check.CheckShape(1.5))
    //                {
    //                    Console.WriteLine("width : " + width + "height : " + height + "\n" + pts.Length + "Up : " + pts[0].X + "," + pts[0].Y + "\n Down : " + "Up : " + pts[1].X + "," + pts[1].Y + "\n Left : " + "Up : " + pts[2].X + "," + pts[2].Y + "\n right : " + "Up : " + pts[3].X + "," + pts[3].Y);
    //                    return true;
    //                }
    //            }
    //        }
    //        return false;
    //    } 

    //    //取得mask，用兩張圖的點做個比對
    //    public Matrix<byte> GetMask(Matrix<float> modelDescriptors, Matrix<float> observedDescriptors)
    //    {
    //        Matrix<byte> mask;
    //        int k = 2;
    //        double uniquenessThreshold = 0.8;
    //        Matrix<int> indices;
    //        //
    //        BruteForceMatcher<float> matcher = new BruteForceMatcher<float>(DistanceType.L2);
    //        matcher.Add(modelDescriptors);

    //        indices = new Matrix<int>(observedDescriptors.Rows, k);
    //        using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k))
    //        {
    //            matcher.KnnMatch(observedDescriptors, indices, dist, k, null); //取得對比
    //            mask = new Matrix<byte>(dist.Rows, 1);
    //            mask.SetValue(255);
    //            Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);
    //        }
    //        return mask;
    //    }

    //    //取得image是不是一樣的
    //    //傳入參數
    //    public HomographyMatrix GetTwoImageHomographyMatrix(VectorOfKeyPoint modelKeyPoints, VectorOfKeyPoint observedKeyPoints, Matrix<int> indices, Matrix<byte> mask)
    //    {
    //        int k = 2;
    //        //indices = new Matrix<int>(observedDescriptors.Rows, k);
    //        HomographyMatrix homography = null;
    //        int nonZeroCount = CvInvoke.cvCountNonZero(mask);
    //        if (nonZeroCount >= 4)
    //        {
    //            nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
    //            if (nonZeroCount >= 4)
    //                homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
    //        }
    //        return homography;
    //    }

    //    //畫出兩個image一樣的地方
    //    //不代表image裡面有相同的物件
    //    public Image<Bgr, Byte> DrawTwoImageMatchPoint(Image<Gray, Byte> modelImage, Image<Gray, byte> observedImage, VectorOfKeyPoint modelKeyPoints, VectorOfKeyPoint observedKeyPoints, Matrix<byte> mask, Matrix<int> indices)
    //    {
    //        Image<Bgr, Byte> result = Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints,
    //           indices, new Bgr(255, 255, 255), new Bgr(255, 255, 255), mask, Features2DToolbox.KeypointDrawType.DEFAULT);
    //        return result;
    //    }

    //    //框出相同點
    //    public Image<Bgr, Byte> DrawMatchPoly(Image<Gray, Byte> modelImage,Image<Bgr, Byte> result, HomographyMatrix homography)
    //    {
    //        if (homography != null)
    //        {  //draw a rectangle along the projected model
    //            //表示有對比到結過
    //            Console.WriteLine("Match! ");
    //            Rectangle rect = modelImage.ROI;
    //            PointF[] pts = new PointF[] {
    //           new PointF(rect.Left, rect.Bottom),
    //           new PointF(rect.Right, rect.Bottom),
    //           new PointF(rect.Right, rect.Top),
    //           new PointF(rect.Left, rect.Top)};
    //            homography.ProjectPoints(pts);

    //            result.DrawPolyline(Array.ConvertAll<PointF, Point>(pts, Point.Round), true, new Bgr(Color.Red), 5);
    //        }

    //        return result;
    //    }



    //}
}
