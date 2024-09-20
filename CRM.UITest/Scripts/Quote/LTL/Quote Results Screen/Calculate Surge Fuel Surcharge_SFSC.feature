@30572 @Sprint72 
Feature: Calculate Surge Fuel Surcharge_SFSC

@Regression
Scenario Outline:30572- Verify Surge Fuel Surcharge when Surge has a value greater than 0 and Bump has value equal to zero
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am on the quote results page to calculate SFSC <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	Then Surge Fuel Surcharge value will be calculated <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	And The calculated Surge Fuel Surcharge value should match with the UI value in quote list page

Examples: 
| Scenario | Username | Password | customerAcc            | userType | oZip  | oCity | oState | dZip  | dCity | dState | classification | quantity | weight | oServices   | dServices |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | External | 33126 | Miami | FL     | 85282 | Tempe | AZ     | 70             | 1        | 100    | Appointment | COD       |

