@Sprint91 @77436 
Feature: 77436-Available Loads - Remove Phone and Email from Page Header
	
@Regression
Scenario: 77436 - Verify the removal of the Phone and Email from the Page Header of Avaialable loads page
	Given that I navigate to the CRM Available Loads web page
	When the page loads
	Then I will not see the Phone and Email text on the page header
