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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");
        Random random;
        public int ID;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text!="" && txtUsername.Text != "")
            {
                int Regen = 0;
                bool found = false; 
                SQLiteCommand cmd = new SQLiteCommand("select * from users where username=@username and user_password=@password", cnx);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cnx.Open();
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    found = true;
                    while (dr.Read())
                    {
                        if ((int)dr["is_Regen_Password"] == 1)
                            Regen = 1;
                    }
                }
                else
                    found = false;
                cnx.Close();
                if (found)
                {
                    SQLiteCommand cmdusers = new SQLiteCommand("insert into logs values(@id,@username,@user_action,@action_date)", cnx);
                    SQLiteCommand cmdlogs = new SQLiteCommand("update users set last_login_date=@date where username=@username", cnx);
                    GenerateRandomID();
                    DateTime date = DateTime.Now;
                    cmdusers.Parameters.AddWithValue("@id", ID);
                    cmdusers.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmdusers.Parameters.AddWithValue("@user_action", "Login");
                    cmdusers.Parameters.AddWithValue("@action_date", date);
                    cmdlogs.Parameters.AddWithValue("@date", date);
                    cmdlogs.Parameters.AddWithValue("@username", txtUsername.Text);
                    cnx.Open();
                    cmdusers.ExecuteNonQuery();
                    cmdlogs.ExecuteNonQuery();
                    cnx.Close();
                    Success(txtUsername.Text,Regen);
                }
                else
                {
                    txtUsername.Text = txtPassword.Text = "";
                    lblError.Text = "You have entered an invalid username or password";
                    lblError.ForeColor = Color.Red;
                    lblError.Font = new Font("Century Gothic", 9, FontStyle.Regular);
                }
            }
        }
        public void GenerateRandomID()
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
                GenerateRandomID();
            else
                ID = id;
        }

        public void Success(string username,int Regen)
        {
            if (Regen == 1)
            {
                ChangePassword frm = new ChangePassword();
                frm.username = txtUsername.Text;
                this.Hide();
                frm.Show();
            }
            else
            {
                MainForm frmMain = new MainForm();
                MainForm.lblusername = username;
                this.Hide();
                frmMain.Show();
            }
        }
        private void LogInForm_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
