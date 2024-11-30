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
    /// Логика взаимодействия для PageTovar.xaml
    /// </summary>
    public partial class PageTovar : Page
    {
        public PageTovar()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Restaurant17Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DtGridTovar.ItemsSource = Restaurant17Entities.GetContext().Tovar.ToList();
        }
    }
}
