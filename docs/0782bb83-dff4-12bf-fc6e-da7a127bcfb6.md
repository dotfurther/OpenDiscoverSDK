# ChildDocuments Property


Child documents (attachments/embedded items). See remarks for the special cases of archives (.7z, zip, etc), media images, and mail stores (.pst, .ost, .mbox, etc.).



## Definition
**Namespace:** <a href="79f11d04-c275-b915-db5b-ab2227989555">OpenDiscoverSDK.Interfaces.Content</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataMemberAttribute]
public List<ChildDocument> ChildDocuments { get; set; }
```



#### Property Value
List(<a href="b03bea52-0626-6949-6cc8-dc453414dd35">ChildDocument</a>)

## Remarks

For most common document formats the child documents (if any) will be fully populated. However, archives, media images, mail stores, and databases present a special problem. They can be very 'large' and to naively extract whole archives, media images, databases (binary table columns), or mail stores into memory would be impossible for 'large' files.

For archives (.7z,.zip, etc) and media image formats each <a href="b03bea52-0626-6949-6cc8-dc453414dd35">ChildDocument</a> in this list will not have properties <a href="33e5d2f7-f54f-88a6-696e-a59e99a1047d">FormatId</a> and <a href="683c2f3f-10f3-083c-8b83-c3398875f011">DocumentBytes</a> set by a call to <a href="1fbb1f20-0cfe-881a-5b6c-7a23cf8bccd9">ExtractContent(String)</a> but will have other properties populated. A separate call must made to get each child document's raw bytes (see <a href="bfe60b4a-d6db-4da3-a602-be7d4d8d11b6">ExtractItem(Int32, Stream, String)</a> and <a href="d6f285a5-6031-1242-10f2-3ce1f0c323d9">ExtractSolidBlockItems(GetItemStreamCallback, ItemExtractionFinishedCallback, String)</a>). Once the child item is extracted to a stream (MemoryStream or FileStream - up to user depending on byte size of item) then the child documents file format id (<a href="33e5d2f7-f54f-88a6-696e-a59e99a1047d">FormatId</a>) can be determined by a call to OpenDiscoverSDK API.

For mail stores (.pst, .ost, .mbox, etc) the ChildDocuments property will not be set at all by a call to <a href="952ce029-8c14-9a52-19ed-24d87d7564d7">ExtractContent(String, Boolean, Int32)</a>. To get each child email document calls to <a href="7eb8509f-105a-703e-dd60-73d8b72d6dd6">GetNextMessage()</a> must be called until there are no more child email documents to be extracted (i.e., <a href="7eb8509f-105a-703e-dd60-73d8b72d6dd6">GetNextMessage()</a> returns null). Each child email document returned by a call to <a href="7eb8509f-105a-703e-dd60-73d8b72d6dd6">GetNextMessage()</a> will have its <a href="b03bea52-0626-6949-6cc8-dc453414dd35">ChildDocument</a> properties set including <a href="33e5d2f7-f54f-88a6-696e-a59e99a1047d">FormatId</a> and <a href="683c2f3f-10f3-083c-8b83-c3398875f011">DocumentBytes</a> and will be added to this ChildDocuments list. Care must be taken to process (or save to disk) each email as its extracted and then set each email child document <a href="683c2f3f-10f3-083c-8b83-c3398875f011">DocumentBytes</a> property to null after extracting the email's content so that used program RAM memory does not grow too large.


## See Also


#### Reference
<a href="8e86a5a1-9129-b079-8605-f7fa3f3a1f21">DocumentContent Class</a>  
<a href="79f11d04-c275-b915-db5b-ab2227989555">OpenDiscoverSDK.Interfaces.Content Namespace</a>  
