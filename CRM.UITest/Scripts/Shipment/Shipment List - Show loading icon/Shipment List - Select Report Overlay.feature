@NinjaSprint35 @111077
Feature: Shipment List - Select Report Overlay

@111077CustomReport
Scenario Outline: 111077 - Verify page is responsive and loading overlay visible on grid when custom report is selected
Given I am a sales sales management operations or station owner user <Username> <Password>
And I navigate to the Shipment List page
When I click the report "Ninja Test Report"
Then the report dropdown will not be visible
And the loading overlay will be visible on the grid
Examples:
| Username                           | Password                           |
| username-CurrentsprintOperations   | password-CurrentsprintOperations   |
| username-CurrentSprintSales        | password-CurrentSprintSales        |
| username-CurrentSprintSalesmanager | password-CurrentSprintSalesmanager |
| username-CurrentSprintStationowner | password-CurrentSprintStationowner |
| username-CurrentSprintshpentry     | password-CurrentSprintshpentry     |
| username-CurrentSprintInquiry      | password-CurrentSprintInquiry      |

Scenario Outline: 111077 - Verify page is responsive and loading overlay visible on grid when standard report is selected
Given I am a sales sales management operations or station owner user <Username> <Password>
And I navigate to the Shipment List page
When I click the report "Shipments from Previous Month"
Then the report dropdown will not be visible
And the loading overlay will be visible on the grid
Examples:
| Username                           | Password                           |
| username-CurrentsprintOperations   | password-CurrentsprintOperations   |
| username-CurrentSprintSales        | password-CurrentSprintSales        |
| username-CurrentSprintSalesmanager | password-CurrentSprintSalesmanager |
| username-CurrentSprintStationowner | password-CurrentSprintStationowner |
| username-CurrentSprintshpentry     | password-CurrentSprintshpentry     |
| username-CurrentSprintInquiry      | password-CurrentSprintInquiry      |