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
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2();
        }

        private void cmpSignGeneration_Click(object sender, EventArgs e)
        {
            form2.Show(true);
        }

        private void cmpSignVerification_Click(object sender, EventArgs e)
        {
            form2.Show(false);
        }
    }
}
