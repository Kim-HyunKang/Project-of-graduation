using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace 캡스톤
{
    public partial class Form4 : Form
    {
        private int SelectedRowIndex;

        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        DataTable salesTable;

        OracleDataReader reader;

        private int SelectedKeyValue;

        public Form4()
        {
            InitializeComponent();
            DB_Open();
        }

        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from sales";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);
                
                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from sales";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "sales");
                dataGridView1.DataSource = DS.Tables["sales"].DefaultView;

                chart1.DataSource = DS.Tables[0];

                chart1.Series[0].XValueMember = "년도";
                chart1.Series[0].YValueMembers = "사업1";              
                chart1.Series[1].YValueMembers = "사업2";           
                chart1.Series[2].YValueMembers = "사업3";


                chart1.Series[0].LegendText = "사업1";
                chart1.Series[1].LegendText = "사업2";
                chart1.Series[2].LegendText = "사업3";

                chart1.DataBind();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }


        }
    }
}
