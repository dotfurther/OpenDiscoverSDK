# UnsupportedFilterType Enumeration


Unsupported document filtering type.



## Definition
**Namespace:** <a href="a1516a26-c3bc-5b32-80d1-92d32506d831">OpenDiscoverSDK.Interfaces.Settings</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataContractAttribute]
public enum UnsupportedFilterType
```



## Remarks


 Unsupported, unknown, and corrupted documents can have text extracted via a proprietary binary-to-text extraction algorithm. 
The binary-to-text filtering algorithm will attempt to extract as much UTF8, UTF-16LE (latin languages only), and code page 1252 encoded text from the documents binary using a proprietary filtering algorithm. In many cases, useful text for indexing or searching can be extracted from unknown/corrupted/unsupported file formats using binary-to-text filtering.


## Members
<table>
<tr>
<td>None</td>
<td>0</td>
<td>No binary-to-text filtering. For this enum value, the SDK API method "ContentExtratorFactory.GetContentExtractor" will NOT return a content extractor interface for unsupported format types.</td></tr>
<tr>
<td>Unsupported</td>
<td>1</td>
<td><p>Perform binary-to-text filtering on unsupported/unknown document formats to extract text. If unsupported format is encrypted it will not be filtered (see UnsupportedAndEncrypted).</p><p>

The binary-to-text filtering algorithm will attempt to extract as much UTF8, UTF-16LE (Latin languages only), and code page 1252 encoded text from the documents binary using a proprietary filtering algorithm. In many cases, useful text for indexing or searching can be extracted from unknown/corrupted/unsupported file formats using binary-to-text filtering.</p>

 For this enum value, the SDK API method "ContentExtratorFactory.GetContentExtractor" will either return a <a href="425bbcf3-95b6-7564-9777-41f0c39bb9b7">IUnsupportedExtractor</a> or <a href="15fe76f2-d9da-2d1d-0fde-5751a490457f">ILargeUnsupportedExtractor</a> interface depending on the value of property <a href="90aee97f-a132-9d0b-5c91-d6ac2eb95ace">LargeDocumentCritera</a> and the document's file size.</td></tr>
<tr>
<td>UnsupportedAndEncrypted</td>
<td>2</td>
<td><p>Perform binary-to-text filtering on unknown/unsupported document formats to get extracted text - even if unsupported format is identified as being encrypted.</p><p>

For encrypted document formats, no meaningful text can be extracted via binary-to-text filtering unless internal parts of the document happen to reside in unencrypted regions (if any) of the document format. For encrypted formats, the utility of this enum value setting is mainly for document forensic analysis and not text extraction for the purpose of indexing/searching. Unless doing document forensic analysis, it is recommened for user to use Unsupported instead.</p><p>

For this enum value, the SDK API method "ContentExtratorFactory.GetContentExtractor" will either return a <a href="425bbcf3-95b6-7564-9777-41f0c39bb9b7">IUnsupportedExtractor</a> or <a href="15fe76f2-d9da-2d1d-0fde-5751a490457f">ILargeUnsupportedExtractor</a> interface depending on the value of property <a href="90aee97f-a132-9d0b-5c91-d6ac2eb95ace">LargeDocumentCritera</a> and the document's file size.</p></td></tr>
</table>

## See Also


#### Reference
<a href="a1516a26-c3bc-5b32-80d1-92d32506d831">OpenDiscoverSDK.Interfaces.Settings Namespace</a>  
