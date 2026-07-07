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
using System.Windows.Shapes;
using PMS_Client.Operation;
using PMS_Common.TCPManager;

namespace PMS_Client.PMS_UI
{
    /// <summary>
    /// PMS_Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PMS_Login : Window
    {
        private readonly TcpClientManager _tcp = new();

        public PMS_Login()
        {
            InitializeComponent();

            PmsClientStarted pmsStart = new PmsClientStarted();
            pmsStart.PmsStart(_tcp);
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginOperation login = new LoginOperation(_tcp, tbID.Text, tbPW.Password);

            await login.SendLoginRequest();
        }

        private void btnAdminContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "관리자에게 문의하시겠습니까?",
                "관리자 문의",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
