# IsRoot Property


Gets or sets whether this folder is the root folder. See remarks.



## Definition
**Namespace:** <a href="79f11d04-c275-b915-db5b-ab2227989555">OpenDiscoverSDK.Interfaces.Content</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataMemberAttribute]
public bool IsRoot { get; set; }
```



#### Property Value
Boolean

## Remarks
The root folder has <a href="0029a144-911a-d5a4-f18d-a6dfa35681c0">DisplayName</a> set to "Root" and is not part of container item paths. Container items that are in the "Root" directory do not have a path associated with them in the container. Sub-folders under the "Root" (see <a href="66e9889d-8d08-38d5-35bb-a33da7fb372a">SubFolders</a>) do not have "Root" as part of their DisplayName.

## See Also


#### Reference
<a href="ad548c58-a9d6-7447-8969-33a7fa5a790a">ContainerFolder Class</a>  
<a href="79f11d04-c275-b915-db5b-ab2227989555">OpenDiscoverSDK.Interfaces.Content Namespace</a>  
