namespace FullScreenAppDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelDragControl = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            username = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAbout = new Guna.UI2.WinForms.Guna2Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnInOut = new Guna.UI2.WinForms.Guna2Button();
            this.BtnMedicaments = new Guna.UI2.WinForms.Guna2Button();
            this.BtnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelDragControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDragControl
            // 
            this.panelDragControl.Controls.Add(this.label3);
            this.panelDragControl.Controls.Add(username);
            this.panelDragControl.Controls.Add(this.label18);
            this.panelDragControl.Controls.Add(this.label2);
            this.panelDragControl.Controls.Add(this.BtnExit);
            this.panelDragControl.Controls.Add(this.btnLogout);
            this.panelDragControl.Controls.Add(this.guna2Button8);
            this.panelDragControl.Controls.Add(this.pictureBox1);
            this.panelDragControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDragControl.Location = new System.Drawing.Point(0, 0);
            this.panelDragControl.Name = "panelDragControl";
            this.panelDragControl.Size = new System.Drawing.Size(1280, 52);
            this.panelDragControl.TabIndex = 0;
            this.panelDragControl.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Made By Youssef OUHASSOUN";
            // 
            // username
            // 
            username.Anchor = System.Windows.Forms.AnchorStyles.Top;
            username.AutoSize = true;
            username.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            username.Location = new System.Drawing.Point(645, 17);
            username.Name = "username";
            username.Size = new System.Drawing.Size(0, 16);
            username.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(572, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Welcome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pharmacy Management System";
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.CheckedState.Parent = this.BtnExit;
            this.BtnExit.CustomImages.Parent = this.BtnExit;
            this.BtnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.BtnExit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.Gray;
            this.BtnExit.HoverState.FillColor = System.Drawing.Color.Red;
            this.BtnExit.HoverState.ForeColor = System.Drawing.Color.White;
            this.BtnExit.HoverState.Parent = this.BtnExit;
            this.BtnExit.Image = ((System.Drawing.Image)(resources.GetObject("BtnExit.Image")));
            this.BtnExit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnExit.Location = new System.Drawing.Point(1229, 8);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.ShadowDecoration.Parent = this.BtnExit;
            this.BtnExit.Size = new System.Drawing.Size(42, 38);
            this.BtnExit.TabIndex = 5;
            this.BtnExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.CheckedState.Parent = this.btnLogout;
            this.btnLogout.CustomImages.Parent = this.btnLogout;
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Gray;
            this.btnLogout.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverState.Image = global::FullScreenAppDemo.Properties.Resources.icons8_logout_48;
            this.btnLogout.HoverState.Parent = this.btnLogout;
            this.btnLogout.Image = global::FullScreenAppDemo.Properties.Resources.icons8_logout_48__1_;
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLogout.Location = new System.Drawing.Point(1075, 8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ShadowDecoration.Parent = this.btnLogout;
            this.btnLogout.Size = new System.Drawing.Size(42, 38);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // guna2Button8
            // 
            this.guna2Button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button8.CheckedState.Parent = this.guna2Button8;
            this.guna2Button8.CustomImages.Parent = this.guna2Button8;
            this.guna2Button8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.guna2Button8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button8.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button8.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button8.HoverState.Parent = this.guna2Button8;
            this.guna2Button8.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button8.Image")));
            this.guna2Button8.Location = new System.Drawing.Point(1181, 8);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.ShadowDecoration.Parent = this.guna2Button8;
            this.guna2Button8.Size = new System.Drawing.Size(42, 38);
            this.guna2Button8.TabIndex = 5;
            this.guna2Button8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button8.Click += new System.EventHandler(this.guna2Button8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAbout);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.btnAdmin);
            this.panel2.Controls.Add(this.guna2Button5);
            this.panel2.Controls.Add(this.btnReports);
            this.panel2.Controls.Add(this.btnInOut);
            this.panel2.Controls.Add(this.BtnMedicaments);
            this.panel2.Controls.Add(this.BtnDashboard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 668);
            this.panel2.TabIndex = 1;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbout.CheckedState.Parent = this.btnAbout;
            this.btnAbout.CustomImages.Parent = this.btnAbout;
            this.btnAbout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnAbout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.Gray;
            this.btnAbout.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAbout.HoverState.Parent = this.btnAbout;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAbout.Location = new System.Drawing.Point(1, 630);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ShadowDecoration.Parent = this.btnAbout;
            this.btnAbout.Size = new System.Drawing.Size(42, 38);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 138);
            this.panel4.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FullScreenAppDemo.Properties.Resources.ministere_de_la_sante_maroc_logo_4E2EDBAA10_seeklogo_com;
            this.pictureBox2.Location = new System.Drawing.Point(56, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "CHR Guelmim";
            // 
            // btnAdmin
            // 
            this.btnAdmin.BorderRadius = 20;
            this.btnAdmin.CheckedState.Parent = this.btnAdmin;
            this.btnAdmin.CustomImages.Parent = this.btnAdmin;
            this.btnAdmin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnAdmin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.Gray;
            this.btnAdmin.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnAdmin.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnAdmin.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmin.HoverState.Image")));
            this.btnAdmin.HoverState.Parent = this.btnAdmin;
            this.btnAdmin.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmin.Image")));
            this.btnAdmin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAdmin.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnAdmin.Location = new System.Drawing.Point(2, 404);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.ShadowDecoration.Parent = this.btnAdmin;
            this.btnAdmin.Size = new System.Drawing.Size(177, 45);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Admin Control";
            this.btnAdmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAdmin.TextOffset = new System.Drawing.Point(25, 0);
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.BorderRadius = 20;
            this.guna2Button5.CheckedState.Parent = this.guna2Button5;
            this.guna2Button5.CustomImages.Parent = this.guna2Button5;
            this.guna2Button5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.guna2Button5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button5.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button5.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.guna2Button5.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.guna2Button5.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button5.HoverState.Image")));
            this.guna2Button5.HoverState.Parent = this.guna2Button5;
            this.guna2Button5.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button5.Image")));
            this.guna2Button5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button5.ImageOffset = new System.Drawing.Point(10, 0);
            this.guna2Button5.Location = new System.Drawing.Point(1, 353);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.ShadowDecoration.Parent = this.guna2Button5;
            this.guna2Button5.Size = new System.Drawing.Size(177, 45);
            this.guna2Button5.TabIndex = 1;
            this.guna2Button5.Text = "Settings";
            this.guna2Button5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button5.TextOffset = new System.Drawing.Point(25, 0);
            // 
            // btnReports
            // 
            this.btnReports.BorderRadius = 20;
            this.btnReports.CheckedState.Parent = this.btnReports;
            this.btnReports.CustomImages.Parent = this.btnReports;
            this.btnReports.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.Gray;
            this.btnReports.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.btnReports.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.btnReports.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnReports.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.HoverState.Image")));
            this.btnReports.HoverState.Parent = this.btnReports;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReports.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnReports.Location = new System.Drawing.Point(1, 302);
            this.btnReports.Name = "btnReports";
            this.btnReports.ShadowDecoration.Parent = this.btnReports;
            this.btnReports.Size = new System.Drawing.Size(177, 45);
            this.btnReports.TabIndex = 2;
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReports.TextOffset = new System.Drawing.Point(25, 0);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnInOut
            // 
            this.btnInOut.BorderRadius = 20;
            this.btnInOut.CheckedState.Parent = this.btnInOut;
            this.btnInOut.CustomImages.Parent = this.btnInOut;
            this.btnInOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.btnInOut.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInOut.ForeColor = System.Drawing.Color.Gray;
            this.btnInOut.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.btnInOut.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.btnInOut.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnInOut.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("btnInOut.HoverState.Image")));
            this.btnInOut.HoverState.Parent = this.btnInOut;
            this.btnInOut.Image = ((System.Drawing.Image)(resources.GetObject("btnInOut.Image")));
            this.btnInOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInOut.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnInOut.Location = new System.Drawing.Point(1, 251);
            this.btnInOut.Name = "btnInOut";
            this.btnInOut.ShadowDecoration.Parent = this.btnInOut;
            this.btnInOut.Size = new System.Drawing.Size(177, 45);
            this.btnInOut.TabIndex = 3;
            this.btnInOut.Text = "In-Out";
            this.btnInOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInOut.TextOffset = new System.Drawing.Point(25, 0);
            this.btnInOut.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // BtnMedicaments
            // 
            this.BtnMedicaments.BorderRadius = 20;
            this.BtnMedicaments.CheckedState.Parent = this.BtnMedicaments;
            this.BtnMedicaments.CustomImages.Parent = this.BtnMedicaments;
            this.BtnMedicaments.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.BtnMedicaments.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMedicaments.ForeColor = System.Drawing.Color.Gray;
            this.BtnMedicaments.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.BtnMedicaments.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.BtnMedicaments.HoverState.ForeColor = System.Drawing.Color.White;
            this.BtnMedicaments.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("BtnMedicaments.HoverState.Image")));
            this.BtnMedicaments.HoverState.Parent = this.BtnMedicaments;
            this.BtnMedicaments.Image = ((System.Drawing.Image)(resources.GetObject("BtnMedicaments.Image")));
            this.BtnMedicaments.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnMedicaments.ImageOffset = new System.Drawing.Point(10, 0);
            this.BtnMedicaments.Location = new System.Drawing.Point(1, 200);
            this.BtnMedicaments.Name = "BtnMedicaments";
            this.BtnMedicaments.ShadowDecoration.Parent = this.BtnMedicaments;
            this.BtnMedicaments.Size = new System.Drawing.Size(177, 45);
            this.BtnMedicaments.TabIndex = 4;
            this.BtnMedicaments.Text = "Medicaments";
            this.BtnMedicaments.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnMedicaments.TextOffset = new System.Drawing.Point(25, 0);
            this.BtnMedicaments.Click += new System.EventHandler(this.BtnMedicaments_Click);
            // 
            // BtnDashboard
            // 
            this.BtnDashboard.BorderRadius = 20;
            this.BtnDashboard.CheckedState.Parent = this.BtnDashboard;
            this.BtnDashboard.CustomImages.Parent = this.BtnDashboard;
            this.BtnDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.BtnDashboard.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDashboard.ForeColor = System.Drawing.Color.Gray;
            this.BtnDashboard.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.BtnDashboard.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.BtnDashboard.HoverState.ForeColor = System.Drawing.Color.White;
            this.BtnDashboard.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("BtnDashboard.HoverState.Image")));
            this.BtnDashboard.HoverState.Parent = this.BtnDashboard;
            this.BtnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("BtnDashboard.Image")));
            this.BtnDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnDashboard.ImageOffset = new System.Drawing.Point(10, 0);
            this.BtnDashboard.Location = new System.Drawing.Point(1, 149);
            this.BtnDashboard.Name = "BtnDashboard";
            this.BtnDashboard.ShadowDecoration.Parent = this.BtnDashboard;
            this.BtnDashboard.Size = new System.Drawing.Size(177, 45);
            this.BtnDashboard.TabIndex = 5;
            this.BtnDashboard.Text = "Dashboard";
            this.BtnDashboard.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnDashboard.TextOffset = new System.Drawing.Point(25, 0);
            this.BtnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(180, 52);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1100, 668);
            this.panelMain.TabIndex = 3;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panelDragControl;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelDragControl);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANACONDA";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelDragControl.ResumeLayout(false);
            this.panelDragControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDragControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button btnReports;
        private Guna.UI2.WinForms.Guna2Button btnInOut;
        private Guna.UI2.WinForms.Guna2Button BtnMedicaments;
        private Guna.UI2.WinForms.Guna2Button BtnDashboard;
        private Guna.UI2.WinForms.Guna2Button BtnExit;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button guna2Button8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private Guna.UI2.WinForms.Guna2Button btnAbout;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button btnAdmin;
        private System.Windows.Forms.PictureBox pictureBox2;
        public static System.Windows.Forms.Label username;
    }
}

