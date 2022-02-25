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
    /// Interaction logic for UninstallView.xaml
    /// </summary>
    public partial class UninstallView : UserControl
    {
        public UninstallView()
        {
            InitializeComponent();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            ProcessStartInfo Link = new ProcessStartInfo(e.Uri.AbsoluteUri);
            Link.UseShellExecute = true;
            Process.Start(Link);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hard to Uninstall
            if (UN_Camera_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *windowscamera* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Alarms_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *windowsalarms* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Cortana_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage Microsoft.549981C3F5F10 | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Help_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *gethelp* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Maps_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *windowsmaps* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Edge_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Start-Process C:\\WINDOWS\\W11F-assets\\scripts\\UninstallEdge.bat -Verb RunAs";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Photos_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *photos* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_GameBar_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *xboxgamingoverlay* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Phone_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *yourphone* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }


            //Easy to Uninstall
            if (UN_Calculator_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *windowscalculator* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Feedback_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *windowsfeedbackhub* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Movies_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *zunevideo* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Media_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *zunemusic* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Mail_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *windowscommunicationsapps* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_News_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *bingnews* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Solitaire_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *solitaire* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Teams_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *microsoftteams* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_ToDo_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *todos* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Notepad_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *windowsnotepad* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Paint_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *paint* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Automate_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *powerautomate* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Snipping_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *screensketch* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Notes_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *stickynotes* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Voice_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *soundrecorder* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Weather_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *bingweather* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Terminal_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *windowsterminal* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Xbox_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *gamingapp* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_Skype_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *skypeapp* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_OneNote_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *onenote* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }

            if (UN_MixedReality_Uninstall.IsChecked == true)
            {
                ProcessStartInfo delProgram = new ProcessStartInfo("Powershell.exe");
                delProgram.UseShellExecute = true;
                delProgram.Arguments = "Get-AppxPackage *mixedreality* | Remove-AppxPackage";
                Process.Start(delProgram).WaitForExit();
            }


            //Clear Values
            UN_Camera_NC.IsChecked = true;
            UN_Alarms_NC.IsChecked = true;
            UN_Cortana_NC.IsChecked = true;
            UN_Help_NC.IsChecked = true;
            UN_Maps_NC.IsChecked = true;
            UN_Edge_NC.IsChecked = true;
            UN_Photos_NC.IsChecked = true;
            UN_GameBar_NC.IsChecked = true;
            UN_Phone_NC.IsChecked = true;
            UN_Calculator_NC.IsChecked = true;
            UN_Feedback_NC.IsChecked = true;
            UN_Movies_NC.IsChecked = true;
            UN_Media_NC.IsChecked = true;
            UN_Mail_NC.IsChecked = true;
            UN_News_NC.IsChecked = true;
            UN_Solitaire_NC.IsChecked = true;
            UN_Teams_NC.IsChecked = true;
            UN_ToDo_NC.IsChecked = true;
            UN_Notepad_NC.IsChecked = true;
            UN_Paint_NC.IsChecked = true;
            UN_Automate_NC.IsChecked = true;
            UN_Snipping_NC.IsChecked = true;
            UN_Notes_NC.IsChecked = true;
            UN_Voice_NC.IsChecked = true;
            UN_Weather_NC.IsChecked = true;
            UN_Terminal_NC.IsChecked = true;
            UN_Xbox_NC.IsChecked = true;
            UN_Skype_NC.IsChecked = true;
            UN_OneNote_NC.IsChecked = true;
            UN_MixedReality_NC.IsChecked = true;
        }
    }
}
