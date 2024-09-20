@48287 @NinjaSprint32 @Regression @Shipment
Feature: 48287 - Shipment (LTL) - Auto Select HazMat As Accessorial When HazMat = Yes 

Scenario: 48287 - Verify the hazardous material accessorial is auto-selected and I have the option to remove the accessorial when I am a user who is associated with a customer with a hazardous material flagged default item
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	When I am on the Add Shipment (LTL) page as a customer who has a default item that is flagged as a hazardous material "HazmatDefaultItemCustomer"
	Then the Hazardous Materials accessorial will be auto-selected in the shipping from section
	And I will have the option to remove the hazardous material accessorial

Scenario: 48287 - Verify the Hazardous Material accessorial is selected when the Hazardous Material yes option is selected
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	When the Hazardous Materials yes option is selected	
	Then the Hazardous Materials accessorial will be auto-selected in the shipping from section

Scenario: 48287 - Verify the Hazardous Material accessorial is auto-selected and I am able to remove it when a saved item that is flagged as hazardous materials is selected 
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	When I choose a saved item that is flagged as a hazardous material
	Then the Hazardous Materials accessorial will be auto-selected in the shipping from section
	And I will have the option to remove the hazardous material accessorial

Scenario: 48287 - Verify the hazardous material accessorial is only selected once when multiple hazardous materials are selected
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	When I add multiple items with at least one flagged as hazardous material
	Then the hazardous material accessorial is added only once

Scenario Outline: 48287 - Verify the first item is flagged as hazardous when there are mulitple items in the shipment and the hazardous material accessorial is selected
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	When I add an addition item to the shipment
	And I choose the accessorial Hazardous Materials in the Click to add services & accessorials field in from or to {accessorialLocation}
	Then the first item is flagged as hazardous material
	And the second item is not flagged as hazardous material
	Examples:
	| accessorialLocation |
	| from                |
	| to                  |

Scenario: 48287 - Verify no items are flagged as hazarous material when the hazarous material accessorial is removed
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	When I add an addition item to the shipment and both items are flagged as hazardous material
	And I remove the Hazardous Materials accessorial
	Then all items are no longer flagged as hazardous material

Scenario: 48287 - Verify the hazarous material accessorial is added when flagging an additional item as hazardous material
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	When I add an addition item to the shipment
	And I flag the additional item as hazardous material
	Then the Hazardous Materials accessorial will be auto-selected in the shipping from section

Scenario: 48287 - Verify the hazardous material accessorial is removed when an additional item is added and is flagged as hazardous material and is then removed
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	And I add an additional item
	And I flag the additional item as hazardous material
	When I remove the hazardous material flagged additional item
	Then the hazarous material accessorial will be removed from the accessorial field from either shipping from or to

Scenario: 48287 - Verify selected accessorials stay the same when the hazardous material accessorial is auto-selected
	Given that I am a shp.entry, shp.entrynorates, sales, sales management, operations, or station owner user "username-CurrentSprintoperations" "password-CurrentSprintoperations"
	And I am on the Add Shipment (LTL) page "NinjaCustomer"
	And I add an accessorial to the shipment	
	When the Hazardous Materials yes option is selected
	Then the chosen accessorials other than hazardous materials remain selected