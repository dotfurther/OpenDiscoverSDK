# ClearCustomEntityDefinitions Method


Clears <a href="d7c5aca5-b71b-adf0-af66-e8075f3cb7e1">CustomEntityDefinition</a>s previously loaded by a previous call to method <a href="4abcff97-fd8e-c2e2-6a00-e3450861a17a">LoadCustomEntityDefinitions(List(CustomEntityDefinition))</a>. See remarks on thread safety.



## Definition
**Namespace:** <a href="269fabc9-a080-183c-2b1b-268520e2038c">OpenDiscoverSDK</a>  
**Assembly:** OpenDiscoverSDK (in OpenDiscoverSDK.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
public static void ClearCustomEntityDefinitions()
```



## Remarks
This method is not thread safe and should only be called when no other threads in the process are performing content extraction with sensitive item detection enabled.

## See Also


#### Reference
<a href="2fbf109b-c0df-5cb9-abc9-e22bc3957c16">ContentExtractorFactory Class</a>  
<a href="269fabc9-a080-183c-2b1b-268520e2038c">OpenDiscoverSDK Namespace</a>  
