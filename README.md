Download the latest price paid data in CSV from here: http://prod.publicdata.landregistry.gov.uk.s3-website-eu-west-1.amazonaws.com/pp-monthly-update-new-version.csv and work out what the most expensive (on average) 10 post code prefixes are
Don’t use any external libraries (even though it would be better to use a CSV library). 

Linq is not an external library. Feel free to use it as much as you'd like. 

The postcode prefix is the first part of the postcode e.g for SE16 7TG the prefix would be SE16.

Attempt to balance efficiency with clear code.

There are no headers. 

The 2nd column is the amount and the 4th one the postcode.

It's not an OO structuring question.

It should be a console app

e.g. if we had this data: 

PostCode | Amount

SE15 2TH | 100

SE15 5NY | 200

SE12 8TW | 50


The output should be:

Prefix | Average

SE15   | 150

SE12   | 50

