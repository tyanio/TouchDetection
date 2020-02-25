using System;
using System.Collections.Generic;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using OpenCvSharp.Aruco;

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

            //カメラキャリブレーションを行う
            #region

            ////チェス盤のコーナー座標がを読み込めた数
            //int imgInd = 0;

            ////読み込むチェス盤の定義
            //const int BOARD_W = 7;
            //const int BOARD_H = 7;
            //Size BOARD_SIZE = new Size(BOARD_W, BOARD_H);
            //const int SCALE = 26;

            ////精度の低いコーナーが検出できた座標のリスト
            //var imageCorners = new Mat<Point2f>();
            ////精度の高いコーナー座標の配列
            //Point2f[] imageCorners2;
            ////検出できたframe中のコーナー座標のリスト
            //var imagePoints = new List<Mat<Point2f>>();

            ////毎秒のフレーム画像
            //var frame = new Mat();
            ////フレーム画像のグレースケール
            //var gray = new Mat();

            ////認識したチェス盤画像
            //var chessboard = new List<Mat>();

            ////精度の高いコーナー座標を作る際の終了基準
            //var criteria = new TermCriteria(CriteriaType.Count | CriteriaType.Eps, 30, 0.001);

            ////ウィンドウを生成
            //using (var capWindow = new Window("capture"))
            //using (var chessWindow = new Window("DrawChessboardCorner"))

            ////videoにカメラから取得した映像を代入
            //using (var video = new VideoCapture(0))
            //{
            //    while (true)
            //    {
            //        video.Read(frame);

            //        var key = Cv2.WaitKey(1);

            //        if (key == 'c')
            //        {
            //            Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
            //            //チェス盤のコーナーが検出できたらretにtrueを代入
            //            var ret = Cv2.FindChessboardCorners(frame, BOARD_SIZE, imageCorners);
            //            //Console.WriteLine(imageCorners.Get<Point2f>(0));

            //            if (ret)
            //            {
            //                Console.WriteLine("find chess board corners.");
            //                chessboard.Add(frame);
            //                //精度を高めたコーナー座標をimageCorners2に代入
            //                imageCorners2 = Cv2.CornerSubPix(gray, imageCorners, new Size(9, 9), new Size(-1, -1), criteria);
            //                //Console.WriteLine(imageCorners2[0]);

            //                Cv2.DrawChessboardCorners(frame, BOARD_SIZE, imageCorners2, ret);

            //                imageCorners.SetArray<Point2f>(imageCorners2);
            //                //Console.WriteLine(imageCorners.Get<Point2f>(0));
            //                //Console.WriteLine(imageCorners.Size());

            //                imagePoints.Add(imageCorners);
            //                chessWindow.ShowImage(frame);
            //                Cv2.WaitKey(500);

            //                imgInd++;
            //            }
            //        }
            //        else if (key == 'q')
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            Cv2.PutText(frame, "Number of caputure: " + imgInd.ToString(), new Point(30, 20), HersheyFonts.HersheyPlain, 1, new Scalar(0, 255, 0));
            //            Cv2.PutText(frame, "c: Capture the image", new Point(30, 40), HersheyFonts.HersheyPlain, 1, new Scalar(0, 255, 0));
            //            Cv2.PutText(frame, "q: Finish capturing and calcurate the camera matrix and distortion", new Point(30, 60), HersheyFonts.HersheyPlain, 1, new Scalar(0, 255, 0));

            //            capWindow.ShowImage(frame);
            //        }
            //    }

            //    //よくわからない
            //    var objectPoints = new List<Mat<Point3f>>();
            //    var objectConrers = new Mat<Point3f>();
            //    for (int j = 0; j < BOARD_H; j++)
            //    {
            //        for (int i = 0; i < BOARD_W; i++)
            //        {
            //            objectConrers.PushBack(new Point3f(i * SCALE, j * SCALE, 0f));
            //        }
            //    }
            //    for (int i = 0; i < imgInd; i++)
            //        objectPoints.Add(objectConrers);

            //    var cameraMatrix = new Mat();
            //    var distCoeffs = new Mat();
            //    Mat[] rvecs;
            //    Mat[] tvecs;

            //    var rms = Cv2.CalibrateCamera(objectPoints, imagePoints, frame.Size(), cameraMatrix, distCoeffs, out rvecs, out tvecs);

            //    Console.WriteLine("Re-projection Error(unit: pixel) : " + rms);
            //    Console.WriteLine("cameraMatrix(unit: pixel) : " + cameraMatrix);
            //    Console.WriteLine("distCoeffs : " + distCoeffs);

            //    var dst = new Mat();
            //    Cv2.Undistort(chessboard[0], dst, cameraMatrix, distCoeffs);
            //    using (new Window("補正画像", WindowMode.AutoSize, dst))
            //    {
            //        while (true)
            //            if (Cv2.WaitKey() == 'q')
            //                break;
            //    }
            //}
            #endregion

            //SIFTマッチング
            #region
            //var leftFrame = new Mat();
            //var rightFrame = new Mat();
            //var view = new Mat();

            //var leftGray = new Mat();
            //var rightGray = new Mat();

            //var sift = SIFT.Create();
            //KeyPoint[] keypoints1, keypoints2;
            //var descriptors1 = new Mat();
            //var descriptors2 = new Mat();

            //using (var leftCapWindow = new Window("left capture"))
            //using (var rightCapWindow = new Window("right capture"))
            //using (var leftVideo = new VideoCapture(0))
            //using (var rightVideo = new VideoCapture(1))
            //{
            //    while (true)
            //    {
            //        leftVideo.Read(leftFrame);
            //        rightVideo.Read(rightFrame);

            //        Cv2.PutText(leftFrame, "d: detect and compute SIFT", new Point(30, 40), HersheyFonts.HersheyPlain, 1, new Scalar(0, 255, 0));
            //        Cv2.PutText(rightFrame, "d: detect and compute SIFT", new Point(30, 40), HersheyFonts.HersheyPlain, 1, new Scalar(0, 255, 0));

            //        leftCapWindow.ShowImage(leftFrame);
            //        rightCapWindow.ShowImage(rightFrame);

            //        var key = Cv2.WaitKey(1);

            //        if (key == 'd')
            //        {
            //            Cv2.CvtColor(leftFrame, leftGray, ColorConversionCodes.BGR2GRAY);
            //            Cv2.CvtColor(rightFrame, rightGray, ColorConversionCodes.BGR2GRAY);

            //            sift.DetectAndCompute(leftGray, null, out keypoints1, descriptors1);
            //            sift.DetectAndCompute(rightGray, null, out keypoints2, descriptors2);

            //            BFMatcher matcher = new BFMatcher(NormTypes.L2, false);
            //            DMatch[] matches = matcher.Match(descriptors1, descriptors2);

            //            Cv2.DrawMatches(leftGray, keypoints1, rightGray, keypoints2, matches, view);

            //            using (new Window("SIFT matching", WindowMode.AutoSize, view))
            //            {
            //                Cv2.WaitKey();
            //            }
            //        }
            //    }
            //}
            #endregion

            //視差マップ生成
            #region
            //var leftFrame = new Mat();
            //var rightFrame = new Mat();
            //var disparity = new Mat();

            //var leftGray = new Mat();
            //var rightGray = new Mat();

            //var sift = SIFT.Create();
            //KeyPoint[] keypoints1, keypoints2;
            //var descriptors1 = new Mat();
            //var descriptors2 = new Mat();

            //using (var leftCapWindow = new Window("left capture"))
            //using (var rightCapWindow = new Window("right capture"))
            //using (var leftVideo = new VideoCapture(1))
            //using (var rightVideo = new VideoCapture(0))
            //{
            //    while (true)
            //    {
            //        leftVideo.Read(leftFrame);
            //        rightVideo.Read(rightFrame);

            //        leftCapWindow.ShowImage(leftFrame);
            //        rightCapWindow.ShowImage(rightFrame);

            //        Cv2.CvtColor(leftFrame, leftGray, ColorConversionCodes.BGR2GRAY);
            //        Cv2.CvtColor(rightFrame, rightGray, ColorConversionCodes.BGR2GRAY);

            //        var stereo = StereoSGBM.Create(0, 16*10, 11, mode:StereoSGBMMode.HH);
            //        stereo.Compute(leftGray, rightGray, disparity);
            //        disparity.Normalize(alpha: 0, beta: 255, normType: NormTypes.MinMax, dtype: MatType.CV_8U);

            //        using (new Window("disparity map", WindowMode.AutoSize, disparity))
            //        {
            //            var key = Cv2.WaitKey(1);
            //            if (key == 'q')
            //                break;
            //        }
            //    }
            //}
            #endregion

            //もっとも簡単なStereoMatchingのTutorial
            #region
            //var imgL = new Mat(@"C:\Users\tyani\Downloads\scene1.row3.col1.png", ImreadModes.Grayscale);
            //var imgR = new Mat(@"C:\Users\tyani\Downloads\scene1.row3.col3.png", ImreadModes.Grayscale);
            //var disparity = new Mat();

            //var stereo = StereoBM.Create();
            //stereo.Compute(imgL, imgR, disparity);


            //using(new Window(disparity))
            //{
            //    Cv2.WaitKey(0);
            //}
            #endregion

            //ARマーカー
            #region

            using (var video0 = new VideoCapture(0))
            using (var video1 = new VideoCapture(1))
            using (var window0 = new Window("capture0"))
            using (var window1 = new Window("capture1"))
            {
                var dictionary = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
                var parameters = DetectorParameters.Create();

                var frames = new List<Mat> { new Mat(), new Mat()};
                var videos = new List<VideoCapture>();
                var windows = new List<Window>();

                Point2f[][] corners;
                int[] ids;
                int[] previousIds;
                Point2f[][] rejectedImgPoints;

                videos.Add(video0);
                videos.Add(video1);
                windows.Add(window0);
                windows.Add(window1);

                var wasFoundList = new List<bool> {false, false};
                var isTouchedList = new List<bool> {false, false};
                var wasTouched = false;

                while (true)
                {
                    for(int i = 0; i < 2; i++)
                    {
                        videos[i].Read(frames[i]);

                        CvAruco.DetectMarkers(frames[i], dictionary, out corners, out ids, parameters, out rejectedImgPoints);

                        isTouchedList[i] = wasFoundList[i] && !(ids.Length > 0);

                        if (ids.Length > 0)
                        {
                            wasFoundList[i] = true;
                            CvAruco.DrawDetectedMarkers(frames[i], corners, ids);
                        }
                        else
                        {
                            wasFoundList[i] = false;
                            isTouchedList[i] = true;
                        }

                        windows[i].ShowImage(frames[i]);
                    }

                    if (!isTouchedList.Contains(false))
                    {
                        if (!wasTouched)
                        {
                            Console.WriteLine("Hello world!");
                            for (int i = 0; i < isTouchedList.Count; i++)
                            {
                                isTouchedList[i] = false;
                            }
                        }
                        wasTouched = true;
                    }
                    else
                    {
                        wasTouched = false;
                    }

                    var key = Cv2.WaitKey(1);
                    if (key == 'q')
                    {
                        break;
                    }
                }
            }
            #endregion

            #region
            //var numCamera = 1;

            //var dictionary = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict7X7_50);
            //var parameters = DetectorParameters.Create();

            //var videoCaps = new List<VideoCapture>(numCamera);
            //var windows = new List<Window>(numCamera);

            //var capFrames = new List<Mat>(numCamera);
            ////var markerCornersList = new List<Point2f[][]>(numCamera);
            ////var markerIdsList = new List<int[]>(numCamera);
            ////var rejectedImgPointsList = new List<Point2f[][]>(numCamera);

            //var isFoundList = new List<bool>(numCamera);
            //var isTouchedList = new List<bool>(numCamera);

            //try
            //{
            //    for (int i = 0; i < numCamera; i++)
            //    {
            //        videoCaps.Add(new VideoCapture(i));
            //        windows.Add(new Window("VideoCapture" + i.ToString()));
            //    }

            //    while (true)
            //    {
            //        for (int i = 0; i < numCamera; i++)
            //        {
            //            var capFrame = new Mat();
            //            Point2f[][] markerCorners;
            //            int[] markerIds;
            //            Point2f[][] rejectedImgPoints;

            //            videoCaps[i].Read(capFrame);
            //            CvAruco.DetectMarkers(capFrame, dictionary, out markerCorners, out markerIds, parameters, out rejectedImgPoints);

            //            if (!isFoundList[i] && markerIds.Length > 0)
            //            {
            //                isFoundList[i] = true;
            //            }

            //            if (isFoundList[i] && !(markerIds[i] > 0))
            //            {
            //                isTouchedList[i] = true;
            //            }

            //            if (markerIds.Length > 0)
            //            {
            //                CvAruco.DrawDetectedMarkers(capFrame, markerCorners, markerIds);
            //            }

            //            windows[i].ShowImage(capFrame);
            //        }

            //        if (!isTouchedList.Contains(false))
            //        {
            //            Console.WriteLine("Hello world!");
            //        }

            //        var key = Cv2.WaitKey(1);
            //        if (key == 'q')
            //        {
            //            break;
            //        }
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("例外：カメラが取得できませんでした。");
            //}
            //finally
            //{
            //    for (int i = 0; i < numCamera; i++)
            //    {
            //        if (videoCaps[i] != null)
            //            videoCaps[i].Dispose();

            //        if (windows[i] != null)
            //        {
            //            windows[i].Dispose();
            //        }
            //    }
            //}

            //test

            #endregion
        }
    }
}
