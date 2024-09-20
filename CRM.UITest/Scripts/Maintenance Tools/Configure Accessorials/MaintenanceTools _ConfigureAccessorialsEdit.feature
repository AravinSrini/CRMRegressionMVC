@Sprint85 @48167
Feature: MaintenanceTools _ConfigureAccessorialsEdit
	
	@GUI
	Scenario: 48167 Verify the Elements in Edit Accessorial Modal
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	When I click on the <Edit> icon of any displayed accessorial
	Then the <Edit Accessorial> modal will open
	And I will see <Name> field - required, alpha-numeric, special characters, max length 100 characters
	And I will see <Service Code> field - required, alpha-numeric, max length 20 characters
	And I will see <MG Description> field - required, alpha-numeric, special characters, max length 100 characters
	And I will see Add Another MG Description link
	And I will see <Service Types> required, multi-select as LTL, Truckload, Partial truckload, Intermodal, Domestic Forwarding, International or All
	And I will see options for <Direction>
	And the options are <Shipping From>, <Shipping To>, <Both>, <None>
	And the fields will display the data associated to the accessorial
	And the fields are editable
	And I will see the <Cancel> and <Save> buttons
	
	@GUI
	Scenario: 48167 Verify Additional MG Description textbox appears and its required along with Remove button upon click on the Add Another MG Description link
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I clicked on the <Edit> icon of any displayed accessorial
	And I am in the <Edit Accessorial> modal
	When I click on the Add Another MG Description link
	Then a new <MG Description> text box will appear
	And I will see <Remove> button next to additional MG Description text box
	And the Additional MG Description field is required

	@GUI
	Scenario: 48167 Verify the Edit Accessorial Modal closes upon click on the Cancel button in the Edit Accessorial Modal
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I clicked on the <Edit> icon of any displayed accessorial
	And the <Edit Accessorial> modal opened
	When I Click on the <Cancel> button
	Then the modal will close

	@Functional
	Scenario Outline: 48167 Verify the Configure Accessorials grid will be updated to display the edited accessorial
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I clicked on the <Edit> icon of any displayed accessorial
	And the <Edit Accessorial> modal opened
	And I edited any <field>
	And I have completed all the required fields
	When I click on the Save button in the <Edit Accessorial> Modal
	Then the modal will close
	And the edits will be saved
	And the Configure Accessorials grid will be updated to display the edited accessorial

	Examples: 
	| field         |
	| Name          |
	| ServiceCode   |
	| MGdescription |
	| ServiceType   |
	| Direction     |


	@GUI
	Scenario: 48167 Verify User not able to select any other Service Type, When the Service Type All is selected in the Edit Accessorial Modal
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I clicked on the <Edit> icon of any displayed accessorial
	And I am on the <Edit Accessorial> modal
	When I Select <Service Types> as ALL
	Then I am not allowed to Select any other Service Type

	@GUI
	Scenario: 48167 Verify all other selected Service Type gets removed from the Service Type dropdown upon selecting Service Type as All
	Given that I am a Config Manager user
	And I am on the Maintenance Tools page
	And I Clicked On the <Configure Accessorials> button
	And I am on the Configure Accessorials page
	And I clicked on the <Edit> icon of any displayed accessorial
	And I am on the <Edit Accessorial> modal
	And I Selected any <Service Type> apart from ALL
	When I Select Service Type as All
	Then the Service Type apart from All will be removed from the Service type dropdown
	