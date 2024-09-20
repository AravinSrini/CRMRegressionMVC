@Sprint82 @43032 
Feature: Master Carrier Rate Settings - Overlength Accessorial Types
	
@GUI
Scenario: 43032 : Verify the existence of Overlength types and Set Gainshare fields when Overlength is selected as Set Accessorial Type
	Given I am a pricing configuration or config manager user
	And A Gainshare customer has been selected on Master Carrier Rate settings page
	And Set Accessorials button has been clicked by selecting one or more carriers
	When I select Overlength in the Set Accessorial Type field
	Then I should be able to view a list of expected Overlenth types
	And Next to each Overlength types there should be a Set Gainshare field
	And Each Set Gainshare field should be blank
	And I should see a message in red font "All Overlength fields required" 

@GUI @Acceptance
Scenario: 43032 : Verify validations of Set Gainshare fields when Overlength is selected as Set Accessorial Type
	Given I am a pricing configuration or config manager user
	And A Gainshare customer has been selected on Master Carrier Rate settings page
	And Set Accessorials button has been clicked by selecting one or more carriers
	When I select Overlength in the Set Accessorial Type field
	Then I should be able to pass values to Set Gainshare fields
	And I should be able to enter a whole value up to 3 numbers
	And I should be able to enter a decimal after the whole number
	And I should be able to enter upto 2 decimal places
	And CRM will add a zero to the value when I enter only 1 value after the decimal place
	And I should be able to enter zero as a value
	And I should not be able to enter a value between 0 and 1 
	And I should not be able to enter a negative value
	And CRM will recognize the value as currency

@GUI @Functional
Scenario: 43032 : Verify the behaviour of Set Gainshare fields and error message displayed when no values are passed to Gainshare fields
	Given I am a pricing configuration or config manager user
	And A Gainshare customer has been selected on Master Carrier Rate settings page
	And Set Accessorials button has been clicked by selecting one or more carriers
	And Overlength has been selected as Set Accessorial Type field
	When I Click on Save button without passing values to Overlength types fields
	Then I should see a message stating - Please complete all required fields
	And Each field should get highlighted in red
	And The focus should be to the first field that is missing data.

@Functional
Scenario: 43032 : Verify the functionality of Save button by entering valid data to Overlength types fields
	Given I am a pricing configuration or config manager user
	And A Gainshare customer has been selected on Master Carrier Rate settings page
	And Set Accessorials button has been clicked by selecting one or more carriers
	And Overlength has been selected as Set Accessorial Type field
	And Valid data has been passed to Overlength type fields
	When I click on save button 
	Then The value for each Overlength Type will be saved.

@GUI
Scenario: 43032 : Verify display of Overlength accessorial type and values when selected customer has individual accessorial Overlength associated at the customer level
	Given I am a pricing configuration or config manager user
	And A Gainshare customer has been selected on Master Carrier Rate settings page.
	When The selected customer has individual accessorial Overlength associated at the customer level
	Then I should see each overlength accessorial type displayed for each carrier
	And I should see each overlength accessorial type value displayed for each carrier
	
@GUI
Scenario: 43032 : Verify display of Overlength accessorial type and values when selected customer has individual accessorial Overlength associated at the carrier level
	Given I am a pricing configuration or config manager user
	And A Gainshare customer has been selected on Master Carrier Rate settings page	
	When The selected customer has individual accessorial Overlength associated at the carrier level
	Then I should see each overlength accessorial type displayed for each carrier
	And I should see each overlength accessorial type value displayed for each carrier.
	
@Functional
Scenario: 43032 : Verify delete button functionality when the selected carriers have accessorial Overlength associated
	Given I am a pricing configuration or config manager user
	And A Gainshare customer has been selected on Master Carrier Rate settings page	
	And One or more Carriers has been selected which has accessorial Overlength associated
	And Overlength accessorial has been selected from the list of Delete Individual Accessorials modal by clicking on Delete Accessorials button
	When I click on Delete button 
	Then All Overlength accessorial types associated to the customer should be deleted.




