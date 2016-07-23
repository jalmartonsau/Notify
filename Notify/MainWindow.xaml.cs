using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace Notify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Hides app from the taskbar
            //this.ShowInTaskbar = false;
            this.Topmost = true;

            Button.MouseLeftButtonDown += Button_MouseLeftButtonDown;

            Margin = 60;
            ScreenWidth = SystemParameters.PrimaryScreenWidth;
            ScreenHeight = SystemParameters.PrimaryScreenHeight;
            AppWidth = Application.Current.MainWindow.ActualWidth;
            AppHeight = Application.Current.MainWindow.ActualHeight;
            AppTop = Application.Current.MainWindow.Top;
            AppLeft = Application.Current.MainWindow.Left;

            SnapToDefault();

        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
            AppTop = Application.Current.MainWindow.Top;
            AppLeft = Application.Current.MainWindow.Left;
            MoveButton();
        }


        #region Properties

        int Margin { get; set; }

        double ScreenWidth { get; set; }
        double ScreenHeight { get; set; }

        double AppWidth { get; set; }
        double AppHeight { get; set; }

        double _AppLeft;
        double AppLeft { get { return _AppLeft; } set { _AppLeft = value; } }

        double _AppTop;
        double AppTop { get { return _AppTop; } set { _AppTop = value; } }


        #endregion

        private void MoveButton()
        {
            double midX = ScreenWidth / 2;
            double midY = ScreenHeight / 2;

            if (AppLeft <= midX)
            {
                Application.Current.MainWindow.Left = Margin - 50;
            } else if (AppLeft > midX) 
            {
                Application.Current.MainWindow.Left = ScreenWidth - Margin;
            }


        }
        
        private void SnapToDefault() {
            Application.Current.MainWindow.Left = ScreenWidth - Margin;
            Application.Current.MainWindow.Top = ScreenHeight - (Margin + 70);
        }

    }
}
