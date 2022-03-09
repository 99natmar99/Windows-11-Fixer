using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
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

namespace Windows_11_Fixer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            object AppThemeReg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize").GetValue("AppsUseLightTheme");
            string AppTheme = AppThemeReg.ToString();

            if (AppTheme == "1")
            {
                App.Current.Properties["isLight"] = "yes";
                ResourceDictionary newRes = new ResourceDictionary();
                newRes.Source = new Uri("pack://application:,,,/Windows 11 Fixer;component/Dictionaries/LightTheme.xaml", UriKind.Absolute);
                this.Resources.MergedDictionaries.Clear();
                this.Resources.MergedDictionaries.Add(newRes);
            }
            if (AppTheme == "0")
            {
                App.Current.Properties["isLight"] = "no";
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
            App.Current.Properties["isLight"] = "yes";
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("pack://application:,,,/Windows 11 Fixer;component/Dictionaries/LightTheme.xaml", UriKind.Absolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["isLight"] = "no";
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("pack://application:,,,/Windows 11 Fixer;component/Dictionaries/DarkTheme.xaml", UriKind.Absolute);
            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(newRes);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo Link = new ProcessStartInfo("https://github.com/99natmar99/Windows-11-Fixer");
            Link.UseShellExecute = true;
            Process.Start(Link);
        }
    }
}
