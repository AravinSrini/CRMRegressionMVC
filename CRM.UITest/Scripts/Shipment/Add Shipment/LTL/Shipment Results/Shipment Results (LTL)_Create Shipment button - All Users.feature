@28176 @Sprint70 
Feature: Shipment Results (LTL)_Create Shipment button - All Users

@Functional
Scenario Outline: verify the functionality of Create Shipment button on Shipment results page
Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
When I click on View rates button in add shipment ltl page
And I click on Create Shipment button of any carrier displayed
Then I must be navigated to Review and Submit Shipment page

Examples: 
| Scenario | Username   | Password | Usertype     | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | classification | nmfc | quantity | weight | itemdesc    |
| S1       | shp.entry  | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | test       | address     | 33126         | Dname           | Desaddress       | 85282              | 50             | 1234 | 1        | 1      | 100         |
| S2       | stationown | Te$t1234 | Internal     | ZZZ - GS Customer Test   | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 55             | 4563 | 6        | 1980   | Item double |

@Functional
Scenario Outline: Verify the functionality of Create Insured Shipment Button On Shipment Results page
Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
When I click on View rates button in add shipment ltl page
And I enter Insured value - <Insured>
And I click on Create Insured Shipment button of any carrier displayed
Then I must be navigated to Review and Submit Shipment page

Examples: 
| Scenario | Username   | Password | Usertype     | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | classification | nmfc | quantity | weight | itemdesc    | Insured |
| S1       | shp.entry  | Te$t1234 | StationOwner | ZZZ - Czar Customer Test | test       | address     | 33126         | Dname           | Desaddress       | 85282              | 50             | 1234 | 1        | 1      | 100         | 10000   |
| S2       | stationown | Te$t1234 | Internal     | ZZZ - GS Customer Test   | test       | Addr        | 33126         | Testing         | DAddr            | 85282              | 55             | 4563 | 6        | 1980   | Item double | 10000   |
