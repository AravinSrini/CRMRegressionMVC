@NinjaSprint35 @109018 @New_Regression
Feature: Dashboard - Station Users - Filtered Customer Functionality

Scenario: 109018 - Verify when I select a customer on the dashboard and navigate to the shipment list page the customer is selected and their shipments are displayed
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the Dashboard page
And I selected the customer "108936 Ninja Test Customer" from the account drop down in the Create Shipment or Quote section
When I navigate to the Shipment List page
Then the customer "108936 Ninja Test Customer" will be selected on the shipment list page
And the shipment list will display any shipments associated to the customer for the previous 30 days "108936 Ninja Test Customer"

Scenario: 109018 - Verify when I select a customer on the dashboard and navigate to the quote list page the customer is selected and their quotes are displayed
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the Dashboard page
And I selected the customer "108936 Ninja Test Customer" from the account drop down in the Create Shipment or Quote section
When I navigate to the Quote List page
Then the customer "108936 Ninja Test Customer" will be selected on the quote list page
And the quote list will display any quotes associated to the customer for the previous 30 days "108936 Ninja Test Customer"

Scenario: 109018 - Verify when I select a customer on the shipment list page and navigate to the dashboard the customer is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Shipment List page
And I select the customer "108936 Ninja Test Customer" from the shipment list account drop down
When I navigate to the Dashboard page
Then The customer "108936 Ninja Test Customer" will be selected on the dashboard

Scenario: 109018 - Verify when I select a customer on the quote list page and navigate to the dashboard the customer is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Quote List page
And I select the customer "108936 Ninja Test Customer" from the quote list account drop down
When I navigate to the Dashboard page
Then The customer "108936 Ninja Test Customer" will be selected on the dashboard

Scenario: 109018 - Verify when I select a station on the shipment list page and navigate to the dashboard the default text is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Shipment List page
And I select the station "87-Fargo ND" from the shipment list account drop down
When I navigate to the Dashboard page
Then "Select an account..." will be selected on the dashboard

Scenario: 109018 - Verify when I select a station on the quote list page and navigate to the dashboard the default text is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Quote List page
And I select the station "87-Fargo ND" from the quote list account drop down
When I navigate to the Dashboard page
Then "Select an account..." will be selected on the dashboard

Scenario: 109018 - Verify when I select a customer on the dashboard and navigate to the user management page then navigate back to the dashboard the customer is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the Dashboard page
And I select the customer "108936 Ninja Test Customer" from the dashboard account drop down
And I navigate to the tracking page
When I navigate to the Dashboard page
Then The customer "108936 Ninja Test Customer" will be selected on the dashboard

Scenario: 109018 - Verify when I select a customer on the shipment list page and navigate to the quote list the customer is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Shipment List page
And I select the customer "108936 Ninja Test Customer" from the shipment list account drop down
When I navigate to the Quote List page
Then the customer "108936 Ninja Test Customer" will be selected on the quote list page 
And the quote list will display any quotes associated to the customer for the previous 30 days "108936 Ninja Test Customer"

Scenario: 109018 - Verify when I select a customer on the quote list page and navigate to the shipment list the customer is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Quote List page
And I select the customer "108936 Ninja Test Customer" from the quote list account drop down
When I navigate to the Shipment List page
Then the customer "108936 Ninja Test Customer" will be selected on the shipment list page
And the shipment list will display any shipments associated to the customer for the previous 30 days "108936 Ninja Test Customer"

Scenario: 109018 - Verify when I select a station on the quote list page and navigate to the dashboard then to the shipment list page the customer is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Quote List page
And I select the station "87-Fargo ND" from the quote list account drop down
When I navigate to the Dashboard page
And I navigate to the Shipment List page
Then the customer "87-Fargo ND" will be selected on the shipment list page
And the shipment list will display any shipments associated to the customer for the previous 30 days "87-Fargo ND"

Scenario: 109018 - Verify when I select a station on the shipment list page and navigate to the dashboard then to the quote list the customer is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Shipment List page
And I select the station "87-Fargo ND" from the shipment list account drop down
When I navigate to the Quote List page
Then the customer "87-Fargo ND" will be selected on the quote list page 
And the quote list will display any quotes associated to the customer for the previous 30 days "87-Fargo ND"

Scenario: 109018 - Verify when I select a customer on quote list page and navigate to the dashboard then I am successfully navigated to Get Quote screen
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Quote List page
And I select the customer "108936 Ninja Test Customer" from the quote list account drop down
When I navigate to the Dashboard page
And I click the Quote button in the Create Shipment or Quote field
Then I will be navigated to the Get Quote (LTL) page for the customer "108936 Ninja Test Customer"

Scenario: 109018 - Verify when I select a customer on shipment list page and navigate to the dashboard then I am successfully navigated to Add Shipment screen
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Shipment List page
And I select the customer "108936 Ninja Test Customer" from the shipment list account drop down
When I navigate to the Dashboard page
And I click the Shipment button in the Create Shipment or Quote field
Then I will be navigated to the Add Shipment (LTL) page for the customer "108936 Ninja Test Customer"

Scenario: 109018 - Verify when I select a customer on quote list page and navigate to the dashboard then the correct hover message will appear for the customer
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Quote List page
And I select the customer "108936 Ninja Test Customer" from the quote list account drop down
When I navigate to the Dashboard page
And I hover over the customer in the Select an account field
Then the entire station, hierarchies, and customer name "108936 Ninja Test Customer" will be displayed in the hover over message for Select an account field with station "ZZZ - Web Services Test" and primary account "108936 Ninja Test Customer"

Scenario: 109018 - Verify when I select a customer on shipment list page and navigate to the dashboard then the correct hover message will appear for the customer
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I navigate to the Shipment List page
And I select the customer "108936 Ninja Test Customer" from the shipment list account drop down
When I navigate to the Dashboard page
And I hover over the customer in the Select an account field
Then the entire station, hierarchies, and customer name "108936 Ninja Test Customer" will be displayed in the hover over message for Select an account field with station "ZZZ - Web Services Test" and primary account "108936 Ninja Test Customer"