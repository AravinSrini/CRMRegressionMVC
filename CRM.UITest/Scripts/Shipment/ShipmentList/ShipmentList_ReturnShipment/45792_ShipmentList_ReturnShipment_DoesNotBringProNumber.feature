@45792 @NinjaSprint30 @Regression @Shipment
Feature: Shipment Entry - Copy and Return Shipments - Remove PRO Ref #

Scenario Outline: 45792 - Verify that the PRO# field is not filled when returning shipments
	Given I am a ship entry, ship entry no rates, sales, sales management, operations, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on ShipmentList page
	And I click the Return Shipment button on a shipment <RefNumber>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page
	Then the PRO NUMBER field will be blank
Examples: 
	| ProCount      | RefNumber    |
	| 0 PRO Numbers | ZZX002015346 |
	| 1 PRO Numbers | ZZX002011751 |
	| 2 PRO Numbers | ZZX002011831 |
	| 3 PRO Numbers | ZZX002015345 |	

	@Ignore
Scenario:  45792 - Verify that the PRO# field is filled in when editing a shipment
	Given I am a ship entry, ship entry no rates, sales, sales management, operations, or station owner user with a valid "username-Currentsprintoperations" "password-Currentsprintoperations"
	And I am on ShipmentList page
	When I click on the edit shipment button "1"
	Then the PRO NUMBER field will be filled in with "4923716081"

	@Ignore
Scenario Outline:  45792 - Verify that the PRO# and additional reference field is filled in when editing a shipment with multiple PRO numbers
	Given I am a ship entry, ship entry no rates, sales, sales management, operations, or station owner user with a valid "username-Currentsprintoperations" "password-Currentsprintoperations"
	And I am on ShipmentList page
	When I click on the edit shipment button <ProNumberCount>
	Then the PRO NUMBER field and additional reference field will be filled in with <PRONumber1> <PRONumber2> <PRONumber3>
Examples: 
	| ProNumberCount | PRONumber1 | PRONumber2 | PRONumber3 |
	| 2              | 4923716081 | 123456     |            |
	| 3              | 4923716081 | 987654     | 654321     |	