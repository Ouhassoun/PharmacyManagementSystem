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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");
        string Username;
        public string username
        {
            get { return Username; }
            set { Username = value; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtPasswordConfirm.Text != "")
            {
                if (txtPassword.Text.Length >= 8 && txtPasswordConfirm.Text.Length >= 8)
                {
                    if (txtPassword.Text == txtPasswordConfirm.Text)
                    {
                        SQLiteCommand cmd = new SQLiteCommand("update users set user_password=@password,is_regen_password='0' where username=@username", cnx);
                        cmd.Parameters.AddWithValue("@password", txtPasswordConfirm.Text);
                        cmd.Parameters.AddWithValue("@username", username);
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                        MainForm frmMain = new MainForm();
                        MainForm.lblusername = username;
                        this.Hide();
                        frmMain.Show();
                    }
                    else
                        lblInfo.Text = "Password isn't Similar";
                }
                else
                    lblInfo.Text = "Password should be 8 characters long";
            }
            else
                lblInfo.Text = "Empty fields detected";
            
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            lblInfo.ForeColor = Color.Red;
        }
    }
}
