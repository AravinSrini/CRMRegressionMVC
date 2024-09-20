@30013 @Regression @Sprint70
Feature: Domestic Forwarding_Submit Rate Request_Manually enter data and Verify Uploaded Document
	

@Regression
Scenario Outline: Verify the submit rate request functionality 
	Given I am a shp.inquiry or shp.entry user - <Username> and <Password>
    And I am on the Rate Request page for Domestic Forwarding
	And I enter data in origin on Shipment Locations and Dates page <OriginLocationName>,<OriginAddress1>,<OriginCountry>,<OriginZip>,<OriginState>,<OriginCity>,<OriginContactName>,<OriginPhoneNo>
	And I enter data in destination on Shipment Locations and Dates page <DestinationLocationName>,<DestinationAddress1>,<DestinationCountry>,<DestinationZip>,<DestinationState>,<DestinationCity>,<DestinationContactName>,<DestinationPhoneNo>
	And I enter data in frieght description on Shipment Locations and Dates page <SelectItem>,<Pieces>,<Weight>,<Lenght>,<Width>,<Height>,<Description>
	And I enter addtional pieces in frieght description on Shipment Locations and Dates page <SelectItem1>,<Pieces1>,<Weight1>,<Lenght1>,<Width1>,<Height1>,<Description1>
	And I enter the Reference numbers on Shipment Locations and Dates page <RefType>,<RefNumber>,<CustType>
	And I enter the additional Services and accessorial on Shipment Locations and Dates page <ServicesType>,<ShipmentValue> and <DefaultSpecialInstruction>
	When I click on the Save and Continue Button
	Then I must land on the Review and Submit page
	And I click on the Submit button 
	And I verify the data on Confirmation page
	 
Examples: 
| Username  | Password | OriginLocationName | OriginAddress1 | OriginCountry | OriginZip | OriginState | OriginCity | OriginContactName | OriginPhoneNo  | DestinationLocationName | DestinationAddress1 | DestinationCountry | DestinationZip | DestinationState | DestinationCity | DestinationContactName | DestinationPhoneNo | SelectItem | Pieces | Weight | Lenght | Width | Height | Description | SelectItem1 | Pieces1 | Weight1 | Lenght1 | Width1 | Height1 | Description1 | RefType | RefNumber | CustType | ServicesType | ShipmentValue | DefaultSpecialInstruction |
| | | Test               | Addr1          | United States | 33126     | FL          | Miami      | TestCont          | (454) 654-6547 | Houston                 | detskk              | United States      | 85282          | AZ               | Tempe           | Tony                   | (454) 654-6548     | Test Item  | 2      | 20     | 4      | 5     | 6      | Item1       | Test Item   | 3       | 21      | 1       | 2      | 3       | Item2        | ACCOUNT |92789742 | Shipper  | Liftgate Pick-Up | 25908         | Testing DF rate request   |
