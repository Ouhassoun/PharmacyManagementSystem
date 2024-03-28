
namespace FullScreenAppDemo
{
    partial class InOutDecide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InOutDecide));
            this.btnTakeOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnRestock = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExit = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.cornerRemoverControl1 = new FullScreenAppDemo.CornerRemoverControl();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTakeOut
            // 
            this.btnTakeOut.BackColor = System.Drawing.Color.Transparent;
            this.btnTakeOut.BorderRadius = 10;
            this.btnTakeOut.CheckedState.Parent = this.btnTakeOut;
            this.btnTakeOut.CustomImages.Parent = this.btnTakeOut;
            this.btnTakeOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(170)))), ((int)(((byte)(231)))));
            this.btnTakeOut.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeOut.ForeColor = System.Drawing.Color.White;
            this.btnTakeOut.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnTakeOut.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnTakeOut.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnTakeOut.HoverState.Parent = this.btnTakeOut;
            this.btnTakeOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTakeOut.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnTakeOut.Location = new System.Drawing.Point(12, 131);
            this.btnTakeOut.Name = "btnTakeOut";
            this.btnTakeOut.ShadowDecoration.Parent = this.btnTakeOut;
            this.btnTakeOut.Size = new System.Drawing.Size(150, 45);
            this.btnTakeOut.TabIndex = 7;
            this.btnTakeOut.Text = "Take out";
            this.btnTakeOut.UseTransparentBackground = true;
            this.btnTakeOut.Click += new System.EventHandler(this.btnTakeOut_Click);
            // 
            // btnRestock
            // 
            this.btnRestock.BackColor = System.Drawing.Color.Transparent;
            this.btnRestock.BorderRadius = 10;
            this.btnRestock.CheckedState.Parent = this.btnRestock;
            this.btnRestock.CustomImages.Parent = this.btnRestock;
            this.btnRestock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(177)))), ((int)(((byte)(65)))));
            this.btnRestock.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestock.ForeColor = System.Drawing.Color.White;
            this.btnRestock.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(19)))));
            this.btnRestock.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(19)))));
            this.btnRestock.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnRestock.HoverState.Parent = this.btnRestock;
            this.btnRestock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRestock.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnRestock.Location = new System.Drawing.Point(338, 131);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.ShadowDecoration.Parent = this.btnRestock;
            this.btnRestock.Size = new System.Drawing.Size(150, 45);
            this.btnRestock.TabIndex = 7;
            this.btnRestock.Text = "Restock";
            this.btnRestock.UseTransparentBackground = true;
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Which form would you like to open";
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnExit.BorderRadius = 5;
            this.BtnExit.CheckedState.Parent = this.BtnExit;
            this.BtnExit.CustomImages.Parent = this.BtnExit;
            this.BtnExit.FillColor = System.Drawing.Color.Transparent;
            this.BtnExit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.Gray;
            this.BtnExit.HoverState.FillColor = System.Drawing.Color.Red;
            this.BtnExit.HoverState.ForeColor = System.Drawing.Color.White;
            this.BtnExit.HoverState.Parent = this.BtnExit;
            this.BtnExit.Image = ((System.Drawing.Image)(resources.GetObject("BtnExit.Image")));
            this.BtnExit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnExit.Location = new System.Drawing.Point(458, -1);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.ShadowDecoration.Parent = this.BtnExit;
            this.BtnExit.Size = new System.Drawing.Size(42, 38);
            this.BtnExit.TabIndex = 10;
            this.BtnExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BtnExit.UseTransparentBackground = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.Aqua;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.PaleTurquoise;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.Parent = this.guna2CustomGradientPanel1;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(500, 200);
            this.guna2CustomGradientPanel1.TabIndex = 11;
            // 
            // cornerRemoverControl1
            // 
            this.cornerRemoverControl1.CornerRedius = 15;
            this.cornerRemoverControl1.TargetControl = this;
            // 
            // InOutDecide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.btnRestock);
            this.Controls.Add(this.btnTakeOut);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InOutDecide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANACONDA";
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTakeOut;
        private Guna.UI2.WinForms.Guna2Button btnRestock;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button BtnExit;
        private CornerRemoverControl cornerRemoverControl1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}