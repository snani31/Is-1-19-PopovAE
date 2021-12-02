using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDB;
using MySql.Data.MySqlClient;

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
            Connector_DB conn4 = new Connector_DB();
            MySqlConnection connect = new MySqlConnection(conn4.stringconn_DB); // создаём соединение
            string fioStud = textBox2.Text; // заполняем поле фиостуд(ента)
            string dateitimeStud = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") ; // Да, всё оказалось настолько просто (Это актуальная дата со временем в формате MySql DateTime)
            MessageBox.Show(dateitimeStud);
            string dateitimeStudFinal = textBox1.Text == "" ? dateitimeStud : textBox1.Text; // случайно добавил автоматическое заполнение нужного поля сегодняшней датой вместо текстбокса, как нужно по заданию, теперь жалко удалять ). Пусть будет как мера предосторожности
            string sql = $"INSERT INTO t_PraktStud (fioStud, datetimeStud)  VALUES ('{fioStud}','{dateitimeStudFinal}');";
            int counter = 0;
            try
            { connect.Open();

                MySqlCommand command1 = new MySqlCommand(sql, connect);
                counter = command1.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Не получилось, накодил себе полные штаны");
            }
            finally
            {
                connect.Close();

                if (counter != 0)
                {
                    MessageBox.Show("Всё отлично, данные добавлены в базу");
                }
            }
        }
    }
}
