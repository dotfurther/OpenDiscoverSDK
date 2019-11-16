Copyright © 2019-2020 dotFurther Inc. All rights reserved.

## File Format Document Identification Example

### DocumentIdentifierExample.csproj:
This example shows how to use the Open Discover SDK DocumentIdentifier API in a parallel ForEach loop to identify the file formats 
of files contained in a directory (including all sub-directories).

The DocumentIdentifier.Identify methods take either a System.IO.Stream or byte array of file bytes. When opening a stream or reading in all file bytes, it is up to the user to take care of long file paths that are greater than MAX_PATH characters in length.

To ENABLE long file path support for Windows 10 and .NET 4.6.2, see this article:
 https://blogs.msdn.microsoft.com/jeremykuhne/2016/07/30/net-4-6-2-and-long-paths-on-windows-10/

------------------------------------------------------------------------------------------------------------------------
WARNING: Watch your anti-virus software in Task Manager (under "Details" tab on Task Manager sort by CPU). Since this example 
         application reads upwards of thousands of files a second most anti-virus softwares will monitor it very closely and 
	 may use a lot of the available CPU. The anti-virus program may even kill the process. If this happens you will need 
	 to configure your anti-virus to 'trust' this application.
------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------
NOTE: Open Discover SDK is made up of x64 assemblies due to unmanaged code dependencies

- Run examples in x64 build (either Debug or Release)
- To edit WinForm forms, set build platform to "Any CPU" and rebuild. This is required to edit WinForm windows. When done, set platform 
  back to x64 before executing in either Debug/Release mode.
- If you get initialization exceptions with error messages like "An attempt was made to load a program with
  an incorrect format" then you are mixing x86 and x64 platforms.
------------------------------------------------------------------------------------------------------------------------		 
