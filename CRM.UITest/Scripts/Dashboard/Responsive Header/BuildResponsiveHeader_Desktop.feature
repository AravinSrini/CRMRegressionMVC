@17388 @Sprint59 
Feature: BuildResponsiveHeader_Desktop
	

@GUI
Scenario Outline: Verify the logo is displayed for the user in the application login
	Given I am a DLS user and login into application with valid <Username> and <Password>	
	Then I should able to see the logo is displayed for the user 
	

	Examples: 
	| Scenario | Username        | Password |
	| S1       | nat@extuser.com | Te$t1234 |

	
	
@GUI
Scenario Outline: Verify the Users Full Name is displayed for the user profile drop down
	Given I am a DLS user and login into application with valid <Username> and <Password>
	Then Verify the Users full name '<UserFullName>' is displayed in the user profile drop down

	Examples: 
	| Scenario | Username        | Password | UserFullName |
	| S1       | nat@extuser.com | Te$t1234 | Nat User     |


@Functional @Ignore
Scenario Outline: Verify the Drop down options in the User Profile drop down depending on the privilege ViewUsers or CustomerUsersView or ShipmentBasic
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the User Profile drop down 
	Then Verify the drop down Options lists '<OptionList1>', '<OptionList2>', '<OptionList3>' in the User Profile drop down

	Examples: 
	| Scenario | Username | Password | OptionList1 | OptionList2 | OptionList3 |



@Functional
Scenario Outline: Verify the PO Management Navigation Functionality
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the User Profile drop down 
	Then User should be able too see the <OptionLists> from the User profile drop down
	
	Examples: 
	| Scenario | Username  | Password | OptionLists   |
	| S1       | ShipEntry | Te$t1234 | PO Management |



@Functional @Acceptance
Scenario Outline: Verify the Terms of Use Navigation Functionality
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the User Profile drop down 
	And I select the '<OptionLists>' from the User profile drop down
	Then Terms of Use window pop up should be displayed 
	And Verify the Download PDF link is visible in the window pop up
	And Verify the Close button is visible

	Examples: 
	| Scenario | Username  | Password | OptionLists  |
	| S1       | ShipEntry | Te$t1234 | Terms Of Use |

@Functional @Acceptance
Scenario Outline: Verify the Sign Out Navigation Functionality
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the User Profile drop down
	And I select the '<OptionLists>' from the User profile drop down
	Then Verify user is navigated back to the Login page and able to see the sign In button
	

	Examples: 
	| Scenario | Username  | Password | OptionLists |
	| S1       | ShipEntry | Te$t1234 | Sign Out    |


@Functional
Scenario Outline: Verify the PO Management option is not displayed for the admin users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the User Profile drop down
	Then Verify the PO Management option '<OptionLists>' is not visible to the admin users		

	Examples: 
	| Scenario | Username       | Password | OptionLists   |
	| S1       | crmSystemAdmin | Te$t1234 | PO Management |



	
	





	