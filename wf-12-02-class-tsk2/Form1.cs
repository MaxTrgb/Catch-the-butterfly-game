using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Automation;

namespace wf_12_02_class_tsk2
{
    public partial class Form1 : Form
    {
        private List<PictureBox> pictures = new List<PictureBox>();

        private int score = 0;

        private int counter = 1;

        private int livesCounter = 3;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Start();

            timer2.Interval = 1000;
            timer2.Start();

            timer3.Interval = 10;

            timer4.Interval = 1;
            timer4.Start();

            timer5.Interval = 1;
            timer5.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            this.Controls.Remove(picture);
            pictures.Remove(picture);
            score += 1;
            label2.Text = score.ToString();

            counter += 1;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (livesCounter == 2)
            {
                pictureBox3.Visible = false;
            }
            else if (livesCounter == 1)
            {
                pictureBox2.Visible = false;
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();

            PictureBox picture = new PictureBox();
            picture.Location = new Point(rand.Next(0, 700), 400);
            picture.Size = new Size(77, 77);

            // adjust the path to the image
            picture.Image = Image.FromFile("D:\\Study\\WinForms\\wf-12-02-class-tsk2\\wf-12-02-class-tsk2\\obj\\241eee72a97d7e312b7eb28d1b7ac070.png");

            picture.BackColor = Color.Transparent;
            picture.Click += pictureBox1_Click;

            if (counter >= 5)
            {
                timer2.Interval = 500;
            }
            else if (counter >= 10)
            {
                timer2.Interval = 300;
            }
            pictures.Add(picture);

            this.Controls.Add(picture);

            timer3.Start();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int baseSpeed = 1;
            double speedMultiplier = 0.5;

            int speed = (int)(baseSpeed + counter * speedMultiplier);

            foreach (var pic in pictures)
            {
                Point point = Point.Add(pic.Location, new Size(0, -speed));
                pic.Location = point;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            if (score == 25)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                timer5.Stop();
                MessageBox.Show("You win!");
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            for (int i = pictures.Count - 1; i >= 0; i--)
            {
                var pic = pictures[i];
                if (pic.Location.Y <= 0)
                {
                    this.Controls.Remove(pic);
                    pictures.RemoveAt(i);
                    livesCounter -= 1;                  
                }
            }          

            if (livesCounter == 0)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                timer4.Stop();
                timer5.Stop();
                pictureBox1.Visible = false;
                MessageBox.Show("You lose!");
                return;
            }
        }
        
    }
}
