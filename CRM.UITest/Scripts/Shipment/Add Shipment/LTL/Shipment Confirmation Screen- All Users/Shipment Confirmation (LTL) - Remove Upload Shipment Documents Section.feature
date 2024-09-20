@33188 @Sprint71 
Feature: Shipment Confirmation (LTL) - Remove Upload Shipment Documents Section

@GUI @Functional
Scenario Outline: 33188_Test to verify Remove Upload Shipment Documents Section
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When I arrive on the Shipment Confirmation page in the shipment process
   Then I should not be displayed with Upload Shipment Documents Section
 
 Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |


