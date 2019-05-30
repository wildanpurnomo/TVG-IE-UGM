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
    /// Interaction logic for TranslasiPage.xaml
    /// </summary>
    public partial class TranslasiPage : UserControl
    {

        Point3DCollection initialForm;
        Timer timer;

        double[] tesGoal;
        double mTranslateValueX, mTranslateValueY, mTranslateValueZ;

        public double translateValueX
        {
            get
            {
                return mTranslateValueX;
            }

            set
            {

                mTranslateValueX = value;
                translateBikinanSendiri(mTranslateValueX, mTranslateValueY, mTranslateValueZ);
            }
        }

        public double translateValueY
        {
            get
            {
                return mTranslateValueY;
            }

            set
            {
                mTranslateValueY = value;
                translateBikinanSendiri(mTranslateValueX, mTranslateValueY, mTranslateValueZ);
            }
        }

        public double translateValueZ
        {
            get
            {
                return mTranslateValueZ;
            }

            set
            {
                mTranslateValueZ = value;
                translateBikinanSendiri(mTranslateValueX, mTranslateValueY, mTranslateValueZ);
            }
        }

        private void translateBikinanSendiri(double offsetX, double offsetY, double offsetZ)
        {

            Point3DCollection translateRes = new Point3DCollection();

            foreach (var item in initialForm)
            {
                double newX = item.X + offsetX;
                double newY = item.Y + offsetY;
                double newZ = item.Z + offsetZ;

                translateRes.Add(new Point3D(newX, newY, newZ));
            }

            meshMain.Positions = translateRes;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //set goals
            tesGoal = new double[] { Double.Parse(boxXValue.Text), Double.Parse(boxYValue.Text), Double.Parse(boxZValue.Text) };

            //change to default zeros
            translateValueX = 0;
            translateValueY = 0;
            translateValueZ = 0;

            boxXValue.Text = "0";
            boxYValue.Text = "0";
            boxZValue.Text = "0";

            timer.Start();
        }

        public TranslasiPage()
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
                if(boxXValue.Text != tesGoal[0].ToString())
                {
                    translateValueX += 0.1;
                    boxXValue.Text = translateValueX.ToString();
                }

                else if(boxYValue.Text != tesGoal[1].ToString()){
                    translateValueY += 0.1;
                    boxYValue.Text = translateValueY.ToString();
                }

                else if(boxZValue.Text != tesGoal[2].ToString())
                {
                    translateValueZ += 0.1;
                    boxZValue.Text = translateValueZ.ToString();
                }

                else
                {
                    Console.WriteLine(boxXValue.Text + " is equal to " + tesGoal[0].ToString());
                    timer.Stop();
                    Console.WriteLine("Timer stopped");
                }
            });
        }

        private void InitModelPosition()
        {
            initialForm = meshMain.Positions;
            slider.DataContext = this;
        }
    }
}
