using System;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Numerics;
using System.Drawing;

namespace TestOpenCV2022
{
    internal class TestOpenCV2022
    {
        public static void CopyToImage(Image<Bgr, Byte> source, Image<Bgr, Byte> destination, int offsetX = 0, int offsetY = 0)
        {
            for(int x = 0; x < source.Width; x++)
            {
                if(x + offsetX >= destination.Width)
                {
                    break;
                }
                for (int y = 0; y < source.Height; y++)
                {
                    if(y + offsetY >= destination.Height)
                    {
                        break;
                    }
                    destination.Data[y + offsetY, x+offsetX, 0] = source.Data[y, x, 0];
                    destination.Data[y + offsetY, x+offsetX, 1] = source.Data[y, x, 1];
                    destination.Data[y + offsetY, x+offsetX, 2] = source.Data[y, x, 2];
                }
            }
        }

        public static void CopyToImage(Image<Gray, Byte> source, Image<Bgr, Byte> destination, int offsetX = 0, int offsetY = 0)
        {
            for (int x = 0; x < source.Width; x++)
            {
                if (x + offsetX >= destination.Width)
                {
                    break;
                }
                for (int y = 0; y < source.Height; y++)
                {
                    if (y + offsetY >= destination.Height)
                    {
                        break;
                    }
                        destination.Data[y + offsetY, x + offsetX, 0] = (byte)source[y, x].Intensity;
                        destination.Data[y + offsetY, x + offsetX, 1] = (byte)source[y, x].Intensity;
                        destination.Data[y + offsetY, x + offsetX, 2] = (byte)source[y, x].Intensity;
                }
            }
        }

        public static void CopyChannelToImage(Image<Bgr, Byte> source, Image<Bgr, Byte> destination, int offsetX, int offsetY, int canal)
        {
            for (int x = 0; x < source.Width; x++)
            {
                if (x + offsetX >= destination.Width)
                {
                    break;
                }
                for (int y = 0; y < source.Height; y++)
                {
                    if (y + offsetY >= destination.Height)
                    {
                        break;
                    }
                    destination.Data[y + offsetY, x + offsetX, canal] = (byte)source.Data[y, x, canal];
                }
            }
        }

        public static void CopyChannelToImage(Image<Hsv, Byte> source, Image<Hsv, Byte> destination, int channel, int offsetX = 0, int offsetY = 0)
        {
            for (int x = 0; x < source.Width; x++)
            {
                if (x + offsetX >= destination.Width)
                {
                    break;
                }
                for (int y = 0; y < source.Height; y++)
                {
                    if (y + offsetY >= destination.Height)
                    {
                        break;
                    }
                    destination.Data[y + offsetY, x + offsetX, channel] = (byte)source.Data[y, x, channel];
                }
            }
        }

        public static void CopyChannelToImage(Image<Hsv, Byte> source, Image<Gray, Byte> destination, int channel, int offsetX = 0, int offsetY = 0)
        {
            for (int x = 0; x < source.Width; x++)
            {
                if (x + offsetX >= destination.Width)
                {
                    break;
                }
                for (int y = 0; y < source.Height; y++)
                {
                    if (y + offsetY >= destination.Height)
                    {
                        break;
                    }
                    destination.Data[y + offsetY, x + offsetX, 0] = (byte)source.Data[y, x, channel];
                }
            }
        }





