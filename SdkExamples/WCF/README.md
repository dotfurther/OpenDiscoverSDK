Copyright © 2019-2020 dotFurther Inc. All rights reserved. 

## The projects contained in this directory show case the use of the Open Discover SDK API in a WCF service.
## The example also shows how extracted document content is supported for serialization.

## WCF Example Projects:
- Service Clients\SdkAPIWinFormClient.csproj : A Winform UI that starts and connects to the console application hosted WCF service 
  and uses that service to extract document content. This test UI will display a dialog to connect to the console app hosted service.
  After connected, use the File menu to open a document that you which to extract content from. The UI will then display the extracted
  content in the various UI controls.
- Service Host\SdkAPIServiceHost.csproj:  Hosts the "SdkAPIWCFService" service in a console application
- SdkAPI.Common.csproj: Contains the service interfaces and a lightweight and reusable service proxy.    
- SdkAPIWCFService.csproj: Contains the service implementation

## Example Screen:

------------------------------------------------------------------------------------------------------------------------
NOTE: Open Discover SDK is comprised of x64 assemblies due to unmanaged code dependencies

- Run examples in x64 build (either Debug or Release)
- To edit WinForm forms, set build platform to "Any CPU" and rebuild. This is required to edit WinForm windows. When done, set platform 
  back to x64 before executing in either Debug/Release mode.
- If you get initialization exceptions with error messages like "An attempt was made to load a program with
  an incorrect format" then you are mixing x86 and x64 platforms.
------------------------------------------------------------------------------------------------------------------------
