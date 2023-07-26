using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDTAnpr;
using System.Configuration;
using static System.Windows.Forms.AxHost;
using ANPR_General.Entity;
using Microsoft.Office.Interop.Excel;
using System.Drawing.Drawing2D;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;
using SimpleLPR3;

namespace ANPR_General
{
    public partial class frmANPR : Form
    {
        private AnprVideoEngine mAnprEngine1 ;
        private AnprParams mAnprParams1;

        private AnprVideoEngine mAnprEngine2;
        private AnprParams mAnprParams2;

        private AnprVideoEngine mAnprEngine3;
        private AnprParams mAnprParams3;

        private AnprVideoEngine mAnprEngine4;
        private AnprParams mAnprParams4;
        private bool FlagStart = false;

        private int ThersholdSeconds =0;

        private string _Last_NP1 = "";
        private DateTime _Last_NP_dt1 ;

        private string _Last_NP2 = "";
        private DateTime _Last_NP_dt2;

        private string _Last_NP3 = "";
        private DateTime _Last_NP_dt3;

        private string _Last_NP4 = "";
        private DateTime _Last_NP_dt4;

        private class ResultHandler : IDisposable
        {
            private string mText;
            private System.Drawing.Image mPreviewImage;


            public ResultHandler(string text, System.Drawing.Image preview, string camid, ref string _picpath)
            {
                mText = text;
                string imgpath = ConfigurationManager.AppSettings.Get("imgPath");
                imgpath = imgpath + "" + camid + "\\" + DateTime.Now.ToString("dd-MM-yy");

                bool exists = System.IO.Directory.Exists(imgpath);

                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(imgpath);
                }

                _picpath = imgpath + "\\" + text + "-" + DateTime.Now.ToString("HH-mm-ss") + ".jpg";

                _picpath = _picpath.Replace("?", "");

                if (preview != null)
                {
                    mPreviewImage = (System.Drawing.Image)preview.Clone();

                    //mPreviewImage.Save(_picpath);

                    var stream = new System.IO.MemoryStream();
                    mPreviewImage.Save(stream, ImageFormat.Jpeg);
                    stream.Position = 0;

                    //Stream strm = mPreviewImage.;
                    double compRatio = 0.3;
                    ReduceImageSize(compRatio, stream, _picpath);

                }

            }

            private void ReduceImageSize(double scaleFactor, Stream sourcePath, string targetPath)
            {
                using (var image = System.Drawing.Image.FromStream(sourcePath))
                {
                    var newWidth = (int)(image.Width * scaleFactor);
                    var newHeight = (int)(image.Height * scaleFactor);
                    var thumbnailImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbnailImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imageRectangle);
                    thumbnailImg.Save(targetPath, image.RawFormat);
                }
            }


            public override string ToString()
            {
                return mText;
            }

            #region IDisposable Members

            public void Dispose()
            {
                if (mPreviewImage != null)
                {
                    mPreviewImage.Dispose();
                }
            }

            #endregion

            public System.Drawing.Image PreviewImage { get { return mPreviewImage; } }

