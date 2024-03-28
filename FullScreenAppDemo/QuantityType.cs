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
    public partial class QuantityType : Form
    {
        public QuantityType()
        {
            InitializeComponent();
        }
        Random random;
        int ID;
        int IdLogs;
        DataView dataView;
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + System.Windows.Forms.Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");
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
        public void Validate(string type)
        {
            if (type == "save")
            {
                AlertBoxShow("success", "The quantity type has been saved successfully");
            }
            else if (type == "update")
            {
                AlertBoxShow("success", "The quantity type has been updated successfully");
            }
            else if (type == "delete")
            {
                AlertBoxShow("success", "The quantity type has been deleted successfully");
            }
            DGVUpdate();
            EmptyFields();
        }
        public void EmptyFields()
        {
            txtName.Text = txtID.Text = "";
        }
        public bool Search(int id,string name)
        {
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select * from quantity_type where quantity_type_id=@id and quantity_type_name=@name", cnx);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                found = true;
            cnx.Close();
            return found;
        }
        public void GenerateRandomID()
        {
            random = new Random();
            int id = random.Next(0, int.MaxValue);
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select quantity_type_id from quantity_type where quantity_type_id=@id", cnx);
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
        void DGVUpdate()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from quantity_type", cnx);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();

            dgv.DataSource = null;
            if (dr.HasRows)
            {
                dgv.ColumnHeadersHeight = 30;
                dgv.RowsDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, FontStyle.Bold);
                dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 12, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataTable.Load(dr);
                dataView = new DataView(dataTable);
                dgv.DataSource = dataView;
                dgv.Columns["quantity_type_id"].HeaderText = "ID";
                dgv.Columns["quantity_type_name"].HeaderText = "Name";
            }
            cnx.Close();
        }


        private void QuantityType_Load(object sender, EventArgs e)
        {
            DGVUpdate();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtName.Text!="")
            {
                GenerateRandomID();
                if (!Search(ID,txtName.Text) && !SearchName(txtName.Text))
                {
                    SQLiteCommand cmd = new SQLiteCommand("insert into quantity_type values (@id,@name)", cnx);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    GenerateLogs("Add quantity type "+txtName.Text);
                    Validate("save");
                    DGVUpdate();
                }
                else
                {
                    AlertBoxShow("error", "A quantity type already exists with the same name");
                }
            }
            else
            {
                AlertBoxShow("warrning", "Please provide a name");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text!="" && txtID.Text!="")
            {
                if (Search(int.Parse(txtID.Text),txtName.Text))
                {
                    SQLiteCommand cmd = new SQLiteCommand("delete from quantity_type where quantity_type_id=@id", cnx);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    GenerateLogs("Delete quantity type " + txtName.Text);
                    Validate("delete");
                }
                else
                {
                    AlertBoxShow("error", "No quantity type was found with the entred name");
                }
            }
            else
            {
                AlertBoxShow("warrning", "Empty fields");
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a row is actually clicked
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                txtName.Text = row.Cells["quantity_type_name"].Value.ToString();
                txtID.Text = row.Cells["quantity_type_id"].Value.ToString();
            }
        }

        public bool SearchID(int id)
        {
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select * from quantity_type where quantity_type_id=@id", cnx);
            cmd.Parameters.AddWithValue("@id", id);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                found = true;
            cnx.Close();
            return found;
        }
        public bool SearchName(string name)
        {
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select * from quantity_type where quantity_type_name=@name", cnx);
            cmd.Parameters.AddWithValue("@name", name);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                found = true;
            cnx.Close();
            return found;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtID.Text != "")
            {
                if (SearchID(int.Parse(txtID.Text)))
                {
                    if (!SearchName(txtName.Text))
                    {
                        SQLiteCommand cmd = new SQLiteCommand("update quantity_type set quantity_type_name=@name where quantity_type_id=@id", cnx);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                        GenerateLogs("Update quantity type " + txtName.Text);
                        DGVUpdate();
                        Validate("update");
                    }
                    else
                        AlertBoxShow("error", "There is already a quantity type with the same name");
                }
                else
                    AlertBoxShow("warrning", "unvalid ID");
            }
            else
                AlertBoxShow("warrning", "Empty fields");
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            int maxLength = 30;

            if (txtName.Text.Length >= maxLength && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            
        }
    }
}
