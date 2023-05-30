using ContactList.Data.Models;
using SQLite;
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
using System.Windows.Shapes;

namespace ContactList
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        User user;
        public EditProfileWindow()
        {
            InitializeComponent();
            //user = User.DerelizeUserDate();
            user = new User();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //user = User.DerelizeUserDate();
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().Last();
            }

            //user.Login = loginTextBox.Text;
            //user.Password = passwordTextBox.Text;
            //User.SerelizeUserDate(user);

            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<User>();
                user.Login = loginTextBox.Text;
                user.Password = passwordTextBox.Text;
                connection.Insert(user);
            }

            Close();
        }
    }
}
