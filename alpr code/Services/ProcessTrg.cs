using ANPR_General.Entity;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http;

namespace ANPR_General.Services
{
    public class ProcessTrg
    {

        public void Delete_MotionImg()
        {
            try
            {

                string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string binDirectory = Path.GetDirectoryName(currentDirectory);
                string imgPath = "";

                DataSet ds = new DataSet();
                DAL dal = new DAL();
                ds = dal.Read_CameraInfo();
                string camId = "";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    camId = dr["Cam_Id"].ToString();
                    Communication c = new Communication();
                    string recordingpath = c.Get_Path(Communication.PathType.Motion_Img, Vald.GetNumeric(camId));


                    System.IO.DirectoryInfo di = new DirectoryInfo(recordingpath);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public void Delete_RecordingImg()
        {
            try
            {

                string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string binDirectory = Path.GetDirectoryName(currentDirectory);
                string imgPath = "";

                DataSet ds = new DataSet();
                DAL dal = new DAL();
                ds = dal.Read_CameraInfo();
                string camId = "";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    camId = dr["Cam_Id"].ToString();
                    Communication c = new Communication();
                    string recordingpath = c.Get_Path(Communication.PathType.RecordingRoot, Vald.GetNumeric(camId));


                    System.IO.DirectoryInfo di = new DirectoryInfo(recordingpath);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public void Process_Delete_MotionImg()
        {
            try
            {

                DAL dal = new DAL();

                ProcessTrigger p = new ProcessTrigger();

                p.PrcCode = "motion_img";
                p.SpendTime = 1;
               

                DataSet ds = new DataSet();

                ds = dal.Read_ProcessTrigger("motion_img");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    p.SpendTime = Convert.ToInt16(dr["SpendTime_hours"].ToString());
                    p.TriggerTime = Convert.ToInt16(dr["TriggerTime_hours"].ToString());
                }

                p.SpendTime++;

                if (p.SpendTime>= p.TriggerTime)
                {
                    Delete_MotionImg();
                    p.SpendTime = 0;
                }

                dal.UpdateProcessTrigger(p);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public void Process_Delete_RecordingImg()
        {
            try
            {

                DAL dal = new DAL();

                ProcessTrigger p = new ProcessTrigger();

                p.PrcCode = "Recording_img";
                p.SpendTime = 1;


                DataSet ds = new DataSet();

                ds = dal.Read_ProcessTrigger("Recording_img");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    p.SpendTime = Convert.ToInt16(dr["SpendTime_hours"].ToString());
                    p.TriggerTime = Convert.ToInt16(dr["TriggerTime_hours"].ToString());
                }

                p.SpendTime++;

                if (p.SpendTime >= p.TriggerTime)
                {
                    p.SpendTime = 0;
                    Delete_RecordingImg();
                }

                dal.UpdateProcessTrigger(p);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        public void Process_main()
        {
            Process_Delete_MotionImg();
            Process_Delete_RecordingImg();

        }
        public void  Process_Shelly_Trg(ANPRDetail A)
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_DevicesTrg_Process(A.Cam_Id,A.vhc_ListCode);
                int Swt_Type = 0;
                int Act_Durr = 0;
                int chan_No = 0;
                int Conn_Type = 0;
                string dev_id = "";
                string IP = "";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Swt_Type = Vald.GetNumeric(dr["Act_Type"].ToString());
                    Act_Durr = Vald.GetNumeric(dr["Act_Durration"].ToString());
                    chan_No = Vald.GetNumeric(dr["Dev_RelayNo"].ToString());
                    dev_id = dr["Dev_Id"].ToString();
                    Conn_Type = Vald.GetNumeric(dr["Connection_Type"].ToString());
                    IP = dr["Dev_LocalIP"].ToString();

                    ShellySwt_On(dev_id, chan_No, Act_Durr, Conn_Type, IP);

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public async void Process_RPI_Trg(ANPRDetail A, string ip = "")
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds = new DataSet();
               
                int Swt_Type = 0;
                int Act_Durr = 0;
                int chan_No = 0;
                int Conn_Type = 0;
                string dev_id = "";
                string IP = "";

                if (A.vhc_ListCode==1)
                {
                    await RPI_API_Trigger(ip);
                }
                

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        public async Task RPI_API_Trigger(string ip="")
        {
            try
            {

                if (ip=="")
                {
                    ip = "127.0.0.1:5000";
                }

                string endPoint = "http://"+ ip + "/OnOff/";
                var client = new HttpClient();

                var contents = await client.GetStringAsync(endPoint);

                //var _status = JsonConvert.DeserializeObject<RootData>(contents);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "System Error");
            }
        }


        public async void ShellySwt_On(string dev_id,int rel_No,int durr, int Conn_Type,string local_IP)
        {

            ShellyAPI s = new ShellyAPI();
            string status="on";

            if (Conn_Type==1) //********** For Cloud API
            {
                _ = s.ShellySwitch(rel_No, dev_id, "", status);

                durr = durr * 1000;

                Thread.Sleep(durr);
                status = "off";
                _ = s.ShellySwitch(rel_No, dev_id, "", status);
            }
            else //********** For hit local IP
            {
                _ = s.ShellySwitchLocal(rel_No, status, local_IP);
            }
          
        }

    }
}
