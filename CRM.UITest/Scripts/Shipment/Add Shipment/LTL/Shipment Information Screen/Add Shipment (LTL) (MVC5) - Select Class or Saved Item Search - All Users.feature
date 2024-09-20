@Sprint71 @32094
Feature: Add Shipment (LTL) (MVC5) - Select Class or Saved Item Search - All Users

@GUI 
Scenario Outline: 32094_Test to verify highlighted in the class or saved item drop down list
    Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	When I am on  Add Shipment (LTL) page in shipment process '<UserType>','<CustomerName>'
	Then the class or saved items that match the values will be highlighted in the class for the searchedvalue '<searchedval>' 
	
Examples: 
| Scenario | Username              | Password | UserType | CustomerName   | searchedval |
| 1        | crmOperation@user.com | Te$t1234 | Internal | testing_uat123 | 5           |
| 2        | shpent                | Te$t1234 | External |                | 5           |

@GUI 
Scenario Outline: 32094_Test to verify highlighted in the class or saved item drop down list_additional item
    Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	When I am on  Add Shipment (LTL) page in shipment process '<UserType>','<CustomerName>'
	And I clicked on add additional item button
	Then the class or saved items that match the values will be highlighted in the class of additional item for the searchedvalue '<searchedval>' 
	
Examples: 
| Scenario | Username              | Password | UserType | CustomerName   | searchedval |
| 1        | crmOperation@user.com | Te$t1234 | Internal | testing_uat123 |  5          |
| 2        | shpent                | Te$t1234 | External |                |  5          |