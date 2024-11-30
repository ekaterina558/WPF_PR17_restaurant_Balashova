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
using WPF_PR17_restaurant_Balashova.ApplicatonData;

namespace WPF_PR17_restaurant_Balashova.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageTovars.xaml
    /// </summary>
    public partial class PageTovars : Page
    {
        public PageTovars()
        {
            InitializeComponent();
            DtGridTovar.ItemsSource = Restaurant17Entities.GetContext().Tovar.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Restaurant17Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DtGridTovar.ItemsSource = Restaurant17Entities.GetContext().Tovar.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemoving = DtGridTovar.SelectedItems.Cast<Tovar>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {tovarForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Restaurant17Entities.GetContext().Tovar.RemoveRange(tovarForRemoving);
                    Restaurant17Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DtGridTovar.ItemsSource = Restaurant17Entities.GetContext().Tovar.ToList();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message.ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageTovarsAdd(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageTovarsAdd((sender as Button).DataContext as Tovar));
        }
    }
}
