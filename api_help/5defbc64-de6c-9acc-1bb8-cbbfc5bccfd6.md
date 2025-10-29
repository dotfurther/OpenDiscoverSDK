# CustomEntityDefinitions Property


Custom entity definitions. To use these custom item definitions they MUST be loaded using method OpenDiscoverSDK.ContentExtractorFactory.LoadCustomEntityDefinitions once in a process BEFORE starting any content extraction on process threads.



## Definition
**Namespace:** <a href="426e0aba-3c94-7f71-597c-2ec5efa7782b">OpenDiscoverSDK.Interfaces.Settings.TextAnalytics</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataMemberAttribute]
public List<CustomEntityDefinition> CustomEntityDefinitions { get; set; }
```



#### Property Value
List(<a href="d7c5aca5-b71b-adf0-af66-e8075f3cb7e1">CustomEntityDefinition</a>)

## See Also


#### Reference
<a href="ec55b021-9975-fde7-8194-2e5ebc6ce775">EntityExtractionSettings Class</a>  
<a href="426e0aba-3c94-7f71-597c-2ec5efa7782b">OpenDiscoverSDK.Interfaces.Settings.TextAnalytics Namespace</a>  
