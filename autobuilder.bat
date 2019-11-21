echo %PATH%
 
echo %USERDOMAIN%\%USERNAME%
 
"C:\Program Files\Unity\Hub\Editor\2019.1.7f1\Editor\Unity.exe" -quit -batchmode -logFile BuildLog.txt -buildTarget Android -executeMethod JENKINS.AutoBuilder.PerformWindowsMixedRealityBuild -keyaliasPass o708041 -keystorePass o708041 -appName IAPValidationRecipe.apk -buildFolder C:\Users\o7716\Desktop\blockbuster\BlockBuster\BlockBusters\builds
