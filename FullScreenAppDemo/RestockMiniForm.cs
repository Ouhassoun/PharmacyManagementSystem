using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace FullScreenAppDemo
{
    public partial class RestockMiniForm : Form
    {
        public RestockMiniForm()
        {
            InitializeComponent();
        }
        private int ID;
        public int MedID
        {
            get { return ID; }
            set { ID = value; }
        }
        public string MedName
        {
            get { return this.lblMedName.Text; }
            set { this.lblMedName.Text = value; }
        }
        public string MedSname
        {
            get { return this.lblMedSname.Text; }
            set { this.lblMedSname.Text = value; }
        }
        public string Quantity
        {
            get { return this.lblQuantity.Text; }
            set { this.lblQuantity.Text = value; }
        }
        public string TextBoxQuantity
        {
            get { return this.txtQuantity.Text; }
            set { this.txtQuantity.Text = value; }
        }
        public string TextBoxSource
        {
            get { return this.txtSource.Text; }
            set { this.txtSource.Text = value; }
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Ignore the key press event
                e.Handled = true;
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;
            int value;
            if (!int.TryParse(textBox.Text, out value))
            {
                // Invalid input, clear the text box or set it to a valid default value
                textBox.Text = "";
            }
            if (textBox.Text != "")
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "RestockForm")
                        (f as RestockForm).TotalUpdate();

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "RestockForm")
                    (f as RestockForm).TotalUpdate();
            }
        }

        private void btnEditSource_Click(object sender, EventArgs e)
        {
            RestockSourceInsert frm = new RestockSourceInsert();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                txtSource.Text = frm.TextBoxSource;
            }
        }
    }
}
