using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OfficeReestr.OfficeReestrModel;
using System.Linq;

using OfficeReestr.Utilities;

namespace OfficeReestr.Views;

public partial class AuthWindowView : Window
{
    public AuthWindowView()
    {
        InitializeComponent();
    }

    private void RegButton_OnClick(object sender, RoutedEventArgs e)
    {
        new RegWindowView().Show();
        this.Close();
    }

    private void RememberMeBox_Unchecked(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void RememberMeBox_Checked(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void ForgotPassword_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void AuthButton_OnClick(object sender, RoutedEventArgs e)
    {
        var login = LoginBox.Text;
        var enteredPassword = PasswordBox.Password;

        var user = AppData._DbContext.Users.FirstOrDefault(u => u.Username == login);

        if (user != null)
        {
            // Получение соли пользователя из базы данных
            string salt = user.Salt;

            // Хеширование введенного пароля с использованием соли
            string hashedEnteredPassword = PasswordHasher.HashPassword(enteredPassword, salt);

            // Проверка хешей
            if (user.Password == hashedEnteredPassword)
            {
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect login or password", "Authorization error ");
            }
        }
        else
        {
            MessageBox.Show("User not found", "Authorization error ");
        }
    }
}