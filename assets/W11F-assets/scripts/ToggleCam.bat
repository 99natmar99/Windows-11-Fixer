@echo off

FOR /F "tokens=2,3" %%A IN ('REG QUERY HKLM\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam /v Value') DO set "CameraStatus=%%B"

if %CameraStatus%==Allow (REG ADD "HKLM\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam" /v Value /t REG_SZ /d "Deny" /f) && (REG ADD "HKCR\DesktopBackground\Shell\Toggle Camera/Microphone\shell\menu1" /v MUIVerb /t REG_SZ /d "Toggle Camera On" /f)
if %CameraStatus%==Deny (REG ADD "HKLM\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam" /v Value /t REG_SZ /d "Allow" /f) && (REG ADD "HKCR\DesktopBackground\Shell\Toggle Camera/Microphone\shell\menu1" /v MUIVerb /t REG_SZ /d "Toggle Camera Off" /f)