using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Я подключил библиотеку Windows.Forms, чтобы иметь возможность выводить информацию из кода этого класса в меседж бокс

namespace ConnectBD
{
    public class ClassConnectBD
    {
        public string stringconn_DB = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";

        public void ConnectInfo()
        {
            MessageBox.Show(stringconn_DB);
        }
    }
}
