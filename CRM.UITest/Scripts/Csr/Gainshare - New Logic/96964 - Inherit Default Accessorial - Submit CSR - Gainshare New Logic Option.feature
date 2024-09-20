@NinjaSprint34 @Regression @96964
Feature: 96964 - Inherit Default Accessorial - Submit CSR - Gainshare New Logic Option

Scenario: 96964 - Verify Gainshare New Logic Field Is Displayed And Is Not Selected for a new CSR
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I choose Gainshare from the Select A Pricing Type drop down list
Then I will see a field Gainshare - New Logic
And I will see a check box associated to the new field
And the check box by default will not be selected

Scenario: 96964 - Verify Gainshare New Logic Field Is Displayed for a revised CSR
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for customer "GS - Ninja Customer not revised"
And I am on the Pricing Model page
When I choose Gainshare from the Select A Pricing Type drop down list
Then I will see a field Gainshare - New Logic
And I will see a check box associated to the new field

Scenario: 96964 - Verify Gainshare New Logic Field remains checked when I check it in the pricing model and continue then go back
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
When I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
And I click the save button
And I then click the back button on the saved items and addresses page
Then the gainshare new logic check box will be selected

Scenario: 96964 - Verify Gainshare New Logic is displayed on the review and submit page for a new CSR
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
And the pricing model of the customer is Gainshare
When I arrive on the Review and Submit page
Then I will see a new field Gainshare - New Logic
And the new field will be located below the Master Accessorial Charge field
And the new field will be located above the Individual Accessorial Charges field

Scenario: 96964 - Verify Gainshare New Logic is displayed on the review and submit page for a revised CSR
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for customer "GS - Ninja Customer not revised"
And I am on the Pricing Model page
And the pricing model of the customer is Gainshare
When I arrive on the Review and Submit page
Then I will see a new field Gainshare - New Logic
And the new field will be located below the Master Accessorial Charge field
And the new field will be located above the Individual Accessorial Charges field

Scenario Outline: 96964 - Verify Gainshare New Logic Checkbox is checked based on CRM Rating Logic for a revised CSR
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And the pricing model of the customer is Gainshare and the CRM Rating Logic flag is <option>
When I am submitting a revised csr and go to the Pricing Model Page
Then the Gainshare - New Logic check box will be checked based on the rating logic value <option>
And I have the option to interact with the checkbox
Examples: 
| option |
| Yes    |
| No     |

Scenario Outline: 96964 - Verify the review and submit Gainshare - New Logic for a new CSR
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
And the pricing model of the customer is Gainshare
And I set Gainshare - New Logic to <option>
When I arrive on the Review and Submit page
Then the value associated to the Gainshare - New Logic field will be <option>	
Examples: 
| option |
| Yes    |
| No     |

Scenario Outline: 96964 - Verify the review and submit Gainshare - New Logic for a revised CSR
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And the pricing model of the customer is Gainshare and the CRM Rating Logic flag is <option>
And I am on the Pricing Model page
And the pricing model of the customer is Gainshare
When I arrive on the Review and Submit page
Then the value associated to the Gainshare - New Logic field will be <option>	
Examples: 
| option |
| Yes    |
| No     |

Scenario Outline: 96964 - Verify when I revise a CSR and swap the rating logic then the value displayed on the review and submit page is also updated
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And the pricing model of the customer is Gainshare and the CRM Rating Logic flag is <option>
And I am on the Pricing Model page
When I swap the gainshare new logic checkbox value
And I arrive on the Review and Submit page
Then the value associated to the Gainshare - New Logic field will not be <option>	
Examples: 
| option |
| Yes    |
| No     |
