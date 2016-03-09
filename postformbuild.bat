@echo off
set RAR="C:\Program Files\WinRAR\WinRAR.exe"
set PORTABLEZIP="D:\dremote\site\dl\dRemote_portable.zip"
set PORTABLESFX="D:\dremote\site\dl\dRemote_sfx.exe"
set buildpath="D:\mRemoteNG-develop\mRemoteV1\bin\Debug\*.*"
IF EXIST "D:\mRemoteNG-develop\mRemoteV1\bin\Debug\putty.exe" del /F "D:\mRemoteNG-develop\mRemoteV1\bin\Debug\putty.exe"
COPY "D:\mRemoteNG-develop\mRemoteV1\References\putty.exe" "D:\mRemoteNG-develop\mRemoteV1\bin\Debug\putty.exe"
IF EXIST %PORTABLEZIP% del /F %PORTABLEZIP%
IF EXIST %PORTABLESFX% del /F %PORTABLESFX%
%RAR% a -m5 -r -ep1 -afzip -inul %PORTABLEZIP% %buildpath%
%RAR% a -m5 -r -ep1 -sfx -inul %PORTABLESFX% %buildpath%