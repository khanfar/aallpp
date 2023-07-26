using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Security;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using DataModel;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Configuration;
using System.Reflection;
using System.IO;
using iTextSharp.text.pdf;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ANPR_General.Services
{
    public class Communication
    {

        public string Send_Email(string pSubject, string pBody,bool pisHTML)
        {
            string Msg = "";

            try
            {
                DAL dal = new DAL();
                DataSet ds = new DataSet();

                ds = dal.Read_SMTP();

                string SMTP_Server = "";
                string SMTP_Email = "";
                int SMTP_Port = 0;
                string User_Name = "";
                string User_Password = "";
                string ToAddress = "";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    SMTP_Server = dr["SMTP_Server"].ToString();
                    SMTP_Email = dr["SMTP_Email"].ToString();
                    if (Vald.IsNumeric(dr["SMTP_Port"].ToString()))
                    {
                        SMTP_Port = Convert.ToInt32(dr["SMTP_Port"].ToString());
                    }
                    User_Name = dr["User_Name"].ToString();
                    User_Password = dr["User_Password"].ToString();
                    ToAddress = dr["Sender_Email"].ToString();
                }

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTP_Server);

                mail.From = new MailAddress(SMTP_Email);
                mail.To.Add(ToAddress);
                mail.Subject = pSubject;
                mail.IsBodyHtml=pisHTML;
                mail.Body = pBody;

                SmtpServer.Port = SMTP_Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(User_Name, User_Password);
                SmtpServer.EnableSsl = true;
               

                SmtpServer.Send(mail);

                return Msg;
            }
            catch (Exception ex)
            {
                return ex.Message;

            }


        }

       
        public void Send_BlackListEmail(string _np,string _dt)
        {
            try
            { 

                string Subject="";
                string Body = "";
                string ToAddress = "";

                Subject = "A Black List car is found at " + _dt;

                string htmlString = @"<html>

	                      <body>
	                      
	                      <p>A Black List car is found at " + _dt + @" .</p>

	                      <p> Number Plate is <strong>" + _np + @"</strong>   </p>

	                     

	                      </body>

	                      </html>

	                     ";

                Body = htmlString;

                Send_Email(Subject, Body, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        public string Send_EmailTest(string pToAddress, string pSubject, string pBody)
        {
            string Msg = "";

            try
            {


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("alifence32@gmail.com");
                mail.To.Add(pToAddress);
                mail.Subject = pSubject;
                mail.Body = pBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("alifence32@gmail.com", "klfyzyjdazexddzo");
                SmtpServer.EnableSsl = true;


                SmtpServer.Send(mail);

                return Msg;
            }
            catch (Exception ex)
            {
                return ex.Message;

            }


        }


        public string Get_Path(PathType pathtype,int Camid=0)
        {
            string path="";

            try
            {

                string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string binDirectory = Path.GetDirectoryName(currentDirectory);

                DAL dal = new DAL();

                DataSet ds = new DataSet();
                ds = dal.Read_CameraInfo(Camid);
                string _recordPath = "";
                string _ANPRImgPath = "";


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    _recordPath = dr["RecordingPath"].ToString();
                    _ANPRImgPath = dr["ANPRImagePath"].ToString();
                }

                if (pathtype == PathType.ANPR_Imge)
                {
                    path = binDirectory + "\\ANPR_Image\\";

                    if(_ANPRImgPath != "")
                    {
                        path = _ANPRImgPath + "\\";
                    }
                }

                if (pathtype == PathType.ANPR_ImgeHD)
                {
                    path = binDirectory + "\\ANPR_Image\\HD\\";

                    if (_ANPRImgPath != "")
                    {
                        path = _ANPRImgPath + "\\HD\\";
                    }
                }

                if (pathtype == PathType.BlackList)
                {
                    path = binDirectory + "\\ANPR_Image\\BlackList\\";

                    if (_ANPRImgPath != "")
                    {
                        path = _ANPRImgPath + "\\BlackList\\";
                    }
                }

                if (pathtype==PathType.Motion_Img)
                {
                    path = binDirectory + "\\motion_img\\";

                    if (_ANPRImgPath != "")
                    {
                        path = _ANPRImgPath + "\\motion_img\\";
                    }
                }

                if (pathtype == PathType.Export)
                {
                    path = binDirectory + "\\Export\\";
                }

                if (pathtype == PathType.Logo)
                {
                    path = binDirectory + "\\Logo\\";
                }

                if (pathtype == PathType.ThirdPartyLib)
                {
                    path = currentDirectory + "\\Third Party Lib\\";
                }

                if (pathtype == PathType.Recording)
                {
                    path = binDirectory + "\\Recording\\" + DateTime.Now.ToString("dd-MM") + "\\";
                   
                    if (_recordPath != "")
                    {
                        path = _recordPath + "\\Recording\\"  + DateTime.Now.ToString("dd-MM") + "\\";
                    }

                }

                if (pathtype == PathType.RecordingRoot)
                {
                    path = binDirectory + "\\Recording\\" ;

                    if (_recordPath != "")
                    {
                        path = _recordPath + "\\Recording\\";
                    }

                }

                if (pathtype == PathType.WebImage)
                {
                    path = "D:\\Ayaz Home Documents\\My Project\\Fivver\\ANPR General\\ANPR-General-Web\\ANPR_WebApp_V2\\ANPR_WebApp_V1\\Images\\ANPRImage\\";

                    path = ConfigurationManager.AppSettings.Get("WebImage");

                }

                if (pathtype == PathType.BinPath)
                {
                    path = binDirectory;

                }

                bool exists = System.IO.Directory.Exists(path);

                if (!exists)
                {
                    //SetAccessRights(binDirectory);
                    System.IO.Directory.CreateDirectory(path);
                    //SetAccessRights(path);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Commun");
            }

            return path;
        }

        public int Get_LanguageCode()
        {
            int LangCode  = 0;

            try
            {
                string strLangCode = ConfigurationManager.AppSettings.Get("langCode");

                LangCode = Vald.GetNumeric(strLangCode);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Commun");
            }

            return LangCode;

        }

        public bool IsLangEnglish()
        {
            bool FlgLang = true;

            try 
            {
                int LangCode = 0;

                LangCode = Get_LanguageCode();

                if (LangCode == 2)
                {
                    FlgLang = true;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Commun");
            }

            return FlgLang;
        }

        private void SetAccessRights(string file)
        {
            //FileSecurity fileSecurity = File.GetAccessControl(file);
            //AuthorizationRuleCollection rules = fileSecurity.GetAccessRules(true, true, typeof(NTAccount));
            //foreach (FileSystemAccessRule rule in rules)
            //{
            //    string name = rule.IdentityReference.Value;
            //    if (rule.FileSystemRights != FileSystemRights.FullControl)
            //    {
            //        FileSecurity newFileSecurity = File.GetAccessControl(file);
            //        FileSystemAccessRule newRule = new FileSystemAccessRule(name, FileSystemRights.FullControl, AccessControlType.Allow);
            //        newFileSecurity.AddAccessRule(newRule);
            //        File.SetAccessControl(file, newFileSecurity);
            //    }
            //}
        }


        public enum PathType
        {
            ANPR_Imge,
            ANPR_ImgeHD,
            Motion_Img,
            Export,
            Logo,
            ThirdPartyLib,
            Recording,
            RecordingRoot,
            BinPath,
            BlackList,
            WebImage
        }

        public string Get_QueryScripts( string filenamestr)
        {
            string qry="";

            try
            {

                string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filename = currentDirectory + "\\Scripts\\" + filenamestr;

                if (File.Exists(filename))
                {
                    // Read entire text file content in one string
                    string text = File.ReadAllText(filename);
                    qry=text;
                }

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);

            }

            return qry;
        }

    }
}
