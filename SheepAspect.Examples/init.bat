@echo off
echo - This script will copy required binaries into these example projects.
echo - MAKE SURE you have built ("Release") SheepAspect solution before proceeding.
echo - You also need to close SheepAspect.Example solution.
pause
echo Copying SheepAspect binary files...
copy ..\NugetItems\Tools\SheepAspect.targets .\Libs\
copy ..\ReferenceAssemblies\Antlr3.Runtime.dll .\Libs\
copy ..\SheepAspect\bin\release\SheepAspect.dll .\Libs\
copy ..\SheepAspect\bin\release\SheepAspect.pdb .\Libs\
copy ..\SheepAspect\bin\release\SheepAspect.xml .\Libs\
copy ..\SheepAspectCompiler\bin\release\SheepAspectCompiler.exe .\Libs\
copy ..\SheepAspect.Tasks\bin\release\SheepAspect.Tasks.dll .\Libs\

echo Completed
pause