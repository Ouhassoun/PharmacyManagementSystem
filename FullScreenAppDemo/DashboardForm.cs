using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms.Integration;

namespace FullScreenAppDemo
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }
        
        
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db; PRAGMA journal_mode = WAL");
        
        
        
        private void SetupChart()
        {

            SeriesCollection seriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Quantity",
                    Values = new ChartValues<int>(),
                    DataLabels = true
                }
            };

            chart.Series = seriesCollection;
            chart.AxisX.Add(new Axis { Title = "Medicament Name" });
            chart.AxisY.Add(new Axis { Title = "Quantity" });
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            RetrieveMedicamentData();
        }
        private void RetrieveMedicamentData()
        {
            string query = "SELECT primary_name, quantity FROM medicaments ORDER BY quantity ASC LIMIT 10";

            
            
            cnx.Open();

            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, cnx))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                UpdateChart(dataTable);
            }
            cnx.Close();

        }
        private void UpdateChart(DataTable dataTable)
        {
            SeriesCollection seriesCollection = chart.Series;

            if (seriesCollection.Count > 0)
            {
                ColumnSeries series = (ColumnSeries)seriesCollection[0];
                series.Values.Clear();
            }
            else
            {
                seriesCollection.Add(new ColumnSeries
                {
                    Title = "Quantity",
                    
                    Values = new ChartValues<int>(),
                    DataLabels = true
                });
            }

            Axis axisX = chart.AxisX[0];
            axisX.Labels = new List<string>();

            ColumnSeries medicamentSeries = (ColumnSeries)seriesCollection[0];

            foreach (DataRow row in dataTable.Rows)
            {
                string name = row["primary_name"].ToString();
                int quantity = Convert.ToInt32(row["quantity"]);
                medicamentSeries.Values.Add(quantity);
                axisX.Labels.Add(name);
                medicamentSeries.InitializeColors();
            }
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(primary_name) FROM medicaments", cnx);
            cnx.Open();
            lblTotalMeds.Text = cmd.ExecuteScalar().ToString();
            cmd = new SQLiteCommand("SELECT COUNT(primary_name) FROM medicaments where expiration_date<date('now')", cnx);
            lblExpired.Text = cmd.ExecuteScalar().ToString();
            cmd = new SQLiteCommand("SELECT SUM(quantity) FROM medicaments", cnx);
            lblQuantity.Text = cmd.ExecuteScalar().ToString();
            cmd = new SQLiteCommand("select COUNT(*) from medicaments where quantity=0", cnx);
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            if (count == 0)
            {
                lblLowStock.Location = new Point(3, 90);
                lblLowStock.Font = new Font("Century Gothic", 22,FontStyle.Bold);
                lblLowStock.Text = "None";
            }else if (count > 0 && count <3)
            {
                cmd = new SQLiteCommand("select * from medicaments where quantity=0", cnx);
                SQLiteDataReader dr = cmd.ExecuteReader();
                lblLowStock.Location = new Point(3, 70);
                lblLowStock.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                lblLowStock.Text = "";
                for (int i = 0; i < count; i++)
                {
                    dr.Read();
                    lblLowStock.Text = lblLowStock.Text+dr["primary_name"].ToString()+"\n";
                    
                }
            }
            else
            {
                cmd = new SQLiteCommand("select * from medicaments where quantity=0", cnx);
                SQLiteDataReader dr = cmd.ExecuteReader();
                lblLowStock.Location = new Point(3, 70);
                lblLowStock.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                lblLowStock.Text = "";
                for (int i = 0; i < 2; i++)
                {
                    dr.Read();
                    lblLowStock.Text = lblLowStock.Text+dr["primary_name"].ToString() + "\n";
                    
                }
                int countt = count - 2;
                lblLowStock.Text = lblLowStock.Text + "and " + countt + " more";
            }
            cnx.Close();
            SetupChart();
            timer1.Start();
        }
    }
}
