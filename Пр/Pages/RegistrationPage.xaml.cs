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
using Пр.Classes;

namespace Пр.Pages
{

    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            
        }

        private void btnRegDB(object sender, RoutedEventArgs e)
        {
            if (ConnectHelper.obdEnt.USERS.Count(X => X.Login == Log.Text) > 0)
            {
                 MessageBox.Show("Такой пользователь уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                 return;
            }
             else
             {
                 try
                 {
                     USERS userObj = new USERS()
                     {
                       Login = Log.Text,
                       Password = ConfirmP.Password,
                     };
                    Athletes atlOBJ = new Athletes()
                    {
                       FIO = FIO.Text,
                       age = Convert.ToInt32(Age.Text),
                    };
                    ConnectHelper.obdEnt.USERS.Add(userObj);
                    ConnectHelper.obdEnt.SaveChanges();
                    MessageBox.Show("Пользователь успешно создан", "Congratulation", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoginPage Loga = new LoginPage();
                    NavigationService.Navigate(Loga);
   
                 }
                 catch (Exception ex)
                 {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                 }

             }
         
          
        }
        private void BackL(object sender, RoutedEventArgs e)
        {
            LoginPage Loga = new LoginPage();
            NavigationService.Navigate(Loga);
        }

        private void FS(object sender, RoutedEventArgs e)
        {
            if(Fpassword.Text == ConfirmP.Password)
            {
                Reg.IsEnabled = true;
                ConfirmP.Background = Brushes.Green;
                ConfirmP.BorderBrush = Brushes.LightGreen;
            }
            else
            {
                Reg.IsEnabled = false;
                ConfirmP.Background = Brushes.LightBlue;
                ConfirmP.BorderBrush = Brushes.Red;
            }
        }
    } 
}
