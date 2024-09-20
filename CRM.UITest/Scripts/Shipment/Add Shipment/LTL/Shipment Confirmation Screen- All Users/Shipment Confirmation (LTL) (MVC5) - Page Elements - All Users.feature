
@Sprint70 @28274  
Feature: Shipment Confirmation (LTL) (MVC5) - Page Elements - All Users

@GUI
Scenario Outline: Test to verify page_elements_Shipment Confirmation (LTL) (MVC5)
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   Then I should be display with service,Bol number,Status,Upload Shipping Documents section fields and View Shipment Details,Print Shipping Labels,Add Another Shipment
   And I should displayed with document uploadarea and ''<Usertype>''and '<verbiage2>'
   And I should'<Usertype>' be display the option to click on a link to browse my computer and networks to locate a document and drop it to the document upload area and option to drag and drop a document to the document upload area
 Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | verbiage1 | verbiage2                                      |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |           | Drag files here or browse for files to upload. |

@GUI
Scenario Outline: Test to verify page_elements_Shipment Confirmation (LTL) (MVC5)_Shipment Document Preference is BOL
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   Then I should '<Usertype>' be displayed with message for receiving BOL document '<message>' and Bill of Lading button
 
 Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |message|
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |You will receive a confirmation email shortly with the Bill of Lading attached.| 


@GUI
Scenario Outline: Test to verify page_elements_Shipment Confirmation (LTL) (MVC5)_Shipment Document Preference is Shipment Summary Document
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   Then I should '<Usertype>'be displayed with message for receiving summary document '<message>' and Shipment Summary button
 
  Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name | oComments | dComments | classification | nmfc    | quantity | weight | desc | message                                                                           |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |               | Dname     |           | 55             | q123asd | 1        | 1      | desc | You will receive a confirmation email shortly with the Shipment Summary attached. |






