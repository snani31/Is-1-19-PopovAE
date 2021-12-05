using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ConnectBD;

namespace Is_1_19_PopovAE
{
    public partial class Task5 : Form
    {
        public Task5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаём экземпляр класса из библиотеки, привязанной по ссылке из другого проекта 
            ClassConnectBD conn4 = new ClassConnectBD();
            MySqlConnection connect = new MySqlConnection(conn4.stringconn_DB); // создаём соединение
            string fioStud = textBox2.Text; // заполняем поле фиостуд(ента)
            string dateitimeStud = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") ; // Да, всё оказалось настолько просто (Это актуальная дата со временем в формате MySql DateTime)
            MessageBox.Show(dateitimeStud);
            string dateitimeStudFinal = textBox1.Text == "" ? dateitimeStud : textBox1.Text; // случайно добавил автоматическое заполнение нужного поля сегодняшней датой вместо текстбокса, как нужно по заданию, теперь жалко удалять ). Пусть будет как мера предосторожности(Данный код написан Поповым Артёмом(ловушка для воров с гитхаб))
            string sql = $"INSERT INTO t_PraktStud (fioStud, datetimeStud)  VALUES ('{fioStud}','{dateitimeStudFinal}');";
            int counter = 0;
            try
            { // пробуем открыть одключение 
                connect.Open();

                // создаём экземпляр MySqlComman, который позволит нам  выполнить команду по извменению базы даннных
                MySqlCommand command1 = new MySqlCommand(sql, connect);
                // Данный метод позволяет нам выполнить указанную выше команду, но команда не должна возвращать никаких данных, а только работать  тем, что уже есть, команда Insert подходит под определение
                counter = command1.ExecuteNonQuery();// В переменной counter будет храниться колличество выполненных изменений

            }
            catch
            {
                MessageBox.Show("Не получилось, накодил себе полные штаны");
            }
            finally
            {
                connect.Close();// соединение закроется в любом случае

                if (counter != 0) // Если counter больше 0, то что-то мы точно добавили в базу, а значит, что изменения успешно применились 
                {
                    MessageBox.Show("Всё отлично, данные добавлены в базу");
                }
            }
        }
    }
}
