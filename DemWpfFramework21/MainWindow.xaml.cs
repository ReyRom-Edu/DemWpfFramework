using DemWpfFramework21.Pages;
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

namespace DemWpfFramework21
{


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.Frame = MainFrame;

            MainFrame.Navigated += MainFrame_Navigated;

            MainFrame.Navigate(new LoginPage());
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            this.Title = (MainFrame.Content as Page).Title;
        }
    }
}
