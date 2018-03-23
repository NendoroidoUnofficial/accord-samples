﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nendoroido.Core.Helps
{
    
    class ImageHelper
    {
        /*
        /// <summary>
        /// Convert from byte to image
        /// https://stackoverflow.com/questions/29153967/convert-a-byte-into-an-emgu-opencv-image
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image<Gray, byte> ConvertFromByte(byte[] bytes, int width, int height)
        {
            Image<Gray, byte> depthImage = new Image<Gray, byte>(width, height);
            depthImage.Bytes = bytes;
            return depthImage;
        }
        */

        /*
        public static Image<Gray, byte> ConvertFromImageSource(Stream source)
        {
            Stream saveStream = null;
            using (Image<Rgba32> image = SixLabors.ImageSharp.Image.Load(source))
            {
                image.Mutate(x => x
                    //.Resize(image.Width / 2, image.Height / 2)
                    .Grayscale());
                image.SaveAsBmp(saveStream); 
            }

            Image<Gray, byte> targetImage = null;
            using (Image<Rgba32> image = SixLabors.ImageSharp.Image.Load(saveStream))
            {
                targetImage = new Image<Gray, byte>(image.Width,image.Height);
                targetImage.Bytes = image.SavePixelData();
            }
            return targetImage;
        }

        public static Image<Gray, byte> ConvertFromStream(Stream source)
        {
            
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    source.CopyTo(ms);
            //    byte[] data = ms.ToArray();
            //}

            //Mat mat = CvInvoke.Imread(source.p);
            //Image<Gray, byte> targetImage = new Image<Gray, byte>();
            //return targetImage;
            

            return null;
        }

        public static Stream ConvertFromEmguCVImage(Image<Gray, byte> image)
        {
            Stream stream = null;
            using (Image<Rgba32> targetImage = new Image<Rgba32>(image.Width, image.Height))
            {
                for (int i = 0; i < image.Width; i++)
                {
                    for (int j = 0; i < image.Height; j++)
                    {
                        var rgba32 = targetImage[i, j];
                        rgba32.R = image.Data[i ,j, 0];
                        rgba32.G = image.Data[i, j, 1];
                        rgba32.B = image.Data[i, j, 2];
                        rgba32.A = image.Data[i, j, 3];
                    }
                }
                targetImage.SaveAsJpeg(stream);
            }
            return stream;
        }
        */
    }

}