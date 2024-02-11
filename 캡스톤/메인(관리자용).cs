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
    public partial class 메인1 : Form
    {
        메인2 main2;

        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        public 메인1()
        {
            InitializeComponent();
            DB_Open();
        }

        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from employee";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);

                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 showform5 = new Form5();
            showform5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //메인2 main2 = new 메인2(textBox1.Text);

            //main2.Owner = this;
            main2.Show();
            main2.plantext.Text = textBox1.Text;
            
         
           
        }

        private void 편집EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 showform3 = new Form3();
            showform3.Show();
        }

        private void 매출관리메뉴_Click(object sender, EventArgs e)
        {
            Form4 showform4 = new Form4();
            showform4.Show();
        }

        private void 근태관리메뉴_Click(object sender, EventArgs e)
        {
            Form6 showform6 = new Form6();
            showform6.Show();
        }

        private void 메인1_Load(object sender, EventArgs e)
        {
            main2 = new 캡스톤.메인2();

            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from employee";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "employee");
                dataGridView1.DataSource = DS.Tables["employee"].DefaultView;
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
                string commandString = "select * from project";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "project");
                dataGridView2.DataSource = DS.Tables["project"].DefaultView;
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
                string commandString = "select * from sales";
                OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
                DataSet DS = new DataSet();
                DBAdapter.Fill(DS, "sales");
                

                chart1.DataSource = DS.Tables[0];

                chart1.Series[0].XValueMember = "년도";
                chart1.Series[0].YValueMembers = "합계";
                chart1.Titles.Add("연도별 총 매출");
                chart1.Series[0].Color = Color.Red;
               


                chart1.Series[0].LegendText = "연 매출";
                

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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void 프로젝트관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            프로젝트_관리 gopro = new 프로젝트_관리();
            gopro.ShowDialog();
        }
    }
}
