@Regression @Quote @32100 @Sprint79
Feature: Quote List (MVC5) - Select Station View - Station Users

@Acceptance @GUI
Scenario: 32100_Verify the station selection option in customer list dropdown
Given I am a sales Management, Operations or Station Owner user
And I am on the Quote List page 
When I click on the Customer list drop down arrow
Then I have the option to select a station

@GUI @DBVerification
Scenario: 32100_Verify the Station selection functionality
Given I am a sales Management, Operations or Station Owner user
And I am on the Quote List page 
And I clicked on Customer List dropdown arrow
When I selected a station
Then Quote list page will be refreshed to display submitted rate requests within the past 30days for the customers associated to the selected station
And the Submit Rate Request button is not visible
