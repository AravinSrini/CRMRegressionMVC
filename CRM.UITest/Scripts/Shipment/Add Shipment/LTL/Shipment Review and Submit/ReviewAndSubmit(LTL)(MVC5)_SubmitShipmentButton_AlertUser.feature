@Sprint72 @32858 @ReviewAndSubmit(LTL)(MVC5)_SubmitShipmentButton_AlertUser
Feature: ReviewAndSubmit(LTL)(MVC5)_SubmitShipmentButton_AlertUser
	

@GUI
Scenario Outline: Verify the Indication Message for Submit Shipment
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	When I click the Submit Shipment Button on the Review and Submit (LTL) page<Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	Then I will receive an indication that CRM is processing my shipment<IndicationMessage>

	Examples: 
| Scenario | Username     | Password | Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name | oComments | dComments | classification | nmfc    | quantity | weight | desc | IndicationMessage                                   |
| S1       | zzzext       | Te$t1234 | External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |               | Dname     |           | 55             | q123asd | 1        | 1      | desc | Please wait while your shipment is being processed. |
| S2       | crmoperation | Te$t1234 | Internal | asd   | 60606 | DName   | OAddress |       | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc | Please wait while your shipment is being processed. |


