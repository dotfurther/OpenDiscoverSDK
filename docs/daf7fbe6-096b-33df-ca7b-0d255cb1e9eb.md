# FailedPdfPages Property


If document is a PDF (a Document with <a href="04a7f5f8-7155-e7aa-f716-b1e9e0b016b2">FormatId</a> property with <a href="b4fb5522-8bb4-b6ac-fc42-ac833701e116">ID</a> equal to <a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDF</a>), then this property contains a list of PDF pages (<a href="fd3fc89d-e1e7-1dc0-73d0-0ef5454a6c84">PdfPageInfo</a>) in the PDF document where either an exception occured processing the page or where the text extracted length was below the <a href="b38280ef-11f7-aac9-3bc1-f0724146f27a">PageExtractedTextCriteria</a> criteria.



## Definition
**Namespace:** <a href="a1e65d49-050f-842a-426e-ba8aab188009">OpenDiscoverSDK.Interfaces.Platform</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataMemberAttribute]
public List<PdfPageInfo> FailedPdfPages { get; set; }
```



#### Property Value
List(<a href="fd3fc89d-e1e7-1dc0-73d0-0ef5454a6c84">PdfPageInfo</a>)

## Remarks
The utility of this list is to alert the end user or developer of the quality of the PDF text extraction. Actions such as OCR'ing the failed pages could be taken on such information, for example.

## See Also


#### Reference
<a href="1ada9969-add0-f951-f601-f7107618fb9d">Document Class</a>  
<a href="a1e65d49-050f-842a-426e-ba8aab188009">OpenDiscoverSDK.Interfaces.Platform Namespace</a>  
