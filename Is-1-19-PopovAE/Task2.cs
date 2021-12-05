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

namespace Is_1_19_PopovAE
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }
        // Создаётся обычный класс внутри кода формы, который содержет в себе поле и метод
        class Connector
        {
            // данное поле содержет в себе строку подключения 
            public string stringconn = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";

            // Данный метод преднозначен для вывода информации о строке подключения
            public void ConnectInfo()
            {
                MessageBox.Show(stringconn);
            }
        }

        // Метод нажатия кнопки, он нужен для того, чтобы открыть соединение с бд
        private void button1_Click(object sender, EventArgs e)
        {
            // создаём экземпляр класса, который мы описали выше
            Connector con = new Connector();

            // Создаём экземпляр класса MySqlConnection, что позволит нам открыть соединение, если в параметрах мы укажем строку подключения
            MySqlConnection conn = new MySqlConnection(con.stringconn); // строка подключения берётся из экземпляра класса  
            bool result = true; // переменная отвечает за исход операции открытия соединения 
            try
            {
                conn.Open();// Метод, который создаёт соединение с бд
            }
            catch
            {
                result = false; 
            }
            finally
            {
                if (result == true)
                {// Если соединение открылось, что нас ожидает данный исход
                    MessageBox.Show("Всё работает и вообще круто");
                }
                else
                {// Если при попытке открыть соединение что-то пошло не так, то программа оповестит нас, что соединение открыть не удалось
                    MessageBox.Show("Ну не работает блин");
                }
                conn.Close(); // соединение закроется в любом случае
            }
        }
    }
}
