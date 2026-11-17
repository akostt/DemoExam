using System.ComponentModel.DataAnnotations;
using System.Windows;
using WPFApp.Data;
using WPFApp.Models;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private readonly User? _user;
        private bool IsAuthorizated => _user != null;
        private AppDbContext _appDbContext = new();

        public ProductWindow()
        {
            InitializeComponent();
            Init();
        }

        public ProductWindow(User user)
        {
            _user = user;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadProducts();
            FullUserName.Text = IsAuthorizated ? $"{_user.FirstName} {_user.MiddleName} {_user.LastName}" : "Гость";
        }

        private void LoadProducts()
        {
            ProductList.ItemsSource = _appDbContext.Products.ToList();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            new AuthWindow().Show();
            Close();
        }
    }
}