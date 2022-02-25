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
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*---------- Notifications ----------*/
            //Notifications
            if (Notifications_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", "ToastEnabled", "00000000", RegistryValueKind.DWord);

                ProcessStartInfo restartService = new ProcessStartInfo("powershell.exe");
                restartService.Arguments = "Restart-Service -DisplayName 'Windows Push Notifications User Service*'";
                restartService.CreateNoWindow = true;
                Process.Start(restartService);
            }
            else if (Notifications_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\PushNotifications", "ToastEnabled", "00000001", RegistryValueKind.DWord);

                ProcessStartInfo restartService = new ProcessStartInfo("powershell.exe");
                restartService.Arguments = "Restart-Service -DisplayName 'Windows Push Notifications User Service*'";
                restartService.CreateNoWindow = true;
                Process.Start(restartService);
            }

            //Offer Suggestions
            if (Suggestions_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement", "ScoobeSystemSettingEnabled", "00000000", RegistryValueKind.DWord);
            }
            else if (Suggestions_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\UserProfileEngagement", "ScoobeSystemSettingEnabled", "00000001", RegistryValueKind.DWord);
            }

            //Get Windows Tips
            if (Tips_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-338389Enabled", "00000000", RegistryValueKind.DWord);
            }
            else if (Tips_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-338389Enabled", "00000001", RegistryValueKind.DWord);
            }


            /*---------- Storage ----------*/
            //Storage Sense
            if (StorageSense_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\StorageSense\\Parameters\\StoragePolicy", "01", "00000000", RegistryValueKind.DWord);
            }
            else if (StorageSense_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\StorageSense\\Parameters\\StoragePolicy", "01", "00000001", RegistryValueKind.DWord);
            }


            /*---------- Clipboard ----------*/
            //Clipboard History
            if (Clipboard_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Clipboard", "EnableClipboardHistory", "00000001", RegistryValueKind.DWord);
            }
            else if (Clipboard_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Clipboard", "EnableClipboardHistory", "00000000", RegistryValueKind.DWord);
            }


            /*---------- Colors ----------*/
            //Windows Theme
            if (WinTheme_Dark.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "SystemUsesLightTheme", "00000000", RegistryValueKind.DWord);
            }
            else if (WinTheme_Light.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "SystemUsesLightTheme", "00000001", RegistryValueKind.DWord);
            }

            //Application Theme
            if (AppTheme_Dark.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", "00000000", RegistryValueKind.DWord);
            }
            else if (AppTheme_Light.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", "00000001", RegistryValueKind.DWord);
            }

            //Transparency Effects
            if (Transparency_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "EnableTransparency", "00000000", RegistryValueKind.DWord);
            }
            else if (Transparency_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "EnableTransparency", "00000001", RegistryValueKind.DWord);
            }


            /*---------- Start ----------*/
            //Show Recently Opened Items
            if (RecentlyOpened_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackDocs", "00000000", RegistryValueKind.DWord);
            }
            if (RecentlyOpened_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackDocs", "00000001", RegistryValueKind.DWord);
            }


            /*---------- Gaming ----------*/
            //Game Mode
            if (GameMode_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\GameBar", "AutoGameModeEnabled", "00000000", RegistryValueKind.DWord);
            }
            else if (GameMode_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\GameBar", "AutoGameModeEnabled", "00000001", RegistryValueKind.DWord);
            }



            /*---------- General ----------*/
            //Let Apps Show Personalized Ads
            if (PersonalizedAds_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", "Enabled", "00000000", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\AdvertisingInfo", "Value", "00000000", RegistryValueKind.DWord);
            }
            else if (PersonalizedAds_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", "Enabled", "00000001", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\AdvertisingInfo", "Value", "00000001", RegistryValueKind.DWord);
            }

            //Allow Websites Access to Lnguage List
            if (LanguageList_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\International\\User Profile", "HttpAcceptLanguageOptOut", "00000001", RegistryValueKind.DWord);

                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKCU\\Software\\Microsoft\\Internet Explorer\\International\" /v AcceptLanguage /f";
                Process.Start(delreg);
            }

            //Improve Search by Tracking App Launches
            if (ImproveSearch_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackProgs", "00000000", RegistryValueKind.DWord);
            }
            else if (ImproveSearch_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Start_TrackProgs", "00000001", RegistryValueKind.DWord);
            }

            //Show Suggest Content in Settings
            if (ShowSuggested_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-353696Enabled", "00000000", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-353694Enabled", "00000000", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-338393Enabled", "00000000", RegistryValueKind.DWord);
            }
            else if (ShowSuggested_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-353696Enabled", "00000001", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-353694Enabled", "00000001", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager", "SubscribedContent-338393Enabled", "00000001", RegistryValueKind.DWord);
            }


            /*---------- Speech ----------*/
            //Online Speech Recognition
            if (SpeechRecognition_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Speech_OneCore\\Settings\\OnlineSpeechPrivacy", "HasAccepted", "00000000", RegistryValueKind.DWord);
            }
            else if (SpeechRecognition_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Speech_OneCore\\Settings\\OnlineSpeechPrivacy", "HasAccepted", "00000001", RegistryValueKind.DWord);
            }


            /*---------- Inking and Typing ----------*/
            //Personal Inking and Typing Dictionary
            if (Dictionary_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\InkingAndTypingPersonalization", "Value", "00000000", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\InputPersonalization", "RestrictImplicitInkCollection", "00000001", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\InputPersonalization", "RestrictImplicitTextCollection", "00000001", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Personalization\\Settings", "AcceptedPrivacyPolicy", "00000000", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\InputPersonalization\\TrainedDataStore", "HarvestContacts", "0000000", RegistryValueKind.DWord);
            }
            else if (Dictionary_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\InkingAndTypingPersonalization", "Value", "00000001", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\InputPersonalization", "RestrictImplicitInkCollection", "00000000", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\InputPersonalization", "RestrictImplicitTextCollection", "00000000", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Personalization\\Settings", "AcceptedPrivacyPolicy", "00000001", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\InputPersonalization\\TrainedDataStore", "HarvestContacts", "0000001", RegistryValueKind.DWord);
            }


            /*---------- Diagnostics and Feedback ----------*/
            //Send Optional Diagnostic Data
            if (OptionalData_Disable.IsChecked == true)
            {
                ProcessStartInfo P1 = new ProcessStartInfo("WT.exe");
                P1.UseShellExecute = true;
                P1.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d \"00000001\" /f";
                Process.Start(P1);
                ProcessStartInfo P2 = new ProcessStartInfo("WT.exe");
                P2.UseShellExecute = true;
                P2.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v MaxTelemetryAllowed /t REG_DWORD /d \"00000001\" /f";
                Process.Start(P2);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Diagnostics\\DiagTrack", "ShowedToastAtLevel", "00000001", RegistryValueKind.DWord);
            }
            else if (OptionalData_Enable.IsChecked == true)
            {
                ProcessStartInfo P1 = new ProcessStartInfo("WT.exe");
                P1.UseShellExecute = true;
                P1.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v AllowTelemetry /t REG_DWORD /d \"00000003\" /f";
                Process.Start(P1);
                ProcessStartInfo P2 = new ProcessStartInfo("WT.exe");
                P2.UseShellExecute = true;
                P2.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection\" /v MaxTelemetryAllowed /t REG_DWORD /d \"00000003\" /f";
                Process.Start(P2);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Diagnostics\\DiagTrack", "ShowedToastAtLevel", "00000003", RegistryValueKind.DWord);
            }

            //Send Inking and Typing Data
            if (TypingData_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Input\\TIPC", "Enabled", "00000000", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\ImproveInkingAndTyping", "Value", "00000000", RegistryValueKind.DWord);
            }
            else if (TypingData_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Input\\TIPC", "Enabled", "00000001", RegistryValueKind.DWord);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\ImproveInkingAndTyping", "Value", "00000001", RegistryValueKind.DWord);
            }

            //Tailored Experience
            if (Tailored_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Privacy", "TailoredExperiencesWithDiagnosticDataEnabled", "00000000", RegistryValueKind.DWord);
            }
            else if (Tailored_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Privacy", "TailoredExperiencesWithDiagnosticDataEnabled", "00000001", RegistryValueKind.DWord);
            }

            //Feedback Frequency
            if (Feedback_Auto.IsSelected == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKCU\\Software\\Microsoft\\Siuf\\Rules\" /v NumberOfSIUFInPeriod  /f";
                Process.Start(delreg);

                ProcessStartInfo delreg1 = new ProcessStartInfo("WT.exe");
                delreg1.UseShellExecute = true;
                delreg1.Arguments = "REG DELETE \"HKCU\\Software\\Microsoft\\Siuf\\Rules\" /v PeriodInNanoSeconds /f";
                Process.Start(delreg1);
            }
            else if (Feedback_Always.IsSelected == true)
            {
                ProcessStartInfo delreg = new ProcessStartInfo("WT.exe");
                delreg.UseShellExecute = true;
                delreg.Arguments = "REG DELETE \"HKCU\\Software\\Microsoft\\Siuf\\Rules\" /v NumberOfSIUFInPeriod  /f";
                Process.Start(delreg);

                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Siuf\\Rules", "PeriodInNanoSeconds", "100000000", RegistryValueKind.QWord);
            }
            else if (Feedback_Daily.IsSelected == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Siuf\\Rules", "NumberOfSIUFInPeriod", "1", RegistryValueKind.DWord);

                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Siuf\\Rules", "PeriodInNanoSeconds", "864000000000", RegistryValueKind.QWord);
            }
            else if (Feedback_Weekly.IsSelected == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Siuf\\Rules", "NumberOfSIUFInPeriod", "1", RegistryValueKind.DWord);

                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Siuf\\Rules", "PeriodInNanoSeconds", "6048000000000", RegistryValueKind.QWord);
            }
            else if (Feedback_Never.IsSelected == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Siuf\\Rules", "NumberOfSIUFInPeriod", "0", RegistryValueKind.DWord);

                ProcessStartInfo delreg1 = new ProcessStartInfo("WT.exe");
                delreg1.UseShellExecute = true;
                delreg1.Arguments = "REG DELETE \"HKCU\\Software\\Microsoft\\Siuf\\Rules\" /v PeriodInNanoSeconds /f";
                Process.Start(delreg1);
            }


            /*---------- Search Permissions ----------*/
            //Safe Search
            if (SafeSearch_Strict.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings", "SafeSearchMode", "00000002", RegistryValueKind.DWord);
            }
            else if (SafeSearch_Moderate.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings", "SafeSearchMode", "00000001", RegistryValueKind.DWord);
            }
            else if (SafeSearch_Off.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings", "SafeSearchMode", "00000000", RegistryValueKind.DWord);
            }

            //Store Search History
            if (SearchHistory_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings", "IsDeviceSearchHistoryEnabled", "00000000", RegistryValueKind.DWord);
            }
            else if (SearchHistory_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings", "IsDeviceSearchHistoryEnabled", "00000001", RegistryValueKind.DWord);
            }


            /*---------- App Permissions ----------*/
            //Location Services
            if (AP_Location_Disable.IsChecked == true)
            {
                ProcessStartInfo P1 = new ProcessStartInfo("WT.exe");
                P1.UseShellExecute = true;
                P1.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\location\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(P1);
                ProcessStartInfo P2 = new ProcessStartInfo("WT.exe");
                P2.UseShellExecute = true;
                P2.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Sensor\\Overrides\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}\" /v SensorPermissionState /t REG_DWORD /d \"00000000\" /f";
                Process.Start(P2);
            }
            else if (AP_Location_Enable.IsChecked == true)
            {
                ProcessStartInfo P1 = new ProcessStartInfo("WT.exe");
                P1.UseShellExecute = true;
                P1.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\location\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(P1);
                ProcessStartInfo P2 = new ProcessStartInfo("WT.exe");
                P2.UseShellExecute = true;
                P2.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Sensor\\Overrides\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}\" /v SensorPermissionState /t REG_DWORD /d \"00000001\" /f";
                Process.Start(P2);
            }

            //Camera Access
            if (AP_Camera_Disable.IsChecked == true)
            {
                ProcessStartInfo camera = new ProcessStartInfo("WT.exe");
                camera.UseShellExecute = true;
                camera.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\webcam\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(camera);
            }
            else if (AP_Camera_Enable.IsChecked == true)
            {
                ProcessStartInfo camera = new ProcessStartInfo("WT.exe");
                camera.UseShellExecute = true;
                camera.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\webcam\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(camera);
            }

            //Microphone Access
            if (AP_Microphone_Disable.IsChecked == true)
            {
                ProcessStartInfo mic = new ProcessStartInfo("WT.exe");
                mic.UseShellExecute = true;
                mic.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(mic);
            }
            else if (AP_Microphone_Enable.IsChecked == true)
            {
                ProcessStartInfo mic = new ProcessStartInfo("WT.exe");
                mic.UseShellExecute = true;
                mic.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\microphone\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(mic);
            }

            //Voice Activation
            if (AP_VActivation_Disable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\UserPreferenceForAllApps", "AgentActivationEnabled", "00000000", RegistryValueKind.DWord);
            }
            else if (AP_VActivation_Enable.IsChecked == true)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\UserPreferenceForAllApps", "AgentActivationEnabled", "00000001", RegistryValueKind.DWord);
            }

            //Notifications Access
            if (AP_Notifications_Disable.IsChecked == true)
            {
                ProcessStartInfo notif = new ProcessStartInfo("WT.exe");
                notif.UseShellExecute = true;
                notif.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(notif);
            }
            else if (AP_Notifications_Enable.IsChecked == true)
            {
                ProcessStartInfo notif = new ProcessStartInfo("WT.exe");
                notif.UseShellExecute = true;
                notif.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(notif);
            }

            //Account Information Access
            if (AP_AInfo_Disable.IsChecked == true)
            {
                ProcessStartInfo account = new ProcessStartInfo("WT.exe");
                account.UseShellExecute = true;
                account.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userAccountInformation\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(account);
            }
            else if (AP_AInfo_Enable.IsChecked == true)
            {
                ProcessStartInfo account = new ProcessStartInfo("WT.exe");
                account.UseShellExecute = true;
                account.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userAccountInformation\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(account);
            }

            //Contacts Access
            if (AP_Contacts_Disable.IsChecked == true)
            {
                ProcessStartInfo contacts = new ProcessStartInfo("WT.exe");
                contacts.UseShellExecute = true;
                contacts.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\contacts\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(contacts);
            }
            else if (AP_Contacts_Enable.IsChecked == true)
            {
                ProcessStartInfo contacts = new ProcessStartInfo("WT.exe");
                contacts.UseShellExecute = true;
                contacts.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\contacts\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(contacts);
            }

            // Calendar Access
            if (AP_Calendar_Disable.IsChecked == true)
            {
                ProcessStartInfo calendar = new ProcessStartInfo("WT.exe");
                calendar.UseShellExecute = true;
                calendar.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appointments\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(calendar);
            }
            else if (AP_Calendar_Enable.IsChecked == true)
            {
                ProcessStartInfo calendar = new ProcessStartInfo("WT.exe");
                calendar.UseShellExecute = true;
                calendar.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appointments\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(calendar);
            }

            //Phone Call Access
            if (AP_PCall_Disable.IsChecked == true)
            {
                ProcessStartInfo phonecall = new ProcessStartInfo("WT.exe");
                phonecall.UseShellExecute = true;
                phonecall.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCall\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(phonecall);
            }
            else if (AP_PCall_Enable.IsChecked == true)
            {
                ProcessStartInfo phonecall = new ProcessStartInfo("WT.exe");
                phonecall.UseShellExecute = true;
                phonecall.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCall\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(phonecall);
            }

            //Call History Access
            if (AP_CHistory_Disable.IsChecked == true)
            {
                ProcessStartInfo phonehistory = new ProcessStartInfo("WT.exe");
                phonehistory.UseShellExecute = true;
                phonehistory.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCallHistory\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(phonehistory);
            }
            else if (AP_CHistory_Enable.IsChecked == true)
            {
                ProcessStartInfo phonehistory = new ProcessStartInfo("WT.exe");
                phonehistory.UseShellExecute = true;
                phonehistory.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCallHistory\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(phonehistory);
            }

            //Email Access
            if (AP_Email_Disable.IsChecked == true)
            {
                ProcessStartInfo phonehistory = new ProcessStartInfo("WT.exe");
                phonehistory.UseShellExecute = true;
                phonehistory.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\email\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(phonehistory);
            }
            else if (AP_Email_Enable.IsChecked == true)
            {
                ProcessStartInfo phonehistory = new ProcessStartInfo("WT.exe");
                phonehistory.UseShellExecute = true;
                phonehistory.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\email\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(phonehistory);
            }

            //Tasks Access
            if (AP_Tasks_Disable.IsChecked == true)
            {
                ProcessStartInfo tasks = new ProcessStartInfo("WT.exe");
                tasks.UseShellExecute = true;
                tasks.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userDataTasks\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(tasks);
            }
            else if (AP_Tasks_Enable.IsChecked == true)
            {
                ProcessStartInfo tasks = new ProcessStartInfo("WT.exe");
                tasks.UseShellExecute = true;
                tasks.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userDataTasks\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(tasks);
            }

            //Messaging Access
            if (AP_Messaging_Disable.IsChecked == true)
            {
                ProcessStartInfo chat = new ProcessStartInfo("WT.exe");
                chat.UseShellExecute = true;
                chat.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\chat\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(chat);
            }
            else if (AP_Messaging_Enable.IsChecked == true)
            {
                ProcessStartInfo chat = new ProcessStartInfo("WT.exe");
                chat.UseShellExecute = true;
                chat.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\chat\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(chat);
            }

            //Radio Control Access
            if (AP_Radio_Disable.IsChecked == true)
            {
                ProcessStartInfo radios = new ProcessStartInfo("WT.exe");
                radios.UseShellExecute = true;
                radios.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\radios\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(radios);
            }
            else if (AP_Radio_Enable.IsChecked == true)
            {
                ProcessStartInfo radios = new ProcessStartInfo("WT.exe");
                radios.UseShellExecute = true;
                radios.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\radios\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(radios);
            }

            //Communicate with Unpaired Devices
            if (AP_Communicate_Disable.IsChecked == true)
            {
                ProcessStartInfo bsync = new ProcessStartInfo("WT.exe");
                bsync.UseShellExecute = true;
                bsync.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\bluetoothSync\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(bsync);
            }
            else if (AP_Communicate_Enable.IsChecked == true)
            {
                ProcessStartInfo bsync = new ProcessStartInfo("WT.exe");
                bsync.UseShellExecute = true;
                bsync.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\bluetoothSync\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(bsync);
            }

            //App Diagnostics Access
            if (AP_Diagnostic_Disable.IsChecked == true)
            {
                ProcessStartInfo diag = new ProcessStartInfo("WT.exe");
                diag.UseShellExecute = true;
                diag.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(diag);
            }
            else if (AP_Diagnostic_Enable.IsChecked == true)
            {
                ProcessStartInfo diag = new ProcessStartInfo("WT.exe");
                diag.UseShellExecute = true;
                diag.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(diag);
            }

            //Doucments Access
            if (AP_Documents_Disable.IsChecked == true)
            {
                ProcessStartInfo documents = new ProcessStartInfo("WT.exe");
                documents.UseShellExecute = true;
                documents.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\documentsLibrary\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(documents);
            }
            else if (AP_Documents_Enable.IsChecked == true)
            {
                ProcessStartInfo documents = new ProcessStartInfo("WT.exe");
                documents.UseShellExecute = true;
                documents.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\documentsLibrary\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(documents);
            }

            //Downloads Folder Access
            if (AP_Downloads_Disable.IsChecked == true)
            {
                ProcessStartInfo downloads = new ProcessStartInfo("WT.exe");
                downloads.UseShellExecute = true;
                downloads.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\downloadsFolder\" /v Value /t REG_SZ /d \"Deny\" /f";
                Process.Start(downloads);
            }
            else if (AP_Downloads_Enable.IsChecked == true)
            {
                ProcessStartInfo downloads = new ProcessStartInfo("WT.exe");
                downloads.UseShellExecute = true;
                downloads.Arguments = "REG ADD \"HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\downloadsFolder\" /v Value /t REG_SZ /d \"Allow\" /f";
                Process.Start(downloads);
            }


            //Clear Values
            Notifications_NC.IsChecked = true;
            Suggestions_NC.IsChecked = true;
            Tips_NC.IsChecked = true;
            StorageSense_NC.IsChecked = true;
            Clipboard_NC.IsChecked = true;
            WinTheme_NC.IsChecked = true;
            AppTheme_NC.IsChecked = true;
            Transparency_NC.IsChecked = true;
            RecentlyOpened_NC.IsChecked = true;
            GameMode_NC.IsChecked = true;
            SelectRecPriv.IsChecked = false;
            SelectRecAppPerm.IsChecked = false;
            DeselectAll.IsChecked = false;
            PersonalizedAds_NC.IsChecked = true;
            LanguageList_NC.IsChecked = true;
            ImproveSearch_NC.IsChecked = true;
            ShowSuggested_NC.IsChecked = true;
            SpeechRecognition_NC.IsChecked = true;
            Dictionary_NC.IsChecked = true;
            OptionalData_NC.IsChecked = true;
            TypingData_NC.IsChecked = true;
            Tailored_NC.IsChecked = true;
            Feedback_NC.IsSelected = true;
            SafeSearch_NC.IsChecked = true;
            SearchHistory_NC.IsChecked = true;
            AP_Location_NC.IsChecked = true;
            AP_Camera_NC.IsChecked = true;
            AP_Microphone_NC.IsChecked = true;
            AP_VActivation_NC.IsChecked = true;
            AP_Notifications_NC.IsChecked = true;
            AP_AInfo_NC.IsChecked = true;
            AP_Contacts_NC.IsChecked = true;
            AP_Calendar_NC.IsChecked = true;
            AP_PCall_NC.IsChecked = true;
            AP_CHistory_NC.IsChecked = true;
            AP_Email_NC.IsChecked = true;
            AP_Tasks_NC.IsChecked = true;
            AP_Messaging_NC.IsChecked = true;
            AP_Radio_NC.IsChecked = true;
            AP_Communicate_NC.IsChecked = true;
            AP_Diagnostic_NC.IsChecked = true;
            AP_Documents_NC.IsChecked = true;
            AP_Downloads_NC.IsChecked = true;
        }

        private void SelectRecPriv_Click(object sender, RoutedEventArgs e)
        {
            SelectRecPriv.IsChecked = true;

            PersonalizedAds_Disable.IsChecked = true;
            LanguageList_NC.IsChecked = true;
            ImproveSearch_Enable.IsChecked = true;
            ShowSuggested_Disable.IsChecked = true;
            SpeechRecognition_Disable.IsChecked = true;
            Dictionary_Disable.IsChecked = true;
            OptionalData_Disable.IsChecked = true;
            TypingData_Disable.IsChecked = true;
            Tailored_Disable.IsChecked = true;
            Feedback_Never.IsSelected = true;
            SafeSearch_Moderate.IsChecked = true;
            SearchHistory_Disable.IsChecked = true;
        }

        private void SelectRecAppPerm_Click(object sender, RoutedEventArgs e)
        {
            SelectRecAppPerm.IsChecked = true;
            
            AP_Location_Disable.IsChecked = true;
            AP_Camera_Enable.IsChecked = true;
            AP_Microphone_Enable.IsChecked = true;
            AP_VActivation_Disable.IsChecked = true;
            AP_Notifications_Disable.IsChecked = true;
            AP_AInfo_Disable.IsChecked = true;
            AP_Contacts_Disable.IsChecked = true;
            AP_Calendar_Enable.IsChecked = true;
            AP_PCall_Disable.IsChecked = true;
            AP_CHistory_Disable.IsChecked = true;
            AP_Email_Enable.IsChecked = true;
            AP_Tasks_Disable.IsChecked = true;
            AP_Messaging_Disable.IsChecked = true;
            AP_Radio_Disable.IsChecked = true;
            AP_Communicate_Disable.IsChecked = true;
            AP_Diagnostic_Disable.IsChecked = true;
            AP_Documents_Enable.IsChecked = true;
            AP_Downloads_Enable.IsChecked = true;
        }

        private void DeselectAll_Click(object sender, RoutedEventArgs e)
        {
            if (DeselectAll.IsChecked == true)
            {
                SelectRecPriv.IsChecked = false;
                SelectRecAppPerm.IsChecked = false;
                DeselectAll.IsChecked = false;

                //Deselect Privacy and Security
                PersonalizedAds_NC.IsChecked = true;
                LanguageList_NC.IsChecked = true;
                ImproveSearch_NC.IsChecked = true;
                ShowSuggested_NC.IsChecked = true;
                SpeechRecognition_NC.IsChecked = true;
                Dictionary_NC.IsChecked = true;
                OptionalData_NC.IsChecked = true;
                TypingData_NC.IsChecked = true;
                Tailored_NC.IsChecked = true;
                Feedback_NC.IsSelected = true;
                SafeSearch_NC.IsChecked = true;
                SearchHistory_NC.IsChecked = true;

                //Deselect App Permissions
                AP_Location_NC.IsChecked = true;
                AP_Camera_NC.IsChecked = true;
                AP_Microphone_NC.IsChecked = true;
                AP_VActivation_NC.IsChecked = true;
                AP_Notifications_NC.IsChecked = true;
                AP_AInfo_NC.IsChecked = true;
                AP_Contacts_NC.IsChecked = true;
                AP_Calendar_NC.IsChecked = true;
                AP_PCall_NC.IsChecked = true;
                AP_CHistory_NC.IsChecked = true;
                AP_Email_NC.IsChecked = true;
                AP_Tasks_NC.IsChecked = true;
                AP_Messaging_NC.IsChecked = true;
                AP_Radio_NC.IsChecked = true;
                AP_Communicate_NC.IsChecked = true;
                AP_Diagnostic_NC.IsChecked = true;
                AP_Documents_NC.IsChecked = true;
                AP_Downloads_NC.IsChecked = true;
            }
        }

        private void UN_Priv_Click(object sender, RoutedEventArgs e)
        {
            SelectRecPriv.IsChecked = false;
        }

        private void UN_AppPerm_Click(object sender, RoutedEventArgs e)
        {
            SelectRecAppPerm.IsChecked = false;
        }
    }
}
