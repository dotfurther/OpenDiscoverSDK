Copyright © 2019-2020 dotFurther Inc. All rights reserved.

# Welcome to Open Discover® SDK for .NET Code Examples
## Open Discover SDK is a .NET application programming interface (API) that supports:
- Identifying file formats using internal binary signatures for reliable and fast file format identification 
  (versus using unreliable file extensions, especially in embedded objects/attachments). 1400+ file formats 
  supported for identification.
- Extracting text from supported file formats and optionally identifying languages present in the extracted text
- Extracting metadata from supported file formats (over 1,350 known and documented metadata fields in total)
- Extracting embedded items/attachments from supported document formats
- Extracting archive container items (7ZIP, ZIP, RAR, TAR, etc)
- Extracting mail store container email objects (PST, OST, OST2013, MBOX, etc)

## The Open Discover SDK API is purposed for users to develop higher level document processing applications for:
- Full text indexing/search
- Machine learning using extracted text and metadata
- Text analytics and document concept clustering
- Information governance
- Website crawling/full-text website search
- Enterprise search and content management
- IT Departments - identify and de-duplicate documents on file servers
- eDiscovery applications 
- And more...

## Open Discover SDK Help:
The Open Discover SDK Help is publisher here: https://dotfurther.github.io/OpenDiscoverSDKHelp/

## This GitHub repository hosts the following C# examples that illustrate how to use the Open Discover SDK API
### DocumentIdentifier Example:
   - Shows how to use SDK to identify the document file formats of all files under an input directory and its 
     sub-directories. 
### ContentExtraction Example - illustrates the following SDK features:
   - How to extract text and metadata from office documents, PDFs, XPS, raster images, vector images, multimedia, and more
   - How to decrypt password protected office documents, PDFs, and archives
   - How to identify the languages present in extracted text
   - MD5/SHA-1 binary hashes and sophisticated content based hashes for emails and office documents. Hashes are useful for de-duplicating copies of same document or email whether saved as .msg, .eml, or .emlx.
   - How to extract items from archives such as 7ZIP, ZIP, RAR, split archives, self-extracting archives, etc.
   - Extract email objects from PST, OST, and MBOX mail stores
### PowerShell Example - shows how to create Cmdlets that use SDK to:
   - Identify file formats. This Cmdlet can be used in a pipeline to find file server files with specific formats or classifications
   - Extract all document content such as text, metadata, hyperlinks, attachments, etc. This Cmdlet can be used in a pipeline to search for and aggregate duplicate documents, search for documents with specific metadata values (i.e., author, creator, etc), search for specific text, etc. 
### Indexing Example - illustrates a simple indexing strategy using SDK with Lucene.NET and how to make indexes better by:
   - Indexing all document extracted metadata as fields.
   - Indexing document format ID as a field. Users can limit searches for documents with very specific formats.
   - Indexing document format classification as fields (ex: WordProcessing, Spreadsheet, etc are file format classifications). Users can limit searches to all "WordProcessing" or all "Spreadsheet" document classifications, for example.
   - Indexing MD5/SHA-1 binary and content based hashes as fields. When searching index, duplicate documents returned by a search can be indicated and grouped together.
   - Indexing languages identified in extracted text as a field to aid in searching for documents that contain foreign languages.
