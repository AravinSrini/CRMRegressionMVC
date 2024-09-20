@ShipmentListCarrierPro @27212 @Sprint68 
Feature: ShipmentList_CarrierPRO_AllUsers
@GUI @Functional
Scenario: Verify the mouse hover functionality of shipment in shipment list grid 
	Given I am a shp.entry,shp.entrynorates user
	When I click on the Shipment Icon
	And I arrive on shipment list page of externaluser
	And I mouse hover on any displayed pro no in the status column
	Then I should see the pro no and verbiagepop up message of any shipment

@GUI @Functional
Scenario: Verify the mouse hover functionality of shipment in shipment list grid_for stationowner 
	Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I mouse hover on any displayed pro no in the status column
	Then I should see the pro no and verbiagepop up message of any shipment
		   

@GUI @Functional
Scenario: Verify the click functionality of any pro # of shipment in shipment list grid for staionowner
	Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I mouse hover on any displayed pro no in the status column
	And I click on the displayed pro in the status column 
	Then I must navigated to the tacking details page of any selected shipment

        
@GUI
Scenario: Verify the click functionality of any pro # of shipment in shipment list grid for ext user
	Given I am a shp.entry,shp.entrynorates user
	When I click on the Shipment Icon
	And I arrive on shipment list page of externaluser
	And I mouse hover on any displayed pro no in the status column
	And I click on the displayed pro in the status column 
	Then I must navigated to the tacking details page of any selected shipment


	#------------Priority Sprint Tracking Details for Sub-Account---------------

@Functional @48377 @PrioritySprint2
Scenario: 48377_Verify the Tracking Details for the PRO number associated to a shipment of sub account
	Given I am a CRM user associated to a customer with sub-accounts
	And I am on the Shipment List page
	When I click on any PRO link associated to a shipment of a sub-account
	Then I will see the tracking details

@Functional @48377 @PrioritySprint2
Scenario: 48377_Verify the Tracking Details for the reference number(s) associated to a shipment of sub account
	Given I am a CRM user associated to a customer with sub-accounts
	And I am on the Tracking page
	When I track a CRM reference number associated to a shipment of a sub-account
	Then I will see the tracking details