@Sprint81
Feature: Shipment List - Station Users - Filtered Customer Functionality
	
@GUI
Scenario: 32155 - Verify the existence of expected text displayed beneath the customer list 
	Given I am a  sales, sales management, operations, or station owner user
	And I am on the Shipment List page
	When I select a Customer from the dropdown of Shipment list page
	Then A text should be displayed beneath the customer list stating - All shipments for the past 30 days are shown.

@GUI
Scenario: 32155 - Verify the default selection of Customer list dropdown and the display of Verbiage
	Given I am a  sales, sales management, operations, or station owner user
	When I am on the Shipment List page
	Then The customer list should be selected with select option
    And I should not be able to see a verbiage stating - All shipments for the past 30 days are shown.

@Functional
Scenario: 32155 - Verify shipment list page when user navigates away and returns back by selecting a Customer
	Given I am a  sales, sales management, operations, or station owner user
	And I have navigated away from the Shipment list page by selecting a Customer
	When I return to the Shipment List page
	Then The customer previously filtered should get pre-selected
	And The shipment list should display any shipments associated to the customer for the previous 30 days 
	And I should have an option to select another customer, station.
	
@Functional
Scenario: 32155 - Verify Quote list page when user navigates from Shipment list page to Quote list by selecting a Customer
	Given I am a  sales, sales management, operations, or station owner user
	And I have navigated away from the Shipment list page by selecting a Customer
	When I arrive on the Quote List page
	Then The customer selected on the Shipment List page should get pre-selected 
	And The quote list should display any quotes associated to the customer for the previous 30 days 
	And I should have an option to select another customer, station from Quote list page

@Functional
Scenario: 32155 - Verify shipment list page when user navigates away and returns back by selecting a Station
	Given I am a  sales, sales management, operations, or station owner user
	And I have navigated away from the Shipment list page by selecting a Station
	When I return to the Shipment List page
	Then The station previously filtered should get pre-selected
	And The shipment list should display any shipments associated to the station for the previous 30 days 
	And I should have an option to select another customer, station.

@Functional	
Scenario: 32155 - Verify Quote list page when user navigates from Shipment list page to Quote list by selecting a Station
	Given I am a  sales, sales management, operations, or station owner user
	And I have navigated away from the Shipment list page by selecting a Station
	When I arrive on the Quote List page
	Then The station selected on the Shipment List page should get pre-selected 
	And The quote list should display any quotes associated to the station for the previous 30 days 
	And I should have an option to select another customer, station from Quote list page



