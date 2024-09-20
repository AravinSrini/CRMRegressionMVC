@ViewRatesButton @Sprint69 @28052

Feature: ViewRatesButton_AllUsers
	
@GUI @Functional
Scenario Outline: Verify the Shipment Results page for ShipEntry Users, Operation, Sales, Sales Management, Station Owner Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
    And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I enter data in the Origin Section <OlocationName>,<OLocationAddress>,<OriginZip>
	And I enter data in the Destination Section <DDestinationName>,<DDestinationAddress>,<DestinationZip>
	And I click on View rates button in add shipment ltl page
	Then API Response of the shipment results should match with UI<Customer_Name>, <Service> ,<OriginCity>, <OriginZip>, <OriginState>, <OriginCountry>, <DestinationCity>, <DestinationZip>, <DestinationState>, <DestinationCountry>,<Classification>,<Quantity>, <QuantityUNIT>, <Weight>,<WeightUnit>,<Username>

Examples: 
| Scenario | Username     | Password | UserType  | CustomerAccName        | Service | OlocationName  | OLocationAddress      | OriginZip | OriginCity | OriginState | OriginCountry | DDestinationName    | DDestinationAddress        | DestinationZip | DestinationCity | DestinationState | DestinationCountry | Classification | NMFC | Quantity | QuantityUNIT | ItemDescription | Weight | WeightUnit |
| S1       | crmOperation | Te$t1234 | Operation | ZZZ - GS Customer Test | LTL     | OriginTestView | OriginTestViewAddress | 33126     | Miami |FL           | USA           | DestinationTestView | DestinationTestViewAddress | 85282          | Tempe           | AZ               | USA                | 50             | 6778 | 6        | Skids        | ItemInformation1 | 1000  | LBS        |