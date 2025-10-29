# CustomEntityDefinition Class


A user defined custom entity to detect in extracted text and metadata and optionally extract following information.



## Definition
**Namespace:** <a href="426e0aba-3c94-7f71-597c-2ec5efa7782b">OpenDiscoverSDK.Interfaces.Settings.TextAnalytics</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataContractAttribute]
public class CustomEntityDefinition
```

<table><tr><td><strong>Inheritance</strong></td><td>Object  →  CustomEntityDefinition</td></tr>
</table>



## Remarks
A custom entity can be additional personal information, sensitive security information, or privileged information that is not covered by built-in SDK checks (see <a href="ec55b021-9975-fde7-8194-2e5ebc6ce775">EntityExtractionSettings</a>). It can also be custom entity types that user can use to classify documents.

## Constructors
<table>
<tr>
<td><a href="61027654-7045-0a48-9baf-fe98ba980e6c">CustomEntityDefinition()</a></td>
<td>Constructor.</td></tr>
<tr>
<td><a href="a6bce558-e193-d31c-8db9-74a1c9eeb285">CustomEntityDefinition(String, String, List(String), Boolean, CustomEntityExtractType, String, Int32)</a></td>
<td>Constructor.</td></tr>
</table>

## Properties
<table>
<tr>
<td><a href="90e785e1-83d6-e42a-f41f-08cf6a806454">Classification</a></td>
<td>The named classification of this sequence type (ex: "LegalContract").</td></tr>
<tr>
<td><a href="5ead8b2a-fb28-710e-fdee-d0883df80e22">ExtractType</a></td>
<td>Determines what type, if any, of text immediately following the <a href="2f1f5646-5290-32d9-45b4-0737b616e6be">KeywordSequences</a> is extracted.</td></tr>
<tr>
<td><a href="2f1f5646-5290-32d9-45b4-0737b616e6be">KeywordSequences</a></td>
<td>A list of keword sequences. A keyword sequence is 1 to a maximum of 14 keyword terms (terms are words or symbols) that define a custom item.</td></tr>
<tr>
<td><a href="769bb185-9126-da26-989f-8554e5b92b7c">Name</a></td>
<td>The named of this sequence (ex: "ContractTerm")</td></tr>
<tr>
<td><a href="00207e37-44b2-2f59-aea3-c5f0a914559e">RegExOptions</a></td>
<td>Regular expression options. Option flag Compiled will be ignored.</td></tr>
<tr>
<td><a href="b2e6287a-0d6b-2003-97a5-964c43773db5">RegExSearchLength</a></td>
<td>Determines the maximum number of characters after (<a href="ba039553-3d3d-7261-ac5a-f6ad9ba5c0c1">RegularExpressionAfter</a>), before (<a href="ba039553-3d3d-7261-ac5a-f6ad9ba5c0c1">RegularExpressionBefore</a>) or before and after (<a href="ba039553-3d3d-7261-ac5a-f6ad9ba5c0c1">RegularExpressionBeforeAndAfter</a>) to use for <a href="d284dbd5-1ca8-b160-0e7d-8208d4db1d6d">RegularExpression</a> search. See property <a href="d284dbd5-1ca8-b160-0e7d-8208d4db1d6d">RegularExpression</a> for more information. The default value is 50 characters and this includes any whitespace characters.</td></tr>
<tr>
<td><a href="d284dbd5-1ca8-b160-0e7d-8208d4db1d6d">RegularExpression</a></td>
<td><p>This property value should only be set with a regular expression data pattern if <a href="5ead8b2a-fb28-710e-fdee-d0883df80e22">ExtractType</a> is <a href="ba039553-3d3d-7261-ac5a-f6ad9ba5c0c1">RegularExpressionAfter</a> or <a href="ba039553-3d3d-7261-ac5a-f6ad9ba5c0c1">RegularExpressionBefore</a> (value will be ignored otherwise). Property <a href="b2e6287a-0d6b-2003-97a5-964c43773db5">RegExSearchLength</a> determines the maximum number of characters after (if <a href="ba039553-3d3d-7261-ac5a-f6ad9ba5c0c1">RegularExpressionAfter</a>) or before (if <a href="ba039553-3d3d-7261-ac5a-f6ad9ba5c0c1">RegularExpressionBefore</a>) to apply the regular expression pattern match.</p><p>

If the regular expression finds no matches then no custom <a href="75bf3100-d4b4-0098-46f5-b953923776a9">Entity</a> will be added to the entity item results. For regular expressions, the keyword sequence and the regular expression both must be matched in order to be added to the <a href="df171504-4e56-94e0-248a-15a2978f734c">Items</a> result list.</p><p>

Regular expressions are computationally expensive and their use should be limited to special cases. <a href="b2e6287a-0d6b-2003-97a5-964c43773db5">RegExSearchLength</a> should not be set larger than needed in order to match a pattern before, after, or before and after the keyword sequence. The keyword sequence should be unique enough (and not a very common word) in order that the regular expression is not excessively invoked to match its pattern.</p></td></tr>
<tr>
<td><a href="e6c26167-8693-6978-2d85-2ec7428a8b9f">RequireKeywordSequenceAtStartOfLine</a></td>
<td>If true, a keyword sequence must have its first token as the first token on a line, else it is not considered a valid sequence and is ignored. Default value is false.</td></tr>
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
<a href="426e0aba-3c94-7f71-597c-2ec5efa7782b">OpenDiscoverSDK.Interfaces.Settings.TextAnalytics Namespace</a>  
