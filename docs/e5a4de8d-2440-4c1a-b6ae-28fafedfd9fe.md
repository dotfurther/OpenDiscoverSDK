# DocumentExchange

Supported DocumentExchange file formats (IdClassification.<a href="1e3a8090-926a-275b-2e9c-c0851d3c49e2">DocumentExchange</a> - Document exchange formats. Document exchange formats are non-program specific, i.e., different applications can output these exchangable document formats.)
<ul><li>All entries in table below are supported for file format identification.</li><li>'X' in "Text" column indicates text extraction is supported for the file format.</li><li>'X**' in "Text" column indicates text extraction is supported BUT binary-to-text filtering is used on partially parsed document records.</li><li>'X' in "Metadata" column indicates metadata extraction is supported for the file format.</li><li>'X' in "EmbeddedItem" column indicates embedded item/attachment extraction is supported for the file format.</li><li>'X' in "ContentHash" column indicates a content hash is supported for the file format (see <a href="a852bcf7-e763-6d05-21d0-198c8c9e1fe3">MD5ContentHash</a> and <a href="66becb90-e903-e12d-cf4d-2a8aa6b65937">SHA1ContentHash</a>)</li></ul>






If a file format does not have a supported content extractor that extracts text then, optionally (default), a binary-to-text content extractor will be used to extract UTF-8, UTF-16, Windows-1252, and ASCII from the binary. In many cases, indexable text can be extract from unknown document formats.


<p><strong>DocumentExchange Supported File Formats</strong></p><table><thead><tr><th><p>

File Format <a href="6f1047fb-7367-c09c-5621-ae7632c8404b">Id</a> Enum Value</p></th>
<th><p>Text</p></th>
<th><p>Metadata</p></th>
<th><p>EmbeddedItem</p></th>
<th><p>ContentHash</p></th>
<th><p>Description</p></th>
</tr></thead><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">MicrosoftXPS</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p /></td>
<td><p>Microsoft XPS (Open XML Paper Specification) (.xps).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">MicrosoftXPSCorrupted</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p /></td>
<td><p>Microsoft XPS (Open XML Paper Specification) that is potentially corrupted. The format's zip container failed inspection (zip potentially truncated) and format had to be identified using an alternate means (.xps).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDF</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Adobe Portable Document Format (PDF) (.pdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDFEncrypted</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Encrypted Adobe Portable Document Format (PDF) (.pdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDF_Portfolio</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Adobe Portable Document Format (PDF) Portfolio. A PDF Portfolio contains multiple files assembled into an integrated PDF unit (.pdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDF_PortfolioEncrypted</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Encrypted Adobe Portable Document Format (PDF) Portfolio. A PDF Portfolio contains multiple files assembled into an integrated PDF unit (.pdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDF_XFA</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Adobe Portable Document Format (PDF) XML Forms Architecture (XFA). An XFA PDF is a interactive and dynamic form created with AEM Forms Designer (.pdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDF_XFAEncrypted</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Encrypted Adobe Portable Document Format (PDF) XML Forms Architecture (XFA). An XFA PDF is a interactive and dynamic form created with AEM Forms Designer (.pdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDFAcroForm</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Adobe Portable Document Format (PDF) AcroForm. AcroForm is Adobe’s older interactive form technology (.pdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobePDFAcroFormEncrypted</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Encrypted Adobe Portable Document Format (PDF) AcroForm. AcroForm is Adobe’s older interactive form technology (.pdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobeFormsDataFormat</a></p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>Acrobat Forms Data Format (FDF) (.fdf)</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobeXDP</a></p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>Adobe XML Data Package (XDP) format, this format allows PDF and/or XFA content resources to be packaged within an XML container (.xdp).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">AdobeXFDF</a></p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>Adobe XML Forms Data Format (XFDF) is a format for representing forms data and annotations in a PDF document. XFDF is an XML version of Forms Data Format (FDF) (.xfdf).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">RichTextFormat</a></p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p>Microsoft Rich Text Format (*.rtf)</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">DjVu</a></p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>DjVu file format. This file format was designed primarily to store scanned documents but is also used as eBook format and has been promoted as an alternative to PDF (.djv;.djvu).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">DjVuEncrypted</a></p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>Encrypted (secure) DjVu file format. This format designed primarily to store scanned documents but is also used as eBook format and has been promoted as an alternative to PDF (.djv;.djvu).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">PostScript</a></p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>Adobe Postscript (.ps).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">EncapsulatedPostScript</a></p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>Adobe Encapsulated Postscript (.eps;.epsf;.ps).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">EncapsulatedPostScriptWithPreviewImage</a></p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>Encapsulated PostScript with content preview image (usually TIFF image) (.eps;.epsf;.epsi).</p></td>
</tr><tr><td><p><a href="6f1047fb-7367-c09c-5621-ae7632c8404b">DocBookXml</a></p></td>
<td><p>X</p></td>
<td><p /></td>
<td><p /></td>
<td><p /></td>
<td><p>OASIS DocBook XML document for general and technical publishing (.xml).</p></td>
</tr></table>