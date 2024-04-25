using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeLord_MVVM_Тепляков.ViewModell;

namespace TimeLord_MVVM_Тепляков.View
{
    /// <summary>
    /// Логика взаимодействия для Stopwatch.xaml
    /// </summary>
    public partial class Stopwatch : Page
    {
        public Stopwatch()
        {
            InitializeComponent();
            DataContext = new VMStopwatch();
        }

        private void TimerClick(object sender, RoutedEventArgs e) => MainWindow.init.frame.Navigate(new View.Timer());
    }
}