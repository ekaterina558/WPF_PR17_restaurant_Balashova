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
    /// Логика взаимодействия для PageTovarsAdd.xaml
    /// </summary>
    public partial class PageTovarsAdd : Page
    {   private Tovar _currentTovar = new Tovar();
        public PageTovarsAdd(Tovar selectedTovar)
        {
            InitializeComponent();
            if (selectedTovar != null)
                _currentTovar = selectedTovar;
            DataContext = _currentTovar;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder err0rs = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTovar.naimenov))
                err0rs.AppendLine("Укажите название товара");
            if (_currentTovar.kolichestvo <= 0)
                err0rs.AppendLine("Количество товара не может быть меньше или равно 0");
            if (_currentTovar.cena <= 0)
                err0rs.AppendLine("Цена не может быть меньше или равно 0");

            if (err0rs.Length > 0)
            {
                MessageBox.Show(err0rs.ToString());
                return;
            }
            //добавление
            if (_currentTovar.ID == 0)
                Restaurant17Entities.GetContext().Tovar.Add(_currentTovar);

            //обработка вариант выпада/записи данных
            try
            {
                Restaurant17Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
