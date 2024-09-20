@Sprint70 @30615 @Ignore
Feature: ShipmentList_EstMarginChange
	

@GUI
Scenario Outline: Verify Shipment EstMargin as N/A when corresponding Est Revenue is $0.00 or N/A
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	Then EstMargin should be read as N/A for the Est Revenue is zero or N/A
	#Then I should get results from API<stationData>,<Standard_report>,<CustomerName>

	Examples: 
	| Scenario | Username   | Password |
	| s1       | stationown | Te$t1234 |

#| Scenario | Username   | Password | stationData | Standard_report        | CustomerName |
#| s1       | stationown | Te$t1234 | ZZZ,ZZX     | CRM-ShpPrev30DaysAgent | Admin        |