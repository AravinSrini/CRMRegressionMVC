@36454 @Sprint75 
Feature: Add Shipment (LTL) (MVC5) - Rename Default Special Instructions field

@GUI
Scenario Outline: 36454_Test to verify the Rename Default Special Instructions field_shipment
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
And   I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When I am on the Add Shipment (LTL) page <Usertype>, <CustomerName>
Then I should  be displayed with Default Special Instructions field as "<SpecialInstructions>" on add shipment page

Examples: 
| Scenario | Username     | Password | CustomerName           | Usertype | Service | oZip  | dZip  | classification | weight | SpecialInstructions  | WindowWidth | WindowHeight |
| S1       | crmOperation | Te$t1234 | ZZZ - GS Customer Test | Internal | LTL     | 33126 | 85282 | 50             | 200    | Special Instructions | 1300        |  750         |

@GUI
Scenario Outline: 36454_Test to verify the Rename Default Special Instructions field_savedquote to shipment
#Creating Quote
Given I am a shp.entry user <Username> <Password>
When I am on Rate Resultspage <userType>, <customerName>, <oZip>, <dZip>, <classification> and <weight>
And I click on save rate as quotelink for selected carrier in results page of '<userType>'
#creating quote to shipment
Given  I am in the Quote Section of the non expired LTL quote <Account>,<userType>
When I click on the Create Shipment button
Then I should  be displayed with Default Special Instructions field as "<SpecialInstructions>" on add shipment page

Examples: 
| Scenario | Username                 | Password | Account                  | userType | customerName             | oZip  | dZip  | classification | weight | SpecialInstructions |
| S1       | crmOperation             | Te$t1234 | ZZZ - GS Customer Test   | Internal | ZZZ - GS Customer Test   | 33126 | 85282 | 50             | 200    | Special Instructions|
| S2       | zzzext                   | Te$t1234 | ZZZ - Czar Customer Test | External | ZZZ - Czar Customer Test | 33126 | 85282 | 50             | 200    | Special Instructions|

@GUI
Scenario Outline: 36454_Test to verify the Rename Default Special Instructions field_rate to shipment 
Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
When I am on Rate Resultspage <userType>, <customerName>, <oZip>, <dZip>, <classification> and <weight>
And I click on createshipment for selected carrier in results page of '<userType>'
Then I should  be displayed with Default Special Instructions field as "<SpecialInstructions>" on add shipment page

Examples: 
| Scenario | Username                  | Password |userType | customerName           |oZip  | dZip  | classification | weight | SpecialInstructions |
| s1       |crmOperation   	           | Te$t1234 | Internal | ZZZ - GS Customer Test |33126 | 85282 | 50             |1000   | Special Instructions|
| s2       | zzzext@user.com           | Te$t1234 | External |ZZZ - Czar Customer Test|33126 | 85282 | 50             |2      | Special Instructions|

