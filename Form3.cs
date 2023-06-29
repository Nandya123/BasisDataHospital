using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        private Form form1;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var builder = new MySqlConnector.MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "hospital (2)",
            };
            var mySqlConnection = new MySqlConnector.MySqlConnection(builder.ConnectionString);
             var con = mySqlConnection;
            con.Open();
             var command = new MySqlConnector.MySqlCommand("SELECT * FROM doctor_type;", con);
             var reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(1));
            }
            con.Close();
            con.Open();
            MySqlConnector.MySqlCommand dataCommand = new MySqlConnector.MySqlCommand("SELECT * FROM daftar_dokter", con);
            MySqlConnector.MySqlDataReader dataReader = dataCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            dataGridView1.DataSource = dataTable;
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
