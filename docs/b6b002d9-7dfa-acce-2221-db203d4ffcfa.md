# IMailStoreExtractor Interface


Mail store content extractor interface.



## Definition
**Namespace:** <a href="66cb506c-7b83-62d0-4a83-d345a647f76a">OpenDiscoverSDK.Interfaces.Extractors</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
public interface IMailStoreExtractor : IContentExtractor, 
	IDisposable
```

<table><tr><td><strong>Implements</strong></td><td><a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>, IDisposable</td></tr>
</table>



## Remarks
A mail store contains email message objects and can contain folders to organize these message objects. Examples of mail stores are Microsoft Outlook PST/OST and MBOX (.mbox) formats.

## Properties
<table>
<tr>
<td><a href="6b82c634-a1d4-57b1-4488-5cfdace4264e">CalculateMailStoreBinaryHash</a></td>
<td>If true, instructs the IMailStoreExtractor to calculate the mail store binary hash (the default value). If false, the mail store will NOT be hashed.</td></tr>
<tr>
<td><a href="7e5a4e4e-e9b6-73cc-6a6a-55a3c97ed0f7">ContentExtractorType</a></td>
<td>The derived, actual content extractor interface type.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="ffa7eb8f-f7d8-bab5-57d5-63a3a93ff661">Length</a></td>
<td>Gets the document's length in bytes.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="64185674-96db-95a5-4531-f7a355b6251b">SupportsChildrenExtraction</a></td>
<td>If true, this content extractor supports attachment, embedded item, or container item extraction.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="2e0a7ef6-472c-13b5-1f7b-d74d88c2575c">SupportsDecryption</a></td>
<td>If true, this content extractor supports decrypting password protected documents.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="acceb8ba-eb46-13ad-a520-e1058ed447bb">SupportsMetadataExtraction</a></td>
<td>If true, this content extractor supports metadata extraction.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="080f604d-af95-717e-61e3-5b7e3848e1f8">SupportsTextExtraction</a></td>
<td>If true, this content extractor supports text extraction.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
</table>

## Methods
<table>
<tr>
<td>Dispose</td>
<td>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.<br />(Inherited from IDisposable)</td></tr>
<tr>
<td><a href="952ce029-8c14-9a52-19ed-24d87d7564d7">ExtractContent</a></td>
<td>Extracts mail store metadata and mail store folders.</td></tr>
<tr>
<td><a href="e5f0220b-c301-04ac-cd7e-b7e77adfa41a">GetMessagesByNodeId</a></td>
<td>Gets a specific message objects from the mail store as <a href="b03bea52-0626-6949-6cc8-dc453414dd35">ChildDocument</a> objects. It is important to see the remarks.</td></tr>
<tr>
<td><a href="7eb8509f-105a-703e-dd60-73d8b72d6dd6">GetNextMessage</a></td>
<td>Gets the next message object from the mail store as a <a href="b03bea52-0626-6949-6cc8-dc453414dd35">ChildDocument</a> object where the message object's contents are contained in the DocumentBytes property of the returned ChildDocument.</td></tr>
<tr>
<td><a href="522af67b-0b37-29ef-5d38-dfe28c21a81f">OverrideContentExtractionSettings</a></td>
<td>Allows for overriding the <a href="b65f5ca9-d476-8b01-b6d2-c47f988ba0a2">ContentExtractionSettings</a> object used by a IContentExtractor instance that was returned by a call to OpenDiscoverSDK.ContentExtractorFactory.GetContentExtractor. See remarks for limitations.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
</table>

## Events
<table>
<tr>
<td><a href="031e2f5b-ab8b-b20d-4921-32a9cfb48cfc">ContentExtractionHeartbeat</a></td>
<td>Notification event that lets implementers of <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a> know that content extraction is still under process. See remarks.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
</table>

## See Also


#### Reference
<a href="66cb506c-7b83-62d0-4a83-d345a647f76a">OpenDiscoverSDK.Interfaces.Extractors Namespace</a>  
