@ShipmentList_GridSearch @Sprint68 @26792 
Feature: ShipmentList_GridSearch
	

@GUI @Acceptance
Scenario Outline: Verify search shipment field dropdown options for Customer users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the drop down arrow of the search field in the Shipment List page
	Then I must see the expected drop down values


Examples: 
| Scenario | Username   | Password |
| S1       | zzzext     | Te$t1234 |
#| S2       | ShpInquiry | Te$t1234 |


@GUI @Acceptance
Scenario Outline: Verify multiple selection search shipment and Highlight functionality in the dropdown options for Customer users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the drop down arrow of the search field in the Shipment List page
	And I Click on the Clear All button
	And I select the multiple fields as Reference number, Service, Status from the drop down
	Then I must be able to search the shipment by entering the Reference number values in the search field and it should be highlighted in the grid- '<ReferenceNumber>'
	And I must be able to search the shipment by entering the Service values in the search field and it should be highlighted in the grid- '<Service>'
	And I must be able to search the shipment by entering the Status values in the search field and it should be highlighted in the grid- '<Status>'

Examples: 
| Scenario | Username | Password | ReferenceNumber | Service | Status    |
| S1       | zzzext   | Te$t1234 | ZZX00206520     | LTL     | Scheduled |
#| S2       | SInq     | Te$t1234 | 1247611         | LTL     | Web       |


@Functional
Scenario Outline: Verify the Clear buttton functionality in the search Shipment field dropdown 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the drop down arrow of the search field in the Shipment List page
	And I Click on the Clear All button
	Then All the options from the search drop down should be cleared

Examples: 
| Scenario | Username   | Password |
| S1       | zzzext     | Te$t1234 |
#| S2       | SInq      | Te$t1234 |

@GUI
Scenario Outline:  Verify the note section text inside Search Dropdown section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the drop down arrow of the search field in the Shipment List page
	Then I must be able to view note text within Search dropdown

Examples: 
| Scenario | Username   | Password |
| S1       | zzzext     | Te$t1234 |
#| S2       | ShpInquiry | Te$t1234 |

