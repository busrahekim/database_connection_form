using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace taskswithnet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("server=.; Initial Catalog=login; Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            String s = "insert into users(no,name,surname,city) values(@no,@name,@surname,@city)";
            SqlCommand add = new SqlCommand(s, connection);
            add.Parameters.AddWithValue("@no", textBox1.Text);
            add.Parameters.AddWithValue("@name", textBox3.Text);
            add.Parameters.AddWithValue("@surname", textBox2.Text);
            add.Parameters.AddWithValue("@city", textBox4.Text);
            connection.Open();
            add.ExecuteNonQuery();
            connection.Close();
            getData();
        }

        private void getData()
        {
            connection.Open();
            String s = "select * from users ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(s, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            String s = "delete from users where no=@no ";
            SqlCommand del = new SqlCommand(s, connection);
            del.Parameters.AddWithValue("@no", textBox1.Text);
            del.ExecuteNonQuery();
            connection.Close();
            getData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            String s = "update users set no=@no, name=@name, surname=@surname,city=@city where no=@no ";
            SqlCommand upd = new SqlCommand(s, connection);
            upd.Parameters.AddWithValue("@no", textBox1.Text);
            upd.Parameters.AddWithValue("@name", textBox3.Text);
            upd.Parameters.AddWithValue("@surname", textBox2.Text);
            upd.Parameters.AddWithValue("@city", textBox4.Text);
            upd.ExecuteNonQuery();
            connection.Close();
            getData();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String tmp = textBox5.Text;

            connection.Open();
            String s = "select name from users where name like '" + tmp +"%'";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(s, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }
    }
}
