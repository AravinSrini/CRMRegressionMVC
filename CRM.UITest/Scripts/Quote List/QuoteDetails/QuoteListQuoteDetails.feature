@QuoteList_QuoteDetailsPage @26238 @Sprint67 
Feature: QuoteListQuoteDetails	

@GUI
Scenario Outline: Verify the quote details section and fields for Station Users , ShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 
	And I click on the Quote Icon
	#And I filter the LTL services <Service> for New quotes
	And I expand the quote details of any quote in the Quoted status <UserType>
	Then I must be able to see the Submitted By Field <SubmittedBy>
	And I must be able to see the orgin <OriginLOcationSection> with <AddressZip> label
	And I must be able to see the destination  <DestinationSection> with <AddressZip> label
	And I must be able to see the Dates <DatesSection> with <PickupDate> and <DropOffDate> label
	And I must be able to see the <FreightInformation> with <Quantity>, <Package>, <Weight>, <ItemDescription>, <Classification>, <NMFC>, <HazardousMaterials> label
	And I can see AdditionalSevicesAccessorials  '<AdditionalServicesandAccessorials>'

Examples: 
| Scenario | Username     | Password | DashboardTitle | UserType  | SubmittedBy    | OriginLOcationSection | AddressZip         | DestinationSection   | DatesSection | PickupDate  | DropOffDate  | FreightInformation                   | Quantity | Package | Weight | ItemDescription  | Classification | NMFC | HazardousMaterials  | AdditionalServicesandAccessorials    |
| s1       | zzzext       | Te$t1234 | Dashboard      | ShipEntry | Submitted By : | ORIGIN LOCATION       | Address and/or Zip | DESTINATION LOCATION | DATES        | Pickup Date | Dropoff Date | FREIGHT INFORMATION (EQUIPMENT TYPE: | Quantity | Package | Weight | Item Description | Classification | NMFC | Hazardous Materials | ADDITIONAL SERVICES AND ACCESSORIALS |
#| s2       | crmOperation | Te$t1234 | Dashboard      | Operation | Submitted By : | ORIGIN LOCATION       | Address and/or Zip | DESTINATION LOCATION | DATES        | Pickup Date | Dropoff Date | FREIGHT INFORMATION (EQUIPMENT TYPE: | Quantity | Package | Weight | Item Description | Classification | NMFC | Hazardous Materials | ADDITIONAL SERVICES AND ACCESSORIALS |


@GUI @Functional
Scenario Outline: Verify the quote details of the Quoted status for the  Station Users, ShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 	
	And I click on the Quote Icon
	And I filter the LTL services <Service> for New quotes
	And I expand the quote details of any quote in the Quoted status <UserType>
	Then previously saved data should be displayed and match with the corresponding fields <Username> 

Examples: 
| Scenario | Username     | Password | DashboardTitle | Service | UserType  |
| S1       | zzzext       | Te$t1234 | Dashboard      | LTL     | ShipEntry |
#| S2       | crmOperation | Te$t1234 | Dashboard      | LTL     | Operation |

@GUI @Functional
Scenario Outline: Verify the quote details of the Expired status for the  Station Users, ShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 	
	And I click on the Quote Icon
	And I filter the LTL services <Service> for Expired quotes
	And I expand the quote details of any quote in the Expired status <UserType>
	Then previously saved data should be displayed and match with the corresponding fields <Username> 

Examples: 
| Scenario | Username     | Password | DashboardTitle | Service | UserType  |
| S1       | zzzext       | Te$t1234 | Dashboard      | LTL     | ShipEntry |
#| S2       | crmOperation | Te$t1234 | Dashboard      | LTL     | Operation |



@GUI 
Scenario Outline: Verify the Print and Create Shipment button is displayed in quote details section of the Quoted status for the ShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle> 	
	And I click on the Quote Icon	
	And I filter the LTL services <Service> for New quotes
	And I expand the quote details of any quote in the Quoted status <UserType>
	Then User should be able to see the Print and <CreateShipment> button

Examples: 
| Scenario | Username              | Password | DashboardTitle | Service | UserType  |
| S1       | zzzext@user.com       | Te$t1234 | Dashboard      | LTL     | ShipEntry |




@GUI 
Scenario Outline: Verify the Print and Re-quote button is displayed in quote details section of the Expired status for the Station, ShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am navigated to the dashboard page <DashboardTitle>	
	And I click on the Quote Icon	
	And I filter the LTL services <Service>	for Expired status
	And I expand the quote details of any quote in the Expired status <UserType>
	Then User must be able to see the Print and <Requote> button

Examples: 
| Scenario | Username              | Password | DashboardTitle | Service | UserType  |
| S1       | zzzext@user.com       | Te$t1234 | Dashboard      | LTL     | ShipEntry |
#| S2       | crmOperation@user.com | Te$t1234 | Dashboard      | LTL     | Operation |
