using ANPR_General.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ANPR_General.Services;
using DataModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using iTextSharp.text.pdf.parser;

namespace ANPR_General
{
    public partial class frmSetting : Form
    {
        bool FlgEngl;
        Communication c;
        private bool FlagIsLangEngl = false;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeft,
            int nTop,
            int nRight,
            int nBottom,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public frmSetting()
        {
            InitializeComponent();
        }

        private void Set_Lang()
        {

            Communication c = new Communication();
             FlgEngl = c.IsLangEnglish();

            if (FlgEngl)
            {
                //btnPlay.Text = "Start";
                //btnStop.Text = "Stop";
            }

        }

        private void ClearCamera()
        {
            txtCameraName.Text = "";
            cmbEntryType.SelectedValue = 1;
            txtCameraURL.Text = "";
            txtIP.Text = "";
            txtCam_UserId.Text = "";
            txtCam_Password.Text = "";
            txtThershold.Text = "5";
            chkEnable.Checked = true;
            chkRecording.Checked = false;
            txtCameraId.Text = "0";
            //chkStartUp.Checked = true;
            txtResl_Height.Text = "720";
            txtResl_Width.Text = "480";

            txtRecordingPath.Text = ""; 
            txtANPRPath.Text = "";
            //txtDeleteMotionImg_Hours.Text = "0";
        }

        private void ClearUser()
        {
            txtUserName.Text = "";
            txtUserFName.Text = "";
            txtUserLastName.Text = "";
            txtUserEmail.Text = "";
            txtUserPwd.Text = "";
            chkIsActive_User.Checked = true;
            cmbUserRole.SelectedValue = 1;
            txtUserId.Text = "0";

        }


        private void ClearDevice()
        {
            txtDev_Id.Text = "0";
            txtDevId_Str.Text = "";
            txtDevName.Text = "";
            txtDevDesc.Text = "";
            txtCh0.Text = "";
            txtCh1.Text = "";
            txtCh2.Text = "";
            txtCh2.Text = "";
            txtDeviceLocalIP.Text = "";

        }

