@Sprint85 @46272
Feature: MaintenanceTools_ConfigureAccessorials_Add
	
	@GUI
	Scenario: 46272 Verify the Elements in the Add Accessorial Modal
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	When I Click on the <Add Accessorial> button
	Then I will be presented with the <Add Accessorial> modal
	And the modal will have <Name> field - required, alpha-numeric, special characters, max length 100 characters
	And the modal will have <Service Code> field - required, alpha-numeric, max length 20 characters
	And the modal will have <MG Description> field - required, alpha-numeric, special characters, max length 100 characters
	And the modal will have <Add Another MG Description> link
	And the modal will have <Service Types> required, multi-select as All, LTL, Truckload, Partial Truckload, Intermodal, Domestic Forwarding, International
	And the modal will have <Apply Accessorial To> required, options
	And the modal will have Cancel button
	And the modal will have Save button
	And I will see options for <Direction>
	And the options are <Shipping From>, <Shipping To>, <Both>, <None>
	And none of the options have been default selected
	And I am required to select an option

	@GUI
	Scenario: 46272 Verify Additional MG Description textbox appears upon click on the Add Another MG Description link
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I Clicked on the <Add Accessorial> button
	And I am in the <Add Accessorial> modal
	When I click on the <Add Another MG Description> link
	Then a new <MG Description> text box will appear
	And I will see <Remove> button next to additional MG Description text box
	And the additional MG Description field is required

	@GUI
	Scenario: 46272 Verify the Remove button functionality for the Additional MG Description textbox
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I Clicked on the <Add Accessorial> button
	And I am in the <Add Accessorial> modal
	And I clicked on the <Add Another MG Description> link
	When I Click on the <Remove> button
	Then the additional MG Description field will be removed
	And the <Remove> button will be removed

	@GUI
	Scenario: 46272 Verify the Add Accessorial modal closes upon click on the Cancel button in the Add Accessorial Modal
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I Clicked on the <Add Accessorial> button
	And I am in the <Add Accessorial> modal
	When I Click on the <Cancel> button
	Then the modal will close

	@Functional
	Scenario: 46272 Verify the Newly created Configure Accessorial is displayed in Grid
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I Clicked on the <Add Accessorial> button
	And I am in the <Add Accessorial> modal
	And I entered all the required information
	When I Click on the <Save> button
	Then the modal will close
	And the data will be saved
	And the Configure Accessorials grid will be updated to display the new accessorial

	@GUI
	Scenario: 46272 Verify User not able to select any other Service Type, When the Service Type All is selected 
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I Clicked on the <Add Accessorial> button
	And I am in the <Add Accessorial> modal
	When I Select <Service Types> as ALL
	Then I am not allowed to Select any other Service Type
		
	@GUI
	Scenario: 46272 Verify selected Service Type gets removed from the Service Type dropdown upon selecting Service Type as All in the Add Accessorial Modal
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I Clicked on the <Add Accessorial> button
	And I am in the <Add Accessorial> modal
	And I Selected any <Service Type> apart from ALL
	When I Select Service Type as All
	Then the Service Type apart from All will be removed from the Service type dropdown
