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
    public partial class 로그인 : Form
    {
        private int SelectedRowIndex;

        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        OracleDataReader DBreader;

        DataTable loginTable;
        private int SelectedKeyValue;

        public static string ID;
        public static string PW;

        public 로그인()
        {
            InitializeComponent();
            DB_Open();
        }
        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from login";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);

                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL= TCP)(HOST = 127.0.0.1)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
            string commandString = "select * from login";
            OracleDataAdapter DBAdapter = new OracleDataAdapter(commandString, connectionString);
            DataSet DS = new DataSet();
            DBAdapter.Fill(DS, "login");

            //string id = textBox1.Text;
            //string pwd = textBox2.Text;

            //string query = @"select id, password from login where 1 = 1 and id = '#id' and password = '#pw'";

            //query = query.Replace("#id", id);
            //query = query.Replace("#pw", pwd);
            메인1 showmain1 = new 메인1();
            //showmain1.Owner = new 메인1();
            메인2 showmain2 = new 메인2();
            //showmain2.Owner = new 메인2();

            if (textBox1.Text == "admin" && textBox2.Text == "1234") // 회원 로그인
            {
                ID = textBox1.Text;
                PW = textBox2.Text;
                showmain1.ShowDialog();
            }
            else if (
                textBox1.Text == "kim" && textBox2.Text == "0000") // 직원 로그인
            {

                showmain2.ShowDialog();
            
            }

            else
            {
                MessageBox.Show("가입하지 않은 아이디이거나, 잘못된 비밀번호입니다.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); //로그인 실패
            }
            if (textBox1.Text.Length == 0) //아이디 입력 X
            {
                MessageBox.Show("아이디가 입력되지 않았습니다");
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            회원가입 showjoin = new 회원가입();
            showjoin.Show();
        }
    }
}
