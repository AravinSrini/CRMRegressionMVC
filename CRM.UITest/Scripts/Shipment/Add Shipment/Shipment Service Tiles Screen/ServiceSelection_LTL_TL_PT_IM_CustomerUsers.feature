@ServiceSelection_LTL_TL_PT_IM_CustomerUsers @29392 @Sprint69 
Feature: ServiceSelection_LTL_TL_PT_IM_CustomerUsers
@GUI @Regression
Scenario Outline: Verify the Click functionality of LTL service tile for Ship Entry and Ship EntryNoRates user
    Given I am a shp.entry,shp.entrynorates user
	And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button
	When I select the tiles <service> 
	Then I must be arrive on the add shipment for the selected service <service>
	Examples: 
            | service   |
            | LTL       |
            | Truckload |
            | Partial Truckload|
            | Intermodal |                          
                                







	
