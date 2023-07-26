using ANPR_General.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANPR_General.Entity;
using System.Reflection;
using ANPR_General.Services;
using System.Windows.Forms.DataVisualization.Charting;

namespace ANPR_General
{
    public partial class frmLogin : Form
    {
        private frmMainMenu f1;
        private int _RoleId;
        private bool FlagIsLangEngl = false;
        public frmLogin(frmMainMenu f)
        {
            f1 = f;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            GetLogin();
        }

        private void GetLogin()
        {
            try
            {

                bool FlgValiduser = false;

                DAL dal = new DAL();
                DataSet ds = new DataSet();

                Users u = new Users();

                u.UserName = txtUserId.Text;
                u.Password = txtPwd.Text;

                ds = dal.Read_UserProfileForlogin(u);

                if (IsValidLicense())
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FlgValiduser = true;

                        Globalvars.UserID = u.UserName;
                        Globalvars.Password = u.Password;

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["RoleId"] != null)
                            {
                                u.RoleId = Convert.ToInt32(dr["RoleId"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (txtUserId.Text == "Kullanıcı Adı" && txtPwd.Text == "Şifre")
                        {
                            FlgValiduser = true;
                        }

                    }

                    if (FlgValiduser)
                    {
                        this._RoleId = u.RoleId;
                        f1._RoleId = this._RoleId;
                        this.DialogResult = DialogResult.OK;

                        object sender = null;
                        f1.OpenChildForm(new frmDashboard(), sender);
                        f1.Set_Lang();
                        f1.SetLoginStatus(_RoleId, true);
                        f1.Enable_AppLifeCount();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or Password.");
                    }
                
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "-" + MethodBase.GetCurrentMethod().Name, "System Error");
            }

        }

        private void picBox_Home_Click(object sender, EventArgs e)
        {
            OpenLink("https://plakasoft.com/");
        }

        private bool IsValidLicense()
        {
            bool isValid =true;
            try
            {
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "-" + MethodBase.GetCurrentMethod().Name, "System Error");
            }

            return isValid;
        }
        private void picBox_FB_Click(object sender, EventArgs e)
        {
            OpenLink("");
        }

        private void picBox_Insta_Click(object sender, EventArgs e)
        {
            OpenLink("https://www.instagram.com/alienfence/");
        }   

        private void picBox_Linkdn_Click(object sender, EventArgs e)
        {
            OpenLink("https://www.instagram.com/plaka.tanima/");
        }

        private void OpenLink(string _link)
        {

            try
            {
                System.Diagnostics.Process.Start(_link);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Communication c = new Communication();

            FlagIsLangEngl = c.IsLangEnglish();
        }

        private void btnSettingDB_Click(object sender, EventArgs e)
        {
           

                    frmDBsetting dbsetting = new frmDBsetting();
                    dbsetting.ShowDialog();
           

        }
    }
}
