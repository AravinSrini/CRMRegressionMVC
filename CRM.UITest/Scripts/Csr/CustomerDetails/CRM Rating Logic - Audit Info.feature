@NinjaSprint34 @97776 @Regression
Feature: CRM Rating Logic - Audit Info

Scenario: Verify correct audit information shown when Apply CRM Rating Logic box is checked and saved
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I navigate to the Customer Details screen for the customer "97776 Gainshare Logic Off"
	And I open the Edit Gainshare Modal for the customer
	When I Set Apply CRM Rating Logic to "Yes"
	And save the edited Gainshare information
	Then the correct audit information will be saved in the database for "97776 Gainshare Logic Off" with station "ZZZ - Web Services Test" and created by name "currentsprint.configmanager@dls-ww.com" and new logic true and old logic false

Scenario: Verify correct audit information shown when Apply CRM Rating Logic box is unchecked and saved
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I navigate to the Customer Details screen for the customer "97776 Gainshare Logic On"
	And I open the Edit Gainshare Modal for the customer
	When I Set Apply CRM Rating Logic to "No"
	And save the edited Gainshare information
	Then the correct audit information will be saved in the database for "97776 Gainshare Logic On" with station "ZZZ - Web Services Test" and created by name "currentsprint.configmanager@dls-ww.com" and new logic false and old logic true

Scenario: Verify correct audit information shown when a revised CSR is in Completed status and switches Rating logic from on to off
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I am submitting a revised csr for the customer "97776 Revised Gainshare Logic On"
	And I am on the Pricing Model page
	And the pricing model of the customer is Gainshare
	When I set Gainshare - New Logic to No
	And I navigate to Review And Submit CSR screen
	And I Submit and approve the CSR "97776 Revised Gainshare Logic On"
	Then the correct audit information will be saved in the database for "97776 Revised Gainshare Logic On" with station "ZZZ - Web Services Test" and created by name "currentsprint.configmanager@dls-ww.com" and new logic false and old logic true

Scenario: Verify correct audit information shown when a revised CSR is in Completed status and switches Rating logic from off to on
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I am submitting a revised csr for the customer "97776 Revised Gainshare Logic Off"
	And I am on the Pricing Model page
	And the pricing model of the customer is Gainshare
	When I set Gainshare - New Logic to Yes
	And I navigate to Review And Submit CSR screen
	And I Submit and approve the CSR "97776 Revised Gainshare Logic Off"
	Then the correct audit information will be saved in the database for "97776 Revised Gainshare Logic Off" with station "ZZZ - Web Services Test" and created by name "currentsprint.configmanager@dls-ww.com" and new logic true and old logic false

Scenario: Verify correct audit information shown when a revised CSA CSR is in Completed Status and switches Rating logic from on to off
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I am submitting a revised csr for the customer "97776 Revised CSA Gainshare Logic On"
	And I am on the Pricing Model page
	And the pricing model of the customer is Gainshare
	When I set Gainshare - New Logic to No
	And I navigate to Review And Submit CSR screen
	And I Submit and approve the CSR "97776 Revised CSA Gainshare Logic On" for CSA
	Then the correct audit information will be saved in the database for "97776 Revised CSA Gainshare Logic On" with station "ZZZ - Web Services Test" and created by name "currentsprint.configmanager@dls-ww.com" and new logic false and old logic true

Scenario: Verify correct audit information shown when a revised CSA CSR is in Completed status and switches Rating logic from off to on
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I am submitting a revised csr for the customer "97776 Revised CSA Gainshare Logic Off"
	And I am on the Pricing Model page
	And the pricing model of the customer is Gainshare
	When I set Gainshare - New Logic to Yes
	And I navigate to Review And Submit CSR screen
	And I Submit and approve the CSR "97776 Revised CSA Gainshare Logic Off" for CSA
	Then the correct audit information will be saved in the database for "97776 Revised CSA Gainshare Logic Off" with station "ZZZ - Web Services Test" and created by name "currentsprint.configmanager@dls-ww.com" and new logic true and old logic false

Scenario: Verify no audit information shown when a revised CSR is in Completed status and Rating logic is not changed
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I am submitting a revised csr for the customer "97776 Revised Gainshare Logic On"
	And I am on the Pricing Model page
	When I change the pricing percentage to "30"
	And I navigate to Review And Submit CSR screen
	And I Submit and approve the CSR "97776 Revised Gainshare Logic On"
	Then no audit information will be saved in the database for "97776 Revised Gainshare Logic On"

Scenario: Verify no audit information shown when a revised CSA CSR is in Completed status and Rating logic is not changed
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I am submitting a revised csr for the customer "97776 Revised CSA Gainshare Logic On"
	And I am on the Pricing Model page
	When I change the pricing percentage to "30"
	And I navigate to Review And Submit CSR screen
	And I Submit and approve the CSR "97776 Revised CSA Gainshare Logic On" for CSA
	Then no audit information will be saved in the database for "97776 Revised CSA Gainshare Logic On"

Scenario: Verify no audit information shown when Apply CRM Rating Logic box is not changed
	Given I am a user who have access to Account Management module 'username-CurrentSprintconfigmanager' , 'password-CurrentSprintconfigmanager'
	And I navigate to the Customer Details screen for the customer "97776 Gainshare Logic Off"
	And I open the Edit Gainshare Modal for the customer
	When I changed minimum about to "20"
	And save the edited Gainshare information
	Then no audit information will be saved in the database for "97776 Gainshare Logic Off"