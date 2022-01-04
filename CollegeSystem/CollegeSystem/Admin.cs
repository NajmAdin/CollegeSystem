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
    public partial class Admin : Form
    {
        MySqlConnection connection;
        MySqlCommand command;
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            
            comboBox3.Text = "Student";
            comboBox1.Text = "ID";
            comboBox2.Text = "ID";
            connection = new MySqlConnection();
            connection.ConnectionString = "server=localhost;database=materialregistration;uid=root;pwd=;";
            connection.Open();
            command = new MySqlCommand();
            command.Connection = connection;

            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String s;
            s=textBox1.Text;
            
            
                if (comboBox1.Text == "ID")
                {

                   
                     MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from users where user_id=" + Convert.ToInt32(s)+"; ", connection);
                      DataTable dataSet = new DataTable();
                     mySqlDataAdapter.Fill(dataSet);
                    dataGridView1.DataSource = dataSet;
                  }
                else
                {
                        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from users where name='" + s + "';", connection);
                     DataTable dataSet = new DataTable();
                      mySqlDataAdapter.Fill(dataSet);
                     dataGridView1.DataSource = dataSet;
                  }
                




            
        }

        private void SearchProfessor_Click(object sender, EventArgs e)
        {
            CurentPlan.Text = ("Search Users");
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void SearchStudent_Click(object sender, EventArgs e)
        {
            CurentPlan.Text = ("Search Student");
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String s;
            s = textBox2.Text;


            if (comboBox2.Text == "ID")
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from users where user_id=" + Convert.ToInt32(s) + "; ", connection);
                DataTable dataSet = new DataTable();
                mySqlDataAdapter.Fill(dataSet);
                dataGridView2.DataSource = dataSet;
            }
            else
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from users where name='" + s + "';", connection);
                DataTable dataSet = new DataTable();
                mySqlDataAdapter.Fill(dataSet);
                dataGridView2.DataSource = dataSet;
            }

        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            CurentPlan.Text = ("Add User");
            panel6.Visible = true;
            panel5.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false; 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Admin")
            {
                comboBox4.Visible = false;
                label10.Visible = false;
            }
            else
            {
                comboBox4.Visible = true;
                label10.Visible =true;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UNA.Text == "" || PHA.Text == "" || ADA.Text == "" || EMA.Text == "" || PSA.Text == "")
            {
                MessageBox.Show("please fill all fields");
            }
            else
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select count(*) from users where email='" + EMA.Text + "'; ", connection);
                DataTable dataSet = new DataTable();
                mySqlDataAdapter.Fill(dataSet);
                int mail = Convert.ToInt32(dataSet.Rows[0][0].ToString());

                if (mail == 1)
                {

                    MessageBox.Show("Email is taken");
                }
                else
                {

                    /*Admin
                    Student
                    Professor*/
                    if (comboBox3.Text == "Admin")
                    {
                        //call Insert_from_admin ("Hesham abd el monsef","010105592","colfvscs","eslam@gmail.com","najm");
                        command.CommandText = "call Insert_from_admin ('" + UNA.Text + "','" + PHA.Text + "','" + ADA.Text + "','" + EMA.Text + "','" + PSA.Text + "');";
                        Exc();
                    }
                    else
                    {
                        if (comboBox4.Text == "")
                        {
                            MessageBox.Show("Please choose Department");
                        }
                        else
                        {
                            if (comboBox3.Text == "Student")
                            {
                                /*call Insert_from_Student (5,"Hesham abd el monsef","010105592","colfvscs","Hesham33@gmail.com","najm");*/
                                command.CommandText = "call Insert_from_Student (" + comboBox4.SelectedIndex + ",'" + UNA.Text + "','" + PHA.Text + "','" + ADA.Text + "','" + EMA.Text + "','" + PSA.Text + "');";
                                Exc();
                            }
                            else
                            {
                                /*call insert_into_Prof (5,"Hesham abd el monsef","010105592","colfvscs","Hesham388@gmail.com","najm");*/
                                command.CommandText = "call insert_into_Prof (" + comboBox4.SelectedIndex + ",'" + UNA.Text + "','" + PHA.Text + "','" + ADA.Text + "','" + EMA.Text + "','" + PSA.Text + "');";
                                Exc();
                            }
                        }
                    }
                    void Exc()
                    {
                        command.ExecuteNonQuery();
                        UNA.Clear();
                        PHA.Clear();
                        ADA.Clear();
                        EMA.Clear();
                        PSA.Clear();
                        MessageBox.Show("Done");

                    }

                }
            }

        }

        private void UpdateUser_Click(object sender, EventArgs e)
        {

            CurentPlan.Text = ("Update User");
            panel7.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel4.Visible = false;
            panel8.Visible = false;
        }

        private void DeletUser_Click(object sender, EventArgs e)
        {

            CurentPlan.Text = ("Delete User");
            panel8.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
           // panel9.Visible = false;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            //Update_from_Users (idd int,new_name varchar(100),new_phone varchar(11),new_address varchar (100),new_Email varchar(100),password varchar(10))
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("please fill all fields");
            }
            else
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select count(*) from users where email='" + textBox4.Text + "'; ", connection);
                DataTable dataSet = new DataTable();
                mySqlDataAdapter.Fill(dataSet);
                int mail = Convert.ToInt32(dataSet.Rows[0][0].ToString());

                if (mail != 1)
                {

                    MessageBox.Show("user not in system add him by 'Add User'");
                }
                else
                {


                    //#call Update_from_Users("hesham abd el monsef","110105592","colfvscs","hesham@gmail.com","Najm");//
                    command.CommandText = "call Update_from_Users('" + textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox3.Text + "');";




                    command.ExecuteNonQuery();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    MessageBox.Show("Done");

                }


            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //textBox8.Text;
            if (textBox8.Text == "")
            {
                MessageBox.Show("please fill Email field");
            }
            else
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select count(*) from users where email='" + textBox8.Text + "'; ", connection);
                DataTable dataSet = new DataTable();
                mySqlDataAdapter.Fill(dataSet);
                int mail = Convert.ToInt32(dataSet.Rows[0][0].ToString());

                if (mail != 1)
                {

                    MessageBox.Show("user not in system ");
                }
                else
                {


                    //#call Update_from_Users("hesham abd el monsef","110105592","colfvscs","hesham@gmail.com","Najm");//
                    command.CommandText = "delete from users where email ='"+textBox8.Text + "';";




                    command.ExecuteNonQuery();
                    textBox8.Clear();
                    MessageBox.Show("Done");

                }


            }
        }

        private void Course_Click(object sender, EventArgs e)
        {
            panel8.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
           // panel9.Visible = true;
            

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}
