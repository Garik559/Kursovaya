using Obuv1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Obuv1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            listView.ItemsSource = AppData.db.Shoes.ToList(); //передаем в listView информацию из таблицы Shoes
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Window1 window1 = new Window1((int)((FrameworkElement)sender).Tag); //при нажатии кнопки создается окно и передается в окно Tag
            this.Close();
            window1.Show();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e) // фильтрация по названию обуви
        {
            listView.ItemsSource = AppData.db.Shoes.Where(item => item.Name_ == TBoxSearch.Text || item.Name_.Contains(TBoxSearch.Text)).ToList();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e) // фильтрация по типам обуви (Все, мужская, женская, детская)
        {
            var current = AppData.db.Shoes.ToList();

            if (ComboType.SelectedItem == All)
            {
                current = AppData.db.Shoes.ToList();
            }
            if (ComboType.SelectedItem == Man)
            {
                current = AppData.db.Shoes.Where(item => item.Type_ == Man.Text).ToList();
            }
            if (ComboType.SelectedItem == Woman)
            {
                current = AppData.db.Shoes.Where(item => item.Type_ == Woman.Text).ToList();
            }
            if(ComboType.SelectedItem == Children)
            {
                current = AppData.db.Shoes.Where(item => item.Type_ == Children.Text).ToList();
            }
            listView.ItemsSource = current;
           
        }
    }
}
