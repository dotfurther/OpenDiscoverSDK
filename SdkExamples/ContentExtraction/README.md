Copyright © 2019-2020 dotFurther Inc. All rights reserved. 

# ContentExtractionExample.csproj:

This example shows how to use the Open Discover SDK API to identify file formats and extract content from various
formats using the OpenDiscoverSDK.ContentExtractorFactory method and its returned interfaces.


## How to use this example:


## Note:
To ENABLE long file path support for Windows 10 and .NET 4.6.2, see this article:
 https://blogs.msdn.microsoft.com/jeremykuhne/2016/07/30/net-4-6-2-and-long-paths-on-windows-10/
 
 
------------------------------------------------------------------------------------------------------------------------
NOTE: Open Discover SDK is comprised of x64 assemblies due to unmanaged code dependencies

- Run examples in x64 build (either Debug or Release)
- To edit WinForm forms, set build platform to "Any CPU" and rebuild. This is required to edit WinForm windows. When done, set platform 
  back to x64 before executing in either Debug/Release mode.
- If you get initialization exceptions with error messages like "An attempt was made to load a program with
  an incorrect format" then you are mixing x86 and x64 platforms.
------------------------------------------------------------------------------------------------------------------------
