@NinjaSprint34 @Regression @96967
Feature: 96967 - Inherit Default Accessorial - Customer Details

Scenario: 96967 - Verify that when a customer has Gainshare new logic set to yes, then Crm Rating Logic also is displayed as yes
Given I am a sales, sales management, operations, station owner, pricing config, or system config user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
When I navigate to the Customer Details page "96967 New Logic Yes"
Then I will see CRM Rating Logic - "YES" displayed in the banner of the Pricing Model section
And I cannot edit the crm rating option

Scenario: 96967 - Verify that when a customer has Gainshare new logic set to no, then Crm Rating Logic also is displayed as no
Given I am a sales, sales management, operations, station owner, pricing config, or system config user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
When I navigate to the Customer Details page "96967 New Logic No"
Then I will see CRM Rating Logic - "NO" displayed in the banner of the Pricing Model section
And I cannot edit the crm rating option