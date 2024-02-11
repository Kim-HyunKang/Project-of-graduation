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
    public partial class Form5 : Form
    {
        private int SelectedRowIndex;

        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        DataTable planTable;
        private int SelectedKeyValue;

        public Form5()
        {
            InitializeComponent();
            DB_Open();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from plan";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);

                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        //private void CalendarBolding()
        //{
        //    DateTime[] bold = new DateTime[dataGridView1.Rows.Count];
        //int i = 0;

        //    foreach(DataRow rr in dataGridView1.Rows)
        //    {
        //        DateTime dt = (DateTime)rr["dt"];
        //bold[i++] = dt;
        //    }
        //    this.monthCalendar1.BoldedDates = bold;

        //}
    private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from plan";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "plan");
                dataGridView1.DataSource = DS.Tables["plan"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
            //CalendarBolding();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pdt = this.monthCalendar1.SelectionStart.ToString();
            string ptitle = this.textBox1.Text;
            string pmemo = this.textBox2.Text;
            string pimp = "";

            if (this.radioButton1.Checked) pimp = this.radioButton1.Text;
            else if (this.radioButton2.Checked) pimp = this.radioButton2.Text;
            else if (this.radioButton3.Checked) pimp = this.radioButton3.Text;
            else pimp = "보통";

            DS.Clear();

            DBAdapter.Fill(DS, "plan");

            DataTable plantable = DS.Tables["plan"];
            DataRow newRow = plantable.NewRow();
            newRow["pdate"] = pdt;
            newRow["ptitle"] = ptitle;
            newRow["pmemo"] = pmemo;
            newRow["pimp"] = pimp;

            plantable.Rows.Add(newRow);
            DBAdapter.Update(DS, "plan");
            DS.AcceptChanges();
            //CalendarBolding();
            dataGridView1.DataSource = DS.Tables["plan"].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.dataGridView1.CurrentCell.RowIndex;

            if (selectedIndex > -1)
            {
                this.dataGridView1.Rows.RemoveAt(selectedIndex);

                this.dataGridView1.Refresh();
            }
        }
    }
}
