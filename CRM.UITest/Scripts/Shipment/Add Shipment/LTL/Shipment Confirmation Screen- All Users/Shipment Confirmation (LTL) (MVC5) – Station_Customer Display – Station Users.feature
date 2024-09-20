@Sprint70 @28309
Feature: Shipment Confirmation (LTL) (MVC5) – Station_Customer Display – Station Users

@GUI
Scenario Outline: Test to verify Station_Customer Display_Shipment Confirmation (LTL) (MVC5)
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When I am on confirmation page of the shipment
   Then I should be display with mapped customer and station name  '<station_customer>' on confirmation page
 

  Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | station_customer                                 |
| Internal | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |ZZZ - Czar Customer Test  | Dname     |           | 55             | q123asd | 1        | 1      | desc |ZZZ - WEB SERVICES TEST - ZZZ - CZAR CUSTOMER TEST|




