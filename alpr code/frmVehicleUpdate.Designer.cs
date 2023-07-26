namespace ANPR_General
{
    partial class frmVehicleUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicleUpdate));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gv_VehicleList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchVehicleOwnerName = new System.Windows.Forms.TextBox();
            this.labelSearchVehicleOwnerName = new System.Windows.Forms.Label();
            this.txtSearchVehicleNoPlate = new System.Windows.Forms.TextBox();
            this.labelSearchVehicleNoPlate = new System.Windows.Forms.Label();
            this.txtSearchVehicleDescr = new System.Windows.Forms.TextBox();
            this.txtSearchVehName = new System.Windows.Forms.TextBox();
            this.labelSearchVehicleDescr = new System.Windows.Forms.Label();
            this.labelSearchVehName = new System.Windows.Forms.Label();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.tblPanelSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtVehicleId = new System.Windows.Forms.TextBox();
            this.labelVehicleId = new System.Windows.Forms.Label();
            this.labelListType = new System.Windows.Forms.Label();
            this.txtVehicleOwnerName = new System.Windows.Forms.TextBox();
            this.labelVehicleOwnerName = new System.Windows.Forms.Label();
            this.txtVehicleNoPlate = new System.Windows.Forms.TextBox();
            this.labelVehicleNoPlate = new System.Windows.Forms.Label();
            this.txtVehicleDescr = new System.Windows.Forms.TextBox();
            this.txtVehicleName = new System.Windows.Forms.TextBox();
            this.labelVehicleDescr = new System.Windows.Forms.Label();
            this.labelVehicleName = new System.Windows.Forms.Label();
            this.cmbListType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_VehicleList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.tblPanelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.gv_VehicleList, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(962, 646);
            this.tableLayoutPanel3.TabIndex = 3;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // gv_VehicleList
            // 
            this.gv_VehicleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_VehicleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_VehicleList.Location = new System.Drawing.Point(623, 13);
            this.gv_VehicleList.Name = "gv_VehicleList";
            this.gv_VehicleList.Size = new System.Drawing.Size(316, 570);
            this.gv_VehicleList.TabIndex = 2;
            this.gv_VehicleList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_VehicleList_CellContentClick);
            this.gv_VehicleList.DoubleClick += new System.EventHandler(this.gv_VehicleList_DoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxAdd, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 570);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnNew, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnUpdate, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 253);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 58);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(288, 0);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 40);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(388, 0);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(488, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel4.Controls.Add(this.groupBoxSearch, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(588, 94);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.tableLayoutPanel5);
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearch.ForeColor = System.Drawing.Color.White;
            this.groupBoxSearch.Location = new System.Drawing.Point(4, 3);
            this.groupBoxSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(580, 81);
            this.groupBoxSearch.TabIndex = 0;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Ara";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 7;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel5.Controls.Add(this.txtSearchVehicleOwnerName, 5, 1);
            this.tableLayoutPanel5.Controls.Add(this.labelSearchVehicleOwnerName, 4, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtSearchVehicleNoPlate, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.labelSearchVehicleNoPlate, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtSearchVehicleDescr, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtSearchVehName, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelSearchVehicleDescr, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelSearchVehName, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(574, 62);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // txtSearchVehicleOwnerName
            // 
            this.txtSearchVehicleOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchVehicleOwnerName.Location = new System.Drawing.Point(410, 34);
            this.txtSearchVehicleOwnerName.Name = "txtSearchVehicleOwnerName";
            this.txtSearchVehicleOwnerName.Size = new System.Drawing.Size(160, 20);
            this.txtSearchVehicleOwnerName.TabIndex = 5;
            this.txtSearchVehicleOwnerName.TextChanged += new System.EventHandler(this.txtSearchVehicleOwnerName_TextChanged);
            // 
            // labelSearchVehicleOwnerName
            // 
            this.labelSearchVehicleOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchVehicleOwnerName.AutoSize = true;
            this.labelSearchVehicleOwnerName.Location = new System.Drawing.Point(310, 29);
            this.labelSearchVehicleOwnerName.Name = "labelSearchVehicleOwnerName";
            this.labelSearchVehicleOwnerName.Size = new System.Drawing.Size(94, 30);
            this.labelSearchVehicleOwnerName.TabIndex = 4;
            this.labelSearchVehicleOwnerName.Text = "isim soyisim";
            this.labelSearchVehicleOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchVehicleNoPlate
            // 
            this.txtSearchVehicleNoPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchVehicleNoPlate.Location = new System.Drawing.Point(104, 34);
            this.txtSearchVehicleNoPlate.Name = "txtSearchVehicleNoPlate";
            this.txtSearchVehicleNoPlate.Size = new System.Drawing.Size(160, 20);
            this.txtSearchVehicleNoPlate.TabIndex = 3;
            this.txtSearchVehicleNoPlate.TextChanged += new System.EventHandler(this.txtSearchVehicleNoPlate_TextChanged);
            // 
            // labelSearchVehicleNoPlate
            // 
            this.labelSearchVehicleNoPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchVehicleNoPlate.AutoSize = true;
            this.labelSearchVehicleNoPlate.Location = new System.Drawing.Point(4, 29);
            this.labelSearchVehicleNoPlate.Name = "labelSearchVehicleNoPlate";
            this.labelSearchVehicleNoPlate.Size = new System.Drawing.Size(94, 30);
            this.labelSearchVehicleNoPlate.TabIndex = 1;
            this.labelSearchVehicleNoPlate.Text = "Plaka ";
            this.labelSearchVehicleNoPlate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchVehicleDescr
            // 
            this.txtSearchVehicleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchVehicleDescr.Location = new System.Drawing.Point(410, 4);
            this.txtSearchVehicleDescr.Name = "txtSearchVehicleDescr";
            this.txtSearchVehicleDescr.Size = new System.Drawing.Size(160, 20);
            this.txtSearchVehicleDescr.TabIndex = 2;
            this.txtSearchVehicleDescr.TextChanged += new System.EventHandler(this.txtSearchVehicleDescr_TextChanged);
            // 
            // txtSearchVehName
            // 
            this.txtSearchVehName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchVehName.Location = new System.Drawing.Point(104, 4);
            this.txtSearchVehName.Name = "txtSearchVehName";
            this.txtSearchVehName.Size = new System.Drawing.Size(160, 20);
            this.txtSearchVehName.TabIndex = 1;
            this.txtSearchVehName.TextChanged += new System.EventHandler(this.txtSearchVehName_TextChanged);
            // 
            // labelSearchVehicleDescr
            // 
            this.labelSearchVehicleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchVehicleDescr.AutoSize = true;
            this.labelSearchVehicleDescr.Location = new System.Drawing.Point(310, 0);
            this.labelSearchVehicleDescr.Name = "labelSearchVehicleDescr";
            this.labelSearchVehicleDescr.Size = new System.Drawing.Size(94, 29);
            this.labelSearchVehicleDescr.TabIndex = 1;
            this.labelSearchVehicleDescr.Text = "Tanım";
            this.labelSearchVehicleDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSearchVehName
            // 
            this.labelSearchVehName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchVehName.AutoSize = true;
            this.labelSearchVehName.Location = new System.Drawing.Point(4, 0);
            this.labelSearchVehName.Name = "labelSearchVehName";
            this.labelSearchVehName.Size = new System.Drawing.Size(94, 29);
            this.labelSearchVehName.TabIndex = 0;
            this.labelSearchVehName.Text = "Araç Markası";
            this.labelSearchVehName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.tblPanelSearch);
            this.groupBoxAdd.ForeColor = System.Drawing.Color.White;
            this.groupBoxAdd.Location = new System.Drawing.Point(3, 103);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(577, 127);
            this.groupBoxAdd.TabIndex = 7;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "Ekle";
            // 
            // tblPanelSearch
            // 
            this.tblPanelSearch.ColumnCount = 7;
            this.tblPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tblPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tblPanelSearch.Controls.Add(this.txtVehicleId, 5, 3);
            this.tblPanelSearch.Controls.Add(this.labelVehicleId, 4, 3);
            this.tblPanelSearch.Controls.Add(this.labelListType, 1, 3);
            this.tblPanelSearch.Controls.Add(this.txtVehicleOwnerName, 5, 2);
            this.tblPanelSearch.Controls.Add(this.labelVehicleOwnerName, 4, 2);
            this.tblPanelSearch.Controls.Add(this.txtVehicleNoPlate, 2, 2);
            this.tblPanelSearch.Controls.Add(this.labelVehicleNoPlate, 1, 2);
            this.tblPanelSearch.Controls.Add(this.txtVehicleDescr, 5, 1);
            this.tblPanelSearch.Controls.Add(this.txtVehicleName, 2, 1);
            this.tblPanelSearch.Controls.Add(this.labelVehicleDescr, 4, 1);
            this.tblPanelSearch.Controls.Add(this.labelVehicleName, 1, 1);
            this.tblPanelSearch.Controls.Add(this.cmbListType, 2, 3);
            this.tblPanelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanelSearch.Location = new System.Drawing.Point(3, 16);
            this.tblPanelSearch.Name = "tblPanelSearch";
            this.tblPanelSearch.RowCount = 7;
            this.tblPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblPanelSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblPanelSearch.Size = new System.Drawing.Size(571, 108);
            this.tblPanelSearch.TabIndex = 3;
            // 
            // txtVehicleId
            // 
            this.txtVehicleId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleId.Location = new System.Drawing.Point(408, 69);
            this.txtVehicleId.Name = "txtVehicleId";
            this.txtVehicleId.ReadOnly = true;
            this.txtVehicleId.Size = new System.Drawing.Size(158, 20);
            this.txtVehicleId.TabIndex = 9;
            this.txtVehicleId.Text = "0";
            // 
            // labelVehicleId
            // 
            this.labelVehicleId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleId.AutoSize = true;
            this.labelVehicleId.ForeColor = System.Drawing.Color.White;
            this.labelVehicleId.Location = new System.Drawing.Point(308, 64);
            this.labelVehicleId.Name = "labelVehicleId";
            this.labelVehicleId.Size = new System.Drawing.Size(94, 30);
            this.labelVehicleId.TabIndex = 8;
            this.labelVehicleId.Text = "Araç ID";
            this.labelVehicleId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelListType
            // 
            this.labelListType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelListType.AutoSize = true;
            this.labelListType.ForeColor = System.Drawing.Color.White;
            this.labelListType.Location = new System.Drawing.Point(4, 64);
            this.labelListType.Name = "labelListType";
            this.labelListType.Size = new System.Drawing.Size(94, 30);
            this.labelListType.TabIndex = 2;
            this.labelListType.Text = "Araç Tipi";
            this.labelListType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVehicleOwnerName
            // 
            this.txtVehicleOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleOwnerName.Location = new System.Drawing.Point(408, 39);
            this.txtVehicleOwnerName.Name = "txtVehicleOwnerName";
            this.txtVehicleOwnerName.Size = new System.Drawing.Size(158, 20);
            this.txtVehicleOwnerName.TabIndex = 5;
            // 
            // labelVehicleOwnerName
            // 
            this.labelVehicleOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleOwnerName.AutoSize = true;
            this.labelVehicleOwnerName.ForeColor = System.Drawing.Color.White;
            this.labelVehicleOwnerName.Location = new System.Drawing.Point(308, 34);
            this.labelVehicleOwnerName.Name = "labelVehicleOwnerName";
            this.labelVehicleOwnerName.Size = new System.Drawing.Size(94, 30);
            this.labelVehicleOwnerName.TabIndex = 4;
            this.labelVehicleOwnerName.Text = "isim soyisim";
            this.labelVehicleOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVehicleNoPlate
            // 
            this.txtVehicleNoPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleNoPlate.Location = new System.Drawing.Point(104, 39);
            this.txtVehicleNoPlate.Name = "txtVehicleNoPlate";
            this.txtVehicleNoPlate.Size = new System.Drawing.Size(158, 20);
            this.txtVehicleNoPlate.TabIndex = 3;
            // 
            // labelVehicleNoPlate
            // 
            this.labelVehicleNoPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleNoPlate.AutoSize = true;
            this.labelVehicleNoPlate.ForeColor = System.Drawing.Color.White;
            this.labelVehicleNoPlate.Location = new System.Drawing.Point(4, 34);
            this.labelVehicleNoPlate.Name = "labelVehicleNoPlate";
            this.labelVehicleNoPlate.Size = new System.Drawing.Size(94, 30);
            this.labelVehicleNoPlate.TabIndex = 1;
            this.labelVehicleNoPlate.Text = "Plaka ";
            this.labelVehicleNoPlate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVehicleDescr
            // 
            this.txtVehicleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleDescr.Location = new System.Drawing.Point(408, 9);
            this.txtVehicleDescr.Name = "txtVehicleDescr";
            this.txtVehicleDescr.Size = new System.Drawing.Size(158, 20);
            this.txtVehicleDescr.TabIndex = 2;
            // 
            // txtVehicleName
            // 
            this.txtVehicleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleName.Location = new System.Drawing.Point(104, 9);
            this.txtVehicleName.Name = "txtVehicleName";
            this.txtVehicleName.Size = new System.Drawing.Size(158, 20);
            this.txtVehicleName.TabIndex = 1;
            // 
            // labelVehicleDescr
            // 
            this.labelVehicleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleDescr.AutoSize = true;
            this.labelVehicleDescr.ForeColor = System.Drawing.Color.White;
            this.labelVehicleDescr.Location = new System.Drawing.Point(308, 5);
            this.labelVehicleDescr.Name = "labelVehicleDescr";
            this.labelVehicleDescr.Size = new System.Drawing.Size(94, 29);
            this.labelVehicleDescr.TabIndex = 1;
            this.labelVehicleDescr.Text = "Tanım";
            this.labelVehicleDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVehicleName
            // 
            this.labelVehicleName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleName.AutoSize = true;
            this.labelVehicleName.ForeColor = System.Drawing.Color.White;
            this.labelVehicleName.Location = new System.Drawing.Point(4, 5);
            this.labelVehicleName.Name = "labelVehicleName";
            this.labelVehicleName.Size = new System.Drawing.Size(94, 29);
            this.labelVehicleName.TabIndex = 0;
            this.labelVehicleName.Text = "Araç Markası";
            this.labelVehicleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbListType
            // 
            this.cmbListType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbListType.FormattingEnabled = true;
            this.cmbListType.Location = new System.Drawing.Point(104, 67);
            this.cmbListType.Name = "cmbListType";
            this.cmbListType.Size = new System.Drawing.Size(158, 21);
            this.cmbListType.TabIndex = 6;
            // 
            // frmVehicleUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(962, 646);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVehicleUpdate";
            this.Text = "Araç Listesi Ekleme";
            this.Load += new System.EventHandler(this.frmVehicleUpdate_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_VehicleList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBoxSearch.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.groupBoxAdd.ResumeLayout(false);
            this.tblPanelSearch.ResumeLayout(false);
            this.tblPanelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView gv_VehicleList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox txtSearchVehicleOwnerName;
        private System.Windows.Forms.Label labelSearchVehicleOwnerName;
        private System.Windows.Forms.TextBox txtSearchVehicleNoPlate;
        private System.Windows.Forms.Label labelSearchVehicleNoPlate;
        private System.Windows.Forms.TextBox txtSearchVehicleDescr;
        private System.Windows.Forms.TextBox txtSearchVehName;
        private System.Windows.Forms.Label labelSearchVehicleDescr;
        private System.Windows.Forms.Label labelSearchVehName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.TableLayoutPanel tblPanelSearch;
        private System.Windows.Forms.TextBox txtVehicleId;
        private System.Windows.Forms.Label labelVehicleId;
        private System.Windows.Forms.Label labelListType;
        private System.Windows.Forms.TextBox txtVehicleOwnerName;
        private System.Windows.Forms.Label labelVehicleOwnerName;
        private System.Windows.Forms.TextBox txtVehicleNoPlate;
        private System.Windows.Forms.Label labelVehicleNoPlate;
        private System.Windows.Forms.TextBox txtVehicleDescr;
        private System.Windows.Forms.TextBox txtVehicleName;
        private System.Windows.Forms.Label labelVehicleDescr;
        private System.Windows.Forms.Label labelVehicleName;
        private System.Windows.Forms.ComboBox cmbListType;
    }
}