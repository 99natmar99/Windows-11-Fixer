@echo off

FOR /F "tokens=2,3" %%A IN ('REG QUERY HKCU\Software\Microsoft\Edge\BLBeacon /v version') DO set "Version=%%B"

cd "C:\Program Files (x86)\Microsoft\Edge\Application\%Version%\Installer"

setup --uninstall --force-uninstall --system-level