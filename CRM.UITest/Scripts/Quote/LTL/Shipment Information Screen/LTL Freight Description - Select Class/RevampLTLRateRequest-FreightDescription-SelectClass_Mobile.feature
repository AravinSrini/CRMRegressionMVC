@RevampLTLRateRequestFreightDescriptionSelectClass @22760 @Sprint64
Feature: RevampLTLRateRequest-FreightDescription-SelectClass_Mobile

@Regression 
Scenario Outline: Verify that  Select Class field and drop down values
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And  I click on the LTL tile
	And I click on the Select Class field
	Then I must see the list of classes in the Select Class field should be in numerical order
	And I must see the saved items should display after the list of classes in the Select Class field
	And I must see the list of saved items should be display as Class and Item Description
	And I must see the list of saved items is displayed in the Select Class field should be in numeric, then alphabetical order

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | 
	| S1       | zzzz     | Te$t1234 | 640         | 768          | 

@Regression 
Scenario Outline: Compare the number of saved items displaying in dropdown with database
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And  I click on the LTL tile
	And I click on the Select Class field
	Then number of items displaying for the <Username> in the saved items dropdown should be equal to database

Examples: 
| Scenario | Username | Password | WindowWidth | WindowHeight | 
| S1       | zzzz     | Te$t1234 | 640         | 768          | 

@Regression 
Scenario Outline: Select any saved item and verify the populated data
	Given I log in to the application as user zzzz
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And  I click on the LTL tile
	And I click on the Select Class field
	Then  I select '<saveditem>' from the Select Class field
	And The saved item information of '<Class>', '<Weight>', '<Quantity>', '<QuantityType>' should be auto-filled in the Freight Description section

	Examples: 
| Username | Password | WindowWidth | WindowHeight | saveditem      | Class          | Weight | Quantity | QuantityType |
| zzzz     |  | 640         | 768          | 175 SVAED ITEM | 175 SVAED ITEM | 100    | 50       | Pallets      |