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
using Excel = Microsoft.Office.Interop.Excel;

namespace FullScreenAppDemo
{
    public partial class MedicamentsForm : Form
    {
        public MedicamentsForm()
        {
            InitializeComponent();
        }
        SQLiteConnection cnx = new SQLiteConnection(@"URI=file:" + System.Windows.Forms.Application.StartupPath + "\\PmsDB.db;PRAGMA journal_mode = WAL;");
        
        private DataView dataView;
        Random random;
        public int ID;
        public int IdLogs;
        public int IDForm;
        private void MedicamentsForm_Load(object sender, EventArgs e)
        {
            comboQuantityType.Size = new Size(202, 47);
            DGVUpdate();
            ComboUpdate();
            dtpEntryDate.Value = dtpExpirationDate.Value = DateTime.Now;
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
        public void Validate(string type)
        {
            if (type == "save")
            {
                AlertBoxShow("success", "The medicament has been saved successfully");
            }
            else if(type == "update")
            {
                AlertBoxShow("success", "The medicament has been updated successfully");
            }
            else if(type == "delete")
            {
                AlertBoxShow("success", "The medicament has been deleted successfully");
            }
            DGVUpdate();
            EmptyFields();
        }
        public void EmptyFields()
        {
            txtName.Text = txtQuantity.Text = comboQuantityType.Text = txtSpecification.Text = "";
            dtpEntryDate.Value = dtpExpirationDate.Value = DateTime.Now;
        }
        public bool IdExists(string id)
        {
            bool meow;
            SQLiteCommand cmd = new SQLiteCommand("select * from medicaments where id_med=@id", cnx);
            cmd.Parameters.AddWithValue("@id", int.Parse(id));
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                meow = true;
            else
                meow = false;
            cnx.Close();
            return meow;
        }
        public bool NameExists(string pname,string sname)
        {
            bool meow;
            SQLiteCommand cmd = new SQLiteCommand("select * from medicaments where primary_name=@pn and secondary_name=@sn", cnx);
            cmd.Parameters.AddWithValue("@pn", pname);
            cmd.Parameters.AddWithValue("@sn", sname);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                meow = true;
            else
                meow = false;
            cnx.Close();
            return meow;
        }
        
        public bool isEmpty()
        {
            if (txtName.Text == "" || txtQuantity.Text == "" || txtSpecification.Text == "" ||comboQuantityType.Text=="")
                return true;
            else
                return false;
        }
        public void FillCmd(SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@pn", txtName.Text);
            cmd.Parameters.AddWithValue("@sn", txtSpecification.Text);
            cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text));
            cmd.Parameters.AddWithValue("@ed", dtpEntryDate.Value);
            cmd.Parameters.AddWithValue("@expd", dtpExpirationDate.Value);
            cmd.Parameters.AddWithValue("@qt", comboQuantityType.Text);
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
                dgv.RowsDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 10, FontStyle.Bold);
                dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 12, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                System.Data.DataTable dataTable = new System.Data.DataTable();
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
        public void GenerateRandomID()
        {
            random = new Random();
            int id = random.Next(0, int.MaxValue);
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select id_med from medicaments where id_med=@id", cnx);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isEmpty())
            {
                if (!NameExists(txtName.Text,txtSpecification.Text))
                {
                    SQLiteCommand cmd = new SQLiteCommand("insert into medicaments values (@id,@pn,@sn,@q,@ed,@expd,@qt)", cnx);
                    GenerateRandomID();
                    FillCmd(cmd);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    GenerateLogs("Add medicament "+txtName.Text+" "+txtSpecification.Text);
                    Validate("save");
                }
                else
                {
                    AlertBoxShow("error", "A Medicaments already exists with the same name");
                }
            }
            else
            {
                AlertBoxShow("warrning", "Empty fields");
            }
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!isEmpty())
            {
                if(NameExists(txtName.Text, txtSpecification.Text))
                {
                    SQLiteCommand cmd = new SQLiteCommand("delete from medicaments where primary_name=@pn and secondary_name=@sn", cnx);
                    cmd.Parameters.AddWithValue("@pn", txtName.Text);
                    cmd.Parameters.AddWithValue("@sn", txtSpecification.Text);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    GenerateLogs("Delete medicament "+ txtName.Text+" "+txtSpecification.Text);
                    Validate("delete");
                }
                else
                {
                    AlertBoxShow("error", "No medicament found with the entred name");
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

                // Retrieve data from the selected row and display in the textboxes
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = barcode.Draw(row.Cells["id_med"].Value.ToString(), 47);
                txtName.Text = row.Cells["primary_name"].Value.ToString();
                txtSpecification.Text = row.Cells["secondary_name"].Value.ToString();
                txtQuantity.Text = row.Cells["quantity"].Value.ToString();
                comboQuantityType.Text = row.Cells["quantity_type"].Value.ToString();
                dtpEntryDate.Value = (DateTime)row.Cells["entry_date"].Value;
                dtpExpirationDate.Value = (DateTime)row.Cells["expiration_date"].Value;
                IDForm = (int)row.Cells["id_med"].Value;
            }
        }
        bool search(string id , string pn,string sn)
        {
            bool found = false;
            SQLiteCommand cmd = new SQLiteCommand("select * from medicaments where id_med=@id and primary_name=@pn and secondary_name=@sn", cnx);
            cmd.Parameters.AddWithValue("@id", int.Parse(id));
            cmd.Parameters.AddWithValue("@pn", pn);
            cmd.Parameters.AddWithValue("@sn", sn);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                found = true;
            cnx.Close();
            return found;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool update = false;
            if(!isEmpty() && IDForm!=0)
            {
                if (search(IDForm.ToString(),txtName.Text,txtSpecification.Text))
                {
                    update = true;
                }
                else if(!NameExists(txtName.Text, txtSpecification.Text))
                {
                    update = true;
                }
                else
                {
                    AlertBoxShow("error", "Already exists with same info");
                }
            }
            else
            {
                AlertBoxShow("warrning", "Empty fields or unknown ID");
            }
            if (update)
            {
                SQLiteCommand cmd = new SQLiteCommand("update medicaments set primary_name=@pn,secondary_name=@sn,quantity=@q,entry_date=@ed,expiration_date=@expd,quantity_type=@qt where id_med=@id", cnx);
                cmd.Parameters.AddWithValue("@pn", txtName.Text);
                cmd.Parameters.AddWithValue("@sn", txtSpecification.Text);
                cmd.Parameters.AddWithValue("@q", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@qt", comboQuantityType.Text);
                cmd.Parameters.AddWithValue("@ed", dtpEntryDate.Value);
                cmd.Parameters.AddWithValue("@expd", dtpExpirationDate.Value);
                cmd.Parameters.AddWithValue("@id", IDForm);
                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
                GenerateLogs("Update medicament " + txtName.Text + " " + txtSpecification.Text);
                Validate("update");
            }
        }
        private bool IsNumeric(string input)
        {
            int result;
            return int.TryParse(input, out result);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (IsNumeric(searchText))
                dataView.RowFilter = string.Format("Convert(id_med, 'System.String') LIKE '%{0}%'", searchText);
            else
                dataView.RowFilter = string.Format("primary_name LIKE '%{0}%'", searchText);
        }




        private void ExportToExcel(string filePath)
        {
            
            
            cnx.Open();

            // Retrieve the medicaments data from the SQLite database
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM medicaments", cnx))
            {
                try
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Create a new Excel application
                        Excel.Application excelApp = new Excel.Application();

                        // Add a new workbook
                        Excel.Workbook workbook = excelApp.Workbooks.Add();

                        // Get the default worksheet
                        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                        // Set the column headers in the first row
                        int columnCount = dataTable.Columns.Count;
                        for (int i = 0; i < columnCount; i++)
                        {
                            worksheet.Cells[1, i + 1] = dataTable.Columns[i].ColumnName;
                        }

                        // Fill the data starting from the second row
                        int rowCount = dataTable.Rows.Count;
                        for (int i = 0; i < rowCount; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                            }
                        }

                        // Check if the file already exists
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath); // Delete the existing file
                        }

