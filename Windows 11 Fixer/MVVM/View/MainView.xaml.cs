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

namespace Windows_11_Fixer.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
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
            bool restartRequired = false;

            //Tranfer Assets onto System
            ProcessStartInfo movefile = new ProcessStartInfo("powershell.exe");
            string flocation = Directory.GetCurrentDirectory();
            movefile.Arguments = "Copy-Item -Path '" + flocation + "\\W11F-assets' -Destination 'C:\\Windows\\W11F-assets' -Recurse";
            movefile.CreateNoWindow = true;
            Process.Start(movefile);



            /*---------- Taskbar ----------*/
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
                restartRequired = true;
            }
            else if (Size_Medium.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarSi", "00000001", RegistryValueKind.DWord);
                restartRequired = true;
            }
            else if (Size_Large.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "TaskbarSi", "00000002", RegistryValueKind.DWord);
                restartRequired = true;
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

            //Keyboard Switcher
            if (Keyboard_Hidden.IsChecked == true)
            {
                ProcessStartInfo keySwitcher = new ProcessStartInfo("Powershell.exe");
                keySwitcher.UseShellExecute = true;
                keySwitcher.Arguments = "Set-WinLanguageBarOption -UseLegacySwitchMode -UseLegacyLanguageBar";
                Process.Start(keySwitcher);

                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\CTF\\LangBar", "ShowStatus", "00000003", RegistryValueKind.DWord);
            }
            else if (Keyboard_Visible.IsChecked == true)
            {
                ProcessStartInfo keySwitcher = new ProcessStartInfo("Powershell.exe");
                keySwitcher.UseShellExecute = true;
                keySwitcher.Arguments = "Set-WinLanguageBarOption";
                Process.Start(keySwitcher);

                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\CTF\\LangBar", "ShowStatus", "00000001", RegistryValueKind.DWord);
            }


            /*---------- Start Menu ----------*/
            //Start Menu Layout
            if (StartLayout_Pins.IsSelected == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_Layout", "00000001", RegistryValueKind.DWord);
            }
            else if (StartLayout_Default.IsSelected == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_Layout", "00000000", RegistryValueKind.DWord);
            }
            else if (StartLayout_Recmmendations.IsSelected == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_Layout", "00000002", RegistryValueKind.DWord);
            }


            /*---------- Right-Click Context Menu ----------*/
            //Context Menu Style
            if (Context_Win10.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32", "", "");
                restartRequired = true;
            }
            else if (Context_Win11.IsChecked == true)
            {
                ProcessStartInfo contextdel = new ProcessStartInfo("WT.exe");
                contextdel.UseShellExecute = true;
                contextdel.Arguments = "REG DELETE \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\" /f";
                Process.Start(contextdel);
                restartRequired = true;
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

            //Control Panel Shortcut
            if (CPanel_Add.IsChecked == true)
            {
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Control Panel", "Icon", "control.exe");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Control Panel\\command", "", "rundll32.exe shell32.dll,Control_RunDLL");
            }
            else if (CPanel_Remove.IsChecked == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Control Panel\" /f";
                Process.Start(delreg);
            }

            //Restart Windows Explorer Shortcut
            if (RestartExplorer_Add.IsChecked == true)
            {
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Restart Explorer", "Icon", "explorer.exe");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Restart Explorer", "Position", "Bottom");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Restart Explorer\\command", "", "cmd.exe /c taskkill /f /im explorer.exe & start explorer.exe");
            }
            else if (RestartExplorer_Remove.IsChecked == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Restart Explorer\" /f";
                Process.Start(delreg);
            }

            //Toggle Camera/Microphone Shortcut
            if (ToggleCM_Add.IsChecked == true)
            {
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone", "Icon", "%windir%\\W11F-assets\\icons\\webcam.ico");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone", "SubCommands", "");

                object CStatus = Registry.LocalMachine.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\webcam").GetValue("Value");
                string CameraStatus = CStatus.ToString();

                if (CameraStatus == "Allow")
                {
                    Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\\Shell\\menu1", "MUIVerb", "Toggle Camera Off");
                }
                if (CameraStatus == "Deny")
                {
                    Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\\Shell\\menu1", "MUIVerb", "Toggle Camera On");
                }

                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\\Shell\\menu1", "Icon", "%windir%\\W11F-assets\\icons\\cam.ico");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\\Shell\\menu1\\command", "", "C:\\WINDOWS\\W11F-assets\\scripts\\RunToggleCamAsAdmin.bat");

                object MStatus = Registry.LocalMachine.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone").GetValue("Value");
                string MicStatus = MStatus.ToString();

                if (MicStatus == "Allow")
                {
                    Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\\Shell\\menu2", "MUIVerb", "Toggle Microphone Off");
                }
                if (MicStatus == "Deny")
                {
                    Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\\Shell\\menu2", "MUIVerb", "Toggle Microphone On");
                }

                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\\Shell\\menu2", "Icon", "%windir%\\W11F-assets\\icons\\mic.ico");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\\Shell\\menu2\\command", "", "C:\\WINDOWS\\W11F-assets\\scripts\\RunToggleMicAsAdmin.bat");
            }
            else if (ToggleCM_Remove.IsChecked == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Toggle Camera/Microphone\" /f";
                Process.Start(delreg);
            }

            //Troubleshooters Shortcut


            //Power User Options Shortcut


            //Settings Shortcut
            if (SettingsShortcutCM_Add.IsChecked == true)
            {
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Settings", "Icon", "%windir%\\W11F-assets\\icons\\settings.ico");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Settings", "SettingsURI", "ms-settings:");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Settings\\command", "DelegateExecute", "{556FF0D6-A1EE-49E5-9FA4-90AE116AD744}");
            }
            else if (SettingsShortcutCM_Remove.IsChecked == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Settings\" /f";
                Process.Start(delreg);
            }

            //Disk Cleanup Shortcut
            if (DiskCleanup_Add.IsChecked == true)
            {
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Disk Cleanup", "Icon", "cleanmgr.exe");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Disk Cleanup\\command", "", "cleanmgr.exe");
            }
            else if (DiskCleanup_Remove.IsChecked == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Disk Cleanup\" /f";
                Process.Start(delreg);
            }

            //Batch File as New File Option
            if (NewBatch_NC.IsChecked == true)
            {
                Registry.SetValue("HKEY_CLASSES_ROOT\\.bat\\ShellNew", "NullFile", "");
            }
            if (NewBatch_Remove.IsChecked == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKEY_CLASSES_ROOT\\.bat\\ShellNew\" /f";
                Process.Start(delreg);
            }

            //Task Manager Shortcut
            if (TaskMGR_Add.IsChecked == true)
            {
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Task Manager", "Icon", "Taskmgr.exe");
                Registry.SetValue("HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Task Manager\\command", "", "Taskmgr.exe");
            }
            else if (TaskMGR_Remove.IsChecked == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKEY_CLASSES_ROOT\\DesktopBackground\\Shell\\Task Manager\" /f";
                Process.Start(delreg);
            }


            /*---------- File Explorer ----------*/
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


            /*---------- File and Folder Options ----------*/
            //Hidden Folders
            if (Hidden_Visible.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Hidden", "00000001", RegistryValueKind.DWord);
                restartRequired = true;
            }
            else if (Hidden_Hidden.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Hidden", "00000000", RegistryValueKind.DWord);
                restartRequired = true;
            }

            //File Type Extensions
            if (Extension_Visible.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "HideFileExt", "00000000", RegistryValueKind.DWord);
                restartRequired = true;
            }
            else if (Extension_Hidden.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "HideFileExt", "00000001", RegistryValueKind.DWord);
                restartRequired = true;
            }

            //Shortcut Icon
            if (Shortcut_None.IsChecked == true)
            {
                ProcessStartInfo Pinfo = new ProcessStartInfo("WT.exe");
                Pinfo.UseShellExecute = true;
                Pinfo.Arguments = "REG ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons\" /v 29 /t REG_SZ /d \"%windir%\\W11F-assets\\icons\\blank.ico\" /f";
                Process.Start(Pinfo);
                restartRequired = true;
            }
            else if (Shortcut_Normal.IsChecked == true)
            {
                ProcessStartInfo Pinfo1 = new ProcessStartInfo("WT.exe");
                Pinfo1.UseShellExecute = true;
                Pinfo1.Arguments = "REG ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons\" /v 29 /t REG_SZ /d \"%windir%\\System32\\shell32.dll,-30\" /f";
                Process.Start(Pinfo1);
                restartRequired = true;
            }
            else if (Shortcut_Large.IsChecked == true)
            {
                ProcessStartInfo Pinfo2 = new ProcessStartInfo("WT.exe");
                Pinfo2.UseShellExecute = true;
                Pinfo2.Arguments = "REG ADD \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Icons\" /v 29 /t REG_SZ /d \"%windir%\\System32\\shell32.dll,-16769\" /f";
                Process.Start(Pinfo2);
                restartRequired = true;
            }

            //Use Checkboxes to Select Items
            if (CheckboxesToSelect_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "AutoCheckSelect", "00000000", RegistryValueKind.DWord);
                restartRequired = true;
            }
            else if (CheckboxesToSelect_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "AutoCheckSelect", "00000001", RegistryValueKind.DWord);
                restartRequired = true;
            }


            /*---------- Other ----------*/
            //Allow Windows to Search Online
            if (WSearch_Prohibit.IsChecked == true)
            {
                ProcessStartInfo searchadd = new ProcessStartInfo("WT.exe");
                searchadd.UseShellExecute = true;
                searchadd.Arguments = "REG ADD \"HKCU\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v DisableSearchBoxSuggestions /t REG_DWORD /d \"00000001\" /f";
                Process.Start(searchadd);
                restartRequired = true;
            }
            else if (WSearch_Allow.IsChecked == true)
            {
                ProcessStartInfo searchdel = new ProcessStartInfo("WT.exe");
                searchdel.UseShellExecute = true;
                searchdel.Arguments = "REG DELETE \"HKCU\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /f";
                Process.Start(searchdel);
                restartRequired = true;
            }

            //Widgets Service
            if (WService_Disable.IsChecked == true)
            {
                ProcessStartInfo widgetsService = new ProcessStartInfo("WT.exe");
                widgetsService.UseShellExecute = true;
                widgetsService.Arguments = "REG ADD \"HKLM\\Software\\Policies\\Microsoft\\Dsh\" /v AllowNewsAndInterests /t REG_DWORD /d \"00000000\" /f";
                Process.Start(widgetsService);
                restartRequired = true;
            }
            else if (WService_Enable.IsChecked == true)
            {
                ProcessStartInfo widgetsService = new ProcessStartInfo("WT.exe");
                widgetsService.UseShellExecute = true;
                widgetsService.Arguments = "REG ADD \"HKLM\\Software\\Policies\\Microsoft\\Dsh\" /v AllowNewsAndInterests /t REG_DWORD /d \"00000001\" /f";
                Process.Start(widgetsService);
                restartRequired = true;
            }


            //Allow Screen Savers
            if (ScreenSavers_Prohibit.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Policies\\Microsoft\\Windows\\Control Panel\\Desktop", "ScreenSaveActive", "0");
            }
            else if (ScreenSavers_Allow.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Policies\\Microsoft\\Windows\\Control Panel\\Desktop", "ScreenSaveActive", "1");
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
                if (restartRequired == true)
                {
                    Restart_Popup newwindow = new Restart_Popup();
                    newwindow.Show();
                }
            }


            //Clear Values
            Location_NC.IsChecked = true;
            Size_NC.IsChecked = true;
            Widgets_NC.IsChecked = true;
            Chat_NC.IsChecked = true;
            Keyboard_NC.IsChecked = true;
            StartLayout_NC.IsSelected = true;
            Context_NC.IsChecked = true;
            TakeOwn_NC.IsChecked = true;
            CPanel_NC.IsChecked = true;
            RestartExplorer_NC.IsChecked = true;
            ToggleCM_NC.IsChecked = true;
            //Troubleshooters_NC.IsChecked = true;
            //PowerUserOptions_NC.IsChecked = true;
            SettingsShortcutCM_NC.IsChecked = true;
            DiskCleanup_NC.IsChecked = true;
            NewBatch_NC.IsChecked = true;
            TaskMGR_NC.IsChecked = true;
            Compact_NC.IsChecked = true;
            OpenLocation_NC.IsChecked = true;
            Hidden_NC.IsChecked = true;
            Extension_NC.IsChecked = true;
            Shortcut_NC.IsChecked = true;
            CheckboxesToSelect_NC.IsChecked = true;
            WSearch_NC.IsChecked = true;
            WService_NC.IsChecked = true;
            ScreenSavers_NC.IsChecked = true;
        }
    }
}
