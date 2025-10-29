# LanguageIdSettings Class


Extracted text language identification settings.



## Definition
**Namespace:** <a href="a1516a26-c3bc-5b32-80d1-92d32506d831">OpenDiscoverSDK.Interfaces.Settings</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataContractAttribute]
public class LanguageIdSettings
```

<table><tr><td><strong>Inheritance</strong></td><td>Object  →  LanguageIdSettings</td></tr>
</table>



## Remarks

If <a href="ab3ffa2a-75b2-4b19-57af-5c18921c9d68">ExtractionType</a> is set to <a href="7c5c2e3e-3fbb-2b71-9b82-3248062c5149">MetadataOnly</a> then the properties of this class are ignored because no text is extracted in metadata only mode.


## Constructors
<table>
<tr>
<td><a href="d45712ce-a1b7-42ae-35ab-62b3da9fca37">LanguageIdSettings</a></td>
<td>Constructor.</td></tr>
</table>

## Properties
<table>
<tr>
<td><a href="950462d6-20db-2c1e-674e-362ea7c8ee45">IdentifyLanguages</a></td>
<td>Determines if languages present in extract text are to be identified by content extractors.</td></tr>
<tr>
<td><a href="725e702d-71d3-8023-d553-ec65843f06de">LatinScriptRegionPartitionSize</a></td>
<td>Used by language identification algorithm, see <a href="950462d6-20db-2c1e-674e-362ea7c8ee45">IdentifyLanguages</a>, to partition detected Latin script regions into smaller character ranges of this size.</td></tr>
<tr>
<td><a href="cfd70668-634e-51df-812d-d14b3e5254fc">MaxLanguageIdCharacters</a></td>
<td>Maximum number of characters in extracted text to use for language identification.</td></tr>
<tr>
<td><a href="fa873d4b-4318-793a-fb1b-2070b94372b9">PartitionLatinScriptRegions</a></td>
<td>Determines if Latin script regions detected during the language identification process (see <a href="950462d6-20db-2c1e-674e-362ea7c8ee45">IdentifyLanguages</a>) are partitioned into smaller regions of <a href="725e702d-71d3-8023-d553-ec65843f06de">LatinScriptRegionPartitionSize</a> number of characters.</td></tr>
</table>

## Methods
<table>
<tr>
<td>Equals</td>
<td>Determines whether the specified object is equal to the current object.<br />(Inherited from Object)</td></tr>
<tr>
<td>GetHashCode</td>
<td>Serves as the default hash function.<br />(Inherited from Object)</td></tr>
<tr>
<td>GetType</td>
<td>Gets the Type of the current instance.<br />(Inherited from Object)</td></tr>
<tr>
<td>ToString</td>
<td>Returns a string that represents the current object.<br />(Inherited from Object)</td></tr>
</table>

## See Also


#### Reference
<a href="a1516a26-c3bc-5b32-80d1-92d32506d831">OpenDiscoverSDK.Interfaces.Settings Namespace</a>  
