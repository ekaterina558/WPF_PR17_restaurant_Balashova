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
using WPF_PR17_restaurant_Balashova.PageMain;

namespace WPF_PR17_restaurant_Balashova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppFrame.FrameMain = FrmMain; //загрузка фрейма
            AppFrame.FrameMain.Navigate(new PageTovar()); //страница PageTovar
        }

        private void Btn_Avt_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageLogin());
        }

    }
}

