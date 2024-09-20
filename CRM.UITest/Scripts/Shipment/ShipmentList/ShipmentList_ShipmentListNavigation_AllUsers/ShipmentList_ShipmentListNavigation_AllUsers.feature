@28364 @Sprint68
Feature: ShipmentList_ShipmentListNavigation_AllUsers
	
@GUI @Functional
Scenario Outline: Verify the Shipment List navigation functionality for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I am navigated to the dashboard page <DashboardTitle> 
Then I should be displayed with Shipments Icon in leftwizard
And I click on the Shipment icon
And I should be navigated to Shipment List page

Examples: 
| Scenario | Username     | Password | DashboardTitle |
| S1       | crmOperation | Te$t1234 | Dashboard      |
| S2       | saleTest     | Te$t1234 | Dashboard      |
| S3       | stationowner | Te$t1234 | Dashboard      |
| S4       | crmsalesusr  | Te$t1234 | Dashboard      |

@GUI @Functional
Scenario Outline: Verify the Shipment List navigation functionality for all external users with claim
Given I am a DLS user and login into application with valid <Username> and <Password>
When I am navigated to the dashboard page <DashboardTitle> 
Then I should be displayed with Shipments Icon in leftwizard
And I click on the Shipment icon for external users
And I will be navigated to new shipment list screen

Examples: 
| Scenario | Username       | Password | DashboardTitle |
| S1       | shpentry       | Te$t1234 | Dashboard      |
| s2       | ShpInquiry     | Te$t1234 | Dashboard      |
| s3       | Entyrnorates   | Te$t1234 | Dashboard      |
| s4       | Inquirynorates | Te$t1234 | Dashboard      |

@GUI @Functional
Scenario Outline: Verify the Shipment List navigation functionality for all external users without claim
Given I am a DLS user and login into application with valid <Username> and <Password>
When I am navigated to the dashboard page <DashboardTitle> 
Then I should be displayed with Shipments Icon in leftwizard
And I click on the Shipment icon for external users
And I will be navigated to legacy shipment list screen

Examples: 
| Scenario | Username             | Password | DashboardTitle |
| s1       | shipment.entryuser   | Te$t1234 | Dashboard      |
| s2       | shipment.inquiryuser | Te$t1234 | Dashboard      |
| s3       | shipment.entryNouser | Te$t1234 | Dashboard      |
| s4       | shipment.inqNouser   | Te$t1234 | Dashboard      |



