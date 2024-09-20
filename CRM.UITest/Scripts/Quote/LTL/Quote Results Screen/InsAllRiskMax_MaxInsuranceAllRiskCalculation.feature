@19275 @Sprint62 @InsAllRiskMax_MaxInsuranceAllRiskCalculation
Feature: InsAllRiskMax_MaxInsuranceAllRiskCalculation

@Regression
Scenario Outline: Verify Insurance rate calculation when value is entered from shipment information page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
	And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>
	And I enter valid data in Item section <Classification>, <Weight>, <ShipmentValue> and <AdditionalService>
	And I click on view quote results button
	Then rate results page should be displayed
	And Insurance calculated value <Username> should be added for the accessorial of carrier for the passed <ShipmentValue>

Examples: 
| Scenario | Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue | AdditionalService |
| S1       | nat      | Te$t1234 | LTL     | 33126     | Miami      | FL          | 85282          | Tempe           | AZ               | 70             | 100    | 1000          | Appointment       |

@Regression
Scenario Outline: Verify Insurance rate calculation when value is entered from rate results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I enter valid data in Origin section <OriginZip>, <OriginCity> and <OriginState>
	And I enter valid data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>	
	And I enter valid data only in Item section <Classification>, <Weight>
	And I click on view quote results button
	And I enters the value in <ShipmentValue> Textbox
    And I clicks on Show Insured Rate button
	Then Insurance calculated value <Username> should be added for the accessorial of carrier for the passed <ShipmentValue>

Examples: 
| Scenario | Username | Password | Service | OriginZip | OriginCity | OriginState | DestinationZip | DestinationCity | DestinationState | Classification | Weight | ShipmentValue |
| S1       | nat      | Te$t1234 | LTL     | 33126     | Miami      | FL          | 85282          | Tempe           | AZ               | 70             | 100    | 100           |