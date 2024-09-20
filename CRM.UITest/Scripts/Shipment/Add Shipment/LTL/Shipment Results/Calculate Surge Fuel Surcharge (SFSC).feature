@30572 @Sprint72 
Feature: Calculate Surge Fuel Surcharge (SFSC)

@Functional
Scenario Outline:30572- Verify Surge Fuel Surcharge when Surge has a value greater than 0 and Bump has value equal to zero
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am passing the required information <Username>, <CustomerName>, <Usertype>
	And I am passing ShipFrom Information <oZip>, <oCity>, <oState>, <oName>, <oAdd>, <oServices>
	And I am passing ShipTo information <dZip>, <dCity>, <dState>, <dName>, <dAdd>, <dServices>
	And I am passing Classification information and i arrive on Shipment results page to calculate SFSC <Usertype>,<CustomerName>,<oCity>,<oZip>,<oState>,<dCity>,<dZip>,<dState>,<classification>, <nmfc>, <quantity>, <weight>, <Username>, <oServices>, <dServices>, <desc>, <CalculationType>
	Then SFSC value will be calculated <CustomerName>
	And The calculated Surge Fuel Surcharge value should match with the UI value

Examples: 
| Scenario | Username | Password | CustomerName           | Usertype | oZip  | oCity | oState | oName       | oAdd      | dZip  | dCity | dState | dName     | dAdd  | classification | nmfc | quantity | weight | desc     | oServices   | dServices | CalculationType |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | External | 33126 | Miami | FL     | Test Origin | O Address | 85282 | Tempe | AZ     | Test Dest | D Add | 70             | nmfc | 1        | 100    | testdata | Appointment | COD       | BOLH            |




