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
    public partial class 회원가입 : Form
    {
        private int SelectedRowIndex;

        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        OracleDataReader DBreader;

        DataTable joinTable;

        private int SelectedKeyValue;

        public 회원가입()
        {
            InitializeComponent();
            DB_Open();
        }
        private void DB_Open()
        {
            try
            {
                string connectionString = "User Id=system; Password=102017; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe)) ); ";
                string commandString = "select * from join";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                myCommandBuilder = new OracleCommandBuilder(DBAdapter);

                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DS.Clear();

                DBAdapter.Fill(DS, "join");

                DataTable joinTable = DS.Tables["join"];
                DataRow newRow = joinTable.NewRow();
                newRow["jname"] = textBox1.Text; //이름 저장
                newRow["jid"] = textBox2.Text; // 아이디 저장
                newRow["jpwd"] = textBox3.Text; // 이메일 저장


                joinTable.Rows.Add(newRow);

                DBAdapter.Update(DS, "join");
                DS.AcceptChanges();


           
            }




            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
            catch (Exception DE)
            {
                MessageBox.Show(DE.Message);
            }
            MessageBox.Show("가입이 완료되었습니다.");

        }
    }
    }

