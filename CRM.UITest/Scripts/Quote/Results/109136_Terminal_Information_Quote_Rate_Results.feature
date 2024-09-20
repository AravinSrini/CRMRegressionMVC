@Sprint94 @109136 @0007Arav
Feature: 109136_Terminal_Information_Quote_Rate_Results

Scenario Outline: 109136_Verify Terminal Info link in Quote result (LTL) Page
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Create Quote for LTL page <user>
	And I have entered all required information
	And I have clicked on the View Quote Results button
	When I arrive on the Quote Results (LTL) page
	Then I will see a link on each carrier rate labeled 'Terminal Info'

Examples: 
	| user     | Username                         | Password                         |
	| Sales    | username-CurrentSprintSales      | password-CurrentSprintSales      |
	| External | username-CurrentSprintshpentry   | password-CurrentSprintshpentry   |
	| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations |

Scenario Outline: 109136_Verify Modal will close for Terminal Information modal when click on close button 
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Create Quote for LTL page <user>
	And I have entered all required information
	And I have clicked on the View Quote Results button
	And I clicked on the Terminal Info Link for a specific carrier rate,
	And I am in the Terminal Information modal,
	When I click on the Close button,
	Then the Terminal modal will close

Examples: 
	| user     | Username                         | Password                         |
	| Sales    | username-CurrentSprintSales      | password-CurrentSprintSales      |
	| External | username-CurrentSprintshpentry   | password-CurrentSprintshpentry   |
	| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations |


Scenario Outline: 109136_Verify terminal information in modal pop up
	Given I am a user and login into application with valid <Username> and <Password>,
	And I am on the Create Quote for LTL page <user>
	And I have entered all required information
	And I have clicked on the View Quote Results button
	When I click on the Terminal Info Link for a specific carrier rate
	Then a popup modal is launched that displays the terminal information for selected carrier record
	And I will see a Close button.

Examples: 
	| user     | Username                         | Password                         |
	| Sales    | username-CurrentSprintSales      | password-CurrentSprintSales      |
	| External | username-CurrentSprintshpentry   | password-CurrentSprintshpentry   |
	| Internal | username-CurrentSprintOperations | password-CurrentSprintOperations |

