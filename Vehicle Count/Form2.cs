﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Threading;
using Emgu.CV.VideoSurveillance;
using Emgu.CV.Cvb;
using Accord.Video.FFMPEG;
using Newtonsoft.Json;
using System.IO;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;

namespace Vehicle_Count
{
  
    public partial class Form2 : Form
    {
        #region
        Capture cap = new Capture();
        Mat frame = new Mat();
        Mat grayframe = new Mat();
        Mat clone = new Mat();
       
        int px1, px2, py1, py2;
        int carcount = 0;
        int clickcount = 1;
        int countBrd = 50;
        string Image_Name=null;
        bool firstCount = false;
        List<String> carid = new List<string>();
        private Image<Bgr, byte> currentframe = null;
        Point px, py;
        
        BackgroundSubtractorMOG2 sub = new BackgroundSubtractorMOG2();
        CvBlobDetector detect = new CvBlobDetector();
        CvBlobs blobs = new CvBlobs();
        CvTracks tracks = new CvTracks();
        Config cfg = new Config();
        Thread sendMail;

        private bool isRecording = false;
        private VideoFileWriter writer;
        private DateTime? firstFrameTime;
        
        #endregion
        public Form2()
        {
            InitializeComponent();

        }


        private void mp4_play()
        {

            cap = new Capture(textBox2.Text);
            cap.QueryFrame();

            cap.ImageGrabbed += ProcessFrameMP4;
            cap.Start();

        }

        private void ProcessFrameMP4(object sender, EventArgs e)
        {
            px = new Point(px1, px2);
            py = new Point(py1, py2);
            
            if (cap != null)
            {

                cap.Retrieve(frame, 0);
                currentframe = frame.ToImage<Bgr, byte>();


                Mat mask = new Mat();
                sub.Apply(currentframe, mask);

                Mat kernelOp = new Mat();
                Mat kernelCl = new Mat();
                Mat kernelEl = new Mat();
                Mat Dilate = new Mat();
                kernelOp = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
                kernelCl = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(11, 11), new Point(-1, -1));
                var element = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(3, 3), new Point(-1, -1));

                CvInvoke.GaussianBlur(mask, mask, new Size(13, 13), 1.5);
                CvInvoke.MorphologyEx(mask, mask, MorphOp.Open, kernelOp, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                CvInvoke.MorphologyEx(mask, mask, MorphOp.Close, kernelCl, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                CvInvoke.Dilate(mask, mask, element, new Point(-1, -1), 1, BorderType.Reflect, default(MCvScalar));
                CvInvoke.Threshold(mask, mask, 127, 255, ThresholdType.Binary);

                detect.Detect(mask.ToImage<Gray, byte>(), blobs);
                blobs.FilterByArea(500, 20000);
                tracks.Update(blobs, 20.0, 1, 10);

                Image<Bgr, byte> result = new Image<Bgr, byte>(currentframe.Size);
                using (Image<Gray, Byte> blobMask = detect.DrawBlobsMask(blobs))
                {
                    frame.CopyTo(result, blobMask);
                }
                CvInvoke.Line(currentframe, px, py, new MCvScalar(0, 0, 255), 2);

                foreach (KeyValuePair<uint, CvTrack> pair in tracks)
                {
                    if (pair.Value.Inactive == 0) //only draw the active tracks.
                    {

                        int cx = Convert.ToInt32(pair.Value.Centroid.X);
                        int cy = Convert.ToInt32(pair.Value.Centroid.Y);

                        CvBlob b = blobs[pair.Value.BlobLabel];
                        Bgr color = detect.MeanColor(b, frame.ToImage<Bgr, Byte>());
                        result.Draw(pair.Key.ToString(), pair.Value.BoundingBox.Location, FontFace.HersheySimplex, 0.5, color);
                        currentframe.Draw(pair.Value.BoundingBox, new Bgr(0, 0, 255), 1);
                        Point[] contour = b.GetContour();
                        //result.Draw(contour, new Bgr(0, 0, 255), 1);

                        Point center = new Point(cx, cy);
                        CvInvoke.Circle(currentframe, center, 1, new MCvScalar(255, 0, 0), 2);

                        if (center.Y <= px.Y + 10 && center.Y > py.Y - 10 && center.X <= py.X && center.X > px.X)
                        {
                            if (pair.Key.ToString() != "")
                            {
                                if (!carid.Contains(pair.Key.ToString()))
                                {
                                    carid.Add(pair.Key.ToString());
                                    if (carid.Count == 20)
                                    {
                                        carid.Clear();
                                    }

                                    carcount++;

                                    if (carcount != countBrd+1 && carcount !=countBrd+2 && carcount != countBrd + 3 && carcount != countBrd + 4 && carcount != countBrd + 5)
                                    {
                                        //Json Logger
                                        Logs log = new Logs()
                                        {
                                            Date = DateTime.Now.ToString(),
                                            Id = carcount
                                        };
                                        string strResultJson = JsonConvert.SerializeObject(log);
                                        File.AppendAllText(cfg.LogSavePath + @"\log.json", strResultJson + Environment.NewLine);
                                    }
                                    


                                    
                                                                           

                                }

                            }

                            CvInvoke.Line(currentframe, px, py, new MCvScalar(0, 255, 0), 2);


                        }

                    }

                }


                CvInvoke.PutText(currentframe, "Count :" + carcount.ToString(), new Point(10, 25), FontFace.HersheySimplex, 1, new MCvScalar(255, 0,255), 2, LineType.AntiAlias);
                //Frame Rate
                double framerate = cap.GetCaptureProperty(CapProp.Fps);
                Thread.Sleep((int)(1000.0 / framerate));
                if (firstCount == false && carcount == countBrd)
                {
                    Image_Name = cfg.PhotoSavePath + @"\" + "Car" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg";
                    currentframe.Save(Image_Name);
                    sendMail = new Thread(SendMail);
                    sendMail.Start();
                    firstCount = true;

                }



                if (isRecording)
                {
                   
                    
                        if (firstFrameTime != null)
                        {
                            writer.WriteVideoFrame(currentframe.Bitmap, DateTime.Now - firstFrameTime.Value);
                        }
                        else
                        {
                            writer.WriteVideoFrame(currentframe.Bitmap);
                            firstFrameTime = DateTime.Now;
                       
                        }
                    
                }

                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = currentframe.Bitmap;

            }

        }

