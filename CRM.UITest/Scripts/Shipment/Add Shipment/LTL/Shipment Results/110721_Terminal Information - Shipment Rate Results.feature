@Sprint94 @110721
Feature: 110721_Terminal Information - Shipment Rate Results

Scenario: 110721 : Verify the Terminal info link for carriers in Shipment results page_ExternalUser
	Given I am a user who have access to Shipments Module 'username-shipentry' 'password-shipentry'
	And I am on the Add Shipment LTL page for an external user
	And I have entered all required information on Add Shipment LTL page
	And I have clicked on the View Rates button
	When I arrive on Shipment Results LTL page
	Then I will see a link on each carrier rate labeled 'Terminal Info' on the Shipment results screen

Scenario: 110721 : Verify the Terminal info link for carriers in Shipment results page_InternalUser
	Given I am a user who have access to Shipments Module 'username-crmOperation' 'password-crmOperation'
	And I am on the Add Shipment LTL page for an internal user
	And I have entered all required information on Add Shipment LTL page
	And I have clicked on the View Rates button
	When I arrive on Shipment Results LTL page
	Then I will see a link on each carrier rate labeled 'Terminal Info' on the Shipment results screen

Scenario: 110721 : Verify the Terminal info link for carriers in Shipment results page_SaleslUser
	Given I am a user who have access to Shipments Module 'username-SalesBoth' 'password-SalesBoth'
	And I am on the Add Shipment LTL page for an internal user
	And I have entered all required information on Add Shipment LTL page
	And I have clicked on the View Rates button
	When I arrive on Shipment Results LTL page
	Then I will see a link on each carrier rate labeled 'Terminal Info' on the Shipment results screen

Scenario: 110721 : Verify the display of popup modal that displays the terminal information for the selected record_ExternalUser
	Given I am a user who have access to Shipments Module 'username-shipentry' 'password-shipentry'
	And I am on shipment results LTL page for an external user
	When I click on Terminal Info Link for a specific carrier rate on Shipment Results page
	Then A popup modal is launched that displays the terminal information for selected record on Shipment Results page
	And I will See a close button on Terminal information modal

Scenario: 110721 : Verify the display of popup modal that displays the terminal information for the selected record_InternalUser
	Given I am a user who have access to Shipments Module 'username-crmOperation' 'password-crmOperation'
	And I am on shipment results LTL page for an internal user
	When I click on Terminal Info Link for a specific carrier rate on Shipment Results page
	Then A popup modal is launched that displays the terminal information for selected record on Shipment Results page
	And I will See a close button on Terminal information modal

Scenario: 110721 : Verify the display of popup modal that displays the terminal information for the selected record_SalesUser
	Given I am a user who have access to Shipments Module 'username-SalesBoth' 'password-SalesBoth'
	And I am on shipment results LTL page for an internal user
	When I click on Terminal Info Link for a specific carrier rate on Shipment Results page
	Then A popup modal is launched that displays the terminal information for selected record on Shipment Results page
	And I will See a close button on Terminal information modal

Scenario: 110721 : Verify the functionality of close button on Terminal Inoformation modal_ExternalUser
	Given I am a user who have access to Shipments Module 'username-shipentry' 'password-shipentry'
	And I am on shipment results LTL page for an external user
	And I clicked on Terminal Info Link for a specific carrier rate on Shipment Results page
	And I am on Terminal Information modal
	When I click on Close button from the Terminal Information modal
	Then The Terminal Information modal will close

Scenario: 110721 : Verify the functionality of close button on Terminal Inoformation modal_InternalUser
	Given I am a user who have access to Shipments Module 'username-crmOperation' 'password-crmOperation'
	And I am on shipment results LTL page for an internal user
	And I clicked on Terminal Info Link for a specific carrier rate on Shipment Results page
	And I am on Terminal Information modal
	When I click on Close button from the Terminal Information modal
	Then The Terminal Information modal will close

Scenario: 110721 : Verify the functionality of close button on Terminal Inoformation modal_SalesUser
	Given I am a user who have access to Shipments Module 'username-SalesBoth' 'password-SalesBoth'
	And I am on shipment results LTL page for an internal user
	And I clicked on Terminal Info Link for a specific carrier rate on Shipment Results page
	And I am on Terminal Information modal
	When I click on Close button from the Terminal Information modal
	Then The Terminal Information modal will close