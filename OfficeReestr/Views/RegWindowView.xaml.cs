using System;
using System.Linq;
using System.Windows;
using OfficeReestr.OfficeReestrModel;
using OfficeReestr.Utilities;

namespace OfficeReestr.Views;

public partial class RegWindowView : Window
{
    public RegWindowView()
    {
        InitializeComponent();
    }

    private void RegButton_OnClick(object sender, RoutedEventArgs e)
    {
        var login = LoginBox.Text;
        var enteredPassword = PasswordBox.Password;

        
        // Проверка наличия данных в текстовых полях
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(enteredPassword) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(enteredPassword))
        {
            MessageBox.Show("Пожалуйста, введите логин и пароль", "Ошибка аутентификации");
            return;
        }

        // Проверка минимальной длины пароля
        if (enteredPassword.Length < 5)
        {
            MessageBox.Show("Пароль должен содержать как минимум " + 5 + " символов.", "Ошибка аутентификации");
            return;
        }

        var sucsess = true;

        // Проверка, что пользователя с таким именем еще нет
        if (AppData._DbContext.Users.Any(u => u.Username == login))
        {
            MessageBox.Show("Пользователь с таким логином уже существует!", "Authorization error ");
        }

        // Генерация соли для нового пользователя
        string salt = PasswordHasher.GenerateSalt();

        // Хеширование пароля с использованием соли
        string hashedPassword = PasswordHasher.HashPassword(enteredPassword, salt);

        // Создание нового пользователя
        var newUser = new User
        {
            Username = login,
            Password = hashedPassword,
            Salt = salt
            // Другие свойства, если есть
        };

        try
        {
            // Добавление пользователя в базу данных
            AppData._DbContext.Users.Add(newUser);

            // Сохранение изменений в базе данных
            AppData._DbContext.SaveChanges();
            sucsess = true;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error while processing user registration.");
            throw;
            sucsess = false;
        }

        if (sucsess == true)
        {
            MessageBox.Show("Успешная регистрация!", "Успех");
            new MainWindow().Show();
            this.Close();
        }
    }

    private void BackLoginWindow_OnClick(object sender, RoutedEventArgs e)
    {
        new AuthWindowView().Show();
        this.Hide();
    }
}