@30567 @Sprint72 
Feature: Calculate Bump Linehaul (BLH)

@Functional
Scenario Outline:30567-Verify Bump Linehaul when Bump has a value greater than Zero
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am passing the required information <Username>, <CustomerName>, <Usertype>
	And I am passing ShipFrom Information <oZip>, <oCity>, <oState>, <oName>, <oAdd>, <oServices>
	And I am passing ShipTo information <dZip>, <dCity>, <dState>, <dName>, <dAdd>, <dServices>	
	And I am passing Classification information and i arrive on shipement result page for BLH <Usertype>,<CustomerName>,<oCity>,<oZip>,<oState>,<dCity>,<dZip>,<dState>,<classification>, <nmfc>, <quantity>, <weight>, <Username>, <oServices>, <dServices>, <desc>, <CalculationType>
	Then The BLH value will be calculated <CustomerName>
	And The calculated Bump value should match with the value in UI of shipment results page

Examples: 
| Scenario | Username | Password | CustomerName           | Usertype | oZip  | oCity | oState | oName       | oAdd      | dZip  | dCity | dState | dName     | dAdd  | classification | nmfc | quantity | weight | desc     | oServices   | dServices | CalculationType |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | External | 33126 | Miami | FL     | Test Origin | O Address | 85282 | Tempe | AZ     | Test Dest | D Add | 70             | nmfc | 1        | 100    | testdata | Appointment | COD       | BOLH            |

