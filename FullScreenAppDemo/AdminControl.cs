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
    public partial class AdminControl : Form
    {
        public AdminControl()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");

        private DataView dataViewLogs;
        private DataView dataViewUsers;
        void DGVUpdateLogs()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from logs order by action_date DESC", cnx);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            dgvLogs.DataSource = null;
            if (dr.HasRows)
            {
                dgvLogs.ColumnHeadersHeight = 30;
                dgvLogs.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                dgvLogs.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                dgvLogs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataTable dataTable = new DataTable();
                dataTable.Load(dr);
                dataViewLogs = new DataView(dataTable);
                dgvLogs.DataSource = dataViewLogs;
                dgvLogs.Columns["log_id"].HeaderText = "Log ID";
                dgvLogs.Columns["username"].HeaderText = "Username";
                dgvLogs.Columns["user_action"].HeaderText = "User action";
                dgvLogs.Columns["action_date"].HeaderText = "Action date";
            }
            cnx.Close();
        }
        void DGVUpdateUsers()
        {
            SQLiteCommand cmd = new SQLiteCommand("select Username,user_role from users", cnx);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            dgvUsers.DataSource = null;
            if (dr.HasRows)
            {
                dgvUsers.ColumnHeadersHeight = 30;
                dgvUsers.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                dgvUsers.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                dgvUsers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataTable dataTable = new DataTable();
                dataTable.Load(dr);
                dataViewUsers = new DataView(dataTable);
                dgvUsers.DataSource = dataViewUsers;
                dgvUsers.Columns["username"].HeaderText = "Username";
                dgvUsers.Columns["user_role"].HeaderText = "User role";
            }
            cnx.Close();
        }
        void PanelInfo()
        {
            SQLiteCommand cmdTotalUsers = new SQLiteCommand("SELECT COUNT(*) from users", cnx);
            SQLiteCommand cmdTotalActions = new SQLiteCommand("SELECT COUNT(*) from logs WHERE strftime('%m/%d/%Y', action_date) = strftime('%m/%d/%Y', 'now', 'localtime');", cnx);
            SQLiteCommand cmdLastAction = new SQLiteCommand("SELECT user_action FROM logs ORDER BY action_date DESC LIMIT 1", cnx);
            cnx.Open();
            lblTotalUsers.Text = cmdTotalUsers.ExecuteScalar().ToString();
            lblTotalActions.Text = cmdTotalActions.ExecuteScalar().ToString();
            SQLiteDataReader dr = cmdLastAction.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                    lblLastAction.Text = dr[0].ToString();
            }
            cnx.Close();
        }
        private void AdminControl_Load(object sender, EventArgs e)
        {
            DGVUpdateLogs();
            DGVUpdateUsers();
            PanelInfo();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsers frm = new ManageUsers();
            frm.ShowDialog();
            DGVUpdateUsers();
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            ViewLogs frm = new ViewLogs();
            frm.ShowDialog();
            DGVUpdateLogs();
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            ClearLogsConfirmation frm = new ClearLogsConfirmation();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                SQLiteCommand cmd = new SQLiteCommand("delete from logs", cnx);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
                DGVUpdateLogs();
            }
        }
    }
}
