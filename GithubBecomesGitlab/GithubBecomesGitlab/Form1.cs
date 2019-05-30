using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GithubBecomesGitlab
{
    public partial class Form1 : Form
    {
        private Point[] githubLogo, gitlabLogo, selisih;
        private Timer timer;
        private float a = 0;

        public Form1()
        {
            InitializeComponent();

            //initialize points
            initializePoints();

            //setting Timer
            initializeTimer();
        }

        private void initializeTimer()
        {
            //instantiate
            timer = new Timer();

            //set interval
            timer.Interval = 100;

            //each 100 seconds do method
            timer.Tick += onTickMethod;
        }

        private void onTickMethod(object sender, EventArgs e)
        {
            a += (float)0.05;
            Refresh();
        }

        private void initializePoints()
        {
            githubLogo = new Point[]
            {
                new Point(187, 71),
                new Point(187, 94),
                new Point(187, 108),
                new Point(177, 125),
                new Point(171, 141),
                new Point(171, 164),
                new Point(177, 182),
                new Point(187, 199),
                new Point(198, 213),
                new Point(213, 223),
                new Point(227, 228),
                new Point(241, 228),
                new Point(233, 248),
                new Point(218, 254),
                new Point(198, 248),
                new Point(187, 237),
                new Point(177, 223),
                new Point(157, 223),
                new Point(171, 237),
                new Point(177, 254),
                new Point(192, 268),
                new Point(213, 274),
                new Point(233, 274),
                new Point(233, 291),
                new Point(233, 306),
                new Point(309, 306),
                new Point(309, 291),
                new Point(309, 291),
                new Point(309, 274),
                new Point(309, 248),
                new Point(299, 228),
                new Point(315, 223),
                new Point(332, 218),
                new Point(346, 211),
                new Point(357, 198),
                new Point(367, 182),
                new Point(367, 164),
                new Point(367, 141),
                new Point(367, 125),
                new Point(352, 108),
                new Point(357, 88),
                new Point(352, 71),
                new Point(337, 71),
                new Point(322, 77),
                new Point(309, 88),
                new Point(282, 77),
                new Point(255, 77),
                new Point(233, 83),
                new Point(213, 77),
                new Point(187, 71)
            };

            gitlabLogo = new Point[]
            {
                new Point(187, 69),
                new Point(179, 90),
                new Point(173, 107),
                new Point(167, 124),
                new Point(163, 139),
                new Point(157, 155),
                new Point(152, 172),
                new Point(147, 186),
                new Point(140, 200),
                new Point(134, 217),
                new Point(147, 223),
                new Point(157, 231),
                new Point(167, 239),
                new Point(179, 248),
                new Point(191, 257),
                new Point(203, 267),
                new Point(217, 276),
                new Point(229, 286),
                new Point(244, 298),
                new Point(255, 304),
                new Point(270, 314),
                new Point(291, 304),
                new Point(301, 298),
                new Point(313, 286),
                new Point(329, 276),
                new Point(346, 263),
                new Point(362, 248),
                new Point(380, 234),
                new Point(392, 224),
                new Point(407, 211),
                new Point(403, 200),
                new Point(398, 186),
                new Point(392, 168),
                new Point(385, 151),
                new Point(380, 139),
                new Point(374, 124),
                new Point(369, 107),
                new Point(362, 90),
                new Point(355, 69),
                new Point(346, 90),
                new Point(340, 107),
                new Point(334, 124),
                new Point(329, 139),
                new Point(322, 161),
                new Point(270, 161),
                new Point(213, 161),
                new Point(203, 107),
                new Point(198, 90),
                new Point(187, 69)
            };

            List<Point> temp = new List<Point>();

            for (int i = 0; i < 49; i++)
            {
                int x = gitlabLogo[i].X - githubLogo[i].X;
                int y = gitlabLogo[i].Y - githubLogo[i].Y;
                Point p = new Point(x, y);
                temp.Add(p);
            } 
            selisih = temp.ToArray();            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                timer.Start();
                Console.WriteLine("S is pressed");
            }

            else if(e.KeyChar == (char)Keys.Space)
            {
                a = 0;
                Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen bluePen = new Pen(Color.Green, 3);

            List<Point> temp = new List<Point>();

            for (int i = 0; i < 49; i++)
            {
                double x = githubLogo[i].X + selisih[i].X * a;
                double y = githubLogo[i].Y + selisih[i].Y * a;
                Point p = new Point(Convert.ToInt32(x), Convert.ToInt32(y));
                temp.Add(p);
            }

            Point[] morPath = temp.ToArray();

            e.Graphics.DrawLines(bluePen, morPath);

            if (morPath[45] == gitlabLogo[45])
            {
                timer.Stop();
                MessageBox.Show("Selesai", "Finish");
            }
        }
    }
}
