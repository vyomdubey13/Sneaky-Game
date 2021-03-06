using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartGame
{
    
    public partial class Form1 : Form
    {
        public string[] conc = "+|-|*|/".Split('|');
        public int timeleft;
        public int a, b, c;
        public int points = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void startButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = " ";
            answerbox.Text = " ";
            timeleft = 6;
            Random r = new Random();
            Random rnd = new Random();
            a = r.Next(15) + 1;
            b = r.Next(15) + 1;
            xlabel.Text = a.ToString();
            zLabel.Text = b.ToString();
            yLabel.Text = conc[rnd.Next(conc.Length)];
            timer1.Start();

            startButton.Enabled = false;
            doneStart.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        { if (timeleft > 0)
            {
                timeleft--;
                timeLabel.Text = timeleft.ToString();
            }
            if (timeleft == 0)
            {
                doneStart.Enabled = false;
                startButton.Enabled = true;
                timer1.Stop();
                timeLabel.Text = "Score:";
                resultLabel.Text = points.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Stop();
        }

        private void doneStart_Click(object sender, EventArgs e)
      {
            
            Startagain();
                
                   
            }
        private void Startagain()
        {
            if (yLabel.Text == "+")
                c = a + b;
            else if (yLabel.Text == "*")
                c = a * b;
            else if (yLabel.Text == "-")
                c = a - b;
            else
                c = a /b;
            if (answerbox.Text == c.ToString())
            {
                startButton.Enabled = false;
                doneStart.Enabled = true;
                timer1.Stop();

                resultLabel.Text = "";
                answerbox.Select();
                answerbox.Text = "";
                
                    points++;
                timeleft = 8;
                timeLabel.Text = timeleft.ToString();
                timer1.Start();
                Random r = new Random();
                Random rnd = new Random();
                a = r.Next(15) + 1;
                b = r.Next(15) + 1;
                xlabel.Text = a.ToString();
                zLabel.Text = b.ToString();
                yLabel.Text = conc[rnd.Next(conc.Length)];







            }
            else
            {
                timeLabel.Text = "Wrong answer";
                for(int i=1000000000;i<1000000007;i++)
                { }
                timeLabel.Text = "You Score :  ";
                answerbox.Text = " ";
                resultLabel.Text = points.ToString();
                startButton.Enabled = true;
                doneStart.Enabled = false;
                timer1.Stop();
            }

        }

    }
    
}
    