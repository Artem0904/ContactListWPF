using ContactList.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactList
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        User user;
        MainWindow mainWindow;
        public LoginWindow()
        {
            InitializeComponent();
            user = new User();
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<User>();
                if(connection.Table<User>() == null )
                {
                    connection.Insert(user);
                }
            }
            mainWindow = new MainWindow();
            //if (!File.Exists(App.UserDataPath))
            //{
            //    User.SerelizeUserDate(user);
            //}
            //user = User.DerelizeUserDate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().Last();
            }
            if (loginTextBox.Text == user.Login && passwordTextBox.Text == user.Password)
            {
                Close();
                mainWindow.ShowDialog();
            }
            else
            {
                loginTextBox.Text = string.Empty;
                passwordTextBox.Text = string.Empty;
                MessageBox.Show("Login or password incorrect! Try again!");
            }
        }
    }
}
