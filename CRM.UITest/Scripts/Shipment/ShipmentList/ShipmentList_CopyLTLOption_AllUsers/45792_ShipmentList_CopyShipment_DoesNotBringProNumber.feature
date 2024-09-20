@45792 @NinjaSprint30 @Regression
Feature: Shipment Entry - Copy and Return Shipments - Remove PRO Ref #

Scenario Outline: 45792 - Verify that the PRO# field is not filled when copying shipments
	Given I am a ship entry, ship entry no rates, sales, sales management, operations, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on ShipmentList page
	And I click the copy shipment button on a shipment <RefNumber>
	And I clicked the yes button in the copy shipment popup box
	When I arrive on the Add Shipment (LTL) page
	Then the PRO NUMBER fields will be blank 
Examples: 
	| ProCount      | RefNumber    |
	| 0 PRO Numbers | ZZX002015346 |
	| 1 PRO Numbers | ZZX002011751 |
	| 2 PRO Numbers | ZZX002011831 |
	| 3 PRO Numbers | ZZX002015345 |	