using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Input;

namespace GameTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 33;
            timer1.Enabled = true;

            Bitmap x = Properties.Resources.smurf;
            for(int i = 0; i < 512; i += 64)
            {
                Rectangle r = new Rectangle(i, 0, 64, 64);
                Bitmap s = x.Clone(r, x.PixelFormat);
                smurf.Add(s);
                
                
            }
            actor = smurf[5];
            
        }

        //bool click = false;
        bool left = false;
        int x = 400;
        int y = 0;

        List<Bitmap> smurf = new List<Bitmap>();
        Bitmap actor;
        DateTime old;
        

        private void Form1_Click(object sender, EventArgs e)
        {

            
        }

        private void GameUpdate()
        {
            //actor.RotateFlip(RotateFlipType.Rotate180FlipY);
            if(MouseButtons == MouseButtons.Left)
            {
                if(left)
                    x = x - 10;
                else
                    x = x + 10;
            }
            if (x < 0) x = 0;
            else if ( x > 800) x = 800;

            actor = smurf[(x / 10) % 8];

            
 
        }

        private void Render()
        {
            Bitmap screen = new Bitmap(800, 480);
            Graphics g4 = Graphics.FromImage(screen);

            Graphics g = this.CreateGraphics();
            Rectangle r1 = new Rectangle(x, y, 800, 480);
            Bitmap b1 = Properties.Resources.back1;
            Bitmap b2 = Properties.Resources.back2;
            Bitmap b3 = b2.Clone(r1, b2.PixelFormat);
            g4.DrawImage(b1, 0, 0);
            g4.DrawImage(b3, 0, 0);

            if (left)
                actor.RotateFlip(RotateFlipType.Rotate180FlipY);

            g4.DrawImage(actor, 360, 330);

            DateTime t = DateTime.Now;
            string str = string.Format("{0:hh:mm:ss:ffff}", t);
            g4.DrawString(str, new Font("나눔고딕", 20, GraphicsUnit.Pixel), Brushes.Yellow, 10, 10);

            g.DrawImage(screen, 0, 0);
            g.Dispose();
            g4.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GameUpdate();
            Render();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            left = (e.X > 400);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