            public string Text { get { return mText; } }
        }

        public frmANPR()
        {
            InitializeComponent();
            mAnprEngine1 = new AnprVideoEngine("<Your Developer License Key>");
            // Activate Royalty free Client Runtime license
            if (!mAnprEngine1.GetLicManager().IsClientRuntimeLicenseActivatedBool())
            {
                mAnprEngine1.GetLicManager().ActivateClientRuntimeLicense();
            }
            mAnprParams1 = new AnprParams();
            mAnprEngine1.VideoRecognitionResults += new VideoRecognitionResultsEventHandler(anprEngine_VideoRecognitionResults1);


            mAnprEngine2 = new AnprVideoEngine("<Your Developer License Key>");
            // Activate Royalty free Client Runtime license
            if (!mAnprEngine2.GetLicManager().IsClientRuntimeLicenseActivatedBool())
            {
                mAnprEngine2.GetLicManager().ActivateClientRuntimeLicense();
            }
            mAnprParams2 = new AnprParams();
            mAnprEngine2.VideoRecognitionResults += new VideoRecognitionResultsEventHandler(anprEngine_VideoRecognitionResults2);


            mAnprEngine3 = new AnprVideoEngine("<Your Developer License Key>");
            // Activate Royalty free Client Runtime license
            if (!mAnprEngine3.GetLicManager().IsClientRuntimeLicenseActivatedBool())
            {
                mAnprEngine3.GetLicManager().ActivateClientRuntimeLicense();
            }
            mAnprParams3 = new AnprParams();
            mAnprEngine3.VideoRecognitionResults += new VideoRecognitionResultsEventHandler(anprEngine_VideoRecognitionResults3);


            mAnprEngine4 = new AnprVideoEngine("<Your Developer License Key>");
            // Activate Royalty free Client Runtime license
            if (!mAnprEngine4.GetLicManager().IsClientRuntimeLicenseActivatedBool())
            {
                mAnprEngine4.GetLicManager().ActivateClientRuntimeLicense();
            }
            mAnprParams4 = new AnprParams();
            mAnprEngine4.VideoRecognitionResults += new VideoRecognitionResultsEventHandler(anprEngine_VideoRecognitionResults4);


            // Load simple settings
            Configuration config = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.PerUserRoamingAndLocal);
            if (config != null)
            {
                //if (config.AppSettings.Settings["video_file"] != null)
                //    tbVideoFilePath.Text = config.AppSettings.Settings["video_file"].Value;

                //if (config.AppSettings.Settings["stream_url"] != null)
                //    tbStreamUrl.Text = config.AppSettings.Settings["stream_url"].Value;

                //if (config.AppSettings.Settings["video_device"] != null)
                //    cbVideoDevice.Text = config.AppSettings.Settings["video_device"].Value;

                //if (config.AppSettings.Settings["country_code"] != null)
                //    tbCountryCode.Text = config.AppSettings.Settings["country_code"].Value;

                //if (config.AppSettings.Settings["input_type"] != null &&
                //    config.AppSettings.Settings["input_type"].Value == "stream")
                //{
                //    rbVideoFile.Checked = false;
                //    rbStream.Checked = true;
                //    rbDevice.Checked = false;
                //}
                //else if (config.AppSettings.Settings["input_type"] != null &&
                //    config.AppSettings.Settings["input_type"].Value == "file")
                //{
                //    rbVideoFile.Checked = true;
                //    rbStream.Checked = false;
                //    rbDevice.Checked = false;
                //}
                //else if (config.AppSettings.Settings["input_type"] != null &&
                //    config.AppSettings.Settings["input_type"].Value == "device")
                //{
                //    rbVideoFile.Checked = false;
                //    rbStream.Checked = false;
                //    rbDevice.Checked = true;
                //}
            }
        }

        delegate void onVideoRecognitionResultsDelegate1(AnprResultsEventArgs eventArgs);
        delegate void onVideoRecognitionResultsDelegate2(AnprResultsEventArgs eventArgs);
        delegate void onVideoRecognitionResultsDelegate3(AnprResultsEventArgs eventArgs);
        delegate void onVideoRecognitionResultsDelegate4(AnprResultsEventArgs eventArgs);

        void anprEngine_VideoRecognitionResults1(object sender, AnprResultsEventArgs eventArgs)
        {
            try
            {

            
                if (this.InvokeRequired)
                {
                    this.Invoke(new onVideoRecognitionResultsDelegate1(onVideoRecognitionResults1), eventArgs);
                }
                else
                {
                    onVideoRecognitionResults1(eventArgs);
                }
            }
            catch(Exception ex)
            {

            }
        }

        void anprEngine_VideoRecognitionResults2(object sender, AnprResultsEventArgs eventArgs)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new onVideoRecognitionResultsDelegate2(onVideoRecognitionResults2), eventArgs);
                }
                else
                {
                    onVideoRecognitionResults2(eventArgs);
                }
            }
            catch (Exception ex)
            {

            }
        }

        void anprEngine_VideoRecognitionResults3(object sender, AnprResultsEventArgs eventArgs)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new onVideoRecognitionResultsDelegate3(onVideoRecognitionResults3), eventArgs);
                }
                else
                {
                    onVideoRecognitionResults3(eventArgs);
                }
            }
            catch (Exception ex)
            {

            }
        }

        void anprEngine_VideoRecognitionResults4(object sender, AnprResultsEventArgs eventArgs)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new onVideoRecognitionResultsDelegate4(onVideoRecognitionResults4), eventArgs);
                }
                else
                {
                    onVideoRecognitionResults4(eventArgs);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private ANPRDetail GetLastNPDetail(int camid, string np)
        {
            ANPRDetail anpr = new ANPRDetail();
            try
            {
                anpr.ANPR_NumberPlate = "";

                DAL dAL = new DAL();
                DataSet ds;

                ds = dAL.Read_LastNumberPlate(camid, np);

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    anpr.ANPR_NumberPlate = dr["ANPR_NumberPlate"].ToString();
                    anpr.ANPR_Time = Convert.ToDateTime( dr["ANPR_Time"].ToString());
                }


            }
            catch (Exception ex)
            {

            }

            return anpr;
        }

        void onVideoRecognitionResults1(AnprResultsEventArgs eventArgs)
        {
            if (eventArgs.Results == null)
                return;

            long resultsCount = eventArgs.Results.Length;

            for (Int32 i = 0; i < resultsCount; i++)
            {
                string resultValue = eventArgs.Results[i].Text;
                string _orgNumPlate = eventArgs.Results[i].Text;
                string resultCC = eventArgs.Results[i].CountryCode;
                double _conf = eventArgs.Results[i].Confidence;

                //if (resultCC != "")
                //{
                //    resultValue += "{" + resultCC + "}";
                //}
                    
                if (resultValue != null)
                {
                    resultValue = resultValue.Replace("$", "");
                    _orgNumPlate= _orgNumPlate.Replace("$", "");

                    if (Validate_Np(_orgNumPlate, _conf,1))
                        {
                            string _Currt_NP = "";
                            DateTime _Currt_NP_dt = DateTime.Now;

                            bool Flgvalidate_NP = true;
                            _Currt_NP = resultValue;

                        //if (_Currt_NP == _Last_NP1)
                        //{
                        //    Flgvalidate_NP = false;
                        //    TimeSpan ts = _Currt_NP_dt - _Last_NP_dt1;

                        //    if (ts.TotalSeconds > ThersholdSeconds)
                        //    {
                        //        Flgvalidate_NP = true;
                        //    }
                        //}


                        if (Flgvalidate_NP)
                            {
                                int _anpr_id = 0;
                                string _picPath="";

                                    // Create and store recognition result and image.
                                    ResultHandler resultHandler = new ResultHandler(_orgNumPlate,
                                        eventArgs.FrameImage, "Cam-1",ref _picPath);

                                _anpr_id = Save_ANPRData(resultValue, 1, _picPath, _conf);
                            }

                            _Last_NP1 = resultValue;
                            _Last_NP_dt1 = DateTime.Now;
                        }
                    
                }
            }
        }
        void onVideoRecognitionResults2(AnprResultsEventArgs eventArgs)
        {
            if (eventArgs.Results == null)
                return;

            long resultsCount = eventArgs.Results.Length;

            for (Int32 i = 0; i < resultsCount; i++)
            {
                string resultValue = eventArgs.Results[i].Text;
                string _orgNumPlate = eventArgs.Results[i].Text;
                string resultCC = eventArgs.Results[i].CountryCode;
                double _conf = eventArgs.Results[i].Confidence;

                //if (resultCC != "")
                //{
                //    resultValue += "{" + resultCC + "}";
                //}

                if (resultValue != null)
                {
                    resultValue = resultValue.Replace("$", "");
                    _orgNumPlate = _orgNumPlate.Replace("$", "");

                    if (Validate_Np(_orgNumPlate, _conf,2))
                        {
                            string _Currt_NP = "";
                            DateTime _Currt_NP_dt = DateTime.Now;
                            bool Flgvalidate_NP = true;


                            _Currt_NP = resultValue;

                            //if (_Currt_NP == _Last_NP2)
                            //{
                            //    Flgvalidate_NP = false;
                            //    TimeSpan ts = _Currt_NP_dt - _Last_NP_dt2;

                            //    if (ts.TotalSeconds > ThersholdSeconds)
                            //    {
                            //        Flgvalidate_NP = true;
                            //    }
                            //}


                            if (Flgvalidate_NP)
                            {
                                    int _anpr_id = 0;
                                    string _picPath = "";

                                    // Create and store recognition result and image.
                                    ResultHandler resultHandler = new ResultHandler(_orgNumPlate,
                                        eventArgs.FrameImage, "Cam-2", ref _picPath);

                                    _anpr_id = Save_ANPRData(resultValue, 2, _picPath, _conf);
                            }

                            _Last_NP2 = resultValue;
                            _Last_NP_dt2 = DateTime.Now;
                        }
                }
            }
        }
        void onVideoRecognitionResults3(AnprResultsEventArgs eventArgs)
        {
            if (eventArgs.Results == null)
                return;

            long resultsCount = eventArgs.Results.Length;

            for (Int32 i = 0; i < resultsCount; i++)
            {
                string resultValue = eventArgs.Results[i].Text;
                string _orgNumPlate = eventArgs.Results[i].Text;
                string resultCC = eventArgs.Results[i].CountryCode;
                double _conf = eventArgs.Results[i].Confidence;

                //if (resultCC != "")
                //{
                //    resultValue += "{" + resultCC + "}";
                //}


                if (resultValue != null)
                {
                    resultValue = resultValue.Replace("$", "");
                    _orgNumPlate = _orgNumPlate.Replace("$", "");
                    if (Validate_Np(_orgNumPlate, _conf,3))
                        {
                            string _Currt_NP = "";
                            DateTime _Currt_NP_dt = DateTime.Now;
                            bool Flgvalidate_NP = true;


                            _Currt_NP = resultValue;

                            if (_Currt_NP == _Last_NP3)
                            {
                                Flgvalidate_NP = false;
                                TimeSpan ts = _Currt_NP_dt - _Last_NP_dt3;

                                if (ts.TotalSeconds > ThersholdSeconds)
                                {
                                    Flgvalidate_NP = true;
                                }
                            }

                            if (Flgvalidate_NP)
                            {
                                int _anpr_id = 0;
                                string _picPath = "";

                                // Create and store recognition result and image.
                                ResultHandler resultHandler = new ResultHandler(_orgNumPlate,
                                    eventArgs.FrameImage, "Cam-3", ref _picPath);

                                _anpr_id = Save_ANPRData(resultValue, 3, _picPath, _conf);
                            }

                            _Last_NP3 = resultValue;
                            _Last_NP_dt3 = DateTime.Now;
                        }
                }
            }
        }
        void onVideoRecognitionResults4(AnprResultsEventArgs eventArgs)
        {
            if (eventArgs.Results == null)
                return;

            long resultsCount = eventArgs.Results.Length;

            for (Int32 i = 0; i < resultsCount; i++)
            {
                string resultValue = eventArgs.Results[i].Text;
                string _orgNumPlate = eventArgs.Results[i].Text;
                string resultCC = eventArgs.Results[i].CountryCode;


                double _conf = eventArgs.Results[i].Confidence;
                //if (resultCC != "")
                //{
                //    resultValue += "{" + resultCC + "}";
                //}



                if (resultValue != null)
                {
                    resultValue = resultValue.Replace("$", "");
                    _orgNumPlate = _orgNumPlate.Replace("$", "");
                    if (Validate_Np(_orgNumPlate, _conf,4))
                   {
                       string _Currt_NP = "";
                       DateTime _Currt_NP_dt = DateTime.Now;
                       bool Flgvalidate_NP = true;

                       _Currt_NP = resultValue;

                       if (_Currt_NP == _Last_NP4)
                            {
                                Flgvalidate_NP = false;
                                TimeSpan ts = _Currt_NP_dt - _Last_NP_dt4;

                                if (ts.TotalSeconds > ThersholdSeconds)
                                {
                                    Flgvalidate_NP = true;
                                }
                            }

                       if (Flgvalidate_NP)
                            {
                                int _anpr_id = 0;
                                string _picPath = "";

                                // Create and store recognition result and image.
                                ResultHandler resultHandler = new ResultHandler(_orgNumPlate,
                                    eventArgs.FrameImage, "Cam-4", ref _picPath);

                                _anpr_id = Save_ANPRData(resultValue, 4, _picPath, _conf);
                        }

                       _Last_NP4 = resultValue;
                       _Last_NP_dt4 = DateTime.Now;
                   }
                    
                }
            }
        }

        private bool Validate_Np(string _np,double _conf,int camid)
        {
            bool FlgVald = false;
            double _req_conf = 0;

            if (IsDouble(txtConfd.Text))
            {
                _req_conf = Convert.ToDouble(txtConfd.Text);
            }

           
            if (chkFiltercity.Checked==false)
            {
                if (IsNumeric(_np.Substring(0, 2)) && IsNumeric(_np.Substring(_np.Length - 2, 2)))
                {
                    FlgVald = true;
                }
                else
                {
                    FlgVald = false;
                    return FlgVald;
                }
            }
            

            //********* Check Confidence level . this is last check 
            if (_conf >= _req_conf)
            {
                FlgVald = true;
            }
            else
            {
                FlgVald = false;
                return FlgVald;
            }

            if (_np.Length > 5)
            {
                FlgVald = true;
            }
            else
            {
                FlgVald = false;
                return FlgVald;
            }

            //******* Check Duplicate *****

            string _Currt_NP = "";
            DateTime _Currt_NP_dt = DateTime.Now;

            _Currt_NP = _np;
            ANPRDetail anpr;

            anpr= GetLastNPDetail(camid, _Currt_NP);

            if (anpr!=null)
            {
                if(anpr.ANPR_NumberPlate!="")
                {
                    TimeSpan ts = _Currt_NP_dt - anpr.ANPR_Time;

                    if (ts.TotalSeconds > ThersholdSeconds)
                    {
                        FlgVald = true;
                    }
                    else
                    {
                        FlgVald = false;
                    }
                    
                }

            }


            return FlgVald;
        }

        private int Save_ANPRData(string _np,int _cameraid,string _picPath,double _conf)
        {
            int anpr_id=0;

            try
            {


                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_VehicleCode(_np);
                int lst_Code = 0;
                int vhc_id = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst_Code =Convert.ToInt16( dr["vhc_ListCode"].ToString());
                    vhc_id = Convert.ToInt16(dr["vhc_Id"].ToString());
                }

                System.Drawing.Image image;

                System.Drawing.Image image1;
                image1 = Properties.Resources.green_circle;

                System.Drawing.Image image2;
                image2 = Properties.Resources.red_circle;

                System.Drawing.Image image3;
                image3 = Properties.Resources.yellow_circle;

                image = image3;

                if (lst_Code == 1)
                {
                    image = image1;
                }
                if (lst_Code == 2)
                {
                    image = image2;
                }
                if (lst_Code == 3)
                {
                    image = image3;
                }
                MessageBox.Show("np is :tag1" + _np);
                gridList.Rows.Add(image, _np,DateTime.Now.ToString("dd-MM-yy HH:mm:ss"));

                
                ANPRDetail A = new ANPRDetail();

                A.Cam_Id = _cameraid;
                A.vhc_Id = vhc_id;
                A.vhc_ListCode=lst_Code;
                A.ANPR_NumberPlate = _np;
                A.Pic_Path = _picPath;
                A.Confidence_Level = _conf;

                string err = dal.SaveANPR(A,ref anpr_id,0);

                if (err!="")
                {
                    MessageBox.Show(err);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

            return anpr_id;
        }
        private void SetStatus()
        {
            if (!FlagStart)
            {
                btnPlay.Enabled = true;
                btnStop.Enabled = false;
            }
            else
            {
                btnPlay.Enabled = false;
                btnStop.Enabled = true;
            }

        }

        private void Set_Grid()
        {
           
            // Icon treeIcon = new Icon(this.GetType(), Properties.Resources.circle_32);
            DataGridViewImageColumn dgvImageColumn = new DataGridViewImageColumn();
            dgvImageColumn.HeaderText = "";
            dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.NotSet;

            DataGridViewTextBoxColumn dgvNoPlateColumn = new DataGridViewTextBoxColumn();
            dgvNoPlateColumn.HeaderText = "Number Plate";

            DataGridViewTextBoxColumn dgvdtColumn = new DataGridViewTextBoxColumn();
            dgvdtColumn.HeaderText = "Date Time";

            //gridList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gridList.RowTemplate.Height = 30;
            gridList.AllowUserToAddRows = false;
           
            gridList.Columns.Add(dgvImageColumn);
            gridList.Columns.Add(dgvNoPlateColumn);
            gridList.Columns.Add(dgvdtColumn);

            gridList.Columns[0].Width = 30;
            gridList.Columns[1].Width = 180;
            gridList.Columns[2].Width = 100;




        }

        private void StoreResultInList(ResultHandler resultHandler)
        {
            // Avoid unlimited memory usage
            //while (listBoxResults.Items.Count > 32)
            //{
            //    ResultHandler resultToDel = (ResultHandler)listBoxResults.Items[0];
            //    resultToDel.Dispose();
            //    listBoxResults.Items.RemoveAt(0);
            //}
            //listBoxResults.Items.Add(resultHandler);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            
            ProcessANPVideoStream();
            FlagStart = true;
            SetStatus();
            
        }


        private void ProcessANPVideoStream()
        {

            try
            {


                if (mAnprEngine1 == null)
                {
                    return;
                }
                Set_Grid();

                string streamURL1 = "rtsp://admin:ms123456@31.223.20.141:1161/main";
                string streamURL2 = "rtsp://admin:ms123456@31.223.20.141:1161/main";
                string streamURL3 = "rtsp://admin:ms123456@31.223.20.141:1161/main";
                string streamURL4 = "rtsp://admin:ms123456@31.223.20.141:1161/main";
                int _thersholdSeconds = 0;
              

               streamURL1 = ConfigurationManager.AppSettings.Get("camer1URL");
                streamURL2 = ConfigurationManager.AppSettings.Get("camer1URL");
                streamURL3 = ConfigurationManager.AppSettings.Get("camer1URL");
                streamURL4 = ConfigurationManager.AppSettings.Get("camer1URL");

                string isvideoURL =  ConfigurationManager.AppSettings.Get("camer1VideoEnable");
                string camer1VideoURL = ConfigurationManager.AppSettings.Get("camer1VideoURL");


                _thersholdSeconds = Convert.ToInt16( ConfigurationManager.AppSettings.Get("thersholdsecond"));
                ThersholdSeconds = _thersholdSeconds;

                string CountryCode = "";

                CountryCode = txtCountryCode.Text;

                int streamType = -1;
                string streamPath = "";
                streamType = AnprVideoStreamType.STREAM;
                streamPath = streamURL1;


                int fps = 20;

                fps = Convert.ToInt32(txtFPS.Text);

                //***************** Camera 1 *******************
                // Apply Parameters
                if (chkCam1.Checked)
                {
                    if (isvideoURL == "1")
                    {
                        streamType = AnprVideoStreamType.FILE;
                        streamPath = camer1VideoURL;
                    }

                    mAnprParams1.CountryCodes = CountryCode;
                    mAnprParams1.ColorSchema = AnprColorSchema.AUTO;
                    mAnprEngine1.Init(mAnprParams1);

                    mAnprEngine1.EnableSoftwarePreviewRendering(chkPreviewEnable.Checked, fps, chkInteractive.Checked);
                    mAnprEngine1.ReadVideoStream(streamType, streamPath, videoPreviewParent1);

                }

                //***************** Camera 2 *******************
                // Apply Parameters
                if (chkCam2.Checked)
                {
                    streamType = AnprVideoStreamType.STREAM;
                    streamPath = streamURL2;
                    mAnprParams2.CountryCodes = CountryCode;
                    mAnprParams2.ColorSchema = AnprColorSchema.AUTO;
                    mAnprEngine2.Init(mAnprParams2);

                    mAnprEngine2.EnableSoftwarePreviewRendering(chkPreviewEnable.Checked, fps, chkInteractive.Checked);
                    mAnprEngine2.ReadVideoStream(streamType, streamPath, videoPreviewParent2);
                }
                ////***************** Camera 3 *******************
                //// Apply Parameters
                ///
                if (chkCam3.Checked)
                {
                    streamType = AnprVideoStreamType.STREAM;
                    streamPath = streamURL3;
                    mAnprParams3.CountryCodes = CountryCode;
                    mAnprParams3.ColorSchema = AnprColorSchema.AUTO;
                    mAnprEngine3.Init(mAnprParams3);

                    mAnprEngine3.EnableSoftwarePreviewRendering(chkPreviewEnable.Checked, fps, chkInteractive.Checked);
                    mAnprEngine3.ReadVideoStream(streamType, streamPath, videoPreviewParent3);
                }
                ////***************** Camera 4 *******************
                //// Apply Parameters
                ///
                if (chkCam4.Checked)
                {
                    streamType = AnprVideoStreamType.STREAM;
                    streamPath = streamURL4;
                    mAnprParams4.CountryCodes = CountryCode;
                    mAnprParams4.ColorSchema = AnprColorSchema.AUTO;
                    mAnprEngine4.Init(mAnprParams4);

                    mAnprEngine4.EnableSoftwarePreviewRendering(chkPreviewEnable.Checked, fps, chkInteractive.Checked);
                    mAnprEngine4.ReadVideoStream(streamType, streamPath, videoPreviewParent4);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"System Error");
            }

        }

       
        
        private void btnStop_Click(object sender, EventArgs e)
        {

            StopProcessing();
            FlagStart = false;
            SetStatus();
        }

        public bool IsNumeric(string value)
        {
            if (value=="")
            {
                return false;
            }
            return value.All(char.IsNumber);
        }
        public bool IsDouble(string _value)
        {
            bool flg = false;
            double price;

            bool isDouble = Double.TryParse(_value, out price);
            if (isDouble)
            {
                flg = true;
            }

            return flg;
        }
       
        
        private void StopProcessing()
        {

            if (mAnprEngine1 != null)
            {
                mAnprEngine1.Reset();
            }

            if (mAnprEngine2 != null)
            {
                mAnprEngine2.Reset();
            }

            if (mAnprEngine3 != null)
            {
                mAnprEngine3.Reset();
            }

            if (mAnprEngine4 != null)
            {
                mAnprEngine4.Reset();
            }
  
        }

        private void frmANPR_Load(object sender, EventArgs e)
        {
            SetStatus();

            string Count_Code;

            Count_Code = ConfigurationManager.AppSettings.Get("CountryCode");
            txtCountryCode.Text = Count_Code;
        }

        private void frmANPR_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopProcessing();
        }

        private void frmANPR_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopProcessing();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
