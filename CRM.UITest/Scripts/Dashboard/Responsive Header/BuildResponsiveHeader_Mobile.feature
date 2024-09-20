@17388 @Sprint59 
Feature: BuildResponsiveHeader_Mobile
	

@GUI
Scenario Outline: Verify the logo is displayed for the user in the application login
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	Then I should able to see the logo is displayed for the user 

	Examples: 
	| Scenario | Username  | Password | WindowWidth | WindowHeight |
	| S1       | ShipEntry | Te$t1234 | 640         | 768          |

@Functional
Scenario Outline: Verify the user drop down is hidden for the mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	Then Verify the user is not able to see the user drop down on top right side of the page

	Examples: 
	| Scenario | Username  | Password | WindowWidth | WindowHeight|
	| S1       | ShipEntry | Te$t1234 | 640         | 768         |
	

@Functional
Scenario Outline: Verify the features/modules are hidden in the left menu
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	Then I should not see Tracking icon in the left navigation menu of MVC5 Landing Page
	

	Examples: 
	| Scenario | Username  | Password | WindowWidth | WindowHeight|
	| S1       | ShipEntry | Te$t1234 | 640         | 768         |


	