        private void rtsp_play()
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                
                cap = new Capture(textBox1.Text);
                cap.QueryFrame();
                
                cap.ImageGrabbed += ProcessFrameRTSP;
                cap.Start();
            }
        }

        private void ProcessFrameRTSP(object sender, EventArgs e)
        {

            Point px = new Point(px1, px2);
            Point py = new Point(py1, py2);

            if (cap != null)
            {

                cap.Retrieve(frame, 0);
                currentframe = frame.ToImage<Bgr, byte>();


                Mat mask = new Mat();
                sub.Apply(currentframe, mask);

                Mat kernelOp = new Mat();
                Mat kernelCl = new Mat();
                Mat kernelEl = new Mat();
                Mat Dilate = new Mat();
                kernelOp = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
                kernelCl = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(11, 11), new Point(-1, -1));
                var element = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(3, 3), new Point(-1, -1));

                CvInvoke.GaussianBlur(mask, mask, new Size(13, 13), 1.5);
                CvInvoke.MorphologyEx(mask, mask, MorphOp.Open, kernelOp, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                CvInvoke.MorphologyEx(mask, mask, MorphOp.Close, kernelCl, new Point(-1, -1), 1, BorderType.Default, new MCvScalar());
                CvInvoke.Dilate(mask, mask, element, new Point(-1, -1), 1, BorderType.Reflect, default(MCvScalar));
                CvInvoke.Threshold(mask, mask, 127, 255, ThresholdType.Binary);

                detect.Detect(mask.ToImage<Gray, byte>(), blobs);
                blobs.FilterByArea(100, int.MaxValue);
                tracks.Update(blobs, 20.0, 1, 10);

                Image<Bgr, byte> result = new Image<Bgr, byte>(currentframe.Size);
                using (Image<Gray, Byte> blobMask = detect.DrawBlobsMask(blobs))
                {
                    frame.CopyTo(result, blobMask);
                }
                CvInvoke.Line(currentframe, px, py, new MCvScalar(0, 0, 255), 1);
                foreach (KeyValuePair<uint, CvTrack> pair in tracks)
                {
                    if (pair.Value.Inactive == 0) //only draw the active tracks.
                    {

                        int cx = Convert.ToInt32(pair.Value.Centroid.X);
                        int cy = Convert.ToInt32(pair.Value.Centroid.Y);

                        CvBlob b = blobs[pair.Value.BlobLabel];
                        Bgr color = detect.MeanColor(b, frame.ToImage<Bgr, Byte>());
                        currentframe.Draw(pair.Value.BoundingBox, new Bgr(0, 0, 255), 1);
                        //Point[] contour = b.GetContour();
                        // result.Draw(contour, new Bgr(0, 0, 255), 1);

                        Point center = new Point(cx, cy);
                        CvInvoke.Circle(currentframe, center, 1, new MCvScalar(255, 0, 0), 2);
                        if (center.Y <= px.Y + 10 && center.Y > py.Y - 10 && center.X <= py.X && center.X > px.X)
                        {

                            if (pair.Key.ToString() != "")
                            {
                                if (!carid.Contains(pair.Key.ToString()))
                                {
                                    carid.Add(pair.Key.ToString());
                                    if (carid.Count == 20)
                                    {
                                        carid.Clear();
                                    }

                                    carcount++;
                                    Thread logTh = new Thread(SendMail);
                                    logTh.Start();

                                }

                            }
                            CvInvoke.Line(currentframe, px, py, new MCvScalar(0, 255, 0), 2);
                            

                            

                        }
                    }
                }

                if (isRecording)
                {


                    if (firstFrameTime != null)
                    {
                        writer.WriteVideoFrame(currentframe.Bitmap);
                    }
                    else
                    {
                        writer.WriteVideoFrame(currentframe.Bitmap);
                        firstFrameTime = DateTime.Now;

                    }

                }

                CvInvoke.PutText(currentframe, "Count :" + carcount.ToString(), new Point(10, 25), FontFace.HersheySimplex, 1, new MCvScalar(0, 255, 255), 2, LineType.AntiAlias);
                pictureBox1.Image = currentframe.Bitmap;
                
                if (firstCount == false && carcount == 15)
                {
                    Image_Name = cfg.PhotoSavePath + @"\" + "Car" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg";
                    currentframe.Save(Image_Name);

                    firstCount = true;
                }

                // Thread th = new Thread(currentframepicBoxRtsp);
                // th.Start();
            }

        }
       
        
        void SaveLogs()
        {

        }
        void SendMail()
        {

            MailMessage message = new MailMessage();
            message.To.Add(cfg.MailAddressTo);
            message.From = new MailAddress("ynsemrektk@hotmail.com");
            message.Subject = "Vehicle Counter Automation";
            message.Body = "Araba sayımız 50'ye ulaştığında bir ekran görüntüsü ile log'lar ektedir.";
            System.Net.Mail.Attachment att;
            System.Net.Mail.Attachment att2;
            att2 = new Attachment(cfg.LogSavePath + @"\log.json");
            att = new Attachment(Image_Name);
            message.Attachments.Add(att);
            message.Attachments.Add(att2);

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("ynsemrektk@hotmail.com", "Cimbom1905.");
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            client.Send(message);

            message.Dispose();

        }
        void StartRecording()
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "Video1";
            dialog.DefaultExt = ".bin";
            dialog.AddExtension = true;
            var dialogresult = dialog.ShowDialog();
            
            firstFrameTime = null;
            writer = new VideoFileWriter();
            writer.Open(dialog.FileName, frame.Width,frame.Height);
            isRecording = true;
            buttonRecStart.Text = "Recording...";
        }

        void StopRecording()
        {
            isRecording = false;
            writer.Close();
            writer.Dispose();
            buttonRecStart.Text = "Start Rec";
        }

        void SetLocation()
        {
            px1 = Convert.ToInt32(textBoxx1.Text);
            px2 = Convert.ToInt32(textBoxx2.Text);
            py1 = Convert.ToInt32(textBoxy1.Text);
            py2 = Convert.ToInt32(textBoxy2.Text);
        }
        
        private void CapStop()
        {
            cap.Stop();
            carcount = 0;
            carid.Clear();
        }

        void LoadBoxes()
        {
            

            textBoxx1.Text = Convert.ToString(100);
            textBoxx2.Text = Convert.ToString(200);
            textBoxy1.Text = Convert.ToString(550);
            textBoxy2.Text = Convert.ToString(200);

            textBox1.Text = cfg.RtspUrl;
            textBox2.Text = cfg.Mp4Path;

            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadBoxes();
        }     

        private void buttonRecStart_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        private void buttonSetLine_Click(object sender, EventArgs e)
        {
            SetLocation();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonMP4Play_Click(object sender, EventArgs e)
        {
            SetLocation();
            mp4_play();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            CapStop();
        }

        private void buttonRtspPlay_Click(object sender, EventArgs e)
        {
            SetLocation();
            rtsp_play();

        }

        private void buttonRecStop_Click(object sender, EventArgs e)
        {
            StopRecording();
        }

        void Reset()
        {
            carcount = 0;
            pictureBox1.Image = null;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (clickcount == 1)
            {
                textBoxx1.Text = e.X.ToString();
                textBoxx2.Text = e.Y.ToString();
                clickcount++;
                px = new Point(e.X, e.Y);
                
            }
            else if (clickcount == 2)
            {
                textBoxy1.Text = e.X.ToString();
                textBoxy2.Text = e.Y.ToString();
                clickcount--;
                py = new Point(e.X, e.Y);
            }
           
                        
         
        }


    }
   
}
