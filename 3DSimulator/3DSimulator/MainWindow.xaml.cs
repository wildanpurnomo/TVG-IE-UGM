using _3DSimulator.Util;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3DSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int pageIndex;

        private int PageIndex
        {
            get
            {
                return pageIndex;
            }

            set
            {
                pageIndex = value;
                changeMenuHighlights(pageIndex);
                openPage(pageIndex);
            }
        }

        

        public MainWindow()
        {
            InitializeComponent();
            PageIndex = 0;
        }

        #region UI Action

        private void menuTranslasi_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = 0;
        }

        private void menuScaling_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = 1;
        }

        private void menuShearing_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = 2;
        }

        private void menuRotasiOrigin_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = 3;
        }

        private void menuRotasiArbitrary_Click(object sender, RoutedEventArgs e)
        {
            PageIndex = 4;
        }

        #endregion

        #region utilities

        private void openPage(int pageIndex)
        {
            switch (pageIndex)
            {
                case 0:
                    framePage.Content = new TranslasiPage();
                    break;

                case 1:
                    framePage.Content = new ScalingPage();
                    break;

                case 2:
                    framePage.Content = new ShearingPage();
                    break;

                case 3:
                    framePage.Content = new RotationByOriginPage();
                    break;

                case 4:
                    framePage.Content = new RotationByArbitraryPage();
                    break;

                default:
                    return ;
            }
        }

        private void changeMenuHighlights(int pageIndex)
        {
            switch (pageIndex)
            {
                case 0:
                    menuTranslasi.IsChecked = true;
                    menuScaling.IsChecked = false;
                    menuShearing.IsChecked = false;
                    menuRotasiOrigin.IsChecked = false;
                    menuRotasiArbitrary.IsChecked = false;
                    break;

                case 1:
                    menuTranslasi.IsChecked = false;
                    menuScaling.IsChecked = true;
                    menuShearing.IsChecked = false;
                    menuRotasiOrigin.IsChecked = false;
                    menuRotasiArbitrary.IsChecked = false;
                    break;

                case 2:
                    menuTranslasi.IsChecked = false;
                    menuScaling.IsChecked = false;
                    menuShearing.IsChecked = true;
                    menuRotasiOrigin.IsChecked = false;
                    menuRotasiArbitrary.IsChecked = false;
                    break;

                case 3:
                    menuTranslasi.IsChecked = false;
                    menuScaling.IsChecked = false;
                    menuShearing.IsChecked = false;
                    menuRotasiOrigin.IsChecked = true;
                    menuRotasiArbitrary.IsChecked = false;
                    break;

                case 4:
                    menuTranslasi.IsChecked = false;
                    menuScaling.IsChecked = false;
                    menuShearing.IsChecked = false;
                    menuRotasiOrigin.IsChecked = false;
                    menuRotasiArbitrary.IsChecked = true;
                    break;

                default:
                    return;
            }
        }

        #endregion
    }
}
