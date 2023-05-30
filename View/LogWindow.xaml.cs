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
using Task5._1.Core;

namespace Task5._1.View
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public List<User> DatabaseUsers { get; private set; }
        public Window1()
        {
            InitializeComponent();
            Read();
        }
        public void Create()
        {
            using (DataContext db = new DataContext())
            {
                var login = TbLogin.Text;
                var password = TbPassword.Text;
                var email = TbEmail.Text;

                try
                {
                    if ((string.IsNullOrEmpty(login)) || (string.IsNullOrEmpty(password)) || (string.IsNullOrEmpty(email)))
                    {
                        MessageBox.Show("Ошибка ввода данных", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    else
                    {
                        db.Users.Add(new User()
                        {
                            Login = login,
                            Password = password,
                            Email = email
                        });
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),
                                    "Системное сообщение",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }
        public void Read()
        {
            using (DataContext db = new DataContext())
            {
                DatabaseUsers = db.Users.ToList();
                LVinfo.ItemsSource = DatabaseUsers;
            }
        }

        public void Update()
        {
            using (DataContext db = new DataContext())
            {
                User? selectedUser = LVinfo.SelectedItem as User;

                var login = TbLogin.Text;
                var password = TbPassword.Text;
                var email = TbEmail;

                try
                {
                    if ((string.IsNullOrEmpty(login)) || (string.IsNullOrEmpty(password)) || (string.IsNullOrEmpty(email)))
                    {
                        MessageBox.Show("Ошибка ввода данных", "Системное сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    else
                    {
                        User user = db.Users.Find(selectedUser.UserID);


                        user.Login = login;
                        user.Password = password;
                        user.Email = email;
                       
                        db.SaveChanges();
                        Read();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),
                                    "Системное сообщение",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }

        }

        public void Delete()
        {
            using (DataContext db = new DataContext())
            {
                User selectedUser = LVinfo.SelectedItem as User;

                if (selectedUser != null)
                {
                    User? user = db.Users.Single(f => f.UserID == selectedUser.UserID);
                    db.Users.Remove(user);
                    db.SaveChanges();
                    Read();
                }    
            }
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            LVinfo.Items.Clear();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
