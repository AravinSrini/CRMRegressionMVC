@43096 @Sprint83
Feature: Insurance Claims - Claim Details - Save Claim Details Button
	
@GUI
Scenario: 43096_Verify Save Claim Details button in Claim Details Page
	Given I am Claims Specialist User
	When I am on Claim Details page
	Then I will see a Save Claim Details button

@GUI
Scenario: 43096_Verify Changes Not Saved Modal when user navigated away from claims details page without saving
	Given I am Claims Specialist User
	And I am on Claim Details page
	And I have updated the fields of Claim Header, FTL-Specific Fields, Forwarding-Specific Fields 
	And I have updated the fields of Shipper, DLSW OS&D Actions, Insurance Info, Consignee, Carrier OS&D Actions, Key Dates, Remarks
	And I have updated the fields of Products Claimed, Freight Calculations, Comments
	When I click on Any CRM module
	Then Changes Not Saved modal will display with message	
	And Leave Page Without Saving, Return to Claim Details buttons will be displayed in modal pop up

@GUI
Scenario: 43096_Verify the user navigated away from Claim Details Page when clicked on Leave Page Without Saving button in modal
	Given I am Claims Specialist User
	And I am on Claim Details page
	And I have edited changes 
	And I click on any CRM module 
	When I click on Leave Page Without Saving button on Changes Not Saved modal
	Then the modal will be closed
	And I will be navigated away from Claim Details Page

@GUI
Scenario: 43096_Verify the user stays in Claim Details Page when clicked on Return to Claim Details button in modal
	Given I am Claims Specialist User
	And I am on Claim Details page
	And I have edited changes 
	And I click on any CRM module 	
	When I Click on Return to Claim Details button on Changes Not Saved modal 
	Then the model will be closed
	And I will be on Claim Details Page itself