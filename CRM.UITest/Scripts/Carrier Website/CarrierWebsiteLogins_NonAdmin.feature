@CarrierWebsiteLogins_NonAdmin @30607 @Sprint72
Feature: CarrierWebsiteLogins_NonAdmin
	

@GUI
Scenario Outline: 30607_Verify the search functionality on carrier website login page for Non Admin
	Given I am an Operations, Station Owner or System Configuration user <Username>,<Password>
	And I am on the Carrier Website Logins page for Non admin
	When I input <Search_Text> into the search field 
	Then The results of my search <Search_Text> will be updated in the table

Examples: 
| Scenario | Username     | Password | Search_Text |
| S1       | crmOperation | Te$t1234 | Test        |
| S2       | stationowner | Te$t1234 | Test        |
| S3       | admin        | Te$t1234 | Test        |

@GUI
Scenario Outline: 30607_Verify the click functionality of website URL on carrier website login page for Non Admin	
	Given I am an Operations, Station Owner or System Configuration user <Username>,<Password>
	And I am on the Carrier Website Logins page for Non admin
	When I click on website URL
	Then The website will be open in the new tab

Examples: 
| Scenario | Username     | Password |
| S1       | crmOperation | Te$t1234 | 
| S2       | stationowner | Te$t1234 | 
| S3       | admin        | Te$t1234 |


@GUI
Scenario Outline: 30607_Verify the option to copy the login field functionality on carrier website login page for Non Admin
	Given I am an Operations, Station Owner or System Configuration user <Username>,<Password>
	And I am on the Carrier Website Logins page for Non admin
	When I select the option to copy the Login field value to clipboard
	Then The Login value will be copied to my clipboard

Examples: 
| Scenario | Username     | Password |
| S1       | crmOperation | Te$t1234 | 
| S2       | stationowner | Te$t1234 | 
| S3       | admin        | Te$t1234 |


@GUI @DBVerification
Scenario Outline: 30607_Verify the option to copy the Password field functionality on carrier website login page for Non Admin
	Given I am an Operations, Station Owner or System Configuration user <Username>,<Password>
	And I am on the Carrier Website Logins page for Non admin
	When  I selected the option to copy the Password field value to clipboard
	Then Verify the Password will be copied to my clipboard 

Examples: 
| Scenario | Username     | Password |
| S1       | crmOperation | Te$t1234 | 
| S2       | stationowner | Te$t1234 | 
| S3       | admin        | Te$t1234 |







