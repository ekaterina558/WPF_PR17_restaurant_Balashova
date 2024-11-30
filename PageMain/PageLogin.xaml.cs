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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageCreateAcc());
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = Restaurant17Entities.GetContext().User.FirstOrDefault(x => x.login == txbLogin.Text && x.password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор" + userObj.name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;

                        case 2:
                            MessageBox.Show("Здравствуйте,гость" + userObj.name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;

                    }
                }

            }
            catch (Exception Ex)
            {

                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
