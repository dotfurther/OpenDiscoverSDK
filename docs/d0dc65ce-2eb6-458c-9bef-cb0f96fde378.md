# DesktopPublishing

Supported DesktopPublishing file formats (IdClassification.<a href="1e3a8090-926a-275b-2e9c-c0851d3c49e2">DesktopPublishing</a> - Desktop publishing document formats)
<ul><li>All entries in table below are supported for file format identification.</li><li>'X' in "Text" column indicates text extraction is supported for the file format.</li><li>'X**' in "Text" column indicates text extraction is supported BUT binary-to-text filtering is used on partially parsed document records.</li><li>'X' in "Metadata" column indicates metadata extraction is supported for the file format.</li><li>'X' in "EmbeddedItem" column indicates embedded item/attachment extraction is supported for the file format.</li><li>'X' in "ContentHash" column indicates a content hash is supported for the file format (see <a href="a852bcf7-e763-6d05-21d0-198c8c9e1fe3">MD5ContentHash</a> and <a href="66becb90-e903-e12d-cf4d-2a8aa6b65937">SHA1ContentHash</a>)</li></ul>






If a file format does not have a supported content extractor that extracts text then, optionally (default), a binary-to-text content extractor will be used to extract UTF-8, UTF-16, Windows-1252, and ASCII from the binary. In many cases, indexable text can be extract from unknown document formats.


<p><strong>DesktopPublishing Supported File Formats</strong></p><table><thead><tr><th><p>

File Format <a href="6f1047fb-7367-c09c-5621-ae7632c8404b">Id</a> Enum Value</p></th>
<th><p>Text</p></th>
<th><p>Metadata</p></th>
<th><p>EmbeddedItem</p></th>
<th><p>ContentHash</p></th>
<th><p>Description</p></th>
</tr></thead><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">MSPublisherCompoundFileCorrupted</a></p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>Microsoft Publisher compound file corrupted. Unable to determine specific format version (.pub).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">MSPublisher98to2003</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>Microsoft Publisher 98-2003 (.pub).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">MSPublisher2007to2016</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>Microsoft Publisher 2007-2016 (.pub).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">MSPublisherMhtml</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Microsoft Publisher exported as MHTML (.mht).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">SerifPagePlus</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Serif PagePlus desktop publishing (page layout) program developed by Serif (.ppp).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">SerifWebPlus</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Serif WebPlus website design program for Microsoft Windows (.wpp).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">PageMaker</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Adobe PageMaker desktop publishing file format (.pm3;.pm4;.pm5;.pm6;.p65;.pm7;.pmd).</p></td>
</tr></table>