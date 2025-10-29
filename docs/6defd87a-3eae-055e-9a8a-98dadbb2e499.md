# Passwords Property


Gets or sets the password array to use for decryption of supported password-protected formats.



## Definition
**Namespace:** <a href="a4de3d25-b44d-10c7-9f7b-6e96e612f300">OpenDiscoverSDK.Interfaces.Platform.Settings</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataMemberAttribute]
public string[] Passwords { get; set; }
```



#### Property Value
String[]

## Remarks
When processing a supported file format for decryption, each password in the password array will be used in an attempt to successfully decrypt the document until the the correct password is found or there are no more passwords in the array to try.

## See Also


#### Reference
<a href="15834f2e-5778-5912-a2cc-a92e9d2e78fb">DocumentTaskSettings Class</a>  
<a href="a4de3d25-b44d-10c7-9f7b-6e96e612f300">OpenDiscoverSDK.Interfaces.Platform.Settings Namespace</a>  
