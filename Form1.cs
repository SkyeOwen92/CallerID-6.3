using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CallerID_6._3
{
    public partial class Form1 : Form
    {
        Q callers = new Q();
        int index = 0;
        int placement = 1200;
        SoundPlayer player = new SoundPlayer(@"C:\MSSA\DS and Algo Weeks 5 - 7\CallerID 6.3\no-this-is-patrick.wav");
        public Form1()
        {
            InitializeComponent();
        }

        private void EnQueue_Click(object sender, EventArgs e)
        {
            placement = placement - 300; 
            callers.EnQue((People)index);
            callers.rear.photo = getImage((People)index);

            if (index == 3)
            { index = 0; }
            else { index++; }
            EnQueTime.Enabled = true;
        }

        public PictureBox getImage(People index)
        {
            switch (index)
            {
                case People.SpongeBob:
                    return QSponge;
                case People.Squidward:
                    return QSquid;
                case People.Crabs:
                    return QCrab;
                case People.Puff:
                    return QPuff;
                default:
                    return null;
            }
        }
        public async void showCaller(People index)
        {
            switch (index)
            {
                case People.SpongeBob:
                    talkSB.Show();
                    await Task.Delay(3000);
                    talkSB.Hide();
                    break;
                case People.Squidward:
                    talkSQ.Show();
                    await Task.Delay(3000);
                    talkSQ.Hide();
                    break;
                case People.Crabs:
                    talkCrabs.Show();
                    await Task.Delay(3000);
                    talkCrabs.Hide();
                    break;
                case People.Puff:
                    talkPuff.Show();
                    await Task.Delay(5000);
                    talkPuff.Hide();
                    break;
                default:
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            callers.rear.photo.Left += EnQueTime.Interval;
            if (callers.rear.photo.Left >= placement)
            {
                EnQueTime.Enabled = false;
            }
        }

        private void DeQueue_Click(object sender, EventArgs e)
        {
            if (!callers.isEmpty())
            {
                DeQueTime.Enabled = true;
                showCaller(callers.front.who.Value);
                player.Play();
                placement += 300;
            }
        }
        private void DeQueTime_Tick(object sender, EventArgs e)
        {
            PictureBox[] pics = callers.move();
            foreach (PictureBox p in pics)
            {
                p.Left += DeQueTime.Interval;
            }
            if (callers.rear.photo.Left >= placement )
            {
                DeQueTime.Enabled = false;
                callers.front.photo.Left = -300;
                callers.DeQue();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}