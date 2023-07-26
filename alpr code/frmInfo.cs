using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANPR_General
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }


        private void GetData()
        {
            try
            {


                DAL dal = new DAL();
                DataSet ds = new DataSet();
                ds = dal.Read_Info();

                lblEmail.Text = "";
                lblWebPage.Text = "";
                lblUserGuide.Text = "";
                lblYouTube.Text = "";
                lblTelephone.Text = "";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lblEmail.Text = dr["Email"].ToString();
                    lblWebPage.Text = dr["WebPage"].ToString();
                    lblUserGuide.Text = dr["UserGuide"].ToString();
                    lblYouTube.Text = dr["YouTube"].ToString();
                    lblTelephone.Text = dr["Telephone"].ToString();

                }
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
