using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3DSimulator
{
    /// <summary>
    /// Interaction logic for ShearingPage.xaml
    /// </summary>
    public partial class ShearingPage : UserControl
    {

        Point3DCollection initialForm;

        double mShearFactorA, mShearFactorB, mShearFactorC, mShearFactorD, mShearFactorE, mShearFactorF;

        double[] goalPoints;

        Timer timer;

        public double a
        {
            get
            {
                return mShearFactorA;
            }

            set
            {
                mShearFactorA = value;
                shearingBikinSendiri(mShearFactorA, mShearFactorB, mShearFactorC, mShearFactorD, mShearFactorE, mShearFactorF);
            }
        }

        public double b
        {
            get
            {
                return mShearFactorB;
            }

            set
            {
                mShearFactorB = value;
                shearingBikinSendiri(mShearFactorA, mShearFactorB, mShearFactorC, mShearFactorD, mShearFactorE, mShearFactorF);
            }
        }

        public double c
        {
            get
            {
                return mShearFactorC;
            }

            set
            {
                mShearFactorC = value;
                shearingBikinSendiri(mShearFactorA, mShearFactorB, mShearFactorC, mShearFactorD, mShearFactorE, mShearFactorF);
            }
        }

        public double d
        {
            get
            {
                return mShearFactorD;
            }

            set
            {
                mShearFactorD = value;
                shearingBikinSendiri(mShearFactorA, mShearFactorB, mShearFactorC, mShearFactorD, mShearFactorE, mShearFactorF);
            }
        }

        public double e
        {
            get
            {
                return mShearFactorE;
            }

            set
            {
                mShearFactorE = value;
                shearingBikinSendiri(mShearFactorA, mShearFactorB, mShearFactorC, mShearFactorD, mShearFactorE, mShearFactorF);
            }
        }

        public double f
        {
            get
            {
                return mShearFactorF;
            }

            set
            {
                mShearFactorF = value;
                shearingBikinSendiri(mShearFactorA, mShearFactorB, mShearFactorC, mShearFactorD, mShearFactorE, mShearFactorF);
            }
        }

        public void shearingBikinSendiri(double a, double b, double c, double d, double e, double f)
        {

            Point3DCollection shearingRes = new Point3DCollection();

            foreach (var item in initialForm)
            {
                double newX = item.X + a * item.Y + b * item.Z;
                double newY = item.X * c + item.Y + d * item.Z;
                double newZ = item.X * e + item.Y * f + item.Z;

                shearingRes.Add(new Point3D(newX, newY, newZ));
            }

            meshMain.Positions = shearingRes;
        }

        public ShearingPage()
        {
            InitializeComponent();
            InitModelPosition();
            InitSliders();
            InitTimer();
        }

        private void InitSliders()
        {
            // slider X axis
            sliderSHyXAxis.DataContext = this;
            sliderSHzXAxis.DataContext = this;

            //slider Y axis
            sliderSHxYAxis.DataContext = this;
            sliderSHzYAxis.DataContext = this;

            //slider Z axis
            sliderSHxZAxis.DataContext = this;
            sliderSHyZAxis.DataContext = this;
        }

        private void InitTimer()
        {
            timer = new Timer();

            timer.Interval = 100;

            timer.Elapsed += onTickMethod;
        }

        private void onTickMethod(object sender, ElapsedEventArgs v)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (boxSHyXAxis.Text != goalPoints[0].ToString())
                {
                    c += 0.1;
                    boxSHyXAxis.Text = c.ToString();
                }

                else if (boxSHzXAxis.Text != goalPoints[1].ToString())
                {
                    e += 0.1;
                    boxSHzXAxis.Text = e.ToString();
                }

                else if (boxSHxYAxis.Text != goalPoints[2].ToString())
                {
                    a += 0.1;
                    boxSHxYAxis.Text = a.ToString();
                }

                else if (boxSHzYAxis.Text != goalPoints[3].ToString())
                {
                    f += 0.1;
                    boxSHzYAxis.Text = f.ToString();
                }

                else if (boxSHxZAxis.Text != goalPoints[4].ToString())
                {
                    b += 0.1;
                    boxSHxZAxis.Text = b.ToString();
                }

                else if (boxSHyZAxis.Text != goalPoints[5].ToString())
                {
                    d += 0.1;
                    boxSHyZAxis.Text = d.ToString();
                }

                else
                {
                    timer.Stop();
                    Console.WriteLine("Timer stopped");
                }
            });
        }

        private void InitModelPosition()
        {
            initialForm = meshMain.Positions;
        }

        private void animateShearBtn_Click(object sender, RoutedEventArgs v)
        {
            //set goals
            goalPoints = new double[] { Double.Parse(boxSHyXAxis.Text), Double.Parse(boxSHzXAxis.Text), Double.Parse(boxSHxYAxis.Text), Double.Parse(boxSHzYAxis.Text), Double.Parse(boxSHxZAxis.Text), Double.Parse(boxSHyZAxis.Text)};

            //change to default ones
            a = 1;
            b = 1;
            c = 1;
            d = 1;
            e = 1; 
            f = 1;

            boxSHyXAxis.Text = "0";
            boxSHzXAxis.Text = "0";
            boxSHxYAxis.Text = "0";
            boxSHzYAxis.Text = "0";
            boxSHxZAxis.Text = "0";
            boxSHyZAxis.Text = "0";

            timer.Start();

        }
    }
}
