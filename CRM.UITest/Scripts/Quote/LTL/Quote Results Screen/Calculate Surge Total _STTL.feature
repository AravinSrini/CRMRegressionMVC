@30574 @Sprint72 
Feature: Calculate Surge Total_(STTL)

@Regression
Scenario Outline:30574- Verify Surge total when Surge value is greater than 0
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I am on the quote results page to calculate STTL <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	Then Surge total value will be calculated <Username>, <customerAcc>, <userType>, <oZip>, <oCity>, <oState>, <dZip>, <dCity>, <dState>, <classification>, <quantity>, <weight>, <oServices> and <dServices>
	And The calculated STTL value should match with the UI values in quote results page

Examples: 
| Scenario | Username | Password | customerAcc            | userType | oZip  | oCity | oState | dZip  | dCity | dState | classification | quantity | weight | oServices   | dServices |
| S1       | Both     | Te$t1234 | ZZZ - GS Customer Test | External | 33126 | Miami | FL     | 85282 | Tempe | AZ     | 70             | 1        | 100    | Appointment | COD       |

