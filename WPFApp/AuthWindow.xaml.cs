using System.Windows;
using WPFApp.Data;
using WPFApp.Helpers;

namespace WPFApp
{
    public partial class AuthWindow : Window
    {
        private AppDbContext _appDbContext = new();
        private MessageHelper _messageHelper = new();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginEnter.Text;

            var user = _appDbContext.Users.Where(u => u.Login == login).FirstOrDefault();

            if (user == null) _messageHelper.ShowError("Пользователь не найден");
            else {
                new ProductWindow(user).Show();
                Close();
            }
        }

        private void GuestBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new ProductWindow().Show();
            Close();
        }
    }
}
