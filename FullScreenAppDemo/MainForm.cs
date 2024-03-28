using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace FullScreenAppDemo
{
    public partial class MainForm : Form
    {
        
        public static string lblusername
        {
            get { return username.Text; }
            set { username.Text = value; }
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");
        Random random;
        int IdLogs;
        public MainForm()
        {
            InitializeComponent();
            
        }
        /*Minimize or maximize app using taskbar icon [under developpement]*/
        //
        //private const int WM_SYSCOMMAND = 0x0112;
        //private const int SC_MINIMIZE = 0xF020;
        //private const int SC_RESTORE = 0xF120;

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_SYSCOMMAND)
        //    {
        //        int wParam = m.WParam.ToInt32();
        //        if (wParam == SC_MINIMIZE)
        //        {
        //            // Taskbar icon clicked, minimize the form
        //            this.WindowState = FormWindowState.Minimized;
        //            return;
        //        }
        //        else if (wParam == SC_RESTORE)
        //        {
        //            // Taskbar icon clicked, restore the form
        //            this.WindowState = FormWindowState.Normal;
        //            return;
        //        }
        //    }
        //    base.WndProc(ref m);
        //}
        //
        
        string DefineRole(string username)
        {
            string role = "none";
            SQLiteCommand cmd = new SQLiteCommand("select user_role from users where username=@username", cnx);
            cmd.Parameters.AddWithValue("@username", username);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["user_role"].ToString() == "Default")
                        role = dr["user_role"].ToString();
                    else
                        role = "Admin";
                }
            }
            cnx.Close();
            return role;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            BtnDashboard_Click(null, null);
            if (DefineRole(lblusername) != "Admin")
            {
                btnAdmin.Visible = false;
            }
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            DashboardForm FrmDashBoard = new DashboardForm() { TopLevel = false };
            FrmDashBoard.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(FrmDashBoard);
            FrmDashBoard.Show();
        }

        private void BtnMedicaments_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            MedicamentsForm FrmMeds = new MedicamentsForm() { TopLevel = false };
            FrmMeds.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(FrmMeds);
            FrmMeds.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            InOutDecide decide = new InOutDecide();
            DialogResult result= decide.ShowDialog();
            if (result == DialogResult.Yes)
            {
                panelMain.Controls.Clear();
                TakeOutForm FrmInOut = new TakeOutForm() { TopLevel = false };
                FrmInOut.FormBorderStyle = FormBorderStyle.None;
                panelMain.Controls.Add(FrmInOut);
                FrmInOut.Show();
            }
            else if (result == DialogResult.No)
            {
                panelMain.Controls.Clear();
                RestockForm FrmInOut = new RestockForm() { TopLevel = false };
                FrmInOut.FormBorderStyle = FormBorderStyle.None;
                panelMain.Controls.Add(FrmInOut);
                FrmInOut.Show();
            }
            else
            {
                BtnDashboard_Click(null, null);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ReportsForm frmReport = new ReportsForm() { TopLevel = false };
            frmReport.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(frmReport);
            frmReport.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            AboutForm frmAbout = new AboutForm() { TopLevel = false };
            frmAbout.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(frmAbout);
            frmAbout.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            AdminControl frmAdmin = new AdminControl() { TopLevel = false };
            frmAdmin.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(frmAdmin);
            frmAdmin.Show();
        }
        public void GenerateRandomIdLogs()
        {
            random = new Random();
            int id = random.Next(0, int.MaxValue);
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select log_id from logs where log_id=@id", cnx);
            cmd.Parameters.AddWithValue("@id", id);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                found = true;
            else
                found = false;
            cnx.Close();
            if (found)
                GenerateRandomIdLogs();
            else
                IdLogs = id;
        }
        void GenerateLogs(string action)
        {
            SQLiteCommand cmdLogs = new SQLiteCommand("insert into Logs values(@id,@username,@user_action,@action_date)", cnx);
            GenerateRandomIdLogs();
            cmdLogs.Parameters.AddWithValue("@id", IdLogs);
            cmdLogs.Parameters.AddWithValue("@username", MainForm.lblusername);
            cmdLogs.Parameters.AddWithValue("@user_action", action);
            cmdLogs.Parameters.AddWithValue("@action_date", DateTime.Now);
            cnx.Open();
            cmdLogs.ExecuteNonQuery();
            cnx.Close();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            GenerateLogs("Logout");
            LogInForm frm = new LogInForm();
            frm.Show();
            this.Close();
        }
    }
}
