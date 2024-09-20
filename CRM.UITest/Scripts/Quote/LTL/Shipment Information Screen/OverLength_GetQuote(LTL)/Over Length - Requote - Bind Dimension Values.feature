@Sprint81
Feature: Over Length - Requote - Bind Dimension Values
	
@Regression 
Scenario: 40958 - Requote: Verify if the dimension fields are binding and editable on Get Quote (LTL) page
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or a station owner user
	And I am on Quote List page
	And The Quote details section of an expired LTL quote contains the following values - Length, Width, height and Dimension type
	When I click on Requote button
	Then CRM should bind the dimension values of the original quote to the re-quote on Get Quote (LTL) page
	And I have the option to edit the values.

