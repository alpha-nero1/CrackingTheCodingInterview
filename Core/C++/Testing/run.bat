@echo off
echo "Running Testing..."
:: %~dp0 gives us the current directory with trailing slash,
:: see here: https://stackoverflow.com/questions/2730643/how-to-execute-programs-in-the-same-directory-as-the-windows-batch-file
%~dp0Build\bin\Debug\Testing.exe