# IdResult(FileFormatDefinition, Int32, Int32) Constructor


Constructor.



## Definition
**Namespace:** <a href="5601be11-3859-60ba-961e-4dc4e0cf2953">OpenDiscoverSDK.Interfaces</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
public IdResult(
	FileFormatDefinition formatDef,
	int matchType,
	int textEncodingId
)
```



#### Parameters
<dl><dt>  <a href="9a4371ad-6dac-fab1-5f87-f823381e3a28">FileFormatDefinition</a></dt><dd>Identified file format.</dd><dt>  Int32</dt><dd>Strength of identification result.</dd><dt>  Int32</dt><dd>If text based format, the character encoding of the format. Set to <a href="6f1047fb-7367-c09c-5621-ae7632c8404b">Unknown</a> otherwise</dd></dl>

## Remarks
Only the SDK should create instances of this class.

## See Also


#### Reference
<a href="b988a0c1-116e-339f-6db3-dfdf9ab0247a">IdResult Class</a>  
<a href="c177d1f7-76b2-bd00-16c2-007c9ebea960">IdResult Overload</a>  
<a href="5601be11-3859-60ba-961e-4dc4e0cf2953">OpenDiscoverSDK.Interfaces Namespace</a>  
