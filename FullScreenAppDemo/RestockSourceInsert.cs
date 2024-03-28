using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullScreenAppDemo
{
    public partial class RestockSourceInsert : Form
    {
        public RestockSourceInsert()
        {
            InitializeComponent();
        }
        public string TextBoxSource
        {
            get { return this.txtSource.Text; }
            set { this.txtSource.Text = value; }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
            
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
