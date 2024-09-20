@31431 @Sprint70 
Feature: Shipment Confirmation (LTL)_Page Bind - All Users

@Acceptance
Scenario Outline: Verify data for all the fields on Shipment Confirmation Page (External Users)
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	And I click on Create Shipment button of any carrier displayed 
	And I am on the Review and Submit page
	And I click on Submit button on Review and Submit page
	And I arrive on the Shipment Confirmation page
	Then The following fields should be binded - '<Service>' ,'<Status>' and BOLNumber

Examples: 
| Usertype     | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | classification | nmfc | quantity | weight | itemdesc    | Service | Status    |
| StationOwner | ZZZ - Czar Customer Test | test       | address     | 33126         | Dname           | Desaddress       | 85282              | 50             | 1234 | 1        | 1      | 100         | LTL     | Submitted |

@Acceptance
Scenario Outline: Verify data for all the fields on Shipment Confirmation Page (Internal Users)
	Given I am a shp.entry, operations, sales, sales management or station user
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	And I click on Create Shipment button of any carrier displayed 
	And I am on the Review and Submit page
	And I click on Submit button on Review and Submit page
	And I arrive on the Shipment Confirmation page
	Then The following fields should be binded to internal users - '<Service>' ,'<Status>' and BOLNumber

Examples: 
| Usertype     | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | classification | nmfc | quantity | weight | itemdesc    | Service | Status    |
| Internal     | ZZZ - GS Customer Test   | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 55             | 4563 | 6        | 1980   | Item double | LTL     | Submitted |
