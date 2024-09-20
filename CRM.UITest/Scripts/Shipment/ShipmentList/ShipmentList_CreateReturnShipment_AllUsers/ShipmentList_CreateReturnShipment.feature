@ShipmentList_CreateReturnShipment @Sprint68 @28054 
Feature: ShipmentList_CreateReturnShipment

@GUI @Functional 
Scenario Outline: Verify the Create Return Shipment pop is displayed when I click the create shipment button for the Station users, ShipEntry and ShipInquiry Users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on the return shipment icon <UserType>
	Then Pop up asking for the Confirmation to create return shipment is displayed with <CreateReturnShipmentTitle> header 
	And I must see the confirmation text <ConfirmationText> in the pop up
	And I must see the Yes and No buttons in the Pop up
	
Examples: 
	| Scenario | Username     | Password | CreateReturnShipmentTitle | ConfirmationText                            | UserType        |
	| S1       | zzzext       | Te$t1234 | Create Return Shipment    | Would you like to create a return shipment? | ShipEntry       |
	| S2       | SInq         | Te$t1234 | Create Return Shipment    | Would you like to create a return shipment? | ShipInquiry     |
	| S3       | crmOperation | Te$t1234 | Create Return Shipment    | Would you like to create a return shipment? | Operation       |
	| S4       | saleTest     | Te$t1234 | Create Return Shipment    | Would you like to create a return shipment? | SalesManagement |
	| S5       | stationowner | Te$t1234 | Create Return Shipment    | Would you like to create a return shipment? | StationOwner    |
	| S6       | crmsalesusr  | Te$t1234 | Create Return Shipment    | Would you like to create a return shipment? | Sales           |

@Functional
Scenario Outline: Verify the page navigation when I click on the No button in create shipment popup or the Station users, ShipEntry and ShipInquiry Users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on the return shipment icon <UserType>
	And I click on the No button in Create Return Shipment pop up
	Then Create Return Shipment Pop Up should be closed and user should be returned back to the Shipment list page
Examples: 
	| Scenario | Username     | Password | UserType        |
	| S1       | zzzext       | Te$t1234 | ShipEntry       |
	| S2       | SInq         | Te$t1234 | ShipInquiry     |
	| S3       | crmOperation | Te$t1234 | Operation       |
	| S4       | saleTest     | Te$t1234 | SalesManagement |
	| S5       | stationowner | Te$t1234 | StationOwner    |
	| S6       | crmsalesusr  | Te$t1234 | Sales           |

@Functional
Scenario Outline: Verify the page navigation when I click on the Yes button in create shipment popup for the ShipEntry and ShipInquiry Users which does not have claim
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on the return shipment icon <UserType>
    And I click on the Yes button in Create Return Shipment pop up
	Then I must be on the Shipment List Locations and Dates page

Examples: 
	| Scenario | Username     | Password | UserType        |
	| S1       | shp.entry    | Te$t1234 | ShipEntry       |





