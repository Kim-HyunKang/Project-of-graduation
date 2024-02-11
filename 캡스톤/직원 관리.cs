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
    public partial class Form3 : Form
    {
        private int SelectedRowIndex;

        OracleDataAdapter DBAdapter;

        DataSet DS;

        OracleCommandBuilder myCommandBuilder;

        DataTable employeeTable;
        private int SelectedKeyValue;

        public Form3()
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
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    DS.Clear();
            //    DBAdapter.Fill(DS, "employee");



            //    DataRow currRow = employeeTable.Rows.Find(SelectedRowIndex);

            //    currRow.BeginEdit();
            //    currRow["enum"] = Convert.ToInt32(textBox3.Text);
            //    currRow["ename"] = textBox4.Text;
            //    currRow["errn"] = textBox5.Text;
            //    currRow["esex"] = textBox14.Text;
            //    currRow["epnum"] = textBox6.Text;
            //    currRow["email"] = textBox7.Text;
            //    currRow["eadd"] = Convert.ToString(textBox8.Text);
            //    currRow["eteam"] = textBox9.Text;
            //    currRow["erank"] = textBox10.Text;
            //    currRow["ejoind"] = textBox11.Text;
            //    currRow["eleavd"] = textBox12.Text;
            //    currRow["ework"] = textBox13.Text;
            //    currRow.EndEdit();

            //    DataSet UpdatedSet = DS.GetChanges(DataRowState.Modified); //테이블 내 변경점 호출

            //    if (UpdatedSet.HasErrors)
            //    { MessageBox.Show("변경된 데이터에 문제가 있습니다."); }
            //    else
            //    { DBAdapter.Update(UpdatedSet, "employee"); DS.AcceptChanges(); }
            //    dataGridView1.DataSource = DS.Tables["employee"].DefaultView;
            //}
            //catch (DataException DE)
            //{ MessageBox.Show(DE.Message); }
            //catch (Exception DE)
            //{ MessageBox.Show(DE.Message); }
            string eenum = this.textBox3.Text;
            string eename = this.textBox4.Text;
            string eerrn = this.textBox5.Text;
            string eesex = this.textBox14.Text;
            string eepnum = this.textBox6.Text;
            string eemail = this.textBox7.Text;
            string eeadd = this.textBox8.Text;
            string eeteam = this.textBox9.Text;
            string eerank = this.textBox10.Text;
            string eejoind = this.textBox11.Text;
            string eeleavd = this.textBox12.Text;
            string eework = this.textBox13.Text;



            DS.Clear();

            DBAdapter.Fill(DS, "employee");

            DataTable breakktable = DS.Tables["employee"];
            DataRow newRow = breakktable.NewRow();
            newRow[0] = eenum;
            newRow[1] = eename;
            newRow[2] = eerrn;
            newRow[3] = eesex;
            newRow[4] = eepnum;
            newRow[5] = eemail;
            newRow[6] = eeadd;
            newRow[7] = eeteam;
            newRow[8] = eerank;
            newRow[9] = eejoind;
            newRow[10] = eeleavd;
            newRow[11] = eework;


            breakktable.Rows.Add(newRow);
            DBAdapter.Update(DS, "employee");
            DS.AcceptChanges();
            dataGridView1.DataSource = DS.Tables["employee"].DefaultView;

            int selectedIndex = this.dataGridView1.CurrentCell.RowIndex;

            if (selectedIndex > -1)
            {
                this.dataGridView1.Rows.RemoveAt(selectedIndex);

                this.dataGridView1.Refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                DS.Clear();

                DBAdapter.Fill(DS, "employee");

                DataTable employeetable = DS.Tables["employee"];
                DataRow newRow = employeetable.NewRow();
                newRow["enum"] = Convert.ToInt32(textBox3.Text);
                newRow["ename"] = textBox4.Text;
                newRow["errn"] = textBox5.Text;
                newRow["esex"] = textBox14.Text;
                newRow["epnum"] = textBox6.Text;
                newRow["email"] = textBox7.Text;
                newRow["eadd"] = Convert.ToString(textBox8.Text);
                newRow["eteam"] = textBox9.Text;
                newRow["erank"] = textBox10.Text;
                newRow["ejoind"] = textBox11.Text;
                newRow["eleavd"] = textBox12.Text;
                newRow["ework"] = textBox13.Text;

                employeetable.Rows.Add(newRow); //해당 셀 추가

                DBAdapter.Update(DS, "employee");
                DS.AcceptChanges();
                

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
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            //    try
            //    {

            //        DS.Clear();
            //        DBAdapter.Fill(DS, "employee");

            //        employeeTable = DS.Tables["employee"];
            //        DataColumn[] PrimaryKey = new DataColumn[1];
            //        PrimaryKey[0] = employeeTable.Columns["enum"];
            //        employeeTable.PrimaryKey = PrimaryKey;

            //        DataRow currRow = employeeTable.Rows.Find(SelectedRowIndex);
            //        currRow.Delete(); //해당 셀 삭제

            //        DBAdapter.Update(DS.GetChanges(DataRowState.Deleted), "employee");
            //        dataGridView1.DataSource = DS.Tables["employee"].DefaultView;
            //    }
            //    catch (DataException DE)
            //    {
            //        MessageBox.Show(DE.Message);
            //    }
            //    catch (Exception DE)
            //    {
            //        MessageBox.Show(DE.Message);
            //    }
            int selectedIndex = this.dataGridView1.CurrentCell.RowIndex;

            if (selectedIndex > -1)
            {
                this.dataGridView1.Rows.RemoveAt(selectedIndex);

                this.dataGridView1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

           
            
        }
    }
}
