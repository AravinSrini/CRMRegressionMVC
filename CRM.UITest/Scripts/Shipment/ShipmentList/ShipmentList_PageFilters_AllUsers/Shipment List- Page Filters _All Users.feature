@Sprint68 @26798 
Feature: Shipment List- Page Filters _All Users

@GUI
Scenario Outline: Verify default filter options in Shipment List page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page	
	Then I must be able to view Scheduled to Deliver as default filter value with no dates selected -<ScheduledDeliver>,<StartDate>,<EndDate>

Examples: 
| Scenario | Username       | Password | ScheduledDeliver     | StartDate  | EndDate  |
| S1       | zzzext         | Te$t1234 | SCHEDULED TO DELIVER | START DATE | END DATE |
| S2       | SInq           | Te$t1234 | SCHEDULED TO DELIVER | START DATE | END DATE |
| S3       | crmOperation   | Te$t1234 | SCHEDULED TO DELIVER | START DATE | END DATE |
| S4       | saleTest       | Te$t1234 | SCHEDULED TO DELIVER | START DATE | END DATE |
| S5       | stationowner   | Te$t1234 | SCHEDULED TO DELIVER | START DATE | END DATE |
| S6       | crmsalesusr    | Te$t1234 | SCHEDULED TO DELIVER | START DATE | END DATE |
| S7       | Entyrnorates   | Te$t1234 | SCHEDULED TO DELIVER | START DATE | END DATE |
| S8       | Inquirynorates | Te$t1234 | SCHEDULED TO DELIVER | START DATE | END DATE |


@Functional
Scenario Outline: Verify the functionality of Filter options in the shipment List page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to change default scheduled to deliver option to scheduled to pickup or viceversa
	

Examples: 
| Scenario | Username       | Password | 
| S1       | zzzext         | Te$t1234 |
| S2       | SInq           | Te$t1234 |
| S3       | crmOperation   | Te$t1234 |
| S4       | saleTest       | Te$t1234 |
| S5       | stationowner   | Te$t1234 |
| S6       | crmsalesusr    | Te$t1234 |
| S7       | Entyrnorates   | Te$t1234 |
| S8       | Inquirynorates | Te$t1234 |

@GUI @Functional
Scenario Outline: Verify the existence and functionality of Remove button in Shipment List page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	And I have option to filter with date range '<Pickup>'
	#And I modify default page filters - <StartDate>,<EndDate>
	Then I must be able to view Remove button
	And When I click remove button, the grid and the filter options should set back to default

Examples: 
| Username | Password | Pickup               | 
| zzzext   | Te$t1234 | SCHEDULED TO DELIVER | 


@Functional
Scenario Outline: Verify the Filtering of the Shipments for the ScheduledToPickup filter in the shipment List page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	#And I have option to filter with date range '<Pickup>'
	Then all the shipments for the ScheduledToPickup option '<ScheduledToPickup>' should be filtered based on the date range
	
Examples: 
| Scenario | Username | Password | ScheduledToPickup    |
| S1       | zzzext   | Te$t1234 | SCHEDULED TO DELIVER |



@Functional
Scenario Outline: Verify the Filtering of the Shipments for the ScheduledToDelivery filter in the shipment List page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	#And I have option to filter with date range '<Pickup>'
	Then all the shipments for the ScheduledToDelivery selected option '<ScheduledToDelivery>' should be filtered based on the date range
	
Examples: 
| Scenario | Username | Password | ScheduledToDelivery    |
| S1       | zzzext   | Te$t1234 | SCHEDULED TO DELIVER |


	
