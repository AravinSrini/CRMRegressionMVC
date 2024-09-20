@35619 @Sprint74
Feature: ShipmentList_PageDisplayfeature


	Scenario Outline: PageDisplay1->Verify the grid is empty and displayed with the message for shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then the grid should be empty and displayed with the <messageDisplay> for shipment display
	Examples: 
| Scenario | Username | Password | messageDisplay |
| s1       |crmOperation@user.com| Te$t1234 | Please select a Station or Customer to view Shipments |
| s2       |SalesManager@stage.com| Te$t1234 | Please select a Station or Customer to view Shipments |
| s3       |stationown@stage.com| Te$t1234 | Please select a Station or Customer to view Shipments |



Scenario Outline: PageDisplay2->Verify the customer drop down will be set to Select option by default
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I should be able to See the customer drop down is set to new option Select<SelectOption> 

	Examples: 
| Scenario | Username				| Password | SelectOption |
| s1       |stationown@stage.com | Te$t1234 | Select |
| s2       |SalesManager@stage.comm| Te$t1234 | Select |
| s3       |crmOperation@user.com | Te$t1234 | Select |


Scenario Outline: PageDisplay3->Verify the customer drop down should have no All option in the drop down list
 Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
    And I click on customer drop down in shipment list page
	Then the customer drop down should not have All Customer option 

	Examples: 
| Scenario | Username | Password |
| s1       | stationown@stage.com | Te$t1234 |
| s2       | SalesManager@stage.com | Te$t1234 |
| s3       | crmOperation@user.com | Te$t1234 |


Scenario Outline:PageDisplay4->Verify the Add Shipment button is hidden in the Shipment list page
   Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	And I select the option Select from the customer drop down
   Then the Add Shipment button should be hidden<AddShipment>

   Examples: 
| Scenario | Username | Password | AddShipment |
| s1       |stationown@stage.com | Te$t1234 | Add Shipment |
| s2       |SalesManager@stage.com| Te$t1234 | Add Shipment |
| s3       |crmOperation@user.com| Te$t1234 | Add Shipment |

Scenario Outline:PageDisplay5 ->Verify the message All shipments for the past 30 days are shown -is not displayed for Select Customer dropdown
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	And I select the option Select from the customer drop down
	Then I should not see the message <shipmentMessage> beside the customer drop down

	Examples: 
| Scenario | Username | Password | shipmentMessage |
| s1       |stationown@stage.com | Te$t1234 | All shipments for the past 30 days are shown. |
| s2       |SalesManager@stage.com| Te$t1234 | All shipments for the past 30 days are shown. |
| s3       |crmOperation@user.com| Te$t1234 | All shipments for the past 30 days are shown. |


