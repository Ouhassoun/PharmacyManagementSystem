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
    public partial class LoadingScreen : Form
    {
        private int progressValue;
        private int incrementAmount;
        public LoadingScreen()
        {
            InitializeComponent();
            timer1.Interval = 100;
            incrementAmount = 1;
        }
        bool finish = false;
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");

        private void LoadingScreen_Load(object sender, EventArgs e)
        {

            timer1.Start();
            CreateDataBase();
        }
        private void CreateDataBase()
        {
            string path = "PmsDB.db";
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                SQLiteCommand cmdMedicaments = new SQLiteCommand("create table medicaments(id_med int primary key,primary_name nvarchar(60),secondary_name nvarchar(30),quantity int,entry_date date,expiration_date date,quantity_type nvarchar(30))", cnx);
                SQLiteCommand cmdTakeOut = new SQLiteCommand("create table take_out(take_id int primary key,take_out_date date,service_ nvarchar(90))", cnx);
                SQLiteCommand cmdTakeOutDetails = new SQLiteCommand("create table take_out_details(take_id int,id_med int,quantity int,primary key(take_id,id_med),FOREIGN KEY (take_id)REFERENCES take_out (take_id) ON UPDATE cascade ON DELETE cascade,FOREIGN KEY (id_med)REFERENCES medicaments (id_med) ON UPDATE cascade ON DELETE cascade)", cnx);
                SQLiteCommand cmdRestock = new SQLiteCommand("create table restock(restock_id int primary key,restock_date date)", cnx);
                SQLiteCommand cmdRestockDetails = new SQLiteCommand("create table restock_details(restock_id int,id_med int,quantity int,source_ nvarchar(120),primary key(restock_id,id_med),FOREIGN KEY (id_med)REFERENCES medicaments (id_med) ON UPDATE cascade ON DELETE cascade,FOREIGN KEY (restock_id)REFERENCES restock (restock_id) ON UPDATE cascade ON DELETE cascade)", cnx);
                SQLiteCommand cmdQuantityType = new SQLiteCommand("create table quantity_type(quantity_type_id int primary key,quantity_type_name nvarchar(30))", cnx);
                SQLiteCommand cmdusers = new SQLiteCommand("create table users(username nvarchar(30),user_password nvarchar(120),user_role nvarchar(30),creation_date date,last_login_date date,is_regen_password int,primary key(username))", cnx);
                SQLiteCommand cmdlogs = new SQLiteCommand("create table logs(log_id int,username nvarchar(30),user_action nvarchar(100),action_date date,primary key(log_id),FOREIGN KEY (username)REFERENCES users (username) ON UPDATE cascade ON DELETE cascade)", cnx);
                SQLiteCommand cmdCreateUser = new SQLiteCommand("insert into users values('meow','meow','Admin',DATE('2023-07-07'),DATE('2023-07-07'),'0')", cnx);
                cnx.Open();
                using (SQLiteCommand pragmaCommand = new SQLiteCommand("PRAGMA journal_mode=WAL;", cnx))
                {
                    pragmaCommand.ExecuteNonQuery();
                }
                cmdMedicaments.ExecuteNonQuery();
                cmdTakeOut.ExecuteNonQuery();
                cmdRestock.ExecuteNonQuery();
                cmdTakeOutDetails.ExecuteNonQuery();
                cmdRestockDetails.ExecuteNonQuery();
                cmdQuantityType.ExecuteNonQuery();
                cmdusers.ExecuteNonQuery();
                cmdlogs.ExecuteNonQuery();
                cmdCreateUser.ExecuteNonQuery();
                cnx.Close();
                finish = true;
            }
            else
                finish = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("PmsDB.db"))
                incrementAmount = 1;
            else
                incrementAmount = 10;
            if (finish != false)
            {
                progressValue += incrementAmount;
                ProgressBar.Value = progressValue;
            }
            if (progressValue == 0)
                lblInfo.Text = "Creating database ...";
            else if(progressValue == 50)
                lblInfo.Text = "Creating forms ...";
            else if (progressValue == 80)
                lblInfo.Text = "Creating beautiful stuff for you ...";
            if (progressValue >= ProgressBar.Maximum)
            {
                timer1.Stop();
                LogInForm frmLogin = new LogInForm();
                this.Hide();
                frmLogin.Show();
            }
        }
    }
}
