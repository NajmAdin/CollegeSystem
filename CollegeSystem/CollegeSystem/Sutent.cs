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
    public partial class Sutent : Form
    {
        List<string> SlectedCourse = new List<string>();
        List<(int,string)> cours = new List<(int,string)>();
        public static MySqlConnection connection;
        public static MySqlCommand command;

        public Sutent()
        {
            InitializeComponent();
        }

        private void Sutent_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection();
            command = new MySqlCommand();
            command.Connection = connection;
            // reader = new MySqlDataReader();
            connection.ConnectionString = "server=localhost;database=materialregistration;uid=root;pwd=;";
            connection.Open();
            panel4.Visible = true;
            panel5.Visible = false;
            name.Text = Form1.name;

            fillcourse();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Regster_Click(object sender, EventArgs e)
        {
            CurentPlan.Text = "Rgster";
            panel4.Visible = true;
            panel5.Visible = false;
        }

        private void Record_Click(object sender, EventArgs e)
        {
            CurentPlan.Text = "Record";
            panel4.Visible = false;
            panel5.Visible = true;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from stud_course where id_student= " + Convert.ToInt32( Form1.str)+";" , connection) ;


            DataTable dataSet = new DataTable();
            mySqlDataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;

            //SqlCommand cmd = new SqlCommand("select * from student", con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select coures id in data base from combox(try)
            SlectedCourse.Add(comboBox1.Text);
            listView1.Items.Add(comboBox1.Text);
            comboBox1.Items.Remove(comboBox1.Text);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            comboBox1.Items.Clear();
            int x = cours.Count();

            for(int i=0;i<x;i++)
            {
                comboBox1.Items.Add(cours[i].Item2);
            }
            SlectedCourse.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SlectedCourse.Count; i++)
            {
                int c_id = 0;
                for(int j = 0; j < cours.Count; j++) {
                    if (cours[j].Item2 == SlectedCourse[i])
                    {
                        c_id = cours[j].Item1;
                        break;
                    }
                }
                
              command.CommandText = "call Insert_student_course (" +c_id.ToString()+" ,"+Form1.str +");";
              command.ExecuteNonQuery();
            }
            listView1.Clear();
            SlectedCourse.Clear();
        }
        private void fillcourse()
        {
            int CourseCount = 0;
            MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from course; ", Form1.connection);
            MySqlDataAdapter sda1 = new MySqlDataAdapter("select course_id,name from course ; ", Form1.connection);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            sda.Fill(dt);
            sda1.Fill(dt1);
            CourseCount = Convert.ToInt32(dt.Rows[0][0].ToString());

            for (int i = 0; i < CourseCount; i++)
            {
                cours.Add((Convert.ToInt32(dt1.Rows[i][0].ToString()), dt1.Rows[i][1].ToString()));
                comboBox1.Items.Add(cours[i].Item2);
            }
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
