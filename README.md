# Welcome to Open Discover® SDK for .NET
## Open Discover SDK is a .NET application programming interface (API) that allows for:
- Identifying file formats using internal binary signatures for reliable and fast file format identification (versus using unreliable file extensions)
- Extracting text from supported file formats and optionally identifying languages present in the extracted text
- Extracting metadata from supported file formats (over 1,325 known metadata fields in total)
- Extracting embedded items/attachments from supported document formats
- Extracting archive container items (7ZIP, ZIP, RAR, TAR, etc)
- Extracting mail store container email objects (PST, OST, OST2013, MBOX, etc)

## Open Discover SDK API is purposed for users to develop higher level document processing applications for:
- Full text search using Lucene.NET
- Machine learning using extracted text and metadata
- Text analytics and document concept clustering
- Information governance
- Website crawling/full-text website search
- Enterprise search and content management
- IT Departments - identify and de-duplicate documents on file servers
- eDiscovery applications 
- And more...

## This GitHub repository hosts the following C# examples that illustrate how to use the Open Discover SDK API
- DocumentIdentifier Example: shows how to use SDK to identify the document file formats of all files under an input directory/sub-directories
- ContentExtraction Example: illustrates the following SDK features:
   - How to extract text and metadata from office documents, PDFs, XPS, raster images, vector images, multimedia, and more
   - How to decrypted password protected office documents, PDFs, and archives
   - How to identify the languages present in extracted text
   - MD5/SHA-1 binary hashes and sophisticated content based hashes for emails and office documents. Hashes are useful for de-duplicating copies of same document or email whether saved as .msg, .eml, or .emlx.
   - How to extract items from archives such as 7ZIP, ZIP, RAR, split archives, self-extracting archives, etc.
   - Extract email objects from PST, OST, and MBOX mail stores
