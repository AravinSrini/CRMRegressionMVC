@Sprint71 @32030
Feature: Shipment Confirmation (LTL) (MVC5) - Upload Document Section Functionality

@GUI @Functional @DB 
Scenario Outline: 32030_Test to verify Upload Document Section Functionality_singlefile
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When I have uploaded files in Shipment Documents landing zone '<filepath>'
   Then I should be displayed with file link,confirmation of document,option to remove file
   And I should be able to download the file on click on the file link '<filename>'
   And file should be inserted in DB '<filename>'
   And remove file from docrepodb after the execution '<filename>'
 
 Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | filepath | filename |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |../../Scripts/TestData/Testfiles_confirmationupload/Tulips.jpg                                 |Tulips    |

@GUI @Functional @DB
Scenario Outline: 32030_Test to verify Upload Document Section Functionality_remove button
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When I have uploaded files in Shipment Documents landing zone '<filepath>'
   And I click on remove button in Upload Document Section
   Then Uploaded file should be removed
   And file should be removed from DB '<filename>'
 
 Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | filepath                                                                                      | filename |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |../../Scripts/TestData/Testfiles_confirmationupload/Tulips.jpg                                 |Tulips    |           






