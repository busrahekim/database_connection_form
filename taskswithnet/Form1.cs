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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        private void button1_Click(object sender, EventArgs e)
        {
            String s = "select * from admin where username = @username and password = @password";
            connection = new SqlConnection("server=.; Initial Catalog=login; Integrated Security=True");
            command = new SqlCommand(s, connection);
            command.Parameters.AddWithValue("@username", textBox1.Text);
            command.Parameters.AddWithValue("@password", textBox2.Text);
            connection.Open();
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Success");
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }
    }
}
