@echo off
echo Building Core...
cd %~dp0Build
echo Running "cmake --build ." from /Build folder
cmake --build .
echo Done.