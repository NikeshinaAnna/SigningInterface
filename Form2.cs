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
    public partial class Form2 : Form
    {
        private bool isGeneratingSign;
        Form3 form3;
        Form4 form4;
        public Form2()
        {
            InitializeComponent();
            form3 = new Form3();
            form4 = new Form4();
        }

        public void Show(bool isItGenerateSign)
        {
            isGeneratingSign = isItGenerateSign;
            this.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private List<CheckBox> getSelectedCurves()
        {
            var result = new List<CheckBox>();
            if (cbWeirProj.Checked)
                result.Add(cbWeirProj);
            if (cbWeirCartes.Checked)
                result.Add(cbWeirCartes);
            if (cbEdwCartes.Checked)
                result.Add(cbEdwCartes);
            if (cbEdwProj.Checked)
                result.Add(cbEdwProj);

            return result;
        }

        private bool ValidateOkClick()
        {
            if (!cbWeirProj.Checked && !cbWeirCartes.Checked && !cbEdwProj.Checked && !cbEdwCartes.Checked)
            {
                form3.Show("Необходимо выбрать хотя бы один вариант, для которого будут проводиться замеры!");
                return false;
            }
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!this.ValidateOkClick())
            {
                return;
            }
            if (isGeneratingSign)
            {
                form4 = new Form4();
                form4.showCreateSignResult(getSelectedCurves());
                form4.Show("Генерация");
                this.Close();
            }
            else
            {
                form4 = new Form4();
                form4.showVerifySignResult(getSelectedCurves());
                form4.Show("Проверка");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
