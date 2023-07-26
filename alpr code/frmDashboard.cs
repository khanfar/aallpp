using ANPR_General.Entity;
using ANPR_General.Services;
using DataModel;
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
    public partial class frmDashboard : Form
    {
        string _Today = "";
        string _Fromdt = "";
        string _Todt = "";

        int _Curr_Sldr_id;
        int _Max_Sldr_id;

        List<PictureSlider> ps;
        public frmDashboard()
        {
            InitializeComponent();
            
        }

        private void Set_Lang()
        {

            try
             {

                Communication c = new Communication();
                bool FlgEngl = c.IsLangEnglish();

                if (FlgEngl)
                {
                    lblWhilteLstCar.Text = "Whilte List Car";
                    lblBlacllstCar.Text = "Black List Car";
                    lblMonthlyVol.Text = "Weekly Volume";
                    lblTotalVolm.Text = "Total Volume";

                    chart_monthlyTotal.Titles[0].Text = "Month Total";
                    chart_Daywise.Titles[0].Text = "Day Wise";
                    chart_monthlyVol.Titles[0].Text = "Monthly Volume";
                }


                DAL dal = new DAL();
                DataSet ds = new DataSet();

                ds = dal.Read_ListedType(false);

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    int id = 0;

                    if ( Vald.IsNumeric(dr["id"].ToString()))
                    {
                        id = Convert.ToInt32(dr["id"].ToString());
                    }

                    if(id==1)
                    {
                        lblWhilteLstCar.Text = dr["Name"].ToString();
                    }

                    if (id == 2)
                    {
                        lblBlacllstCar.Text = dr["Name"].ToString();
                    }

                    if (id == 3)
                    {
                        lbllst3Car.Text = dr["Name"].ToString();
                    }

                    if (id == 4)
                    {
                        lbllst4Car.Text = dr["Name"].ToString();
                    }


                }

            }
             catch (Exception ex)
             {
                        MessageBox.Show(ex.Message);
              }
       }

        private void Get_ChartData(string _fromdt ,string _Todt)
        {
            DAL dal = new DAL();
            DataSet ds = new DataSet();

            int _whitelst = 0;
            int _blacklst = 0;
            int _lst3 = 0;
            int _lst4 = 0;
            int _visitorlst = 0;
            int _Tltlst = 0;

            //************* Char 1 ********************
            //***************************************

            ds = dal.Report_ListedWiseVech(_fromdt, _Todt);

            chart_monthlyVol.Series["s1"].Points.Clear();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
               

                if (Convert.ToInt16( dr["vhc_ListCode"].ToString()) == 1)
                {
                    _whitelst = Convert.ToInt16(dr["ct_vhc"].ToString());
                }

                if (Convert.ToInt16(dr["vhc_ListCode"].ToString()) == 2)
                {
                    _blacklst = Convert.ToInt16(dr["ct_vhc"].ToString());
                }

                if (Convert.ToInt16(dr["vhc_ListCode"].ToString()) == 3)
                {
                    _lst3 = Convert.ToInt16(dr["ct_vhc"].ToString());
                }

                if (Convert.ToInt16(dr["vhc_ListCode"].ToString()) == 4)
                {
                    _lst4 = Convert.ToInt16(dr["ct_vhc"].ToString());
                }

                if (Convert.ToInt16(dr["vhc_ListCode"].ToString()) ==0)
                {
                    _visitorlst = Convert.ToInt16(dr["ct_vhc"].ToString());
                }


                chart_monthlyVol.Series["s1"].Points.AddXY(dr["Lst_Type"].ToString(), dr["ct_vhc"]);
            }

            _Tltlst = _whitelst + _blacklst + _lst3 + _lst4;

            lbCt_WhiteLst.Text = _whitelst.ToString();
            lbCt_BlackLst.Text = _blacklst.ToString();
            lbCt_lst3.Text = _lst3.ToString();
            lbCt_lst4.Text = _lst4.ToString();

            lbCt_Monthly.Text = _Tltlst.ToString();
            lbCt_Total.Text = _Tltlst.ToString();

            //************* Char 2 ********************
            //***************************************
            ds = dal.Report_DayWiseVech(_fromdt, _Todt);

            chart_Daywise.Series["s1"].Points.Clear() ;

            //chart_monthlyVol.Series.Add("s1");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chart_Daywise.Series["s1"].Points.AddXY( Convert.ToDateTime( dr["ANPR_Date"].ToString()).ToString("ddd dd MMM"), dr["ct_vhc"]);
            }
            chart_Daywise.ChartAreas[0].AxisX.LabelStyle.Angle = -45;


            //************* Char 3 ********************
            //*****************************************

            ds = dal.Report_MonthlyTotal(_fromdt, _Todt);

            chart_monthlyTotal.Series["s1"].Points.Clear();

            //chart_monthlyVol.Series.Add("s1");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chart_monthlyTotal.Series["s1"].Points.AddXY(dr["Month_name"].ToString(), dr["ct_vhc"]);
            }
            //chart_monthlyTotal.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

        }

        private void Get_Prev_Next_Slider(int _prvNxt)
        {
            try
            {

                DAL dal = new DAL();
                DataSet ds = new DataSet();

                string _Fromdt = dtFrom.Value.ToString("yyyy-MM-dd");
                string _Todt = dtTo.Value.ToString("yyyy-MM-dd");

                string _Today = DateTime.Now.ToString("yyyy-MM-dd");

                ps = new List<PictureSlider>();

               int _btnMax_Sldr_id = dal.Read_MaxIdANPR();
               int _btnMin_Sldr_id = dal.Read_MinIdANPR(_Fromdt, _Todt);

                int diff = 0;
               
                

                //******** for Prev ************

                _Max_Sldr_id = dal.Read_MaxIdANPR();

                if (_prvNxt==1) //****** Previous 
                {

                    if (_Curr_Sldr_id > _btnMin_Sldr_id) // If already slide on last 
                    {
                        _Curr_Sldr_id -= 1;
                    

                        diff = _btnMax_Sldr_id - _Curr_Sldr_id;

                        if (diff<5)
                        {
                            ds = dal.Read_LastVch_Lst_Prev(_Curr_Sldr_id, 5);
                        }
                        else
                        {
                            ds = dal.Read_LastVch_Lst_Next(_Curr_Sldr_id, 5);
                        }
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    _Curr_Sldr_id += 1;

                    if (_Curr_Sldr_id>_Max_Sldr_id)
                    {
                        _Curr_Sldr_id = _Max_Sldr_id;
                    }

                    diff = _btnMax_Sldr_id - _Curr_Sldr_id;

                    if (diff < 5)
                    {
                        ds = dal.Read_LastVch_Lst_Prev(_Curr_Sldr_id, 5);
                    }
                    else
                    {
                        ds = dal.Read_LastVch_Lst_Next(_Curr_Sldr_id, 5);
                    }
                }

               

                int ct = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ct += 1;

                    PictureSlider obj_ps = new PictureSlider();
                    obj_ps.ANPR_Id = Convert.ToInt32(dr["ANPR_Id"].ToString());
                    obj_ps.NP = dr["ANPR_NumberPlate"].ToString();
                    obj_ps.Pic_Path = dr["Pic_Path"].ToString();
                    obj_ps.Pic_Path_HD = dr["Pic_PathHD"].ToString();
                    obj_ps.dt = Convert.ToDateTime(dr["ANPR_Time"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    obj_ps.Lst_Type = Convert.ToInt32(dr["vhc_ListCode"].ToString());

                    if (ct == 1)
                    {
                        _Curr_Sldr_id = obj_ps.ANPR_Id;
                        _Max_Sldr_id = obj_ps.ANPR_Id;
                    }

                    ps.Add(obj_ps);

                }

                SetPicBox_ImageLatest(ps);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Get_LatesSlider()
        {
            try
            {

                DAL dal = new DAL();
                DataSet ds = new DataSet();

                ps = new List<PictureSlider>();

                ds = dal.Read_LastVch_Lst(0, 5); //** 0 means latest , no filter 

                int ct = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ct += 1;

                    PictureSlider obj_ps = new PictureSlider();
                    obj_ps.ANPR_Id = Convert.ToInt32(dr["ANPR_Id"].ToString());
                    obj_ps.Lst_Type = Convert.ToInt32(dr["vhc_ListCode"].ToString());
                    obj_ps.NP = dr["ANPR_NumberPlate"].ToString();
                    obj_ps.Pic_Path = dr["Pic_Path"].ToString();
                    obj_ps.Pic_Path_HD = dr["Pic_PathHD"].ToString();
                    obj_ps.dt = Convert.ToDateTime(dr["ANPR_Time"].ToString()).ToString("dd/MM/yyyy HH:mm");

                    if (ct == 1)
                    {
                        _Curr_Sldr_id = obj_ps.ANPR_Id;
                        _Max_Sldr_id = obj_ps.ANPR_Id;
                    }

                    ps.Add(obj_ps);

                }

                SetPicBox_ImageLatest(ps);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Get_Last_Slider()
        {
            try
            {
                DAL dal = new DAL();
                DataSet ds = new DataSet();

                ps = new List<PictureSlider>();

                //******** for Prev ************

                _Max_Sldr_id = dal.Read_MaxIdANPR();
                _Curr_Sldr_id = _Max_Sldr_id;

                //Get all list with Is equal to and less than current id

                int Slide_No = 5;
                ds = dal.Read_LastVch_Lst(_Curr_Sldr_id, Slide_No);

                int ct = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ct += 1;

                    PictureSlider obj_ps = new PictureSlider();
                    obj_ps.ANPR_Id = Convert.ToInt32(dr["ANPR_Id"].ToString());
                    obj_ps.NP = dr["ANPR_NumberPlate"].ToString();
                    obj_ps.Pic_Path = dr["Pic_Path"].ToString();
                    obj_ps.Pic_Path_HD = dr["Pic_PathHD"].ToString();
                    obj_ps.dt = Convert.ToDateTime(dr["ANPR_Time"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    obj_ps.Lst_Type = Convert.ToInt32(dr["vhc_ListCode"].ToString());

                    if (ct == 1) // for set first max id only 
                    {
                        _Curr_Sldr_id = obj_ps.ANPR_Id;
                        _Max_Sldr_id = obj_ps.ANPR_Id;
                    }
                    ps.Add(obj_ps);
                }

                SetPicBox_ImageLatest(ps);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Get_Image_Path(List<PictureSlider> _ps,int index)
        {
            string _picPath="";

            try
            {
                if (_ps.Count> index)
                {
                    _picPath = ps[index].Pic_Path;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return _picPath;
        }

        private void Get_First_Slider()
        {
            try
            {

                DAL dal = new DAL();
                DataSet ds = new DataSet();

                ps = new List<PictureSlider>();

                //******** for Prev ************

                //string _Fromdt = Convert.ToDateTime(dtFrom.Text).ToString("yyyy-MM-dd");
                //string _Todt = Convert.ToDateTime(dtTo.Text).ToString("yyyy-MM-dd");

                string _Fromdt = dtFrom.Value.ToString("yyyy-MM-dd");
                string _Todt = dtTo.Value.ToString("yyyy-MM-dd");

                string _Today = DateTime.Now.ToString("yyyy-MM-dd");

                _Max_Sldr_id = dal.Read_MinIdANPR(_Fromdt, _Todt);

                _Curr_Sldr_id = _Max_Sldr_id;


                ds = dal.Read_FirstVch_Lst(_Curr_Sldr_id,5);

                int ct = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ct += 1;


                    PictureSlider obj_ps = new PictureSlider();
                    obj_ps.ANPR_Id = Convert.ToInt32(dr["ANPR_Id"].ToString());
                    obj_ps.NP = dr["ANPR_NumberPlate"].ToString();
                    obj_ps.Pic_Path = dr["Pic_Path"].ToString();
                    obj_ps.Pic_Path_HD = dr["Pic_PathHD"].ToString();
                    obj_ps.dt = Convert.ToDateTime(dr["ANPR_Time"].ToString()).ToString("dd/MM/yyyy HH:mm");
                    obj_ps.Lst_Type = Convert.ToInt32(dr["vhc_ListCode"].ToString());

                    if (ct == 1)
                    {
                        _Curr_Sldr_id = obj_ps.ANPR_Id;
                        _Max_Sldr_id = obj_ps.ANPR_Id;
                    }

                    ps.Add(obj_ps);

                }

                SetPicBox_ImagePrevious(ps);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetPicBox_ImageLatest(List<PictureSlider> ps)
        {
            try
            {
                picbox1.ImageLocation = Get_Image_Path(ps, 0);
                picbox2.ImageLocation = Get_Image_Path(ps, 1);
                picbox3.ImageLocation = Get_Image_Path(ps, 2);
                picbox4.ImageLocation = Get_Image_Path(ps, 3);
                picbox5.ImageLocation = Get_Image_Path(ps, 4);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SetPicBox_ImagePrevious(List<PictureSlider> ps)
        {
            try
            {
                picbox1.ImageLocation = Get_Image_Path(ps, 4);
                picbox2.ImageLocation = Get_Image_Path(ps, 3);
                picbox3.ImageLocation = Get_Image_Path(ps, 2);
                picbox4.ImageLocation = Get_Image_Path(ps, 1);
                picbox5.ImageLocation = Get_Image_Path(ps, 0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            dtFrom.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            Set_Lang();
            Refresh_Data();
        }

        private void Refresh_Data()
        {
            try
            {
                //string _Fromdt = Convert.ToDateTime( dtFrom.Text).ToString("yyyy-MM-dd");
                //string _Todt = Convert.ToDateTime(dtTo.Text).ToString("yyyy-MM-dd");
                string _Today = DateTime.Now.ToString("yyyy-MM-dd");

                string _Fromdt = dtFrom.Value.ToString("yyyy-MM-dd"); 
                string _Todt = dtTo.Value.ToString("yyyy-MM-dd");

                Get_ChartData(_Fromdt, _Todt);
                Get_LatesSlider();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_previous_Click(object sender, EventArgs e)
        {
            Get_Prev_Next_Slider(1);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Get_Prev_Next_Slider(2);
        }

        private void picbox1_Click(object sender, EventArgs e)
        {
            try
            {
                string _NP = ps[0].NP;
                string _PicPath = ps[0].Pic_Path_HD;
                int _LstType = ps[0].Lst_Type;
                int _anpr_id = ps[0].ANPR_Id;
                string _dt = ps[0].dt;

                frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
                frm_np.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picbox2_Click(object sender, EventArgs e)
        {
            try
            {
                string _NP = ps[1].NP;
                string _PicPath = ps[1].Pic_Path_HD;
                int _LstType = ps[1].Lst_Type;
                int _anpr_id = ps[1].ANPR_Id;
                string _dt = ps[1].dt;

                frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
                frm_np.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picbox3_Click(object sender, EventArgs e)
        {
            try
            {
                string _NP = ps[2].NP;
                string _PicPath = ps[2].Pic_Path_HD;
                int _LstType = ps[2].Lst_Type;
                int _anpr_id = ps[2].ANPR_Id;
                string _dt = ps[2].dt;

                frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
                frm_np.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picbox4_Click(object sender, EventArgs e)
        {
            try
            {
                string _NP = ps[3].NP;
                string _PicPath = ps[3].Pic_Path_HD;
                int _LstType = ps[3].Lst_Type;
                int _anpr_id = ps[3].ANPR_Id;
                string _dt = ps[3].dt;

                frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
                frm_np.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picbox5_Click(object sender, EventArgs e)
        {
            try
            {
                string _NP = ps[4].NP;
                string _PicPath = ps[4].Pic_Path_HD;
                int _LstType = ps[4].Lst_Type;
                int _anpr_id = ps[4].ANPR_Id;
                string _dt = ps[4].dt;

                frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
                frm_np.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void btnNext_MouseHover(object sender, EventArgs e)
        {
            btnNext.Image = Properties.Resources.Next_hover;
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            btnNext.Image = Properties.Resources.Next;
        }

        private void btnNextAll_MouseHover(object sender, EventArgs e)
        {
            btnNextAll.Image = Properties.Resources.Next_Last_hover;
        }

        private void btnNextAll_MouseLeave(object sender, EventArgs e)
        {
            btnNextAll.Image = Properties.Resources.Next_Last;
        }

        private void btnPrev_MouseHover(object sender, EventArgs e)
        {
            btnPrev.Image = Properties.Resources.Prev_Hover;
        }

        private void btnPrev_MouseLeave(object sender, EventArgs e)
        {
            btnPrev.Image = Properties.Resources.Prev;
        }

        private void btnPrevAll_MouseHover(object sender, EventArgs e)
        {
            btnPrevAll.Image = Properties.Resources.Prev_Last_Hover;
        }

        private void btnPrevAll_MouseLeave(object sender, EventArgs e)
        {
            btnPrevAll.Image = Properties.Resources.Prev_Last;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Get_Prev_Next_Slider(2);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            Get_Prev_Next_Slider(1);
        }

        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void btnNextAll_Click(object sender, EventArgs e)
        {
            Get_Last_Slider();
        }

        private void btnPrevAll_Click(object sender, EventArgs e)
        {
            Get_First_Slider();
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 