        private void ClearDeviceTrigger()
        {
            cmbCameralst.SelectedIndex = 0;
            cmbDevicelst.SelectedIndex = 0;
            cmbRelayChannel.SelectedIndex = 0;
            cmbLstType.SelectedIndex = 0;
            optCloud.Checked = true;
            txtTriggerId.Text = "0";
        }
        private void GetCamera_Grid()
        {
            try
            {

                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_CameraInfo();
                gv_CameraList.DataSource = ds.Tables[0];

                gv_CameraList.Columns["Cam_Id"].HeaderText = "Id";
                gv_CameraList.Columns["Cam_Name"].HeaderText = "Cam Name";
                gv_CameraList.Columns["Cam_Direction"].HeaderText = "Cam Direction";
                gv_CameraList.Columns["Cam_StreamURL"].HeaderText = "Stream Url";
                gv_CameraList.Columns["ThersholdSeconds"].HeaderText = "Same Plate Time";
                gv_CameraList.Columns["Cam_Enable"].HeaderText = "Cam Enable";
                gv_CameraList.Columns["Cam_IP"].HeaderText = "IP";
                gv_CameraList.Columns["User_Name"].HeaderText = "User";
                gv_CameraList.Columns["User_Password"].HeaderText = "Password";

                gv_CameraList.Columns["Resolut_Width"].HeaderText = "Resolut Width ( X )";
                gv_CameraList.Columns["Resolut_Height"].HeaderText = "Resolut Height ( Y )";

                gv_CameraList.Columns["RecordingPath"].HeaderText = "Recording Path";
                gv_CameraList.Columns["ANPRImagePath"].HeaderText = "Image Path";
                gv_CameraList.Columns["RecordingDeleteHours"].HeaderText = "Recording Delete Hours";

                gv_CameraList.Columns["Cam_DirectionCode"].Visible = false;

                gv_CameraList.Columns["ThersholdSeconds"].Width = 100;
                gv_CameraList.Columns["Cam_StreamURL"].Width = 250;
                gv_CameraList.Columns["Cam_Name"].Width = 150;
                gv_CameraList.Columns["Cam_Enable"].Width = 80;
                gv_CameraList.Columns["Cam_IP"].Width = 80;
                gv_CameraList.Columns["Cam_Direction"].Width = 150;

                gv_CameraList.Columns["Cam_Id"].Width = 30;
                gv_CameraList.ReadOnly = true;

                Read_Config();
                FillDropDown();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void GetUsers_Grid()
        {
            try
            {

                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_AllUsers();
                gv_UserList.DataSource = ds.Tables[0];

                gv_UserList.Columns["UserId"].HeaderText = "UserId";
                gv_UserList.Columns["FirstName"].HeaderText = "First Name";
                gv_UserList.Columns["LastName"].HeaderText = "Last Name";
                gv_UserList.Columns["UserName"].HeaderText = "User Name";
                gv_UserList.Columns["UserRole"].HeaderText = "User Role";
                gv_UserList.Columns["Is_Active"].HeaderText = "Is Active";

                gv_UserList.Columns["UserName"].Width = 100;
                gv_UserList.Columns["FirstName"].Width = 350;
                gv_UserList.Columns["LastName"].Width = 150;
                gv_UserList.Columns["UserRole"].Width = 80;
                gv_UserList.Columns["Is_Active"].Width = 70;
               
                gv_UserList.Columns["UserId"].Width = 80;

                gv_UserList.Columns["RoleId"].Visible = false;

                gv_UserList.ReadOnly = true;

                Read_Config();
                FillDropDown();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void GetDevice_Grid()
        {
            try
            {


                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_AllDevices();
                gv_Devicelst.DataSource = ds.Tables[0];

                gv_Devicelst.Columns["Dev_Id"].HeaderText = "Device Id";
                gv_Devicelst.Columns["Dev_Name"].HeaderText = "Name";
                gv_Devicelst.Columns["Dev_Descrp"].HeaderText = "Description";
                gv_Devicelst.Columns["Chanel_0"].HeaderText = "Chanel 0";
                gv_Devicelst.Columns["Chanel_1"].HeaderText = "Chanel 1";
                gv_Devicelst.Columns["Chanel_2"].HeaderText = "Chanel 2";
                gv_Devicelst.Columns["Dev_LocalIP"].HeaderText = "Local IP";

                gv_Devicelst.Columns["Dev_Id"].Width = 100;
                gv_Devicelst.Columns["Dev_Name"].Width = 250;
                gv_Devicelst.Columns["Dev_Descrp"].Width = 250;
                gv_Devicelst.Columns["Chanel_0"].Width = 80;
                gv_Devicelst.Columns["Chanel_1"].Width = 70;
                gv_Devicelst.Columns["Chanel_2"].Width = 80;

                gv_Devicelst.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void GetDeviceTriger_Grid()
        {
            try
            {

                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_DevicesTrg();
                gv_Devicetrigger.DataSource = ds.Tables[0];

                //gv_Devicelst.Columns["Dev_Id"].HeaderText = "Device Id";
                //gv_Devicelst.Columns["Dev_Name"].HeaderText = "Name";
                //gv_Devicelst.Columns["Dev_Descrp"].HeaderText = "Description";
                //gv_Devicelst.Columns["Chanel_0"].HeaderText = "Chanel 0";
                //gv_Devicelst.Columns["Chanel_1"].HeaderText = "Chanel 1";
                //gv_Devicelst.Columns["Chanel_2"].HeaderText = "Chanel 2";

                //gv_Devicelst.Columns["Dev_Id"].Width = 100;
                //gv_Devicelst.Columns["Dev_Name"].Width = 250;
                //gv_Devicelst.Columns["Dev_Descrp"].Width = 250;
                //gv_Devicelst.Columns["Chanel_0"].Width = 80;
                //gv_Devicelst.Columns["Chanel_1"].Width = 70;
                //gv_Devicelst.Columns["Chanel_2"].Width = 80;

                gv_Devicetrigger.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void GetComp_Info()
        {
            try
            {


                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_CompInfo();
              
                foreach(DataRow dr in ds.Tables[0].Rows )
                {
                    txtEmail.Text = dr["Email"].ToString();
                    txtTelephone.Text = dr["Telephone"].ToString();
                    txtWebPage.Text = dr["WebPage"].ToString();
                    txtYoutube.Text = dr["Youtube"].ToString();
                    txtUserGuide.Text = dr["UserGuide"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

        }

        private void GetSMTP_Info()
        {
            try
            {


                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_SMTP();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtSMTPServer.Text = dr["SMTP_Server"].ToString();
                    txtPort.Text = dr["SMTP_Port"].ToString();
                    txtSMTPUserName.Text = dr["User_Name"].ToString();
                    txtSMTP_Password.Text = dr["User_Password"].ToString();
                    txtSMTPEmail.Text = dr["SMTP_Email"].ToString();
                    txt_SenderEmail.Text = dr["Sender_Email"].ToString();

                    chkBlackList.Checked = Convert.ToBoolean(dr["BlackList_Email"].ToString());
                    chkSSL.Checked = Convert.ToBoolean(dr["Enable_SSL"].ToString());

                    if (dr["Email_Frequency"].ToString()=="1")
                    {
                        chkDailyEmail.Checked = true;
                    }
                    else
                    {
                        chkDailyEmail.Checked = false;
                    }
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void GetCaptureSetting_Info()
        {
            try
            {


                DAL dal = new DAL();
                DataSet dsCapt = new DataSet();
                DataSet dsPrc_trg = new DataSet();

                dsCapt = dal.Read_CaptureSetting();

                foreach (DataRow dr in dsCapt.Tables[0].Rows)
                {
                    double hours = Convert.ToDouble(dr["AccuracyLevel"].ToString());

                    txtAccuracyLevel.Text = hours.ToString();

                }

                dsPrc_trg = dal.Read_ProcessTrigger("motion_img");

                foreach (DataRow dr in dsPrc_trg.Tables[0].Rows)
                {
                    
                    txtDeleteMotionImg_Hours.Text = dr["TriggerTime_hours"].ToString();
                }

                dsPrc_trg = dal.Read_ProcessTrigger("Recording_img");

                foreach (DataRow dr in dsPrc_trg.Tables[0].Rows)
                {

                    txtDeleteRecordingImg_Hours.Text = dr["TriggerTime_hours"].ToString();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }


        private void Read_Config()
        {
            try
            {
                //string imgpath = ConfigurationManager.AppSettings.Get("logoPath");
                string appName = ConfigurationManager.AppSettings.Get("AppName");
                string lang = ConfigurationManager.AppSettings.Get("langCode");
                string path = ConfigurationManager.AppSettings.Get("WebImage");

                string imgpath = c.Get_Path(Communication.PathType.Logo);
                string imgfilepath = imgpath + "logo.png";


                txtWebImage.Text = path;

                if (File.Exists(imgfilepath))
                {
                    Image img;

                    img = Image.FromFile(imgfilepath);

                    if (imgpath != "")
                    {
                        picLogo.Image = img;
                    }

                }


                if (lang=="1")
                {
                    OptTurkish.Checked = true;
                }
                else
                {
                    optEngl.Checked = true;
                }

                picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                txtAppName.Text = appName;

                //img.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void Set_Config()
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void SaveCamera_Data()
        {
            try
            {
                if (Validate_Channels())
                {

                    if (txtResl_Height.Text == "")
                    {
                        txtResl_Height.Text = "0";
                    }

                    if (txtResl_Width.Text == "")
                    {
                        txtResl_Width.Text = "0";
                    }


                    CameraInfo c = new CameraInfo();

                    c.CamId = Convert.ToInt32(txtCameraId.Text);
                    c.CamName = txtCameraName.Text;
                    c.CamDirectionCode = Convert.ToInt32(cmbEntryType.SelectedValue);
                    c.CamDirection = cmbEntryType.Text;
                    c.CamStreamURL = txtCameraURL.Text;
                    c.CamIP = txtIP.Text;
                    c.UserID = txtCam_UserId.Text;
                    c.Password = txtCam_Password.Text;
                    c.CamEnable = chkEnable.Checked;
                    c.ThersholdSeconds = Convert.ToInt32(txtThershold.Text);
                    c.ResolutHeight = Convert.ToInt32(txtResl_Height.Text);
                    c.ResolutWidth = Convert.ToInt32(txtResl_Width.Text);
                    c.isRecording = chkRecording.Checked;
                    c.RecordingPath = txtRecordingPath.Text;
                    c.ANPRImagePath = txtANPRPath.Text;
                    c.RecordingDeleteHours =Vald.GetNumeric(txtDeleteMotionImg_Hours.Text);


                    bool flgChanel = Validate_Channels();

                    DAL dal = new DAL();
                    string err = dal.SaveCamera(c);


                    if (err == "")
                    {
                        MessageBox.Show("Camera Details has been Saved.");
                        ClearCamera();
                        GetCamera_Grid();
                    }
                    else
                    {
                        MessageBox.Show(err, "System Error");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void SaveUser_Data()
        {
            try
            {


                Users u = new Users();

                u.UserId = Convert.ToInt16(txtUserId.Text);
                u.UserName= txtUserName.Text;
                u.FirstName= txtUserFName.Text;
                u.LastName = txtUserLastName.Text;
                u.Email = txtUserEmail.Text;
                u.Password = txtUserPwd.Text;
                u.RoleId = Convert.ToInt16(cmbUserRole.SelectedValue);
                u.Is_Active = Convert.ToInt16(chkIsActive_User.Checked);
            
                DAL dal = new DAL();
                string err = dal.SaveUser(u);


                if (err == "")
                {
                    MessageBox.Show("User has been Saved.");
                    ClearUser();
                    GetUsers_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void SaveCompInfo_Data()
        {
            try
            {


                CompInfo c = new CompInfo();

                c.Email = txtEmail.Text;
                c.YouTube = txtYoutube.Text;
                c.UserGuide = txtUserGuide.Text;
                c.Telephone=   txtTelephone.Text;
                c.WebPage = txtWebPage.Text;

               
                DAL dal = new DAL();
                string err = dal.SaveCompInfo(c);


                if (err == "")
                {
                    MessageBox.Show("Infor has been Saved.");
                    GetUsers_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void SaveSMTPSetting_Data()
        {
            try
            {


                SMTP s = new SMTP();

                s.SMTPEmail=txtSMTPEmail.Text;
                s.SMTPServer=txtSMTPServer.Text;
                s.UserName = txtSMTPUserName.Text;
                s.Password = txtSMTP_Password.Text;
                s.SSLEnable=chkSSL.Checked;
                s.BlackListEmail=chkBlackList.Checked;
                s.SenderEmail = txt_SenderEmail.Text;

                if (Vald.IsNumeric(txtPort.Text) ) 
                { 
                    s.Port = Convert.ToInt32(txtPort.Text); 
                }
                else
                {
                    s.Port = 0;
                }


                if (chkDailyEmail.Checked)
                {
                    s.EmailFrequency = 1;
                }
                else
                {
                    s.EmailFrequency = 0;
                }
                

                DAL dal = new DAL();
                string err = dal.SaveSMTPSetting(s);


                if (err == "")
                {
                    MessageBox.Show("SMTP setting has been Saved.");
                    GetUsers_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void SaveCaptureSetting_Data()
        {
            try
            {


                ProcessTrigger p = new ProcessTrigger();
                CaptureSetting c = new CaptureSetting();

                p.PrcCode = "motion_img";
                p.PrcName = "motion image clear";
                p.TriggerTime = Convert.ToInt32(txtDeleteMotionImg_Hours.Text);
                c.AccuracyLevel = Convert.ToDouble(txtAccuracyLevel.Text);
                c.MinNPLength = Convert.ToInt16(txtMinNPLength.Text);
                c.MaxNPLength = Convert.ToInt16(txtMaxNPLength.Text);
                c.MotionFrameNo = Convert.ToInt16(txMotionFrameNo.Text);
                c.StartupEnable = chkStartUp.Checked;

                DAL dal = new DAL();
                string err = dal.SaveCaptureSetting(c,p);


                p.PrcCode = "Recording_img";
                p.PrcName = "Recording image clear";
                p.TriggerTime = Convert.ToInt32(txtDeleteRecordingImg_Hours.Text);
                c.AccuracyLevel = Convert.ToDouble(txtAccuracyLevel.Text);
                c.MinNPLength = Convert.ToInt16(txtMinNPLength.Text);
                c.MaxNPLength = Convert.ToInt16(txtMaxNPLength.Text);
                c.MotionFrameNo = Convert.ToInt16(txMotionFrameNo.Text);
                c.StartupEnable = chkStartUp.Checked;
;
                 err = dal.SaveCaptureSetting(c, p);


                if (err == "")
                {
                    MessageBox.Show("Info has been Saved.");
                    //GetUsers_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void SaveDeviceTrg_Data()
        {
            try
            {

                DeviceTrigger d = new DeviceTrigger();

                d.Cam_Id = Vald.GetNumeric(cmbCameralst.SelectedValue.ToString());
                d.Dev_Id = cmbDevicelst.SelectedValue.ToString();
                d.Act_Id = Vald.GetNumeric(cmbActionType.SelectedValue.ToString());
                d.Dev_RelayNo = Vald.GetNumeric(cmbRelayChannel.SelectedValue.ToString());
                d.Lst_Id = Vald.GetNumeric(cmbLstType.SelectedValue.ToString());
                d.id = Vald.GetNumeric(txtTriggerId.Text);

                if(optCloud.Checked)
                {
                    d.Connection_Type = 1;
                }
                else
                {
                    d.Connection_Type = 2;
                }



                //****** for use local Shelly ip
                //* http://192.168.1.38/rpc/Switch.Set?id=0&on=false

                DAL dal = new DAL();
                string err = dal.SaveDeviceTriggers(d);


                if (err == "")
                {
                    MessageBox.Show("Device Trigger has been Saved.");
                    ClearDeviceTrigger();
                    GetDeviceTriger_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void DeleteDeviceTrg_Data()
        {
            try
            {

                DeviceTrigger d = new DeviceTrigger();

             
                d.id = Vald.GetNumeric(txtTriggerId.Text);


                DAL dal = new DAL();
                string err = dal.DeleteDeviceTriggers(d);


                if (err == "")
                {
                    MessageBox.Show("Device Trigger has been Delete.");
                    ClearDeviceTrigger();
                    GetDeviceTriger_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void SaveDevice_Data()
        {
            try
            {


                Devices d = new Devices();

                d.id = Convert.ToInt16(txtDev_Id.Text);
                d.Dev_Id= txtDevId_Str.Text;
                d.Dev_Name = txtDevName.Text;
                d.Dev_Descrp = txtDevDesc.Text;
                d.Chanel_0 = txtCh0.Text;
                d.Chanel_1 = txtCh1.Text;
                d.Chanel_2 = txtCh2.Text;
                d.Dev_LocalIP = txtDeviceLocalIP.Text;


                DAL dal = new DAL();
                string err = dal.SaveDevice(d);


                if (err == "")
                {
                    MessageBox.Show("Device has been Saved.");
                    ClearDevice();
                    GetDevice_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void DeleteDevice_Data()
        {
            try
            {

                Devices d = new Devices();

                d.id = Convert.ToInt16(txtDev_Id.Text);
    
                DAL dal = new DAL();
                string err = dal.DeleteDevice(d);


                if (err == "")
                {
                    MessageBox.Show("Device has been Deleted.");
                    ClearDevice();
                    GetDevice_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void DeleteCameraData()
        {
            try
            {


                CameraInfo c = new CameraInfo();

                c.CamId = Convert.ToInt16(txtCameraId.Text);
       
                DAL dal = new DAL();
                string err = dal.DeleteCamera(c);


                if (err == "")
                {
                    MessageBox.Show("Camera Details has been Deleted.");
                    ClearCamera();
                    GetCamera_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveCamera_Data();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearCamera();
        }

        private bool Validate_Channels()
        {
            bool FlgVald = true;

            try
            {
                int? ChanelNo = 0;
                int Cam_Count = 0;

                ChanelNo = 4;
                DAL dal = new DAL();

                Cam_Count = dal.Read_ActiveCameraCount();

                if (txtCameraId.Text== "0")
                {
                    if (Cam_Count>= ChanelNo)
                    {
                        FlgVald = false;
                        MessageBox.Show("You have exceeded the chanel limit. You have " + ChanelNo.ToString() + " chanel license.");

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

            return FlgVald;
        }

        private void gv_CameraList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gv_CameraList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CameraGrid_Select();
        }

        private void DeviceGrid_Select()
        {
            txtDev_Id.Text = gv_Devicelst.CurrentRow.Cells["id"].Value.ToString();
            txtDevId_Str.Text = gv_Devicelst.CurrentRow.Cells["Dev_Id"].Value.ToString();
            txtDevName.Text = gv_Devicelst.CurrentRow.Cells["Dev_Name"].Value.ToString();
            txtDevDesc.Text = gv_Devicelst.CurrentRow.Cells["Dev_Descrp"].Value.ToString();

            txtCh0.Text = gv_Devicelst.CurrentRow.Cells["Chanel_0"].Value.ToString();
            txtCh1.Text = gv_Devicelst.CurrentRow.Cells["Chanel_1"].Value.ToString();
            txtCh2.Text = gv_Devicelst.CurrentRow.Cells["Chanel_2"].Value.ToString();
            txtDeviceLocalIP.Text = gv_Devicelst.CurrentRow.Cells["Dev_LocalIP"].Value.ToString();

        }

        private void DeviceGridTrg_Select()
        {
            cmbCameralst.SelectedValue = Vald.GetNumeric(gv_Devicetrigger.CurrentRow.Cells["Cam_Id"].Value.ToString());
            cmbDevicelst.SelectedValue = gv_Devicetrigger.CurrentRow.Cells["Dev_Id"].Value.ToString();
            cmbRelayChannel.SelectedValue = Vald.GetNumeric(gv_Devicetrigger.CurrentRow.Cells["Dev_RelayNo"].Value.ToString());
            cmbLstType.SelectedValue = Vald.GetNumeric(gv_Devicetrigger.CurrentRow.Cells["Lst_Id"].Value.ToString());
            cmbActionType.SelectedValue = Vald.GetNumeric(gv_Devicetrigger.CurrentRow.Cells["Act_Id"].Value.ToString());
            txtTriggerId.Text = gv_Devicetrigger.CurrentRow.Cells["id"].Value.ToString();

            int Conn_Type = Vald.GetNumeric(gv_Devicetrigger.CurrentRow.Cells["Connection_Type"].Value.ToString());

            if (Conn_Type==1)
            {
                optCloud.Checked=true;
            }
            else
            {
                OptLocal.Checked = true; ;
            }

        }

        private void CameraGrid_Select()
        {
            txtCameraId.Text = gv_CameraList.CurrentRow.Cells["Cam_Id"].Value.ToString();
            txtCameraName.Text = gv_CameraList.CurrentRow.Cells["Cam_Name"].Value.ToString();

            if (gv_CameraList.CurrentRow.Cells["Cam_DirectionCode"].Value.ToString() != "")
            {
                cmbEntryType.SelectedValue = Convert.ToInt16(gv_CameraList.CurrentRow.Cells["Cam_DirectionCode"].Value);
            }

            txtCameraURL.Text = gv_CameraList.CurrentRow.Cells["Cam_StreamURL"].Value.ToString();
            txtIP.Text = gv_CameraList.CurrentRow.Cells["Cam_IP"].Value.ToString();
            txtThershold.Text = gv_CameraList.CurrentRow.Cells["ThersholdSeconds"].Value.ToString();
            txtResl_Width.Text = gv_CameraList.CurrentRow.Cells["Resolut_Width"].Value.ToString();
            txtResl_Height.Text = gv_CameraList.CurrentRow.Cells["Resolut_Height"].Value.ToString();

            if (gv_CameraList.CurrentRow.Cells["Cam_Enable"].Value.ToString() != "")
            {
                chkEnable.Checked = Convert.ToBoolean(gv_CameraList.CurrentRow.Cells["Cam_Enable"].Value);
            }

            if (gv_CameraList.CurrentRow.Cells["IsRecording"].Value.ToString() != "")
            {
                chkRecording.Checked = Convert.ToBoolean(gv_CameraList.CurrentRow.Cells["IsRecording"].Value);
            }
            else
            {
                chkEnable.Checked = false;
            }

            //if (gv_CameraList.CurrentRow.Cells["Startup_Enable"].Value.ToString() != "")
            //{
            //    chkStartUp.Checked = Convert.ToBoolean(gv_CameraList.CurrentRow.Cells["Startup_Enable"].Value);
            //}


            txtCam_UserId.Text = gv_CameraList.CurrentRow.Cells["User_Name"].Value.ToString();
            txtCam_Password.Text = gv_CameraList.CurrentRow.Cells["User_Password"].Value.ToString();
            txtRecordingPath.Text = gv_CameraList.CurrentRow.Cells["RecordingPath"].Value.ToString();
            txtANPRPath.Text = gv_CameraList.CurrentRow.Cells["ANPRImagePath"].Value.ToString();
            txtDeleteMotionImg_Hours.Text = gv_CameraList.CurrentRow.Cells["RecordingDeleteHours"].Value.ToString();


        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            Set_Lang();
            c = new Communication();
            GetCamera_Grid();
            GetUsers_Grid();
            GetComp_Info();
            ClearCamera();
            ClearDevice();
            GetSMTP_Info();
            GetCaptureSetting_Info();
            GetDevice_Grid();
            GetDeviceTriger_Grid();
            Init();
            FillTriggerDropDown();
        }

        private void Init()
        {
            btnNew_Camera.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnNew_Camera.Width, btnNew_Camera.Height, 10, 10));
            btnUpdate_Camera.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUpdate_Camera.Width, btnUpdate_Camera.Height, 10, 10));
            btnDelete_Camera.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete_Camera.Width, btnDelete_Camera.Height, 10, 10));
            btnUpdateSetting.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUpdateSetting.Width, btnUpdateSetting.Height, 10, 10));
            btnUpdateLogo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUpdateLogo.Width, btnUpdateLogo.Height, 10, 10));
            btnNew_User.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnNew_User.Width, btnNew_User.Height, 10, 10));
            btnSave_User.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSave_User.Width, btnSave_User.Height, 10, 10));
            btnDelete_User.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete_User.Width, btnDelete_User.Height, 10, 10));
            btnNew_Rules.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnNew_Rules.Width, btnNew_Rules.Height, 10, 10));
            btnSave_Rules.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSave_Rules.Width, btnSave_Rules.Height, 10, 10));
            btnDelete_Rules.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete_Rules.Width, btnDelete_Rules.Height, 10, 10));
            btnUpdateInfo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUpdateInfo.Width, btnUpdateInfo.Height, 10, 10));   
            btnDeleteMotionImg.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDeleteMotionImg.Width, btnDeleteMotionImg.Height, 10, 10));
            btnUpdateCaptureSetting.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUpdateCaptureSetting.Width, btnUpdateCaptureSetting.Height, 10, 10));

            btnNew_Dev.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnNew_Dev.Width, btnNew_Dev.Height, 10, 10));
            btnSave_Dev.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSave_Dev.Width, btnSave_Dev.Height, 10, 10));
            btnDelete_Dev.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete_Dev.Width, btnDelete_Dev.Height, 10, 10));

            btnNew_Trg.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnNew_Trg.Width, btnNew_Trg.Height, 10, 10));
            btnSave_Trg.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSave_Trg.Width, btnSave_Trg.Height, 10, 10));
            btnDelete_Trg.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete_Trg.Width, btnDelete_Trg.Height, 10, 10));

            Communication c = new Communication();

            FlagIsLangEngl = c.IsLangEnglish();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCameraData();
        }

        private void btnUpdateSetting_Click(object sender, EventArgs e)
        {
            UpdateAppSetting();
        }

        private void UpdateAppSetting()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                string key;
                string value;

                key = "AppName";
                value = txtAppName.Text;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                key = "langCode";
                if (OptTurkish.Checked)
                {
                    value = "1";
                }
                else
                {
                    value = "2";
                }
                

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }


                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                
                MessageBox.Show("Data has been Updated", "System Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void btnUpdateLogo_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void UploadFile()
        {
            try
            {
                string imageFileName = "";
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Title = "Browse Image File";
                openFileDialog1.Filter = "image files (*.png)|*.png|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                this.openFileDialog1.Multiselect = false;
                imageFileName = openFileDialog1.FileName;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                        imageFileName = openFileDialog1.FileName;
                        string logimgpath = c.Get_Path(Communication.PathType.Logo);


                    string sourcePath = imageFileName;
                      
                        // Use Path class to manipulate file and directory paths.
                        string sourceFile = imageFileName;
                        string destFile = logimgpath + "\\logo.png";

                    //System.IO.Directory.CreateDirectory(targetPath);

                    if (picLogo.Image !=null)
                    {
                        picLogo.Image.Dispose();
                    }
                   

                    System.IO.File.Copy(sourceFile, destFile, true);

                    GetCamera_Grid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
}


        private void FillDropDown()
        {

            try
            {
               DataSet ds = new DataSet();
                DAL dal = new DAL();

                ds = dal.Read_Roles();

                cmbUserRole.DataSource = ds.Tables[0];
                cmbUserRole.DisplayMember = "RoleName";
                cmbUserRole.ValueMember = "RoleId";
                cmbUserRole.DropDownStyle = ComboBoxStyle.DropDownList;


                DataTable Camera_direction = new DataTable();
                DataColumn dtColumn;
                DataRow myDataRow;

                // Create id column
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(int);
                dtColumn.ColumnName = "id";
                dtColumn.Caption = "id";

                // Add column to the DataColumnCollection.
                Camera_direction.Columns.Add(dtColumn);

                // Create Name column.
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "Name";
                dtColumn.Caption = "Name";

                /// Add column to the DataColumnCollection.
                Camera_direction.Columns.Add(dtColumn);


                // I add three customers with their addresses, names and ids

                myDataRow = Camera_direction.NewRow();
                myDataRow["id"] = 0;
                myDataRow["Name"] = "All";
                Camera_direction.Rows.Add(myDataRow);

                myDataRow = Camera_direction.NewRow();
                myDataRow["id"] = 1;
                myDataRow["Name"] = "Entry";
                Camera_direction.Rows.Add(myDataRow);

                myDataRow = Camera_direction.NewRow();
                myDataRow["id"] = 2;
                myDataRow["Name"] = "Exit";
                Camera_direction.Rows.Add(myDataRow);

                cmbEntryType.DataSource = Camera_direction;
                cmbEntryType.DisplayMember = "Name";
                cmbEntryType.ValueMember = "id";
                cmbEntryType.DropDownStyle = ComboBoxStyle.DropDownList;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void FillTriggerDropDown()
        {

            try
            {
                DataSet dsCam = new DataSet();
                DAL dal = new DAL();

                dsCam = dal.Read_CameraInfo();

                cmbCameralst.DataSource = dsCam.Tables[0];
                cmbCameralst.DisplayMember = "Cam_Name";
                cmbCameralst.ValueMember = "Cam_Id";
                cmbCameralst.DropDownStyle = ComboBoxStyle.DropDownList;


                DataTable Device_Channel = new DataTable();
                DataColumn dtColumn;
                DataRow myDataRow;

                // Create id column
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(int);
                dtColumn.ColumnName = "id";
                dtColumn.Caption = "id";

                // Add column to the DataColumnCollection.
                Device_Channel.Columns.Add(dtColumn);

                // Create Name column.
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "Name";
                dtColumn.Caption = "Name";

                /// Add column to the DataColumnCollection.
                Device_Channel.Columns.Add(dtColumn);


                // I add three customers with their addresses, names and ids

                myDataRow = Device_Channel.NewRow();
                myDataRow["id"] = 0;
                myDataRow["Name"] = "Channel - 0";
                Device_Channel.Rows.Add(myDataRow);

                myDataRow = Device_Channel.NewRow();
                myDataRow["id"] = 1;
                myDataRow["Name"] = "Channel - 1";
                Device_Channel.Rows.Add(myDataRow);

                myDataRow = Device_Channel.NewRow();
                myDataRow["id"] = 2;
                myDataRow["Name"] = "Channel - 2";
                Device_Channel.Rows.Add(myDataRow);

                cmbRelayChannel.DataSource = Device_Channel;
                cmbRelayChannel.DisplayMember = "Name";
                cmbRelayChannel.ValueMember = "id";
                cmbRelayChannel.DropDownStyle = ComboBoxStyle.DropDownList;

                DataSet dsDevicelst = new DataSet();

                dsDevicelst = dal.Read_AllDevices();

                cmbDevicelst.DataSource = dsDevicelst.Tables[0];
                cmbDevicelst.DisplayMember = "Dev_Name";
                cmbDevicelst.ValueMember = "Dev_Id";
                cmbDevicelst.DropDownStyle = ComboBoxStyle.DropDownList;

                DataSet dslstType = new DataSet();

                dslstType = dal.Read_ListedType(false);

                cmbLstType.DataSource = dslstType.Tables[0];
                cmbLstType.DisplayMember = "Name";
                cmbLstType.ValueMember = "id";
                cmbLstType.DropDownStyle = ComboBoxStyle.DropDownList;

                DataSet dsActType = new DataSet();

                dsActType = dal.Read_ActType(false);

                cmbActionType.DataSource = dsActType.Tables[0];
                cmbActionType.DisplayMember = "Act_Name";
                cmbActionType.ValueMember = "Act_Id";
                cmbActionType.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error;" + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void gv_CameraList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gv_UserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtUserId.Text = gv_UserList.CurrentRow.Cells["UserId"].Value.ToString();
                txtUserName.Text = gv_UserList.CurrentRow.Cells["UserName"].Value.ToString();
                txtUserFName.Text = gv_UserList.CurrentRow.Cells["FirstName"].Value.ToString();
                txtUserLastName.Text = gv_UserList.CurrentRow.Cells["LastName"].Value.ToString();
                txtUserPwd.Text = gv_UserList.CurrentRow.Cells["Password"].Value.ToString();
                txtUserEmail.Text = gv_UserList.CurrentRow.Cells["Email"].Value.ToString();

                if (gv_UserList.CurrentRow.Cells["RoleId"].Value.ToString() != "")
                {
                    cmbUserRole.SelectedValue = Convert.ToInt16(gv_UserList.CurrentRow.Cells["RoleId"].Value.ToString());
                }

                if (gv_UserList.CurrentRow.Cells["Is_Active"].Value.ToString() != "")
                {
                    chkIsActive_User.Checked = Convert.ToBoolean(gv_UserList.CurrentRow.Cells["Is_Active"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

        }

        private void btnNew_User_Click(object sender, EventArgs e)
        {
            ClearUser();
        }

        private void btnSave_User_Click(object sender, EventArgs e)
        {
            SaveUser_Data();
        }

        private void btnUpdate_Camera_Click(object sender, EventArgs e)
        {
            SaveCamera_Data();
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            SaveCompInfo_Data();
        }

        private void btnSave_Rules_Click(object sender, EventArgs e)
        {
            //Communication c = new Communication();
            //c.Send_Email("ayaz.softengr@gmail.com", "test email 22", "test body e3r");
            SaveSMTPSetting_Data();

            //Communication c = new Communication();
            //c.Send_Email("ayaz.softengr@gmail.com", "test email 22", "test body e3r");
        }

        private void btnDeleteMotionImg_Click(object sender, EventArgs e)
        {
            try
            { 
                ProcessTrg prc = new ProcessTrg();
                prc.Delete_MotionImg();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateCaptureSetting_Click(object sender, EventArgs e)
        {
            SaveCaptureSetting_Data();
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SetStartup()
        {
            string AppName = "Palakasoft";

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            string cmd = Application.ExecutablePath.ToString() + " LPR";

            if (chkStartUp.Checked)
            {
                rk.SetValue(AppName, cmd);
            }
            else
            {
                rk.DeleteValue(AppName, false);
            }
                

        }

        private void chkStartUp_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup();
        }

        private void gv_CameraList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CameraGrid_Select();
        }

        private void gv_CameraList_Click(object sender, EventArgs e)
        {
            CameraGrid_Select();
        }

        private void btnNew_Dev_Click(object sender, EventArgs e)
        {
            ClearDevice();
        }

        private void btnSave_Dev_Click(object sender, EventArgs e)
        {
            SaveDevice_Data();
        }

        private void btnDelete_Dev_Click(object sender, EventArgs e)
        {
            DeleteDevice_Data();
        }

        private void gv_Devicelst_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeviceGrid_Select();
        }

        private void btnChanel0_Click(object sender, EventArgs e)
        {
            ShellyAPI s = new ShellyAPI();
            //s.RelaySwitchAction();
            string status;

            if (btnChanel0.Text=="Off")
            {
                status = "on";
                btnChanel0.Text = "On";
            }
            else
            {
                status = "off";
                btnChanel0.Text = "Off";
            }

            s.ShellySwitch(0, txtDevId_Str.Text, "", status);
        }

        private void btnChanel1_Click(object sender, EventArgs e)
        {
            ShellyAPI s = new ShellyAPI();
         
            string status;

            if (btnChanel1.Text == "Off")
            {
                status = "on";
                btnChanel1.Text = "On";
            }
            else
            {
                status = "off";
                btnChanel1.Text = "Off";
            }

            s.ShellySwitch(1, txtDevId_Str.Text, "", status);
        }

        private void btnChanel2_Click(object sender, EventArgs e)
        {
            ShellyAPI s = new ShellyAPI();
            //s.RelaySwitchAction();
            string status;

            if (btnChanel2.Text == "Off")
            {
                status = "on";
                btnChanel2.Text = "On";
            }
            else
            {
                status = "off";
                btnChanel2.Text = "Off";
            }

            s.ShellySwitch(2, txtDevId_Str.Text, "", status);
        }

        private void btnNew_Trg_Click(object sender, EventArgs e)
        {
            ClearDeviceTrigger();
        }

        private void btnSave_Trg_Click(object sender, EventArgs e)
        {
            SaveDeviceTrg_Data();
        }

        private void gv_Devicetrigger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeviceGridTrg_Select();
        }

        private void btnDelete_Trg_Click(object sender, EventArgs e)
        {
            DeleteDeviceTrg_Data();
        }

        private void btnRecordingMotionImg_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessTrg prc = new ProcessTrg();
                prc.Delete_RecordingImg();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the initial directory (optional)
            folderBrowserDialog.SelectedPath = "C:\\";

            // Show the folder browser dialog
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Retrieve the selected directory path
                string selectedDirectoryPath = folderBrowserDialog.SelectedPath;

                // Do something with the selected directory path
                // For example, display the path in a text box
                txtWebImage.Text = selectedDirectoryPath;
            }

        }

        private void btnUpdatePath_Click(object sender, EventArgs e)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                string key;
                string value;

                key = "WebImage";
                value = txtWebImage.Text + "\\";

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }


                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                MessageBox.Show("Data has been Updated", "System Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }
    }
}
