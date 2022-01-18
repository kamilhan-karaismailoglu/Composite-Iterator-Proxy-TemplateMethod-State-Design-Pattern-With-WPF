using System;
using System.Windows;

namespace CompositeAndIteratorAndProxyDP
{
    public partial class MainWindow : Window
    {
        private double version = 1.61;

        public MainWindow()
        {
            InitializeComponent();
            versionLbl.Content = version;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region Proxy DP Client

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string message = client.CheckVersion(version);
            MessageBox.Show(message,"info");

            #endregion
        }
    }
}