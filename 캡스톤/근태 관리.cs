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
    public partial class Form6 : Form
    {
        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        public Form6()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Enabled = true;
            label7.Text = System.DateTime.Now.ToString("HH:mm:ss");

            DB_Open();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = System.DateTime.Now.ToString("HH:mm:ss");
        }

        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from breakk";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);

                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from commute";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "commute");
                dataGridView1.DataSource = DS.Tables["commute"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }

            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from break";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "break");
                dataGridView2.DataSource = DS.Tables["break"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }

            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from breakk";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "breakk");
                dataGridView3.DataSource = DS.Tables["breakk"].DefaultView;
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
            
            string bkdt = this.monthCalendar1.SelectionStart.ToString();
            string bkname = this.textBox2.Text;
            string bkmemo = this.textBox4.Text;
            string bkimp = this.textBox3.Text;
            string bknow = this.button2.Text;
            string bkwhy = this.textBox5.Text;

           
            DS.Clear();

            DBAdapter.Fill(DS, "breakk");

            DataTable breakktable = DS.Tables["breakk"];
            DataRow newRow = breakktable.NewRow();
            newRow[0] = bkdt;
            newRow[1] = bkname;
            newRow[2] = bkimp;
            newRow[3] = bkmemo;
            newRow[4] = bknow;
            newRow[5] = bkwhy;

            breakktable.Rows.Add(newRow);
            DBAdapter.Update(DS, "breakk");
            DS.AcceptChanges();
            dataGridView3.DataSource = DS.Tables["breakk"].DefaultView;

            int selectedIndex = this.dataGridView2.CurrentCell.RowIndex;

            if (selectedIndex > -1)
            {
                this.dataGridView2.Rows.RemoveAt(selectedIndex);

                this.dataGridView2.Refresh();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string bkdt = this.monthCalendar1.SelectionStart.ToString();
            string bkname = this.textBox2.Text;
            string bkmemo = this.textBox4.Text;
            string bkimp = this.textBox3.Text;
            string bknow = this.button3.Text;
            string bkwhy = this.textBox5.Text;


            DS.Clear();

            DBAdapter.Fill(DS, "breakk");

            DataTable breakktable = DS.Tables["breakk"];
            DataRow newRow = breakktable.NewRow();
            newRow[0] = bkdt;
            newRow[1] = bkname;
            newRow[2] = bkimp;
            newRow[3] = bkmemo;
            newRow[4] = bknow;
            newRow[5] = bkwhy;

            breakktable.Rows.Add(newRow);
            DBAdapter.Update(DS, "breakk");
            DS.AcceptChanges();
            dataGridView3.DataSource = DS.Tables["breakk"].DefaultView;

            int selectedIndex = this.dataGridView2.CurrentCell.RowIndex;

            if (selectedIndex > -1)
            {
                this.dataGridView2.Rows.RemoveAt(selectedIndex);

                this.dataGridView2.Refresh();
            }
        }
    }
}
