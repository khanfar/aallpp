using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using ANPR_General.Entity;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace ANPR_General
{
    public class DAL
    {


        public string SaveVehicle(VehicleMaster V)
        {

            string qry = "";
            string error_msg = "";

            try
            {
                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;
                string ConnString = ConfigurationManager.AppSettings["ConnString"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                //sqlcmd.Parameters.AddWithValue("@posttxt", p.PostText);
                string dt = DateTime.Now.ToString("yyyy-MM-dd");

                qry += " Declare @id as int";
                qry += " Select @id=ISNULL(MAx(vhc_Id),0)+1  From  VehicleMaster ";

                if (V.vhc_Id == 0)
                {
                    qry += " INSERT INTO dbo.[VehicleMaster] ";
                    qry += " (vhc_Id, vhc_Name, vhc_CompId, vhc_Description, vhc_NumberPlate1, vhc_NumberPlate2, vhc_ListCode, vhc_Owner, CreateOn";
                    qry += " )";
                    qry += "  Values(@id,'" + V.vhc_Name + "',0,'" + V.vhc_Description + "',";
                    qry += "'" + V.vhc_NumberPlate1 + "',''," + V.vhc_ListCode + ",'" + V.vhc_Owner + "',Getdate())";

                }
                else
                {
                    qry += " Update VehicleMaster Set vhc_Name='" + V.vhc_Name + "',vhc_Description='" + V.vhc_Description + "',";
                    qry += " vhc_NumberPlate1='" + V.vhc_NumberPlate1 + "',vhc_ListCode=" + V.vhc_ListCode;
                    qry += " ,vhc_Owner='" + V.vhc_Owner + "'";
                    qry += " Where vhc_Id=" + V.vhc_Id;
                }



                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string DeleteVehicle(VehicleMaster V)
        {

            string qry = "";
            string error_msg = "";

            try
            {
                //Step 1 -- Define the connection string
              
                string ConnString = ConfigurationManager.AppSettings["ConnString"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
       
                string dt = DateTime.Now.ToString("yyyy-MM-dd");


                qry += " Delete From VehicleMaster ";
                 qry += " Where vhc_Id=" + V.vhc_Id;
              


                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string DeleteDevice(Devices d)
        {

            string qry = "";
            string error_msg = "";

            try
            {
                //Step 1 -- Define the connection string

                string ConnString = ConfigurationManager.AppSettings["ConnString"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;

                string dt = DateTime.Now.ToString("yyyy-MM-dd");


                qry += " Delete From DeviceDetail ";
                qry += " Where Id=" + d.id;



                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string DeleteDeviceTriggers(DeviceTrigger d)
        {

            string error_msg = "";

            try
            {
                string qry = "";

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                qry = " Delete [DeviceTrigger] ";
                qry += " Where id=" + d.id + "";

                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string DeleteCamera(CameraInfo c)
        {

            string qry = "";
            string error_msg = "";

            try
            {
                //Step 1 -- Define the connection string
              
                string ConnString = ConfigurationManager.AppSettings["ConnString"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;

                string dt = DateTime.Now.ToString("yyyy-MM-dd");


                qry += " Delete From CameraInfo ";
                qry += " Where Cam_Id=" + c.CamId;



                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string SaveCamera(CameraInfo c)
        {

            string qry = "";
            string error_msg = "";

            try
            {
                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;
                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                //sqlcmd.Parameters.AddWithValue("@posttxt", p.PostText);
                string dt = DateTime.Now.ToString("yyyy-MM-dd");

                qry += " Declare @id as int";
                qry += " Select @id=ISNULL(MAx(Cam_Id),0)+1  From  CameraInfo ";

                if (c.ResolutWidth==0)
                {
                    c.ResolutWidth = 1280;
                }

                if (c.ResolutHeight == 0)
                {
                    c.ResolutHeight = 1024;
                }

                if (c.CamId == 0)
                {
                    qry += " INSERT INTO dbo.[CameraInfo] ";
                    qry += " (Cam_Id, Cam_Name,Cam_DirectionCode, Cam_Direction, Cam_StreamURL, ThersholdSeconds,Cam_IP, Cam_Enable,IsRecording, CreatedOn,App_Code,";
                    qry += " Resolut_Width,Resolut_Height,RecordingPath,ANPRImagePath,RecordingDeleteHours)";
                    qry += "  Values(@id,'" + c.CamName + "'," + c.CamDirectionCode  + ",'" + c.CamDirection + "',";
                    qry += "'" + c.CamStreamURL + "'," + c.ThersholdSeconds + ",'" + c.CamIP + "','" + c.CamEnable + "','" + c.isRecording + "',Getdate(),'" + appCode + "','" + c.ResolutWidth + "','" + c.ResolutHeight + "',";
                    qry += "'" + c.RecordingPath + "','" + c.ANPRImagePath + "'," + c.RecordingDeleteHours + ")";

                }
                else
                {
                    qry += " Update CameraInfo Set Cam_Name='" + c.CamName + "',Cam_Direction='" + c.CamDirection + "',Cam_DirectionCode=" + c.CamDirectionCode;
                    qry += " ,Cam_StreamURL='" + c.CamStreamURL + "',ThersholdSeconds=" + c.ThersholdSeconds;
                    qry += " ,Cam_Enable='" + c.CamEnable + "' ,IsRecording='" + c.isRecording + "',Cam_IP='" + c.CamIP + "',User_Name='" + c.UserID + "',User_Password='" + c.Password + "',";
                    qry += " Resolut_Width='" + c.ResolutWidth + "',Resolut_Height='" + c.ResolutHeight + "',";
                    qry += " RecordingPath='" + c.RecordingPath + "',ANPRImagePath='" + c.ANPRImagePath + "',RecordingDeleteHours=" + c.RecordingDeleteHours;
                    qry += " Where Cam_Id=" + c.CamId;
                }



                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public static bool IsStringAlphabetic(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }

        public string SaveANPR(ANPRDetail A, ref int _id, int CitycodeFormat)
        {

            string qry = "";
            string error_msg = "";

            try
            {
                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;
                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                //sqlcmd.Parameters.AddWithValue("@posttxt", p.PostText);
                string dt = DateTime.Now.ToString("yyyy-MM-dd");
                string tm = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string _CityCode = "0";

               

                if (A.ANPR_NumberPlate.Length > 2)
                {
                    _CityCode = A.ANPR_NumberPlate.Substring(0, 2);

                    if (CitycodeFormat == 1)
                    {
                        _CityCode = A.ANPR_NumberPlate.Substring(0, 1);

                        if (!IsStringAlphabetic(_CityCode))
                        {
                            _CityCode = A.ANPR_NumberPlate.Substring(A.ANPR_NumberPlate.Length - 1)[0].ToString();
                        }

                        string CityCode_Spec = A.ANPR_NumberPlate.Substring(0, 2);

                        if (CityCode_Spec.ToUpper()=="IL")
                        {
                            _CityCode = "IL";
                        }

                    }
                }

                

                qry += " Declare @citynm as nvarchar(15)" + "\n\r";
                qry += " Declare @countrynm as nvarchar(15)" + "\n\r";
                qry += " SELECT @citynm=City_Name,@countrynm=Country_Name ";
                qry += " FROM CityDetail Where City_Code='" + _CityCode + "'";

                //qry += " ";

                qry += " INSERT INTO dbo.[ANPRDetail] ";
                    qry += " (ANPR_NumberPlate, ANPR_Date, ANPR_Time, vhc_Id, vhc_ListCode, Cam_Id, App_Code, CreateOn,";
                    qry += " City_Code,City_Name,Country_Name,Pic_Path,Pic_PathHD,Pic_PathServer,Confidence_Level)";
                    qry += "  Values('" + A.ANPR_NumberPlate + "','" + dt + "','" + tm + "',";
                    qry += "" + A.vhc_Id + "," + A.vhc_ListCode + "," + A.Cam_Id + ",'" + appCode + "',Getdate(),";
                    qry += "'" + _CityCode + "',@citynm,@countrynm,'" + A.Pic_Path + "','" + A.Pic_Path_HD + "','" + A.Web_Path + "'," + A.Confidence_Level.ToString().Replace(",","")+")";
                //MessageBox.Show(qry, "qry1");

                //qry += " Select SCOPE_IDENTITY()";

                string query2;

                query2 = "Select SCOPE_IDENTITY()";

                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();

                sqlcmd.CommandText = query2;

                string str_int = sqlcmd.ExecuteScalar().ToString();

                _id = Convert.ToInt32(str_int);

                sqlconn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                return error_msg;
            }

            return error_msg;

        }

        public string SaveUser(Users u)
        {


            string error_msg = "";

            try
            {
                string qry = "";

                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;

                string _picPath = "~/Images/User-Profile/male.png";

                if (u.ProfilePic == "")
                {
                    u.ProfilePic = _picPath;
                }

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                if (u.UserId == 0)
                {
                    qry = " INSERT INTO [dbo].[UserProfile](";
                    qry += " [UserName],[FirstName],LastName,Email,Password,ProfilePic,Gender ";
                    qry += " ,Whatsapp_Verified,Email_Verified,Whatsapp_Code,Email_Code,DOB,Is_Active,Country_Id,City_Name,WhatsappNo,RoleId) Values (";
                    qry += "'" + u.UserName+ "','" + u.FirstName + "','" + u.LastName + "','" + u.Email + "','" + u.Password + "','" + u.ProfilePic + "','" + u.Gender + "',0,0,'','','2000-01-01',1," + u.Country_Id + ",'" + u.City_Name + "','" + u.WhatsappNo + "'," + u.RoleId + ")";


                }
                else
                {
                    qry = " Update [UserProfile] ";
                    qry += " Set [UserName]='" + u.UserName + "', [FirstName]='" + u.FirstName + "',[LastName]='" + u.LastName + "',";
                    qry += " Gender='" + u.Gender + "',WhatsappNo='" + u.WhatsappNo + "',City_Name='" + u.City_Name + "',Country_Id=" + u.Country_Id;
                    qry += " ,Email='" + u.Email + "',Password='" + u.Password + "',RoleId=" + u.RoleId;
                    if (u.ProfilePic != "" && u.ProfilePic != null)
                    {
                        qry += ",ProfilePic = '" + u.ProfilePic + "'";
                    }

                    qry += " Where UserId='" + u.UserId + "'";

                }

                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string SaveDevice(Devices d)
        {

            string error_msg = "";

            try
            {
                string qry = "";

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                if (d.id == 0)
                {
                    qry = " INSERT INTO [dbo].[DeviceDetail](";
                    qry += " Dev_Id, Dev_Name, Dev_Descrp, Chanel_0, Chanel_1, Chanel_2, Chanel_3, DevType_Id,Dev_LocalIP";
                    qry += " ) Values (";
                    qry += "'" + d.Dev_Id + "','" + d.Dev_Name + "','" + d.Dev_Descrp + "','" + d.Chanel_0 + "','" + d.Chanel_1 + "','" + d.Chanel_2 + "',''," + d.DevType_Id + ",'" + d.Dev_LocalIP + "')";

                }
                else
                {
                    qry = " Update [DeviceDetail] ";
                    qry += " Set [Dev_Id]='" + d.Dev_Id + "', [Dev_Name]='" + d.Dev_Name + "', [Dev_Descrp]='" + d.Dev_Descrp + "',[Chanel_0]='" + d.Chanel_0 + "',";
                    qry += " Chanel_1='" + d.Chanel_1 + "',Chanel_2='" + d.Chanel_2 + "',Dev_LocalIP='" + d.Dev_LocalIP + "'";
                    qry += " Where id=" + d.id + "";

                }

                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string SaveDeviceTriggers(DeviceTrigger d)
        {

            string error_msg = "";

            try
            {
                string qry = "";

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                if (d.id == 0)
                {
                    qry = " INSERT INTO [dbo].[DeviceTrigger](";
                    qry += " Cam_Id, Dev_Id, Act_Id, Dev_RelayNo, Lst_Id,Connection_Type";
                    qry += " ) Values (";
                    qry += "" + d.Cam_Id + ",'" + d.Dev_Id + "'," + d.Act_Id + "," + d.Dev_RelayNo + "," + d.Lst_Id + "," + d.Connection_Type + ")";

                }
                else
                {
                    qry = " Update [DeviceTrigger] ";
                    qry += " Set [Cam_Id]=" + d.Cam_Id + ", [Dev_Id]='" + d.Dev_Id + "', [Act_Id]=" + d.Act_Id + ",[Dev_RelayNo]=" + d.Dev_RelayNo + ",";
                    qry += " Lst_Id=" + d.Lst_Id + " ,Connection_Type=" + d.Connection_Type;
                    qry += " Where id=" + d.id + "";

                }

                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string SaveCompInfo(CompInfo c)
        {


            string error_msg = "";

            try
            {
                string qry = "";

                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;


                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                   qry += " Delete From CompInfo ";

                    qry += " INSERT INTO [dbo].[CompInfo](";
                    qry += "  Email, WebPage, UserGuide, YouTube, Telephone ";
                    qry += " ) Values (";
                    qry += "'" + c.Email + "','" + c.WebPage + "','" + c.UserGuide + "','" + c.YouTube + "','" + c.Telephone + "')";

               
                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string SaveSMTPSetting(SMTP s)
        {


            string error_msg = "";

            try
            {
                string qry = "";

                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;


                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                qry += " Delete From SMTP_Setting ";

                qry += " INSERT INTO [dbo].[SMTP_Setting](";
                qry += "  SMTP_Server, SMTP_Email, SMTP_Port,Sender_Email, User_Name, User_Password,Enable_SSL,BlackList_Email,Email_Frequency,App_Code ";
                qry += " ) Values (";
                qry += "'" + s.SMTPServer + "','" + s.SMTPEmail + "'," + s.Port + ",'" + s.SenderEmail + "','" + s.UserName + "','" + s.Password + "', ";
                qry +=  "'" + s.SSLEnable + "','" + s.BlackListEmail + "'," + s.EmailFrequency + ",'" + appCode + "')";

                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string SaveCaptureSetting(CaptureSetting c , ProcessTrigger p )
        {


            string error_msg = "";

            try
            {
                string qry = "";

                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;


                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                qry += " Delete From Process_Trigger Where Prc_Code='" + p.PrcCode +"'";

                qry += " INSERT INTO [dbo].[Process_Trigger](";
                qry += "  Prc_Code, Prc_Name, TriggerTime_hours,SpendTime_hours";
                qry += " ) Values (";
                qry += "'" + p.PrcCode + "','" + p.PrcName + "'," + p.TriggerTime + "," + p.SpendTime + ")";

                qry += " Delete From CaptureSetting ";

                qry += " INSERT INTO [dbo].[CaptureSetting](";
                qry += " AccuracyLevel,MinNPLength, MaxNPLength, MotionFrame";
                qry += " ) Values (";
                qry +=  c.AccuracyLevel + "," + c.MinNPLength + "," + c.MaxNPLength+ "," + c.MotionFrameNo  + ")";


                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string SaveNotes(Notes N)
        {


            string error_msg = "";

            try
            {
                string qry = "";

                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;


                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                qry += " Delete From [NotesDetail] Where ANPR_Id=" + N.ANPR_Id ;

                qry += " INSERT INTO [dbo].[NotesDetail](";
                qry += "  Nt_Notes, Nt_Date, ANPR_NumberPlate,vhc_ListCode,ANPR_Id";
                qry += " ) Values (";
                qry += "'" + N.Note_Notes + "','" + N.Note_dt + "','" + N.NP + "'," + N.Lst_Type + "," + N.ANPR_Id + ")";


                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public string UpdateProcessTrigger(ProcessTrigger p)
        {


            string error_msg = "";

            try
            {
                string qry = "";

                //Step 1 -- Define the connection string
                //string ConnString = ConfigurationManager.ConnectionStrings["NAYDrive_Conn"].ConnectionString;


                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                

                qry += " Update [Process_Trigger] ";
                qry += " Set SpendTime_hours=" + p.SpendTime;
                qry += " Where Prc_Code='" + p.PrcCode +"'";
              
                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }


        public string UpdateLicHours(string _EncrypHours,string _ExpDateEncryp)
        {


            string error_msg = "";

            try
            {
                string qry = "";

               

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                DateTime dt = DateTime.Now;

                DataSet ds = new DataSet();

                qry = "SELECT  * From Lic";

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);


                if (ds.Tables[0].Rows.Count == 0)
                {
                    qry = " INSERT INTO [dbo].[Lic](";
                    qry += " C2,C3) ";
                    qry += " Values (";
                    qry += "'" + _EncrypHours + "','')";


                }
                else
                {
                    qry = " Update [Lic] ";
                    qry += " Set C2='" + _EncrypHours  + "' )";
              

                }

                sqlcmd.CommandText = qry;
                sqlcmd.Connection = sqlconn;

                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

            }
            catch (Exception ex)
            {
                error_msg = ex.Message;

            }

            return error_msg;

        }

        public DataSet Read_VehicleCode(string _numPlate)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT  vhc_Id, vhc_Name, vhc_Description, vhc_NumberPlate1, vhc_ListCode, vhc_Owner,";
                qry += " Case vhc_ListCode When 1 then 'White List Car' When 2 then 'Black List Car' When 3 then 'Visitor Car' End as  vhc_Type";
                qry += " FROM  VehicleMaster ";
                qry += " Where (vhc_NumberPlate1='" + _numPlate + "'";
                qry += " OR REPLACE(vhc_NumberPlate1, ' ', '') ='" + _numPlate.Replace(" ", "") + "' )";

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_VehicleMaster(VehicleMaster vm)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";
                qry = "SELECT  vhc_Id,vhc_NumberPlate1, vhc_Name, vhc_Description,  vhc_ListCode, vhc_Owner,";
                qry += " Listed_Type.Lst_Type vhc_Type";
                qry += " FROM  VehicleMaster INNER JOIN Listed_Type ON VehicleMaster.vhc_ListCode = Listed_Type.Lst_Id  Where 1=1";

                if(vm.vhc_NumberPlate1!="")
                {
                    qry += " AND (vhc_NumberPlate1 Like'%" + vm.vhc_NumberPlate1 + "%' OR Replace(vhc_NumberPlate1,' ','') Like '%" + vm.vhc_NumberPlate1 + "%')" ;
                }

                if (vm.vhc_Description != "")
                {
                    qry += " AND vhc_Description Like'%" + vm.vhc_Description + "%'";
                }

                if (vm.vhc_Name != "")
                {
                    qry += " AND vhc_Name Like'%" + vm.vhc_Name + "%'";
                }

                if (vm.vhc_Owner != "")
                {
                    qry += " AND vhc_Owner Like'%" + vm.vhc_Owner + "%'";
                }


                qry += " Order By vhc_Id";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_ANPR_Detail(string _fromdt ,string _Todt, string _NP,string _owner,int _lstCode,string _VchName,string VchDes, int _camera_id, int _camera_dir)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT a.ANPR_Id, a.ANPR_NumberPlate,a.ANPR_Time,   Listed_Type.Lst_Type as vhc_Type,";
                qry += " c.Cam_Name,c.Cam_Direction, a.City_Code,a.City_Name , v.vhc_Description,v.vhc_Name, v.vhc_NumberPlate1, ISNULL(v.vhc_ListCode,3) vhc_ListCode, v.vhc_Owner,";
                qry += " v.vhc_Id,a.Confidence_Level,a.Pic_Path";
                qry += " FROM ANPRDetail AS a LEFT OUTER JOIN  VehicleMaster AS v ON a.vhc_Id = v.vhc_Id  LEFT OUTER JOIN  Listed_Type ON a.vhc_ListCode = Listed_Type.Lst_Id ";
                qry += " LEFT OUTER JOIN  CameraInfo c ON a.Cam_Id =c.Cam_Id";
                qry += " Where a.ANPR_Date>='" + _fromdt + "' AND a.ANPR_Date<='" + _Todt + "'";

                if (_NP!="")
                {
                    qry += " AND (a.ANPR_NumberPlate Like '%" + _NP + "%'  OR Replace(a.ANPR_NumberPlate,' ','') Like '%" + _NP + "%')";
                }

                if (_owner != "")
                {
                    qry += " AND v.vhc_Owner Like '%" + _owner + "%'";
                }

                if (_VchName != "")
                {
                    qry += " AND v.vhc_Name Like '%" + _VchName + "%'";
                }

                if (VchDes != "")
                {
                    qry += " AND v.vhc_Description Like '%" + VchDes + "%'";
                }


                if (_lstCode != 0)
                {
                    qry += " AND v.vhc_ListCode =" + _lstCode + "";
                }

                if (_camera_id != 0)
                {
                    qry += " AND c.Cam_Id =" + _camera_id + "";
                }

                if (_camera_dir != 0)
                {
                    qry += " AND c.Cam_DirectionCode =" + _camera_dir + "";
                }

                qry += " Order By ANPR_Time Desc";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_ANPR_DetailNotes(string _fromdt, string _Todt, string _NP, string _owner, int _lstCode, string _VchName, string VchDes, int _camera_id, int _camera_dir,string Notes)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT a.ANPR_Id,n.Nt_Notes, a.ANPR_NumberPlate,a.ANPR_Time,   Listed_Type.Lst_Type as vhc_Type,";
                qry += " c.Cam_Name,c.Cam_Direction, a.City_Code,a.City_Name , v.vhc_Description,v.vhc_Name, v.vhc_NumberPlate1, ISNULL(v.vhc_ListCode,3) vhc_ListCode, v.vhc_Owner,";
                qry += " v.vhc_Id,a.Confidence_Level,a.Pic_Path";
                qry += " FROM ANPRDetail AS a LEFT OUTER JOIN  VehicleMaster AS v ON a.vhc_Id = v.vhc_Id  LEFT OUTER JOIN  Listed_Type ON a.vhc_ListCode = Listed_Type.Lst_Id ";
                qry += " LEFT OUTER JOIN  CameraInfo c ON a.Cam_Id =c.Cam_Id LEFT OUTER JOIN  NotesDetail n ON n.ANPR_Id =a.ANPR_Id";
                qry += " Where a.ANPR_Date>='" + _fromdt + "' AND a.ANPR_Date<='" + _Todt + "'";

                if (_NP != "")
                {
                    qry += " AND (a.ANPR_NumberPlate Like '%" + _NP + "%'  OR Replace(a.ANPR_NumberPlate,' ','') Like '%" + _NP + "%')";
                }

                if (_owner != "")
                {
                    qry += " AND v.vhc_Owner Like '%" + _owner + "%'";
                }

                if (_VchName != "")
                {
                    qry += " AND v.vhc_Name Like '%" + _VchName + "%'";
                }

                if (VchDes != "")
                {
                    qry += " AND v.vhc_Description Like '%" + VchDes + "%'";
                }

                if (Notes != "")
                {
                    qry += " AND n.Nt_Notes Like '%" + Notes + "%'";
                }


                if (_lstCode != 0)
                {
                    qry += " AND v.vhc_ListCode =" + _lstCode + "";
                }

                if (_camera_id != 0)
                {
                    qry += " AND c.Cam_Id =" + _camera_id + "";
                }

                if (_camera_dir != 0)
                {
                    qry += " AND c.Cam_DirectionCode =" + _camera_dir + "";
                }

                qry += " Order By ANPR_Time Desc";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_ANPR_Vhcl(int _vhc_Id)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT a.ANPR_Id, a.ANPR_NumberPlate,a.ANPR_Time,  v.vhc_Name, Case ISNULL(v.vhc_ListCode,3) When 1 then 'White List Car' When 2 then 'Black List Car' When 3 then 'Visitor Car' End as vhc_Type,";
                qry += " a.City_Code,a.City_Name , v.vhc_Description, v.vhc_NumberPlate1, ISNULL(v.vhc_ListCode,3) vhc_ListCode, v.vhc_Owner,";
                qry += " v.vhc_Id,a.Confidence_Level,a.Pic_Path,a.Pic_PathHD";
                qry += " FROM ANPRDetail AS a LEFT OUTER JOIN  VehicleMaster AS v ON a.vhc_Id = v.vhc_Id";
                qry += " Where a.ANPR_Id=" + _vhc_Id ;


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_CameraInfo()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];


                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";
                qry = "SELECT  Cam_Id, Cam_Name,Cam_DirectionCode, Cam_Direction, Cam_StreamURL,User_Name,User_Password, ThersholdSeconds,Cam_IP,Resolut_Width,Resolut_Height, Cam_Enable,IsRecording, CreatedOn,";
                qry += " RecordingPath,ANPRImagePath,RecordingDeleteHours";
                qry += " FROM  CameraInfo Where App_Code='" + appCode + "'";

                qry += " Order By Cam_Id";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_CameraInfo(int camid)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];


                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";
                qry = "SELECT  Cam_Id, Cam_Name,Cam_DirectionCode, Cam_Direction, Cam_StreamURL,User_Name,User_Password, ThersholdSeconds,Cam_IP,Resolut_Width,Resolut_Height, Cam_Enable,IsRecording, CreatedOn,";
                qry += " RecordingPath,ANPRImagePath,RecordingDeleteHours";
                qry += " FROM  CameraInfo Where App_Code='" + appCode + "' AND Cam_Id=" + camid;

                qry += " Order By Cam_Id";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_Info()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];


                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";
                qry = "SELECT  Email, WebPage, UserGuide, YouTube, Telephone";
                qry += " FROM CompInfo";
               
                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public int Read_ActiveCameraCount()
        {
            DataSet ds = new DataSet();
            int cam_Count = 0;

            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];


                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT  ISNULL(Count(Cam_Id),0) Cam_count ";
                qry += " FROM  CameraInfo Where App_Code='" + appCode + "'";
              
                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    cam_Count =Convert.ToInt16( dr["Cam_count"].ToString());
                }

            }
            catch (Exception ex)
            {

            }
            return cam_Count;
        }


        public DataSet Read_Camera_Combo()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];


                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry += " Select 0 Cam_Id, 'Hepsi' Cam_Name";
                qry += " Union";
                qry += " SELECT  Cam_Id, Cam_Name";
                qry += " FROM  CameraInfo Where App_Code='" + appCode + "'";
                qry += " Order By Cam_Id";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_Roles()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];


                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";
                qry = "SELECT RoleId, RoleName, RoleDescription, RoleITypeCode ";
                qry += " FROM RoleMaster";
                qry += " Order By RoleId";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_LastNumberPlate(int camid,string np)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];


                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";
                qry = "SELECT  TOP 1 ANPR_NumberPlate, ANPR_Time";
                qry += " FROM  ANPRDetail Where App_Code='" + appCode + "'"; // "' AND Cam_Id=" + camid;
                qry += " AND (ANPR_NumberPlate='" + np + "' OR REPLACE(ANPR_NumberPlate, ' ', '') ='" + np.Replace(" ","") + "' )";
                qry += " Order By ANPR_Time Desc ";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_CitynCountry_F1(string CityCode1, string CityCode2)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];


                SqlConnection sqlconn = new SqlConnection(ConnString);

                string qry = "";
                qry = "SELECT   City_Code, City_Name, Country_Name";
                qry += " FROM  CityDetail";
                qry += " Where City_Code Like '%" + CityCode1 + "%' OR  City_Code Like '%" + CityCode2 + "%' ";



                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }


        public string Read_NP_Notes(int anpr_id)
        {
            string notes = "";
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = " SELECT  Nt_Id, Nt_Notes, Nt_Date, ANPR_NumberPlate, vhc_ListCode ";
                qry += " FROM  NotesDetail ";
                qry += " Where ANPR_Id=" + anpr_id ;


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    notes = dr["Nt_Notes"].ToString();
                }

            }
            catch (Exception ex)
            {

            }

            return notes;
        }


        public DataSet Read_UserProfileForlogin(Users u)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT UserName, Email, Password,FirstName, LastName,RoleId ";
                qry += " FROM  UserProfile ";
                qry += " Where UserName='" + u.UserName + "' AND Password='" + u.Password + "'";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }

            return ds;
        }

        public DataSet Read_ListedType(bool _isAllInclude,int listid=0)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = " SELECT Lst_Id id, Lst_Type Name";
                qry += " FROM Listed_Type Where 1=1";

                if(!_isAllInclude)
                {
                    qry += " AND Lst_Id Not In (0)";
                }
                
                if (listid>0)
                {
                    qry += " AND Lst_Id=" + listid;
                }

                qry += " Order By  Lst_Id";
               

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_ActType(bool _isAllInclude)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = " SELECT Act_Id, Act_Name, Act_Durration, Act_Type";
                qry += " FROM DeviceAction Where 1=1";

                if (!_isAllInclude)
                {
                    qry += " AND Act_Id Not In (0)";
                }

                qry += " Order By  Act_Id";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_AllUsers()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT UserId,UserName, Email, Password,FirstName, LastName,ISNULL(Is_Active,0) Is_Active,";
                qry += " ISNULL((SELECT r.RoleName FROM RoleMaster r Where r.RoleId= UserProfile.RoleId),'') UserRole,ISNULL(RoleId,0) RoleId ";
                qry += " FROM  UserProfile ";
                //qry += " Where Email='" + _email + "'";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_AllDevices()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT  Id, Dev_Id, Dev_Name, Dev_Descrp, Chanel_0, Chanel_1, Chanel_2,Dev_LocalIP";
                qry += " FROM  DeviceDetail ";
               

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_DevicesTrg_Process(int camId, int LstCode)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT d.Id, d.Cam_Id, d.Dev_Id, d.Act_Id, d.Dev_RelayNo, d.Lst_Id, a.Act_Durration, a.Act_Type,Connection_Type,Dev_LocalIP";
                qry += " FROM DeviceTrigger AS d INNER JOIN  DeviceAction AS a ON d.Act_Id = a.Act_Id";
                qry += " INNER JOIN  DeviceDetail dev ON dev.Dev_Id = d.Dev_Id";
                qry += " Where d.Cam_Id=" + camId + " AND d.Lst_Id=" + LstCode;


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_DevicesTrg()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT  t.Id, t.Cam_Id, t.Dev_Id, t.Act_Id, t.Dev_RelayNo, t.Lst_Id, c.Cam_Name, c.Cam_Direction,t.Connection_Type,d.Dev_LocalIP";
                qry += " FROM DeviceTrigger AS t INNER JOIN CameraInfo AS c ON t.Cam_Id = c.Cam_Id INNER JOIN";
                qry += " DeviceDetail AS d ON t.Dev_Id = d.Dev_Id";
                

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_CompInfo()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT  Id, Email, WebPage, UserGuide, YouTube, Telephone ";
                qry += " FROM  CompInfo ";
               

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_SMTP()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT  SMTP_Id, SMTP_Server, SMTP_Email, SMTP_Port, Sender_Email,User_Name, User_Password, Enable_SSL, BlackList_Email, Email_Frequency, App_Code\r\n ";
                qry += " FROM  SMTP_Setting ";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_CaptureSetting()
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT AccuracyLevel, MinNPLength, MaxNPLength, MotionFrame ";
                qry += " FROM  CaptureSetting ";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_ProcessTrigger(string Prc_Code)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT   Prc_Code, Prc_Name, TriggerTime_hours, SpendTime_hours ";
                qry += " FROM  Process_Trigger Where 1=1";

                if (Prc_Code!="")
                {
                    qry += " AND  Prc_Code='" + Prc_Code + "'";
                }

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }

        public DataSet Read_DeviceTrigger(string Prc_Code)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                string appCode = ConfigurationManager.AppSettings["AppCode"];

                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT   Prc_Code, Prc_Name, TriggerTime_hours, SpendTime_hours ";
                qry += " FROM  Process_Trigger Where 1=1";

                if (Prc_Code != "")
                {
                    qry += " AND  Prc_Code='" + Prc_Code + "'";
                }

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);
                ad.Fill(ds);
            }
            catch (Exception ex)
            {
                //PushExceptionMsg(ex.Message, ex.HResult);
            }

            return ds;
        }


        public DataSet Report_ListedWiseVech(string _fromdt,string _Todt)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT  Count(ANPR_NumberPlate) ct_vhc, Listed_Type.Lst_Type,ANPRDetail.vhc_ListCode ";
                qry += " FROM  ANPRDetail INNER JOIN Listed_Type ON ANPRDetail.vhc_ListCode = Listed_Type.Lst_Id";
                qry += " Where ANPR_Date Between '" + _fromdt + "' AND '" + _Todt + "' AND Listed_Type.Lst_Id<>0 ";
                qry += " Group By Listed_Type.Lst_Type,ANPRDetail.vhc_ListCode ";
               


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Report_DayWiseVech(string _fromdt, string _Todt)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT Top 7 Count(ANPR_NumberPlate) ct_vhc, ANPR_Date ";
                qry += " FROM  ANPRDetail ";
                qry += " Where ANPR_Date Between '" + _fromdt + "' AND '" + _Todt + "'";
                qry += " Group By ANPR_Date ";



                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Report_MonthlyTotal(string _fromdt, string _Todt)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT Top 7 Count(ANPR_NumberPlate) ct_vhc, DATENAME(month,ANPR_Date) Month_name ";
                qry += " FROM  ANPRDetail ";
                qry += " Where 1=1";
                qry += "  Group By DATENAME(month,ANPR_Date)";
                qry += " Order by DATENAME(month,ANPR_Date)  desc";



                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_LastVch_Lst(int _ANPR_Id,int Record_Nos)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT Top " + Record_Nos + " ANPR_Id, ANPR_NumberPlate, ANPR_Date, ANPR_Time,Pic_Path, Pic_PathHD,vhc_ListCode";
                qry += " FROM  ANPRDetail ";
                qry += " Where 1=1";

                if (_ANPR_Id>0)
                {
                    qry += " AND ANPR_Id<=" + _ANPR_Id; //Is equal to and less than current id
                }

                qry += " Order By ANPR_Id Desc ";



                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_LastVch_Lst_Next(int _ANPR_Id, int Record_Nos)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT Top " + Record_Nos + " ANPR_Id, ANPR_NumberPlate, ANPR_Date, ANPR_Time,Pic_Path, Pic_PathHD,vhc_ListCode";
                qry += " FROM  ANPRDetail ";
                qry += " Where 1=1";

                if (_ANPR_Id > 0)
                {
                    qry += " AND ANPR_Id>=" + _ANPR_Id; //Is equal to and less than current id
                }

                qry += " Order By ANPR_Id ";



                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataSet Read_LastVch_Lst_Prev(int _ANPR_Id, int Record_Nos)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT Top " + Record_Nos + " ANPR_Id, ANPR_NumberPlate, ANPR_Date, ANPR_Time,Pic_Path, Pic_PathHD,vhc_ListCode";
                qry += " FROM  ANPRDetail ";
                qry += " Where 1=1";

                if (_ANPR_Id > 0)
                {
                    qry += " AND ANPR_Id<=" + _ANPR_Id; //Is equal to and less than current id
                }

                qry += " Order By ANPR_Id Desc";

                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }


        public DataSet Read_FirstVch_Lst(int _ANPR_Id, int Record_Nos)
        {
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT Top " + Record_Nos + " ANPR_Id, ANPR_NumberPlate, ANPR_Date, ANPR_Time,Pic_Path, Pic_PathHD,vhc_ListCode";
                qry += " FROM  ANPRDetail ";
                qry += " Where 1=1";

                if (_ANPR_Id > 0)
                {
                    qry += " AND ANPR_Id>=" + _ANPR_Id;
                }

                qry += " Order By ANPR_Id ";



                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }


        public int Read_MaxIdANPR()
        {
            int _maxid = 0;
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT ISNULL(MAX(ANPR_Id),0) ANPR_Id";
                qry += " FROM  ANPRDetail ";
                qry += " Where 1=1";


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    _maxid = Convert.ToInt32(dr["ANPR_Id"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            return _maxid;
        }

        public int Read_MinIdANPR(string _fromdt, string _Todt)
        {
            int _maxid = 0;
            DataSet ds = new DataSet();
            try
            {

                string ConnString = ConfigurationManager.AppSettings["ConnString"];
                SqlConnection sqlconn = new SqlConnection(ConnString);
                string qry = "";

                qry = "SELECT ISNULL(Min(ANPR_Id),0) ANPR_Id";
                qry += " FROM  ANPRDetail ";
               qry += " Where ANPR_Date Between '" + _fromdt + "' AND '" + _Todt + "'"; ;


                SqlDataAdapter ad = new SqlDataAdapter(qry, sqlconn);

                ad.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    _maxid = Convert.ToInt32(dr["ANPR_Id"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            return _maxid;
        }



    }


}
