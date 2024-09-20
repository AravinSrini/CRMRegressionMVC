@17531 @Sprint59 @New_Regression
Feature: Dashboard LTL get quote flow

Scenario Outline: Verify the navigation to the quote pages for LTL Truckload Partial TruckLoad and Intermodal From Dashboard
Given I am a shp.entry,shp.inquiry user
When I choose <serviceOption> radio button
And click on GetQuote button on the dashboard
Then I should be navigated to get quote page for the service <ShipmentPageToRedirect>
Examples: 
| serviceOption       | ShipmentPageToRedirect |
| LTL                 | Get Quote (LTL)        |
| Truckload           | Truckload              |
| Partial Truckload   | Partial Truckload      |
| Intermodal          | Intermodal             |

Scenario Outline: Verify the navigation to the quote pages for Domestic Forwarding
Given I am a shp.entry,shp.inquiry user
When I choose Domestic Forwarding radio button and choose <quoteType> for domestic forwarding quote
And click on GetQuote button on the dashboard
Then I should be navigated to get quote page for the service Domestic Forwarding
And I will see the type for the quote as <quoteType>
Examples: 
 | quoteType       |
 | Next Flight Out |
 | Same Day        |
 | Next Day        |
 | Next Day AM     |
 | 2 Day           |
 | 2 Day AM        |
 | 3 Day           |
 | 3 Day AM        |
 | Economy         |
 | White Glove     |
 | Hot Shot        |
 | Full Truck Load |
 | Local           |
 | Charter         |

Scenario Outline: Verify the navigation to the quote pages for International
Given I am a shp.entry,shp.inquiry user
When I choose International radio button and choose <quoteType> and <additonalType> for international quote
And click on GetQuote button on the dashboard
Then I should be navigated to get quote page for the service International
And I will see the type for the quote as <shipmentInformationType>
Examples: 
 | quoteType      | additonalType     | shipmentInformationType          |
 | Air - Import   | Air Consolidation | Air - Import - Air Consolidation |
 | Air - Import   | Air Direct        | Air - Import - Air Direct        |
 | Air - Export   | Air Consolidation | Air - Export - Air Consolidation |
 | Air - Export   | Air Direct        | Air - Export - Air Direct        |
 | Ocean - Import | Ocean LCL         | Ocean - Import - Ocean LCL       |
 | Ocean - Import | Ocean FCL         | Ocean - Import - Ocean FCL       |
 | Ocean - Export | Ocean LCL         | Ocean - Export - Ocean LCL       |
 | Ocean - Export | Ocean FCL         | Ocean - Export - Ocean FCL       |