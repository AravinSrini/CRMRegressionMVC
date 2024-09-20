@CarrierRateSettings @25381 @Sprint66 
Feature: CarrierRateSettings_AddPricingButtonToMaintenanceTools
	

@GUI
Scenario Outline: Verify the Add Pricing Button in the Maintenance Tools Page
	Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu	
	Then I will have the option '<Pricing>' to configure Master Carrier Rate Settings
	
	
Examples: 
	| Scenario | username       | password | Pricing | 
	| S1       | crmSystemAdmin | Te$t1234 | Pricing |    


@GUI
Scenario Outline: Verify navigation functionality when user clicks on the Pricing button
	Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then User should be navigated to the <MasterCarrierRateSettings> page
Examples: 
	| Scenario | username       | password | MasterCarrierRateSettings   | 
	| S1       | crmSystemAdmin | Te$t1234 | Master Carrier Rate Settings|      