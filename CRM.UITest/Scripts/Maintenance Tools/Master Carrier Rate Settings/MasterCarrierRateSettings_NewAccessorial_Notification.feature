 @Sprint83 @44491
 Feature: MasterCarrierRateSettings_NewAccessorial_Notification
	
	@GUI
	Scenario Outline:44491 Verify Notification Accessorial and its in Alphabetical order in the Accessorial type dropdown list
	Given I am a pricing configuration or config manager user
	And I have selected Customer in Master Carrier Rate settings page
	And I have selected one or more<Carriers>
	And I clicked on the Set Accessorials button
	And the Set Individual Accessorials modal is displayed
	When I click Select Accessorial Type dropdown
	Then I will see Notification as one of the Accessorial in the Select Accessorial Type dropdown list
	And the Notification Accessorial will be displayed alphabetically within the Select Accessorial Type dropdown list
	Examples: 
	| Carriers |
	| Single   |
	| Multiple |
	
	@GUI
	Scenario Outline:44491 Verify Notification Accessorial and its displayed in Alphabetical order in the additional Accessorial type dropdown list 
	Given I am a pricing configuration or config manager user
	And I have selected Customer in Master Carrier Rate settings page
	And I have selected one or more<Carriers>
	And I clicked on the Set Accessorials button
	And the Set Individual Accessorials modal is displayed
	And I clicked on the Add Another Accessorial button
	When I click the added additional Select Accessorial Type dropdown
	Then I will see Notification as one of the Accessorial in the added additional Select Accessorial Type dropdown list
	And the Notification Accessorial will be displayed alphabetically within the added additional Select Accessorial Type dropdown list
	Examples: 
	| Carriers |
	| Single   |
	| Multiple |

	@Functional
	Scenario Outline:44491 Verify the Master Carrier Rate Settings grid displays Notification Accessorial and its values for the selected Carrier
	Given I am a pricing configuration or config manager user
	And I have selected Customer in Master Carrier Rate settings page
	And I have selected one or more<Carriers>
	And I clicked on the Set Accessorials button
	And I selected as Notification Accessorial from the Select Accessorial Type dropdown
	And I entered valid data in Accessorial value field
	When I click on save button
	Then the Notification Accessorial will be displayed as one of the column in the grid
	And the value will be displayed for each carrier selected in the grid
	Examples: 
	| Carriers |
	| Single   |
	| Multiple |

	@GUI
	Scenario Outline:44491 Verify the Notification Accessorial is displayed in the Delete Individual Accessorial Modal Pop-Up
	Given I am a pricing configuration or config manager user
	And I have selected Customer with Notification Accessorial in Master Carrier Rate settings page
	And I have selected one or more<Carriers>
	And I clicked on the Delete Accessorials button
	When the Delete Individual Accessorials modal is displayed
	Then I will see the Notification Accessorial is displayed in the Delete Individual Accessorial Modal Pop-Up
	Examples: 
	| Carriers |
	| Single   |
	| Multiple |

	@Functional
	Scenario Outline:44491 Verify N/A displayed in Notification Accessorial column in the grid for the selected carrier when Notification Accessorial is deleted
	Given I am a pricing configuration or config manager user
	And I have selected Customer with Notification Accessorial in Master Carrier Rate settings page
	And I have selected one or more<Carriers>
	And I clicked on the Delete Accessorials button
	And I have selected Notification Accessorial from the Delete Individual Accessorials modal PopUp
	When I click the Delete button
	Then the value N/A will be displayed for the Notification Accessorial column in the grid for each selected Carrier
	Examples: 
	| Carriers |
	| Single   |
	| Multiple |

	@Functional
	Scenario:44491 Verify Notification Accessorial column will not be displayed in the grid when its deleted for all selected carrier
	Given I am a pricing configuration or config manager user
	And I have selected Customer with Notification Accessorial in Master Carrier Rate settings page
	And I have selected all Carriers
	And I clicked on the Delete Accessorials button
	And I have selected Notification Accessorial from the Delete Individual Accessorials modal PopUp
	When I click the Delete button
	Then the Notification Accessorial column will not be displayed in the grid for all the Carriers