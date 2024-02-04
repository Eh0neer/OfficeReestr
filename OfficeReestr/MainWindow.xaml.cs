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

namespace OfficeReestr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Укажите строку подключения к вашей базе данных
            string connectionString = "your_connection_string";

            // try
            // {
            //     using (SqlConnection connection = new SqlConnection(connectionString))
            //     {
            //         connection.Open();
            //
            //         // Здесь вы можете выполнить SQL-запрос для получения информации о кабинетах и компьютерах из базы данных
            //
            //         // Пример SQL-запроса:
            //         // string sqlQuery = "SELECT CabinetName, ComputerName FROM YourTable";
            //         // SqlCommand command = new SqlCommand(sqlQuery, connection);
            //         // SqlDataReader reader = command.ExecuteReader();
            //
            //         // Замените этот блок кода на обработку реальных данных из базы данных
            //
            //         string[] cabinetNames = { "Юр. Отдел", "Администрация", "Учебный класс" }; // Пример данных
            //         int computersPerCabinet = 5; // Пример данных
            //
            //         foreach (var cabinetName in cabinetNames)
            //         {
            //             TreeViewItem cabinetItem = new TreeViewItem { Header = cabinetName };
            //             directoryTreeView.Items.Add(cabinetItem);
            //
            //             for (int i = 1; i <= computersPerCabinet; i++)
            //             {
            //                 string computerName = $"Computer{i}";
            //                 TreeViewItem computerItem = new TreeViewItem { Header = computerName };
            //                 cabinetItem.Items.Add(computerItem);
            //             }
            //         }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            // }
        }
    }
}