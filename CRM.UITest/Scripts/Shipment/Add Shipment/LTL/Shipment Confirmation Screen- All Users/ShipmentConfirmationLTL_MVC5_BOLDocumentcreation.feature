@30676 @Sprint70
Feature: ShipmentConfirmationLTL_MVC5_BOLDocumentcreation

@GUI @Functional
Scenario Outline: Verify Bill of Lading button options on Shipment confirmation page
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Bill of Lading button
Then I should display with <twoptions>

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | twoptions                                |
| External | asd   | 33126 | DName | OAddress | werr  | DAddress | 60606 | Daddress |                          | Dname     | test      | 55             | q123asd | 1        | 1      | desc | View Bill Of Lading,Email Bill Of Lading |

@Functional
Scenario Outline: Verify BOL document creation on click on View Bill of Lading on shipment confirmationn page
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Bill of Lading button
When I click on View Bill of Lading option
Then New tab will be opened which will display the BOL of shipment

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2  | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| Internal | asd   | 60409 | DName | OAddress | tutyty | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc |