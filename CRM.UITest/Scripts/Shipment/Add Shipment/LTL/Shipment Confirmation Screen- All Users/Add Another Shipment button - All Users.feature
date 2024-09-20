@28304 @Sprint70 @GUI
Feature: Add Another Shipment button - All Users
	
@Regression
Scenario Outline: Verify the Add Another Shipment button and functionality on shipment confirmation page -All Users
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the Add Another Shipment button
Then I will arrive on the Add Shipment page<Usertype>

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |
