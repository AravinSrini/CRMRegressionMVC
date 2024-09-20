@37496 @sprint75
Feature: Integration_NavigationIntegrationListFromIntegrationRequestPage


@GUI @Functional
Scenario Outline: 37496_Verify the navigation from IntehrationRequest to IntegrationList 
Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
When I am on Integration Request page
And I click the back to integration list button
Then I will return to the integration list page <PageTitle>

Examples: 
| Scenario | Username    | Password | PageTitle						|
| s1       | systemadmin | Te$t1234 | Integration Request List      |
