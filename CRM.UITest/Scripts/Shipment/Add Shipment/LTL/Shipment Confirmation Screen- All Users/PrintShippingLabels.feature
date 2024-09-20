@28302 @Sprint70
Feature: PrintShippingLabels

@GUI	
Scenario Outline: Verify the options for print shipping labels button
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Print Shipping Labels button <Usertype>
Then I will have four options Full Page Label,two Labels Per Page,four Labels Per Page,six Labels Per Page

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |

@GUI
Scenario Outline: Verify the shipping labels displayed on selecting an option
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Print Shipping Labels button <Usertype>
And  I make any selection from the drop down list <Label_Name>
Then a new tab will open in CRM


Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | Label_Name      |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc | Full Page Label |

