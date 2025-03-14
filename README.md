# barcodegen

A simple .NET console app to generate a barcode (Code 39 extended format) from a text value.

This only uses the **barcoder** library (<https://github.com/huysentruitw/barcoder>)


## Prerequisites

* Install dotnet 8.0


## How to run

* Use

  `dotnet run "TEST"`

  to generate a Code 39 Extended (full ascii mode) barcode for the string "TEST" (output PNG).


* Use

  `dotnet run "TEST" -svg`

  to generate a Code 39 Extended (full ascii mode) barcode for the string "TEST" (output SVG).


* Output is always done in a sub-directory "output".


## Managed format

If you want to manage one of following format, just clone this repo and alter the code based on **barcoder** documentation.

* 2 of 5
* Aztec Code
* Codabar
* Code 39
* Code 93
* Code 128
* Code 128 GS1
* Data Matrix (ECC 200)
* Data Matrix GS1
* EAN 8
* EAN 13
* KIX (used by PostNL)
* PDF 417
* QR Code
* RM4SC (Royal Mail 4 State Code)
* UPC A
* UPC E


