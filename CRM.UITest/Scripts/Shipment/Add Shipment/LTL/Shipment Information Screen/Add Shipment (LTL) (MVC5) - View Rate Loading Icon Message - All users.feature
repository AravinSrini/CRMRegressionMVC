@32725 @Sprint71 @AddShipment(LTL)(MVC5)ViewRateLoadingIconMessageAllusers
Feature: Add Shipment (LTL) (MVC5) - View Rate Loading Icon Message - All users

@GUI
Scenario Outline: 32725 - Verify loading icon message in Add Shipment (LTL) Page
Given I am a shp.entry, operations, sales, sales management, or station owner user <Username> <Password>
	When I am on the Add Shipment(LTL) page<Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
	Then loading message will be displayed for view rates button click<loadingMess>

	Examples: 
| Scenario | Username					 | Password | Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | loadingMess                                       |
| S1       | zzzext						 | Te$t1234 | External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc | Please wait while we are getting the carrier list |
| S2       | crmoperation				 | Te$t1234 | Internal | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc | Please wait while we are getting the carrier list |

