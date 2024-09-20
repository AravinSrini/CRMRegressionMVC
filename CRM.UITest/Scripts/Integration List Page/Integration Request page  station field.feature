@Sprint75 @37497 
Feature: Integration Request page  station field
	
Scenario Outline: 37497- Verify if the displayed Station dropdown options are associated to the logged in user 
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
And I arrive on Integration Request page <IntegrationRequestPageTitle>
When I am associated to multiple station and I select the station field
Then I will only have the option to select stations which I am associated to

Examples: 
| Scenario | UserName                  | Password | IntegrationRequestPageTitle |
| S1       | MultipleStation@gmail.com | Te$t1234 | Submit Integration Request  |

Scenario Outline: 37497 - Verify Station field when the user is associated to a single station
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then The station must be prepopulated when I have only one station associated

Examples: 
| Scenario | UserName         | Password | IntegrationRequestPageTitle |
| S1       | Opstage@user.com | Te$t1234 | Submit Integration Request  | 