        static void Main(string[] args)
        {

            // PARTIE 1

            //// Q1
            //Emgu.CV.Mat img = new Mat("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\hsv.png");
            //CvInvoke.Imshow("Exercice 1", img);
            //CvInvoke.WaitKey(0);


            //String window = "My window";
            //CvInvoke.NamedWindow(window);
            //Mat frame = new Mat(); 

            //Emgu.CV.VideoCapture video = new VideoCapture(0);
            //while(CvInvoke.WaitKey(1)  == -1) {
            //    video.Read(frame);

            //    Image<Bgr, Byte> image = frame.ToImage<Bgr, Byte>();

            //    CvInvoke.Imshow(window, image);
            //}
            //CvInvoke.WaitKey(0);


            // PARTIE 3
            //Image<Bgr, Byte> img = new Image<Bgr, Byte>("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\crochet.jpg");
            //Image<Bgr, Byte> img2 = new Image<Bgr, Byte>("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\crochet.jpg");
            //int height;
            //if (img.Height > img2.Height)
            //{
            //    height = img.Height;

            //}
            //else
            //{
            //    height = img2.Height;
            //}
            //Image<Bgr, Byte> img3 = new Image<Bgr, Byte>(img.Width + img2.Width,height);
            //Image<Bgr, Byte> img3 = new Image<Bgr, Byte>(img.Width * 2, img.Height);


            //CopyChannelToImage(img, img2, 0,0, 0);


            // PARTIE 4

            //CvInvoke.CvtColor(img2, img2, ColorConversion.Bgr2Gray);
            //CvInvoke.Flip(img2, img2, FlipType.Vertical);

            //CopyToImage(img, img3, 0, 0);
            //CopyToImage(img2, img3, img.Width, 0);
            //CvInvoke.Imshow("Exercice 1", img3);
            //CvInvoke.WaitKey(0);


            // PARTIE 5
            //Image<Hsv, byte> img1 = new Image<Hsv, byte>("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\crochet.jpg");
            //Image<Gray, byte> img2 = new Image<Gray, byte>(img1.Width * 3, img1.Height);


            //int teinteMin = 30;
            //int saturationMin = 0;
            //int valeurMin = 0;
            //Hsv borneInf = new Hsv(teinteMin, saturationMin, valeurMin);
            //int teinteMax = 80;
            //int saturationMax = 255;
            //int valeurMax = 255;
            //Hsv borneMax = new Hsv(teinteMax, saturationMax, valeurMax);

            //Image<Gray, byte> img3 = img1.InRange(borneInf, borneMax) ;
            //CopyChannelToImage(img1, img2, 0);
            //CopyChannelToImage(img1, img2, 1, img1.Width);
            //CopyChannelToImage(img1, img2, 2, img1.Width * 2);
            //CvInvoke.Imshow("channel", img3);
            //CvInvoke.WaitKey(0);


            // PARTIE 6
            //Image<Hsv, byte> img1 = new Image<Hsv, byte>("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\crochet.jpg");
            //Image<Gray, byte> img2 = new Image<Gray, byte>(img1.Width * 3, img1.Height);


            //int teinteMin = 30;
            //int saturationMin = 0;
            //int valeurMin = 0;
            //Hsv borneInf = new Hsv(teinteMin, saturationMin, valeurMin);
            //int teinteMax = 80;
            //int saturationMax = 255;
            //int valeurMax = 255;
            //Hsv borneMax = new Hsv(teinteMax, saturationMax, valeurMax);

            //Image<Gray, byte> img3 = img1.InRange(borneInf, borneMax);
            //CvInvoke.Erode(img3, img3, null, new System.Drawing.Point(-1, -1), 10, BorderType.Default, default);
            //CvInvoke.Dilate(img3, img3, null, new System.Drawing.Point(-1, -1), 10, BorderType.Default, default);

            //CvInvoke.Imshow("channel", img3);
            //CvInvoke.WaitKey(0);

            // PARTIE 7

            //Image<Hsv, byte> img1 = new Image<Hsv, byte>("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\crochet.jpg");
            //Image<Gray, byte> img2 = new Image<Gray, byte>(img1.Width * 3, img1.Height);
            //Image<Bgr, byte> imgBlack = new Image<Bgr, byte>(1000,1000);


            //int teinteMin = 30;
            //int saturationMin = 0;
            //int valeurMin = 0;
            //Hsv borneInf = new Hsv(teinteMin, saturationMin, valeurMin);
            //int teinteMax = 80;
            //int saturationMax = 255;
            //int valeurMax = 255;
            //Hsv borneMax = new Hsv(teinteMax, saturationMax, valeurMax);

            //Image<Gray, byte> img3 = img1.InRange(borneInf, borneMax);

            //CvInvoke.Erode(img3, img3, null, new System.Drawing.Point(-1, -1), 10, BorderType.Default, default);
            //CvInvoke.Dilate(img3, img3, null, new System.Drawing.Point(-1, -1), 10, BorderType.Default, default);


            //VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            //CvInvoke.FindContours(img3, contours, new Mat(), RetrType.List, ChainApproxMethod.ChainApproxNone);

            //if(contours.Size > 0)
            //{
            //    VectorOfPoint largestContour = contours[0];
            //    for(int i = 0; i < contours.Size; i++)
            //    {

            //        if(CvInvoke.ContourArea(largestContour) > CvInvoke.ContourArea(contours[i]))
            //        {
            //            largestContour = contours[i];
            //        }
            //    }

            //    Image<Gray, byte> imgContour = new Image<Gray, byte>(img3.Width, img3.Height);
            //    imgContour.DrawPolyline(largestContour.ToArray(), false, new Gray(255));
            //    CopyToImage(imgContour, imgBlack);
            //    Moments m = CvInvoke.Moments(largestContour);
            //    Point center = new Point(
            //        (int)(m.M10 / m.M00),
            //        (int)(m.M01 / m.M00));
            //    Image<Bgr, byte> momentImage = imgContour.Convert<Bgr, byte>();
            //    CvInvoke.Circle(momentImage, center, 5, new MCvScalar(255, 255, 0));
            //    CopyToImage( momentImage, imgBlack);

            //}

            //CvInvoke.Imshow("channel", imgBlack);
            //CvInvoke.WaitKey(0);

            // PARTIE 8

            Image<Hsv, byte> img1 = new Image<Hsv, byte>("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\crochet.jpg");
            Image<Gray, byte> img2 = new Image<Gray, byte>(img1.Width * 3, img1.Height);
            Image<Bgr, byte> imgBlack = new Image<Bgr, byte>(1000, 1000);


            int teinteMin = 30;
            int saturationMin = 0;
            int valeurMin = 0;
            Hsv borneInf = new Hsv(teinteMin, saturationMin, valeurMin);
            int teinteMax = 80;
            int saturationMax = 255;
            int valeurMax = 255;
            Hsv borneMax = new Hsv(teinteMax, saturationMax, valeurMax);

            Image<Gray, byte> img3 = img1.InRange(borneInf, borneMax);

            CvInvoke.Erode(img3, img3, null, new System.Drawing.Point(-1, -1), 10, BorderType.Default, default);
            CvInvoke.Dilate(img3, img3, null, new System.Drawing.Point(-1, -1), 10, BorderType.Default, default);


            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(img3, contours, new Mat(), RetrType.List, ChainApproxMethod.ChainApproxNone);

            if (contours.Size > 0)
            {
                VectorOfPoint largestContour = contours[0];
                for (int i = 0; i < contours.Size; i++)
                {

                    if (CvInvoke.ContourArea(largestContour) > CvInvoke.ContourArea(contours[i]))
                    {
                        largestContour = contours[i];
                    }
                }

                Image<Gray, byte> imgContour = new Image<Gray, byte>(img3.Width, img3.Height);
                imgContour.DrawPolyline(largestContour.ToArray(), false, new Gray(255));
                CopyToImage(imgContour, imgBlack);
                Moments m = CvInvoke.Moments(largestContour);
                Point center = new Point(
                    (int)(m.M10 / m.M00),
                    (int)(m.M01 / m.M00));
                Image<Bgr, byte> momentImage = imgContour.Convert<Bgr, byte>();
                CvInvoke.Circle(momentImage, center, 5, new MCvScalar(255, 255, 0));
                CopyToImage(momentImage, imgBlack);

            }

            CvInvoke.Imshow("channel", imgBlack);
            CvInvoke.WaitKey(0);

        }
    }


}
