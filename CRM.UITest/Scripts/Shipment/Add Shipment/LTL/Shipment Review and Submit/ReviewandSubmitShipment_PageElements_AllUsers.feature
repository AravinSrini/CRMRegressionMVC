@ReviewandSubmitShipment_PageElements_AllUsers @28254 @Sprint70 
Feature: ReviewandSubmitShipment_PageElements_AllUsers
	

@GUI
Scenario Outline: Verify the Sections and field on review and submit page for all user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page		
	And I arrive on Review and Submit Shipment LTL page <Usertype>
	Then I verified <shippingfrom>,<shippingfromcontact_info>,<shippingTo>,<shippingTocontact_info>,<pickupDate>,<FreightDesc>,<ReferenceNo>,<DefaultSpecialInstruction>,<InsuredValue>,<carrierinfo> and fields on review and submit page	
	And I will see the Edit Shipping Info button
	And I will see the Submit Shipment button

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | shippingfrom  | shippingfromcontact_info   | shippingTo  | shippingTocontact_info   | pickupDate  | FreightDesc         | ReferenceNo       | DefaultSpecialInstruction    | InsuredValue  | carrierinfo  |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Shipping From | Shipping From Contact Info | Shipping To | Shipping To Contact Info | Pickup Date | Freight Description | Reference Numbers | Default Special Instructions | Insured Value | Carrier Info |
| S2       | shp.entry             | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Shipping From | Shipping From Contact Info | Shipping To | Shipping To Contact Info | Pickup Date | Freight Description | Reference Numbers | Default Special Instructions | Insured Value | Carrier Info |    



@GUI
Scenario Outline: Verify the Hazardous Materials all fields on review and submit page for all user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I select the Hazardous Materials as yes <UNnumber>,<CCN>,<hazmatPackaging_Group>,<hazmat_class>,<hazmat_contactName>,<hazmat_Phoneno>
	When I click on View rates button in add shipment ltl page	
	And I arrive on Review and Submit Shipment LTL page <Usertype>
	Then Verify I should see the <un_number>,<ccn_number>,<hazmat_package>,<hazmatclass>,<em_contactname>,<em_phone> of Hazardous Materials on review and submit page

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | UNnumber | CCN     | hazmatPackaging_Group | hazmat_class | hazmat_contactName | hazmat_Phoneno | un_number | ccn_number | hazmat_package         | hazmatclass  | em_contactname             | em_phone                 |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1234     | 1234567 | II                    | 1            | hazmat name        | 7878787878     | UN Number | CNN Number | Hazmat Packaging Group | Hazmat Class | Emergency Response Contact | Emergency Response Phone |
| S2       | shp.entry             | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1234     | 1234567 | II                    | 1            | hazmat name        | 7878787878     | UN Number | CNN Number | Hazmat Packaging Group | Hazmat Class | Emergency Response Contact | Emergency Response Phone |


@GUI
Scenario Outline: Verify the default special instructions of associated user on review and submit page for all user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page	
	And I arrive on Review and Submit Shipment LTL page <Usertype>
	Then Verify I should see the defined <defaultspecialinstruction> on review and submit page

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | defaultspecialinstruction                    |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Sprint 69 Special Instructions Display test. |
| S2       | shp.entry             | Te$t1234 |          |                        | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Sprint 69 Special Instructions Display test. | 


@GUI
Scenario Outline: Verify the insured value field on review and submit page for all user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I enter the <insuredvalue> and <insuredtype> in Add shipment page 
	When I click on View rates button in add shipment ltl page
	And I arrive on Review and Submit Shipment LTL page <Usertype>
	Then Verify I should see the <insuredvalue> and <insuredtype> on review and submit page


Examples: 
| Scenario | Username              | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | insuredvalue | insuredtype |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000         | Used        |
| S2       | shp.entry             | Te$t1234 |          | Test                   | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | 1000         | Used        |



@GUI
Scenario Outline: Verify the customer specific reference number of associated user on review and submit page for all user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	And I expand Reference number section and select <movetype>,<inventorylocationtype>
	When I click on View rates button in add shipment ltl page
	And I arrive on Review and Submit Shipment LTL page <Usertype>
	Then Verify customer specific reference with Move Type and Inventory Location Type on review and submit page

Examples: 
| Scenario | Username                   | Password | Usertype | CustomerName           | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | movetype | inventorylocationtype |
| S1       | Allstateshipentry@user.com | Te$t2345 | External | ZZZ - GS Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Cust     | 01 – Downing          |



@GUI
Scenario Outline: Verify carrier info section on review and submit page for internal user
	Given I am a operations, sales, sales management or station owner user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	And I arrive on Review and Submit Shipment LTL page <Usertype>
	Then Verify the carrier info section on review and submit page
	And I will see the edit carrier info icon 

Examples: 
| Scenario | Username              | Password | Usertype | CustomerName             | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |


@GUI
Scenario Outline: Verify carrier info section on review and submit page for ship entry user 
	Given I am a shp.entry user <Username> <Password>
	And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
	When I click on View rates button in add shipment ltl page
	And I arrive on Review and Submit Shipment LTL page <Usertype>
	Then Verify the carrier info section on review and submit page for ship entry user
	And I will see the edit carrier info icon 

Examples: 
| Scenario | Username  | Password | Usertype | CustomerName | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       |
| S1       | shp.entry | Te$t1234 |          |              | Oname      | Oname1      | 33126         | Dname           | Dname2           | 85282              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES |






