Copyright © 2019-2020 dotFurther Inc. All rights reserved. 

## The projects contained in this directory show case the use of the Open Discover SDK API in a WCF service.

### WCF Example Projects:
- **Service Clients\SdkAPIWinFormClient.csproj:** A Winform UI that starts and connects to the console application hosted WCF service 
  and uses that service to extract document content. This test UI will display a dialog to connect to the console app hosted service.
  After connected, use the File menu to open a document that you which to extract content from. The UI will then display the extracted
  content in the various UI controls. The SdkAPIWinFormClient.proj WinForm UI WCF client app is a modified version of the  OpenDiscoverSDK/SdkSamples/ContentExtraction/ContentExtractionExample.csproj project WinForm UI. 
- **Service Host\SdkAPIServiceHost.csproj:**  Hosts the "SdkAPIWCFService" service in a console application
- **SdkAPI.Common.csproj:** Contains the service interfaces and a lightweight and reusable service proxy.    
- **SdkAPIWCFService.csproj:** Contains the service implementation


These example projects demonstrate how SDK extracted document content is supported for serialization and also show how to implement document content extraction as an out-of-process service for a layer of main application protection.

Make sure all WCF C# example projects are built (Visual Studio menu "Build/Rebuild Solution") before running the Winform UI client app - the client app will start the WCF service host console app (SdkAPIServiceHost.exe).

### When Building your own SDK WCF Services Configure Microsoft Visual Studio IIS Express:
If you creating your own WCF service that uses Open Discover SDK remember that the SDK assemblies are x64 (64 bit and not AnyCPU). To use Microsoft Visual Studio IIS Express to test a x64 service, make sure you configure IIS like this (use Microsoft Visual Studio menu "Tools/Options..." to display the dialog below):

<img src="VS_IIS_Express_x64_HostedSettings.png">

### Example Screen Shots:

Running the WinForm client SdkAPIWinFormClient.exe will also launch the the WCF console host executable (SdkAPIServiceHost.exe). Press "Connect to Service" button to connect to the console app hosted WCF service:

<img src="Image1.png">

The console app that hosts the WCF service:

<img src="Image2.png">

After connected to service the Winform SdkAPIWinFormClient.exe app works the same way as the OpenDiscoverSDK/SdkSamples/ContentExtraction/ContentExtractionExample.csproj WinForm app:

<img src="Image3.png">

------------------------------------------------------------------------------------------------------------------------
NOTE: Open Discover SDK is comprised of x64 assemblies due to unmanaged code dependencies

- Run examples in x64 build (either Debug or Release)
- To edit WinForm forms, set build platform to "Any CPU" and rebuild. This is required to edit WinForm windows. When done, set platform 
  back to x64 before executing in either Debug/Release mode.
- If you get initialization exceptions with error messages like "An attempt was made to load a program with
  an incorrect format" then you are mixing x86 and x64 platforms.

