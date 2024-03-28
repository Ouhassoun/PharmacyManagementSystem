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
using Guna.UI2.WinForms;
using FullScreenAppDemo.DataSet69TableAdapters;
using System.Text.RegularExpressions;

namespace FullScreenAppDemo
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");

        private void LoadTakeOut()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from take_out", cnx);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Guna2GradientTileButton btn = new Guna2GradientTileButton();
                    btn.Size = new Size(150, 150);
                    btn.Image = Properties.Resources.document;
                    btn.ImageSize = new Size(90, 90);
                    btn.ImageOffset = new Point(0, 20);
                    btn.Tag = dr["take_id"].ToString();
                    btn.Text = "Delivery Report\n" + dr["service_"].ToString() + "\n" + DateTime.Parse(dr["take_out_date"].ToString()).ToString("dd/MM/yy");
                    btn.Font = new Font("Century Gothic", 9, FontStyle.Bold);
                    btn.ForeColor = Color.Black;
                    btn.TextOffset = new Point(0, 0);
                    btn.FillColor = Color.Transparent;
                    btn.FillColor2 = Color.Transparent;
                    btn.Click += btnPrintTakeOut_Click;
                    flowLayoutPanel1.Controls.Add(btn);
                }
            }
            cnx.Close();
        }
        private void SortButtonsByDateDescending()
        {
            List<Guna2GradientTileButton> buttons = flowLayoutPanel1.Controls.OfType<Guna2GradientTileButton>().ToList();

            buttons.Sort((button1, button2) =>
            {
                DateTime date1, date2;

                string datePattern = @"\d{2}/\d{2}/\d{2}";

                string name1 = button1.Text;
                string name2 = button2.Text;

                string dateStr1 = Regex.Match(name1, datePattern).Value;
                string dateStr2 = Regex.Match(name2, datePattern).Value;

                DateTime.TryParseExact(dateStr1, "dd/MM/yy", null, System.Globalization.DateTimeStyles.None, out date1);
                DateTime.TryParseExact(dateStr2, "dd/MM/yy", null, System.Globalization.DateTimeStyles.None, out date2);

                // Compare the parsed DateTime objects in descending order
                return date2.CompareTo(date1);
            });

            // Clear the FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            // Add the sorted buttons back to the FlowLayoutPanel
            flowLayoutPanel1.Controls.AddRange(buttons.ToArray());
        }
        private void LoadRestock()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from restock", cnx);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Guna2GradientTileButton btn = new Guna2GradientTileButton();
                    btn.Size = new Size(150, 150);
                    btn.Image = Properties.Resources.document_red;
                    btn.ImageSize = new Size(90, 90);
                    btn.ImageOffset = new Point(0, 20);
                    btn.Tag = dr["restock_id"].ToString();
                    btn.Text = "Restock Report\n"+ DateTime.Parse(dr["restock_date"].ToString()).ToString("dd/MM/yy");
                    btn.Font = new Font("Century Gothic", 9, FontStyle.Bold);
                    btn.ForeColor = Color.Black;
                    btn.TextOffset = new Point(0, 0);
                    btn.FillColor = Color.Transparent;
                    btn.FillColor2 = Color.Transparent;
                    btn.Click += btnPrintRestock_Click;
                    flowLayoutPanel1.Controls.Add(btn);
                }
            }
            cnx.Close();
        }
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadTakeOut();
            LoadRestock();
            SortButtonsByDateDescending();
        }
        private void btnPrintTakeOut_Click(object sender, EventArgs e)
        {
            
                cnx.Open();

                // Create a DataSet and fill it with data from the SQLite database
                DataSet69 ds = new DataSet69();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter("select take_out_details.take_id, take_out.service_, medicaments.primary_name,medicaments.secondary_name,take_out_details.quantity from ((take_out_details INNER JOIN take_out ON take_out.take_id = take_out_details.take_id) INNER JOIN medicaments ON medicaments.id_med = take_out_details.id_med)", cnx))
                {
                    da.Fill(ds.TakeOutDataTable);
                }

                // Create the Crystal Report
                TakeOutReport report = new TakeOutReport();
                report.SetDataSource(ds);

                // Set report parameters
                int takeID = int.Parse((sender as Guna2GradientTileButton).Tag.ToString());
                report.SetParameterValue("pmTakeID", takeID);

                // Display the report in your form
                ShowReport form = new ShowReport();
                (form.Controls["crystalReportViewer1"] as CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = report;
                cnx.Close();
                form.Show();
            


        }
        private void btnPrintRestock_Click(object sender, EventArgs e)
        {
          
            
                cnx.Open();

                // Create a DataSet and fill it with data from the SQLite database
                DataSet69 ds = new DataSet69();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT restock_details.restock_id, restock_details.source_, medicaments.primary_name, medicaments.secondary_name, restock_details.quantity FROM restock_details, medicaments WHERE(medicaments.id_med = restock_details.id_med)", cnx))
                {
                    da.Fill(ds.RestockDataTable);
                }

                // Create the Crystal Report
                RestockReport report = new RestockReport();
                report.SetDataSource(ds);

                // Set report parameters
                int RestockID = int.Parse((sender as Guna2GradientTileButton).Tag.ToString());
                report.SetParameterValue("pmRestockID", RestockID);

                // Display the report in your form
                ShowReport form = new ShowReport();
                (form.Controls["crystalReportViewer1"] as CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = report;
            cnx.Close();    
            form.Show();
            
        }
    }
}
