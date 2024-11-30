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
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageTovars());
        }

        private void psbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psbPass.Password != txbPass.Text)
            {
                btnBack.IsEnabled = false;
                psbPass.Background = Brushes.LightCoral;
                psbPass.BorderBrush = Brushes.Red;
            }
            else
            {
                btnBack.IsEnabled = true;
                psbPass.Background = Brushes.LightGreen;
                psbPass.BorderBrush = Brushes.Green;

            }

        }

        private void btnBack_Click_1(object sender, RoutedEventArgs e)
        {
            //проверяем есть ли такой же пользователь 
            if (Restaurant17Entities.GetContext().User.Count(X => X.login == txbLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // если прошли проверку логина, записываем нового пользователя с ролью 2
            try
            {
                User userObj = new User()
                {
                    login = txbLogin.Text, //получаем данные логина
                    name = txbName.Text,// получаем  данные имени пользователя
                    password = txbPass.Text,// получаем проль

                };
                Restaurant17Entities.GetContext().User.Add(userObj);
                Restaurant17Entities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {

                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnBack_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.GoBack();
        }
    }
}
