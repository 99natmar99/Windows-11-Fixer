@echo off

FOR /F "tokens=2,3" %%A IN ('REG QUERY HKLM\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone /v Value') DO set "MicStatus=%%B"

if %MicStatus%==Allow (REG ADD "HKLM\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone" /v Value /t REG_SZ /d "Deny" /f) && (REG ADD "HKCR\DesktopBackground\Shell\Toggle Camera/Microphone\shell\menu2" /v MUIVerb /t REG_SZ /d "Toggle Microphone On" /f)
if %MicStatus%==Deny (REG ADD "HKLM\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone" /v Value /t REG_SZ /d "Allow" /f) && (REG ADD "HKCR\DesktopBackground\Shell\Toggle Camera/Microphone\shell\menu2" /v MUIVerb /t REG_SZ /d "Toggle Microphone Off" /f)