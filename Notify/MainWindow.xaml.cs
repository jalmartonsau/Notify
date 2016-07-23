using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

        #region Properties

        int Margin { get; set; }

        double ScreenWidth { get; set; }
        double ScreenHeight { get; set; }

        double AppWidth { get; set; }
        double AppHeight { get; set; }

        private double _AppLeft;
        public double AppLeft { get { return _AppLeft; } set { _AppLeft = value; } }

        private double _AppTop;
        public double AppTop { get { return _AppTop; } set { _AppTop = value; } }


        #endregion

        #region Button Snap to sides

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
            AppTop = Application.Current.MainWindow.Top;
            AppLeft = Application.Current.MainWindow.Left;
            MoveButton();
        }

        Timer Animate = new Timer();
        private void MoveButton()
        {
            double midX = ScreenWidth / 2;
            double midY = ScreenHeight / 2;

            if (AppLeft <= midX)
            {
                Animate.Elapsed += new ElapsedEventHandler(SnapToLeft);
            } else if (AppLeft > midX) 
            {
                Animate.Elapsed += new ElapsedEventHandler(SnapToRight);
            }
            
            Animate.Interval = 1;
            Animate.Enabled = true;

        }

        private void SnapToRight(object source, ElapsedEventArgs e)
        {
            if (AppLeft < (ScreenWidth - Margin))
            {
                AppLeft += 100;
                Dispatcher.Invoke(() => Application.Current.MainWindow.Left = AppLeft);
            }
            else {
                Dispatcher.Invoke(() => Application.Current.MainWindow.Left = ScreenWidth - Margin);
                KillAnimation();
            }
        }

        private void SnapToLeft(object source, ElapsedEventArgs e)
        {
            if (AppLeft > Margin - 55)
            {
                AppLeft -= 100;
                Dispatcher.Invoke(() => Application.Current.MainWindow.Left = AppLeft);
            }
            else {
                Dispatcher.Invoke(() => Application.Current.MainWindow.Left = Margin - 55);
                KillAnimation();
            }
        }

        private void KillAnimation()
        {
            Animate.Enabled = false;
            Animate = new Timer();
        }
        
        private void SnapToDefault() {
            Application.Current.MainWindow.Left = ScreenWidth - Margin;
            Application.Current.MainWindow.Top = ScreenHeight - (Margin + 70);
        }

        #endregion

    }
}
