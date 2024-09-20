@32964

Feature: Hide Shipments Reference Number - URL Change
	
@Regression
Scenario Outline:  32964 - Verify the URL from shipment details page
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
	And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	When I click on the View Shipment Details button on the confirmation page
	Then the BOL number will not be displayed in the URL details page

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |


Scenario Outline: 32964 - Verify the URL for the View Bill Of Landing
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
	And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	When I click on the drop down arrow of the Bill of Lading button and select View Bill of Landing option
	When I click on the drop down arrow of the Bill of Lading button
	#And I select View Bill of Landing option
	Then the BOL number will not be displayed in the URL of View Bill Of Landing page

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |


Scenario Outline: 32964 - Verify the URL for Print Shiipping Label
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
	And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	When I click on the drop down arrow of the Print Shipping Labels <Usertype> button  and make any selection from the drop down <Label_Name>
	#When I click on the drop down arrow of the Print Shipping Labels button <Usertype>
	#And  I make any selection from the drop down list <Label_Name>
	Then BOL number will not be displayed in the URL of Print Shiipping Label
	
Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | Label_Name        |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc | Full Page Label   |

Scenario Outline:  32964 - Verify the URL for shipment summary page
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
	And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	When I click on the drop down arrow of the View shipment Summary button and select View Shipment Summary button
	Then the BOL number will not be displayed in the URL shipment summary page

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |

@Ignore
Scenario Outline:  32964 - Verify the URL of shipment coverage document page
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
	And I click on the insured shipment and navigate to the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc> 
	When I click on the View Shipment Coverage button on the Shipment Confirmation page
	Then the BOL number will not be displayed in the URL Shipment Coverage page
	 
Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |





