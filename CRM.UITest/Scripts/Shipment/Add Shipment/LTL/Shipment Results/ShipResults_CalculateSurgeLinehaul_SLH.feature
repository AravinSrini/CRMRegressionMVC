@Sprint72 @30571
Feature: ShipResults_CalculateSurgeLinehaul_SLH


@Functional
Scenario Outline: 30571 - Verify the SLH calculations in shipment results page
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am passing the required information <Username>, <CustomerName>, <userType>
	And I am passing ShipFrom Information <oZip>, <oCity>, <oState>, <oName>, <oAdd>, <oServices>
	And I am passing ShipTo information <dZip>, <dCity>, <dState>, <dName>, <dAdd>, <dServices>
	And I am passing Classification information and i arrive on shipement result page for SLH <Usertype>,<CustomerName>,<oCity>,<oZip>,<oState>,<dCity>,<dZip>,<dState>,<classification>, <nmfc>, <quantity>, <weight>, <Username>, <oServices>, <dServices>, <desc>, <CalculationType>
	Then SLH should be calculated <CustomerName> when surge value is greater than zero and bump value is equal to zero 
	And linehaul value for carrrier in shipment results should be equal to SLH <userType>
Examples: 
| Scenario | Username | Password | CustomerName           | Usertype | oZip | oCity | oState | oName | oAdd | oServices | dZip | dCity | dState | dName | dAdd | dServices | classification | nmfc | quantity | weight | desc | CalculationType |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test |External  | 33126 | Miami | FL     | Test Origin | O Address | Appointment | 85282 | Tempe | AZ     | Test Dest | D Add | COD       | 70             | nmfc | 1        | 100    | testdata | BOTFACC         |
#| S2       | Stationown | Te$t1234 | Internal | ZZZ - GS Customer Test | 33126 | Miami | FL     | Test Origin | O Address | 85282 | Tempe | AZ     | Test Dest | D Add | 70             | nmfc | 1        | 100    | testdata | COD, Appointment |