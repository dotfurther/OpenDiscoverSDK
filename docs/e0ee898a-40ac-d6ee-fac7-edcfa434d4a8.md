# FilteringType Property


Binary-to-text filtering of unsupported/unknown document file format options.



## Definition
**Namespace:** <a href="a1516a26-c3bc-5b32-80d1-92d32506d831">OpenDiscoverSDK.Interfaces.Settings</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataMemberAttribute]
public UnsupportedFilterType FilteringType { get; set; }
```



#### Property Value
<a href="ba2d31dd-f24d-ca10-4acc-d073fcb5e47f">UnsupportedFilterType</a>

## Remarks

Filtering unsupported/unknown file formats uses a proprietary binary-to-text filtering algorithm that attempts to extract as much UTF8, UTF-16LE (Latin languages only), and code page 1252 encoded text from the document's binary. In many cases, useful text for indexing or searching can be extracted from unknown/corrupted/unsupported file formats using binary-to-text filtering (see <a href="ba2d31dd-f24d-ca10-4acc-d073fcb5e47f">Unsupported</a>).

Default property value: <a href="ba2d31dd-f24d-ca10-4acc-d073fcb5e47f">Unsupported</a>


## See Also


#### Reference
<a href="dbf9dc6c-b54d-322f-a286-8e3eb41f2c08">UnsupportedFilteringSettings Class</a>  
<a href="a1516a26-c3bc-5b32-80d1-92d32506d831">OpenDiscoverSDK.Interfaces.Settings Namespace</a>  
