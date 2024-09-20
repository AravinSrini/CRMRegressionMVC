@LTLQuoteResultspageDisplayDecimaltoTwoPlaces @19221 @Sprint62
Feature: RateRequest-QuoteResults-DisplayDecimaltoTwoPlaces

@Regression
Scenario Outline: Test to verify the New and Used amount under the carrier should be displayed with two decimal places
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
Then I must be displayed with New and Used amount decimal to two places


Examples: 
| Scenario | Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue |
| s1       | zzz      | Te$t1234 | LTL     | 90001     |             |             | 90001          | Los Angeles     | LA               | 50             | 50     |     1000.00   |
| s2       | zzz      | Te$t1234 | LTL     | 33126     |             |             | 60606          | Los Angeles     | LA               | 50             | 50     |               |

@Regression
Scenario Outline: Test to verify the Rate, Fuel, Line Haul, Accessorials under Rate grid should be displayed with two decimal places
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
Then I must be displayed with Rate, Fuel, Line Haul and Accessorials decimal to two places of Rate grid

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue |  
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90001          | Los Angeles     | CA               | 70             | 100    | 1000          | 


@Regression
Scenario Outline: Test to verify the Insured Rate, Fuel, Line Haul, Accessorials under Insured Rate grid should be displayed with two decimal places
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
Then I must be displayed with Insured Rate, Fuel, Line Haul and Accessorials decimal to two places of Insured Rate grid

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | 
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90001          | Los Angeles     | CA               | 70             | 100    | 1000          |

@Regression
Scenario Outline: Test to verify the New and Used amount under the Guaranteed Rate carrier should be displayed with two decimal places
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
Then I must be displayed with New and Used amount decimal to two places of Guaranteed Carrier Grid

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | 
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90001          | Los Angeles     | CA               | 70             | 100    | 1000          | 


@Regression
Scenario Outline: Test to verify the Rate, Fuel, Line Haul, Accessorials under Guaranteed Rate grid should be displayed with two decimal places
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
Then I must be displayed with Rate, Fuel, Line Haul and Accessorials decimal to two places of Guaranteed Rate grid

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | 
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90001          | Los Angeles     | CA               | 70             | 100    | 1000          | 


@Regression
Scenario Outline: Test to verify the Insured Rate, Fuel, Line Haul, Accessorials under Guaranteed Insured Rate grid should be displayed with two decimal places
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid mandatory data in Item section <Classification>, <Weight>, <ShipmentValue>
And I click on view quote results button
Then I must be displayed with Insured Rate, Fuel, Line Haul and Accessorials decimal to two places of Guaranteed Insured Rate grid

Examples: 
| Username | Password | Service | OriginZip | OriginCity  | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue |  
| zzz      | Te$t1234 | LTL     | 90001     | Los Angeles | CA          | 90001          | Los Angeles     | CA               | 70             | 100    | 1000           |



@Regression
Scenario Outline: Test to verify the all rates be displayed with two decimal places
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter valid data origin zip in Origin section <OriginZip>
And I enter valid data destination zip in Destination section <DestinationZip>
And I enter valid data in mandatory Item section <Classification>, <Weight>
And I click on view quote results button
Then I should able to enter decimal value in <ShipmentValue> text box
And I click on Show Insured Rate button 
Then I must be displayed all rates with two decimal points

Examples: 
| Scenario | Username | Password | Service | OriginZip | DestinationZip | Classification | Weight | ShipmentValue   |
| s1       | zzz      | Te$t1234 | LTL     | 60606     | 15370          | 55             | 700    | 100             |


