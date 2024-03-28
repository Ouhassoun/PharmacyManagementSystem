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
    public partial class TakeOutForm : Form
    {
        public TakeOutForm()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");
        public static int MedCount = 0;
        public static int QtyCount = 0;
        private Random random;
        public int ID;
        int IdLogs;
        private DataView dataView;
        private void in_out_Load(object sender, EventArgs e)
        {
            DGVUpdate();
        }
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

        
        void DGVUpdate()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from medicaments", cnx);
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
                dataView = new DataView(dataTable);
                dgv.DataSource = dataView;
                dgv.Columns["id_med"].Visible = false;
                dgv.Columns["primary_name"].HeaderText = "Name";
                dgv.Columns["secondary_name"].HeaderText = "Specification";
                dgv.Columns["quantity"].HeaderText = "Quantity";
                dgv.Columns["quantity_type"].HeaderText = "Quantity type";
                dgv.Columns["entry_date"].HeaderText = "Entry Date";
                dgv.Columns["expiration_date"].HeaderText = "Expiration Date";
                dgv.Columns["quantity_type"].DisplayIndex = 4;
            }
            cnx.Close();
        }
        public bool ExistsInFlow(string pn,string sn)
        {
            foreach(TakeOutMiniForm frm in flowLayoutPanel1.Controls)
            {
                if (frm.MedName == pn && frm.MedSname == sn)
                    return true;
            }
            return false;
        }
        public void TotalUpdate()
        {
            MedCount = 0;
            QtyCount = 0;
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is TakeOutMiniForm)
                {
                    MedCount++;
                    QtyCount = QtyCount + int.Parse((c as TakeOutMiniForm).TextBoxQuantity);
                }
            }
            lblTotalMeds.Text = MedCount.ToString();
            lblTotalQuantity.Text = QtyCount.ToString();
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a row is actually clicked
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                if (int.Parse(row.Cells["quantity"].Value.ToString()) >= 1 && !ExistsInFlow(row.Cells["primary_name"].Value.ToString(), row.Cells["secondary_name"].Value.ToString()))
                {
                    TakeOutMiniForm frm = new TakeOutMiniForm() { TopLevel = false };
                    frm.MedName = row.Cells["primary_name"].Value.ToString();
                    frm.MedSname = row.Cells["secondary_name"].Value.ToString();
                    frm.Quantity = row.Cells["quantity"].Value.ToString();
                    frm.MedID = int.Parse(row.Cells["id_med"].Value.ToString());
                    frm.TextBoxQuantity = "1";
                    flowLayoutPanel1.Controls.Add(frm);
                    frm.Show();
                    TotalUpdate();
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                    if (int.Parse(row.Cells["quantity"].Value.ToString()) == 0)
                        AlertBoxShow("warrning", "No stock is available for this medicament");
                    else
                        AlertBoxShow("info", "This medicament is already selected");
                }
            }
        }
        public void GenerateRandomID()
        {
            random = new Random();
            int id = random.Next(0, int.MaxValue);
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select take_id from take_out where take_id=@id", cnx);
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
                ID= id;
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
        private void btnTakeOut_Click(object sender, EventArgs e)
        {
            if(lblTotalMeds.Text!="None" && lblTotalQuantity.Text != "None")
            {
                if (int.Parse(lblTotalMeds.Text) != 0  && int.Parse(lblTotalQuantity.Text) != 0)
                {
                    if(comboService.Text!= "Select a Service ...")
                    {
                        SQLiteCommand cmd = new SQLiteCommand("insert into take_out values(@id,@date,@ser)", cnx);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        GenerateRandomID();
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@ser", comboService.Text);
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                        foreach (Control c in flowLayoutPanel1.Controls)
                        {

                            if (c is TakeOutMiniForm)
                            {
                                TakeOutMiniForm frm = (c as TakeOutMiniForm);
                                if (frm.TextBoxQuantity == "")
                                    continue;
                                SQLiteCommand Subcmd = new SQLiteCommand("insert into take_out_details values(@take_id,@med_id,@qty)", cnx);
                                Subcmd.Parameters.AddWithValue("@take_id", ID);
                                Subcmd.Parameters.AddWithValue("@med_id", frm.MedID);
                                Subcmd.Parameters.AddWithValue("@qty", int.Parse(frm.TextBoxQuantity));
                                cnx.Open();
                                Subcmd.ExecuteNonQuery();
                                cnx.Close();
                                Subcmd = new SQLiteCommand("update medicaments set quantity=@qty where id_med=@id", cnx);
                                int quantity = int.Parse(frm.Quantity) - int.Parse(frm.TextBoxQuantity);
                                Subcmd.Parameters.AddWithValue("@qty", quantity);
                                Subcmd.Parameters.AddWithValue("@id", frm.MedID);
                                cnx.Open();
                                Subcmd.ExecuteNonQuery();
                                cnx.Close();
                            }
                        }
                        flowLayoutPanel1.Controls.Clear();
                        DGVUpdate();
                        TotalUpdate();
                        AlertBoxShow("success", "The take out has been executed successfully");
                        GenerateLogs("TakeOut");
                    }
                }
            }
            
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            if(dgv.Rows.Count!=0)
                dataView.RowFilter = string.Format("primary_name LIKE '%{0}%'", searchText);
        }

    }
}
