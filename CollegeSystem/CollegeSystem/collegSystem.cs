using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeSystem
{
    public partial class collegSystem : Form
    {
        public collegSystem()
        {
            InitializeComponent();
        }

        private void collegSystem_Load(object sender, EventArgs e)
        {

        }
        private void loginshow()
        {
            Form1 login = new Form1();
            login.Visible = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            guna2ProgressBar1.Value+=5;
           if (guna2ProgressBar1.Value >= 100)
            {
                
                this.Visible = false;
                
                timer1.Enabled = false;
                loginshow();
            }

        }
    }
}
