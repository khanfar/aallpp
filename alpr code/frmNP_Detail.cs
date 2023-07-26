using ANPR_General.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ANPR_General
{
    public partial class frmNP_Detail : Form
    {

        private string _NP;
        private int _LstType;
        private string _PicPath;
        private int _ANPR_Id;
        private string _dt;

        public frmNP_Detail(string nP, string picPath, int lstType, int aNPR_Id, string dt)
        {
            this._NP = nP;
            this._LstType = lstType;
            this._PicPath = picPath;
            this._ANPR_Id = aNPR_Id;
            this._dt = dt;
            InitializeComponent();
            
        }

        private void frmNP_Detail_Load(object sender, EventArgs e)
        {
            Set_Titles();
        }

        private void Set_Titles()
        {
            lbl_NP.Text = _NP;
            this.Text = _NP;
            lblDt.Text = _dt;



            DAL dal = new DAL();
            DataSet ds = new DataSet();

            ds = dal.Read_ListedType(false, _LstType);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lbl_LstType.Text = dr["Name"].ToString();
            }


           if (_LstType == 1)
            {
                //lbl_LstType.Text = "White List";
                //lbl_LstType.Text = "White List";
                lbl_LstType.BackColor = Color.Green;
            }
            else if( _LstType == 2)
            {
                //lbl_LstType.Text = "Black List";
                //lbl_LstType.Text = "Black List";
                lbl_LstType.BackColor = Color.Red;
            }
            else if(_LstType == 3 || _LstType == 0)
            {
                lbl_LstType.BackColor = Color.Yellow;
            }
            else if (_LstType == 4)
            {
                lbl_LstType.BackColor = Color.Blue;
            }
            else if (_LstType == 5)
            {
                lbl_LstType.BackColor = Color.Pink;
            }
            pic_Main.ImageLocation = _PicPath;

          

           txtNotes.Text= dal.Read_NP_Notes(this._ANPR_Id);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "";

                fileName = _NP + ".jpg";

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.Title = "Save Image Files";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "jpg";
                saveFileDialog1.Filter = "Image files (*.jpg)|*.jpeg";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = fileName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string FullfileName = "";
                    //textBox1.Text = saveFileDialog1.FileName;
                    FullfileName = saveFileDialog1.FileName;
                    pic_Main.Image.Save(FullfileName);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveNotes()
        {
            try
            {
                DAL dal = new DAL();

                Notes n = new Notes();

                n.NP= this._NP ;
                n.Lst_Type= this._LstType;
                n.Note_Notes = txtNotes.Text;
                n.ANPR_Id = this._ANPR_Id;
                n.Note_dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (n.Note_Notes!="")
                {
                    dal.SaveNotes(n);
                }
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtNotes_Leave(object sender, EventArgs e)
        {
            SaveNotes();
        }

        private void frmNP_Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNotes();
        }

        private void pic_Main_Click(object sender, EventArgs e)
        {

        }
    }
}
