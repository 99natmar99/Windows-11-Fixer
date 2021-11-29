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
using System.Windows.Shapes;

namespace Windows_11_Fixer
{
    /// <summary>
    /// Interaction logic for Restart_Popup.xaml
    /// </summary>
    public partial class Restart_Popup : Window
    {
        public Restart_Popup()
        {
            InitializeComponent();

            string isLight = App.Current.Properties["isLight"].ToString();

            if (isLight == "yes")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("pack://application:,,,/Windows 11 Fixer;component/Dictionaries/LightTheme.xaml", UriKind.Absolute);
                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(newRes);
            }
            else if (isLight == "no")
            {
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("pack://application:,,,/Windows 11 Fixer;component/Dictionaries/DarkTheme.xaml", UriKind.Absolute);
                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(newRes);
            }
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
