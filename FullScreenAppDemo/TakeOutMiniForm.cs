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
    public partial class TakeOutMiniForm : Form
    {
        public TakeOutMiniForm()
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
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a number or the backspace key
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Ignore the key press event
                e.Handled = true;
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;
            if (textBox.Text != "")
            {
                // Set the maximum length of characters for the TextBox
                int maxLength = int.Parse(Quantity); // Set your desired maximum length


                if (int.Parse(textBox.Text) > maxLength)
                {
                    // Trim the text to the maximum length
                    textBox.Text = maxLength.ToString();
                }
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name == "TakeOutForm")
                        (f as TakeOutForm).TotalUpdate();
                    
                }
            }
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach(Form f in Application.OpenForms)
            {
                if (f.Name == "TakeOutForm")
                    (f as TakeOutForm).TotalUpdate();
            }
        }
    }
}
