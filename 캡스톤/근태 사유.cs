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
    public partial class 근태_사유 : Form
    {
        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        public 근태_사유()
        {
            InitializeComponent();
            DB_Open();
        }
        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from break";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);

                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from break";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "break");
                dataGridView1.DataSource = DS.Tables["break"].DefaultView;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string bdt = this.monthCalendar1.SelectionStart.ToString();
            string bname = this.textBox1.Text;
            string bmemo = this.textBox2.Text;
            string bimp = "";
            string bnow = "";

            if (this.radioButton1.Checked) bimp = this.radioButton1.Text;
            else if (this.radioButton2.Checked) bimp = this.radioButton2.Text;
            else if (this.radioButton3.Checked) bimp = this.radioButton3.Text;
            else if (this.radioButton4.Checked) bimp = this.radioButton4.Text;
            else if (this.radioButton5.Checked) bimp = this.textBox3.Text;
            else bimp = "";

            DS.Clear();

            DBAdapter.Fill(DS, "break");

            DataTable breaktable = DS.Tables["break"];
            DataRow newRow = breaktable.NewRow();
            newRow["신청일자"] = bdt;
            newRow["신청자"] = bname;
            newRow["신청유형"] = bimp;
            newRow["신청내용"] = bmemo;
            newRow["처리현황"] = bnow;

            breaktable.Rows.Add(newRow);
            DBAdapter.Update(DS, "break");
            DS.AcceptChanges();
            dataGridView1.DataSource = DS.Tables["break"].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from breakk";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "breakk");
                dataGridView1.DataSource = DS.Tables["breakk"].DefaultView;
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
