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
    public partial class Task4 : Form
    {
        public Task4()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //Большую часть кода реюзнул из прошлого задания
            Connector_DB conn4 = new Connector_DB();
            MySqlConnection connect = new MySqlConnection(conn4.stringconn_DB);
            string sql = $"SELECT idStud, fioStud, drStud FROM t_datetime";
            try
            {
                connect.Open();

                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);

                DataSet dataset = new DataSet();

                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            catch
            {
                MessageBox.Show("Чёт не так пошло, бееееее");
            }
            finally
            {
                connect.Close();
            }
        }
        string id_rows5 = "0";
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];

                dataGridView1.CurrentRow.Selected = true;

                string index_rows5;

                index_rows5 = dataGridView1.SelectedCells[0].RowIndex.ToString();

                id_rows5 = dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString();
                DateTime x = DateTime.Today;
                DateTime y = Convert.ToDateTime(dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString());
                string resultDays = (x - y).ToString(); //Тут хранится значение, которое соотвутствует прошедшим дням
                MessageBox.Show("Со дня рождения прошло " + resultDays.Substring(0, resultDays.Length - 9) + " дней"); //Тут это значение приводится в презентабельный вид и выводится пользователю
            }
        }
    }
}