                        // Save the workbook to the specified file path
                        workbook.SaveAs(filePath);
                        GC.Collect();
                        workbook.Close();
                        excelApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                        worksheet = null;
                        workbook = null;
                        excelApp = null;
                        MessageBox.Show("Medicaments exported successfully.");
                        cnx.Close();
                        GenerateLogs("Export Medicaments");
                    }
                }catch(Exception m)
                {
                    MessageBox.Show("Close the working Excel file and try again");
                }
                
            }
            cnx.Close();
            
        }


        private void ImportFromExcel(string filePath)
        {
            
            string sheetName = "Sheet1"; // Modify this to match the name of your sheet

            // Create a new Excel application
            Excel.Application excelApp = new Excel.Application();

            // Open the Excel file
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

            // Get the first worksheet
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[sheetName];

            // Get the used range of cells
            Excel.Range usedRange = worksheet.UsedRange;

            // Get the number of rows and columns
            int rowCount = usedRange.Rows.Count;
            int columnCount = usedRange.Columns.Count;

            // Create a connection to the SQLite database
            
            cnx.Open();

            // Retrieve the existing records from the SQLite database
            List<string> existingRecords = new List<string>();
            using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM medicaments", cnx))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Create a unique identifier for each record using the primary key (id_med)
                        string recordIdentifier = reader["id_med"].ToString();

                        // Add the identifier to the list
                        existingRecords.Add(recordIdentifier);
                    }
                }
            }

            // Start a transaction for faster inserts
            using (SQLiteTransaction transaction = cnx.BeginTransaction())
            {
                // Prepare the INSERT statement
                string insertQuery = "INSERT INTO medicaments (id_med, primary_name, secondary_name, quantity, entry_date, expiration_date, quantity_type) " +
                                        "VALUES (@id_med, @primary_name, @secondary_name, @quantity, @entry_date, @expiration_date, @quantity_type)";

                using (SQLiteCommand command = new SQLiteCommand(insertQuery, cnx))
                {
                    // Bind the parameters
                    command.Parameters.AddWithValue("@id_med", null);
                    command.Parameters.AddWithValue("@primary_name", null);
                    command.Parameters.AddWithValue("@secondary_name", null);
                    command.Parameters.AddWithValue("@quantity", null);
                    command.Parameters.AddWithValue("@entry_date", null);
                    command.Parameters.AddWithValue("@expiration_date", null);
                    command.Parameters.AddWithValue("@quantity_type", null);

                    // Iterate through each row in the Excel sheet (skipping the header row)
                    for (int row = 2; row <= rowCount; row++)
                    {
                        // Set the parameter values from the corresponding cells in the Excel sheet
                        for (int col = 1; col <= columnCount; col++)
                        {
                            command.Parameters[col - 1].Value = usedRange.Cells[row, col].Value;
                        }

                        // Create a unique identifier for the current record using the primary key (id_med)
                        string recordIdentifier = command.Parameters[0].Value.ToString();

                        // Check if the record already exists in the database
                        if (existingRecords.Contains(recordIdentifier))
                        {
                            // Skip importing this record as it already exists in the database
                            continue;
                        }

                        // Execute the INSERT statement
                        command.ExecuteNonQuery();
                    }
                }

                // Commit the transaction
                transaction.Commit();
            }
            cnx.Close();

            // Close the Excel workbook and application
            workbook.Close();
            excelApp.Quit();

            // Release the COM objects to avoid memory leaks
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count != 0)
            {
                
                    ExportToExcel(Application.StartupPath + "\\meow.xlsx");
                    
                
            }
            else
            {
                MessageBox.Show("Nothing to Export >~<");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Select Excel File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Call the ImportFromExcel method with the selected file path
                    ImportFromExcel(filePath);
                }
                MessageBox.Show("Medicaments imported successfully.");
            GenerateLogs("Imported Medicaments");
            DGVUpdate();
            
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(txtQuantity.Text, out value))
            {
                // Invalid input, clear the text box or set it to a valid default value
                txtQuantity.Text = "";
            }
        }
        private void pNameMaxLenght_KeyPress(object sender, KeyPressEventArgs e)
        {
            int maxLength = 60; // Specify the maximum length here
            if (txtName.Text.Length >= maxLength && e.KeyChar != '\b')
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }
        private void sNameMaxLenght_KeyPress(object sender, KeyPressEventArgs e)
        {
            int maxLength = 30; // Specify the maximum length here

            if (txtSpecification.Text.Length >= maxLength && e.KeyChar != '\b')
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }
        private void QuantityTypeMaxLenght_KeyPress(object sender, KeyPressEventArgs e)
        {
            int maxLength = 30; // Specify the maximum length here

            if (comboQuantityType.Text.Length >= maxLength && e.KeyChar != '\b')
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

        public void ComboUpdate()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from quantity_type", cnx);
            cnx.Open();
            SQLiteDataReader dr = cmd.ExecuteReader();
            BindingSource bs = new BindingSource();
            comboQuantityType.DataSource = null;
            
            if (dr.HasRows)
            {
                bs.DataSource = dr;
                comboQuantityType.DataSource = bs;
                comboQuantityType.DisplayMember = "quantity_type_name";
                comboQuantityType.ValueMember = "quantity_type_id";
            }
            cnx.Close();
        }
        private void btnQuantityType_Click(object sender, EventArgs e)
        {
            QuantityType frm = new QuantityType();
            frm.ShowDialog();
            ComboUpdate();
        }
    }
}
