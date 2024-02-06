using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using OfficeReestr.OfficeReestrModel;

namespace OfficeReestr
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                using (var context = new CompReestrDbContext())
                {
                    var roomsWithComputers = context.Rooms
                        .Join(context.Movements,
                            room => room.RoomId,
                            movement => movement.TargetRoomId,
                            (room, movement) => new { Room = room, Movement = movement })
                        .Join(context.Equipment,
                            combined => combined.Movement.EquipmentId,
                            equipment => equipment.EquipmentId,
                            (combined, equipment) => new { Room = combined.Room, Equipment = equipment })
                        .GroupBy(result => result.Room, result => result.Equipment)
                        .ToList();

                    foreach (var roomWithComputers in roomsWithComputers)
                    {
                        TreeViewItem roomItem = new TreeViewItem { Header = $"Room Number: {roomWithComputers.Key.RoomNumber}" };
                        directoryTreeView.Items.Add(roomItem);

                        foreach (var computer in roomWithComputers)
                        {
                            TreeViewItem computerItem = new TreeViewItem { Header = $"Computer: {computer.Name}" };
                            roomItem.Items.Add(computerItem);

                            // Add handling for components if needed
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
