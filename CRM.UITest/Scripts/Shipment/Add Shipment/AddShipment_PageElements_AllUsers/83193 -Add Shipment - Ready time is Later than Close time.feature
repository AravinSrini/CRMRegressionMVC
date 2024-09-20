@Sprint90 @83193
Feature: 83193 -Add Shipment - Ready time is Later than Close time
	
@Regression
Scenario Outline: 83193 - Ready time is Later than Close time for external user
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	When I click on Add Shipment Button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	And I enter data in the Origin Section <OlocationName>,<OLocationAddress>,<OriginZip>
	And I enter data in the Destination Section <DDestinationName>,<DDestinationAddress>,<DestinationZip>
	And I enter data in the Freight Description <Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>,<user>,<OrderNumber>,<GLCode>,<ReferenceNumber>,<ReferenceNumber2>
    Then I select Pickup date <Closetime>
	And I select PickUp date <Readytime> that is after Pickup Date Close time
	When I click on View rates button in add shipment ltl page
	Then i should receive a message stating - Please select a Pickup Date Close time that is after the Pickup Date Ready time.Then I should receive message stating - Please select a Pickup Date Ready time that is before the Pickup Date Close time.

Examples: 
| user  |OlocationName  | OLocationAddress      | OriginZip | OriginCity | OriginState | OriginCountry | DDestinationName    | DDestinationAddress        | DestinationZip | DestinationCity | DestinationState | DestinationCountry | Classification | nmfc | quantity | QuantityUNIT | itemdesc | weight | WeightUnit |Readytime | Closetime |
| External | OriginTestView | OriginTestViewAddress | 33126     | Miami |FL           | USA           | DestinationTestView | DestinationTestViewAddress | 85282          | Tempe           | AZ               | USA                | 50             | 6778 | 6        | Skids        | ItemInformation1 | 1000  | LBS        |02:00 AM   | 01:00 AM   |



@Regression
Scenario Outline: 83193 - Ready time is Later than Close time for internal user
	Given I am a user and login into application with valid <user> user
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I select a customer of TMS type MG or Both from the customer selection dropdown
	When I click on Add Shipment button for Internal Users
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	And I enter data in the Origin Section <OlocationName>,<OLocationAddress>,<OriginZip>
	And I enter data in the Destination Section <DDestinationName>,<DDestinationAddress>,<DestinationZip>
	And I enter data in the Freight Description <Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>,<user>,<OrderNumber>,<GLCode>,<ReferenceNumber>,<ReferenceNumber2>
	Then I select Pickup date <Closetime>
	And I select PickUp date <Readytime> that is after Pickup Date Close time
	When I click on View rates button in add shipment ltl page
	Then i should receive a message stating - Please select a Pickup Date Close time that is after the Pickup Date Ready time.Then I should receive message stating - Please select a Pickup Date Ready time that is before the Pickup Date Close time.

Examples: 
 | user       | OlocationName  | OLocationAddress      | OriginZip | OriginCity | OriginState | OriginCountry | DDestinationName    | DDestinationAddress        | DestinationZip | DestinationCity | DestinationState | DestinationCountry | Classification | nmfc | quantity | QuantityUNIT | itemdesc         | weight | WeightUnit | Readytime | Closetime | OrderNumber | GLCode | ReferenceNumber | ReferenceNumber2 |
 | Sales      | OriginTestView | OriginTestViewAddress | 33126     | Miami      | FL          | USA           | DestinationTestView | DestinationTestViewAddress | 85282          | Tempe           | AZ               | USA                | 50             | 6778 | 6        | Skids        | ItemInformation1 | 1000   | LBS        | 02:00 AM  | 01:00 AM  | 123         | 234    | 3456            | 8976             |
 | Operations | OriginTestView | OriginTestViewAddress | 33126     | Miami      | FL          | USA           | DestinationTestView | DestinationTestViewAddress | 85282          | Tempe           | AZ               | USA                | 50             | 6778 | 6        | Skids        | ItemInformation1 | 1000   | LBS        | 02:00 AM  | 01:00 AM  | 123         | 234    | 3456            | 8976             |
