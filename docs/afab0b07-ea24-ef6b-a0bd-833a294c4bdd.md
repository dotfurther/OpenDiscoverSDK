# IArchiveExtractor Properties




## Properties
<table>
<tr>
<td><a href="bf69ed8a-cc00-94f5-89c0-684d0889626e">CalculateArchiveBinaryHash</a></td>
<td>If true, instructs the <a href="9d2fb8da-9eff-b1d9-e027-a4b2d24993e8">IArchiveExtractor</a> to calculate the archive binary hash (default value). If false, the archive will NOT be hashed.</td></tr>
<tr>
<td><a href="7e5a4e4e-e9b6-73cc-6a6a-55a3c97ed0f7">ContentExtractorType</a></td>
<td>The derived, actual content extractor interface type.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="21a19556-7131-cde4-a808-e53aa60ca73b">IsSolid</a></td>
<td>If true, this archive is a 'solid' block compressed archive, i.e., an archive composed of one or more internal blocks of items that are compressed together as one.</td></tr>
<tr>
<td><a href="218de38e-c718-553f-7868-b15989ce20bb">IsSplit</a></td>
<td>If true, this archive is a split (multi-file) archive.</td></tr>
<tr>
<td><a href="ffa7eb8f-f7d8-bab5-57d5-63a3a93ff661">Length</a></td>
<td>Gets the document's length in bytes.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="64185674-96db-95a5-4531-f7a355b6251b">SupportsChildrenExtraction</a></td>
<td>If true, this content extractor supports attachment, embedded item, or container item extraction.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="2e0a7ef6-472c-13b5-1f7b-d74d88c2575c">SupportsDecryption</a></td>
<td>If true, this content extractor supports decrypting password protected documents.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="acceb8ba-eb46-13ad-a520-e1058ed447bb">SupportsMetadataExtraction</a></td>
<td>If true, this content extractor supports metadata extraction.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
<tr>
<td><a href="080f604d-af95-717e-61e3-5b7e3848e1f8">SupportsTextExtraction</a></td>
<td>If true, this content extractor supports text extraction.<br />(Inherited from <a href="94fa03c2-ad71-ecdc-48b0-48fb7ff40e45">IContentExtractor</a>)</td></tr>
</table>

## See Also


#### Reference
<a href="9d2fb8da-9eff-b1d9-e027-a4b2d24993e8">IArchiveExtractor Interface</a>  
<a href="66cb506c-7b83-62d0-4a83-d345a647f76a">OpenDiscoverSDK.Interfaces.Extractors Namespace</a>  
