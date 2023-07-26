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

namespace ANPR_General
{
    public partial class frmDashboardSlider : Form
    {

        string _Today = "";
        string _Fromdt = "";
        string _Todt = "";

        int _Curr_Sldr_id;
        int _Max_Sldr_id;

        List<PictureSlider> ps;
        public frmDashboardSlider()
        {
            InitializeComponent();
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

                if (_prvNxt == 1) //****** Previous 
                {

                    if (_Curr_Sldr_id > _btnMin_Sldr_id) // If already slide on last 
                    {
                        _Curr_Sldr_id -= 1;


                        diff = _btnMax_Sldr_id - _Curr_Sldr_id;

                        if (diff < 25)
                        {
                            ds = dal.Read_LastVch_Lst_Prev(_Curr_Sldr_id, 25);
                        }
                        else
                        {
                            ds = dal.Read_LastVch_Lst_Next(_Curr_Sldr_id, 25);
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

                    if (_Curr_Sldr_id > _Max_Sldr_id)
                    {
                        _Curr_Sldr_id = _Max_Sldr_id;
                    }

                    diff = _btnMax_Sldr_id - _Curr_Sldr_id;

                    if (diff < 25)
                    {
                        ds = dal.Read_LastVch_Lst_Prev(_Curr_Sldr_id, 25);
                    }
                    else
                    {
                        ds = dal.Read_LastVch_Lst_Next(_Curr_Sldr_id, 25);
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

                ds = dal.Read_LastVch_Lst(0, 25); //** 0 means latest , no filter 

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

                int Slide_No = 25;
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

        private string Get_Image_Path(List<PictureSlider> _ps, int index)
        {
            string _picPath = "";

            try
            {
                if (_ps.Count > index)
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


                ds = dal.Read_FirstVch_Lst(_Curr_Sldr_id, 25);

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
                picbox6.ImageLocation = Get_Image_Path(ps, 5);
                picbox7.ImageLocation = Get_Image_Path(ps, 6);
                picbox8.ImageLocation = Get_Image_Path(ps, 7);
                picbox9.ImageLocation = Get_Image_Path(ps, 8);
                picbox10.ImageLocation = Get_Image_Path(ps, 9);
                picbox11.ImageLocation = Get_Image_Path(ps, 10);
                picbox12.ImageLocation = Get_Image_Path(ps, 11);
                picbox13.ImageLocation = Get_Image_Path(ps, 12);
                picbox14.ImageLocation = Get_Image_Path(ps, 13);
                picbox15.ImageLocation = Get_Image_Path(ps, 14);
                picbox16.ImageLocation = Get_Image_Path(ps, 15);
                picbox17.ImageLocation = Get_Image_Path(ps, 16);
                picbox18.ImageLocation = Get_Image_Path(ps, 17);
                picbox19.ImageLocation = Get_Image_Path(ps, 18);
                picbox20.ImageLocation = Get_Image_Path(ps, 19);
                picbox21.ImageLocation = Get_Image_Path(ps, 20);
                picbox22.ImageLocation = Get_Image_Path(ps, 21);
                picbox23.ImageLocation = Get_Image_Path(ps, 22);
                picbox24.ImageLocation = Get_Image_Path(ps, 23);
                picbox25.ImageLocation = Get_Image_Path(ps, 24);

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
                picbox1.ImageLocation = Get_Image_Path(ps, 24);
                picbox2.ImageLocation = Get_Image_Path(ps, 23);
                picbox3.ImageLocation = Get_Image_Path(ps, 22);
                picbox4.ImageLocation = Get_Image_Path(ps, 21);
                picbox5.ImageLocation = Get_Image_Path(ps, 20);
                picbox6.ImageLocation = Get_Image_Path(ps, 19);
                picbox7.ImageLocation = Get_Image_Path(ps, 18);
                picbox8.ImageLocation = Get_Image_Path(ps, 17);
                picbox9.ImageLocation = Get_Image_Path(ps, 16);
                picbox10.ImageLocation = Get_Image_Path(ps, 15);
                picbox11.ImageLocation = Get_Image_Path(ps, 14);
                picbox12.ImageLocation = Get_Image_Path(ps, 13);
                picbox13.ImageLocation = Get_Image_Path(ps, 12);
                picbox14.ImageLocation = Get_Image_Path(ps, 11);
                picbox15.ImageLocation = Get_Image_Path(ps, 10);
                picbox16.ImageLocation = Get_Image_Path(ps, 9);
                picbox17.ImageLocation = Get_Image_Path(ps, 8);
                picbox18.ImageLocation = Get_Image_Path(ps, 7);
                picbox19.ImageLocation = Get_Image_Path(ps, 6);
                picbox20.ImageLocation = Get_Image_Path(ps, 5);
                picbox21.ImageLocation = Get_Image_Path(ps, 4);
                picbox22.ImageLocation = Get_Image_Path(ps, 3);
                picbox23.ImageLocation = Get_Image_Path(ps, 2);
                picbox24.ImageLocation = Get_Image_Path(ps, 1);
                picbox25.ImageLocation = Get_Image_Path(ps, 0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void frmDashboardSlider_Load(object sender, EventArgs e)
        {
            dtFrom.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");

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


                Get_LatesSlider();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Get_Prev_Next_Slider(2);
        }

        private void btnNextAll_Click(object sender, EventArgs e)
        {
            Get_Last_Slider();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            Get_Prev_Next_Slider(1);
        }

        private void btnPrevAll_Click(object sender, EventArgs e)
        {
            Get_First_Slider();
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

        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh_Data();
        }

        private void picbox1_Click(object sender, EventArgs e)
        {
            if (ps.Count<1)
            {
                return;
            }

            string _NP = ps[0].NP;
            string _PicPath = ps[0].Pic_Path_HD;
            int _LstType = ps[0].Lst_Type;
            int _anpr_id = ps[0].ANPR_Id;
            string _dt = ps[0].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox2_Click(object sender, EventArgs e)
        {
            if (ps.Count < 2)
            {
                return;
            }

            string _NP = ps[1].NP;
            string _PicPath = ps[1].Pic_Path_HD;
            int _LstType = ps[1].Lst_Type;
            int _anpr_id = ps[1].ANPR_Id;
            string _dt = ps[1].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox3_Click(object sender, EventArgs e)
        {
            if (ps.Count < 3)
            {
                return;
            }
            string _NP = ps[2].NP;
            string _PicPath = ps[2].Pic_Path_HD;
            int _LstType = ps[2].Lst_Type;
            int _anpr_id = ps[2].ANPR_Id;
            string _dt = ps[2].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox4_Click(object sender, EventArgs e)
        {
            if (ps.Count < 4)
            {
                return;
            }
            string _NP = ps[3].NP;
            string _PicPath = ps[3].Pic_Path_HD;
            int _LstType = ps[3].Lst_Type;
            int _anpr_id = ps[3].ANPR_Id;
            string _dt = ps[3].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox5_Click(object sender, EventArgs e)
        {
            if (ps.Count < 5)
            {
                return;
            }
            string _NP = ps[4].NP;
            string _PicPath = ps[4].Pic_Path_HD;
            int _LstType = ps[4].Lst_Type;
            int _anpr_id = ps[4].ANPR_Id;
            string _dt = ps[4].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox6_Click(object sender, EventArgs e)
        {
            if (ps.Count < 6)
            {
                return;
            }
            string _NP = ps[5].NP;
            string _PicPath = ps[5].Pic_Path_HD;
            int _LstType = ps[5].Lst_Type;
            int _anpr_id = ps[5].ANPR_Id;
            string _dt = ps[5].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox7_Click(object sender, EventArgs e)
        {
            if (ps.Count < 7)
            {
                return;
            }
            string _NP = ps[6].NP;
            string _PicPath = ps[6].Pic_Path_HD;
            int _LstType = ps[6].Lst_Type;
            int _anpr_id = ps[6].ANPR_Id;
            string _dt = ps[6].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox8_Click(object sender, EventArgs e)
        {
            if (ps.Count < 8)
            {
                return;
            }
            string _NP = ps[7].NP;
            string _PicPath = ps[7].Pic_Path_HD;
            int _LstType = ps[7].Lst_Type;
            int _anpr_id = ps[7].ANPR_Id;
            string _dt = ps[7].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox9_Click(object sender, EventArgs e)
        {
            if (ps.Count < 9)
            {
                return;
            }
            string _NP = ps[8].NP;
            string _PicPath = ps[8].Pic_Path_HD;
            int _LstType = ps[8].Lst_Type;
            int _anpr_id = ps[8].ANPR_Id;
            string _dt = ps[8].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox10_Click(object sender, EventArgs e)
        {
            if (ps.Count < 10)
            {
                return;
            }
            string _NP = ps[9].NP;
            string _PicPath = ps[9].Pic_Path_HD;
            int _LstType = ps[9].Lst_Type;
            int _anpr_id = ps[9].ANPR_Id;
            string _dt = ps[9].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox11_Click(object sender, EventArgs e)
        {
            if (ps.Count < 11)
            {
                return;
            }
            string _NP = ps[10].NP;
            string _PicPath = ps[10].Pic_Path_HD;
            int _LstType = ps[10].Lst_Type;
            int _anpr_id = ps[10].ANPR_Id;
            string _dt = ps[10].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox12_Click(object sender, EventArgs e)
        {
            if (ps.Count < 12)
            {
                return;
            }
            string _NP = ps[11].NP;
            string _PicPath = ps[11].Pic_Path_HD;
            int _LstType = ps[11].Lst_Type;
            int _anpr_id = ps[11].ANPR_Id;
            string _dt = ps[11].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox13_Click(object sender, EventArgs e)
        {
            if (ps.Count < 13)
            {
                return;
            }
            string _NP = ps[12].NP;
            string _PicPath = ps[12].Pic_Path_HD;
            int _LstType = ps[12].Lst_Type;
            int _anpr_id = ps[12].ANPR_Id;
            string _dt = ps[12].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox14_Click(object sender, EventArgs e)
        {
            if (ps.Count < 14)
            {
                return;
            }
            string _NP = ps[13].NP;
            string _PicPath = ps[13].Pic_Path_HD;
            int _LstType = ps[13].Lst_Type;
            int _anpr_id = ps[13].ANPR_Id;
            string _dt = ps[13].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox15_Click(object sender, EventArgs e)
        {
            if (ps.Count < 15)
            {
                return;
            }
            string _NP = ps[14].NP;
            string _PicPath = ps[14].Pic_Path_HD;
            int _LstType = ps[14].Lst_Type;
            int _anpr_id = ps[14].ANPR_Id;
            string _dt = ps[14].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox16_Click(object sender, EventArgs e)
        {
            if (ps.Count < 16)
            {
                return;
            }
            string _NP = ps[15].NP;
            string _PicPath = ps[15].Pic_Path_HD;
            int _LstType = ps[15].Lst_Type;
            int _anpr_id = ps[15].ANPR_Id;
            string _dt = ps[15].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox17_Click(object sender, EventArgs e)
        {
            if (ps.Count < 17)
            {
                return;
            }
            string _NP = ps[16].NP;
            string _PicPath = ps[16].Pic_Path_HD;
            int _LstType = ps[16].Lst_Type;
            int _anpr_id = ps[16].ANPR_Id;
            string _dt = ps[16].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox18_Click(object sender, EventArgs e)
        {
            if (ps.Count < 18)
            {
                return;
            }
            string _NP = ps[17].NP;
            string _PicPath = ps[17].Pic_Path_HD;
            int _LstType = ps[17].Lst_Type;
            int _anpr_id = ps[17].ANPR_Id;
            string _dt = ps[17].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox19_Click(object sender, EventArgs e)
        {
            if (ps.Count < 19)
            {
                return;
            }
            string _NP = ps[18].NP;
            string _PicPath = ps[18].Pic_Path_HD;
            int _LstType = ps[18].Lst_Type;
            int _anpr_id = ps[18].ANPR_Id;
            string _dt = ps[18].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox20_Click(object sender, EventArgs e)
        {
            if (ps.Count < 20)
            {
                return;
            }
            string _NP = ps[19].NP;
            string _PicPath = ps[19].Pic_Path_HD;
            int _LstType = ps[19].Lst_Type;
            int _anpr_id = ps[19].ANPR_Id;
            string _dt = ps[19].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox21_Click(object sender, EventArgs e)
        {
            if (ps.Count < 21)
            {
                return;
            }
            string _NP = ps[20].NP;
            string _PicPath = ps[20].Pic_Path_HD;
            int _LstType = ps[20].Lst_Type;
            int _anpr_id = ps[20].ANPR_Id;
            string _dt = ps[20].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox22_Click(object sender, EventArgs e)
        {
            if (ps.Count < 22)
            {
                return;
            }
            string _NP = ps[21].NP;
            string _PicPath = ps[21].Pic_Path_HD;
            int _LstType = ps[21].Lst_Type;
            int _anpr_id = ps[21].ANPR_Id;
            string _dt = ps[21].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox23_Click(object sender, EventArgs e)
        {
            if (ps.Count < 23)
            {
                return;
            }
            string _NP = ps[22].NP;
            string _PicPath = ps[22].Pic_Path_HD;
            int _LstType = ps[22].Lst_Type;
            int _anpr_id = ps[22].ANPR_Id;
            string _dt = ps[22].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox24_Click(object sender, EventArgs e)
        {
            if (ps.Count < 24)
            {
                return;
            }
            string _NP = ps[23].NP;
            string _PicPath = ps[23].Pic_Path_HD;
            int _LstType = ps[23].Lst_Type;
            int _anpr_id = ps[23].ANPR_Id;
            string _dt = ps[23].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }

        private void picbox25_Click(object sender, EventArgs e)
        {
            if (ps.Count < 25)
            {
                return;
            }
            string _NP = ps[24].NP;
            string _PicPath = ps[24].Pic_Path_HD;
            int _LstType = ps[24].Lst_Type;
            int _anpr_id = ps[24].ANPR_Id;
            string _dt = ps[24].dt;

            frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstType, _anpr_id, _dt);
            frm_np.ShowDialog();
        }
    }
}
