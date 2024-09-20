@Sprint71 @32162
Feature: Shipment Confirmation (LTL) (MVC5) - Upload Document to Doc Repository

@GUI @Functional 
Scenario Outline: 32162_Test to verify Upload Document Functionality_docrepo
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When I have uploaded files in Shipment Documents landing zone '<filepath>'
   And I have navigated to docrepo recently added page
   Then I should be diaplyed the uploadefile '<filename>' in recently added folder
   And I should be displayed in '<filename>' BOL folder
   And remove file from docrepodb after the execution '<filename>'
   
 
 Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | filepath                                                                                      | filename |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |../../Scripts/TestData/Testfiles_confirmationupload/Tulips.jpg                                 |Tulips    |

@GUI @Functional 
Scenario Outline: 32162_Test to verify Upload Document Functionality_PrimaryReferencenumber mapping_docrepo
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When I have uploaded files in Shipment Documents landing zone '<filepath>'
   Then I should be diaplyed the uploadefile '<filename>' will be assigned the CRM Primary Reference number of the shipment in Docrepo module
   And remove file from docrepodb after the execution '<filename>'
 
 
 Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | filepath                                                                                      | filename |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |../../Scripts/TestData/Testfiles_confirmationupload/Tulips.jpg                                 |Tulips    |

