@ShipmentResultsLTLBackButtonsAllUsers @30188 @Sprint71 @API
Feature: ShipmentResults_LTL_Backbuttons_AllUsers

@GUI
Scenario Outline: 30188_Verify the Back to Add shipment and Back to shipment List buttons for All user
	    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
		And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
		When I click on View rates button in add shipment ltl page	
		And I am navigated to the Shipment Results LTL page
		Then I will see the <Back_to_AddShipment> and <Back_to_ShipmentList> button

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | Back_to_AddShipment  | Back_to_ShipmentList  |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Back to Add Shipment | Back to Shipment List |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Back to Add Shipment | Back to Shipment List |


@GUI
Scenario Outline: 30188_Verify the click functionality of Back to Add Shipment button for All user
	    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
		And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
		When I click on View rates button in add shipment ltl page	
		And I am navigated to the Shipment Results LTL page
		And I click on Back to Add Shipment button
		Then I must be arrive on Add Shipment LTL page
		And Verified previously entered information on Add shipment LTL Page will be displayed <originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>


Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |
| S2       | zzzext                | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |


@GUI @Regression @DBVerification @Functional
Scenario Outline: 30188_Verify the click functionality of Back to Shipment List button for External Ship entry user
	    Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	    And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
		When I click on View rates button in add shipment ltl page	
		And I am navigated to the Shipment Results LTL page
		And I click on Back to Shipment List button
		Then I must be arrive to the Shipment List page
		And The Shipment List will be shows default to the previous Thirty days shipment data <Account>,<option>

Examples: 
| Username | Password | Usertype | CustomerName | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | Account                  | option |
 | zzzext   | Te$t1234 | External |              | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | ZZZ - Czar Customer Test | ALL    |


@GUI @Regression @DBVerification @Functional
Scenario Outline: 30188_Verify the click functionality of Back to Shipment List button for Internal users
	    Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
		And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
		When I click on View rates button in add shipment ltl page	
		And I am navigated to the Shipment Results LTL page
		And I click on Back to Shipment List button
		Then I must be arrive to the Shipment List page
		And Previously selected <CustomerName> must be display in customer list
		And The Shipment list will display shipments from the previous Thirty days for the customer selected <CustomerName> <Option>

Examples: 
| Username              | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | Option |
| crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | ALL    |



		
	