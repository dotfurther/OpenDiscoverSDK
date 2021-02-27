# This example can be run by  right-mouse clicking on it in the 'Build' output directory and selecting "Run with PowerShell 7"


# Verify version of PowerShell, this example requires PowerShell version 7.1.2 or newer for .NET 5 support:
# PowerShell release can be downloaded from official GitHub repository: https://github.com/PowerShell/PowerShell/releases/
$PSVersionTable.PSVersion


# Import assembly "PowerShellExample.dll" as a module into PowerShell environment:
Import-Module .\PowerShellExample.dll -Force
" "
" "
"-----------------------------------------------------------------------------"
" Display all Cmdlets in 'PowerShellExample.dll' module:"
"-----------------------------------------------------------------------------"
Get-Command -Module PowerShellExample 

" "
" "
" "
"------------------------------------------------------------------------------------------"
" Identify TestFile.pdf file format and store the returned IdResult object in a variable:"
"------------------------------------------------------------------------------------------"
Get-FileFormatId -Path ".\TestFile.pdf"

" "
" "
" "
"---------------------------------------------------------------------------------------------------------------------------------------------"
" Get TestFile.pdf file format, metadata, attributes, hyperlinks, and [optionally] display up to the first 1000 characters of extracted text"
"---------------------------------------------------------------------------------------------------------------------------------------------"
Get-FileInfo -Path ".\TestFile.pdf" -ShowText $true


" "
" "
" "
"--------------------------------------------------------------------------------------------------------------------------------"
" Get TestFile.pdf extracted content as a DocumentContent object and store it in a variable named 'content' variable:"
"--------------------------------------------------------------------------------------------------------------------------------"
$content = Get-FileContent -Path ".\TestFile.pdf"



Read-Host -Prompt "Press Enter to exit"