using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace CollegeSystem
{
    public partial class Professor : Form
    {
        MySqlConnection connection;
        public Professor()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Professor_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "server=localhost;database=materialregistration;uid=root;pwd=";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from course where prof_id= " + Convert.ToInt32(Form1.str) + ";", connection);
            DataTable dataSet = new DataTable();
            mySqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
