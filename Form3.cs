using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigningInterface
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public void Show(string warning)
        {
            warningText.Text = warning;
            this.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
