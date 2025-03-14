# barcodegen

A simple .NET console app to generate a barcode (Code 39 extended format) from a text value. 

This encapsulates the library "barcoder" (<https://github.com/huysentruitw/barcoder>)

## Prerequisites

* Install dotnet 8.0

## How to run

* Use

  `dotnet run "TEST"`

  to generate a Code 39 Extended barcode for the string "TEST" (output PNG).


* Use

  `dotnet run "TEST" -svg`

  to generate a Code 39 Extended barcode for the string "TEST" (output SVG).


