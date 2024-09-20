@49192 @Sprint85
Feature: CRMAccessRRD_StationOwnerandOperations_Access

@GUI
Scenario: 49192 Verify Stations associated to logged in user are available in the Station dropdown
Given I am a Station Owner or Operations user
And I am on the Customer Invoice Page
When I Click on the Station dropdown
Then I should see All the station which I am associated 


@GUI
Scenario: 49192 Verify Customer Accounts in the Customer Account dropdown are loaded for the selected Station
Given I am a Station Owner or Operations user
And I am on the Customer Invoice Page
When I Select a Station from the Station dropdown
Then I will see All the Customer Account associated to selected Station 