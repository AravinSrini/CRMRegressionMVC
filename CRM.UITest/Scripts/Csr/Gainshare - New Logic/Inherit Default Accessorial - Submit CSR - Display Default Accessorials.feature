@NinjaSprint34 @97682
Feature: 97682 - Inherit Default Accessorial - Submit CSR - Display Default Accessorials

Scenario: 97682 - Verify primary account default accessorials are shown when New Gainshare Logic is selected for new sub account CSR when primary account default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I have selected the station "NT2" that does not have default accessorials
And I selected Sub Account
And I have selected "97682PrimaryWithDefaultAccessorials" for the Primary Customer Account that contains default accessorials
And I have entered valid information on the Account information page after station ID and customer account type
And I enter valid information to the Locations and Contacts page
When I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the default accessorials for the primary account "97682PrimaryWithDefaultAccessorials"

@97682StationAccessorials
Scenario: 97682 - Verify station default accessorials are shown when New Gainshare Logic is selected for new primary account CSR when station default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I have selected the station "NTS" that has default accessorials
And I selected Primary Customer Account
And I have entered valid information on the Account information page after station ID and customer account type
And I enter valid information to the Locations and Contacts page
When I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the station level default accessorials for station "NTS"

@97682StationAccessorials
Scenario: 97682 - Verify station default accessorials are shown when New Gainshare Logic is selected for new sub account CSR when primary account default accessorials are not set and station default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I have selected the station "NTS" that has default accessorials
And I selected Sub Account
And I have selected "97682PrimaryCSRNoAccessorials" for the Primary Customer Account that does not contain default accessorials
And I have entered valid information on the Account information page after station ID and customer account type
And I enter valid information to the Locations and Contacts page
When I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the station level default accessorials for station "NTS"

@97682CorporateAccessorials
Scenario: 97682 - Verify corporate default accessorials are shown when New Gainshare Logic is selected for new primary account CSR when station default accessorials are not set and corporate default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I have selected the station "NT2" that does not have default accessorials
And I selected Primary Customer Account
And I have entered valid information on the Account information page after station ID and customer account type
And I enter valid information to the Locations and Contacts page
When I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the Corporate level default accessorials

@97682CorporateAccessorials
Scenario: 97682 - Verify corporate default accessorials are shown when New Gainshare Logic is selected for new sub account CSR when primary account and station default accessorials are not set and corporate default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a new csr
And I have selected the station "NT2" that does not have default accessorials
And I selected Sub Account
And I have selected "97682PrimaryNoAccessorials" for the Primary Customer Account that does not contain default accessorials
And I have entered valid information on the Account information page after station ID and customer account type
And I enter valid information to the Locations and Contacts page
When I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the Corporate level default accessorials

Scenario: 97682 - Verify customer account default accessorials are shown when New Gainshare Logic is selected for revised CSR when primary account default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for the account name "Customer With Accessorials"
When I am submitting a revised csr and go to the Pricing Model Page
And I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the default accessorials for the primary account "Customer With Accessorials"

Scenario: 97682 - Verify primary account default accessorials are shown when New Gainshare Logic is selected for revised sub account CSR when primary account default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for the account name "97682 Sub Account Of Primary With Accessorials"
When I am submitting a revised csr and go to the Pricing Model Page
And I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the default accessorials for the primary account "Customer With Accessorials"

@97682StationAccessorials
Scenario: 97682 - Verify station default accessorials are shown when New Gainshare Logic is selected for revised primary account CSR when account default accessorials are not set and station default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for the account name "97682PrimaryCSRNoAccessorials"
When I am submitting a revised csr and go to the Pricing Model Page
And I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the station level default accessorials for station "NTS"

@97682StationAccessorials
Scenario: 97682 - Verify station default accessorials are shown when New Gainshare Logic is selected for revised sub account CSR when primary account and account default accessorials are not set and station default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for the account name "97686 Sub Of Primary With Station Accessorials"
When I am submitting a revised csr and go to the Pricing Model Page
And I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the station level default accessorials for station "NTS"

@97682CorporateAccessorials
Scenario: 97682 - Verify corporate default accessorials are shown when New Gainshare Logic is selected for revised primary account CSR when account and station default accessorials are not set and corporate default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for the account name "97682PrimaryNoAccessorials"
When I am submitting a revised csr and go to the Pricing Model Page
And I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the Corporate level default accessorials

@97682CorporateAccessorials
Scenario: 97682 - Verify corporate default accessorials are shown when New Gainshare Logic is selected for revised sub account CSR when account and primary and station default accessorials are not set and corporate default accessorials are set
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
And I am submitting a revised csr for the account name "97682 Sub Account Of Primary Without Accessorials"
When I am submitting a revised csr and go to the Pricing Model Page
And I choose Gainshare from the Select A Pricing Type drop down list
And I check the Gainshare - New Logic checkbox
Then I will see the Corporate level default accessorials