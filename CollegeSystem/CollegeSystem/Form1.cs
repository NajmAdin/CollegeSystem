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
    public partial class Form1 : Form
    {

        public static MySqlConnection connection;
        public static MySqlCommand command;
        MySqlDataReader reader;
        public static string str;
        public static string name;
        
        Boolean adminStat = false;
        Boolean profStat = false;
        Boolean StudentStat = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            connection = new MySqlConnection();
            command = new MySqlCommand();
            command.Connection = connection;
            // reader = new MySqlDataReader();
            connection.ConnectionString = "server=localhost;database=materialregistration;uid=root;pwd=;";
            try
            {
                connection.Open();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("هناك خطا في الاتصال");
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            if (uname.Length == 0)
            {
                MessageBox.Show("Plass Enter User Name");
                return;
            }
            string Password = textBox2.Text;
            if (Password.Length == 0)
            {
                MessageBox.Show("Plass Enter User Password");
                return;
            }
            if (StudentStat == false && adminStat == false && profStat == false)
            {
                MessageBox.Show("Plass choes your State");
                return;
            }
           

            MySqlDataAdapter sda = new MySqlDataAdapter("select count(*) from Users where email='" + textBox1.Text + "'and pasword='" + textBox2.Text + "'", connection);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                
                MySqlDataAdapter sdd = new MySqlDataAdapter("select * from Users where email='" + textBox1.Text + "'and pasword='" + textBox2.Text + "'", connection);
                DataTable dtt = new DataTable();
                sdd.Fill(dtt);
               
                str = dtt.Rows[0][0].ToString();
                name = dtt.Rows[0][1].ToString();
                MessageBox.Show(adminStat.ToString() + " " + StudentStat.ToString() + " " + profStat.ToString());
                if (adminStat == true)
                {
                    
                    MySqlDataAdapter admin = new MySqlDataAdapter("select count(*) from admin where admin_id='" + str +"'" , connection);
                    DataTable t1 = new DataTable();

                    admin.Fill(t1);
                    if (t1.Rows[0][0].ToString() == "0")
                        MessageBox.Show("you are not an admin");
                    else
                    {
                        Admin AD = new Admin();
                        this.Visible = false;
                        AD.Visible = true;
                    }
                }
                
                   
                else if (StudentStat == true)
                {
                    MySqlDataAdapter stude = new MySqlDataAdapter("select count(*) from student where student_id='" + str +  "'", connection);
                    DataTable t2 = new DataTable();

                    stude.Fill(t2);
                    if (t2.Rows[0][0].ToString() == "0")
                        MessageBox.Show("you are not an Student");
                    else
                    {
                        Sutent stu = new Sutent();
                        this.Visible = false;
                        stu.Visible = true;
                    }    
                }
                    
                else if (profStat == true)
                {
                    MySqlDataAdapter prof = new MySqlDataAdapter("select count(*) from professor where prfessor_id='" + str + "'", connection);
                    DataTable t3 = new DataTable();

                    prof.Fill(t3);
                    if (t3.Rows[0][0].ToString() == "0")
                        MessageBox.Show("you are not an prof");
                    else {
                        Professor profi = new Professor();
                        this.Visible = false;
                        profi.Visible = true;
                    }
                }
                    

            }
            else
            {
                MessageBox.Show("incorrect usrename and password", "alter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            adminStat = !adminStat;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            StudentStat = !StudentStat;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            profStat = !profStat;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

