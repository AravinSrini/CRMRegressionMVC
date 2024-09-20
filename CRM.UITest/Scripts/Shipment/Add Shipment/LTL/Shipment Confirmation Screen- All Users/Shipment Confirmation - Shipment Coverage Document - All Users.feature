@Sprint71 @30316
 
Feature: Shipment Confirmation - Shipment Coverage Document - All Users

@GUI
Scenario Outline: 30316 - Verify the shipment coverage button 
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
When I Am on the shipment confirmation of insured shipment  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
Then I will see the View Shipment Coverage button

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |  ZZZ - GS Customer Test  | Dname     |           | 55             | q123asd | 1        | 1      | desc |

@GUI
Scenario Outline: 30316 -  Verify the shipment coverage document in new tab 
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
When I Am on the shipment confirmation of insured shipment  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
And I click on the View Shipment Coverage button
Then the Shipment Coverage document will be displayed in the new tab

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |

@GUI
Scenario Outline: 30316 - Verify if shipment coverage button is not present
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
When I Am on the shipment confirmation page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
Then I will not see the View Shipment Coverage button

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |  ZZZ - GS Customer Test  | Dname     |           | 55             | q123asd | 1        | 1      | desc |





