@48287 @NinjaSprint32 @Regression @Shipment
Feature: 48287 - Shipment (LTL) - HazMat required tests 

Scenario Outline: 48287 - Verify HazMat option is auto-selected, HazMat section is expanded and the HazMat fields are required when the HazMat accessorial is selected
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	When I choose the accessorial Hazardous Materials in the Click to add services & accessorials field in from or to <accessorialLocation>
	Then the Hazardous Materials Yes option will be auto-selected in the Freight Description section
	And the Hazardous Materials details section will be expanded
	And all of the fields in the Hazardous Materials details section will be required
	Examples:
	| accessorialLocation |
	| from                |
	| to                  |
	
Scenario Outline: 48287 - Verify the Hazardous Material accessorial is removed, the HazMat section is collapsed, any input data is removed and the fields are not required
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	When I choose the accessorial Hazardous Materials in the Click to add services & accessorials field in from or to <accessorialLocation>
	And the Hazardous Materials Yes option was auto-selected in the Freight Description section
	And I choose the Hazardous Materials No option in the Freight Description section
	Then the hazarous material accessorial will be removed from the accessorial field from either shipping from or to
	And the Hazardous Materials details section will be collapsed
	And any input data in the section will be removed
	And the hazardous material input fields are no longer required
	Examples:
	| accessorialLocation |
	| from                |
	| to                  |

Scenario Outline: 48287 - Verify the Hazardous Material no option is auto-selected, the Hazardous Material section is collapsed, any input data is removed and the fields are not required
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	And I choose the accessorial Hazardous Materials in the Click to add services & accessorials field in from or to <accessorialLocation>
	When I remove the Hazardous Materials accessorial
	Then the Hazardous Materials No option will be auto-selected in the Freight Description section
	And the Hazardous Materials details section will be collapsed
	And any input data in the section will be removed
	And the hazardous material input fields are no longer required
	Examples:
	| accessorialLocation |
	| from                |
	| to                  |

Scenario: 48287 - Verify the Hazardous Material no option is auto-selected, the hazardous material section is collapsed, any input data is removed and the input fields are no longer required when I select a saved item that is flagged as a hazardous material and then remove the accessorial
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	And I choose a saved item that is flagged as a hazardous material
	And the hazardous material accessorial is auto-selected
	When I remove the Hazardous Materials accessorial
	Then the Hazardous Materials No option will be auto-selected in the Freight Description section
	And the Hazardous Materials details section will be collapsed
	And any input data in the section will be removed
	And the hazardous material input fields are no longer required

Scenario: 48287 - Verify the Hazardous Material accessorial is removed, the option to readd it is available, the hazardous material section collapses, any input data is removed and the input fields are not required
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	And I choose a saved item that is flagged as a hazardous material
	And the hazardous material accessorial is auto-selected
	When I choose the Hazardous Materials No option in the Freight Description section
	Then the Hazardous Materials No option will be auto-selected in the Freight Description section
	And I have the option to select the hazardous material accessorial
	And the Hazardous Materials details section will be collapsed
	And any input data in the section will be removed
	And the hazardous material input fields are no longer required

Scenario: 48287 - Verify the hazardous material no option is selected and the hazardous material section is collapsed, any input data is removed and the fields are no longer required when the hazardous material accessorial is removed from a default item that is flagged as hazardous material
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page as a customer who has a default item that is flagged as a hazardous material "HazmatDefaultItemCustomer"
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	When I remove the Hazardous Materials accessorial
	Then the Hazardous Materials No option will be auto-selected in the Freight Description section
	And the Hazardous Materials details section will be collapsed
	And any input data in the section will be removed
	And the hazardous material input fields are no longer required
	
Scenario: 48287 - Verify the hazardous material accessorial is removed, I have the option to select the hazardous material accessorial, the hazardous material section will collapse, any input data is removed and the input fields are no longer required
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page as a customer who has a default item that is flagged as a hazardous material "HazmatDefaultItemCustomer"
	And I have entered all the required information in the Shipping from section - {test}, {test} and {60606}
	And I have entered all the required information in the Shipping To section - {test}, {test} and {90210}
	And I have entered all the required information in the Freight Description section - {50}, {1}, {1}, {1}
	When I choose the Hazardous Materials No option in the Freight Description section
	Then the hazarous material accessorial will be removed from the accessorial field from either shipping from or to
	And I have the option to select the hazardous material accessorial
	And the Hazardous Materials details section will be collapsed
	And any input data in the section will be removed
	And the hazardous material input fields are no longer required