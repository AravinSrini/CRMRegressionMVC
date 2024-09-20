@NinjaSprint34 @Regression @96965
Feature: 96965 - Inherit Default Accessorial - CSR Details

Scenario: 96965 - Verify Gainshare New Logic field is displayed on Customer Details page
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
And I am on the CSR List screen
And I am on the CSR Details screen for the CSR "New CSR With New Logic as No"
When I expand the Pricing Model section for "Gainshare"
Then I will see the Gainshare - New Logic Field
And the field will be displayed below the Rating Instruction and Rate Provisions field

Scenario Outline: 96965 - Verify Gainshare New Logic field value is Yes when CRM rating logic is Yes
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
And I am on the CSR List screen
And I am on the CSR Details screen for the CSR: <CustomerName>
When I expand the Pricing Model section for "Gainshare"
Then the Gainshare - New Logic field value will be Yes
Examples:
| CustomerName                  |
| New CSR With New Logic as Yes |
| Darshan Ninja 10              |

Scenario Outline: 96965 - Verify Gainshare New Logic field value is No when CRM rating logic is No
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
And I am on the CSR List screen
And I am on the CSR Details screen for the CSR: <CustomerName>
When I expand the Pricing Model section for "Gainshare"
Then the Gainshare - New Logic field value will be No
Examples:
| CustomerName                 |
| New CSR With New Logic as No |
| Ninjajuly                    |

Scenario: 96965 - Verify Gainshare New Logic field is not present for CSR with Tariff pricing model
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
And I am on the CSR List screen
And I am on the CSR Details screen for the CSR "96965 Tariff Customer"
When I expand the Pricing Model section for "Tariff"
Then the Gainshare New Logic field will not be present


Scenario: 96965 - Verify Gainshare New Logic field is not present for CSR with no pricing model
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
And I am on the CSR List screen
And I am on the CSR Details screen for the CSR "96965 No Pricing Customer"
When I expand the Pricing Model section for "None"
Then the Gainshare New Logic field will not be present