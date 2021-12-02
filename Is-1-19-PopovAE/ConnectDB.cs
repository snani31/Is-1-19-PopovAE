using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectDB
{
    class Connector_DB
    {
        public string stringconn_DB = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";

        public void ConnectInfo()
        {
            MessageBox.Show(stringconn_DB);
        }
    }
}
