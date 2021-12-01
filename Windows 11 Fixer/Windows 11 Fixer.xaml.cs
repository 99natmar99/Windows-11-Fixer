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
            App.Current.Properties["isLight"] = "yes";
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
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            ProcessStartInfo Link = new ProcessStartInfo(e.Uri.AbsoluteUri);
            Link.UseShellExecute = true;
            Process.Start(Link);
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            string cDirectory = Directory.GetCurrentDirectory();
            string fLocation = cDirectory + "\\SettingsInfo.txt";
            Process.Start("notepad.exe", @fLocation);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var n_installs = 0;
            String id_install = " ";

            //Taskbar Fixes
                //Taskbar Location
                if (Location_Left.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarAl", "00000000", RegistryValueKind.DWord);
                }
                else if (Location_Center.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarAl", "00000001", RegistryValueKind.DWord);
                }

                //Taskbar Size
                if (Size_Small.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarSi", "00000000", RegistryValueKind.DWord);
                }
                else if (Size_Medium.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarSi", "00000001", RegistryValueKind.DWord);
                }
                else if (Size_Large.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarSi", "00000002", RegistryValueKind.DWord);
                }

                //Widgets Button
                if (Widgets_Disable.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarDa", "00000000", RegistryValueKind.DWord);
                }
                else if (Widgets_Enable.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarDa", "00000001", RegistryValueKind.DWord);
                }

                //Chat Button
                if (Chat_Disable.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarMn", "00000000", RegistryValueKind.DWord);
                }
                else if (Chat_Enable.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarMn", "00000001", RegistryValueKind.DWord);
                }

                //Install ElevenClock
                if (ElevenClock_Install.IsChecked == true)
                {
                    n_installs = n_installs + 1;
                    id_install = "SomePythonThings.ElevenClock";
                }

            //Right-Click Menu
                //Context Menu Style
                if (Context_Win10.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32", "", "");
                }
                else if (Context_Win11.IsChecked == true)
                {
                    ProcessStartInfo contextdel = new ProcessStartInfo("WT.exe");
                    contextdel.UseShellExecute = true;
                    contextdel.Arguments = "REG DELETE \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\" /f";
                    Process.Start(contextdel);
                }

                //Take Ownership
                if (TakeOwn_Add.IsChecked == true)
                {
                    string CMDText;
                    CMDText = "/C start reg-files\\ATO.reg";
                    Process.Start("CMD.exe", CMDText);
                }
                else if (TakeOwn_Remove.IsChecked == true)
                {
                    string CMDText1;
                    CMDText1 = "/C start reg-files\\RTO.reg";
                    Process.Start("CMD.exe", CMDText1);
                }

                if (CPanel_Add.IsChecked == true)
                {
                    ProcessStartInfo movefile = new ProcessStartInfo("Powershell.exe");
                    string flocation = Directory.GetCurrentDirectory();
                    movefile.UseShellExecute = true;
                    movefile.Arguments = "Copy-Item " + flocation + "\\icons\\cpanel.ico -Destination C:\\Windows";
                    Process.Start(movefile);

                    System.Threading.Thread.Sleep(500);

                    Registry.SetValue("HKEY_CLASSES_ROOT\\Directory\\Background\\shell\\Control Panel\\command", "", "rundll32.exe shell32.dll,Control_RunDLL");

                    ProcessStartInfo Pinfo = new ProcessStartInfo("WT.exe");
                    Pinfo.UseShellExecute = true;
                    Pinfo.Arguments = "REG ADD \"HKEY_CLASSES_ROOT\\Directory\\Background\\shell\\Control Panel\" /v Icon /t REG_SZ /d \"%windir%\\cpanel.ico\" /f";
                    Process.Start(Pinfo);
                }
                else if (CPanel_Remove.IsChecked == true)
                {
                    ProcessStartInfo cpaneldel = new ProcessStartInfo("WT.exe");
                    cpaneldel.UseShellExecute = true;
                    cpaneldel.Arguments = "REG DELETE \"HKEY_CLASSES_ROOT\\Directory\\Background\\shell\\Control Panel\" /f";
                    Process.Start(cpaneldel);
                }

            //File Explorer
                //Compact View
                if (Compact_Enable.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "UseCompactMode", "00000001", RegistryValueKind.DWord);
                }
                else if (Compact_Disable.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "UseCompactMode", "00000000", RegistryValueKind.DWord);
                }

                //Opening Location
                if (OpenLocation_ThisPC.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "LaunchTo", "00000001", RegistryValueKind.DWord);
                }
                else if (OpenLocation_QA.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "LaunchTo", "00000002", RegistryValueKind.DWord);
                }

            //File and Folder Options
                //Hidden Folders
                if (Hidden_Visible.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Hidden", "00000001", RegistryValueKind.DWord);
                }
                else if (Hidden_Hidden.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Hidden", "00000000", RegistryValueKind.DWord);
                }

                //File Type Extensions
                if (Extension_Visible.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "HideFileExt", "00000000", RegistryValueKind.DWord);
                }
                else if (Extension_Hidden.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "HideFileExt", "00000001", RegistryValueKind.DWord);
                }

                //Shortcut Icon
                if (Shortcut_None.IsChecked == true)
                {
                    ProcessStartInfo movefile = new ProcessStartInfo("powershell.exe");
                    string flocation = Directory.GetCurrentDirectory();
                    movefile.UseShellExecute = true;
                    movefile.Arguments = "Copy-Item " + flocation + "\\icons\\blank.ico -Destination C:\\Windows";
                    Process.Start(movefile);
                    System.Threading.Thread.Sleep(1000);
                    ProcessStartInfo Pinfo = new ProcessStartInfo("WT.exe");
                    Pinfo.UseShellExecute = true;
                    Pinfo.Arguments = "REG ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons\" /v 29 /t REG_SZ /d \"%windir%\\blank.ico\" /f";
                    Process.Start(Pinfo);
                }
                else if (Shortcut_Normal.IsChecked == true)
                {
                    ProcessStartInfo Pinfo1 = new ProcessStartInfo("WT.exe");
                    Pinfo1.UseShellExecute = true;
                    Pinfo1.Arguments = "REG ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons\" /v 29 /t REG_SZ /d \"%windir%\\System32\\shell32.dll,-30\" /f";
                    Process.Start(Pinfo1);
                }
                else if (Shortcut_Large.IsChecked == true)
                {
                    ProcessStartInfo Pinfo2 = new ProcessStartInfo("WT.exe");
                    Pinfo2.UseShellExecute = true;
                    Pinfo2.Arguments = "REG ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons\" /v 29 /t REG_SZ /d \"%windir%\\System32\\shell32.dll,-16769\" /f";
                    Process.Start(Pinfo2);
                }

            //Install Internet Browser
                //Mozilla Firefox
                if (Firefox_Install.IsChecked == true)
                {
                    n_installs = n_installs + 1;
                    id_install = "Mozilla.Firefox";
                }

                //Google Chrome
                if (Chrome_Install.IsChecked == true)
                {
                    n_installs = n_installs + 1;
                    id_install = "Google.Chrome";
                }
            
            //Recommended Software
                //StartAllBack
                if (StartAllBack_Install.IsChecked == true)
                {
                    n_installs = n_installs + 1;
                }
                
                //Start 11
                if (Start11_Install.IsChecked == true)
                {
                    ProcessStartInfo installStart11 = new ProcessStartInfo("https://cdn.stardock.us/downloads/public/software/start/Start11_setup.exe");
                    installStart11.UseShellExecute = true;
                    Process.Start(installStart11);
                }

                //Microsoft PowerToys
                if (PowerToys_Install.IsChecked == true)
                {
                    n_installs = n_installs + 1;
                    id_install = "Microsoft.PowerToys";
                }

                //ThisIsWin11
                if (TIW11_Install.IsChecked == true)
                {
                    ProcessStartInfo installTIW11 = new ProcessStartInfo("https://github.com/builtbybel/ThisIsWin11/releases/download/0.93.0/TIW11.zip");
                    installTIW11.UseShellExecute = true;
                    Process.Start(installTIW11);
                }

            //Windows Settings
                //Suggested Security Settings
                if (Ssettings_Apply.IsChecked == true)
                {
                    //Notifications Settings
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement", "ScoobeSystemSettingEnabled", "00000000", RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-338389Enabled", "00000000", RegistryValueKind.DWord);

                    //Privacy & Security -> General Settings
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", "Enabled", "00000000", RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\AdvertisingInfo", "Value", "00000000", RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-353696Enabled", "00000000", RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-353694Enabled", "00000000", RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-338393Enabled", "00000000", RegistryValueKind.DWord);

                    //Privacy & Security -> Diagnostics & Feedback Settings
                    ProcessStartInfo P1 = new ProcessStartInfo("WT.exe");
                    P1.UseShellExecute = true;
                    P1.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d \"00000001\" /f";
                    Process.Start(P1);
                    ProcessStartInfo P2 = new ProcessStartInfo("WT.exe");
                    P2.UseShellExecute = true;
                    P2.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v MaxTelemetryAllowed /t REG_DWORD /d \"00000001\" /f";
                    Process.Start(P2);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Diagnostics\\DiagTrack", "ShowedToastAtLevel", "00000001", RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Privacy", "TailoredExperiencesWithDiagnosticDataEnabled", "00000000", RegistryValueKind.DWord);
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Siuf\\Rules", "NumberOfSIUFInPeriod", "00000000", RegistryValueKind.DWord);
                }

                //Optional Privacy Settings
                if (Osettings_Apply.IsChecked == true)
                {
                    //Location Services
                    ProcessStartInfo P1 = new ProcessStartInfo("WT.exe");
                    P1.UseShellExecute = true;
                    P1.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\location\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(P1);
                    ProcessStartInfo P2 = new ProcessStartInfo("WT.exe");
                    P2.UseShellExecute = true;
                    P2.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Sensor\\Overrides\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}\" /v SensorPermissionState /t REG_DWORD /d \"00000000\" /f";
                    Process.Start(P2);

                    //Camera Access
                    ProcessStartInfo camera = new ProcessStartInfo("WT.exe");
                    camera.UseShellExecute = true;
                    camera.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\webcam\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(camera);

                    //Microphone Access
                    ProcessStartInfo mic = new ProcessStartInfo("WT.exe");
                    mic.UseShellExecute = true;
                    mic.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(mic);

                    //Voice Activation
                    Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\UserPreferenceForAllApps", "AgentActivationEnabled", "00000000", RegistryValueKind.DWord);

                    //Notification Access
                    ProcessStartInfo notif = new ProcessStartInfo("WT.exe");
                    notif.UseShellExecute = true;
                    notif.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(notif);

                    //Account Info Access
                    ProcessStartInfo account = new ProcessStartInfo("WT.exe");
                    account.UseShellExecute = true;
                    account.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userAccountInformation\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(account);

                    //Contacts Access
                    ProcessStartInfo contacts = new ProcessStartInfo("WT.exe");
                    contacts.UseShellExecute = true;
                    contacts.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\contacts\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(contacts);

                    //Phone Calls Access
                    ProcessStartInfo phonecall = new ProcessStartInfo("WT.exe");
                    phonecall.UseShellExecute = true;
                    phonecall.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCall\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(phonecall);

                    //Call History Access
                    ProcessStartInfo phonehistory = new ProcessStartInfo("WT.exe");
                    phonehistory.UseShellExecute = true;
                    phonehistory.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCallHistory\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(phonehistory);

                    //Tasks Access
                    ProcessStartInfo tasks = new ProcessStartInfo("WT.exe");
                    tasks.UseShellExecute = true;
                    tasks.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userDataTasks\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(tasks);

                    //Messaging Access
                    ProcessStartInfo chat = new ProcessStartInfo("WT.exe");
                    chat.UseShellExecute = true;
                    chat.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\chat\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(chat);

                    //Radio Control Access
                    ProcessStartInfo radios = new ProcessStartInfo("WT.exe");
                    radios.UseShellExecute = true;
                    radios.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\radios\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(radios);

                    //Communicate with Unpaired Devices
                    ProcessStartInfo bsync = new ProcessStartInfo("WT.exe");
                    bsync.UseShellExecute = true;
                    bsync.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\bluetoothSync\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(bsync);

                    //App Diagnostic Access
                    ProcessStartInfo diag = new ProcessStartInfo("WT.exe");
                    diag.UseShellExecute = true;
                    diag.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics\" /v Value /t REG_SZ /d \"Deny\" /f";
                    Process.Start(diag);
                }

                //System Theme
                if (STheme_Dark.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "SystemUsesLightTheme", "00000000", RegistryValueKind.DWord);
                }
                else if (STheme_Light.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "SystemUsesLightTheme", "00000001", RegistryValueKind.DWord);
                }

                //Application Theme
                if (ATheme_Dark.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", "00000000", RegistryValueKind.DWord);
                }
                else if (ATheme_Light.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", "00000001", RegistryValueKind.DWord);
                }

                //System Transparency
                if (Transparency_Disable.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "EnableTransparency", "00000000", RegistryValueKind.DWord);
                }
                else if (Transparency_Enable.IsChecked == true)
                {
                    Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "EnableTransparency", "00000001", RegistryValueKind.DWord);
                }

            //Other
                //Allow Windows to Search Online
                if (WSearch_Prohibit.IsChecked == true)
                {
                    ProcessStartInfo searchadd = new ProcessStartInfo("WT.exe");
                    searchadd.UseShellExecute = true;
                    searchadd.Arguments = "REG ADD \"HKCU\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v DisableSearchBoxSuggestions /t REG_DWORD /d \"00000001\" /f";
                    Process.Start(searchadd);
                }
                else if (WSearch_Allow.IsChecked == true)
                {
                    ProcessStartInfo searchdel = new ProcessStartInfo("WT.exe");
                    searchdel.UseShellExecute = true;
                    searchdel.Arguments = "REG DELETE \"HKCU\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /f";
                    Process.Start(searchdel);
                }

                //Uninstall Cortana
                if (Cortana_Uninstall.IsChecked == true)
                {
                    ProcessStartInfo delCortana = new ProcessStartInfo("WT.exe");
                    delCortana.UseShellExecute = true;
                    delCortana.Arguments = "Get-AppxPackage Microsoft.549981C3F5F10 | Remove-AppxPackage";
                    Process.Start(delCortana);
                }

                //Widgets Service
                if (WService_Disable.IsChecked == true)
                {
                    ProcessStartInfo widgetsService = new ProcessStartInfo("WT.exe");
                    widgetsService.UseShellExecute = true;
                    widgetsService.Arguments = "REG ADD \"HKLM\\Software\\Policies\\Microsoft\\Dsh\" /v AllowNewsAndInterests /t REG_DWORD /d \"00000000\" /f";
                    Process.Start(widgetsService);
                }
                else if (WService_Enable.IsChecked == true)
                {
                    ProcessStartInfo widgetsService = new ProcessStartInfo("WT.exe");
                    widgetsService.UseShellExecute = true;
                    widgetsService.Arguments = "REG ADD \"HKLM\\Software\\Policies\\Microsoft\\Dsh\" /v AllowNewsAndInterests /t REG_DWORD /d \"00000001\" /f";
                    Process.Start(widgetsService);
                }

            //Install Software
            if (n_installs == 1)
            {
                if (StartAllBack_Install.IsChecked == true)
                {
                    ProcessStartInfo installApp = new ProcessStartInfo("WT.exe");
                    installApp.UseShellExecute = true;
                    installApp.Arguments = "winget install StartAllBack ";
                    Process.Start(installApp);
                }
                else
                {
                    ProcessStartInfo installApp = new ProcessStartInfo("WT.exe");
                    installApp.UseShellExecute = true;
                    installApp.Arguments = "winget install -e --id " + id_install;
                    Process.Start(installApp);
                }
            }
            else if (n_installs > 1)
            {
                if (ElevenClock_Install.IsChecked == true)
                {
                    ProcessStartInfo installElevenClock = new ProcessStartInfo("Powershell.exe");
                    installElevenClock.UseShellExecute = false;
                    installElevenClock.Arguments = "winget install -e --id SomePythonThings.ElevenClock";
                    Process.Start(installElevenClock).WaitForExit();
                }

                if (Firefox_Install.IsChecked == true)
                {
                    ProcessStartInfo installFirefox = new ProcessStartInfo("Powershell.exe");
                    installFirefox.UseShellExecute = false;
                    installFirefox.Arguments = "winget install -e --id Mozilla.Firefox";
                    Process.Start(installFirefox).WaitForExit();
                }

                if (Chrome_Install.IsChecked == true)
                {
                    ProcessStartInfo installChrome = new ProcessStartInfo("Powershell.exe");
                    installChrome.UseShellExecute = false;
                    installChrome.Arguments = "winget install -e --id Google.Chrome";
                    Process.Start(installChrome).WaitForExit();
                }

                if (StartAllBack_Install.IsChecked == true)
                {
                    ProcessStartInfo installChrome = new ProcessStartInfo("Powershell.exe");
                    installChrome.UseShellExecute = false;
                    installChrome.Arguments = "winget install StartAllBack";
                    Process.Start(installChrome).WaitForExit();
                }

                if (PowerToys_Install.IsChecked == true)
                {
                    ProcessStartInfo installChrome = new ProcessStartInfo("Powershell.exe");
                    installChrome.UseShellExecute = false;
                    installChrome.Arguments = "winget install -e --id Microsoft.PowerToys";
                    Process.Start(installChrome).WaitForExit();
                }
            }

            //Initiate Restart Popup
            bool isWindowOpen = false;

            foreach (Window w in Application.Current.Windows)
            {
                if (w is Restart_Popup)
                {
                    isWindowOpen = true;
                    w.Activate();
                }
            }

            if (!isWindowOpen)
            {
                Restart_Popup newwindow = new Restart_Popup();
                newwindow.Show();
            }

            //Clear Values
            Location_NC.IsChecked = true;
            Size_NC.IsChecked = true;
            Widgets_NC.IsChecked = true;
            Chat_NC.IsChecked = true;
            ElevenClock_NC.IsChecked = true;
            Context_NC.IsChecked = true;
            TakeOwn_NC.IsChecked = true;
            CPanel_NC.IsChecked = true;
            Compact_NC.IsChecked = true;
            OpenLocation_NC.IsChecked = true;
            Hidden_NC.IsChecked = true;
            Extension_NC.IsChecked = true;
            Shortcut_NC.IsChecked = true;
            Firefox_NC.IsChecked = true;
            Chrome_NC.IsChecked = true;
            StartAllBack_NC.IsChecked = true;
            Start11_NC.IsChecked = true;
            PowerToys_NC.IsChecked = true;
            TIW11_NC.IsChecked = true;
            Ssettings_NC.IsChecked = true;
            Osettings_NC.IsChecked = true;
            STheme_NC.IsChecked = true;
            ATheme_NC.IsChecked = true;
            Transparency_NC.IsChecked = true;
            WSearch_NC.IsChecked = true;
            Cortana_NC.IsChecked = true;
            WService_NC.IsChecked = true;
            
        }

    }
}
