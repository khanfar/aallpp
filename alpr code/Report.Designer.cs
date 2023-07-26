namespace ANPR_General
{
    partial class Report
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.gv_VehicleList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtVehicleOwnerName = new System.Windows.Forms.TextBox();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.labelVehicleOwnerName = new System.Windows.Forms.Label();
            this.txtVehicleDescr = new System.Windows.Forms.TextBox();
            this.labelVehicleDescr = new System.Windows.Forms.Label();
            this.labelListType = new System.Windows.Forms.Label();
            this.cmbListType = new System.Windows.Forms.ComboBox();
            this.labeldtFrom = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.labeldtTo = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblwait = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.labelEntryType = new System.Windows.Forms.Label();
            this.cmbEntryType = new System.Windows.Forms.ComboBox();
            this.labelCamera = new System.Windows.Forms.Label();
            this.txtVehicleName = new System.Windows.Forms.TextBox();
            this.txtVehicleNoPlate = new System.Windows.Forms.TextBox();
            this.labelVehicleName = new System.Windows.Forms.Label();
            this.labelVehicleNoPlate = new System.Windows.Forms.Label();
            this.btnPic_Pdf = new System.Windows.Forms.PictureBox();
            this.btnPic_Excel = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.gv_VehicleList_Notes = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtVehicleOwnerName_Notes = new System.Windows.Forms.TextBox();
            this.cmbCamera_Notes = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbListType_Notes = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtFrom_Notes = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dtTo_Notes = new System.Windows.Forms.DateTimePicker();
            this.btnSearch_Notes = new System.Windows.Forms.Button();
            this.btnExport_Notes = new System.Windows.Forms.Button();
            this.lblwait_Notes = new System.Windows.Forms.Label();
            this.pb_Notes = new System.Windows.Forms.ProgressBar();
            this.label17 = new System.Windows.Forms.Label();
            this.txtVehicleName_Notes = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnPic_Pdf_Notes = new System.Windows.Forms.PictureBox();
            this.btnPic_Excel_Notes = new System.Windows.Forms.PictureBox();
            this.txtVehicleNoPlate_Notes = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tbMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_VehicleList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic_Pdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic_Excel)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_VehicleList_Notes)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic_Pdf_Notes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic_Excel_Notes)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tabPage1);
            this.tbMain.Controls.Add(this.tabPage2);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(860, 604);
            this.tbMain.TabIndex = 6;
            this.tbMain.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(852, 578);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General Report";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.gv_VehicleList, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 210);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(846, 365);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblTotalCount, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(23, 308);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(800, 54);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.ForeColor = System.Drawing.Color.White;
            this.lblTotalCount.Location = new System.Drawing.Point(3, 6);
            this.lblTotalCount.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(144, 16);
            this.lblTotalCount.TabIndex = 0;
            this.lblTotalCount.Text = "Total Records : 0";
            // 
            // gv_VehicleList
            // 
            this.gv_VehicleList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_VehicleList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_VehicleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_VehicleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_VehicleList.Location = new System.Drawing.Point(23, 13);
            this.gv_VehicleList.Name = "gv_VehicleList";
            this.gv_VehicleList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv_VehicleList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gv_VehicleList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gv_VehicleList.Size = new System.Drawing.Size(800, 289);
            this.gv_VehicleList.TabIndex = 5;
            this.gv_VehicleList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_VehicleList_CellContentClick);
            this.gv_VehicleList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_VehicleList_CellDoubleClick);
            this.gv_VehicleList.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_VehicleList_CellMouseEnter);
            this.gv_VehicleList.Click += new System.EventHandler(this.gv_VehicleList_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtVehicleOwnerName, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbCamera, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelVehicleOwnerName, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtVehicleDescr, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelVehicleDescr, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelListType, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbListType, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labeldtFrom, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtFrom, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labeldtTo, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtTo, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblwait, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.pb, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelEntryType, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmbEntryType, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelCamera, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtVehicleName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtVehicleNoPlate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelVehicleName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelVehicleNoPlate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnPic_Pdf, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnPic_Excel, 8, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 207);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txtVehicleOwnerName
            // 
            this.txtVehicleOwnerName.AcceptsReturn = true;
            this.txtVehicleOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleOwnerName.Location = new System.Drawing.Point(453, 76);
            this.txtVehicleOwnerName.Name = "txtVehicleOwnerName";
            this.txtVehicleOwnerName.Size = new System.Drawing.Size(144, 20);
            this.txtVehicleOwnerName.TabIndex = 5;
            this.txtVehicleOwnerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleOwnerName_KeyDown);
            // 
            // cmbCamera
            // 
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(453, 140);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(144, 21);
            this.cmbCamera.TabIndex = 17;
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // labelVehicleOwnerName
            // 
            this.labelVehicleOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleOwnerName.AutoSize = true;
            this.labelVehicleOwnerName.ForeColor = System.Drawing.Color.White;
            this.labelVehicleOwnerName.Location = new System.Drawing.Point(333, 69);
            this.labelVehicleOwnerName.Name = "labelVehicleOwnerName";
            this.labelVehicleOwnerName.Size = new System.Drawing.Size(114, 34);
            this.labelVehicleOwnerName.TabIndex = 4;
            this.labelVehicleOwnerName.Text = "İsim Soyad";
            this.labelVehicleOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVehicleDescr
            // 
            this.txtVehicleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleDescr.Location = new System.Drawing.Point(453, 42);
            this.txtVehicleDescr.Name = "txtVehicleDescr";
            this.txtVehicleDescr.Size = new System.Drawing.Size(144, 20);
            this.txtVehicleDescr.TabIndex = 2;
            this.txtVehicleDescr.TextChanged += new System.EventHandler(this.txtVehicleDescr_TextChanged);
            this.txtVehicleDescr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleDescr_KeyDown);
            // 
            // labelVehicleDescr
            // 
            this.labelVehicleDescr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleDescr.AutoSize = true;
            this.labelVehicleDescr.ForeColor = System.Drawing.Color.White;
            this.labelVehicleDescr.Location = new System.Drawing.Point(333, 35);
            this.labelVehicleDescr.Name = "labelVehicleDescr";
            this.labelVehicleDescr.Size = new System.Drawing.Size(114, 34);
            this.labelVehicleDescr.TabIndex = 1;
            this.labelVehicleDescr.Text = "Araç Model";
            this.labelVehicleDescr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelListType
            // 
            this.labelListType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelListType.AutoSize = true;
            this.labelListType.ForeColor = System.Drawing.Color.White;
            this.labelListType.Location = new System.Drawing.Point(23, 137);
            this.labelListType.Name = "labelListType";
            this.labelListType.Size = new System.Drawing.Size(114, 34);
            this.labelListType.TabIndex = 2;
            this.labelListType.Text = "Araç Türü";
            this.labelListType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbListType
            // 
            this.cmbListType.FormattingEnabled = true;
            this.cmbListType.Location = new System.Drawing.Point(143, 140);
            this.cmbListType.Name = "cmbListType";
            this.cmbListType.Size = new System.Drawing.Size(144, 21);
            this.cmbListType.TabIndex = 6;
            this.cmbListType.SelectedIndexChanged += new System.EventHandler(this.cmbListType_SelectedIndexChanged);
            // 
            // labeldtFrom
            // 
            this.labeldtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labeldtFrom.AutoSize = true;
            this.labeldtFrom.ForeColor = System.Drawing.Color.White;
            this.labeldtFrom.Location = new System.Drawing.Point(23, 103);
            this.labeldtFrom.Name = "labeldtFrom";
            this.labeldtFrom.Size = new System.Drawing.Size(114, 34);
            this.labeldtFrom.TabIndex = 7;
            this.labeldtFrom.Text = "Başlangıç Tarihi";
            this.labeldtFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtFrom
            // 
            this.dtFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(143, 106);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(144, 20);
            this.dtFrom.TabIndex = 8;
            // 
            // labeldtTo
            // 
            this.labeldtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labeldtTo.AutoSize = true;
            this.labeldtTo.ForeColor = System.Drawing.Color.White;
            this.labeldtTo.Location = new System.Drawing.Point(333, 103);
            this.labeldtTo.Name = "labeldtTo";
            this.labeldtTo.Size = new System.Drawing.Size(114, 34);
            this.labeldtTo.TabIndex = 9;
            this.labeldtTo.Text = "Bitiş Tarihi";
            this.labeldtTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtTo
            // 
            this.dtTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(453, 106);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(144, 20);
            this.dtTo.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(620, 35);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 34);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Ara";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(620, 69);
            this.btnExport.Margin = new System.Windows.Forms.Padding(0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 34);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Dışa Aktar";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // lblwait
            // 
            this.lblwait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblwait.AutoSize = true;
            this.lblwait.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwait.ForeColor = System.Drawing.Color.Blue;
            this.lblwait.Location = new System.Drawing.Point(453, 179);
            this.lblwait.Name = "lblwait";
            this.lblwait.Size = new System.Drawing.Size(144, 14);
            this.lblwait.TabIndex = 17;
            this.lblwait.Text = "Please wait . . . . .";
            this.lblwait.Visible = false;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(623, 174);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(114, 23);
            this.pb.TabIndex = 16;
            this.pb.Value = 25;
            this.pb.Visible = false;
            // 
            // labelEntryType
            // 
            this.labelEntryType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEntryType.AutoSize = true;
            this.labelEntryType.ForeColor = System.Drawing.Color.White;
            this.labelEntryType.Location = new System.Drawing.Point(23, 171);
            this.labelEntryType.Name = "labelEntryType";
            this.labelEntryType.Size = new System.Drawing.Size(114, 31);
            this.labelEntryType.TabIndex = 18;
            this.labelEntryType.Text = "Kamera Yönü";
            this.labelEntryType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEntryType
            // 
            this.cmbEntryType.FormattingEnabled = true;
            this.cmbEntryType.Location = new System.Drawing.Point(143, 174);
            this.cmbEntryType.Name = "cmbEntryType";
            this.cmbEntryType.Size = new System.Drawing.Size(144, 21);
            this.cmbEntryType.TabIndex = 16;
            this.cmbEntryType.SelectedIndexChanged += new System.EventHandler(this.cmbEntryType_SelectedIndexChanged);
            // 
            // labelCamera
            // 
            this.labelCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCamera.AutoSize = true;
            this.labelCamera.ForeColor = System.Drawing.Color.White;
            this.labelCamera.Location = new System.Drawing.Point(333, 137);
            this.labelCamera.Name = "labelCamera";
            this.labelCamera.Size = new System.Drawing.Size(114, 34);
            this.labelCamera.TabIndex = 19;
            this.labelCamera.Text = "Kameralar";
            this.labelCamera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVehicleName
            // 
            this.txtVehicleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleName.Location = new System.Drawing.Point(143, 76);
            this.txtVehicleName.Name = "txtVehicleName";
            this.txtVehicleName.Size = new System.Drawing.Size(144, 20);
            this.txtVehicleName.TabIndex = 1;
            this.txtVehicleName.TextChanged += new System.EventHandler(this.txtVehicleName_TextChanged);
            this.txtVehicleName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleName_KeyDown);
            // 
            // txtVehicleNoPlate
            // 
            this.txtVehicleNoPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleNoPlate.Location = new System.Drawing.Point(143, 42);
            this.txtVehicleNoPlate.Name = "txtVehicleNoPlate";
            this.txtVehicleNoPlate.Size = new System.Drawing.Size(144, 20);
            this.txtVehicleNoPlate.TabIndex = 3;
            this.txtVehicleNoPlate.TextChanged += new System.EventHandler(this.txtVehicleNoPlate_TextChanged);
            this.txtVehicleNoPlate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleNoPlate_KeyDown);
            // 
            // labelVehicleName
            // 
            this.labelVehicleName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleName.AutoSize = true;
            this.labelVehicleName.ForeColor = System.Drawing.Color.White;
            this.labelVehicleName.Location = new System.Drawing.Point(23, 69);
            this.labelVehicleName.Name = "labelVehicleName";
            this.labelVehicleName.Size = new System.Drawing.Size(114, 34);
            this.labelVehicleName.TabIndex = 0;
            this.labelVehicleName.Text = "Araç Marka";
            this.labelVehicleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVehicleNoPlate
            // 
            this.labelVehicleNoPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVehicleNoPlate.AutoSize = true;
            this.labelVehicleNoPlate.ForeColor = System.Drawing.Color.White;
            this.labelVehicleNoPlate.Location = new System.Drawing.Point(23, 35);
            this.labelVehicleNoPlate.Name = "labelVehicleNoPlate";
            this.labelVehicleNoPlate.Size = new System.Drawing.Size(114, 34);
            this.labelVehicleNoPlate.TabIndex = 1;
            this.labelVehicleNoPlate.Text = "Plaka No";
            this.labelVehicleNoPlate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPic_Pdf
            // 
            this.btnPic_Pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPic_Pdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPic_Pdf.Image = global::ANPR_General.Properties.Resources.pdf_icon;
            this.btnPic_Pdf.Location = new System.Drawing.Point(743, 69);
            this.btnPic_Pdf.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnPic_Pdf.Name = "btnPic_Pdf";
            this.btnPic_Pdf.Size = new System.Drawing.Size(94, 34);
            this.btnPic_Pdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPic_Pdf.TabIndex = 4;
            this.btnPic_Pdf.TabStop = false;
            this.btnPic_Pdf.Click += new System.EventHandler(this.btnPic_Pdf_Click);
            // 
            // btnPic_Excel
            // 
            this.btnPic_Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPic_Excel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPic_Excel.Image = global::ANPR_General.Properties.Resources.excel_icon;
            this.btnPic_Excel.Location = new System.Drawing.Point(743, 35);
            this.btnPic_Excel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnPic_Excel.Name = "btnPic_Excel";
            this.btnPic_Excel.Size = new System.Drawing.Size(94, 34);
            this.btnPic_Excel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPic_Excel.TabIndex = 0;
            this.btnPic_Excel.TabStop = false;
            this.btnPic_Excel.Click += new System.EventHandler(this.btnPic_Excel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.tabPage2.Controls.Add(this.tableLayoutPanel5);
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(852, 578);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notes Report";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.gv_VehicleList_Notes, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.ForeColor = System.Drawing.Color.Black;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 210);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(846, 365);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(23, 308);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(800, 54);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(3, 6);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(144, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "Total Records : 0";
            // 
            // gv_VehicleList_Notes
            // 
            this.gv_VehicleList_Notes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_VehicleList_Notes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gv_VehicleList_Notes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_VehicleList_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_VehicleList_Notes.Location = new System.Drawing.Point(23, 13);
            this.gv_VehicleList_Notes.Name = "gv_VehicleList_Notes";
            this.gv_VehicleList_Notes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv_VehicleList_Notes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gv_VehicleList_Notes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gv_VehicleList_Notes.Size = new System.Drawing.Size(800, 289);
            this.gv_VehicleList_Notes.TabIndex = 5;
            this.gv_VehicleList_Notes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_VehicleList_Notes_CellDoubleClick);
            this.gv_VehicleList_Notes.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_VehicleList_Notes_CellMouseEnter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 10;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtNotes, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtVehicleOwnerName_Notes, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbCamera_Notes, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.label10, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cmbListType_Notes, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label13, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.dtFrom_Notes, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label14, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.dtTo_Notes, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnSearch_Notes, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnExport_Notes, 7, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblwait_Notes, 5, 5);
            this.tableLayoutPanel2.Controls.Add(this.pb_Notes, 7, 5);
            this.tableLayoutPanel2.Controls.Add(this.label17, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtVehicleName_Notes, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label18, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnPic_Pdf_Notes, 8, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnPic_Excel_Notes, 8, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtVehicleNoPlate_Notes, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.label19, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(846, 207);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(143, 42);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(144, 20);
            this.txtNotes.TabIndex = 6;
            this.txtNotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotes_KeyDown);
            // 
            // txtVehicleOwnerName_Notes
            // 
            this.txtVehicleOwnerName_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleOwnerName_Notes.Location = new System.Drawing.Point(453, 76);
            this.txtVehicleOwnerName_Notes.Name = "txtVehicleOwnerName_Notes";
            this.txtVehicleOwnerName_Notes.Size = new System.Drawing.Size(144, 20);
            this.txtVehicleOwnerName_Notes.TabIndex = 5;
            this.txtVehicleOwnerName_Notes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleOwnerName_Notes_KeyDown);
            // 
            // cmbCamera_Notes
            // 
            this.cmbCamera_Notes.FormattingEnabled = true;
            this.cmbCamera_Notes.Location = new System.Drawing.Point(453, 140);
            this.cmbCamera_Notes.Name = "cmbCamera_Notes";
            this.cmbCamera_Notes.Size = new System.Drawing.Size(144, 21);
            this.cmbCamera_Notes.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(333, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 34);
            this.label10.TabIndex = 4;
            this.label10.Text = "İsim Soyad";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(23, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 34);
            this.label12.TabIndex = 2;
            this.label12.Text = "Araç Türü";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbListType_Notes
            // 
            this.cmbListType_Notes.FormattingEnabled = true;
            this.cmbListType_Notes.Location = new System.Drawing.Point(143, 140);
            this.cmbListType_Notes.Name = "cmbListType_Notes";
            this.cmbListType_Notes.Size = new System.Drawing.Size(144, 21);
            this.cmbListType_Notes.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(23, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 34);
            this.label13.TabIndex = 7;
            this.label13.Text = "Başlangıç Tarihi";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtFrom_Notes
            // 
            this.dtFrom_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFrom_Notes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom_Notes.Location = new System.Drawing.Point(143, 106);
            this.dtFrom_Notes.Name = "dtFrom_Notes";
            this.dtFrom_Notes.Size = new System.Drawing.Size(144, 20);
            this.dtFrom_Notes.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(333, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 34);
            this.label14.TabIndex = 9;
            this.label14.Text = "Bitiş Tarihi";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtTo_Notes
            // 
            this.dtTo_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTo_Notes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo_Notes.Location = new System.Drawing.Point(453, 106);
            this.dtTo_Notes.Name = "dtTo_Notes";
            this.dtTo_Notes.Size = new System.Drawing.Size(144, 20);
            this.dtTo_Notes.TabIndex = 10;
            // 
            // btnSearch_Notes
            // 
            this.btnSearch_Notes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnSearch_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch_Notes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnSearch_Notes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch_Notes.ForeColor = System.Drawing.Color.White;
            this.btnSearch_Notes.Location = new System.Drawing.Point(620, 35);
            this.btnSearch_Notes.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch_Notes.Name = "btnSearch_Notes";
            this.btnSearch_Notes.Size = new System.Drawing.Size(120, 34);
            this.btnSearch_Notes.TabIndex = 13;
            this.btnSearch_Notes.Text = "Ara";
            this.btnSearch_Notes.UseVisualStyleBackColor = false;
            this.btnSearch_Notes.Click += new System.EventHandler(this.btnSearch_Notes_Click);
            // 
            // btnExport_Notes
            // 
            this.btnExport_Notes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnExport_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport_Notes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.btnExport_Notes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport_Notes.ForeColor = System.Drawing.Color.White;
            this.btnExport_Notes.Location = new System.Drawing.Point(620, 69);
            this.btnExport_Notes.Margin = new System.Windows.Forms.Padding(0);
            this.btnExport_Notes.Name = "btnExport_Notes";
            this.btnExport_Notes.Size = new System.Drawing.Size(120, 34);
            this.btnExport_Notes.TabIndex = 15;
            this.btnExport_Notes.Text = "Dışa Aktar";
            this.btnExport_Notes.UseVisualStyleBackColor = false;
            this.btnExport_Notes.Visible = false;
            // 
            // lblwait_Notes
            // 
            this.lblwait_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblwait_Notes.AutoSize = true;
            this.lblwait_Notes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblwait_Notes.ForeColor = System.Drawing.Color.Blue;
            this.lblwait_Notes.Location = new System.Drawing.Point(453, 179);
            this.lblwait_Notes.Name = "lblwait_Notes";
            this.lblwait_Notes.Size = new System.Drawing.Size(144, 14);
            this.lblwait_Notes.TabIndex = 17;
            this.lblwait_Notes.Text = "Please wait . . . . .";
            this.lblwait_Notes.Visible = false;
            // 
            // pb_Notes
            // 
            this.pb_Notes.Location = new System.Drawing.Point(623, 174);
            this.pb_Notes.Name = "pb_Notes";
            this.pb_Notes.Size = new System.Drawing.Size(114, 23);
            this.pb_Notes.TabIndex = 16;
            this.pb_Notes.Value = 25;
            this.pb_Notes.Visible = false;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(333, 137);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 34);
            this.label17.TabIndex = 19;
            this.label17.Text = "Kameralar";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVehicleName_Notes
            // 
            this.txtVehicleName_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleName_Notes.Location = new System.Drawing.Point(143, 76);
            this.txtVehicleName_Notes.Name = "txtVehicleName_Notes";
            this.txtVehicleName_Notes.Size = new System.Drawing.Size(144, 20);
            this.txtVehicleName_Notes.TabIndex = 1;
            this.txtVehicleName_Notes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleName_Notes_KeyDown);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(23, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 34);
            this.label18.TabIndex = 0;
            this.label18.Text = "Araç Marka";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPic_Pdf_Notes
            // 
            this.btnPic_Pdf_Notes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPic_Pdf_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPic_Pdf_Notes.Image = global::ANPR_General.Properties.Resources.pdf_icon;
            this.btnPic_Pdf_Notes.Location = new System.Drawing.Point(743, 69);
            this.btnPic_Pdf_Notes.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnPic_Pdf_Notes.Name = "btnPic_Pdf_Notes";
            this.btnPic_Pdf_Notes.Size = new System.Drawing.Size(94, 34);
            this.btnPic_Pdf_Notes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPic_Pdf_Notes.TabIndex = 4;
            this.btnPic_Pdf_Notes.TabStop = false;
            this.btnPic_Pdf_Notes.Click += new System.EventHandler(this.btnPic_Pdf_Notes_Click);
            // 
            // btnPic_Excel_Notes
            // 
            this.btnPic_Excel_Notes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPic_Excel_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPic_Excel_Notes.Image = global::ANPR_General.Properties.Resources.excel_icon;
            this.btnPic_Excel_Notes.Location = new System.Drawing.Point(743, 35);
            this.btnPic_Excel_Notes.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnPic_Excel_Notes.Name = "btnPic_Excel_Notes";
            this.btnPic_Excel_Notes.Size = new System.Drawing.Size(94, 34);
            this.btnPic_Excel_Notes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPic_Excel_Notes.TabIndex = 0;
            this.btnPic_Excel_Notes.TabStop = false;
            this.btnPic_Excel_Notes.Click += new System.EventHandler(this.btnPic_Excel_Notes_Click);
            // 
            // txtVehicleNoPlate_Notes
            // 
            this.txtVehicleNoPlate_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVehicleNoPlate_Notes.Location = new System.Drawing.Point(453, 42);
            this.txtVehicleNoPlate_Notes.Name = "txtVehicleNoPlate_Notes";
            this.txtVehicleNoPlate_Notes.Size = new System.Drawing.Size(144, 20);
            this.txtVehicleNoPlate_Notes.TabIndex = 3;
            this.txtVehicleNoPlate_Notes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleNoPlate_Notes_KeyDown);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(333, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(114, 34);
            this.label19.TabIndex = 1;
            this.label19.Text = "Plaka No";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(23, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 34);
            this.label11.TabIndex = 20;
            this.label11.Text = "Notes";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(860, 604);
            this.Controls.Add(this.tbMain);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Report";
            this.Text = "Araç Geçiş Raporları";
            this.Load += new System.EventHandler(this.Report_Load);
            this.tbMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_VehicleList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic_Pdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic_Excel)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_VehicleList_Notes)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic_Pdf_Notes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic_Excel_Notes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtVehicleOwnerName;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.Label labelVehicleOwnerName;
        private System.Windows.Forms.TextBox txtVehicleDescr;
        private System.Windows.Forms.Label labelVehicleDescr;
        private System.Windows.Forms.Label labelListType;
        private System.Windows.Forms.ComboBox cmbListType;
        private System.Windows.Forms.Label labeldtFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label labeldtTo;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblwait;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label labelEntryType;
        private System.Windows.Forms.ComboBox cmbEntryType;
        private System.Windows.Forms.Label labelCamera;
        private System.Windows.Forms.TextBox txtVehicleName;
        private System.Windows.Forms.TextBox txtVehicleNoPlate;
        private System.Windows.Forms.Label labelVehicleName;
        private System.Windows.Forms.Label labelVehicleNoPlate;
        private System.Windows.Forms.PictureBox btnPic_Pdf;
        private System.Windows.Forms.PictureBox btnPic_Excel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView gv_VehicleList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView gv_VehicleList_Notes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtVehicleOwnerName_Notes;
        private System.Windows.Forms.ComboBox cmbCamera_Notes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbListType_Notes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtFrom_Notes;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtTo_Notes;
        private System.Windows.Forms.Button btnSearch_Notes;
        private System.Windows.Forms.Button btnExport_Notes;
        private System.Windows.Forms.Label lblwait_Notes;
        private System.Windows.Forms.ProgressBar pb_Notes;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtVehicleName_Notes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox btnPic_Pdf_Notes;
        private System.Windows.Forms.PictureBox btnPic_Excel_Notes;
        private System.Windows.Forms.TextBox txtVehicleNoPlate_Notes;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer timer2;
    }
}