@Sprint90 @90444 @Regression
Feature: ShipmentImport_AddReferenceforCRMRatingLogicFlag
	

Scenario Outline: 90444_Verify the Reference Type as CRMRL and Reference value is True in MG for the Customer associated to the Shipment has CRM Rating Logic Turned On
Given I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user<Usertype>
And I am creating an LTL shipment in CRM<Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
And the customer account associated to the shipment has CRM rating logic turned on<Customer_Name>
When I click submit shipment from the Review and Submit Shipment (LTL) page
Then the shipment will be created in Mercurygate with a reference type of "CRMRL"
And the reference value will be "true"
Examples: 

| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name				| oComments | dComments | classification | nmfc    | quantity | weight | desc | 
| External | asd   | 33126 | DName | OAddress | werr  | DAddress | 60606 | Daddress |  ZZZ - Czar Customer Test | Dname     | test      | 55             | q123asd | 1        | 1      | desc | 
| Internal | asd   | 33126 | DName | OAddress | werr  | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test  | Dname     | test      | 55             | q123asd | 1        | 1      | desc | 
| Sales    | asd   | 33126 | DName | OAddress | werr  | DAddress | 60606 | Daddress |  ZZZ - Czar Customer Test | Dname     | test      | 55             | q123asd | 1        | 1      | desc | 


Scenario Outline: 90444_Verify the Reference Type as CRMRL and Refernce value is True in MG for the Customer associated to the Edit Shipment has CRM Rating Logic Turned On
Given I'm sales, salesmanagement, operations, or station owner user<Usertype>
And I am editing an LTL shipment in CRM<Customer_Name>
And the customer account associated to the shipment has CRM rating logic turned on<Customer_Name>
When I click submit shipment from the Review and Submit Shipment (LTL) page
Then the shipment will be updated in Mercurygate with a reference type of "CRMRL"
And the reference value will be "true"
Examples: 
| Usertype | Customer_Name				|
| Internal | ZZZ - Czar Customer Test   |
| Sales    | ZZZ - Czar Customer Test	|



Scenario Outline: 90444_Verify the Reference Type CRMRL is not added in MG for the Customer associated to the Shipment has CRM Rating Logic Turned Off
Given I am Shp.Entry, Shp.Entrynorates, Sales, Sales Management, Operations, or Station Owner user<Usertype>
And I am creating an LTL shipment for the Customer having CRM Rating Logic off<Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click submit shipment from the Review and Submit Shipment (LTL) page
Then the shipment will be created in Mercurygate without a reference type "CRMRL"
Examples: 

| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name									   | oComments | dComments | classification | nmfc    | quantity | weight | desc | 
| External | asd   | 33126 | DName | OAddress | werr  | DAddress | 60606 | Daddress |  ZZZ - GS D e m o								   | Dname     | test      | 55             | q123asd | 1        | 1      | desc | 
| Internal | asd   | 33126 | DName | OAddress | werr  | DAddress | 60606 | Daddress | ZZZ - GS D e m o								   | Dname     | test      | 55             | q123asd | 1        | 1      | desc | 
| Sales    | asd   | 33126 | DName | OAddress | werr  | DAddress | 60606 | Daddress |  ZZZ - GS D e m o								   | Dname     | test      | 55             | q123asd | 1        | 1      | desc | 


Scenario Outline: 90444_Verify the Reference Type as CRMRL is not added in  MG for the Customer associated to the Edit Shipment has CRM Rating Logic Turned Off
Given I'm Sales, Sales Management, Operations, or Station Owner User<Usertype>
And I am editing LTL shipment belongs to Customer having CRM Rating Logic off<Customer_Name>
When I click submit shipment from the Review and Submit Shipment (LTL) page
Then the shipment will be created in Mercurygate without a reference type "CRMRL"
Examples: 

| Usertype | Customer_Name				|
| Internal | ZZZ - GS D e m o           |
| Sales    | ZZZ - GS D e m o			|
