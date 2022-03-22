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
    public partial class PageADD : Page
    {
        
        public PageADD()
        {
            InitializeComponent();

            cmUn.SelectedValuePath = "id_unit"; // путь к значению
            cmUn.DisplayMemberPath = "unit"; // сами значения
            cmUn.ItemsSource = ConnectHelper.obdEnt.UnitOfMea.ToList();

        }

        private void BackL(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new Datagrid());
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            // проверка на пустое и нулевое значение в полях
            if (String.IsNullOrEmpty(name.Text) || String.IsNullOrEmpty(Age.Text) || String.IsNullOrEmpty(Date.Text) || String.IsNullOrEmpty(WorldR.Text) || String.IsNullOrEmpty(NameSport.Text)) 
            {
                MessageBox.Show("заполните поля");
            }
            else
            {
                Athletes atf = new Athletes()
                {
                    FIO = name.Text,
                    age = int.Parse(Age.Text)
                };
                Sport sp = new Sport()
                {
                    record_date = DateTime.Parse(Date.Text),
                    world_rec = float.Parse(WorldR.Text),
                    Sport_name = NameSport.Text
                };

                ConnectHelper.obdEnt.Athletes.Add(atf); // добавление данных
                ConnectHelper.obdEnt.Sport.Add(sp); // добавление данных
                ConnectHelper.obdEnt.SaveChanges();
            } 
        }
    }
}
