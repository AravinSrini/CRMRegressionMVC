@MaintanceToolsProductProtectionSetting @18311 @Sprint62
Feature: MaintenanceToolsProductProtectionFunctionality
	


@GUI @Acceptance

Scenario Outline:Verify the Product Protection option and the page layout
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I will arrive on the Product Protection settings page
	And   I can see Product Protection section
Examples: 
	| Scenario | username       | password | 
	| S1       | crmSystemAdmin | Te$t1234 |
	


@GUI @Acceptance
Scenario Outline:Verify fields name within Product Protection section
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I will arrive on the Product Protection settings page
	And   I can see Product Protection section
	And   I can see select a station option
	And   I can see select coustomer account serach box
	And   I can see save button
Examples: 
	| Scenario | username       | password | 
	| S1       | crmSystemAdmin | Te$t1234 |  

@GUI @Acceptance
Scenario Outline:Verify validation message if user didn't select station name
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I have clicked on save button without enter station name 
	And   User should be presented with error message
Examples: 
	| Scenario | username       | password | 
	| S1       | crmSystemAdmin | Te$t1234 |  

@GUI @Acceptance
Scenario Outline:Verify validation message if user didn't select customer name
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I have clicked on save button wihout enter customer name 
	And   User should be presented with error message
Examples: 
	| Scenario | username       | password | 
	| S1       | crmSystemAdmin | Te$t1234 |  

 

@GUI @Acceptance @DBVerification
Scenario Outline:Verify displayed station name under station drop down
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	Then   I have clicked on station drop down
	And   Station name displayed in UI should match with database
Examples: 
	| Scenario | username       | password | 
	| S1       | crmSystemAdmin | Te$t1234 |  

@GUI @Acceptance@DB
Scenario Outline:Verify displayed customer name based on associated station name
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	Then   I have clicked on station drop down
	And   I have selected any station <station_name>
	Then   Click on customer account text box list of customer name should be displayed associated to selected station name <station_name>
Examples: 
	| Scenario | username       | password | station_name              |
	| S1       | crmSystemAdmin | Te$t1234 | NewStation12132016        |


@GUI @Acceptance
Scenario Outline:Try to select multiple account for the station
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I have clicked on station drop down
	And   I have selected any station <station_name>
	And   Try to select multiple account for the selected station <account_name>
Examples: 
	| Scenario | username       | password | station_name       | account_name                |
	| S1       | crmSystemAdmin | Te$t1234 | NewStation12132016 | testmanualportal,Autotest_1 |

	@GUI @Acceptance
Scenario Outline:Verify saved customer accounts within grid in which the Product Protection option has been applied
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	Then   I have clicked on station drop down
	Then   I have selected any station <station_name>
	And   Try to select multiple account for the selected station <account_name>
	And   I have clicked on save button and account should be listed as Non default customer<account_name>
Examples: 
	| Scenario | username       | password | station_name       | account_name     |
	| S1       | crmSystemAdmin | Te$t1234 | NewStation12132016 | testmanualportal |

	
@GUI @Acceptance
	Scenario Outline:Verify columns in product protection grid
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   Verify columns in product protection grid <Customer_name>,<Staiton_Id>,<Station_Name>,<Date_Assigned>
Examples: 
	| Scenario | username       | password | Customer_name | Staiton_Id | Station_Name | Date_Assigned |
	| S1       | crmSystemAdmin | Te$t1234 | CUSTOMER NAME | STATION ID | STATION NAME | DATE ASSIGNED | 


@GUI @Acceptance@DB
Scenario Outline:Verify the list of stations and customer accounts in which the Product Protection option has been applied
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option
	Then   Verify account dispalying under Product Protection gird
Examples: 
	| Scenario | username       | password | 
	| S1       | crmSystemAdmin | Te$t1234 |  

@Acceptance @NotAutomated @Ignore
Scenario:Verify rate caculation for propduct protection customer account
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I have clicked on station drop down
	And   I have selected any station 
	And   Try to select single/multiple account for the selected station
	And   I have clicked on save button and account should be listed as Non default customer account
	And   Logout from the application and login into application with exteranl user mapped to above Non default customer account and user must have access quote or shipment module
	And   Click on quote or shipment module and enter valaid data in all the fields and navigate till results page.
	And   Verify Carrier insured rates 
	And   And rates should be displayed as per the Non default INS calculation


