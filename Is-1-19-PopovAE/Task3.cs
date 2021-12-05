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
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }

        // метод загрузки формы
        private void Form4_Load(object sender, EventArgs e)
        {
            // создаём экземпляр класса, который находится в Program.cs
            ConnectorPcs conn = new ConnectorPcs();
            // Создаём и инициализируем соединение с бд со строкой соединения из экземпляра conn
            MySqlConnection connect = new MySqlConnection(conn.stringconn);
            // Переменная содержит запрос SQL на вывод информации из таблицы t_stud
            string sql = $"SELECT id, fio, theme_kurs FROM t_stud";
            try
            {
                connect.Open();// пробуем открыть соеднинение 

                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);

                DataSet dataset = new DataSet(); // Создаём виртуальную таблицу

                IDataAdapter.Fill(dataset); // заполняем витруальную таблицу 
                // предаём датагриду вид заполненной нами виртуальной таблицы
                dataGridView1.DataSource = dataset.Tables[0]; 
            }
            catch
            {
                // если возниклас ошибка
                MessageBox.Show("Чёт не так пошло, бееееее");
            }
            finally
            {
                // закрываем соединение
                connect.Close();
            }
            
        }
        string id_rows = "0";

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

                string index_rows;

                // В переменную попадает уникальный индекс ячейки, которую мы выбрали нажатием
                index_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();

                // Переменной, которую мы объявили глобально присваивается значение второй по счёту ячейки из выбранной нами строки
                id_rows = dataGridView1.Rows[Convert.ToInt32(index_rows)].Cells[1].Value.ToString();
                MessageBox.Show(id_rows);
            }
        }
    }
}
