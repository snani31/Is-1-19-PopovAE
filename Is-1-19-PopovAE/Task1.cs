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

        abstract class Components<T> // Родительский класс комплектующих, имеет один обобщённый тип
        {
            // поля артикула, цена и дата соответственно
            public T artikul;
            public int price;
            public int date;

            // конструктор, отвечающий за инициализацию полей класса
            public Components(T AR, int PR, int DaT)
            {
                artikul = AR;
                price = PR;
                date = DaT;
            }

            // абстрактный метод, который будет реализован только в классах наследниках (в параметры принимает какой-либо листбокс)
            abstract public void DisplayInfo(ListBox L);
            
        }

        class CPU<T> : Components<T> // Дочерний класс процессоров, наследуемый от класса комплектующих (обобщённый тип имеет тот же)
        {
            // Новые закрытые поля наследика: частота процессора, количество ядер, количество потоков соответственно
            int cpu_frequency;
            int number_Cores;
            int number_threads;
            
            /* В данном классе появились свойства, отвечающие каждое за своё поле. Они соответствуют по названию, но отличаются по 
               регистру, в данном виде от этих свойств не очень много пользы, однако это позволяет внедрять доп логику при работе с полями */
           int CPU_frequency { get { return cpu_frequency; } set { cpu_frequency = value; } }
           int Number_Cores { get { return number_Cores; } set { number_Cores = value; } }
            int Number_threads { get { return number_threads; } set { number_threads = value; } }

            // Конструкторо, отвечающий за инициализуцию полей класса, как унаследованных, так и собственных
            public CPU(T AR, int PR, int DaT, int FRE, int COR, int THR)
               : base (AR, PR, DaT) //конструкция base позволяет нам отправить унаследованные параметры в конструктор родительского класса
            {
                CPU_frequency = FRE;
                Number_Cores = COR;
                Number_threads = THR;
            }

            // Переопределённый метод родительского абстрактного класса, Он будет выводить всю необходимую информацию в указанный листбокс
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

        // Дочерний класс Видеокарт, наследуемый от класса комплектующих (обобщённый тип имеет тот же)
        class Videocard<T> : Components<T>
        {
           // Новые закрытые поля наследика: частота gpu, производитель, и объём памяти соответственно
            int gpu_frequency;
            string maker;
            int memory;

            /* В данном классе появились свойства, отвечающие каждое за своё поле. Они соответствуют по названию, но отличаются по 
            регистру, в данном виде от этих свойств не очень много пользы, однако это позволяет внедрять доп логику при работе с полями */
            public int GPU_frequency { get { return gpu_frequency; } set { gpu_frequency = value ; } } 
            public string Maker { get { return maker; } set { maker = value; } } 
            public int Memory { get { return memory; } set { memory = value; } }

            // Конструкторо, отвечающий за инициализуцию полей класса, как унаследованных, так и собственных
            public Videocard(T AR, int PR, int DaT, int FRE, string MAK, int MEM)
               : base(AR, PR, DaT)//конструкция base позволяет нам отправить унаследованные параметры в конструктор родительского класса
            {
                GPU_frequency = FRE;
                Maker = MAK;
                Memory = MEM;
            }

            // Переопределённый метод родительского абстрактного класса, Он будет выводить всю необходимую информацию в указанный листбокс
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
        //Метод нажатия кнопки, он преднозначен для инициализация экземпляра класса процессоров
        private void button1_Click(object sender, EventArgs e)
        {
            // создаются переменные для дальнейшей передачи в качестве параметров в конструктор при создании экземпляра
            int a1 = Convert.ToInt32(textBox1.Text);
            int a2 = Convert.ToInt32(textBox2.Text);
            int a3 = Convert.ToInt32(textBox3.Text);
            int a4 = Convert.ToInt32(textBox4.Text);
            int a5 = Convert.ToInt32(textBox5.Text);
            int a6 = Convert.ToInt32(textBox6.Text);
            // Создаётся инициализируется экземпляр
            CPU<int> processor = new CPU<int>(a1, a2, a3, a4, a5, a6);
            processor.DisplayInfo(listBox1); // Вызов метода класса, который будет выводить информацию об экземпляре в указанный листбокс
        }

        //Метод нажатия кнопки, он преднозначен для инициализация экземпляра класса видеокарт
        private void button2_Click(object sender, EventArgs e)
        {
            // создаются переменные для дальнейшей передачи в качестве параметров в конструктор при создании экземпляра
            int a1 = Convert.ToInt32(textBox12.Text);
            int a2 = Convert.ToInt32(textBox11.Text);
            int a3 = Convert.ToInt32(textBox10.Text);
            int a4 = Convert.ToInt32(textBox9.Text);
            string a5 = textBox8.Text;
            int a6 = Convert.ToInt32(textBox7.Text);
            // Создаётся инициализируется экземпляр
            Videocard<int> vidyxa1 = new Videocard<int>(a1,a2,a3,a4,a5,a6);
            vidyxa1.DisplayInfo(listBox1);// Вызов метода класса, который будет выводить информацию об экземпляре в указанный листбокс
        }

        
    }
}
