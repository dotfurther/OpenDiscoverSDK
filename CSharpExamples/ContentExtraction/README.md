Copyright © 2019-2023 dotFurther Inc. All rights reserved. 

## Document Content Extraction Example

### ContentExtractionExample.csproj:
This WinForm UI example shows how to use the Open Discover SDK API to identify file formats and extract content from various
formats using the OpenDiscoverSDK.ContentExtractorFactory method and its returned interfaces. The UI will also display all the
various extracted document content (see images below).


### How to use this example:

- Set the Visual Studio Startup Project to "ContentExtractionExample.csproj". 
- Make sure your build Platform is x64 and then menu select Debug/Start Debugging. 
- Once ContentExtraction WinForm UI is displayed select menu "File/Open" and select a file. All file names in the same directory will be displayed in the left hand side file list. Left mouse-clicking on a displayed file name will cause the contents of the selected file to be extracted and displayed.

Your application should now look something like the image below. There is a panel for document file format identification information, the content extraction result, and document hashes. There is also a panel that contains tab pages for extracted metadata, document attributes, hyperlinks, the languages identified in the extracted text, and all extracted child documents (attachments/embedded objects/embedded media). Notice the bottom right side panel that contains any extracted text. The panels are separated by splitters for easy resizing.


<img src="DocumentationImages/Image1.png">

The image below shows the document attributes extracted (see "Attributes" tab page) for the selected document in the file list (left panel list box that shows all files in same directory of the originally opened file). Selecting another file in this list box will extract its content.

<img src="DocumentationImages/Image2.png">


The "Hyperlinks" tab page displays any extracted hyperlinks for HTML, office formats, and PDF documents:

<img src="DocumentationImages/Image3.png">


The "Languages" tab page displays the languages identified in the extracted text (if any). Some formats such as spreadsheets or any document that is not mostly sentences (e.g., tables, addresses, names, acronyms) can have poor results for language identification. Non-Latin-based languages yield the best language identification results because of their unique scripts (e.g., CJK):

<img src="DocumentationImages/Image4.png">

The "Children" tab displays any information on any extracted attachments/embedded objects/embedded media. Child documents automatically have their file formats identified. To save a child item, right mouse-click on a child item and select "Save As...".

<img src="DocumentationImages/Image5.png">

The "Sensitive Items" tab displays any detected sensitive items in extracted text, metadata, or hyperlinks/urls (note: sensitive item detection must be enabled through ContentExtractionSettings class)

<img src="DocumentationImages/Image6.png">

The "Entity Items" tab displays any detected entity items in extracted text. 

<img src="DocumentationImages/Image7.png">

### Archive and mail store containers:

Items supported for password decryption will have a password dialog box automatically appear. In this example, we selected an encrypted 7-zip archive: 

<img src="DocumentationImages/Image8.png">

This screen shot shows the archive item metadata and archive level metadata. Note that the archive container's metadata contains the number
of items in the container ("NumOfContainerItems" field):

<img src="DocumentationImages/Image9.png">

This screen shot shows the archive's internal container folder structure. The example also supports extracting all archive items to a user supplied folder: 

<img src="DocumentationImages/Image10.png">

This screen shot shows the results of running an archive true expanded size ("Test Archive" button) to test a malicious archive. This particular malicious archive advertises a 1 byte item decompressed size, but in reality it is 10 GB in size (the items header was maliciously modified to hide the true item expanded size). The Open Discover SDK can be used to test untrusted archives for true expansion size before extracting archive items (naively extracting items from untrusted archives can potentially ruin your file server's day). Additionally, the Open Discover Platform API has built-in safety checks for detecting both archive compression bombs and archive recursion (self-replicating) bombs.

<img src="DocumentationImages/Image10b.png">

This screen shot shows a mail store container's (Microsoft Outlook .pst file) internal folder structure. Note that the mail store container's metadata contains the number
of email objects in the container ("NumOfContainerItems" field). Users can perform metadata only extraction to get the total number of items contained in all archive and mail store containers on a file share, for example. 

<img src="DocumentationImages/Image11.png">

Microsoft Outlook for Mac (.olm) mail store container internal folder structure (email objects are extracted as MIME files (.eml) for .olm format):
<img src="DocumentationImages/Image12.png">


### Note:
To ENABLE long file path support for Windows 10 and .NET 5, see this article:
 https://blogs.msdn.microsoft.com/jeremykuhne/2016/07/30/net-4-6-2-and-long-paths-on-windows-10/
  
------------------------------------------------------------------------------------------------------------------------
### Note: 
Open Discover SDK is comprised of .NET 6 x64 assemblies due to unmanaged code dependencies

- Run Microsoft Visual Studio C# examples in x64 solution platform (either Debug or Release)
- To edit WinForm forms, set build platform to "Any CPU" and rebuild. This is required to edit WinForm windows as Visual Studio WinForm designer is a 32-bit process. When done, set solution platform back to x64 before executing in either x64 Debug/Release mode.
- If you get run-time initialization exceptions with error messages like "An attempt was made to load a program with
  an incorrect format" then you are mixing x86 and x64 platforms. 


