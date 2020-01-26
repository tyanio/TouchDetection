﻿using System;
using OpenCvSharp;

namespace TouchDetectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //取得した画像とその差分画像を表示する
            #region
            //Mat src = new Mat(@"C:\Users\tyani\Downloads\lenna.png", ImreadModes.Grayscale);
            //// Mat src = Cv2.ImRead("lenna.png", ImreadModes.Grayscale);
            //Mat dst = new Mat();

            //Cv2.Canny(src, dst, 50, 200);
            //using (new Window("src image", src))
            //using (new Window("dst image", dst))
            //{
            //    Cv2.WaitKey();
            //}
            #endregion

            //キャプチャーした映像から顔を認識してその位置に丸を付ける
            #region
            //using (var win = new Window("capture"))
            //using (var video = new VideoCapture(0))
            //{
            //    //保存先行列
            //    var frame = new Mat();
            //    //分類器
            //    var haarcascade = new CascadeClassifier(@"C:\Users\tyani\Downloads\opencv-master\data\haarcascades\haarcascade_frontalface_default.xml");
            //    //グレースケール
            //    var gray = new Mat();

            //    while (true)
            //    {
            //        video.Read(frame);
            //        //grayにframeのグレースケール返還画像を代入
            //        Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
            //        //検出
            //        var faces = haarcascade.DetectMultiScale(gray);
            //        //検出箇所に円を描画
            //        foreach (OpenCvSharp.Rect face in faces)
            //        {
            //            var center = new Point
            //            {
            //                X = (int)(face.X + face.Width * 0.5),
            //                Y = (int)(face.Y + face.Height * 0.5)
            //            };
            //            var axes = new Size
            //            {
            //                Width = (int)(face.Width * 0.5),
            //                Height = (int)(face.Height * 0.5)
            //            };
            //            Cv2.Ellipse(frame, center, axes, 0, 0, 360, Scalar.Red, 4);
            //            Console.WriteLine("Found!");
            //        }

            //        win.ShowImage(frame);
            //        if (Cv2.WaitKey(30) >= 0) { break; }
            //    }
            //}
            #endregion

            #region
            //チェス盤のコーナー座標がを読み込めた数
            int imgInd = 0;

            //読み込むチェス盤の定義
            const int BOARD_W = 7;
            const int BOARD_H = 7;
            Size BOARD_SIZE = new Size(BOARD_W, BOARD_H);

            //精度の低いコーナーが検出できた座標のリスト
            var imageCorners = new Mat<Point2f>();
            //精度の高いコーナー座標の配列
            Point2f[] imageCorners2;
            //検出できたframe中のコーナー座標のリスト
            var imagePoints = new Mat<Point2f>();

            //まだよくわからない
            //var objectPoints = new Mat(new Mat<Point3f>());
            //var objectConrers = new Mat<Point3f>();
            //for(int j = 0; j < BOARD_H; j++)
            //{
            //    for(int i = 0; i < BOARD_W; i++)
            //    {
            //        objectConrers.PushBack(new Point3f());
            //    }
            //}

            //毎秒のフレーム画像
            var frame = new Mat();
            //フレーム画像のグレースケール
            var gray = new Mat();

            //精度の高いコーナー座標を作る際の終了基準
            var criteria = new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, 0.001);

            //ウィンドウを生成
            using(var capWindow = new Window("capture"))
            using (var chessWindow = new Window("DrawChessboardCorner"))

            //videoにカメラから取得した映像を代入
            using (var video = new VideoCapture(0))
            {
                while (true)
                {
                    video.Read(frame);

                    Cv2.PutText(frame, "Number of caputure: " + imgInd.ToString(), new Point(30, 20), HersheyFonts.HersheyPlain, 1, new Scalar(0, 255, 0));
                    Cv2.PutText(frame, "c: Capture the image", new Point(30, 40), HersheyFonts.HersheyPlain, 1, new Scalar(0, 255, 0));
                    Cv2.PutText(frame, "q: Finish capturing and calcurate the camera matrix and distortion", new Point(30, 60), HersheyFonts.HersheyPlain, 1, new Scalar(0, 255, 0));

                    capWindow.ShowImage(frame);

                    var key = Cv2.WaitKey(1);

                    if (key == 'c')
                    {
                        Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
                        //チェス盤のコーナーが検出できたらretにtrueを代入
                        var ret = Cv2.FindChessboardCorners(frame, BOARD_SIZE, imageCorners);

                        if (ret)
                        {
                            Console.WriteLine("find chess board corners.");
                            //精度を高めたコーナー座標をimageCorners2に代入
                            imageCorners2 = Cv2.CornerSubPix(gray, imageCorners, new Size(9, 9), new Size(-1, -1), criteria);

                            Cv2.DrawChessboardCorners(frame, BOARD_SIZE, imageCorners2, ret);
                            chessWindow.ShowImage(frame);
                            Cv2.WaitKey(500);

                            imgInd++;


                        }
                    }
                    else if (key == 'q')
                    {
                        break;
                    }
                }


                //Cv2.CalibrateCamera(objectPoints, imagePoints, frame.Size(), );
            }
            #endregion
        }
    }
}