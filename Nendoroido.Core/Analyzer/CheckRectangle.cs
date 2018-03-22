using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test10.Class.FindMatch
{
    //用來檢查是不是正方形
    class CheckRectangle
    {
        //設定正方形長寬最小是多少
        PointF _leftUpPosition;
        PointF _leftDownPosition;
        PointF _rightUpPosition;
        PointF _rightDownPosition;

        //建構
        public CheckRectangle(PointF[] pts)
        {
            _leftDownPosition = pts[0];
            _rightDownPosition = pts[1];
            _rightUpPosition = pts[2];
            _leftUpPosition = pts[3];
        }

        //檢查是不是大於最小邊
        public bool CheckMinBorder(int minX,int minY)
        {
            try
            {
                if ((_leftDownPosition.Y - _leftUpPosition.Y) < minY)
                    return false;
                if ((_rightDownPosition.Y - _rightUpPosition.Y) < minY)
                    return false;
                if ((_rightUpPosition.X - _leftUpPosition.X) < minX)
                    return false;
                if ((_rightDownPosition.X - _leftDownPosition.X) < minX)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        //檢查最大邊界
        public bool CheckMaxBorder(int maxX, int maxY)
        {
            try
            {
                if ((_leftDownPosition.Y - _leftUpPosition.Y) > maxY)
                    return false;
                if ((_rightDownPosition.Y - _rightUpPosition.Y) > maxY)
                    return false;
                if ((_rightUpPosition.X - _leftUpPosition.X) > maxX)
                    return false;
                if ((_rightDownPosition.X - _leftDownPosition.X) > maxX)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        //檢查形狀
        public bool CheckShape(double rate)
        {
            try
            {
                //先檢查兩邊長寬比
                if ((_leftDownPosition.Y - _leftUpPosition.Y) > (_rightDownPosition.Y - _rightUpPosition.Y) * rate)
                    return false;
                if ((_rightDownPosition.Y - _rightUpPosition.Y) > (_leftDownPosition.Y - _leftUpPosition.Y)*rate)
                    return false;
                if ((_rightUpPosition.X - _leftUpPosition.X) > (_rightDownPosition.X - _leftDownPosition.X)*rate)
                    return false;
                if ((_rightDownPosition.X - _leftDownPosition.X) > (_rightUpPosition.X - _leftUpPosition.X)*rate)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
