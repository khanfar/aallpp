
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ANPR_General.Entity;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Image = System.Drawing.Image;
using ANPR_General.Services;

namespace ANPR_General
{
    public partial class Report : Form
    {
        bool FlgEngl;
        DataSet ds;
        DataSet ds_Notes;
        Communication c;
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


        public Report()
        {
            InitializeComponent();
        }

        private void cmbListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetData_Grid();
        }

        private void Set_Lang()
        {
            Communication c = new Communication();
            FlgEngl = c.IsLangEnglish();

            if (FlgEngl)
            {
                btnSearch.Text = "Search";

                labelVehicleNoPlate.Text = "No. Plate";
                labelVehicleDescr.Text = "Vehicle Descr";
                labelVehicleName.Text = "Vehicle Name";
                labelVehicleOwnerName.Text = "Vehicle Owner";
                labeldtFrom.Text = "From";
                labeldtTo.Text = "To";
                labelListType.Text = "List Type";
                labelCamera.Text = "Camera";
                labelEntryType.Text = "Entry Type";


                this.Text = "Reports";
            }

        }


        private void FillDropDown()
        {

            try
            {

                DAL dal = new DAL();
                DataSet ds = new DataSet();

                ds = dal.Read_ListedType(true);

                cmbListType.DisplayMember = "Name";
                cmbListType.ValueMember = "id";

                cmbListType.DataSource = ds.Tables[0]; 
                cmbListType.DropDownStyle = ComboBoxStyle.DropDownList;


                cmbListType_Notes.DisplayMember = "Name";
                cmbListType_Notes.ValueMember = "id";

                cmbListType_Notes.DataSource = ds.Tables[0];
                cmbListType_Notes.DropDownStyle = ComboBoxStyle.DropDownList;

                // Add column to the DataColumnCollection.
                DataTable Camera_direction = new DataTable();

                DataTable CarTypeTable = new DataTable();
                DataColumn dtColumn;
                DataRow myDataRow;

                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(int);
                dtColumn.ColumnName = "id";
                dtColumn.Caption = "id";

                Camera_direction.Columns.Add(dtColumn);

                // Create Name column.
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "Name";
                dtColumn.Caption = "Name";

                /// Add column to the DataColumnCollection.
                Camera_direction.Columns.Add(dtColumn);


                // I add three customers with their addresses, names and ids

             

                string _all = "All";
                string _Entry = "Entry";
                string _Exit = "Exit";
                string _Name = "Name";
                string _id = "id";

                if(!FlgEngl)
                {
                    _all = "Hepsi";
                     _Entry = "Giriş";
                     _Exit = "Çıkış";
                }

                myDataRow = Camera_direction.NewRow();
                myDataRow["id"] = 0;
                myDataRow["Name"] = _all;
                Camera_direction.Rows.Add(myDataRow);

                myDataRow = Camera_direction.NewRow();
                myDataRow["id"] = 1;
                myDataRow["Name"] = _Entry;
                Camera_direction.Rows.Add(myDataRow);

                myDataRow = Camera_direction.NewRow();
                myDataRow["id"] = 2;
                myDataRow["Name"] = _Exit;
                Camera_direction.Rows.Add(myDataRow);

                cmbEntryType.DataSource = Camera_direction;
                cmbEntryType.DisplayMember = "Name";
                cmbEntryType.ValueMember = "id";
                cmbEntryType.DropDownStyle = ComboBoxStyle.DropDownList;

                 ds = new DataSet();

                dal = new DAL();
                ds = dal.Read_Camera_Combo();

                cmbCamera.DataSource = ds.Tables[0];
                cmbCamera.DisplayMember = "Cam_Name";
                cmbCamera.ValueMember = "Cam_Id";
                cmbCamera.DropDownStyle = ComboBoxStyle.DropDownList;

                cmbCamera_Notes.DataSource = ds.Tables[0];
                cmbCamera_Notes.DisplayMember = "Cam_Name";
                cmbCamera_Notes.ValueMember = "Cam_Id";
                cmbCamera_Notes.DropDownStyle = ComboBoxStyle.DropDownList;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error " + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void Init()
        {
            btnSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSearch.Width, btnSearch.Height, 10, 10));
            btnExport.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnExport.Width, btnExport.Height, 10, 10));
            btnSearch_Notes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSearch_Notes.Width, btnSearch_Notes.Height, 10, 10));

            Set_Lang();


        }


        private void Report_Load(object sender, EventArgs e)
        {
            c = new Communication();
            FillDropDown();
            //GetData_Grid();

            Init();
        }

        private void GetData_Grid()
        {
            try
            {

                DAL dal = new DAL();
                ds = new DataSet();

                string fromdt;
                string Todt;

                fromdt = dtFrom.Value.ToString("yyyy-MM-dd");
                Todt = dtTo.Value.ToString("yyyy-MM-dd");

                int listcode = 0;

                gv_VehicleList.DataSource = null;
                //gv_VehicleList.Rows.Clear();
                //gv_VehicleList.Columns.Clear();


                //gv_VehicleList.Columns.RemoveAt();

                listcode = Convert.ToInt32(cmbListType.SelectedValue.ToString());

                ds = dal.Read_ANPR_Detail(fromdt, Todt, txtVehicleNoPlate.Text, txtVehicleOwnerName.Text, listcode, txtVehicleName.Text, txtVehicleDescr.Text, Convert.ToInt32(cmbCamera.SelectedValue), Convert.ToInt32( cmbEntryType.SelectedValue));


                gv_VehicleList.DataSource = ds.Tables[0];


                if (FlgEngl)
                {
                    gv_VehicleList.Columns["vhc_Id"].HeaderText = "Id";
                    gv_VehicleList.Columns["vhc_Name"].HeaderText = "Vehicle Name";
                    gv_VehicleList.Columns["vhc_Description"].HeaderText = "Vehicle Descrip";
                    gv_VehicleList.Columns["vhc_NumberPlate1"].HeaderText = "Number Plate";
                    gv_VehicleList.Columns["vhc_Owner"].HeaderText = "vhc_Owner";
                    gv_VehicleList.Columns["vhc_Type"].HeaderText = "Vehicle Type";
                    gv_VehicleList.Columns["City_Code"].HeaderText = "City Code";
                    gv_VehicleList.Columns["City_Name"].HeaderText = "City Name";

                    gv_VehicleList.Columns["Country_Name"].HeaderText = "Country Name";
                    gv_VehicleList.Columns["Cam_Direction"].HeaderText = "Cam Direction";

                    gv_VehicleList.Columns["ANPR_NumberPlate"].HeaderText = "Number Plate";
                    gv_VehicleList.Columns["ANPR_Time"].HeaderText = "Time";

                    gv_VehicleList.Columns["Confidence_Level"].HeaderText = "Confidence";
                    gv_VehicleList.Columns["Pic_Path"].HeaderText = "Pic";

                }
                else
                {
                    gv_VehicleList.Columns["vhc_Id"].HeaderText = "Id";
                    gv_VehicleList.Columns["vhc_Name"].HeaderText = "Araç Marka";
                    gv_VehicleList.Columns["vhc_Description"].HeaderText = "Araç Model";
                    gv_VehicleList.Columns["vhc_NumberPlate1"].HeaderText = "Plaka No";
                    gv_VehicleList.Columns["vhc_Owner"].HeaderText = "İsim Soyad";
                    gv_VehicleList.Columns["vhc_Type"].HeaderText = "Araç Türü";
                    gv_VehicleList.Columns["City_Code"].HeaderText = "Şehir";
                    gv_VehicleList.Columns["City_Name"].HeaderText = "Şehir İsim";

                    gv_VehicleList.Columns["Cam_Name"].HeaderText = "Kamera İsim";
                    gv_VehicleList.Columns["Cam_Direction"].HeaderText = "Cam Direction";

                    gv_VehicleList.Columns["ANPR_NumberPlate"].HeaderText = "Plaka No";
                    gv_VehicleList.Columns["ANPR_Time"].HeaderText = "Tarih Saat";

                    gv_VehicleList.Columns["Confidence_Level"].HeaderText = "Doğruluk";
                    gv_VehicleList.Columns["Pic_Path"].HeaderText = "Pic";
                }
               

                gv_VehicleList.Columns["Pic_Path"].Visible = false;
                gv_VehicleList.Columns["vhc_Id"].Visible = false;
                gv_VehicleList.Columns["vhc_ListCode"].Visible = false;
                gv_VehicleList.Columns["vhc_NumberPlate1"].Visible = false;
                gv_VehicleList.Columns["ANPR_Id"].Visible = false;
                gv_VehicleList.Columns["vhc_Description"].Visible = false;


                gv_VehicleList.Columns["Confidence_Level"].Width = 110;
                gv_VehicleList.Columns["ANPR_NumberPlate"].Width = 110;
                gv_VehicleList.Columns["vhc_Name"].Width = 150;
                gv_VehicleList.Columns["vhc_Description"].Width = 150;
                gv_VehicleList.Columns["ANPR_Time"].Width = 180;
                gv_VehicleList.Columns["vhc_Owner"].Width = 200;
                gv_VehicleList.Columns["vhc_Type"].Width = 170;

                //gv_VehicleList.Columns["City_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                gv_VehicleList.Columns["City_Code"].Width = 70;
                gv_VehicleList.Columns["City_Name"].Width = 100;


                //************************** Grid Settings ******************/


                gv_VehicleList.AllowUserToAddRows = false;

                //****************** Create Image Column *********************

                gv_VehicleList.RowTemplate.Height = 150;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.HeaderText = "Images";
                imageColumn.DataPropertyName = "Images";
                imageColumn.Name = "Images";
                imageColumn.Width = 150;
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;


              if (gv_VehicleList.Columns.Contains("Images") == true)
              {
                   gv_VehicleList.Columns.Remove("Images");
              }
                   gv_VehicleList.Columns.Add(imageColumn);

                //********************** For Icon *********************

                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.HeaderText = "";
                iconColumn.DataPropertyName = "icon";
                iconColumn.Name = "icon";
                iconColumn.Width = 22;
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Normal;


                if (gv_VehicleList.Columns.Contains("icon") == true)
                {
                    gv_VehicleList.Columns.Remove("icon");
                }
                gv_VehicleList.Columns.Add(iconColumn);


                ////ADD images to columns:
                foreach (DataGridViewRow row in gv_VehicleList.Rows)
                {
                    DataGridViewImageCell cell = row.Cells["Images"] as DataGridViewImageCell;
                    DataGridViewImageCell cellicon = row.Cells["icon"] as DataGridViewImageCell;

                   
                    //********************************* For Image Icon **********

                    int lst_Code = 0;
                    lst_Code =Convert.ToInt32( row.Cells["vhc_ListCode"].Value.ToString());

                    System.Drawing.Image imageicon;

                    System.Drawing.Image imageicon1;
                    imageicon1 = Properties.Resources.green_circle;

                    System.Drawing.Image imageicon2;
                    imageicon2 = Properties.Resources.red_circle;

                    System.Drawing.Image imageicon3;
                    imageicon3 = Properties.Resources.yellow_circle;

                    System.Drawing.Image imageicon4;
                    imageicon4 = Properties.Resources.blue_circle;

                    System.Drawing.Image imageicon5;
                    imageicon5 = Properties.Resources.pink_circle;

                    imageicon = imageicon3;

                    if (lst_Code == 1)
                    {
                        imageicon = imageicon1;
                    }
                    if (lst_Code == 2)
                    {
                        imageicon = imageicon2;
                    }
                    if (lst_Code == 3)
                    {
                        imageicon = imageicon3;
                    }
                    if (lst_Code == 4)
                    {
                        imageicon = imageicon4;
                    }
                    if (lst_Code == 5)
                    {
                        imageicon = imageicon5;
                    }

                    var bmp = (Bitmap)imageicon;

                    cellicon.Value = bmp;

                    if (row.Cells["Pic_Path"].Value != null)
                    {
                        Image img;
                        img = Image.FromFile(row.Cells["Pic_Path"].Value.ToString());
                        //cell.Value = img;
                        cell.Value = Bitmap.FromFile(row.Cells["Pic_Path"].Value.ToString());
                        //gv_VehicleList.Update();
                    }

                }

                gv_VehicleList.Columns["icon"].DisplayIndex = 0;
                gv_VehicleList.Columns["Images"].DisplayIndex = 1;

                gv_VehicleList.Columns["Images"].HeaderText = "Images";

                lblTotalCount.Text = "Total Records : " + ds.Tables[0].Rows.Count.ToString();
                //gv_VehicleList.DataSource = ds.Tables[0];

                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error " + MethodBase.GetCurrentMethod().Name);
            }

        }


        private void GetDataNotes_Grid()
        {
            try
            {

                DAL dal = new DAL();
                ds_Notes = new DataSet();

                string fromdt;
                string Todt;

                fromdt = dtFrom_Notes.Value.ToString("yyyy-MM-dd");
                Todt = dtTo_Notes.Value.ToString("yyyy-MM-dd");

                int listcode = 0;

                gv_VehicleList_Notes.DataSource = null;
                //gv_VehicleList.Rows.Clear();
                //gv_VehicleList.Columns.Clear();


                //gv_VehicleList.Columns.RemoveAt();

                listcode = Convert.ToInt32(cmbListType.SelectedValue.ToString());

                ds_Notes = dal.Read_ANPR_DetailNotes(fromdt, Todt, txtVehicleNoPlate_Notes.Text, txtVehicleOwnerName_Notes.Text, listcode, txtVehicleName_Notes.Text, "", Convert.ToInt32(cmbCamera.SelectedValue), 0,txtNotes.Text);


                gv_VehicleList_Notes.DataSource = ds_Notes.Tables[0];


                if (FlgEngl)
                {
                    gv_VehicleList.Columns["vhc_Id"].HeaderText = "Id";
                    gv_VehicleList.Columns["vhc_Name"].HeaderText = "Vehicle Name";
                    gv_VehicleList.Columns["vhc_Description"].HeaderText = "Vehicle Descrip";
                    gv_VehicleList.Columns["vhc_NumberPlate1"].HeaderText = "Number Plate";
                    gv_VehicleList.Columns["vhc_Owner"].HeaderText = "vhc_Owner";
                    gv_VehicleList.Columns["vhc_Type"].HeaderText = "ehicle Type";
                    gv_VehicleList.Columns["City_Code"].HeaderText = "City Code";
                    gv_VehicleList.Columns["City_Name"].HeaderText = "City Name";

                    gv_VehicleList.Columns["Cam_Name"].HeaderText = "Camera Name";
                    gv_VehicleList.Columns["Cam_Direction"].HeaderText = "Cam Direction";

                    gv_VehicleList.Columns["ANPR_NumberPlate"].HeaderText = "Number Plate";
                    gv_VehicleList.Columns["ANPR_Time"].HeaderText = "Time";

                    gv_VehicleList.Columns["Confidence_Level"].HeaderText = "Confidence";
                    gv_VehicleList.Columns["Pic_Path"].HeaderText = "Pic";
                    gv_VehicleList_Notes.Columns["Nt_Notes"].HeaderText = "Notes";
                }
                else
                {
                    gv_VehicleList_Notes.Columns["vhc_Id"].HeaderText = "Id";
                    gv_VehicleList_Notes.Columns["vhc_Name"].HeaderText = "Araç Marka";
                    gv_VehicleList_Notes.Columns["vhc_Description"].HeaderText = "Araç Model";
                    gv_VehicleList_Notes.Columns["vhc_NumberPlate1"].HeaderText = "Plaka No";
                    gv_VehicleList_Notes.Columns["vhc_Owner"].HeaderText = "İsim Soyad";
                    gv_VehicleList_Notes.Columns["vhc_Type"].HeaderText = "Araç Türü";
                    gv_VehicleList_Notes.Columns["City_Code"].HeaderText = "Şehir";
                    gv_VehicleList_Notes.Columns["City_Name"].HeaderText = "Şehir İsim";

                    gv_VehicleList_Notes.Columns["Cam_Name"].HeaderText = "Kamera İsim";
                    gv_VehicleList_Notes.Columns["Cam_Direction"].HeaderText = "Cam Direction";

                    gv_VehicleList_Notes.Columns["ANPR_NumberPlate"].HeaderText = "Plaka No";
                    gv_VehicleList_Notes.Columns["ANPR_Time"].HeaderText = "Tarih Saat";

                    gv_VehicleList_Notes.Columns["Confidence_Level"].HeaderText = "Doğruluk";
                    gv_VehicleList_Notes.Columns["Pic_Path"].HeaderText = "Pic";
                    gv_VehicleList_Notes.Columns["Nt_Notes"].HeaderText = "Notes";
                }

              

                gv_VehicleList_Notes.Columns["Pic_Path"].Visible = false;
                gv_VehicleList_Notes.Columns["vhc_Id"].Visible = false;
                gv_VehicleList_Notes.Columns["vhc_ListCode"].Visible = false;
                gv_VehicleList_Notes.Columns["vhc_NumberPlate1"].Visible = false;
                gv_VehicleList_Notes.Columns["ANPR_Id"].Visible = false;
                gv_VehicleList_Notes.Columns["vhc_Description"].Visible = false;


                gv_VehicleList_Notes.Columns["Confidence_Level"].Width = 110;
                gv_VehicleList_Notes.Columns["ANPR_NumberPlate"].Width = 110;
                gv_VehicleList_Notes.Columns["vhc_Name"].Width = 150;
                gv_VehicleList_Notes.Columns["vhc_Description"].Width = 150;
                gv_VehicleList_Notes.Columns["ANPR_Time"].Width = 180;
                gv_VehicleList_Notes.Columns["vhc_Owner"].Width = 200;
                gv_VehicleList_Notes.Columns["vhc_Type"].Width = 170;

                //gv_VehicleList.Columns["City_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                gv_VehicleList_Notes.Columns["City_Code"].Width = 70;
                gv_VehicleList_Notes.Columns["City_Name"].Width = 100;


                //************************** Grid Settings ******************/


                gv_VehicleList_Notes.AllowUserToAddRows = false;

                //****************** Create Image Column *********************

                gv_VehicleList_Notes.RowTemplate.Height = 150;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.HeaderText = "Images";
                imageColumn.DataPropertyName = "Images";
                imageColumn.Name = "Images";
                imageColumn.Width = 150;
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;


                if (gv_VehicleList_Notes.Columns.Contains("Images") == true)
                {
                    gv_VehicleList_Notes.Columns.Remove("Images");
                }
                gv_VehicleList_Notes.Columns.Add(imageColumn);

                //********************** For Icon *********************

                DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
                iconColumn.HeaderText = "";
                iconColumn.DataPropertyName = "icon";
                iconColumn.Name = "icon";
                iconColumn.Width = 22;
                iconColumn.ImageLayout = DataGridViewImageCellLayout.Normal;


                if (gv_VehicleList_Notes.Columns.Contains("icon") == true)
                {
                    gv_VehicleList_Notes.Columns.Remove("icon");
                }
                gv_VehicleList_Notes.Columns.Add(iconColumn);


                ////ADD images to columns:
                foreach (DataGridViewRow row in gv_VehicleList_Notes.Rows)
                {
                    DataGridViewImageCell cell = row.Cells["Images"] as DataGridViewImageCell;
                    DataGridViewImageCell cellicon = row.Cells["icon"] as DataGridViewImageCell;


                    //********************************* For Image Icon **********

                    int lst_Code = 0;
                    lst_Code = Convert.ToInt32(row.Cells["vhc_ListCode"].Value.ToString());

                    System.Drawing.Image imageicon;

                    System.Drawing.Image imageicon1;
                    imageicon1 = Properties.Resources.green_circle;

                    System.Drawing.Image imageicon2;
                    imageicon2 = Properties.Resources.red_circle;

                    System.Drawing.Image imageicon3;
                    imageicon3 = Properties.Resources.yellow_circle;

                    System.Drawing.Image imageicon4;
                    imageicon4 = Properties.Resources.blue_circle;

                    System.Drawing.Image imageicon5;
                    imageicon5 = Properties.Resources.pink_circle;

                    imageicon = imageicon3;

                    if (lst_Code == 1)
                    {
                        imageicon = imageicon1;
                    }
                    if (lst_Code == 2)
                    {
                        imageicon = imageicon2;
                    }
                    if (lst_Code == 3)
                    {
                        imageicon = imageicon3;
                    }
                    if (lst_Code == 4)
                    {
                        imageicon = imageicon4;
                    }
                    if (lst_Code == 5)
                    {
                        imageicon = imageicon5;
                    }

                    var bmp = (Bitmap)imageicon;

                    cellicon.Value = bmp;

                    if (row.Cells["Pic_Path"].Value != null)
                    {
                        Image img;
                        img = Image.FromFile(row.Cells["Pic_Path"].Value.ToString());
                        //cell.Value = img;
                        cell.Value = Bitmap.FromFile(row.Cells["Pic_Path"].Value.ToString());
                        //gv_VehicleList.Update();
                    }

                }

                gv_VehicleList_Notes.Columns["icon"].DisplayIndex = 0;
                gv_VehicleList_Notes.Columns["Images"].DisplayIndex = 1;


                if (FlgEngl)
                {
                    gv_VehicleList_Notes.Columns["Images"].HeaderText = "Pictures";
                }
                else
                {
                    gv_VehicleList_Notes.Columns["Images"].HeaderText = "Resimler";
                }


                lblTotalCount.Text = "Total Records : " + ds_Notes.Tables[0].Rows.Count.ToString();
                //gv_VehicleList.DataSource = ds.Tables[0];

                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error " + MethodBase.GetCurrentMethod().Name);
            }

        }

        private void SetColumnOrder()
        {
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //((DataGridViewImageColumn)gv_VehicleList.Columns["Pic_Path"]).ImageLayout = DataGridViewImageCellLayout.Stretch;

            pb.Visible = true;
            pb.Value = 30;
            lblwait.Visible = true;

            GetData_Grid();
            timer1.Enabled = true;


        }

        private void cmbListType_TextChanged(object sender, EventArgs e)
        {
            //GetData_Grid();
        }

        private void txtVehicleName_TextChanged(object sender, EventArgs e)
        {
            //GetData_Grid();
        }

        private void txtVehicleNoPlate_TextChanged(object sender, EventArgs e)
        {
            //GetData_Grid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            try
            {
                pb.Visible = true;
                pb.Value = 30;
                lblwait.Visible = true;


                DataTable anprTable = new DataTable();

                anprTable.Columns.Add("NumberPlate", typeof(string));
                anprTable.Columns.Add("Date_Time", typeof(DateTime));
                anprTable.Columns.Add("Vehicle_Name", typeof(string));
                anprTable.Columns.Add("ListedType", typeof(string));
                anprTable.Columns.Add("Vehicle_Description", typeof(string));
                anprTable.Columns.Add("Vehicle_Owner", typeof(string));
                anprTable.Columns.Add("City_Code", typeof(string));
                anprTable.Columns.Add("City_Name", typeof(string));


                DataRow newRow;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    newRow = anprTable.NewRow();
                    newRow["NumberPlate"] = dr["ANPR_NumberPlate"];
                    newRow["Date_Time"] = dr["ANPR_Time"];
                    newRow["Vehicle_Name"] = dr["vhc_Name"];
                    newRow["ListedType"] = dr["vhc_Type"];
                    newRow["Vehicle_Description"] = dr["vhc_Description"];
                    newRow["Vehicle_Owner"] = dr["vhc_Owner"];
                    newRow["City_Code"] = dr["City_Code"];
                    newRow["City_Name"] = dr["City_Name"];
                    anprTable.Rows.Add(newRow);
                }


                string exportpath = c.Get_Path(Communication.PathType.Export);

                string fileName =  DateTime.Now.ToString("dd-MM-HH-mm") + ".xlsx";
                string filepath;

                filepath = exportpath + fileName;

                ExcelUtlity obj = new ExcelUtlity();
                obj.WriteDataTableToExcel(anprTable, "ANPR Details", filepath, "Details");
                pb.Value = 100;
                MessageBox.Show("Excel created " + fileName);
                pb.Visible = false;
                lblwait.Visible = false;
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void ExportToExcel_Notes()
        {
            try
            {
                pb_Notes.Visible = true;
                pb_Notes.Value = 30;
                lblwait_Notes.Visible = true;


                DataTable anprTable = new DataTable();

                anprTable.Columns.Add("NumberPlate", typeof(string));
                anprTable.Columns.Add("Notes", typeof(string));
                anprTable.Columns.Add("Date_Time", typeof(DateTime));
                anprTable.Columns.Add("Vehicle_Name", typeof(string));
                anprTable.Columns.Add("ListedType", typeof(string));
                anprTable.Columns.Add("Vehicle_Description", typeof(string));
                anprTable.Columns.Add("Vehicle_Owner", typeof(string));
                anprTable.Columns.Add("City_Code", typeof(string));
                anprTable.Columns.Add("City_Name", typeof(string));


                DataRow newRow;

                foreach (DataRow dr in ds_Notes.Tables[0].Rows)
                {
                    newRow = anprTable.NewRow();
                    newRow["NumberPlate"] = dr["ANPR_NumberPlate"];
                    newRow["Notes"] = dr["Nt_Notes"];
                    newRow["Date_Time"] = dr["ANPR_Time"];
                    newRow["Vehicle_Name"] = dr["vhc_Name"];
                    newRow["ListedType"] = dr["vhc_Type"];
                    newRow["Vehicle_Description"] = dr["vhc_Description"];
                    newRow["Vehicle_Owner"] = dr["vhc_Owner"];
                    newRow["City_Code"] = dr["City_Code"];
                    newRow["City_Name"] = dr["City_Name"];
                    anprTable.Rows.Add(newRow);
                }


                string exportpath = c.Get_Path(Communication.PathType.Export);

                string fileName = DateTime.Now.ToString("dd-MM-HH-mm") + ".xlsx";
                string filepath;

                filepath = exportpath + fileName;

                ExcelUtlity obj = new ExcelUtlity();
                obj.WriteDataTableToExcel(anprTable, "ANPR Details", filepath, "Details");
                pb_Notes.Value = 100;
                MessageBox.Show("Excel created " + fileName);
                pb_Notes.Visible = false;
                lblwait_Notes.Visible = false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void gv_VehicleList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //GetData_Grid();
        }

        private void gv_VehicleList_Scroll(object sender, ScrollEventArgs e)
        {
             //GetData_Grid();
        }

        private void gv_VehicleList_Click(object sender, EventArgs e)
        {
            //GetData_Grid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetData_Grid();
            timer1.Enabled=false;
            pb.Value = 100;
            pb.Visible = false;
            lblwait.Visible = false;
        }

      
        private void OpenHDPicture(int _vhc_Id)
        {

            try
            {
                DAL dal = new DAL();
                DataSet ds = new DataSet();

                ds = dal.Read_ANPR_Vhcl(_vhc_Id);

                string _NP = "";
                string _PicPath = "";
                int _LstTypeCode = 0;
                int _anpr_id = 0;
                string _dt = "";

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    _NP = dr["ANPR_NumberPlate"].ToString();
                    _PicPath = dr["Pic_PathHD"].ToString();
                    _LstTypeCode = Convert.ToInt32( dr["vhc_ListCode"].ToString());
                    _anpr_id = Convert.ToInt32(dr["ANPR_Id"].ToString());
                    _dt = Convert.ToDateTime(dr["ANPR_Time"].ToString()).ToString("dd/MM/yyyy HH:mm");
                }


                frmNP_Detail frm_np = new frmNP_Detail(_NP, _PicPath, _LstTypeCode, _anpr_id, _dt);
                frm_np.ShowDialog();

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "System Error");
            }


}

        private void gv_VehicleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int vhc_Id = 0;
            if (gv_VehicleList.CurrentRow.Cells["ANPR_Id"].Value.ToString()!="")
            {
                vhc_Id = Convert.ToInt32(gv_VehicleList.CurrentRow.Cells["ANPR_Id"].Value.ToString());

            }
            OpenHDPicture(vhc_Id);
        }

        

        private void gv_VehicleList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            gv_VehicleList.Cursor = Cursors.Hand;
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetData_Grid();
        }

        private void cmbEntryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetData_Grid();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void btnPic_Excel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void btnPic_Pdf_Click(object sender, EventArgs e)
        {
            ExportToPdf();
        }


        private void ExportToPdf()
        {
            try
            {
             
                    pb.Visible = true;
                    pb.Value = 30;
                    lblwait.Visible = true;

                    DataTable anprTable = new DataTable();

                    anprTable.Columns.Add("NumberPlate", typeof(string));
                    anprTable.Columns.Add("Date_Time", typeof(DateTime));
                    anprTable.Columns.Add("Vehicle_Name", typeof(string));
                    anprTable.Columns.Add("ListedType", typeof(string));
                    anprTable.Columns.Add("Vehicle_Description", typeof(string));
                    anprTable.Columns.Add("Vehicle_Owner", typeof(string));
                    anprTable.Columns.Add("City_Code", typeof(string));
                    anprTable.Columns.Add("City_Name", typeof(string));

                    DataRow newRow;

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        newRow = anprTable.NewRow();
                        newRow["NumberPlate"] = dr["ANPR_NumberPlate"];
                        newRow["Date_Time"] = dr["ANPR_Time"];
                        newRow["Vehicle_Name"] = dr["vhc_Name"];
                        newRow["ListedType"] = dr["vhc_Type"];
                        newRow["Vehicle_Description"] = dr["vhc_Description"];
                        newRow["Vehicle_Owner"] = dr["vhc_Owner"];
                        newRow["City_Code"] = dr["City_Code"];
                        newRow["City_Name"] = dr["City_Name"];
                        anprTable.Rows.Add(newRow);
                    }


                    ExportToPdf(anprTable);


                    pb.Value = 100;
                    
                    pb.Visible = false;
                    lblwait.Visible = false;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExportToPdf(DataTable dt)
        {
            string exportpath = c.Get_Path(Communication.PathType.Export); ;
            string fileName = DateTime.Now.ToString("dd-MM-HH-mm") + ".pdf";
            string filepath;

            filepath = exportpath + fileName;

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filepath, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("ANPR_Result"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {

                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                    table.AddCell(new Phrase(r[4].ToString(), font5));
                    table.AddCell(new Phrase(r[5].ToString(), font5));
                    table.AddCell(new Phrase(r[6].ToString(), font5));
                    table.AddCell(new Phrase(r[7].ToString(), font5));
                }
            }
            document.Add(table);
            document.Close();

            MessageBox.Show("PDF created " + fileName);
        }

        private void txtVehicleNoPlate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetData_Grid();
            }
        }

        private void txtVehicleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetData_Grid();
            }
        }

        private void txtVehicleDescr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetData_Grid();
            }
        }

        private void txtVehicleOwnerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetData_Grid();
            }
        }

        private void txtVehicleDescr_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSearch_Notes_Click(object sender, EventArgs e)
        {

            pb_Notes.Visible = true;
            pb_Notes.Value = 30;
            lblwait_Notes.Visible = true;

            GetDataNotes_Grid();
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GetDataNotes_Grid();
            timer2.Enabled = false;
            pb_Notes.Value = 100;
            pb_Notes.Visible = false;
            lblwait_Notes.Visible = false;
        }

        private void txtNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetDataNotes_Grid();
            }
        }

        private void txtVehicleNoPlate_Notes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetDataNotes_Grid();
            }
        }

        private void txtVehicleName_Notes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetDataNotes_Grid();
            }
        }

        private void txtVehicleOwnerName_Notes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetDataNotes_Grid();
            }
        }

        private void gv_VehicleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gv_VehicleList_Notes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            gv_VehicleList_Notes.Cursor = Cursors.Hand;
        }

        private void gv_VehicleList_Notes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int vhc_Id = 0;
            if (gv_VehicleList_Notes.CurrentRow.Cells["ANPR_Id"].Value.ToString() != "")
            {
                vhc_Id = Convert.ToInt32(gv_VehicleList_Notes.CurrentRow.Cells["ANPR_Id"].Value.ToString());

            }
            OpenHDPicture(vhc_Id);
        }

        private void btnPic_Excel_Notes_Click(object sender, EventArgs e)
        {
            ExportToExcel_Notes();
        }

        private void btnPic_Pdf_Notes_Click(object sender, EventArgs e)
        {

        }
    }
}
