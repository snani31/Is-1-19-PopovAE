using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Is_1_19_PopovAE
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task1 form2 = new Task1();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task2 form3 = new Task2();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task3 form4 = new Task3();
            form4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Task4 form5 = new Task4();
            form5.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Task5 form6 = new Task5();
            form6.ShowDialog();
        }
    }
}
