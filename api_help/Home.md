# Welcome


Welcome to Open Discover® SDK for .NET 8


Open Discover SDK is a .NET application programming interface (API) that supports:
<ul><li>Identifying file formats using internal binary signatures for reliable and very fast file format identification (over 1,550 file formats supported for identification)</li><li>Extracting text from supported file formats and optionally identifying the languages present in the extracted text</li><li>Extracting metadata from supported file formats (over 1,350 known metadata fields extracted in total)</li><li>Extracting attachments/embedded items from supported document formats</li><li>Extracting archive container items (7-zip, .zip, .rar, .tar, and many more)</li><li>Testing archives and archive items for true expansion size before extraction. This feature can help in malicious archive detection (e.g., 'compression bombs' and archives with intentionally modified item headers).</li><li>Extracting mail store container email objects (PST, OST, OST2013, MBOX, etc)</li><li>Detecting and extracting sensitive item information from text and metadata such as social security numbers, credit card numbers, driver's license numbers, addresses, phone numbers, and much more.</li><li>Detecting and extracting supported entity item type information present in text and metadata.</li></ul>






Open Discover SDK API is purposed for users to develop higher level document processing applications for:
<ul><li>Full text search using SDK for text/metadata/attachment/entity extraction</li><li>Machine learning/AI requiring format identification and quality extracted text and metadata</li><li>Text analytics</li><li>Information governance</li><li>Website crawling/full-text website search</li><li>Enterprise search and content management</li><li>IT Departments - identify, classify, and deduplicate documents in file storage devices on-premise or in the cloud</li><li>eDiscovery</li><li>And more...</li></ul>






<table>
	<tr>
		<th>
			<img src="media/AlertCaution.png" alt="Important note">
				
			</img>  Important
		</th>
	</tr>
	<tr>
		
		<td>
		<p>The .NET assemblies that make up Open Discover SDK are x64 release builds (not AnyCPU) due to x64 dependencies. Therefore, .NET applications that directly reference and use the SDK assemblies MUST also be x64 builds.</p></td>
	</tr>
</table>



## See Also


#### Concepts
<a href="b17635d4-db19-4248-b66f-c449ade2baf8">System and Development Requirements</a>  
<a href="b8b727e1-17e3-4ba8-b572-ac4316bc9b53">Features Overview</a>  
<a href="7e782821-dd62-4262-b342-f603ac374bba">Supported File Formats</a>  
<a href="59ed8473-fbd9-4bf1-9e80-33226882e71f">How To</a>  
