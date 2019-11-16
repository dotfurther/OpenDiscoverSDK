// ***************************************************************************************
// 
//  Copyright © 2019 dotFurther Inc. All rights reserved. 
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

The projects contained in the "SDK\Examples\WCF" directory show case the use of the Open Discover SDK API in a WCF service.
The example also shows how extracted document content is supported for serialization.

WCF Example Projects:
- SdkAPI.Common.csproj: Contains the service interfaces and a lightweight and reusable service proxy.    
- SdkAPIWCFService.csproj: Contains the service implementation
- Service Host\SdkAPIServiceHost.csproj:  Hosts the "SdkAPIWCFService" service in a console application
- Service Clients\SdkAPIWinFormClient.csproj: A Winform UI that starts and connects to the console application hosted WCF service and uses service to extract document content.

Build the example projects and then run the SdkAPIWinFormClient executable. This executable will automatically start and connect to a SdkAPIServiceHost console app that hosts the WCF service.
