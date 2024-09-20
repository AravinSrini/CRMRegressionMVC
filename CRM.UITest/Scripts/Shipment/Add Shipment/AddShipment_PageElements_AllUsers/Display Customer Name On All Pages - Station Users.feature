@Sprint21_Ninja @44621
Feature: Display Customer Name On All Pages - Station Users - Shipment

@functional @Acceptance @GUI
Scenario: 44621_Verify display of expected default selection in the customer list dropdown of Shipment list page
	Given I am a sales, sales management, operations, or station owner user
	When I arrive on the Shipment List page
	Then The default selection in the customer list should be "Select an account to display..."
	And I should no longer have "Select..." as an option from the customer drop down list

@functional @Acceptance @GUI
Scenario: 44621_Verify Station - Primary Account - Customer Name displayed on Add Shipment page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And I have selected a customer from my customer list
	And I clicked on the Add Shipment button
	And I clicked on the LTL tile on the Add Shipment page
	When I am on the Add Shipment (LTL) page
	Then I will see the Station - Primary Account - Customer Name displayed on the page
	And The Station-Primary Account-Customer Name is not editable.

@functional @Acceptance @GUI
Scenario: 44621_Verify Station - Primary Account - Customer Name displayed on Shipment Result page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And I am creating a LTL shipment 
	And I clicked on the "View Rates" button on the Add Shipment (LTL) page
	When I am on the Shipment Results (LTL) page
	Then I will see the Station - Primary Account - Customer Name getting displayed on page
	And The Station-Primary Account-Customer Name is not editable

@functional @Acceptance @GUI
Scenario Outline: 44621_Verify Station - Primary Account - Customer Name displayed on Shipment Review And Submit page
	Given I am a sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	And I am creating a LTL shipment 
	And I clicked on either on Create Shipment or Create Insured Shipment buttons on the Shipment Results (LTL) page <ShipmentType>
	When I am on the Review and Submit (LTL) page
	Then I will see the Station - Primary Account - Customer Name getting displayed on page
	And The Station-Primary Account-Customer Name is not editable

Examples: 
| ShipmentType          |
| CreateShipment        |
| CreateInsuredShipment |

@functional @Acceptance @GUI
Scenario: 44621_Verify Station - Primary Account - Customer Name displayed on Shipment Confirmation page
	Given that I am a sales, sales management, operations, or station owner user,
	And I am on the Shipment List page
	And I am creating a LTL shipment  
	And I clicked on the "Submit Shipment" button on the Review and Submit page
	When I am on the Shipment Confirmation (LTL) page
	Then I will see the Station - Primary Account - Customer Name getting displayed on page
	And The Station-Primary Account-Customer Name is not editable


@functional @Acceptance @GUI
Scenario: 44621_Verify Station - Primary Account - Customer Name of the saved quote displayed on the page
Given that I am a sales, sales management, operations, or station owner user,
And I am expanded non expired Quote with Notification accessorial
And I clicked on the Create Shipment Page
When I arrive on the Add Shipment (LTL) page
Then I will see the Station - Primary Account - Customer Name displayed on the page
And The Station-Primary Account-Customer Name is not editable.

@functional @Acceptance @GUI
Scenario: 44621_Verify Station - Primary Account - Customer Name of the rate shop displayed on the page
	Given that I am a sales, sales management, operations, or station owner user,
	And I am on the Quote Results (LTL) page
	And I clicked on either Create Shipment or Create Insured Shipment buttons for any displayed carrier
	When I arrive on the Add Shipment (LTL) page,
	Then I will see the Station - Primary Account - Customer Name displayed on the page
	And The Station-Primary Account-Customer Name is not editable.

