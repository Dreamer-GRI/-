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
   
    public partial class PageEdit : Page
    {
        private int ViewID;
       
        public PageEdit(VieWWhole vieW) // вписываем название таблицы и задаём новую переменную
        {
            InitializeComponent();
            ViewID = vieW.id_Athletes; // задаю новому элементу значение ключа  
            Journal.ItemsSource = ConnectHelper.obdEnt.Athletes.Where(x => x.id_Athletes == ViewID).ToList(); // с начала беру значение Athletes и создаю новую переменную x. 
            // Где x это переменная для таблицы Athlets и далее приравниваю x к переменной ViewIDs
        }

        private void BtnBackClick(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new Datagrid());
        }

        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            ConnectHelper.obdEnt.SaveChanges();
        }
    }
}
