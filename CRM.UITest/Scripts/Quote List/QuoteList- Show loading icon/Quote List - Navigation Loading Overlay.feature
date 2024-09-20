@Sprint93 @111075
Feature:Quote List - Navigation Loading Overlay

Scenario Outline:111075_Verify the loading overlay in shiplist screen while page is loading
Given I am a user and login into application with valid <Username> and <Password>,
When I click the Quote List Icon on the navigation menu
Then I will see a loading overlay while the page is loading in quote list screen

Examples:
| Username                         | Password                         |
| username-CurrentSprintOperations | password-CurrentSprintOperations |
| username-CurrentSprintSales      | password-CurrentSprintSales      |
| username-CurrentSprintshpentry   | password-CurrentSprintshpentry   | 

Scenario Outline:111075_Verify the loading overlay in shiplist screen when page is loaded
Given I am a user and login into application with valid <Username> and <Password>,
When I click the Quote List Icon on the navigation menu
And the quote list page is loaded
Then I will no longer see the loading overlay in quote list screen

Examples:
| Username                         | Password                         |
| username-CurrentSprintOperations | password-CurrentSprintOperations |
| username-CurrentSprintSales      | password-CurrentSprintSales      |
| username-CurrentSprintshpentry   | password-CurrentSprintshpentry   |