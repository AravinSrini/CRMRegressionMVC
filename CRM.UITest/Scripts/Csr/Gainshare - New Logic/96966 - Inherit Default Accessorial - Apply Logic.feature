@NinjaSprint34 @96966
Feature: 96966 - Inherit Default Accessorial - Apply Logic


@96966NewGainshareLogicYesDeleteCustomer
Scenario: 96966 - CSR Created with Gainshare New Logic has CRM Rating Logic turned On MG
	Given I am a sales, sales management, operations, station owner, pricing config, or system config user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
	And I am submitting a new csr 
	And I am on the Pricing Model page for a new CSR "96966 New Gainshare Logic is Yes MG"
	And I choose Gainshare from the Select A Pricing Type drop down list
	And I check the Gainshare - New Logic checkbox
	And I arrive on the Review and Submit page
	When I Submit and approve the CSR "96966 New Gainshare Logic is Yes MG"
	Then the value of New CRM Rating Logic in the database will be true for customer "96966 New Gainshare Logic is Yes MG"

@96966NewGainshareLogicNoDeleteCustomer
Scenario: 96966 - CSR Created without Gainshare New Logic has CRM Rating Logic turned Off MG
	Given I am a sales, sales management, operations, station owner, pricing config, or system config user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
	And I am submitting a new csr 
	And I am on the Pricing Model page for a new CSR "96966 New Gainshare Logic is No MG"
	And I choose Gainshare from the Select A Pricing Type drop down list
	And I arrive on the Review and Submit page
	When I Submit and approve the CSR "96966 New Gainshare Logic is No MG"
	Then the value of New CRM Rating Logic in the database will be false for customer "96966 New Gainshare Logic is No MG"

@96966TurnOffGainshareLogicForCustomer
Scenario: 96966 - CSR Created With Gainshare New Logic turned Off then Revised to turn Gainshare New Logic On has CRM Rating Logic turned On MG
	Given I am a sales, sales management, operations, station owner, pricing config, or system config user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
	And I am submitting a revised csr for customer "96966 New Gainshare Logic No Revised"
	And I am on the Pricing Model page
	And I set Gainshare - New Logic to Yes
	And I arrive on the Review and Submit page
	When I Submit and approve the CSR "96966 New Gainshare Logic No Revised"
	Then the value of New CRM Rating Logic in the database will be true for customer "96966 New Gainshare Logic No Revised"

@96966TurnOffGainshareLogicForCustomer
Scenario: 96966 - CSR Created With Gainshare New Logic turned Off then Revised to turn Gainshare New Logic On has CRM Rating Logic turned On CSA
	Given I am a sales, sales management, operations, station owner, pricing config, or system config user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
	And I am submitting a revised csr for customer "96966 New Gainshare Logic No Revised CSA"
	And I am on the Pricing Model page
	And I set Gainshare - New Logic to Yes
	And I arrive on the Review and Submit page
	When I Submit and approve the CSR "96966 New Gainshare Logic No Revised CSA" for CSA
	Then the value of New CRM Rating Logic in the database will be true for customer "96966 New Gainshare Logic No Revised CSA"
	
@96966TurnOnGainshareLogicForCustomer
Scenario: 96966 - CSR Created With Gainshare New Logic turned On then Revised to turn Gainshare New Logic Off has CRM Rating Logic turned Off MG
	Given I am a sales, sales management, operations, station owner, pricing config, or system config user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
	And I am submitting a revised csr for customer "96966 New Gainshare Logic Yes Revised"
	And I am on the Pricing Model page
	And I set Gainshare - New Logic to No
	And I arrive on the Review and Submit page
	When I Submit and approve the CSR "96966 New Gainshare Logic Yes Revised"
	Then the value of New CRM Rating Logic in the database will be false for customer "96966 New Gainshare Logic Yes Revised"

@96966TurnOnGainshareLogicForCustomer
Scenario: 96966 - CSR Created With Gainshare New Logic turned On then Revised to turn Gainshare New Logic Off has CRM Rating Logic turned Off CSA
	Given I am a sales, sales management, operations, station owner, pricing config, or system config user "username-CurrentSprintconfigmanager" "password-CurrentSprintconfigmanager"
	And I am submitting a revised csr for customer "96966 New Gainshare Logic Yes Revised CSA"
	And I am on the Pricing Model page
	And I set Gainshare - New Logic to No
	And I arrive on the Review and Submit page
	When I Submit and approve the CSR "96966 New Gainshare Logic Yes Revised CSA" for CSA
	Then the value of New CRM Rating Logic in the database will be false for customer "96966 New Gainshare Logic Yes Revised CSA"