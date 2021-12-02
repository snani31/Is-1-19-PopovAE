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
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        abstract class Components<T>
        {
            public T artikul;
            public int price;
            public int date;

            public Components(T AR, int PR, int DaT)
            {
                artikul = AR;
                price = PR;
                date = DaT;
            }

            abstract public void DisplayInfo(ListBox L);
            
        }

        class CPU<T> : Components<T>
        {
            int cpu_frequency;
            int number_Cores;
            int number_threads;

           int CPU_frequency { get { return cpu_frequency; } set { cpu_frequency = value; } }
           int Number_Cores { get { return number_Cores; } set { number_Cores = value; } }
            int Number_threads { get { return number_threads; } set { number_threads = value; } }

            public CPU(T AR, int PR, int DaT, int FRE, int COR, int THR)
               : base (AR, PR, DaT)
            {
                CPU_frequency = FRE;
                Number_Cores = COR;
                Number_threads = THR;
            }

            public override void DisplayInfo(ListBox L)
            { 
                L.Items.Clear();
                L.Items.Add($"Артикул - {artikul}");
                L.Items.Add($"Дата изготовления - {date}");
                L.Items.Add($"Цена - {price}");
                L.Items.Add($"Частота - {CPU_frequency}");
                L.Items.Add($"Количество ядер - {Number_Cores}");
                L.Items.Add($"Количество потоков - {Number_threads}");
            }


        }

        class Videocard<T> : Components<T>
        {

            int gpu_frequency;
            string maker;
            int memory;

            public int GPU_frequency { get { return gpu_frequency; } set { gpu_frequency = value ; } } 
            public string Maker { get { return maker; } set { maker = value; } } 
            public int Memory { get { return memory; } set { memory = value; } }

            public Videocard(T AR, int PR, int DaT, int FRE, string MAK, int MEM)
               : base(AR, PR, DaT)
            {
                GPU_frequency = FRE;
                Maker = MAK;
                Memory = MEM;
            }

            public override void DisplayInfo(ListBox L)
            {
                L.Items.Clear();
                L.Items.Add($"Артикул - {artikul}");
                L.Items.Add($"Дата изготовления - {date}");
                L.Items.Add($"Цена - {price}");
                L.Items.Add($"Частота - {GPU_frequency}");
                L.Items.Add($"Производитель - {Maker}");
                L.Items.Add($"Объём памяти - {Memory}");
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a1 = Convert.ToInt32(textBox1.Text);
            int a2 = Convert.ToInt32(textBox2.Text);
            int a3 = Convert.ToInt32(textBox3.Text);
            int a4 = Convert.ToInt32(textBox4.Text);
            int a5 = Convert.ToInt32(textBox5.Text);
            int a6 = Convert.ToInt32(textBox6.Text);

            CPU<int> processor = new CPU<int>(a1, a2, a3, a4, a5, a6);
            processor.DisplayInfo(listBox1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int a1 = Convert.ToInt32(textBox12.Text);
            int a2 = Convert.ToInt32(textBox11.Text);
            int a3 = Convert.ToInt32(textBox10.Text);
            int a4 = Convert.ToInt32(textBox9.Text);
            string a5 = textBox8.Text;
            int a6 = Convert.ToInt32(textBox7.Text);

            Videocard<int> vidyxa1 = new Videocard<int>(a1,a2,a3,a4,a5,a6);
            vidyxa1.DisplayInfo(listBox1);
        }

        
    }
}
