@Sprint72 @30571 
Feature: QuoteResults_CalculateSurgeLinehaul_SLH

@Regression
Scenario Outline: 30571 - Verify the surge line haul calculations in quote results page 
	Given I am an DLS user and login into application with valid <Username> and <Password>		
	When  I am on the quote results page with calculation for SLH <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	Then SLH can be calculated <customerAcc> when surge value is greater than zero and bump value is equal to zero <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	And linehaul value for carrrier in quote results should be equal to SLH

	
	
Examples: 
| Scenario | Username | Password | customerAcc            | Service | userType | oZip  | oCity | oState | oCountry | dZip  | dCity | dState | dCountry | classification | quantity | quantityUnit | weight | weightUnit | oServices   | dServices |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | LTL     | External | 33126 | Miami | FL     | USA      | 85282 | Tempe | AZ     | USA      | 50             | 5        | skids        | 1000   | LBS        | Appointment | COD       |           


