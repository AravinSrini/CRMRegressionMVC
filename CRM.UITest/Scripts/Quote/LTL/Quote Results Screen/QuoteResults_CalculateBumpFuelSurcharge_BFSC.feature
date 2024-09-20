@Sprint72 @30568 
Feature: QuoteResults_CalculateBumpFuelSurcharge_BFSC
		BFSC will be calculated when bump is available and surge is not available


@Regression
Scenario Outline: 30568 - Verify the bump fuel surcharge calculations in quote results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am on the quote results page with calculation for BFSC <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	Then BFSC should be calculated when bump is available and surge is not available <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	And fuel value for carrrier in quote results should be equal to BFSC

Examples: 
| Scenario | Username | Password | customerAcc            | userType | oZip  | oCity | oState | dZip  | dCity | dState | classification | quantity | weight | oServices   | dServices |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | External | 33126 | Miami | FL     | 85282 | Tempe | AZ     | 70             | 1        | 100    | Appointment | COD       |

