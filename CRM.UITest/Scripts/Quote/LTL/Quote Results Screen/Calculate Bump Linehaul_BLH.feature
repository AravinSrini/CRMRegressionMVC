@30567 @Sprint72 
Feature: Calculate Bump Linehaul_BLH

@Regression
Scenario Outline:30567- Verify Bump Linehaul when Bump has a value greater than Zero
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am on the quote results page to calculate the BLH <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	Then The Bump Linehaul value will be calculated <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	And The calculated Bump value should match with the value in UI of quotes results page
Examples: 
| Scenario | Username | Password | customerAcc            | userType | oZip  | oCity | oState | dZip  | dCity | dState | classification | quantity | weight | oServices   | dServices |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | External | 33126 | Miami | FL     | 85282 | Tempe | AZ     | 70             | 1        | 100    | Appointment | COD       |




