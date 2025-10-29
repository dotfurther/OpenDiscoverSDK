# DirectoryResult Class


Represents a file system directory and its contained files (documents) and sub-directories.



## Definition
**Namespace:** <a href="05ac8cdb-ff0b-7a5c-da07-61a1da637cb0">OpenDiscoverSDK.Interfaces.Platform.Inventory</a>  
**Assembly:** OpenDiscoverSDK.Interfaces (in OpenDiscoverSDK.Interfaces.dll) Version: 2025.4.4.0 (2025.4.4)

**C#**
``` C#
[DataContractAttribute]
public class DirectoryResult
```

<table><tr><td><strong>Inheritance</strong></td><td>Object  →  DirectoryResult</td></tr>
</table>



## Constructors
<table>
<tr>
<td><a href="469fa016-2cea-bdd5-d306-8c401772b409">DirectoryResult</a></td>
<td>Initializes a new instance of the DirectoryResult class</td></tr>
</table>

## Properties
<table>
<tr>
<td><a href="2e09256f-c540-1db0-48c3-d4d4a8213412">CreationTimeUtc</a></td>
<td>Gets or sets the creation time, in coordinated universal time (UTC), of the current file or directory.</td></tr>
<tr>
<td><a href="53f28f1e-dc1c-c71a-c584-1f39310f2493">DirectoryID</a></td>
<td>Directory unique integer ID (-1 means uninitialized).</td></tr>
<tr>
<td><a href="7cf5141c-225d-139f-3f85-1d56c05231b8">Documents</a></td>
<td>Only documents directly contained by this directory. This propert is only set if returned by InventoryDirectoriesAndFiles.</td></tr>
<tr>
<td><a href="ae14ec23-9477-5298-2a1b-b4314a401282">DocumentsOwnedCount</a></td>
<td>The number of documents contained directly in this directory, does not include sub-directories.</td></tr>
<tr>
<td><a href="059f9617-6567-6e0d-a01a-a1aefd5a78a4">ErrorMessage</a></td>
<td>Error message for the error that occurred enumerating the directory.</td></tr>
<tr>
<td><a href="b28551a8-b965-9805-6acc-295b2760cf37">FileAttributes</a></td>
<td>Directory file system attributes.</td></tr>
<tr>
<td><a href="b4ce86ec-237c-851f-5f6f-59fa988d7721">HasError</a></td>
<td>Error occured enumerating the directory.</td></tr>
<tr>
<td><a href="d74cd7ae-a5d6-b96d-0705-d417ac30f5fb">IsEnumerated</a></td>
<td>Is directory item completely enumerated. This property is only set by classes InventoryDirectoriesAndFiles and InventoryDirectoriesOnly.</td></tr>
<tr>
<td><a href="163794e3-ce98-0726-ff16-46fe6e6a5b5e">LastAccessTimeUtc</a></td>
<td>Gets or sets the time, in coordinated universal time (UTC), that the current file or directory was last accessed.</td></tr>
<tr>
<td><a href="dfe1d2d1-cca3-d09a-763f-074c1d537285">LastWriteTimeUtc</a></td>
<td>Gets or sets the time, in coordinated universal time (UTC), when the current file or directory was last written to.</td></tr>
<tr>
<td><a href="590e6041-5720-c931-cfe8-72ffe536f45a">Name</a></td>
<td>Directory or file name.</td></tr>
<tr>
<td><a href="fd7a78fe-a2dd-9bb0-6842-22b22c441149">NameWithTotalFileCount</a></td>
<td>Name of the directory and total document count under the directory as a string. Format: "Name (count)"</td></tr>
<tr>
<td><a href="cf146765-2883-c640-b8f4-2ad3afce70c6">Owner</a></td>
<td>Gets or sets the file system owner.</td></tr>
<tr>
<td><a href="a059abe1-3663-03a7-b50a-59ecda8819e4">ParentDirectoryID</a></td>
<td>Parent directory unique integer ID (-1 means no parent).</td></tr>
<tr>
<td><a href="954d32b2-2bca-22be-90aa-9f6b569a791f">Path</a></td>
<td>Full path of the directory</td></tr>
<tr>
<td><a href="80648af0-6f97-2379-a3ee-f3d3469ed39f">Result</a></td>
<td>Result of the enumeration of this directory item.</td></tr>
<tr>
<td><a href="3cbb90a6-ce89-1d0b-6950-48e493d76265">TotalDirectoryCount</a></td>
<td>Total number of sub-directories in this directory.</td></tr>
<tr>
<td><a href="07b1fb2a-d338-9e33-c6de-a2e292cb8f11">TotalDocumentCount</a></td>
<td>Total number of documents contained directly in this directory and in all sub-directories nested under this directory (inclused sub-directories of sub.</td></tr>
<tr>
<td><a href="90562634-014b-829f-c590-706c9ea5dda7">TotalSizeInBytes</a></td>
<td>Total size, in bytes, of all the documents in this directory and in all sub-directories nested under this directory.</td></tr>
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
<a href="05ac8cdb-ff0b-7a5c-da07-61a1da637cb0">OpenDiscoverSDK.Interfaces.Platform.Inventory Namespace</a>  
