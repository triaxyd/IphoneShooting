using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shooterP21120
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1(int score = 0)
        {
            InitializeComponent();
            prevScore.Text += score;
            instance = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {

        
        }

        private void statsForm(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }
            
        private void playForm(object sender, EventArgs e)
        {
            this.Close();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
            
            
            
            






            





