Copyright © 2019-2020 dotFurther Inc. All rights reserved. 

## Document Content Extraction Example

### ContentExtractionExample.csproj:
This WinForm UI example shows how to use the Open Discover SDK API to identify file formats and extract content from various
formats using the OpenDiscoverSDK.ContentExtractorFactory method and its returned interfaces. The UI will also display all the
various extracted document (see images below).


### How to use this example:

- Set the Visual Studio Startup Project to "ContentExtractionExample.csproj". 
- Make sure your build Platform is x64 and then menu select Debug/Start Debugging. 
- Once ContentExtraction WinForm UI is dispalyed select menu File/Open and select one of the test files in the "TestFiles" directory of this repository.

Your application should now look something like the image below. There is a panel for document file format identification information, the content extraction result, and document hashes. There is also a panel that contains tab pages for extracted metadata, document attributes, hyperlinks, the languages identified in the extracted text, and all extracted child documents (attachments/embedded objects/embedded media). Notice the bottom right side panel that contains any extracted text. The panels are separated by splitters for easy resizing.


<img src="Image1.png">

The image below shows the document attributes extracted (see "Attributes" tab page) for the selected document in the file list (left panel list box that shows all files in same directory of the originally opened file). Selecting another file in this list box will extract its content.

<img src="Image2.png">


The "Hyperlinks" tab page displays any extracted hyperlinks for HTML, office formats, and PDF documents:

<img src="Image3.png">


The "Languages" tab page displays the languages identified in the extracted text (if any). Some formats such as spreadsheets or any document that is not mostly sentences (e.g., tables, addresses, names, acronyms) can have poor results for language identification. Non-Latin-based languages usually yield the best language identification results because of their unique scripts (e.g. CJK). Many languages use Latin script so this poses more of a challenge:

<img src="Image4.png">

The "Children" tab displays any information on any extracted attachments/embedded objects/embedded media. Child documents have their file formats identified. To save a child item, right mouse-click on a child item and select "Save As...".

<img src="Image5.png">

The "Sensitive Items" tab displays any detected sensitive items in extracted text, metadata, or hyperlinks/urls (note: sensitive item detection must be enabled through ContentExtractionSettings class)

<img src="Image6.png">

The "Entity Items" tab displays any detected entity items in extracted text. 

<img src="Image7.png">


### Note:
To ENABLE long file path support for Windows 10 and .NET 4.6.2, see this article:
 https://blogs.msdn.microsoft.com/jeremykuhne/2016/07/30/net-4-6-2-and-long-paths-on-windows-10/
  
------------------------------------------------------------------------------------------------------------------------
### Note: 
Open Discover SDK is comprised of .NET x64 assemblies due to unmanaged code dependencies

- Run Microsoft Visual Studio C# examples in x64 solution platform (either Debug or Release)
- To edit WinForm forms, set build platform to "Any CPU" and rebuild. This is required to edit WinForm windows as Visual Studio WinForm designer is a 32-bit process. When done, set solution platform back to x64 before executing in either x64 Debug/Release mode.
- If you get run-time initialization exceptions with error messages like "An attempt was made to load a program with
  an incorrect format" then you are mixing x86 and x64 platforms. 


