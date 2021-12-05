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
using ConnectBD; // добавляем дополнительную библиотеку с классом из другого проекта (предварительно привязав его по ссылкам)

namespace Is_1_19_PopovAE
{
    public partial class Task4 : Form
    {
        public Task4()
        {
            InitializeComponent();
        }

        
        private void Form5_Load(object sender, EventArgs e)
        {
            //Большую часть кода реюзнул из прошлого задания

            // Создаём экземпляр класса, добавленного из другого проекта того же репозитория
            ClassConnectBD conn4 = new ClassConnectBD();
            MySqlConnection connect = new MySqlConnection(conn4.stringconn_DB);
            // Переменная содержит запрос На вывод столбцов из таблицы t_datetime
            string sql = $"SELECT idStud, fioStud, drStud FROM t_datetime";
            try
            {
                connect.Open();// Открываем соединение

                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);

                // Создаём виртуальную таблицу
                DataSet dataset = new DataSet();

                IDataAdapter.Fill(dataset);// заполняем витруальную таблицу 
                // предаём датагриду вид заполненной нами виртуальной таблицы
                dataGridView1.DataSource = dataset.Tables[0];
            }
            catch
            {
                MessageBox.Show("Чёт не так пошло, бееееее");
            }
            finally
            {
                connect.Close();// Закрываем соединение
            }
        }
        string id_rows5 = "0";

        // Данный метод будет срабатывать по нажатию кнопки мыши на датагрид
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* Это условие срботает только тогда, когда мы нажимаем на какое-либо поле, отображаемое 
            в датагриде, а так же если мы нажали на это поле левой кнопкой мыши */
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                // определяется, какая именно строка была нами нажата
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                // выбранная строка подсвечивается выделяется программой
                dataGridView1.CurrentRow.Selected = true;
                
                string index_rows5;
                // В переменную попадает уникальный индекс ячейки, которую мы выбрали нажатием
                index_rows5 = dataGridView1.SelectedCells[0].RowIndex.ToString();

                // Переменной, которую мы объявили глобально присваивается значение второй по счёту ячейки из выбранной нами строки
                id_rows5 = dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString();
                DateTime x = DateTime.Today; // Программа получает в х настоящую на данный момент дату
                DateTime y = Convert.ToDateTime(dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString());// в y попадает дата и время ячейки, полученной из таблицы
                string resultDays = (x - y).ToString(); //Тут хранится значение, которое соотвутствует прошедшим дням
                MessageBox.Show("Со дня рождения прошло " + resultDays.Substring(0, resultDays.Length - 9) + " дней"); //Тут это значение приводится в презентабельный вид и выводится пользователю
            }
        }
    }
}
