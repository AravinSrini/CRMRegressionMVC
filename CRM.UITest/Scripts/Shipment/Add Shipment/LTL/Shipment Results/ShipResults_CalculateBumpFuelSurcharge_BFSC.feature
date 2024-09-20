@Sprint72 @30568
Feature: ShipResults_CalculateBumpFuelSurcharge_BFSC

@Functional
Scenario Outline: 30568 - Verify the bump fuel surcharge calculations in shipment results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am passing the required information <Username>, <CustomerName>, <Usertype>
	And I am passing ShipFrom Information <oZip>, <oCity>, <oState>, <oName>, <oAdd>, <oServices>
	And I am passing ShipTo information <dZip>, <dCity>, <dState>, <dName>, <dAdd>, <dServices>
	And I am passing Classification information and i arrive on shipement result page for BFSC <classification>, <nmfc>, <quantity>, <weight>, <desc>, <CalculationType>
	Then BFSC should be calculated for shipment when bump is available and surge is not available <CustomerName>,<Usertype>
	And fuel value of carrier in shipment results should be equal to BFSC <Usertype>

Examples: 
| Scenario | Username | Password | CustomerName           | Usertype | oZip  | oCity | oState | oName       | oAdd      | dZip  | dCity | dState | dName     | dAdd  | classification | nmfc | quantity | weight | desc     | oServices   | dServices | CalculationType |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | External | 33126 | Miami | FL     | Test Origin | O Address | 85282 | Tempe | AZ     | Test Dest | D Add | 70             | nmfc | 1        | 100    | testdata | Appointment | COD       | BOLH            |
