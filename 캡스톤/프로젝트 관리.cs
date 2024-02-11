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
    public partial class 프로젝트_관리 : Form
    {
        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        public 프로젝트_관리()
        {
            InitializeComponent();
            DB_Open();
        }

        int cnt1 = 0;
        int cnt2 = 0;
        int cnt3 = 0;
        int cnt4 = 0;
        int cnt5 = 0;

        
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void 일정관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 goplan = new Form5();
            goplan.ShowDialog();
        }

        private void 직원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 goemp = new Form3();
            goemp.ShowDialog();
        }

        private void 매출관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 gosales = new Form4();
            gosales.ShowDialog();
        }

        private void 근태관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 gocmt = new Form6();
            gocmt.ShowDialog();
        }

        private void 진행중인프로젝트ToolStripMenuItem_Click(object sender, EventArgs e)
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

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void 과거프로젝트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from projectt";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "projectt");
                dataGridView1.DataSource = DS.Tables["projectt"].DefaultView;
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            

            if (textBox1.Text == "MJ카페")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox8.Enabled = true;
                checkBox9.Enabled = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;
                checkBox10.Checked = true;
                checkBox11.Checked = true;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
            }
            else if (textBox1.Text == "MJ하우징")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox8.Enabled = false;
                checkBox9.Enabled = false;
                checkBox10.Checked = true;
                checkBox11.Checked = true;
                checkBox12.Checked = true;
                checkBox13.Checked = true;
                checkBox14.Checked = true;

            }
            else if (textBox1.Text == "MJ25")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox8.Enabled = true;
                checkBox9.Enabled = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
            }
            else if (textBox1.Text == "MJ미디어")
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox8.Enabled = false;
                checkBox9.Enabled = false;
                checkBox10.Checked = true;
                checkBox11.Checked = true;
                checkBox12.Checked = true;
                checkBox13.Checked = true;
                checkBox14.Checked = true;

            }
            else if (checkBox8.Enabled == false)
            {
                checkBox8.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked = true)
            {

                cnt1 = 33;
                progressBar1.Value = cnt1;              
            }
            else
            {
                cnt1 = 0;
                progressBar1.Value = cnt1;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked = true)
            {
                cnt1 = 66;
                progressBar1.Value = cnt1;
            }
            else
            {
                cnt1 = 0;
                progressBar1.Value = cnt1;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked = true)
            {
                cnt1 = 100;
                progressBar1.Value = cnt1;
            }
            else
            {
                cnt1 = 0;
                progressBar1.Value = cnt1;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked = true)
            {
                cnt2 = 33;
                progressBar2.Value = cnt2;
            }
            else
            {
                cnt2 = 0;
                progressBar2.Value = cnt2;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked = true)
            {
                cnt2 = 66;
                progressBar2.Value = cnt2;
            }
            else
            {
                cnt2 = 0;
                progressBar2.Value = cnt2;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked = true)
            {
                cnt2 = 100;
                progressBar2.Value = cnt2;
            }
            else
            {
                cnt2 = 0;
                progressBar2.Value = cnt2;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked = true)
            {
                cnt3 = 50;
                progressBar3.Value = cnt3;
            }
            else
            {
                cnt3 = 0;
                progressBar3.Value = cnt3;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked = true)
            {
                cnt3 = 100;
                progressBar3.Value = cnt3;
            }
            else
            {
                cnt3 = 0;
                progressBar3.Value = cnt3;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked = true)
            {
                cnt4 = 33;
                progressBar4.Value = cnt4;
            }
            else
            {
                cnt4 = 0;
                progressBar4.Value = cnt4;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked = true)
            {
                cnt4 = 66;
                progressBar4.Value = cnt4;
            }
            else
            {
                cnt4 = 0;
                progressBar4.Value = cnt4;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked = true)
            {
                cnt4 = 100;
                progressBar4.Value = cnt4;
            }
            else
            {
                cnt4 = 0;
                progressBar4.Value = cnt4;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked = true)
            {
                cnt5 = 50;
                progressBar5.Value = cnt5;
            }
            else
            {
                cnt5 = 0;
                progressBar5.Value = cnt5;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked = true)
            {
                cnt5 = 100;
                progressBar5.Value = cnt5;
            }
            else
            {
                cnt5 = 0;
                progressBar5.Value = cnt5;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            프로젝트_추가 gopplus = new 프로젝트_추가();
            gopplus.ShowDialog();
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
