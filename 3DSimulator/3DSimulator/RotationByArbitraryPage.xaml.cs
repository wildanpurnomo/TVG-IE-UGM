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
    /// Interaction logic for RotationByArbitraryPage.xaml
    /// </summary>
    public partial class RotationByArbitraryPage : UserControl
    {
        Point3DCollection initialForm;

        Vector3D axisStartPoint, axisEndPoint;

        double mRotateAngle, goalPoint;

        Timer timer;

        public double rotateAngle
        {
            get
            {
                return mRotateAngle;
            }

            set
            {
                mRotateAngle = value;
                rotasiArbitraryBikinSendiri(degreeToRad(mRotateAngle));
            }
        }

        public void rotasiArbitraryBikinSendiri(double mRotateAngle)
        {
            Point3DCollection rotationRes = new Point3DCollection();

            Matrix3D transformationMatrix = getTransformationMatrix(mRotateAngle);

            foreach (var item in initialForm)
            {
                Vector3D pointResult = Vector3D.Multiply(new Vector3D(item.X, item.Y, item.Z), transformationMatrix);
                double newX = pointResult.X;
                double newY = pointResult.Y;
                double newZ = pointResult.Z;

                rotationRes.Add(new Point3D(newX, newY, newZ));
            }

            meshMain.Positions = rotationRes;

        }

        private Matrix3D getTransformationMatrix(double mRotateAngle)
        {
            Point3D translatedEndPoint = new Point3D();
            translatedEndPoint.X = axisEndPoint.X - axisStartPoint.X;
            translatedEndPoint.Y = axisEndPoint.Y - axisStartPoint.Y;
            translatedEndPoint.Z = axisEndPoint.Z - axisStartPoint.Z;

            double rotateYAxisAngle = Math.Atan(translatedEndPoint.X / translatedEndPoint.Z);
            Console.WriteLine("Yaxis" + rotateYAxisAngle);
            if (Double.IsNaN(rotateYAxisAngle) && translatedEndPoint.X != 0)
            {
                rotateYAxisAngle = degreeToRad(90);
            }

            else if (translatedEndPoint.X == 0 && translatedEndPoint.Z == 0)
            {
                rotateYAxisAngle = 0;
            }

            double rotateXAxisAngle = Math.Atan(translatedEndPoint.Y / translatedEndPoint.Z);
            if (Double.IsNaN(rotateXAxisAngle) && translatedEndPoint.Y != 0)
            {
                rotateXAxisAngle = degreeToRad(90);
            }

            else if (translatedEndPoint.Y == 0 && translatedEndPoint.Z == 0)
            {
                rotateXAxisAngle = 0;
            }

            //define matrices
            Matrix3D firstMatrixTranslasi = new Matrix3D(
                1, 0, 0, -axisStartPoint.X,
                0, 1, 0, -axisStartPoint.Y,
                0, 0, 1, -axisStartPoint.Z,
                0, 0, 0, 1);

            Matrix3D secondMatrixTranslasi = new Matrix3D(
                1, 0, 0, axisStartPoint.X,
                0, 1, 0, axisStartPoint.Y,
                0, 0, 1, axisStartPoint.Z,
                0, 0, 0, 1);

            Matrix3D firstRotateXAxis = new Matrix3D(
                1, 0, 0, 0,
                0, Math.Cos(-rotateXAxisAngle), -Math.Sin(-rotateXAxisAngle), 0,
                0, Math.Sin(-rotateXAxisAngle), Math.Cos(-rotateXAxisAngle), 0,
                0, 0, 0, 1
                );

            Matrix3D secondRotateXAxis = new Matrix3D(
                1, 0, 0, 0,
                0, Math.Cos(rotateXAxisAngle), -Math.Sin(rotateXAxisAngle), 0,
                0, Math.Sin(rotateXAxisAngle), Math.Cos(rotateXAxisAngle), 0,
                0, 0, 0, 1
                );

            Matrix3D firstRotateYAxis = new Matrix3D(
                Math.Cos(rotateYAxisAngle), 0, Math.Sin(rotateYAxisAngle), 0,
                0, 1, 0, 0,
                -Math.Sin(rotateYAxisAngle), 0, Math.Cos(rotateYAxisAngle), 0,
                0, 0, 0, 1
                );

            Matrix3D secondRotateYAxis = new Matrix3D(
                Math.Cos(-rotateYAxisAngle), 0, Math.Sin(-rotateYAxisAngle), 0,
                0, 1, 0, 0,
                -Math.Sin(-rotateYAxisAngle), 0, Math.Cos(-rotateYAxisAngle), 0,
                0, 0, 0, 1
                );

            Matrix3D rotateZAxis = new Matrix3D(
                Math.Cos(mRotateAngle), -Math.Sin(mRotateAngle), 0, 0,
                Math.Sin(mRotateAngle), Math.Cos(mRotateAngle), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
                );

            //calculate transformation matrix
            Matrix3D transformationMatrix = firstMatrixTranslasi * firstRotateYAxis * firstRotateXAxis * rotateZAxis * secondRotateXAxis * secondRotateYAxis * secondMatrixTranslasi;

            return transformationMatrix;
        }

        public RotationByArbitraryPage()
        {
            InitializeComponent();
            InitModelPosition();
            InitSliderSettings();
            InitTImer();
        }

        private void InitTImer()
        {
            timer = new Timer();

            timer.Interval = 100;

            timer.Elapsed += onTickMethod;
        }

        private void onTickMethod(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (boxTethaAngle.Text != goalPoint.ToString())
                {
                    rotateAngle += 10;
                    boxTethaAngle.Text = rotateAngle.ToString();
                }

                else
                {
                    timer.Stop();
                    Console.WriteLine("Timer stopped");
                }
            });

        }

        private void InitSliderSettings()
        {
            sliderTethaAngle.DataContext = this;
            sliderTethaAngle.Visibility = Visibility.Hidden;

            boxTethaAngle.Visibility = Visibility.Hidden;
            animateBtn.IsEnabled = false;
        }

        private void InitModelPosition()
        {
            initialForm = meshMain.Positions;
        }

        private void createAxisBtn_Click(object sender, RoutedEventArgs e)
        {
            if( boxStartX.Text != "" && boxStartY.Text != "" && boxStartZ.Text != "" && boxEndX.Text != "" && boxEndY.Text != "" && boxEndZ.Text != "")
            {
                getAxisStartPoints();
                getAxisEndPoints();
                //addSegment(axisStartPoint, axisEndPoint);

                sliderTethaAngle.Visibility = Visibility.Visible;
                boxTethaAngle.Visibility = Visibility.Visible;
                animateBtn.IsEnabled = true;

            }

            else
            {
                MessageBox.Show("Please fill point boxes first.", "Illegal move detected.");
            }

        }

        private void getAxisEndPoints()
        {
            axisEndPoint.X = Double.Parse(boxEndX.Text);
            axisEndPoint.Y = Double.Parse(boxEndY.Text);
            axisEndPoint.Z = Double.Parse(boxEndZ.Text);
        }

        private void getAxisStartPoints()
        {
            axisStartPoint.X = Double.Parse(boxStartX.Text);
            axisStartPoint.Y = Double.Parse(boxStartY.Text);
            axisStartPoint.Z = Double.Parse(boxStartZ.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goalPoint = Double.Parse(boxTethaAngle.Text);

            rotateAngle = 0;

            boxTethaAngle.Text = "0";

            timer.Start();
        }

        private double degreeToRad(double mRotateAngleX)
        {
            return Math.PI * mRotateAngleX / 180;
        }

        /*private void addSegment(Vector3D start, Vector3D end)
        {
            double lineLength = Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.Z - start.Z, 2));

            Vector3D middlePoint = new Vector3D(start.X + lineLength, start.Y + lineLength, start.Z + lineLength);

            Vector3D n1 = new Vector3D(middlePoint.X * 0.5, middlePoint.Y * 0.5, middlePoint.Z * 0.5);
            Vector3D n2 = new Vector3D(middlePoint.X * -0.5, middlePoint.Y * -0.5, middlePoint.Z * -0.5);

            line.Positions.Add(new Point3D(start.X, start.Y, start.Z));
            line.Positions.Add(new Point3D(n2.X, n2.Y, n2.Z));
            line.Positions.Add(new Point3D(n1.X, n1.Y, n1.Z));
            line.Positions.Add(new Point3D(end.X, end.Y, end.Z));

        }*/
    }
}
