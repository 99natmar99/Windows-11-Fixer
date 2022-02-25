using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_11_Fixer.Core;

namespace Windows_11_Fixer.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand SettingsViewCommand { get; set; }

        public RelayCommand UninstallViewCommand { get; set; }

        public RelayCommand InstallViewCommand { get; set; }

        public HomeViewModel MainVM{ get; set; }

        public SettingsViewModel SettingsVM { get; set; }

        public UninstallViewModel UninstallVM { get; set; }

        public InstallViewModel InstallVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            MainVM = new HomeViewModel();
            SettingsVM = new SettingsViewModel();
            UninstallVM = new UninstallViewModel();
            InstallVM = new InstallViewModel();
            CurrentView = MainVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = MainVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

            UninstallViewCommand = new RelayCommand(o =>
            {
                CurrentView = UninstallVM;
            });

            InstallViewCommand = new RelayCommand(o =>
            {
                CurrentView = InstallVM;
            });
        }
    }
}
