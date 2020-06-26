using Donate.Services;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace Donate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private readonly IDonateService donateService;
             
        public MainWindow()
        {
            InitializeComponent();
            donateService = new DonateService();
        }
    }
}
