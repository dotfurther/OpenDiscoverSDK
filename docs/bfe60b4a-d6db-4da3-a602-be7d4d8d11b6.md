# ExtractItem Method


Extracts the archive file item to the specified stream. This method is for non-solid archives. See remarks.



## Definition
**Namespace:** <a href="66cb506c-7b83-62d0-4a83-d345a647f76a">OpenDiscoverSDK.Interfaces.Extractors</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
ContentResult ExtractItem(
	int index,
	Stream stream,
	string password = null
)
```



#### Parameters
<dl><dt>  Int32</dt><dd>The archive item given by this zero-offset index to extract to the input stream argument. An item's index is given by the <a href="5a0378dc-735c-57d7-6c2f-8a7bf3908407">Index</a> property. See <a href="0782bb83-dff4-12bf-fc6e-da7a127bcfb6">ChildDocuments</a>.</dd><dt>  Stream</dt><dd>Stream to write the decompressed item data. Only use MemoryStream if item's expanded size is "small enough" for your system's resources. It is up to user to define the subjective term "small enough". You should always test an archive item's expanded size first before extracting using method <a href="99e7c745-df9e-0b64-4aab-c0967e5dbf7a">TestItem(Int32, Int64, String)</a>.</dd><dt>  String  (Optional)</dt><dd><p>Optional password (default is null). Archive items can have individual item passwords except for solid block compressed archives where all items have the same password because they are in compressed together into solid blocks.</p><p>

Check the returned <a href="ff0037ea-a44f-2c8c-d4c2-7a636e133434">ContentResult</a> value, if <a href="ff0037ea-a44f-2c8c-d4c2-7a636e133434">WrongPassword</a> is the value then this archive item requires a decryption password. User can make subsequent calls to this method using a password until <a href="ff0037ea-a44f-2c8c-d4c2-7a636e133434">Ok</a> is returned or there are no more passwords to try.</p></dd></dl>

#### Return Value
<a href="ff0037ea-a44f-2c8c-d4c2-7a636e133434">ContentResult</a>  
A <a href="ff0037ea-a44f-2c8c-d4c2-7a636e133434">ContentResult</a> enumerated result. If the returned value is <a href="ff0037ea-a44f-2c8c-d4c2-7a636e133434">WrongPassword</a> then this archive item requires a decryption password. User can make subsequent calls to this method using a password until <a href="ff0037ea-a44f-2c8c-d4c2-7a636e133434">Ok</a> is returned or there are no more passwords to try.

## Remarks
For solid block compressed archives where <a href="21a19556-7131-cde4-a808-e53aa60ca73b">IsSolid</a> is true, use method <a href="d6f285a5-6031-1242-10f2-3ce1f0c323d9">ExtractSolidBlockItems(GetItemStreamCallback, ItemExtractionFinishedCallback, String)</a> instead. Using this method to extract all archive items from solid archives can be VERY slow if archive has many items (the more items, the more time consuming the extraction).

## See Also


#### Reference
<a href="9d2fb8da-9eff-b1d9-e027-a4b2d24993e8">IArchiveExtractor Interface</a>  
<a href="66cb506c-7b83-62d0-4a83-d345a647f76a">OpenDiscoverSDK.Interfaces.Extractors Namespace</a>  
