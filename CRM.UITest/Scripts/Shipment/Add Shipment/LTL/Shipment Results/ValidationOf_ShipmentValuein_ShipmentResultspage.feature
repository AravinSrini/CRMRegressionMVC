@ValidationOfShipmentValue @32149 @Sprint71 
Feature: ValidationOf_ShipmentValuein_ShipmentResultspage
	

@GUI
Scenario Outline: Validate the Shipment value text box when value exceeds one lakh in shipment results page
    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
    And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I select <MoveType> and <InventoryLocationType> depending on the Customer Specific references <CustSpecRef> 
	When I click on View rates button in add shipment ltl page
	When I enter the Shipment value in shipment results page <ShipmentValue>
	Then Shipment value text box should be highlighted in red

Examples: 
| Scenario | Username       | Password    | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc | quantity | weight | itemdesc | ShipmentValue | MoveType | InventoryLocationType | CustSpecRef |
| S1       | Entry.allstate | Connect@123 |          |                        | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     | 100,0001      | Cust     | 01 – Downing          |    Yes      |
| S2       | stationown     | Te$t1234    | Internal | ZZZ - GS Customer Test | Test       | Add         | 33126         | tesing          | Addrl            | 85282              | 50             | 45   | 5        | 4      | item     | 100,001.00    |          |                       |    No       |
