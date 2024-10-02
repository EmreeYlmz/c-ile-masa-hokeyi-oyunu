using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        int doğmayeri=250;
        Random doğmayerir = new Random();
        int süre = 100;
        public Form1()
        {
            InitializeComponent();
        }
        bool g1 = false, g2 = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) label2.Top -= 10;
            if (e.KeyCode == Keys.Down) label2.Top += 10;

            if (e.KeyCode == Keys.W) label1.Top -= 10;
            if (e.KeyCode == Keys.S) label1.Top += 10;

            if (e.KeyCode == Keys.NumPad0)
            {
                if (progressBar2.Value > 95)
                {
                    
                    g1 = true;
                }
                else
                {

                }
            }
            if (e.KeyCode == Keys.D1)
            {
                if (progressBar1.Value > 95)
                {
                    
                    g2 = true;
                }
                else
                {

                }
            }
        }
        Random yönbelirle = new Random();
        int yön;
        private void Form1_Load(object sender, EventArgs e)
        {
            yön = yönbelirle.Next(0, 6);
        }
        int p1 = 0, p2 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (g1!=true&&g2!=true)
            {
                if (yön == 1)
                {
                    label3.Left -= 10;
                    label3.Top -= 5;
                }
                else if (yön == 2)
                {
                    label3.Left -= 10;
                    label3.Top += 5;
                }
                else if (yön == 3)
                {
                    label3.Left += 10;
                    label3.Top -= 5;
                }
                else if (yön == 4)
                {
                    label3.Left += 10;
                    label3.Top += 5;
                }
                else if (yön == 5)
                {
                    label3.Left += 10;
                }
                else if (yön == 0)
                {
                    label3.Left -= 10;
                }
            }

            if (g1 == true)
            {
                if (timer4.Enabled != true)
                {
                    timer3.Enabled = true;
                }
            }

            if (g2 == true)
            {
                if (timer3.Enabled != true)
                {
                    timer4.Enabled = true;
                }               
            }

            if (yön == 1 || yön == 2 ||yön==0)
            {
                if ((label3.Top >= label1.Top - 20 && label3.Top <= label1.Top + 50) && (label3.Left <= label1.Left + 16))
                {
                    yön = yönbelirle.Next(3, 6);
                    if (timer1.Interval > 2)
                        timer1.Interval -= 2;
                }
            }
            if (yön == 3 || yön == 4||yön==5)
            {
                if ((label3.Top >= label2.Top - 10 && label3.Top <= label2.Top + 50) && (label3.Left >= label2.Left - 16))
                {
                    yön = yönbelirle.Next(0, 3);
                    if (timer1.Interval > 2)
                        timer1.Interval -= 2;
                }
            }
            if (yön == 1 || yön == 2 || yön ==0)
            {
                if (label3.Top < 0)
                {
                    yön = 2;
                }
                else if (label3.Top > 302)
                {
                    yön = 1;
                }
                if (label3.Left < 0)
                {
                    p2++;
                    label5.Text = p2.ToString();
                    doğmayeri = doğmayerir.Next(1, 300);
                    label3.Left = 334;
                    label3.Top = doğmayeri;
                }
            }
            if (yön == 3 || yön == 4||yön==5)
            {
                if (label3.Top < 0)
                {
                    yön = 4;
                }
                else if (label3.Top > 302)
                {
                    yön = 3;
                }

                if (label3.Left > 690)
                {
                    p1++;
                    label4.Text = p1.ToString();
                    doğmayeri=doğmayerir.Next(1,300);
                    label3.Left = 334;
                    label3.Top = doğmayeri;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (süre > 0)
                süre--;
            label7.Text = süre.ToString();
            if (süre < 8)
                label7.ForeColor = Color.Red;

            if (süre == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                if (p1 < p2)
                    MessageBox.Show("Kazanan Sağ taraf");
                else if (p1 > p2)
                    MessageBox.Show("Kazanan Sol Taraf");
                else
                    MessageBox.Show("Beraber");
                DialogResult aa = new DialogResult();
                aa=MessageBox.Show("Yeni Oyun?","Yeni Oyun",MessageBoxButtons.YesNo);
                if (aa == DialogResult.Yes)
                    Application.Restart();
            }
        }//süre
        int say = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            say++;
            progressBar2.Value = 0;
            if (say < 200)
            {
                timer1.Enabled = false;
                yön = 5;
            }
            else
            {
                timer1.Enabled = true;
                say = 0;
                timer3.Enabled = false;
                g1 = false;
            }
            if (label3.Left > 690)
            {
                p1++;
                label4.Text = p1.ToString();
                label3.Left = 334;
            }


        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            say++;
            
            if (say < 200)
            {
                timer1.Enabled = false;
                yön = 0;
            }
            else
            {
                timer1.Enabled = true;
                say = 0;
                timer4.Enabled = false;
                g2 = false;
            }
            if (label3.Left < 0)
            {
                p2++;
                label5.Text = p2.ToString();
                label3.Left = 334;
            }


        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
                progressBar1.Value += 1;
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (progressBar2.Value < 100)
                progressBar2.Value += 1;
        }

     

       
    }
}
