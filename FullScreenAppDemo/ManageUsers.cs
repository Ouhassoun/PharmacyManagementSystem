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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");
        private DataView dataViewUsers;
        private static readonly Random random = new Random();

        void AlertBoxShow(string Type, string text)
        {
            FormAlertBox frm = new FormAlertBox();
            if (Type == "success")
            {
                frm.BackColor = Color.LightGreen;
                frm.ColorAlertBox = Color.SeaGreen;
                frm.TitleAlertBox = "Success";
                frm.IconAlertBox = Properties.Resources.success;
            }
            else if (Type == "error")
            {
                frm.BackColor = Color.LightPink;
                frm.ColorAlertBox = Color.DarkRed;
                frm.TitleAlertBox = "Error";
                frm.IconAlertBox = Properties.Resources.error;
            }
            else if (Type == "warrning")
            {
                frm.BackColor = Color.LightGoldenrodYellow;
                frm.ColorAlertBox = Color.Goldenrod;
                frm.TitleAlertBox = "Warrning";
                frm.IconAlertBox = Properties.Resources.warning;
            }
            else
            {
                frm.BackColor = Color.LightBlue;
                frm.ColorAlertBox = Color.DodgerBlue;
                frm.TitleAlertBox = "Information";
                frm.IconAlertBox = Properties.Resources.information;
            }

            frm.TextAlertBox = text;
            frm.Show();
        }
        
        void EmptyFields()
        {
            txtUsername.Text = comboRoles.Text = "";
        }
        void DGVUpdateUsers()
        {
            SQLiteCommand cmd = new SQLiteCommand("select username,user_role,creation_date,last_login_date from users", cnx);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            dgv.DataSource = null;
            if (dr.HasRows)
            {
                dgv.ColumnHeadersHeight = 30;
                dgv.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataTable dataTable = new DataTable();
                dataTable.Load(dr);
                dataViewUsers = new DataView(dataTable);
                dgv.DataSource = dataViewUsers;
                dgv.Columns["username"].HeaderText = "Username";
                dgv.Columns["user_role"].HeaderText = "User role";
                dgv.Columns["creation_date"].HeaderText = "Creation date";
                dgv.Columns["last_login_date"].HeaderText = "Last Login date";
            }
            cnx.Close();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            DGVUpdateUsers();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool Search(string username)
        {
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select username from users where username=@username", cnx);
            cmd.Parameters.AddWithValue("@username", username);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                found = true;
            }
            cnx.Close();
            return found;
        }
        public string GeneratePassword()
        {
            int length = 20;
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(0, validChars.Length);
                sb.Append(validChars[randomIndex]);
            }

            return sb.ToString();
        }
        string DefineRole(string username)
        {
            string role="none";
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
        //--------------------------------------------------------------------
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text!="" && comboRoles.Text != "")
            {
                if (!Search(txtUsername.Text))
                {
                    string password = GeneratePassword();
                    SQLiteCommand cmd = new SQLiteCommand("insert into users values(@username,@password,@role,@creation,@lastlogin,@regen)", cnx);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", comboRoles.Text);
                    cmd.Parameters.AddWithValue("@creation", DateTime.Now);
                    cmd.Parameters.AddWithValue("@lastlogin", DateTime.Now);
                    cmd.Parameters.AddWithValue("@regen", 1);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    AlertBoxShow("success", "The user has been added successfully");
                    EmptyFields();
                    DGVUpdateUsers();
                    MessageBox.Show("Password :"+password+"\nThe password has been copied");
                    Clipboard.SetText(password);
                }
                else
                    AlertBoxShow("error", "User exists already");
            }
            else
                AlertBoxShow("warrning", "Empty field detected");
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                if (Search(txtUsername.Text))
                {
                    if (txtUsername.Text != MainForm.lblusername)
                    {
                        SQLiteCommand cmd = new SQLiteCommand("delete from users where username=@username", cnx);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                        AlertBoxShow("success", "The user has been deleted successfully");
                        EmptyFields();
                        DGVUpdateUsers();
                    }
                    else
                        AlertBoxShow("error", "You can't delete the current working account");
                }
                else
                    AlertBoxShow("error", "User doesn't exists");
            }
            else
                AlertBoxShow("warrning", "Empty field detected");
        }

        private void btnPromoteUser_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                if (Search(txtUsername.Text))
                {
                    if (DefineRole(txtUsername.Text) == "Default")
                    {
                        SQLiteCommand cmd = new SQLiteCommand("update users set user_role='Admin' where username=@username", cnx);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                        AlertBoxShow("success", "The user has been promoted successfully");
                        EmptyFields();
                        DGVUpdateUsers();
                    }
                    else
                        AlertBoxShow("info", "User is already an Admin");
                }
                else
                    AlertBoxShow("error", "User doesn't exists");
            }
            else
                AlertBoxShow("warrning", "Empty field detected");
        }

        private void btnDemoteUser_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                if (Search(txtUsername.Text))
                {
                    if (DefineRole(txtUsername.Text) == "Admin")
                    {
                        if (txtUsername.Text != "meow")
                        {
                            SQLiteCommand cmd = new SQLiteCommand("update users set user_role='Default' where username=@username", cnx);
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            cnx.Open();
                            cmd.ExecuteNonQuery();
                            cnx.Close();
                            AlertBoxShow("success", "The user has been demoted successfully");
                            EmptyFields();
                            DGVUpdateUsers();
                        }
                        else
                            AlertBoxShow("error", "You can't demote master account");
                    }
                    else
                        AlertBoxShow("info", "User is already a Default user");
                }
                else
                    AlertBoxShow("error", "User doesn't exists");
            }
            else
                AlertBoxShow("warrning", "Empty field detected");
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                if (Search(txtUsername.Text))
                {
                    if (txtUsername.Text != "meow")
                    {
                        string password = GeneratePassword();
                        SQLiteCommand cmd = new SQLiteCommand("update users set user_password=@password,is_regen_password='1' where username=@username", cnx);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", password);
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                        AlertBoxShow("success", "The user password has been reset successfully");
                        EmptyFields();
                        DGVUpdateUsers();
                        MessageBox.Show("Password :" + password + "\nThe password has been copied");
                        Clipboard.SetText(password);
                    }
                    else
                        AlertBoxShow("error", "Can't change master account password");
                }
                else
                    AlertBoxShow("error", "User doesn't exists");
            }
            else
                AlertBoxShow("warrning", "Empty field detected");
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["username"].Value.ToString();
                comboRoles.Text = row.Cells["user_role"].Value.ToString();
            }
        }
    }
}
