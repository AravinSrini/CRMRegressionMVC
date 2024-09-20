@Sprint85 @48353

Feature: 48353-Customer Invoice - List View With Multiple DAGRT

@Ignore	
Scenario: 48353-Verify the filtering and grid display for station users when invoice DAGRT # matches any DAGRT # within the Station DAGDRT list for Open Invoices
Given I am a sales management, operations, or station owner user with access to Customer Invoice
And I'm assigned to a station with multiple DAGRT numbers
When I arrive on the Customer Invoice page
Then the grid will display Open invoices where the invoice DAGRT # matches any DAGRT # within the station DAGRT list

@Ignore
Scenario: 48353-Verify the filtering and grid display for station users when invoice DAGRT # matches any DAGRT # within the Station DAGDRT list for Closed Invoices
Given I am a sales management, operations, or station owner user with access to Customer Invoice
And I'm assigned to a station with multiple DAGRT numbers
When I arrive on the Customer Invoice page
Then the grid will display Closed invoices where the invoice DAGRT # matches any DAGRT # within the station DAGRT list


Scenario: 48353-Verify the filtering and grid display for Access RRD user when invoice DAGRT # matches any DAGRT # within the Station DAGDRT list for Open Invoices
Given I am an AccessRRD user
And I am on the Customer Invoice page
And I select a station with multiple DAGRT numbers
When I choose 'All Accounts' for the selected station
And I click on the Display Invoices Button
Then the grid will display Open invoices where the invoice DAGRT # matches any DAGRT # within the selected <Stations> DAGRT list.


Scenario: 48353-Verify the filtering and grid display for Access RRD user when invoice DAGRT # matches any DAGRT # within the Station DAGDRT list for Closed Invoices
Given I am an AccessRRD user
And I am on the Customer Invoice page
And I select a station with multiple DAGRT numbers
When I choose 'All Accounts' for the selected station
And I click on the Display Invoices Button
Then the grid will display Closed invoices where the invoice DAGRT # matches any DAGRT # within the selected <Stations> DAGRT list.