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
    public partial class 프로젝트_추가 : Form
    {
        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        public 프로젝트_추가()
        {
            InitializeComponent();
            DB_Open();
        }

        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from project";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);

                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void 프로젝트_추가_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from project";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "project");
                dataGridView1.DataSource = DS.Tables["project"].DefaultView;
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

        private void button2_Click(object sender, EventArgs e)
        {
            string proname = this.textBox1.Text;
            string procon = this.textBox2.Text;
            string prodt = this.dateTimePicker1.Text + "~" ;
            string proemp = this.textBox3.Text;
            string protp = this.comboBox1.Text;
           
            DS.Clear();

            DBAdapter.Fill(DS, "project");

            DataTable breakktable = DS.Tables["project"];
            DataRow newRow = breakktable.NewRow();
            newRow[0] = proname;
            newRow[1] = procon;
            newRow[2] = prodt;
            newRow[3] = proemp;
            newRow[4] = protp;

            breakktable.Rows.Add(newRow);
            DBAdapter.Update(DS, "project");
            DS.AcceptChanges();
            dataGridView1.DataSource = DS.Tables["project"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 searchemp = new Form3();
            searchemp.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (comboBox1.SelectedItem.ToString() == "서비스형")
            {
                checkBox8.Enabled = false;
                checkBox9.Enabled = false;
            }
           else if (comboBox1.SelectedItem.ToString() == "시장진입형")
            {
                checkBox8.Enabled = true;
                checkBox9.Enabled = true;
            }
        }
    }
}
