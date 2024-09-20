@ShipmentList_GridSearch_StationUsers @Sprint68 @26793
Feature: ShipmentList_GridSearch_StationUsers


@GUI @Acceptance
Scenario Outline: Verify search shipment field dropdown options for Station users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the drop down arrow of the search field in the Shipment List page
	Then I must see the expected drop down values for station Users


Examples: 
| Scenario | Username     | Password |
#| S1       | crmOperation | Te$t1234 |
#| S2       | saleTest     | Te$t1234 |
| S3       | stationowner | Te$t1234 | 
#| S4       | crmsalesusr  | Te$t1234 |


@GUI @Acceptance
Scenario Outline: Verify multiple selection search shipment and Highlight functionality in the dropdown options for Station users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the drop down arrow of the search field in the Shipment List page
	And I Click on the Clear All button
	And I select the multiple fields as Staion Name, Customer Name, PickUp Date from the drop down
	Then I must be able to search the shipment by entering the Staion Name values in the search field and it should be highlighted in the grid- '<StationName>'
	And I must be able to search the shipment by entering the Customer Name values in the search field and it should be highlighted in the grid- '<CustomerName>'
	And I must be able to search the shipment by entering the PickUp Date values in the search field and it should be highlighted in the grid- '<PickUpDate>'

Examples: 
| Scenario | Username     | Password | StationName | CustomerName | PickUpDate |
| S1       | crmOperation | Te$t1234 |ZZZ - Web Services Test| ZZZ - GS Customer Test| 09/29/2017 |
#| S2       | saleTest     | Te$t1234 |             |              |            |
#| S3       | stationowner | Te$t1234 |             |              |            |
#| S4       | crmsalesusr  | Te$t1234 |             |              |            |

@Functional
Scenario Outline: Verify the Clear buttton functionality in the search Shipment field dropdown 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the drop down arrow of the search field in the Shipment List page
	And I Click on the Clear All button
	Then All the options from the search drop down should be cleared

Examples: 
| Scenario | Username     | Password |
#| S1       | crmOperation | Te$t1234 |
| S2       | saleTest     | Te$t1234 |
#| S3       | stationowner | Te$t1234 | 
#| S4       | crmsalesusr  | Te$t1234 |

@GUI
Scenario Outline:  Verify the note section text inside Search Dropdown section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the drop down arrow of the search field in the Shipment List page
	Then I must be able to view note text within Search dropdown

Examples: 
| Scenario | Username     | Password |
#| S1       | crmOperation | Te$t1234 |
#| S2       | saleTest     | Te$t1234 |
#| S3       | stationowner | Te$t1234 | 
| S4       | crmsalesusr  | Te$t1234 |



