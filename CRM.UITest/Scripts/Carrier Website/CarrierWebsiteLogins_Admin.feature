@CarrierWebsiteLogins_Admin @30606  @Sprint72
Feature: CarrierWebsiteLogins_Admin


@GUI
Scenario Outline: 30606_Verify the search functionality on carrier website login page
	Given I am a System Admin and Pricing Configuration user <Username>, <Password>
	And I am on the Carrier Website Logins page 
	When I input <Search_Text> into the search field 
	Then The results of my search <Search_Text> will be updated in the table

Examples: 
| Scenario | Username    | Password | Search_Text |
| S1       | systemadmin | Te$t1234 | Test        |
| S2       | jtest       | Te$t1234 | Test        |
   

@GUI
Scenario Outline: 30606_Verify the click functionality of website URL on carrier website login page
	Given I am a System Admin and Pricing Configuration user <Username>, <Password>
	And I am on the Carrier Website Logins page
	When I click on website URL
	Then The website will be open in the new tab

Examples: 
| Scenario | Username    | Password | 
| S1       | systemadmin | Te$t1234 |
| S2       | jtest       | Te$t1234 |  


@GUI
Scenario Outline: 30606_Verify the option to copy the Website link  functionality on carrier website login page
	Given I am a System Admin and Pricing Configuration user <Username>, <Password>
	And I am on the Carrier Website Logins page
	When I select the option to copy the Website field value to clipboard
	Then The Website value will be copied to my clipboard

Examples: 
| Scenario | Username    | Password |
| S1       | systemadmin | Te$t1234 | 
| S2       | jtest       | Te$t1234 |

@GUI
Scenario Outline: 30606_Verify the option to copy the login field functionality on carrier website login page
	Given I am a System Admin or Pricing Configuration user - <Username>, <Password>
	And I am on the Carrier Website Logins page
	When I select the option to copy the Login field value to clipboard
	Then The Login value will be copied to my clipboard

Examples: 
| Scenario | Username    | Password | 
| S1       | systemadmin | Te$t1234 |
| S2       | jtest       | Te$t1234 |  

@GUI
Scenario Outline: 30606_Verify the option to copy the Password field  functionality on carrier website login page
	Given I am a System Admin and Pricing Configuration user <Username>, <Password>
	And I am on the Carrier Website Logins page
	When  I select the option to copy the Password field value to clipboard
	Then The Password will be copied to my clipboard

Examples: 
| Scenario | Username    | Password | 
| S1       | systemadmin | Te$t1234 | 
| S2       | jtest       | Te$t1234 | 



@GUI
Scenario Outline: 30606_Verify the functionality of edit the Password field on carrier website login page
	Given I am a System Admin and Pricing Configuration user <Username>, <Password>
	And I am on the Carrier Website Logins page
	When I select the option to edit the Password field value
	Then I will be taken to the Carrier Website Logins <EditPassword> modal

Examples: 
| Scenario | Username    | Password | EditPassword  |
| S1       | systemadmin | Te$t1234 | Edit Password |
| S2       | jtest       | Te$t1234 | Edit Password |





