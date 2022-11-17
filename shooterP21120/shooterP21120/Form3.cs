using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace shooterP21120
{
    public partial class Form3 : Form
    {
        public List<int> scores = new List<int>();
        public Form3()
        {
            InitializeComponent();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            desir();
            manageScores();
            setHighScore();
        }

        private void goToForm1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.instance.Show(); 
        }

        private void setHighScore()
        {
            top1.Text = scores[0].ToString();
            top2.Text = scores[1].ToString();
            top3.Text = scores[2].ToString();
            top4.Text = scores[3].ToString();
            top5.Text = scores[4].ToString();
            top6.Text = scores[5].ToString();
            top7.Text = scores[6].ToString();
            top8.Text = scores[7].ToString();
            top9.Text = scores[8].ToString();
            top10.Text = scores[9].ToString();   
        }
        private void desir()
        {
            IFormatter formatter2 = new BinaryFormatter();
            Stream stream2 = new FileStream("topScores.ser", FileMode.Open, FileAccess.Read);
            scores = (List<int>)formatter2.Deserialize(stream2);
            stream2.Close();
            scores.Sort();
            scores.Reverse();
        }

        private void manageScores()
        {
            while (scores.Count() < 10)
            {
                scores.Add(0);
            }
        }
    }
}
