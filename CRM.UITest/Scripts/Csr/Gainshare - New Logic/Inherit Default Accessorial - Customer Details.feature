@NinjaSprint34 @96967 @Regression
Feature: Inherit Default Accessorial - Customer Details

Scenario: Verify CRM Rating Logic - No is displayed when Gainshare - New Logic not applied
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
And I have created a CSR doesn't have Gainshare - New Logic applied "96967 CSR No New Logic"
And I have completed the CSR approval process
And I am on the Account Management page
And I have searched for the CSR "96967 CSR No New Logic"
When I am on the Customer Details screen for the customer
Then the Pricing Model banner will read "CRM Rating Logic - No"
And the CRM Rating Logic cannot be edited

Scenario: Verify CRM Rating Logic - Yes is displayed when Gainshare - New Logic is applied
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
And I have created a CSR doesn't have Gainshare - New Logic applied "96967 CSR New Logic Applied"
And I have completed the CSR approval process
And I am on the Account Management page
And I have searched for the CSR "96967 CSR New Logic Applied"
When I am on the Customer Details screen for the customer
Then the Pricing Model banner will read "CRM Rating Logic - Yes"
And the CRM Rating Logic cannot be edited
