@30574 @Sprint72 
Feature: Calculate Surge Total (STTL)

@Functional
Scenario Outline:30574- Verify Surge total when Surge value is greater than 0
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am passing the required information <Username>, <CustomerName>, <Usertype>
	And I am passing ShipFrom Information <oZip>, <oCity>, <oState>, <oName>, <oAdd>, <oServices>
	And I am passing ShipTo information <dZip>, <dCity>, <dState>, <dName>, <dAdd>, <dServices>
	And I am passing Classification information and i arrive on shipement result page for STTL <Usertype>,<CustomerName>,<oCity>,<oZip>,<oState>,<dCity>,<dZip>,<dState>,<classification>, <nmfc>, <quantity>, <weight>, <Username>, <oServices>, <dServices>, <desc>, <CalculationType>
	Then STTL Value will be calculated <CustomerName>
	Then The calculated STTL value should match with the UI

Examples: 
| Scenario | Username | Password | CustomerName           | Usertype | oZip  | oCity | oState | oName       | oAdd      | dZip  | dCity | dState | dName     | dAdd  | classification | nmfc | quantity | weight | desc     | oServices   | dServices | CalculationType |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | External | 33126 | Miami | FL     | Test Origin | O Address | 85282 | Tempe | AZ     | Test Dest | D Add | 70             | nmfc | 1        | 100    | testdata | Appointment | COD       | BOLH            |


