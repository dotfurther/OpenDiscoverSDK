# MaxBinaryHashLength Property


Maximum number of bytes to use for MD5/SHA-1 binary hash (digest) calculation. See property <a href="d34afc18-5918-ccab-8fc3-99f3100e4842">HashingType</a>.



## Definition
**Namespace:** <a href="a1516a26-c3bc-5b32-80d1-92d32506d831">OpenDiscoverSDK.Interfaces.Settings</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataMemberAttribute]
public long MaxBinaryHashLength { get; set; }
```



#### Property Value
Int64

## Remarks

Values greater than 0 must be multiples of 64 KB (65,536 bytes). The property setter will enfore this requirement to the nearest multiple of 64 KB.

For values less than or equal to zero, all document bytes are used for the hash.

This property allows users to limit the number of bytes used for binary hash (digest) calculation so that for very large files only the first "MaxBinaryHashLength" bytes are used for the hashing.

Default property value: -1 (use all document bytes for binary hash calculation)


## See Also


#### Reference
<a href="4f386b26-6ef3-858f-a333-39d801f2ec09">HashingSettings Class</a>  
<a href="a1516a26-c3bc-5b32-80d1-92d32506d831">OpenDiscoverSDK.Interfaces.Settings Namespace</a>  
