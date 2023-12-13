using System;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Numerics;
using System.Drawing;
using Emgu.CV.Aruco;


namespace TestOpenCV2022
{
    internal class TestOpenCV2022
    {

        public static void CopyToImage(Image<Bgr, Byte> source, Image<Bgr, Byte> destination, int offsetX = 0, int offsetY = 0)
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
                    destination.Data[y + offsetY, x + offsetX, 0] = source.Data[y, x, 0];
                    destination.Data[y + offsetY, x + offsetX, 1] = source.Data[y, x, 1];
                    destination.Data[y + offsetY, x + offsetX, 2] = source.Data[y, x, 2];
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

        static void Main(string[] args)
        {

            // PARTIE 2

            //// Q1
            //Emgu.CV.Mat img = new Mat("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\hsv.png");
            //CvInvoke.Imshow("Exercice 1", img);
            //CvInvoke.WaitKey(0);

            // Q2
            //String win1 = "Video"; 
            //CvInvoke.NamedWindow(win1);
            //using (Mat frame = new Mat())
            //using (VideoCapture capture = new VideoCapture())
            //while (CvInvoke.WaitKey(1) == -1)
            //{
            //    capture.Read(frame);
            //    CvInvoke.Imshow(win1, frame);
            //}


            // PARTIE 3

            // Q4
            //Emgu.CV.Mat img = new Mat("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\aruco.png");

            //VectorOfInt vectorOfInt = new VectorOfInt();
            //VectorOfVectorOfPointF vectorOfVectorOfPointF = new VectorOfVectorOfPointF();
            //DetectorParameters detectorParameters = DetectorParameters.GetDefault();
            //Dictionary dictionary = new Dictionary(Dictionary.PredefinedDictionaryName.Dict6X6_250);

            //// Q5
            //ArucoInvoke.DetectMarkers(img, dictionary, vectorOfVectorOfPointF, vectorOfInt, detectorParameters);

            //// Q6
            //ArucoInvoke.DrawDetectedMarkers(img, vectorOfVectorOfPointF, vectorOfInt, new MCvScalar(255, 0, 255));

            //CvInvoke.Imshow("Arcudo", img);
            //CvInvoke.WaitKey(0);

            // Partie 4



            Image<Gray, Byte> grayImg = new Image<Gray, Byte>("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\aruco.png");
            CvInvoke.AdaptiveThreshold(grayImg, grayImg, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, 3, 1);
            Image<Bgr, byte> imgBlack = new Image<Bgr, byte>(1000, 1000);
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(grayImg, contours, new Mat(), RetrType.List, ChainApproxMethod.ChainApproxNone);

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

                Image<Gray, byte> imgContour = new Image<Gray, byte>(grayImg.Width, grayImg.Height);
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

            CvInvoke.Imshow("Arcudo", grayImg);
            CvInvoke.WaitKey(0);

        }
    }


}
