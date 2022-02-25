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
    /// Interaction logic for InstallView.xaml
    /// </summary>
    public partial class InstallView : UserControl
    {
        public InstallView()
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
            int numInstalls = 0;
            string[] programID = new string[46];

            //Windows Modification Software
            if (StartAllBack_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "StartIsBack.StartAllBack";
            }

            if (Start11_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Stardock.Start11";
            }

            if (Fences4_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Stardock.Fences";
            }

            if (ElevenClock_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "SomePythonThings.ElevenClock";
            }

            if (ModernFlyouts_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "ModernFlyouts.ModernFlyouts";
            }

            if (PowerToys_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Microsoft.PowerToys";
            }


            //Computer Maintenance Software
            if (Malwarebytes_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Malwarebytes.Malwarebytes";
            }

            if (CCleaner_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Piriform.CCleaner";
            }

            if (Speccy_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Piriform.Speccy";
            }

            if (RevoUninstaller_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "RevoUninstaller.RevoUninstaller";
            }

            if (HWiNFO_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "REALiX.HWiNFO";
            }

            if (CPUZ_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "CPUID.CPU-Z";
            }

            if (WinDirStat_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "WinDirStat.WinDirStat";
            }

            if (CrystalDiskInfo_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "CrystalDewWorld.CrystalDiskInfo";
            }


            //Internet Browsers
            if (Firefox_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Mozilla.Firefox";
            }

            if (Chrome_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Google.Chrome";
            }

            if (Opera_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Opera.Opera";
            }


            //Audio/Video
            if (Spotify_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Spotify.Spotify";
            }

            if (AmazonMusic_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Amazon.Music";
            }

            if (iTunes_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Apple.iTunes";
            }

            if (VLC_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "VideoLAN.VLC";
            }

            if (Audacity_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Audacity.Audacity";
            }


            //Office
            if (Microsoft365_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Microsoft.Office";
            }

            if (LibreOffice_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "TheDocumentFoundation.LibreOffice";
            }

            if (OpenOffice_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Apache.OpenOffice";
            }

            if (Foxit_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Foxit.FoxitReader";
            }

            if (AdobePDF_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Adobe.Acrobat.Reader.64-bit";
            }


            //Gaming
            if (Steam_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Valve.Steam";
            }

            if (EpicGames_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "EpicGames.EpicGamesLauncher";
            }

            if (Ubisoft_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Ubisoft.Connect";
            }

            if (EA_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "ElectronicArts.EADesktop";
            }


            //Messaging
            if (Discord_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Discord.Discord";
            }

            if (Teams_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Microsoft.Teams";
            }

            if (Zoom_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Zoom.Zoom";
            }

            if (Skype_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Microsoft.Skype";
            }

            
            //Streaming
            if (Netflix_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "9WZDNCRFJ3TJ";
            }

            if (PrimeVideo_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "9P6RC76MSMMJ";
            }

            if (Disney_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "9NXQXXLFST89";
            }

            if (Twitch_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Twitch.Twitch";
            }


            //Coding
            if (Notepad_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Notepad++.Notepad++";
            }

            if (VSCode_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Microsoft.VisualStudioCode";
            }


            //Editing
            if (GIMP_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "GIMP.GIMP";
            }

            if (Blender_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "BlenderFoundation.Blender";
            }

            if (Inkscape_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "Inkscape.Inkscape";
            }


            //Other
            if (WinRAR_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "RARLab.WinRAR";
            }

            if (qBittorrent_Install.IsChecked == true)
            {
                numInstalls = numInstalls + 1;
                programID[numInstalls] = "qBittorrent.qBittorrent";
            }


            for (int ni = 1; ni < numInstalls + 1; ni = ni + 1)
            {
                ProcessStartInfo installProgram = new ProcessStartInfo("Powershell.exe");
                installProgram.UseShellExecute = false;
                installProgram.Arguments = "winget install -e --id " + programID[ni];
                Process.Start(installProgram).WaitForExit();
            }

            //Clear Values
            StartAllBack_DI.IsChecked = true;
            Start11_DI.IsChecked = true;
            Fences4_DI.IsChecked = true;
            ElevenClock_DI.IsChecked = true;
            ModernFlyouts_DI.IsChecked = true;
            PowerToys_DI.IsChecked = true;
            Malwarebytes_DI.IsChecked = true;
            CCleaner_DI.IsChecked = true;
            Speccy_DI.IsChecked = true;
            RevoUninstaller_DI.IsChecked = true;
            HWiNFO_DI.IsChecked = true;
            CPUZ_DI.IsChecked = true;
            WinDirStat_DI.IsChecked = true;
            CrystalDiskInfo_DI.IsChecked = true;
            Firefox_DI.IsChecked = true;
            Chrome_DI.IsChecked = true;
            Opera_DI.IsChecked = true;
            Spotify_DI.IsChecked = true;
            AmazonMusic_DI.IsChecked = true;
            iTunes_DI.IsChecked = true;
            VLC_DI.IsChecked = true;
            Audacity_DI.IsChecked = true;
            Microsoft365_DI.IsChecked = true;
            LibreOffice_DI.IsChecked = true;
            OpenOffice_DI.IsChecked = true;
            Foxit_DI.IsChecked = true;
            AdobePDF_DI.IsChecked = true;
            Steam_DI.IsChecked = true;
            EpicGames_DI.IsChecked = true;
            Ubisoft_DI.IsChecked = true;
            EA_DI.IsChecked = true;
            Discord_DI.IsChecked = true;
            Teams_DI.IsChecked = true;
            Zoom_DI.IsChecked = true;
            Skype_DI.IsChecked = true;
            Netflix_DI.IsChecked = true;
            PrimeVideo_DI.IsChecked = true;
            Disney_DI.IsChecked = true;
            Twitch_DI.IsChecked = true;
            Notepad_DI.IsChecked = true;
            VSCode_DI.IsChecked = true;
            GIMP_DI.IsChecked = true;
            Blender_DI.IsChecked = true;
            Inkscape_DI.IsChecked = true;
            WinRAR_DI.IsChecked = true;
            qBittorrent_DI.IsChecked = true;
        }
    }
}
