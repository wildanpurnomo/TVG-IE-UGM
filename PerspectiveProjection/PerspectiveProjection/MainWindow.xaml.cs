using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace PerspectiveProjection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point3DCollection initialPositionsDinding, initialPositionsAtap, initialPositionsPintu, initialPositionsJendela;

        double mTranslateValueX, mTranslateValueY, mTranslateValueZ, mRotateValueX, mRotateValueY, mRotateValueZ, mScaleValueX, mScaleValueY, mScaleValueZ, mNegativeZCOP;

        bool isToggleOn;

        #region properti translasi

        public double translateValueX
        {
            get
            {
                return mTranslateValueX;
            }

            set
            {
                if (value > mTranslateValueX)
                {
                    translateDinding(1, 0, 0);
                    translateAtap(1, 0, 0);
                    translatePintu(1, 0, 0);
                    translateJendela(1, 0, 0);
                }

                else if (value < mTranslateValueX)
                {
                    translateDinding(-1, 0, 0);
                    translateAtap(-1, 0, 0);
                    translatePintu(-1, 0, 0);
                    translateJendela(-1, 0, 0);
                } 

                mTranslateValueX = value;
                createProyeksiDinding();
                createProyeksiAtap();

                createGarisPerspektif();

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
                if (value > mTranslateValueY)
                {
                    translateDinding(0, 1, 0);
                    translateAtap(0, 1, 0);
                    translatePintu(0, 1, 0);
                    translateJendela(0, 1, 0);
                }

                else if (value < mTranslateValueY)
                {
                    translateDinding(0, -1, 0);
                    translateAtap(0, -1, 0);
                    translatePintu(0, -1, 0);
                    translateJendela(0, -1, 0);
                }

                mTranslateValueY = value;
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
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
                if (value > mTranslateValueZ)
                {
                    translateDinding(0, 0, 1);
                    translateAtap(0, 0, 1);
                    translatePintu(0, 0, 1);
                    translateJendela(0, 0, 1);
                }

                else if (value < mTranslateValueZ)
                {
                    translateDinding(0, 0, -1);
                    translateAtap(0, 0, -1);
                    translatePintu(0, 0, -1);
                    translateJendela(0, 0, -1);
                }

                mTranslateValueZ = value;
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
            }
        }

        #endregion

        #region properti rotasi

        public double rotateValueX
        {
            get
            {
                return mRotateValueX;
            }

            set
            {
                mRotateValueX = value;
                rotateDinding(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotateAtap(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotatePintu(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotateJendela(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
            }
        }

        public double rotateValueY
        {
            get
            {
                return mRotateValueY;
            }

            set
            {
                mRotateValueY = value;
                rotateDinding(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotateAtap(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotatePintu(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotateJendela(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
            }
        }

        public double rotateValueZ
        {
            get
            {
                return mRotateValueZ;
            }

            set
            {
                mRotateValueZ = value;
                rotateDinding(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotateAtap(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotatePintu(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                rotateJendela(degreeToRad(mRotateValueX), degreeToRad(mRotateValueY), degreeToRad(mRotateValueZ));
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
            }
        }

        #endregion

        #region properti scaling

        public double scaleValueX
        {
            get
            {
                return mScaleValueX;
            }

            set
            {
                scaleDinding(value / mScaleValueX, 1, 1);
                scaleAtap(value / mScaleValueX, 1, 1);
                scalePintu(value / mScaleValueX, 1, 1);
                scaleJendela(value / mScaleValueX, 1, 1);
                mScaleValueX = value;
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
            }
        }

        public double scaleValueY
        {
            get
            {
                return mScaleValueY;
            }

            set
            {
                scaleDinding(1, value / mScaleValueY, 1);
                scaleAtap(1, value / mScaleValueY, 1);
                scalePintu(1, value / mScaleValueY, 1);
                scaleJendela(1, value / mScaleValueY, 1);
                mScaleValueY = value;
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
            }
        }

        public double scaleValueZ
        {
            get
            {
                return mScaleValueZ;
            }

            set
            {
                scaleDinding(1, 1, value / mScaleValueZ);
                scaleAtap(1, 1, value / mScaleValueZ);
                scalePintu(1, 1, value / mScaleValueZ);
                scaleJendela(1, 1, value / mScaleValueZ);
                mScaleValueZ = value;
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            initViewport3D();
            drawCoords();
        }

        private void initViewport3D()
        {
            // gerakin camera
            viewPort3D.RotateGesture = new MouseGesture(MouseAction.LeftClick);

            // apa nanti gatau : setting camera awal
            viewPort3D.Camera.LookDirection = new Vector3D(13.682, -36.838, -13.243);
            viewPort3D.Camera.UpDirection = new Vector3D(-0.187, 0.504, 0.843);
            viewPort3D.Camera.Position = new Point3D(-13.682, 36.838, 13.243);
            
            // catat posisi awal objek, siapatahu butuh
            initialPositionsDinding = meshMain.Positions;
            initialPositionsAtap = meshAtap.Positions;
            initialPositionsPintu = meshPintu.Positions;
            initialPositionsJendela = meshJendela.Positions;

            // biar slider jalan
            sliderTranslateX.DataContext = this;
            sliderTranslateY.DataContext = this;
            sliderTranslateZ.DataContext = this;

            sliderRotateX.DataContext = this;
            sliderRotateY.DataContext = this;
            sliderRotateZ.DataContext = this;

            sliderScaleX.DataContext = this;
            sliderScaleY.DataContext = this;
            sliderScaleZ.DataContext = this;

            //biar textbox jalan
            negZCOPTextBox.DataContext = this;

            //khusus
            mScaleValueX = 1;
            mScaleValueY = 1;
            mScaleValueZ = 1;

            mNegativeZCOP = 1;

            //nyalain garis sama proyeksi
            isToggleOn = true;
        }

        private void drawCoords()
        {
            Model3DGroup modelGroup = new Model3DGroup();

            var axisBuilder = new MeshBuilder(false, false);
            axisBuilder.AddPipe(new Point3D(-1000, 0, 0), new Point3D(1000, 0, 0), 0, 0.1, 360);
            axisBuilder.AddPipe(new Point3D(0, -1000, 0), new Point3D(0, 1000, 0), 0, 0.1, 360);
            axisBuilder.AddPipe(new Point3D(0, 0, -1000), new Point3D(0, 0, 1000), 0, 0.1, 360);

            var mesh = axisBuilder.ToMesh(true);
            var material = new DiffuseMaterial(new SolidColorBrush(Colors.Black));

            modelGroup.Children.Add(new GeometryModel3D
            {
                Geometry = mesh,
                Material = material,
                Transform = new TranslateTransform3D(0, 0, 0)
            });

            garis.Content = modelGroup;
            
        }

        #region createProyeksi

        private void createProyeksiDinding()
        {
            if(isToggleOn == false)
            {
                return;
            }

            Point3DCollection newPoints = new Point3DCollection();

            foreach(var item in meshMain.Positions)
            {
                double something = (item.Z / mNegativeZCOP) + 1;

                if(item.Z < 0)
                {
                    meshProyeksi.Positions.Clear();
                    meshProyeksiAtap.Positions.Clear();
                    return;
                }

                if(mNegativeZCOP == 0)
                {
                    double jarakProyeksi = 3;

                    if (item.Z < jarakProyeksi)
                    {
                        meshProyeksi.Positions.Clear();
                        meshProyeksiAtap.Positions.Clear();
                        return;
                    }

                    something = item.Z / jarakProyeksi;

                    double newX = item.X / something;
                    double newY = item.Y / something;
                    double newZ = jarakProyeksi;

                    newPoints.Add(new Point3D(newX, newY, newZ));
                }

                else
                {
                    double newX = item.X / something;
                    double newY = item.Y / something;
                    double newZ = 0;

                    newPoints.Add(new Point3D(newX, newY, newZ));
                }
            }

            meshProyeksi.Positions = newPoints;

        }

        private void createProyeksiAtap()
        {
            if (isToggleOn == false)
            {
                return;
            }

            Point3DCollection anotherNewPoints = new Point3DCollection();
            foreach (var item in meshAtap.Positions)
            {
                double something = (item.Z / mNegativeZCOP) + 1;

                if (item.Z < 0)
                {
                    meshProyeksi.Positions.Clear();
                    meshProyeksiAtap.Positions.Clear();
                    return;
                }

                if (mNegativeZCOP == 0)
                {
                    double jarakProyeksi = 3;

                    if(item.Z < jarakProyeksi)
                    {
                        meshProyeksi.Positions.Clear();
                        meshProyeksiAtap.Positions.Clear();
                        return;
                    }

                    something = item.Z / jarakProyeksi;

                    double newX = item.X / something;
                    double newY = item.Y / something;
                    double newZ = jarakProyeksi;

                    anotherNewPoints.Add(new Point3D(newX, newY, newZ));
                }

                else
                {
                    double newX = item.X / something;
                    double newY = item.Y / something;
                    double newZ = 0;

                    anotherNewPoints.Add(new Point3D(newX, newY, newZ));
                }
            }

            meshProyeksiAtap.Positions = anotherNewPoints;
        }

        #endregion

        #region creategarisperspektif
        private void createGarisPerspektif()
        {
            if (isToggleOn == false)
            {
                return;
            }

            Model3DGroup modelGroup = new Model3DGroup();

            var garisBuilder = new MeshBuilder(false, false);

            foreach(var titikSudut in meshMain.Positions)
            {
                // don't make line from origin since it will not scaled.
                if(titikSudut == meshMain.Positions[8])
                {
                    continue;
                }

                garisBuilder.AddArrow(new Point3D(titikSudut.X, titikSudut.Y, titikSudut.Z), new Point3D(0, 0, -mNegativeZCOP), 0.05);
            }

            garisBuilder.AddArrow(new Point3D(meshAtap.Positions[0].X, meshAtap.Positions[0].Y, meshAtap.Positions[0].Z), new Point3D(0, 0, -mNegativeZCOP), 0.05);

            var mesh = garisBuilder.ToMesh(true);
            var material = new DiffuseMaterial(new SolidColorBrush(Colors.Black));

            modelGroup.Children.Add(new GeometryModel3D
            {
                Geometry = mesh,
                Material = material,
                Transform = new TranslateTransform3D(0, 0, 0)
            });

            garisPerspektif.Content = modelGroup;

        }

        #endregion

        private double degreeToRad(double mRotateAngleX)
        {
            return Math.PI * mRotateAngleX / 180;
        }

        #region fungsi translasi

        private void translateDinding(double offsetX, double offsetY, double offsetZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //translasi dinding
            foreach (var item in meshMain.Positions)
            {
                double newX = item.X + offsetX;
                double newY = item.Y + offsetY;
                double newZ = item.Z + offsetZ;

                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshMain.Positions = newPoints;
        }

        private void translateAtap(double offsetX, double offsetY, double offsetZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //translasi atap
            foreach (var item in meshAtap.Positions)
            {
                double newX = item.X + offsetX;
                double newY = item.Y + offsetY;
                double newZ = item.Z + offsetZ;

                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshAtap.Positions = newPoints;
        }

        private void translatePintu(double offsetX, double offsetY, double offsetZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //translasi atap
            foreach (var item in meshPintu.Positions)
            {
                double newX = item.X + offsetX;
                double newY = item.Y + offsetY;
                double newZ = item.Z + offsetZ;

                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshPintu.Positions = newPoints;
        }

        private void translateJendela(double offsetX, double offsetY, double offsetZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //translasi atap
            foreach (var item in meshJendela.Positions)
            {
                double newX = item.X + offsetX;
                double newY = item.Y + offsetY;
                double newZ = item.Z + offsetZ;

                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshJendela.Positions = newPoints;
        }

        #endregion

        #region fungsi rotasi

        private void rotateDinding(double angleX, double angleY, double angleZ)
        {
            Point3DCollection newPoints = new Point3DCollection();
        
            //rotasi dinding
            foreach (var item in initialPositionsDinding)
            {
                double newX = (item.X * Math.Cos(angleZ) * Math.Cos(angleY)) + (item.Y * (-Math.Sin(angleZ) * Math.Cos(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (Math.Sin(angleZ) * Math.Sin(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newY = (item.X * Math.Sin(angleZ) * Math.Cos(angleY)) + (item.Y * (Math.Cos(angleZ) * Math.Cos(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (-Math.Cos(angleZ) * Math.Sin(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newZ = (item.X * -Math.Sin(angleY)) + (item.Y * Math.Cos(angleY) * Math.Sin(angleX)) + (item.Z * Math.Cos(angleY) * Math.Cos(angleX));

                newPoints.Add(new Point3D(newX, newY, newZ));

            }

            meshMain.Positions = newPoints;

            translateDinding(mTranslateValueX, mTranslateValueY, mTranslateValueZ);
            scaleDinding(mScaleValueX, mScaleValueY, mScaleValueZ);

        }

        private void rotateAtap(double angleX, double angleY, double angleZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //rotasi atap
            foreach (var item in initialPositionsAtap)
            {
                double newX = (item.X * Math.Cos(angleZ) * Math.Cos(angleY)) + (item.Y * (-Math.Sin(angleZ) * Math.Cos(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (Math.Sin(angleZ) * Math.Sin(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newY = (item.X * Math.Sin(angleZ) * Math.Cos(angleY)) + (item.Y * (Math.Cos(angleZ) * Math.Cos(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (-Math.Cos(angleZ) * Math.Sin(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newZ = (item.X * -Math.Sin(angleY)) + (item.Y * Math.Cos(angleY) * Math.Sin(angleX)) + (item.Z * Math.Cos(angleY) * Math.Cos(angleX));

                newPoints.Add(new Point3D(newX , newY , newZ ));
            }

            meshAtap.Positions = newPoints;

            translateAtap(mTranslateValueX, mTranslateValueY, mTranslateValueZ);
            scaleAtap(mScaleValueX, mScaleValueY, mScaleValueZ);

        }

        private void rotatePintu(double angleX, double angleY, double angleZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //rotasi atap
            foreach (var item in initialPositionsPintu)
            {
                double newX = (item.X * Math.Cos(angleZ) * Math.Cos(angleY)) + (item.Y * (-Math.Sin(angleZ) * Math.Cos(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (Math.Sin(angleZ) * Math.Sin(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newY = (item.X * Math.Sin(angleZ) * Math.Cos(angleY)) + (item.Y * (Math.Cos(angleZ) * Math.Cos(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (-Math.Cos(angleZ) * Math.Sin(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newZ = (item.X * -Math.Sin(angleY)) + (item.Y * Math.Cos(angleY) * Math.Sin(angleX)) + (item.Z * Math.Cos(angleY) * Math.Cos(angleX));

                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshPintu.Positions = newPoints;

            translatePintu(mTranslateValueX, mTranslateValueY, mTranslateValueZ);
            scalePintu(mScaleValueX, mScaleValueY, mScaleValueZ);
        }

        private void rotateJendela(double angleX, double angleY, double angleZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //rotasi atap
            foreach (var item in initialPositionsJendela)
            {
                double newX = (item.X * Math.Cos(angleZ) * Math.Cos(angleY)) + (item.Y * (-Math.Sin(angleZ) * Math.Cos(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (Math.Sin(angleZ) * Math.Sin(angleX) + Math.Cos(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newY = (item.X * Math.Sin(angleZ) * Math.Cos(angleY)) + (item.Y * (Math.Cos(angleZ) * Math.Cos(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Sin(angleX))) + (item.Z * (-Math.Cos(angleZ) * Math.Sin(angleX) + Math.Sin(angleZ) * Math.Sin(angleY) * Math.Cos(angleX)));
                double newZ = (item.X * -Math.Sin(angleY)) + (item.Y * Math.Cos(angleY) * Math.Sin(angleX)) + (item.Z * Math.Cos(angleY) * Math.Cos(angleX));

                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshJendela.Positions = newPoints;

            translateJendela(mTranslateValueX, mTranslateValueY, mTranslateValueZ);
            scaleJendela(mScaleValueX, mScaleValueY, mScaleValueZ);
        }
        #endregion

        #region fungsi scaling

        private void scaleDinding(double scaleFactorX, double scaleFactorY, double scaleFactorZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //scaling dinding
            foreach (var item in meshMain.Positions)
            {
                //don't scale the origin
                if(item == meshMain.Positions[8])
                {
                    newPoints.Add(item);
                    continue;
                }

                double newX = item.X * scaleFactorX ;
                double newY = item.Y * scaleFactorY ;
                double newZ = item.Z * scaleFactorZ ;

                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshMain.Positions = newPoints;
        }

        private void scaleAtap(double scaleFactorX, double scaleFactorY, double scaleFactorZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //scaling atap
            foreach (var item in meshAtap.Positions)
            {

                double newX = item.X * scaleFactorX;
                double newY = item.Y * scaleFactorY;
                double newZ = item.Z * scaleFactorZ;

                
                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshAtap.Positions = newPoints;

        }

        private void scalePintu(double scaleFactorX, double scaleFactorY, double scaleFactorZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //scaling atap
            foreach (var item in meshPintu.Positions)
            {

                double newX = item.X * scaleFactorX;
                double newY = item.Y * scaleFactorY;
                double newZ = item.Z * scaleFactorZ;


                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshPintu.Positions = newPoints;
        }

        private void scaleJendela(double scaleFactorX, double scaleFactorY, double scaleFactorZ)
        {
            Point3DCollection newPoints = new Point3DCollection();

            //scaling atap
            foreach (var item in meshJendela.Positions)
            {

                double newX = item.X * scaleFactorX;
                double newY = item.Y * scaleFactorY;
                double newZ = item.Z * scaleFactorZ;


                newPoints.Add(new Point3D(newX, newY, newZ));
            }

            meshJendela.Positions = newPoints;
        }

        #endregion

        #region event handler

        private void negZCOPTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            negZCOPTextBox.Text = "";
        }

        private void toggleOnBtn_Click(object sender, RoutedEventArgs e)
        {
            isToggleOn = true;

            createProyeksiDinding();
            createProyeksiDinding();
            createGarisPerspektif();
        }

        private void toggleOffBtn_Click(object sender, RoutedEventArgs e)
        {
            isToggleOn = false;

            meshProyeksi.Positions.Clear();
            meshProyeksiAtap.Positions.Clear();
            garisPerspektif.Content = new Model3DGroup();
        }

        private void negZCOPTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = negZCOPTextBox.Text;

            if(value == "" || negZCOPTextBox.IsLoaded == false)
            {
                return;
            }

            else
            {
                mNegativeZCOP = Double.Parse(value);
                createProyeksiDinding();
                createProyeksiAtap();
                createGarisPerspektif();
            }
        }

        private void negZCOPTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                e.Handled = true;
            }

            return;
        }


        #endregion

    }
}
