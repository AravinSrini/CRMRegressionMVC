@NinjaSprint34 @97686 @Regression
Feature: 97686 - Inherit Default Accessorial - Submit CSR - Edit or Delete Default Accessorials

@97686StationAccessorials	
Scenario: 97686 - Verify that when submitting a new csr the edited default accessorial will be set at the customer level
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr for Primary account
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
And one or more default accessorials are displayed
And I click the Set Individual Accessorials button
And I edited an existing default accessorial in the Set Individual Accessorials modal
And I click the Save button
When I fill in valid Gainshare percentage information
Then the default accessorials will be set at the customer level

@97686StationAccessorials
Scenario: 97686 - Verify that when submitting a new csr the added accessorial will be set at the customer level
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr for Primary account
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
And one or more default accessorials are displayed
And I click the Set Individual Accessorials button
And I add an accessorial in the Set Individual Accessorials modal
And I click the Save button
When I fill in valid Gainshare percentage information
Then the default accessorials will be set at the customer level

@97686StationAccessorials
Scenario: 97686 - Verify that when revising a csr the edited default accessorial will be set at the customer level
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for a Primary account
And I am on the Pricing Model page
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
And one or more default accessorials are displayed
And I fill in valid Gainshare percentage information
And I click the Set Individual Accessorials button
And I edited an existing default accessorial in the Set Individual Accessorials modal
When I click the Save button
Then the default accessorials will be set at the customer level

@97686StationAccessorials
Scenario: 97686 - Verify that when revising a csr the added accessorial will be set at the customer level
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for a Primary account
And I am on the Pricing Model page
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
And one or more default accessorials are displayed
And I fill in valid Gainshare percentage information
And I click the Set Individual Accessorials button
And I add an accessorial in the Set Individual Accessorials modal
When I click the Save button
Then the added default accessorial will be set at the customer level

@97686StationAccessorials
Scenario: 97686 - Verify that when submitting a new csr and an existing default carrier accessorial was edited then the default carrier accessorial is set at the customer level
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr for Primary account
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
And one or more default carrier accessorials are displayed and populated with the correct information
And I fill in valid Gainshare percentage information
And I clicked on the Set Individual Accessorials button of a carrier with carrier specific pricing
And I edited an existing default carrier accessorial in the Set Individual Accessorials modal
When I click the Save button
Then the edited default carrier accessorial will be set at the customer level

@97686StationAccessorials
Scenario: 97686 - Verify that when revising a csr and an existing default carrier accessorial was edited then the default carrier accessorial is set at the customer level
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for a Primary account
And I am on the Pricing Model page
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
And one or more default carrier accessorials are displayed and populated with the correct information
And I fill in valid Gainshare percentage information
And I clicked on the Set Individual Accessorials button of a carrier with carrier specific pricing
And I edited an existing default carrier accessorial in the Set Individual Accessorials modal
When I click the Save button
Then the edited default carrier accessorial will be set at the customer level

@97686StationAccessorials
Scenario: 97686 - Verify that when revising a csr for a primary account when there is a default carrier accessorial set at th e station level then the carrier specific gainshare pricing section is expanded
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And the default carrier accessorial was set at the Station level
And I choose a Primary account as the account type
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
When one or more default carrier accessorials are displayed and populated with the correct information
Then the Carrier-Specific Gainshare Pricing section of the carrier with a default accessorial will be expanded

@97686CorporateAccessorials
Scenario: 97686 - Verify that when submitting a new csr for a primary account when there is a default carrier accessorial set at the corporate level then the carrier specific gainshare pricing section is expanded
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And the default carrier accessorial was set at the Corporate level
And I choose a Primary account as the account type
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
When one or more default carrier accessorials are displayed and populated with the correct information
Then the Carrier-Specific Gainshare Pricing section of the carrier with a default accessorial will be expanded

Scenario: 97686 - Verify that when submitting for a sub-account a new csr when there is a default carrier accessorial set at the primary level then the carrier specific gainshare pricing section is expanded
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And the default carrier accessorial was set at the Primary level
And I choose a Sub-account as the account type for customer "97682PrimaryWithDefaultAccessorials"
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
When one or more default carrier accessorials are displayed and populated with the correct information
Then the Carrier-Specific Gainshare Pricing section of the carrier with a default accessorial will be expanded

@97686StationAccessorials
Scenario: 97686 - Verify that when submitting for a sub-account a new csr when there is a default carrier accessorial set at the station level then the carrier specific gainshare pricing section is expanded
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And the default carrier accessorial was set at the Station level
And I choose a Sub-account as the account type
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
When one or more default carrier accessorials are displayed and populated with the correct information
Then the Carrier-Specific Gainshare Pricing section of the carrier with a default accessorial will be expanded

@97686CorporateAccessorials
Scenario: 97686 - Verify that when submitting for a sub-account a new csr when there is a default carrier accessorial set at the corporate level then the carrier specific gainshare pricing section is expanded
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And the default carrier accessorial was set at the Corporate level
And I choose a Sub-account as the account type for customer "97686 primary corporate level"
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
When one or more default carrier accessorials are displayed and populated with the correct information
Then the Carrier-Specific Gainshare Pricing section of the carrier with a default accessorial will be expanded

@97686StationAccessorials
Scenario: 97686 - Verify that when submitting a new csr the non-edited default accessorial will not be set at the customer level
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr for Primary account
And I am on the Pricing Model page for the CSR
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
And one or more default accessorials are displayed
When I fill in valid Gainshare percentage information
Then the default accessorials will not be set at the customer level

@97686StationAccessorials
Scenario: 97686 - Verify that when revising a csr the non-edited default accessorial will not be set at the customer level
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for a Primary account
And I am on the Pricing Model page
And my Pricing Model Type is Gainshare
And I checked the Gainshare - New Logic box
And one or more default accessorials are displayed
When I fill in valid Gainshare percentage information
Then the default accessorials will not be set at the customer level