// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************

------------------------------------------------------------------------------------------------------------------------
NOTE: Open Discover SDK is made up of x64 assemblies due to unmanaged code dependencies

- Run examples in x64 build (either Debug or Release)
- To edit WinForm forms, set build platform to "Any CPU" and rebuild. This is required to edit WinForm windows. When done, set platform 
  back to x64 before executing in either Debug/Release mode.
- If you get initialization exceptions with error messages like "An attempt was made to load a program with
  an incorrect format" then you are mixing x86 and x64 platforms.
------------------------------------------------------------------------------------------------------------------------

#PowerShellExample.csproj:

The classes in this example project show how the Open Discover SDK API can be used in C# PowerShell Cmdlets. IT professionals
can easily take advantage of the power of Open Discover SDK by expanding on these examples or creating their own Cmdlets.

The Cmdlet derived classes in this example C# project show how to use the Open Discover SDK API to:
- Identify a file's format (GetFileFormatCmdlet.cs)
- Display a summary of a file's content (GetFileInfoCmdlet.cs)
- Extract document content and return the result as a DocumentContent object (GetFileContentCmdlet.cs)
- Test an archive for true expansion size (GetArchiveExpandedSizeCmdlet.cs)


#Example Cmdlet Usage:
Change PowerShell directory to location of compiled "PowerShellExample.dll" assembly (this path will be unique to where the user installed the Github examples):
  PS> cd F:\OpenDiscover\Examples\SDK\Build  

Import assembly "PowerShellExample.dll" as a module into PowerShell environment:
  PS> Import-Module .\PowerShellExample.dll -Force

Display all Cmdlets in "PowerShellExample.dll" module:
  PS> Get-Command -Module PowerShellExample       

Identify a file's format:
  PS> Get-FileFormat -Path "F:\OpenDiscover\TestData\Document Hyperlinks\010190.pdf"

Identify a file's format and store the returned IdResult object in a variable:
  PS> $format = Get-FileFormat -Path "F:\OpenDiscover\TestData\Document Hyperlinks\010190.pdf"  
Compare $format.ID enumerated value with SDK's Id.PDF value:
  PS> $format.ID -eq [OpenDiscoverSDK.Interfaces.Id]::PDF
Compare the $format.Classification with SDK's IdClassification.DocumentExchange:
  PS>  $format.Classification -eq [OpenDiscoverSDK.Interfaces.IdClassification]::DocumentExchange
It's not hard to see that the user using a file path pipeline with this Cmdlet could search for all documents on a file server that either 
have certain Id or IdClassification types.

Get a file's format, metadata, attributes, hyperlinks, and [optionaly] display up to the first 1000 characters of extracted text:
  PS> Get-FileInfo -Path "F:\OpenDiscover\TestData\Document Hyperlinks\010190.pdf" 
  PS> Get-FileInfo -Path "F:\OpenDiscover\TestData\Document Hyperlinks\010190.pdf" -ShowText $true

Get a file's extracted content as a DocumentContent object ans store it in a variable names "$content":
  PS> $content = Get-FileContent -Path "F:\OpenDiscover\TestData\Document Hyperlinks\010190.pdf"

Now display the $content result object's SHA1 binary hash, language identification, and convert the extracted text to an HTML file:
  PS> $content.SHA1BinaryHash
  PS> $content.LanguageIdResults
  PS> ConvertTo-Html -InputObject $content -Property ExtractedText | Out-File content.htm
Using a a pipeline that compared both $content.SHA1BinaryHash and also $content.SHA1ContentHash and aggragated all documents with matching hashes, an IT professional 
or power user could easily find all duplicate documents on a file server.


To ENABLE long file path support for Windows 10 and .NET 4.6.2, see this article:
 https://blogs.msdn.microsoft.com/jeremykuhne/2016/07/30/net-4-6-2-and-long-paths-on-windows-10/

		 