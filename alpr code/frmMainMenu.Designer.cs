namespace ANPR_General
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.flow_panelLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.picture_logo = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnDashboardGrid = new System.Windows.Forms.Button();
            this.btnANPR = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnVehicleUpdate = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.panel_ClockMain = new System.Windows.Forms.Panel();
            this.panel_Clock = new System.Windows.Forms.Panel();
            this.tbllayout_Time = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Day = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbldt = new System.Windows.Forms.Label();
            this.lbltm_Type = new System.Windows.Forms.Label();
            this.panel_header = new System.Windows.Forms.Panel();
            this.tableLayoutInsidePanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.timer_tm = new System.Windows.Forms.Timer(this.components);
            this.timer_App = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.flow_panelLeft.SuspendLayout();
            this.panel_logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_logo)).BeginInit();
            this.panel_ClockMain.SuspendLayout();
            this.panel_Clock.SuspendLayout();
            this.tbllayout_Time.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_header.SuspendLayout();
            this.tableLayoutInsidePanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // flow_panelLeft
            // 
            this.flow_panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.flow_panelLeft.Controls.Add(this.panel_logo);
            this.flow_panelLeft.Controls.Add(this.btnDashboard);
            this.flow_panelLeft.Controls.Add(this.btnDashboardGrid);
            this.flow_panelLeft.Controls.Add(this.btnANPR);
            this.flow_panelLeft.Controls.Add(this.btnReports);
            this.flow_panelLeft.Controls.Add(this.btnSetting);
            this.flow_panelLeft.Controls.Add(this.btnVehicleUpdate);
            this.flow_panelLeft.Controls.Add(this.btnInfo);
            this.flow_panelLeft.Controls.Add(this.btnLogout);
            this.flow_panelLeft.Controls.Add(this.btnLogIn);
            this.flow_panelLeft.Controls.Add(this.panel_ClockMain);
            this.flow_panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.flow_panelLeft.Location = new System.Drawing.Point(0, 0);
            this.flow_panelLeft.Name = "flow_panelLeft";
            this.flow_panelLeft.Size = new System.Drawing.Size(214, 745);
            this.flow_panelLeft.TabIndex = 0;
            // 
            // panel_logo
            // 
            this.panel_logo.BackColor = System.Drawing.Color.Gray;
            this.panel_logo.Controls.Add(this.picture_logo);
            this.panel_logo.Location = new System.Drawing.Point(0, 0);
            this.panel_logo.Margin = new System.Windows.Forms.Padding(0);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(214, 55);
            this.panel_logo.TabIndex = 1;
            // 
            // picture_logo
            // 
            this.picture_logo.BackColor = System.Drawing.Color.White;
            this.picture_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture_logo.Image = global::ANPR_General.Properties.Resources.CDT_01;
            this.picture_logo.Location = new System.Drawing.Point(0, 0);
            this.picture_logo.Name = "picture_logo";
            this.picture_logo.Size = new System.Drawing.Size(214, 55);
            this.picture_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_logo.TabIndex = 2;
            this.picture_logo.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::ANPR_General.Properties.Resources.dashboard;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 55);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(214, 60);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "                Anasayfa";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnDashboardGrid
            // 
            this.btnDashboardGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboardGrid.FlatAppearance.BorderSize = 0;
            this.btnDashboardGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboardGrid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboardGrid.ForeColor = System.Drawing.Color.White;
            this.btnDashboardGrid.Image = global::ANPR_General.Properties.Resources.grid_icon;
            this.btnDashboardGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboardGrid.Location = new System.Drawing.Point(0, 115);
            this.btnDashboardGrid.Margin = new System.Windows.Forms.Padding(0);
            this.btnDashboardGrid.Name = "btnDashboardGrid";
            this.btnDashboardGrid.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDashboardGrid.Size = new System.Drawing.Size(214, 60);
            this.btnDashboardGrid.TabIndex = 13;
            this.btnDashboardGrid.Text = "                Grid izleme";
            this.btnDashboardGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboardGrid.UseVisualStyleBackColor = true;
            this.btnDashboardGrid.Click += new System.EventHandler(this.btnDashboardGrid_Click);
            // 
            // btnANPR
            // 
            this.btnANPR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnANPR.FlatAppearance.BorderSize = 0;
            this.btnANPR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnANPR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnANPR.ForeColor = System.Drawing.Color.White;
            this.btnANPR.Image = global::ANPR_General.Properties.Resources.liveview;
            this.btnANPR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnANPR.Location = new System.Drawing.Point(0, 175);
            this.btnANPR.Margin = new System.Windows.Forms.Padding(0);
            this.btnANPR.Name = "btnANPR";
            this.btnANPR.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnANPR.Size = new System.Drawing.Size(214, 60);
            this.btnANPR.TabIndex = 3;
            this.btnANPR.Text = "                Canlı izleme";
            this.btnANPR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnANPR.UseVisualStyleBackColor = true;
            this.btnANPR.Click += new System.EventHandler(this.btnANPR_Click);
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::ANPR_General.Properties.Resources.reports;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 235);
            this.btnReports.Margin = new System.Windows.Forms.Padding(0);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(214, 60);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "                Raporlar";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Image = global::ANPR_General.Properties.Resources.settings;
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(0, 295);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSetting.Size = new System.Drawing.Size(214, 60);
            this.btnSetting.TabIndex = 5;
            this.btnSetting.Text = "                Ayarlar";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnVehicleUpdate
            // 
            this.btnVehicleUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVehicleUpdate.FlatAppearance.BorderSize = 0;
            this.btnVehicleUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicleUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicleUpdate.ForeColor = System.Drawing.Color.White;
            this.btnVehicleUpdate.Image = global::ANPR_General.Properties.Resources.vehicle_list;
            this.btnVehicleUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleUpdate.Location = new System.Drawing.Point(0, 355);
            this.btnVehicleUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnVehicleUpdate.Name = "btnVehicleUpdate";
            this.btnVehicleUpdate.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnVehicleUpdate.Size = new System.Drawing.Size(214, 60);
            this.btnVehicleUpdate.TabIndex = 8;
            this.btnVehicleUpdate.Text = "                Araç Listesi";
            this.btnVehicleUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVehicleUpdate.UseVisualStyleBackColor = true;
            this.btnVehicleUpdate.Click += new System.EventHandler(this.btnVehicleUpdate_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Image = global::ANPR_General.Properties.Resources.info;
            this.btnInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfo.Location = new System.Drawing.Point(0, 415);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnInfo.Size = new System.Drawing.Size(214, 60);
            this.btnInfo.TabIndex = 10;
            this.btnInfo.Text = "                iletişim";
            this.btnInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::ANPR_General.Properties.Resources.log_out;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 475);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(214, 60);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "                Çıkış";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.FlatAppearance.BorderSize = 0;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Image = global::ANPR_General.Properties.Resources.log_out;
            this.btnLogIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogIn.Location = new System.Drawing.Point(0, 535);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogIn.Size = new System.Drawing.Size(214, 60);
            this.btnLogIn.TabIndex = 12;
            this.btnLogIn.Text = "                Giriş yapmak";
            this.btnLogIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // panel_ClockMain
            // 
            this.panel_ClockMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_ClockMain.Controls.Add(this.panel_Clock);
            this.panel_ClockMain.Location = new System.Drawing.Point(0, 595);
            this.panel_ClockMain.Margin = new System.Windows.Forms.Padding(0);
            this.panel_ClockMain.Name = "panel_ClockMain";
            this.panel_ClockMain.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.panel_ClockMain.Size = new System.Drawing.Size(214, 145);
            this.panel_ClockMain.TabIndex = 13;
            this.panel_ClockMain.Visible = false;
            // 
            // panel_Clock
            // 
            this.panel_Clock.BackColor = System.Drawing.Color.Black;
            this.panel_Clock.Controls.Add(this.tbllayout_Time);
            this.panel_Clock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Clock.Location = new System.Drawing.Point(8, 45);
            this.panel_Clock.Name = "panel_Clock";
            this.panel_Clock.Size = new System.Drawing.Size(198, 100);
            this.panel_Clock.TabIndex = 0;
            this.panel_Clock.Visible = false;
            // 
            // tbllayout_Time
            // 
            this.tbllayout_Time.ColumnCount = 1;
            this.tbllayout_Time.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbllayout_Time.Controls.Add(this.lbl_Day, 0, 2);
            this.tbllayout_Time.Controls.Add(this.lbltime, 0, 1);
            this.tbllayout_Time.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tbllayout_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbllayout_Time.Location = new System.Drawing.Point(0, 0);
            this.tbllayout_Time.Name = "tbllayout_Time";
            this.tbllayout_Time.RowCount = 3;
            this.tbllayout_Time.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbllayout_Time.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbllayout_Time.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbllayout_Time.Size = new System.Drawing.Size(198, 100);
            this.tbllayout_Time.TabIndex = 1;
            // 
            // lbl_Day
            // 
            this.lbl_Day.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Day.AutoSize = true;
            this.lbl_Day.Font = new System.Drawing.Font("Digital-7 Italic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Day.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Day.Location = new System.Drawing.Point(10, 75);
            this.lbl_Day.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lbl_Day.Name = "lbl_Day";
            this.lbl_Day.Size = new System.Drawing.Size(36, 20);
            this.lbl_Day.TabIndex = 3;
            this.lbl_Day.Text = "SAT";
            // 
            // lbltime
            // 
            this.lbltime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Digital-7 Italic", 32.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.Yellow;
            this.lbltime.Location = new System.Drawing.Point(0, 30);
            this.lbltime.Margin = new System.Windows.Forms.Padding(0);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(198, 40);
            this.lbltime.TabIndex = 4;
            this.lbltime.Text = "10:10:15";
            this.lbltime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbldt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbltm_Type, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 24);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbldt
            // 
            this.lbldt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbldt.AutoSize = true;
            this.lbldt.Font = new System.Drawing.Font("Digital-7 Italic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldt.ForeColor = System.Drawing.Color.Yellow;
            this.lbldt.Location = new System.Drawing.Point(10, 5);
            this.lbldt.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.lbldt.Name = "lbldt";
            this.lbldt.Size = new System.Drawing.Size(39, 19);
            this.lbldt.TabIndex = 3;
            this.lbldt.Text = "14/8";
            // 
            // lbltm_Type
            // 
            this.lbltm_Type.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbltm_Type.AutoSize = true;
            this.lbltm_Type.Font = new System.Drawing.Font("Digital-7 Italic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltm_Type.ForeColor = System.Drawing.Color.Yellow;
            this.lbltm_Type.Location = new System.Drawing.Point(155, 5);
            this.lbltm_Type.Margin = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.lbltm_Type.Name = "lbltm_Type";
            this.lbltm_Type.Size = new System.Drawing.Size(27, 19);
            this.lbltm_Type.TabIndex = 4;
            this.lbltm_Type.Text = "AM";
            this.lbltm_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.DimGray;
            this.panel_header.Controls.Add(this.tableLayoutInsidePanelTop);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(214, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1156, 55);
            this.panel_header.TabIndex = 1;
            // 
            // tableLayoutInsidePanelTop
            // 
            this.tableLayoutInsidePanelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.tableLayoutInsidePanelTop.ColumnCount = 1;
            this.tableLayoutInsidePanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutInsidePanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutInsidePanelTop.Controls.Add(this.lbltitle, 0, 0);
            this.tableLayoutInsidePanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutInsidePanelTop.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutInsidePanelTop.Name = "tableLayoutInsidePanelTop";
            this.tableLayoutInsidePanelTop.RowCount = 1;
            this.tableLayoutInsidePanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutInsidePanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutInsidePanelTop.Size = new System.Drawing.Size(1156, 55);
            this.tableLayoutInsidePanelTop.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(54)))), ((int)(((byte)(69)))));
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(3, 15);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(1150, 25);
            this.lbltitle.TabIndex = 2;
            this.lbltitle.Text = "ANPR System";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(214, 55);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1156, 690);
            this.panelDesktop.TabIndex = 3;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // timer_tm
            // 
            this.timer_tm.Enabled = true;
            this.timer_tm.Interval = 60000;
            this.timer_tm.Tick += new System.EventHandler(this.timer_tm_Tick);
            // 
            // timer_App
            // 
            this.timer_App.Interval = 3600000;
            this.timer_App.Tick += new System.EventHandler(this.timer_App_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "plakasoft";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 745);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.flow_panelLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainMenu";
            this.Text = "ANPR System";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.flow_panelLeft.ResumeLayout(false);
            this.panel_logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_logo)).EndInit();
            this.panel_ClockMain.ResumeLayout(false);
            this.panel_Clock.ResumeLayout(false);
            this.tbllayout_Time.ResumeLayout(false);
            this.tbllayout_Time.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_header.ResumeLayout(false);
            this.tableLayoutInsidePanelTop.ResumeLayout(false);
            this.tableLayoutInsidePanelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flow_panelLeft;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Button btnANPR;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.PictureBox picture_logo;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button btnVehicleUpdate;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutInsidePanelTop;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Panel panel_ClockMain;
        private System.Windows.Forms.Panel panel_Clock;
        private System.Windows.Forms.Label lbl_Day;
        private System.Windows.Forms.Timer timer_tm;
        private System.Windows.Forms.TableLayoutPanel tbllayout_Time;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lbldt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbltm_Type;
        private System.Windows.Forms.Timer timer_App;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnDashboardGrid;
    }
}

