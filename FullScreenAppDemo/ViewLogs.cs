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
    public partial class ViewLogs : Form
    {
        public ViewLogs()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");

        private DataView dataViewLogs;
        void DGVUpdateLogs()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from logs order by action_date DESC", cnx);
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
                dataViewLogs = new DataView(dataTable);
                dgv.DataSource = dataViewLogs;
                dgv.Columns["log_id"].HeaderText = "Log ID";
                dgv.Columns["username"].HeaderText = "Username";
                dgv.Columns["user_action"].HeaderText = "User action";
                dgv.Columns["action_date"].HeaderText = "Action date";
            }
            cnx.Close();
        }
        void ComboFilterUserFill()
        {
            if (dgv.Rows.Count != 0)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT DISTINCT username FROM logs", cnx);
                cnx.Open();
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboFilterUser.Items.Add(dr["username"].ToString());
                    }
                }
                cnx.Close();
            }
        }
        void ComboFilterActionFill()
        {
            if (dgv.Rows.Count != 0)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT DISTINCT user_action FROM logs", cnx);
                cnx.Open();
                SQLiteDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comboFilterAction.Items.Add(dr["user_action"].ToString());
                    }
                }
                cnx.Close();
            }
        }

        private void ViewLogs_Load(object sender, EventArgs e)
        {
            DGVUpdateLogs();
            ComboFilterUserFill();
            //ComboFilterActionFill();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            comboFilterAction.SelectedIndex = comboFilterUser.SelectedIndex = -1;
            DGVUpdateLogs();
        }

        private void comboFilterAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFilterAction.Text != "")
            {
                SQLiteCommand cmd;
                if (comboFilterUser.Text != "")
                {
                    cmd = new SQLiteCommand("SELECT * FROM logs where user_action like '" + comboFilterAction.Text + "%' and username=@username", cnx);
                    cmd.Parameters.AddWithValue("@username", comboFilterUser.Text);
                }
                else
                    cmd = new SQLiteCommand("SELECT * FROM logs where user_action like '" + comboFilterAction.Text + "%'", cnx);
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
                    dataViewLogs = new DataView(dataTable);
                    dgv.DataSource = dataViewLogs;
                    dgv.Columns["log_id"].HeaderText = "Log ID";
                    dgv.Columns["username"].HeaderText = "Username";
                    dgv.Columns["user_action"].HeaderText = "User action";
                    dgv.Columns["action_date"].HeaderText = "Action date";
                }
                cnx.Close();
            }
        }

        private void comboFilterUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFilterUser.Text != "")
            {
                SQLiteCommand cmd;
                if (comboFilterAction.Text != "")
                {
                    cmd = new SQLiteCommand("SELECT * FROM logs where user_action like '"+comboFilterAction.Text+"%' and username=@username", cnx);
                }
                else
                    cmd = new SQLiteCommand("SELECT * FROM logs where username=@username", cnx);
                cmd.Parameters.AddWithValue("@username", comboFilterUser.Text);
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
                    dataViewLogs = new DataView(dataTable);
                    dgv.DataSource = dataViewLogs;
                    dgv.Columns["log_id"].HeaderText = "Log ID";
                    dgv.Columns["username"].HeaderText = "Username";
                    dgv.Columns["user_action"].HeaderText = "User action";
                    dgv.Columns["action_date"].HeaderText = "Action date";
                }
                cnx.Close();
            }
        }
    }
}
