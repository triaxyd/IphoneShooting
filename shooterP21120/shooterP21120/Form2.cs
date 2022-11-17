using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;

namespace shooterP21120
{
    [Serializable]   
    public partial class Form2 : Form
    {
        SoundPlayer sp,spc;
        public List<int> myScores = new List<int>();
        bool gameOver, moveLeft, moveRight,shooting;
        int speed = 30;
        int enemySpeed, score, bulletSpeed;
        Random r = new Random();
        
        
        
        public Form2()
        {
            InitializeComponent();
            resetGame();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("topScores.ser", FileMode.Open, FileAccess.Read);
            myScores = (List<int>)formatter.Deserialize(stream);
            stream.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sp = new SoundPlayer("villager.wav");
            spc = new SoundPlayer("charging.wav");
        }
            
            
        private void gameTimer_Tick(object sender, EventArgs e)
        {
             
            playerScore.Text = score.ToString();
            enemy1.Top += enemySpeed;
            enemy2.Top += enemySpeed;
            enemy3.Top += enemySpeed;

            if (enemy1.Top>630 || enemy2.Top>630|| enemy3.Top > 630)
            {
                endGame();
            }
                
            if (moveLeft == true && player.Left > 5)
            {
                player.Left -= speed;
            }

            if (moveRight == true && player.Right < 1170)
            {
                player.Left += speed;
            }

            if (shooting == true)
            {
                bulletSpeed = 25;
                bullet.Top -= bulletSpeed;
            }
            else
            {
                bullet.Left = -500;
                bulletSpeed = 0;
            }

            if (bullet.Top < -5)
            {
                shooting = false;
            }

            if (bullet.Bounds.IntersectsWith(enemy1.Bounds))
            {
                sp.Play();
                score += 1;
                shooting = false;
                enemy1.Top = -300;
                enemy1.Left = r.Next(10, 1100); 
            }
     
            if (bullet.Bounds.IntersectsWith(enemy2.Bounds))
            {
                sp.Play();
                score += 1;
                shooting = false;
                enemy2.Top = -550;
                enemy2.Left = r.Next(10, 1100);
            }
                
                
            if (bullet.Bounds.IntersectsWith(enemy3.Bounds))
            {
                sp.Play();
                score += 1;
                shooting = false;
                enemy3.Top = -650;
                enemy3.Left = r.Next(10,1100);
            }
                
                
               
            if (score == 5)
            {
                enemySpeed = 6;
            }
            if (score == 10)
            {
                enemySpeed = 7;
            }
            if (score == 15)
            {
                enemySpeed = 8;
            }
            if (score == 20)
            {
                enemySpeed = 9;
            }
            if (score == 25)
            {
                enemySpeed = 10;
            }
            if (score == 30)
            {
                enemySpeed = 11;
            }
            if (score == 40)
            {
                enemySpeed = 12;
            }
            if (score == 50)
            {
                enemySpeed = 13;
            }
            if (score == 60)
            {
                enemySpeed = 14;
            }
            if (score == 70)
            {
                enemySpeed = 15;
            }
            if (score == 80)
            {
                enemySpeed = 16;
            }
            if (score == 90)
            {
                enemySpeed = 17;
            }
            if (score == 100)
            {
                enemySpeed = 18;
            }
       
        }
                
                
                    


        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Space && shooting==false)
            {
                shooting = true;
                bullet.Top = player.Top - 55;
                bullet.Left = player.Left +38;
            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                resetGame();
            }
            if (e.KeyCode ==Keys.Back && gameOver == true)
            {
                Form1 form1 = new Form1(score);
                form1.Show();
                this.Close();
            }
        }

        private void resetGame()
        {
            gameTimer.Start();
            enemySpeed = 5;

            enemy1.Left = r.Next(10, 1100);
            enemy2.Left = r.Next(10, 1100);
            enemy3.Left = r.Next(10, 1100);

            enemy1.Top = r.Next(0, 300) * -1;
            enemy2.Top = r.Next(0, 600) * -1;
            enemy3.Top = r.Next(0, 900) * -1;
            score = 0;
            playerScore.Text = score.ToString();
            bulletSpeed = 0;
            bullet.Left = -300;
            shooting = false;

            enemy1.Show();
            enemy2.Show();
            enemy3.Show();
            errorMess.Hide();
            bullet.Show();
            player.Show();
        }


        private void endGame()
        {
            spc.Play();
            shooting = true;
            gameOver = true;
            sendData();
            gameTimer.Stop();
            playerScore.Text += Environment.NewLine +Environment.NewLine + "Press Enter to Play Again" + Environment.NewLine + Environment.NewLine + "Press BackSpace for Main Menu";
            errorMess.Show();
            enemy1.Hide();
            enemy2.Hide();
            enemy3.Hide();
            bullet.Hide();
            player.Hide();
        }

            

        public void sendData()
        {
            myScores.Add(score);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("topScores.ser", FileMode.Open, FileAccess.Write);
            formatter.Serialize(stream, myScores);
            stream.Close();
        }
    }
}
                
                
                

            
           
            

        




            


