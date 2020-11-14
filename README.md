Copyright © 2019-2020 dotFurther Inc. All rights reserved.

# Welcome to Open Discover® SDK for .NET Code Examples
## Open Discover SDK is a .NET application programming interface (API) that supports:
* Identifying file formats using internal binary signatures for reliable and fast file format identification 
  (versus using unreliable file extensions, especially in embedded objects/attachments). 1500+ file formats 
  supported for identification.
* Extracting text from supported file formats and optionally identifying languages present in the extracted text
* Extracting metadata from supported file formats (over 1,350 known and documented metadata fields in total)
* Extracting embedded items/attachments from supported document formats
* Extracting archive container items (7ZIP, ZIP, RAR, TAR, etc)
* Extracting mail store container email objects (PST, OST, OST2013, MBOX, etc)
* Detecting and extracting information on 18 types of personally identifiable information (PII) (in extracted text and metadata):
     * Social security numbers
     * Credit card numbers (13-19 digits)
     * IBAN account numbers
     * Investment account numbers
     * Email addresses
     * Phone numbers
     * Street addresses
     * Date of birth
     * Driver's license numbers
     * Passport numbers
     * Maiden names
     * Health care number/member IDs
     * License plate numbers
     * Vehicle identification numbers (VIN)
     * IP addresses (IPv4 and IPv6)
     * Cryptocurrency addresses
* Detecting 4 types of sensitive security information (in extracted text and metadata):
     * Passwords
     * Usernames
     * Network names
     * Database credentials
* Detecting custom defined sensitive item search types in extracted text and metadata.
     * Create your own entity or sensitive item definitions

## The Open Discover SDK API is purposed for users to develop higher level document processing applications for:
* Full text indexing/search
* Machine learning using extracted text and metadata
* Text analytics and document concept clustering
* Information governance
* Website crawling/full-text website search
* Enterprise search and content management
* IT Departments - identify documents with sensitive information and/or de-duplicate documents on file servers. 
* eDiscovery applications such as early case assessment (ECA) or full processing
* And more...

## Open Discover SDK Help:
The Open Discover SDK Help is published here: https://dotfurther.github.io/OpenDiscoverSDKHelp/

## This GitHub repository hosts the following C# examples that illustrate how to use the Open Discover SDK API
### DocumentIdentifier Example:
   * Shows how to use SDK to identify the document file formats of all files under an input directory and its 
     sub-directories. 
### ContentExtraction Example - illustrates the following SDK features:
   * How to extract text and metadata from office documents, PDFs, XPS, raster images, vector images, multimedia, and more
   * How to decrypt password protected office documents, PDFs, and archives
   * Identified languages present in extracted text
   * MD5/SHA-1 binary hashes and sophisticated content based hashes for emails and office documents. Hashes are useful for de-duplicating copies of same document or email whether saved as .msg, .eml, or .emlx.
   * How to extract items from archives such as 7ZIP, ZIP, RAR, split archives, self-extracting archives, etc.
   * Extract email objects from PST, OST, and MBOX mail stores
   * Sensitive item detection such as social security, credit card numbers, IBAN, driver's license numbers, license plate numbers, phone numbers, emails, and much more.
### PowerShell Example - shows how to create Cmdlets that use SDK to:
   * Identify file formats. This Cmdlet can be used in a pipeline to find file server files with specific formats or classifications
   * Extract all document content such as text, metadata, hyperlinks, attachments, etc. This Cmdlet can be used in a pipeline to search for and aggregate duplicate documents, search for documents with specific metadata values (i.e., author, creator, etc), search for specific text, etc. 
### Indexing Example - illustrates a simple indexing strategy using SDK with Lucene.NET and how to make indexes better by:
   * Indexing all document extracted metadata as fields.
   * Indexing document format ID as a field. Users can limit searches for documents with very specific formats.
   * Indexing document format classification as fields (ex: WordProcessing, Spreadsheet, etc are file format classifications). Users can limit searches to all "WordProcessing" or all "Spreadsheet" document classifications, for example.
   * Indexing MD5/SHA-1 binary and content based hashes as fields. When searching index, duplicate documents returned by a search can be indicated and grouped together.
   * Indexing languages identified in extracted text as a field to aid in searching for documents that contain foreign languages.
   * Indexing the sensitive item information (PII) in order to find sensitive documents. Note: your index will now contain sensitive information and should be protected and/or properly disposed of when done auditing documents for sensitive information is complete.
