Copyright © 2019-2025 dotFurther Inc. All rights reserved.

### API Help: https://dotfurther.github.io/OpenDiscoverSDK

# Welcome to Open Discover® SDK for .NET Code Examples
### At this time, Open Discover SDK is only available for evaluation to companies that are in the eDiscovery, incidence response, data breach, AI/ML, and information governance industries or in an industry that ingests/processes large volumes of documents. We also provide higher level APIs built upon the SDK, Open Discover Platform, that help customers easily and quickly build high volume/high throughput document processing workflows. 

### See white paper on Azure performance of a distributed document processing/entity extraction workflow system built upon the OpenDiscover SDK:  https://github.com/dotfurther/Open-Discover-WhitePaper-1

### Contact us if your company meets these requirements and are interested in evaluating the APIs: https://dotfurther.com/contact-us/

## Open Discover® SDK is a .NET 8 application programming interface (API) that supports:
* Identifying file formats using internal binary signatures for reliable and fast file format identification 
  (versus using unreliable file extensions, especially in embedded objects/attachments). 1,570+ file formats 
  supported for identification.
* Extracting text from supported file formats and optionally identifying languages present in the extracted text.
     * Supported file formats for identification and extraction: https://dotfurther.github.io/OpenDiscoverSDK/html/7e782821-dd62-4262-b342-f603ac374bba.htm
* Extracting metadata (includes user defined custom metadata) from supported file formats (over 1,400 known and documented metadata fields in total)
    * All known metadata extracted and documented: https://dotfurther.github.io/OpenDiscoverSDK/html/520b27cc-9ac9-4549-2981-558ed96ae428.htm
* Extracting embedded items/attachments from supported document formats
* Extracting archive container items (7ZIP, ZIP, RAR, TAR, split archives, etc)
* Extracting mail store container email objects (PST, OST, OST2013, OLM, MBOX, etc)
* Detecting and extracting information on 25 types of personally identifiable information (PII) (in extracted text and metadata):
     * Social security numbers
     * Credit card numbers (13-19 digits)
     * Bank account numbers
     * IBAN account numbers
     * Investment account numbers
     * Email addresses
     * Phone numbers
     * Street addresses
     * Date of birth
     * Driver's license numbers
     * State ID card numbers
     * Passport numbers
     * Maiden names
     * Health care number/member IDs
     * License plate numbers
     * Vehicle identification numbers (VIN)
     * Social media accounts
     * IP addresses (IPv4 and IPv6)
     * MAC addresses
     * Cryptocurrency addresses
     * And more... See https://dotfurther.github.io/OpenDiscoverSDK/html/2caef568-f7bd-69fc-89c4-aa0d3e2c497b.htm
* Detecting 4 types of sensitive security information (in extracted text and metadata):
     * Passwords
     * Usernames
     * Network names
     * Database credentials
* Detecting and extracting information on many entity types related to:
     * Person name
     * Medical records
     * Health care/insurance
     * Student records
     * HR records
     * Legal matters
     * URLs
     * General accounts
     * Emojis (and their group, subgroup, and name) 
     * Gender
     * Religion
     * Form entry fields related to sensitive items
     * Policy numbers
     * Insurance
     * 350+ entity types extracted (along with all content, in one simple API call and at a very high performance).
* Ability to define and detect user defined custom sensitive/entity item types in extracted text and metadata.
     * Create your own entity or sensitive item definitions
* Open Discover SDK does not use regular expressions for sensitive/entity item detection; however, user defined custom sensitive/entity items have an option to use regular expressions.

## The Open Discover® SDK API is purposed for users to develop higher level document processing applications for:
* Full text indexing/search
* Machine learning using extracted text and metadata
* Text analytics and document concept clustering
* Information governance
* Website crawling/full-text website search
* Enterprise search and content management
* IT Departments - identify documents with sensitive information and/or that are redunant, obsolete, and trivial (ROT). 
* eDiscovery applications such as early case assessment (ECA) or full processing/indexing
* And more...

In addition to the Open Discover SDK, we also provide higher level APIs built upon the SDK (Open Discover Platform) that help users build
high volume document processing workflows.

## This GitHub repository hosts the following C# examples that illustrate how to use the Open Discover SDK API
### [DocumentIdentifier Example:](./CSharpExamples/DocumentIdentifier/README.md) 
   * Shows how to use SDK to identify the document file formats of all files under an input directory and its 
     sub-directories. 
### [ContentExtraction Example - illustrates the following SDK features:](./CSharpExamples/ContentExtraction/README.md)
   * How to extract text and metadata from office documents, PDFs, XPS, raster images, vector images, multimedia, and more
   * How to decrypt password protected office documents, PDFs, and archives
   * Identified languages present in extracted text
   * MD5/SHA-1/SHA-256 binary hashes and sophisticated content based hashes for emails and office documents. Hashes are useful for de-duplicating copies of the same document or email whether saved as .msg, .eml, or .emlx.
   * How to extract items from archives such as 7ZIP, ZIP, RAR, split archives, self-extracting archives, etc.
   * How to extract email objects from PST, OST, and MBOX mail stores
   * Sensitive item detection (PII) such as social security, credit card numbers, IBAN, driver's license numbers, license plate numbers, phone numbers, emails, and much more.
### [PowerShell Example - shows how to create Cmdlets that use SDK to:](./CSharpExamples/PowerShellExample/README.md)
   * Identify file formats. This Cmdlet can be used in a pipeline to find file server files with specific formats or classifications
   * Extract all document content such as text, metadata, hyperlinks, attachments, etc. This Cmdlet can be used in a pipeline to search for and aggregate duplicate documents, search for documents with specific metadata values (i.e., author, creator, etc), search for specific text, etc. 
