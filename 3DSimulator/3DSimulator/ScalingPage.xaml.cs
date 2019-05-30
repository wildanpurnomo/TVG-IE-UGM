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
using System.Windows.Shapes;

namespace _3DSimulator
{
    /// <summary>
    /// Interaction logic for ScalingPage.xaml
    /// </summary>
    public partial class ScalingPage : UserControl
    {
        Point3DCollection initialForm;

        double mScalingFactorX, mScalingFactorY, mScalingFactorZ;

        Timer timer;

        double[] tesGoal;

        public double scalingFactorX
        {
            get
            {
                return mScalingFactorX;
            }

            set
            {
                mScalingFactorX = value;
                scalingBikinSendiri(mScalingFactorX, mScalingFactorY, mScalingFactorZ);
            }
        }

        public double scalingFactorY
        {
            get
            {
                return mScalingFactorY;
            }

            set
            {
                mScalingFactorY = value;
                scalingBikinSendiri(mScalingFactorX, mScalingFactorY, mScalingFactorZ);
            }
        }

        public double scalingFactorZ
        {
            get
            {
                return mScalingFactorZ;
            }

            set
            {
                mScalingFactorZ = value;
                scalingBikinSendiri(mScalingFactorX, mScalingFactorY, mScalingFactorZ);
            }
        }

        private void scalingBikinSendiri(double scaleFactorX, double scaleFactorY, double scaleFactorZ)
        {
            Point3DCollection scalingRes = new Point3DCollection();

            foreach (var item in initialForm)
            {
                double newX = scaleFactorX * item.X;
                double newY = scaleFactorY * item.Y;
                double newZ = scaleFactorZ * item.Z;

                scalingRes.Add(new Point3D(newX, newY, newZ));
            }

            Console.WriteLine(scalingRes);
            meshMain.Positions = scalingRes;
        }

        public ScalingPage()
        {
            InitializeComponent();
            InitModelPosition();
            InitScalingFactors();
            InitTimer();
        }

        private void animateScaleBtn_Click(object sender, RoutedEventArgs e)
        {
            //set goals
            tesGoal = new double[] { Double.Parse(boxXValue.Text), Double.Parse(boxYValue.Text), Double.Parse(boxZValue.Text) };

            //change to default ones
            scalingFactorX = 1;
            scalingFactorY = 1;
            scalingFactorZ = 1;

            boxXValue.Text = "1";
            boxYValue.Text = "1";
            boxZValue.Text = "1";

            timer.Start();
        }

        private void InitTimer()
        {
            timer = new Timer();

            timer.Interval = 100;

            timer.Elapsed += onTickMethod;
        }

        private void onTickMethod(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (boxXValue.Text != tesGoal[0].ToString())
                {
                    scalingFactorX += 0.1;
                    boxXValue.Text = scalingFactorX.ToString();
                }

                else if (boxYValue.Text != tesGoal[1].ToString())
                {
                    scalingFactorY += 0.1;
                    boxYValue.Text = scalingFactorY.ToString();
                }

                else if (boxZValue.Text != tesGoal[2].ToString())
                {
                    scalingFactorZ += 0.1;
                    boxZValue.Text = scalingFactorZ.ToString();
                }

                else
                {
                    Console.WriteLine(boxXValue.Text + " is equal to " + tesGoal[0].ToString());
                    timer.Stop();
                    Console.WriteLine("Timer stopped");
                }
            });
        }

        private void InitScalingFactors()
        {
            mScalingFactorX = 1;
            mScalingFactorY = 1;
            mScalingFactorZ = 1;
        }

        private void InitModelPosition()
        {
            initialForm = meshMain.Positions;
            slider.DataContext = this;

            Console.WriteLine(initialForm);
        }
    }
}
