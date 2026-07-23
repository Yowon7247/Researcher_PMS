using PMS_Client.Events;
using PMS_Client.Operation;
using PMS_Common.Packets;
using PMS_Common.TCPManager;
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

            ClientEvents.LoginResponded += OnLoginResponded;
            Closed += (s, e) => ClientEvents.LoginResponded -= OnLoginResponded;
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

        private void OnLoginResponded(LoginResponse response)
        {
            Dispatcher.Invoke(() =>
            {
                if (response.Success)
                {
                    MessageBox.Show(
                        response.IsAdmin
                            ? "관리자로 로그인되었습니다."
                            : $"{response.UserName}님, 환영합니다.",
                        "로그인 성공",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    // TODO: 로그인 성공 후 메인 화면으로 이동하는 로직 필요하면 여기에
                }
                else
                {
                    MessageBox.Show(
                        response.Message,
                        "로그인 실패",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            });
        }
    }
}
