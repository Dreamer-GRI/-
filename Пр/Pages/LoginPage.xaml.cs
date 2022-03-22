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

    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }
        private void btnEnter(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = ConnectHelper.obdEnt.USERS.FirstOrDefault(x => x.Login.ToLower() == texLog.Text.ToLower() && x.Password == texPas.Password);
                if (userObj == null)
                {
                    MessageBox.Show("такого пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    FrameApp.frmobj.Navigate(new Pages.Datagrid());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical damage" + ex.Message.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
