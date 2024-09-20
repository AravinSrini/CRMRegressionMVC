@Sprint91 @90821
Feature: 90821- Available Loads - Update Email Modal
	
@GUI @Functional
Scenario:90821- Available Loads - Update Email Modal
Given that I navigate to the CRM Available Loads page
And I click on the email button of any displayed load from the grid TMX008442755 (BOL)
When the email modal is launched
Then the To will display the value from Available Load Email of the associated station details

@GUI @Functional
Scenario:90821- Available Loads - Update Email Modal when To is empty
Given that I navigate to the CRM Available Loads page
And I click on the email button of any displayed load from the grid 50 (BOL)
And corresponding station is not available for load in CRM
When the email modal is launched
Then the To field will be empty
And the Send button is inactive
