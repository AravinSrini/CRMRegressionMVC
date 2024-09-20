@Sprint74 @35283
Feature: ShipmentList_EditOption_LTL
	
@GUI
Scenario Outline: Verify the Presence of Edit Option for the Shipments
Given I am a DLS user and login into application with valid <Username> and <Password>
When I am navigated to the Shipment List page<UserType>,<CustomerName>
Then I will see Edit button for the Shipment Pending,PrePlan,Rated,UnScheduled,TenderRejected,Scheduled Status

Examples: 
| Scenario | Username               | Password | UserType | CustomerName           |
| s1       | crmoperation		    | Te$t1234 | Internal | ZZZ - GS Customer Test |