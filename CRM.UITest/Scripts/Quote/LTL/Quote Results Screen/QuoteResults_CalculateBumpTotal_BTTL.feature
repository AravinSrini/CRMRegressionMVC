@Sprint72 @30570 
Feature: QuoteResults_CalculateBumpTotal_BTTL

@Regression
Scenario Outline: 30570 - Verify the bump total charge calculations in quote results page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am on the quote results page with calculation for BTTL <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	Then Bump total value will be calculated <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	And displaying carrier total value in UI should match with calculated BTTL value

Examples: 
| Scenario | Username          | Password | customerAcc              | userType | oZip  | oCity | oState | dZip  | dCity | dState | classification | quantity | weight | oServices   | dServices |
| S1       | Both@test.com     | Te$t1234 | ZZZ - GS Customer Test   | External | 33126 | Miami | FL     | 85282 | Tempe | AZ     | 70             | 1        | 100    | Appointment | COD       |



