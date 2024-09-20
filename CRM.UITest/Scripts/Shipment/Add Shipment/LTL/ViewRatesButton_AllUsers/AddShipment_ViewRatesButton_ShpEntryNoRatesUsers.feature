@AddShipment_ViewRatesButton_ShpEntryNoRatesUsers @28175 @Sprint70 
Feature: AddShipment_ViewRatesButton_ShpEntryNoRatesUsers
	
@GUI
Scenario Outline: Verify the click functionality of View Rates Button for Ship Entry No Rates user
	  Given I am a Ship Entry No Rates user <Username> <Password>
	  And I enter data in add shipment ltl page <Usertype>, <CustomerName>,<originName>,<originAddr1>,<originZipcode>,<destinationName>,<destinationAddr1>,<destinationZipcode>,<Classification>,<nmfc>,<quantity>,<weight>,<itemdesc>
   	  When I click on View rates button in add shipment ltl page	
	  And Verify that i will arrive on the <review_submit_page>
	  Then Verify I must see the <shippingfrom>,<shippingfromcontact_info>,<shippingTo>,<shippingTocontact_info>,<pickupDate>,<FreightDesc>,<ReferenceNo>,<DefaultSpecialInstruction>,<InsuredValue> and fields on review and submit page


Examples: 
| Scenario | Username           | Password | Usertype | CustomerName | originName | originAddr1 | originZipcode | destinationName | destinationAddr1 | destinationZipcode | Classification | nmfc    | quantity | weight | itemdesc       | shippingfrom  | shippingfromcontact_info   | shippingTo  | shippingTocontact_info   | pickupDate  | FreightDesc         | ReferenceNo       | DefaultSpecialInstruction    | InsuredValue  | review_submit_page               |
| S1       | prakashshpentynomg | Te$t1234 |          |              | Oname      | Oname1      | 30013         | Dname           | Dname2           | 30013              | 55             | 6789-01 | 5        | 100    | CLEANING WIPES | Shipping From | Shipping From Contact Info | Shipping To | Shipping To Contact Info | Pickup Date | Freight Description | Reference Numbers | Default Special Instructions | Insured Value | Review and Submit Shipment (LTL) |   

	
