using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANPR_General.Entity;
using ANPR_General.Services;

namespace ANPR_General
{
    public partial class frmVehicleUpdate : Form
    {
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

        public frmVehicleUpdate()
        {
            InitializeComponent();
        }

        private void FillDropDown()
        {

            try
            {
                //DataTable CarTypeTable = new DataTable();
                //DataColumn dtColumn;
                //DataRow myDataRow;

                //// Create id column
                //dtColumn = new DataColumn();
                //dtColumn.DataType = typeof(Int32);
                //dtColumn.ColumnName = "id";
                //dtColumn.Caption = "id";

                //// Add column to the DataColumnCollection.
                //CarTypeTable.Columns.Add(dtColumn);

                //// Create Name column.
                //dtColumn = new DataColumn();
                //dtColumn.DataType = typeof(String);
                //dtColumn.ColumnName = "Name";
                //dtColumn.Caption = "Name";

                ///// Add column to the DataColumnCollection.
                //CarTypeTable.Columns.Add(dtColumn);


                //// I add three customers with their addresses, names and ids
                //myDataRow = CarTypeTable.NewRow();
                //myDataRow["id"] = 1;
                //myDataRow["Name"] = "While List Car";
                //CarTypeTable.Rows.Add(myDataRow);

                //myDataRow = CarTypeTable.NewRow();
                //myDataRow["id"] = 2;
                //myDataRow["Name"] = "Black List Car";
                //CarTypeTable.Rows.Add(myDataRow);

                //myDataRow = CarTypeTable.NewRow();
                //myDataRow["id"] = 3;
                //myDataRow["Name"] = "Visitor Car";

                //CarTypeTable.Rows.Add(myDataRow);
                DAL dal = new DAL();
                DataSet ds = new DataSet();

                ds = dal.Read_ListedType(false);


                cmbListType.DataSource= ds.Tables[0];
                cmbListType.DisplayMember = "Name";
                cmbListType.ValueMember= "id";
                cmbListType.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmVehicleUpdate_Load(object sender, EventArgs e)
        {
            Init();
            FillDropDown();
            GetData_Grid();
        }

        private void Init()
        {
            btnNew.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnNew.Width, btnNew.Height, 10, 10));
            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUpdate.Width, btnUpdate.Height, 10, 10));
            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete.Width, btnDelete.Height, 10, 10));
            Set_Lang();
        }
        private void Set_Lang()
        {
            Communication c = new Communication();
            bool FlgEngl = c.IsLangEnglish();

            if (FlgEngl)
            {
                btnNew.Text = "New";
                btnUpdate.Text = "Save";
                btnDelete.Text = "Delete";

                labelListType.Text = "List Type";
                labelSearchVehicleDescr.Text = "Vehicle Desrp.";
                labelSearchVehicleNoPlate.Text = "No. Plate";
                labelSearchVehicleOwnerName.Text = "Owner Name";
                labelSearchVehName.Text = "Vehicle Name";
                labelVehicleDescr.Text = "Vehicle Descr";
                labelVehicleId.Text = "Vehicle Id";
                labelVehicleName.Text = "Vehicle Name";
                labelVehicleNoPlate.Text = "Vehicle No Plate";
                labelVehicleOwnerName.Text = "Vehicle Owner";

                groupBoxSearch.Text = "Search";
                groupBoxAdd.Text = "Add";

                this.Text = "Vehicle Details";
            }

        }

        private void Clear()
        {
            txtVehicleName.Text = "";
            txtVehicleDescr.Text = "";
            txtVehicleNoPlate.Text = "";
            txtVehicleOwnerName.Text = "";
            txtVehicleId.Text = "0";
            cmbListType.SelectedValue = 1; ;
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void GetData_Grid()
        {
            try
            {


                DAL dal = new DAL();
                DataSet ds = new DataSet();

                VehicleMaster searchVM = new VehicleMaster();

                searchVM.vhc_Name = txtSearchVehName.Text;
                searchVM.vhc_Description = txtSearchVehicleDescr.Text;
                searchVM.vhc_NumberPlate1 = txtSearchVehicleNoPlate.Text;
                searchVM.vhc_Owner = txtSearchVehicleOwnerName.Text;


                ds = dal.Read_VehicleMaster(searchVM);
                gv_VehicleList.DataSource = ds.Tables[0];
                
                gv_VehicleList.Columns["vhc_Id"].HeaderText = "Id";
                gv_VehicleList.Columns["vhc_Name"].HeaderText = "Name";
                gv_VehicleList.Columns["vhc_Description"].HeaderText = "Description";
                gv_VehicleList.Columns["vhc_NumberPlate1"].HeaderText = "Number Plate";
                gv_VehicleList.Columns["vhc_Owner"].HeaderText = "Owner";
                gv_VehicleList.Columns["vhc_Type"].HeaderText = "List Type";
                gv_VehicleList.Columns["vhc_ListCode"].Visible=false;

                gv_VehicleList.Columns["vhc_NumberPlate1"].Width = 150;
                gv_VehicleList.Columns["vhc_Name"].Width = 150;
                gv_VehicleList.Columns["vhc_Description"].Width = 150;

                gv_VehicleList.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }

        }
        private void SaveData()
        {
            try
            {

            
            VehicleMaster v = new VehicleMaster();

                int id = 0;

                if(txtVehicleId.Text!="")
                {
                    id = Convert.ToInt16(txtVehicleId.Text);
                }

                v.vhc_Id = Convert.ToInt16( txtVehicleId.Text);
                v.vhc_Description = txtVehicleDescr.Text;
                v.vhc_NumberPlate1 = txtVehicleNoPlate.Text;
                v.vhc_Name= txtVehicleName.Text;
                v.vhc_Owner = txtVehicleOwnerName.Text;
                v.vhc_ListCode = Convert.ToInt16( cmbListType.SelectedValue);
                DAL dal = new DAL();
               string err=  dal.SaveVehicle(v);
               

                if (err=="")
                {
                    MessageBox.Show("Vehicle Details has been Saved.");
                    Clear();
                    GetData_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }    
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void DeleteData()
        {
            try
            {


                VehicleMaster v = new VehicleMaster();

                v.vhc_Id = Convert.ToInt16(txtVehicleId.Text);
                v.vhc_Description = txtVehicleDescr.Text;
                v.vhc_NumberPlate1 = txtVehicleNoPlate.Text;
                v.vhc_Name = txtVehicleName.Text;
                v.vhc_Owner = txtVehicleOwnerName.Text;
                v.vhc_ListCode = Convert.ToInt16(cmbListType.SelectedValue);
                DAL dal = new DAL();
                string err = dal.DeleteVehicle(v);


                if (err == "")
                {
                    MessageBox.Show("Vehicle Details has been Deleted.");
                    Clear();
                    GetData_Grid();
                }
                else
                {
                    MessageBox.Show(err, "System Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error");
            }
        }

        private void gv_VehicleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gv_VehicleList_DoubleClick(object sender, EventArgs e)
        {
            txtVehicleId.Text = gv_VehicleList.CurrentRow.Cells["vhc_Id"].Value.ToString();
            txtVehicleName.Text = gv_VehicleList.CurrentRow.Cells["vhc_Name"].Value.ToString();
            txtVehicleNoPlate.Text = gv_VehicleList.CurrentRow.Cells["vhc_NumberPlate1"].Value.ToString();
            txtVehicleDescr.Text = gv_VehicleList.CurrentRow.Cells["vhc_Description"].Value.ToString();
            txtVehicleOwnerName.Text = gv_VehicleList.CurrentRow.Cells["vhc_Owner"].Value.ToString();
            cmbListType.SelectedValue = gv_VehicleList.CurrentRow.Cells["vhc_ListCode"].Value;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void txtSearchVehName_TextChanged(object sender, EventArgs e)
        {
            GetData_Grid();
        }

        private void txtSearchVehicleDescr_TextChanged(object sender, EventArgs e)
        {
            GetData_Grid();
        }

        private void txtSearchVehicleNoPlate_TextChanged(object sender, EventArgs e)
        {
            GetData_Grid();
        }

        private void txtSearchVehicleOwnerName_TextChanged(object sender, EventArgs e)
        {
            GetData_Grid();
        }
    }

  

}
