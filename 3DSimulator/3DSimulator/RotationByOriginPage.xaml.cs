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
    /// Interaction logic for RotationByOriginPage.xaml
    /// </summary>
    public partial class RotationByOriginPage : UserControl
    {
        Point3DCollection initialForm;

        double mRotateAngleX, mRotateAngleY, mRotateAngleZ;

        Timer timer;

        double[] goalPoints;

        public double rotateAngleX
        {
            get
            {
                return mRotateAngleX;
            }

            set
            {
                mRotateAngleX = value;
                rotateAllAxis(degreeToRad(mRotateAngleX), degreeToRad(mRotateAngleY), degreeToRad(mRotateAngleZ));
            }
        }

        public double rotateAngleY
        {
            get
            {
                return mRotateAngleY;
            }

            set
            {
                mRotateAngleY = value;
                rotateAllAxis(degreeToRad(mRotateAngleX), degreeToRad(mRotateAngleY), degreeToRad(mRotateAngleZ));
            }
        }

        public double rotateAngleZ
        {
            get
            {
                return mRotateAngleZ;
            }

            set
            {
                mRotateAngleZ = value;
                rotateAllAxis(degreeToRad(mRotateAngleX), degreeToRad(mRotateAngleY), degreeToRad(mRotateAngleZ));
            }
        }

        public void rotateAllAxis(double angleX, double angleY, double angleZ)
        {
            Point3DCollection rotateRes = new Point3DCollection();

            foreach (var item in initialForm)
            {
                double newX = (item.X * Math.Cos(angleZ) * Math.Cos(angleY)) + (item.Y * (-Math.Sin(angleZ) * Math.Cos(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (Math.Sin(angleZ) * Math.Sin(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newY = (item.X * Math.Sin(angleZ) * Math.Cos(angleY)) + (item.Y * ( Math.Cos(angleZ) * Math.Cos(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * ( -Math.Cos(angleZ) * Math.Sin(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newZ = (item.X * -Math.Sin(angleY)) + (item.Y * Math.Cos(angleY) * Math.Sin(angleX)) + (item.Z * Math.Cos(angleY) * Math.Cos(angleX));

                rotateRes.Add(new Point3D(newX, newY, newZ));
            }

            meshMain.Positions = rotateRes;
        }

        public RotationByOriginPage()
        {
            InitializeComponent();
            InitModelPosition();
            InitTimer();
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
                if (boxXValue.Text != goalPoints[0].ToString())
                {
                    rotateAngleX += 10;
                    boxXValue.Text = rotateAngleX.ToString();
                }

                else if (boxYValue.Text != goalPoints[1].ToString())
                {
                    rotateAngleY += 10;
                    boxYValue.Text = rotateAngleY.ToString();
                }

                else if (boxZValue.Text != goalPoints[2].ToString())
                {
                    rotateAngleZ += 10;
                    boxZValue.Text = rotateAngleZ.ToString();
                }

                else
                {
                    timer.Stop();
                    Console.WriteLine("Timer stopped");
                }
            });
        }

        private void animateRotationBtn_Click(object sender, RoutedEventArgs e)
        {
            //set goals
            goalPoints = new double[] { Double.Parse(boxXValue.Text), Double.Parse(boxYValue.Text), Double.Parse(boxZValue.Text) };

            //change to default zeros
            rotateAngleX = 0;
            rotateAngleY = 0;
            rotateAngleZ = 0;

            boxXValue.Text = "0";
            boxYValue.Text = "0";
            boxZValue.Text = "0";

            timer.Start();
        }

        private void InitModelPosition()
        {
            initialForm = meshMain.Positions;
            slider.DataContext = this;
        }

        private double degreeToRad(double mRotateAngleX)
        {
            return Math.PI * mRotateAngleX / 180;
        }
    }
}
