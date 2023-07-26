using ANPR_General.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANPR_General.Services;
using System.Threading;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ANPR_General
{
    public partial class frmMainMenu : Form
    {

        private Form activeForm;
        frmANPR_WareLogic fm = null;
        public int _RoleId;
        Communication c;
        private static Mutex mutex = null;
        public frmMainMenu()
        {
            InitializeComponent();
        }

        public void Set_Lang()
        {
           Communication c = new Communication();
           bool FlgEngl = c.IsLangEnglish();

           if (FlgEngl)
           {
                btnDashboard.Text = "                Dashboard";
                btnDashboardGrid.Text = "                Dashboard Grid";
                btnANPR.Text = "                Live View";
                btnSetting.Text = "                Setting";
                btnReports.Text = "                Reports";
                btnVehicleUpdate.Text = "                Vehicle";
                btnInfo.Text = "                Info";
                btnLogIn.Text = "                LogIn";
                btnLogout.Text = "                Logout";

            }

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard(), sender);
        }

        private void btnANPR_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmANPR(), sender);
            OpenANPRForm(false);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Report(), sender);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSetting(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmLogin(), sender);
            SetLoginStatus(0, false);
            OpenChildForm(new frmLogin(this), sender);
            //OpenChildForm(new frmDefaultScreen(), sender);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInfo(), sender);
        }


        public void OpenChildForm(Form childForm,object btnSendor)
        {

            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbltitle.Text = childForm.Text + " ";

        }

        private void btnVehicleUpdate_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmVehicleUpdate(), sender);
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Mutex mut =
                        new System.Threading.Mutex(false, Application.ProductName);
                bool running = !mut.WaitOne(0, false);
                if (running)
                {
                    Application.ExitThread();
                    return;
                }
                Set_Lang();

                //******** Set Timmer Interval ***********
                int mintues_Conv = 1000 * 60;
                int Mints_App = 60; //********** This is for timmer
                int Totalmintues = mintues_Conv* Mints_App;

                timer_App.Interval = Totalmintues;

                c = new Communication();
                getConfig();
                OpenChildForm(new frmLogin(this), sender);

                //********* Get Startup parameter 

                string[] args = Environment.GetCommandLineArgs();
                string _StartPara = "";

                if(args.Length> 1)
                {
                    //MessageBox.Show(args[1]);
                    _StartPara = args[1];
                }
               
                if(_StartPara=="LPR")
                {
                    OpenANPRForm(true);
                }

                timer_App.Interval = 60 * 1000; //** For 60 seconds
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

        }

        private void getConfig()
        {
            string appName = ConfigurationManager.AppSettings.Get("AppName");
            this.Text = appName;
            //string imgfilepath = ConfigurationManager.AppSettings.Get("logoPath");
            //string imgpath = ConfigurationManager.AppSettings.Get("logoFolder");


            string imgpath = c.Get_Path(Communication.PathType.Logo);

            //SetAccessRights(imgpath);

            string imgfilepath = imgpath + "logo.png";

            string tempPath = imgpath + "\\temp";

            System.IO.Directory.CreateDirectory(tempPath);
            //SetAccessRights(tempPath);

            string sourceFile = imgfilepath;
            string destFile = imgpath + "\\temp\\" +DateTime.Now.ToString("ddMMHHss.png");

            if (File.Exists(sourceFile))
            {
                System.IO.File.Copy(sourceFile, destFile, true);
                Image img;
                img = Image.FromFile(destFile);

                if (imgpath != "")
                {
                    picture_logo.Image = img;
                }
                picture_logo.SizeMode = PictureBoxSizeMode.StretchImage;
               
            }
            SetLoginStatus(0, false);
            //Get_font();

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
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void OpenANPRForm(bool flgStartup)
        {
            
            if (fm == null || fm.Text == "")
            {
                fm = new frmANPR_WareLogic(flgStartup);
                //fm.MdiParent = this;
                fm.Dock = DockStyle.Fill;
                fm.Show();
            }
            else if (CheckOpened(fm.Name))
            {
                fm.WindowState = FormWindowState.Normal;
                fm.Dock = DockStyle.Fill;
                fm.Show();
                fm.Focus();
            }

            //frmANPR fm =null;
            //if (CheckOpened("frmANPR"))
            //{
            //    fm = new frmANPR();
            //    fm.WindowState = FormWindowState.Normal;
            //    //fm.Dock = DockStyle.Fill;
            //    fm.Show();
            //    fm.Focus();
            //}
            //else
            //{
            //    //fm.MdiParent = this;
            //    //fm.Dock = DockStyle.Fill;
            //    fm.Show();
            //}



        }

        public void SetLoginStatus(int role,bool FlgValidLogin)
        {

            btnDashboard.Visible = FlgValidLogin;
            btnANPR.Visible = FlgValidLogin;
            btnReports.Visible = FlgValidLogin;
            btnVehicleUpdate.Visible = FlgValidLogin;
            btnInfo.Visible = FlgValidLogin;
            //btnSetting.Visible = FlgValidLogin;
            btnLogout.Visible = FlgValidLogin;

            if (FlgValidLogin) //******** if login true
            {
                if(role==1) // ****** If admin user
                {
                    btnSetting.Visible = FlgValidLogin;
                }
                else
                {
                    btnSetting.Visible = false;
                }
            }
            else
            {
                btnSetting.Visible = false;
            }

            btnLogIn.Visible = !FlgValidLogin;
            btnDashboardGrid.Visible = FlgValidLogin;

        }

        public void Enable_AppLifeCount()
        {
            timer_App.Enabled = true;
        }

        public void NotifyMe(string s)
        {
            // Do whatever you need to do with the string
            Console.WriteLine(s);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLogin(this), sender);

            //frmLogin sf = new frmLogin(this);
            //sf.ShowDialog();
            //if (sf.DialogResult == DialogResult.OK)
            //{
            //    SetLoginStatus(_RoleId, true);
            //}

        }

        private void timer_tm_Tick(object sender, EventArgs e)
        {
            Get_Time();
        }

        private void Get_Time()
        {
            lbltime.Text = DateTime.Now.ToString("hh:mm:ss");
            lbltm_Type.Text = DateTime.Now.ToString("tt");

            lbldt.Text = DateTime.Now.ToString("dd/MM");
            lbl_Day.Text = DateTime.Now.ToString("ddd");
        }

        private void Get_font()
        {
            try
            {


                //PrivateFontCollection pfc = new PrivateFontCollection();
                //Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("ANPR_V1.Digital7Italic-BW658.ttf");
                //byte[] fontdata = new byte[fontStream.Length];
                //fontStream.Read(fontdata, 0, (int)fontStream.Length);
                //fontStream.Close();
                //unsafe
                //{
                //    fixed (byte* pFontData = fontdata)
                //    {
                //        pfc.AddMemoryFont((System.IntPtr)pFontData, fontdata.Length);
                //    }
                //}
                //lbltime.Font = new Font(pfc.Families[0], 32, FontStyle.Italic);
            }
            catch(Exception ex1)
            {

            }

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer_App_Tick(object sender, EventArgs e)
        {
            try
            {
                //*************** Run Process Trigger ********

                ProcessTrg p = new ProcessTrg();
                p.Process_main();

            }
            catch(Exception ex)
            {

            }
        }

        private bool IsValidLicense()
        {
            bool isValid = true;
            try
            {
                
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return isValid;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenANPRForm(false);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            OpenANPRForm(false);
        }

        private void btnDashboardGrid_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboardSlider(), sender);
        }
    }
}
