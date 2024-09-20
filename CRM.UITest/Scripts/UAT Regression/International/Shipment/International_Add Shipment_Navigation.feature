@35480 @Regression @Sprint75

Feature: International_Add Shipment_Navigation

Scenario Outline: 35480 - Verify Shipment Locations and Dates page for International shipments -From Dasboard page
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	When  I land on the dashboard page
	And   I select International from Create A Shipment section<Type>,<level>
	And   I click on Create  Shipment button
    Then  I must land on the Shipment Locations and Dates page for International

Examples: 
| userName | password | Type         | level      |
| Both     |  | Air - Import | Air Direct | 


Scenario Outline: 35480 - Verify Shipment Locations and Dates page for International shipments -From Navigation menu
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	When  I land on the dashboard page
	And   I click Shipment icon from the menu
	And   I select Add Shipment on the Shipment List page
    And   I land on the Add Shipment (tiles) page
	And   I click on International tiles <Type>,<level>
    Then  I must land on the Shipment Locations and Dates page for International

Examples: 
| userName | password | Type         | level      |
 | Both     | Te$t1234 | Air - Import | Air Direct | 


	