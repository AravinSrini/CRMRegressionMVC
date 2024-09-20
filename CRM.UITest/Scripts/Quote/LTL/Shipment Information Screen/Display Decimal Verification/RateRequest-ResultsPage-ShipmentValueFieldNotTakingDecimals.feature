@LTLQuoteResultspageShipmentValeNotTakingDecimalValues @19750 @Sprint62
Feature: RateRequest-ResultsPage-ShipmentValueFieldNotTakingDecimals

@Regression
Scenario Outline: Test to verify the Shipment Value text box taking decimal values on Get Quote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid data in mandatory Item section <Classification>, <Weight>
And I click on view quote results button
And I will be navigated results page with rates
Then I should be able to enter decimal value in <ShipmentValue> text box
And I click on Show Insured Rate button
And I will be displayed with <ShipmentValue> in decimals
And I should be displayed with updated Insured rate column in the grid

Examples: 
| Scenario | Username | Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue |
| s1       | zzz      | Te$t1234 | LTL     | 15370     | 51301          | 250            | 1300   | 100.98        |
| s2       | zzz      | Te$t1234 | LTL     | 60606     | 33126          | 50             | 90     | 89.50         |

@Regression
Scenario Outline: Test to verify the Shipment Value text box on Create Shipment pop up taking decimal values on Get Quote(LTL) page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid data in mandatory Item section <Classification>, <Weight>
And I click on view quote results button
And I will be navigated results page with rates
And I click on Create shipment for selected carrier
Then I will be displayed with Shipment Value of Insured Rates modal pop up
And I should be able to enter decimal value in <ShipmentValue> text box of modal pop up
And I click on Show Insured Rates button in the modal pop up
And I should be displayed with updated Insured rate column in the grid

Examples: 
| Scenario | Username              | Password  | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue |
| s1       | testing@ltlfilter.com | Passw0rd1 | LTL     | 60606     | 15370          | 55             | 700    | 1000.00       |
| s2       | testing@ltlfilter.com | Passw0rd1 | LTL     | 60563     | 60606          | 50             | 90     | 89.50         |

@Regression
Scenario Outline: Test to verify the Shipment Value text box taking decimal values on Shipment Information page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid data in mandatory Item section <Classification>, <Weight>
And I enter decimal values in <ShipmentValue>
And I click on view quote results button
And I will be navigated results page with rates
Then I will be displayed with <ShipmentValue> in decimals
And I should be displayed with updated Insured rate column in the grid

Examples: 
| Scenario | Username | Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue |
| s1       | zzz      | Te$t1234 | LTL     | 15370     | 51301          | 250            | 1300   | 100.00        |
| s2       | zzz      | Te$t1234 | LTL     | 60606     | 33126          | 50             | 90     | 99.50         |
