@TilePageCustomerUsers @Sprint69 @28331 @GUI


Feature: Service-TILE page - Customer Users
	


Scenario Outline: Verify shipment service types(tiles) when customer I am associated to is CSA only
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
Then I Can see the services associated to the customer<TMS_Type>
Examples: 
| Scenario | Username | Password | Service | Customer_Name              | TMS_Type |
| s1       | zzzext   | Te$t1234 | LTL     |  ZZZ - Czar Customer Test  | MG       |




Scenario Outline: Verify shipment service types(tiles) when customer I am associated to is MG
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
Then I Can see the services associated to the customer<TMS_Type>
Examples: 
| Scenario | Username        | Password | Service | Customer_Name           |TMS_Type|
| s1       | zzzcsa@stage.com| Te$t1234 | LTL     | Kim Manufacturing       | BOTH   |



Scenario Outline: Verify shipment service types(tiles) when customer I am associated to is MG and CSA(BOTH)
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I click on Add Shipment button
And I will be navigated to Add Shipment Tiles page
Then I Can see the services associated to the customer<TMS_Type>
Examples: 
| Scenario | Username               | Password | Service | Customer_Name           |TMS_Type|
| s1       |Both@test.com           | Te$t1234 | LTL     | ZZZ - GS Customer Test  | BOTH    |