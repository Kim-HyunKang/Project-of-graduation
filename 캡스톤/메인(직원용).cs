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
    public partial class 메인2 : Form
    {
        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        public 메인2()
        {
            InitializeComponent();
            
            DB_Open();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            label2.Text = System.DateTime.Now.ToString("HH:mm:ss");
        }
        


        private void 메인2_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.Titles.Add("MJ카페 프로젝트 진행도");
            chart1.Series["Series1"].Points.AddXY("업무E", 1);
            chart1.Series["Series1"].Points.AddXY("업무D", 66);
            chart1.Series["Series1"].Points.AddXY("업무C", 100);
            chart1.Series["Series1"].Points.AddXY("업무B", 100);
            chart1.Series["Series1"].Points.AddXY("업무A", 100);
            chart1.Series[0].LegendText = "진행도";
            chart1.Series[0].Color = Color.Green;
        }

        

        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from commute";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);

                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        private void 도구TToolStripMenuItem_Click(object sender, EventArgs e)
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
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label2.Text = System.DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = label2.Text;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = label2.Text;


            try
            {

                DS.Clear();

                DBAdapter.Fill(DS, "commute");

                DataTable employeetable = DS.Tables["commute"];
                DataRow newRow = employeetable.NewRow();
                newRow["직원명"] = label10.Text;
                newRow["출근시각"] = label4.Text;
                newRow["퇴근시각"] = label6.Text;


                employeetable.Rows.Add(newRow); 

                DBAdapter.Update(DS, "commute");
                DS.AcceptChanges();


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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            근태_사유 bform = new 근태_사유();
            bform.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
