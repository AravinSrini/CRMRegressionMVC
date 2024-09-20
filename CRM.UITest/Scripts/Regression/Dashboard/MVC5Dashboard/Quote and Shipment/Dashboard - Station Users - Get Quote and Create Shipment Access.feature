@NinjaSprint35 @108936 @New_Regression
Feature: Dashboard - Station Users - Get Quote and Create Shipment Access

Scenario: 108936 - Verify that all new fields are displayed on the dashboard for Create Shipment or Quote section
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
When I am on the CSR Dashboard page
Then the Create Shipment or Quote section banner will be visible
And the Select an account dropdown will be visible
And the default Select an account option is "Select an account..."
And the Mode dropdown will be visble
And the default Mode will be LTL
And the Shipment button is visible
And the Quote button is visible

Scenario: 108936 - Verify that Create Shipment or Quote section visible above Station Summary for Tableu URL user
Given I am a sales sales management operations or station owner user username-CurrentSprintStationowner password-CurrentSprintStationowner
When I am on the CSR Dashboard page
Then the Create Shipment or Quote section banner will be visible
And the Create Shipment or Quote section banner is above Station Summary section

Scenario: 108936 - Verify only option in Mode dropdown is LTL
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I click the Mode dropdown
Then the only option is LTL

Scenario: 108936 - Verify that customer names and stations are displayed in correct hierarchy format from Select an account dropdown
Given I am a sales sales management operations or station owner user username-NinjaStationOwner password-NinjaStationOwner
When I am on the CSR Dashboard page
And I click the Select an account dropdown
Then the customer names will be listed in hierarchy format
And the stations "ZZZ - Web Services Test,NinjaTestStation,97682 Ninja Test Station without accessorials" will be displayed numerically, then alphabetically

Scenario: 108936 - Verify that stations are not selectable in customer account dropdown
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I click the Select an account dropdown
Then I cannot select a station

Scenario: 108936 - Verify that selected customer name is displayed correctly for primary account
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I choose the customer "108936 Ninja Test Customer"
Then the customer "108936 Ninja Test Customer" will be displayed in the correct format with 0 sub-accounts and station "ZZZ - Web Services Test" and primary account "108936 Ninja Test Customer"

Scenario: 108936 - Verify that selected customer name is displayed correctly for sub account
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I choose the customer "108936 Ninja Sub Test Customer"
Then the customer "108936 Ninja Sub Test Customer" will be displayed in the correct format with 1 sub-accounts and station "ZZZ - Web Services Test" and primary account "108936 Ninja Test Customer"

Scenario: 108936 - Verify that selected customer name is displayed correctly for sub account of a sub account
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I choose the customer "108936 Ninja Sub Sub Test Customer"
Then the customer "108936 Ninja Sub Sub Test Customer" will be displayed in the correct format with 2 sub-accounts and station "ZZZ - Web Services Test" and primary account "108936 Ninja Test Customer"

Scenario: 108936 - Verify that correct hover over message is displayed for Select an account field
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
And I choose the customer "108936 Ninja Test Customer"
When I hover over the customer in the Select an account field
Then the entire station, hierarchies, and customer name "108936 Ninja Test Customer" will be displayed in the hover over message for Select an account field with station "ZZZ - Web Services Test" and primary account "108936 Ninja Test Customer"

Scenario: 108936 - Verify that correct hover over message is displayed for Select an account field for sub of a sub account
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
And I choose the customer "108936 Ninja Sub Sub Test Customer"
When I hover over the customer in the Select an account field
Then the entire station, hierarchies, and customer name "108936 Ninja Sub Sub Test Customer" will be displayed in the hover over message for Select an account field with station "ZZZ - Web Services Test" and primary account "108936 Ninja Test Customer"

Scenario: 108936 - Verify that successfully naviagated to Add Shipment page for customer when Shipment button is clicked
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
And I choose the customer "108936 Ninja Test Customer"
And the selected Mode field is "LTL"
When I click the Shipment button in the Create Shipment or Quote field
Then I will be navigated to the Add Shipment (LTL) page for the customer "108936 Ninja Test Customer"

Scenario: 108936 - Verify that successfully naviagated to Get Quote page for customer when Quote button is clicked
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
And I choose the customer "108936 Ninja Test Customer"
And the selected Mode field is "LTL"
When I click the Quote button in the Create Shipment or Quote field
Then I will be navigated to the Get Quote (LTL) page for the customer "108936 Ninja Test Customer"

Scenario: 108936 - Verify that Select an account field is highlighted when no customer select and Shipment button selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
And I have not selected a customer account
When I click the Shipment button in the Create Shipment or Quote field
Then the Select an account field will be highlighted

Scenario: 108936 - Verify that Select an account field is highlighted when no customer select and Quote button selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
And I have not selected a customer account
When I click the Quote button in the Create Shipment or Quote field
Then the Select an account field will be highlighted

Scenario: 108936 - Verify that Credit Hold indicator appears for Credit Hold customer account
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I search for the customer "108936 Ninja Credit Hold Customer"
Then I will see a "Credit Hold" indicator for the customer

Scenario: 108936 - Verify that Shipment button and quote button are disabled when Credit Hold customer account is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I choose the customer "108936 Ninja Credit Hold Customer"
Then the Shipment button for Create Shipment or Quote field will be inactive
And the Quote button for Create Shipment or Quote field will be inactive

Scenario: 108936 - Verify that Inactive indicator appears for Inactive customer account
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I search for the customer "108936 Ninja Inactive Customer"
Then I will see a "Inactive" indicator for the customer

Scenario: 108936 - Verify that Shipment button and quote button are disabled when Inactive customer account is selected
Given I am a sales sales management operations or station owner user username-CurrentSprintOperations password-CurrentSprintOperations
And I am on the CSR Dashboard page
When I choose the customer "108936 Ninja Inactive Customer"
Then the Shipment button for Create Shipment or Quote field will be inactive
And the Quote button for Create Shipment or Quote field will be inactive