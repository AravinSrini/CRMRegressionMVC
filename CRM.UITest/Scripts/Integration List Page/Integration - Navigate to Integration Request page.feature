@34272 @sprint75
Feature: Integration - Navigate to Integration Request page
	

Scenario Outline: 34272_Verify the navigation to Integration Request page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I am on the Integration List page
When I click on the Submit Integration Request button
Then I will arrive on the Integration Request Page <PageTitle>

Examples: 
| Scenario | Username    | Password | PageTitle                  |
| s1       | systemadmin | Te$t1234 | Submit Integration Request |