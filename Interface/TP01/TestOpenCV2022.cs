using System;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Numerics;

namespace TestOpenCV2022
{
    internal class TestOpenCV2022
    {
        public static void CopyToImage(Image<Bgr, Byte> source, Image<Bgr, Byte> destination, int offsetX, int offsetY)
        {
            for(int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    destination.Data[y + offsetY, x+offsetX, 0] = source.Data[y, x, 0];
                    destination.Data[y + offsetY, x+offsetX, 1] = source.Data[y, x, 1];
                    destination.Data[y + offsetY, x+offsetX, 2] = source.Data[y, x, 2];
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
            Image<Bgr, Byte> img = new Image<Bgr, Byte>("C:\\Users\\rchapelle\\Documents\\2023_M2-GAMAGORA\\Interface\\Images\\crochet.jpg");

            Image<Bgr, Byte> img2 = new Image<Bgr, Byte>(1000,1000);


            CopyToImage(img, img2, 0,0);


            CvInvoke.Imshow("Exercice 2", img2);
            CvInvoke.WaitKey(0);

        }
    }


}


//string name = "crochet";
//var img = new Mat($"C:\\Users\\ymiollany\\Pictures\\{name}.png");

//Image<Bgr, Byte> imageCopy = img.ToImage<Bgr, Byte>();

//String win1 = "Test Window (Press any key to close)"; //The name of the window
//CvInvoke.NamedWindow(win1); //Create the window using the specific name
//using (Mat frame = new Mat())
//using (VideoCapture capture = new VideoCapture())
//    while (CvInvoke.WaitKey(1) == -1)
//    {
//        capture.Read(frame);

//        Image<Bgr, Byte> frameImage = frame.ToImage<Bgr, Byte>();

//        CopyToImage(imageCopy, frameImage, new Vector2(10, 10));

//        CvInvoke.Imshow(win1, frameImage);
//    }