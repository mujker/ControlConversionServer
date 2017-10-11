using System.Windows;
using SuperSocket.SocketBase;

namespace ControlConversionServer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppServer _appServer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_OnClick(object sender, RoutedEventArgs e)
        {
            _appServer = new AppServer();
            _appServer.NewSessionConnected += AppServerOnNewSessionConnected;
            _appServer.Setup(2099);
            _appServer.Start();
        }

        private void AppServerOnNewSessionConnected(AppSession session)
        {
            session.Send("i am appserver");
        }

        private void BtnStop_OnClick(object sender, RoutedEventArgs e)
        {
            _appServer?.Stop();
        }
    }
}
