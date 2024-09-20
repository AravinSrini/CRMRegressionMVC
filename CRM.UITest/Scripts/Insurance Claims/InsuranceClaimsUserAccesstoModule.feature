@Sprint78 @39353
Feature: InsuranceClaimsUserAccesstoModule
	

	#---------------------------Verifying the presence of Claims Icon in the Navigation Panel----------------------#
@GUI
	Scenario: 39353 - Verify the presence of Claims icon in the Navigation Panel for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	When I log in to CRM
	Then I will able to see Claims icon in the Navigation Panel

	@GUI
	Scenario: 39353 - Verify the presence of Claims icon in the Navigation Panel for Sales Management User
	Given I am Sales Management User with Access to Claims Module
	When I log in to CRM
	Then I will able to see Claims icon in the Navigation Panel


	#-------------------Verifying the text Claims upon mouse over on CLaims Icon-----------------------------------# 
	@GUI
	Scenario: 39353 - Verify the Verbiage Claims on MouseOver on Claims icon for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	When I MouseOver on the Claims icon
	Then I will be able to read the verbiage Claims 

	@GUI
	Scenario: 39353 - Verify the Verbiage Claims on MouseOver on Claims icon for Sales Management User
	Given I am Sales Management User with Access to Claims Module
	When I MouseOver on the Claims icon
	Then I will be able to read the verbiage Claims


	#-----------------------------------Verifying onclick functionality of Claims Icon------------------------------#
	@GUI
	Scenario: 39353 - Verifying onClick of Claims icon will be navigated to Claims List Page for Shipment Entry User
	Given I am Shipment Entry User with Access to Claims Module
	When I clicked on the Claims icon
	Then I will be navigated to Claims List page

	@GUI
	Scenario: 39353 - Verifying onClick of Claims icon will be navigated to Claims List Page for Sales Management User
	Given I am Sales Management User with Access to Claims Module
	When I clicked on the Claims icon
	Then I will be navigated to Claims List page

