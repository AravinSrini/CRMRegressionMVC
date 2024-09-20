@NinjaSprint18 @38851
Feature: Master Carrier Rate Settings - Carrier accessorial shown NA

Scenario: Test to verify the Individual Accessorial Charge for all carriers_selected customer
Given I am systemadmin user
And I have navigated to the mastercarrierratesettings page
When I have defaultaccessorials values for the any accessorials type
Then I should be displayed with the default individual accessorials for all carriers


