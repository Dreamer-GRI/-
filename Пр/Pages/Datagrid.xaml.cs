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
using Пр.Pages;

namespace Пр.Pages
{
    public partial class Datagrid : Page
    {
        public Datagrid()
        {
            InitializeComponent();
            dgData.ItemsSource  = ConnectHelper.obdEnt.VieWWhole.ToList(); // !
            cmb.SelectedValuePath = "id_Athletes"; 
            cmb.DisplayMemberPath = "FIO";
            cmb.ItemsSource = ConnectHelper.obdEnt.Athletes.ToList();
        }

        private void BackT(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new LoginPage());
        }

        private void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int FIOid = (int)cmb.SelectedValue;
            dgData.ItemsSource = ConnectHelper.obdEnt.VieWWhole.Where(x => x.id_Athletes == FIOid).ToList();
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new PageADD());
        }

        private void btnClickEd(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new PageEdit((sender as Button).DataContext as VieWWhole));
        }
    }
}
