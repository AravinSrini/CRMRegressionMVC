@50765 @NinjaSprint30 @Regression
Feature: Add Shipment (LTL) - Dim Fields Required When Value Entered

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Length
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "1", "", ""
	Then the Freight Length, Width, and Height fields will be required
	
Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Width
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "", "1", ""
	Then the Freight Length, Width, and Height fields will be required

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Height
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "", "", "1"
	Then the Freight Length, Width, and Height fields will be required

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Length and Width
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "1", "1", ""
	Then the Freight Length, Width, and Height fields will be required

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Length and Height
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "1", "", "1"
	Then the Freight Length, Width, and Height fields will be required

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Width and Height
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "", "1", "1"
	Then the Freight Length, Width, and Height fields will be required

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Length, Width, and Height
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "1", "1", "1"
	Then the Freight Length, Width, and Height fields will be required

Scenario: 50765 - Verify that the dimension fields are not required when a value is entered for Length and then cleared
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "1", "1", "1"
	And I click Clear Item for the freight item
	Then the Freight Length, Width, and Height fields will not be required

Scenario: 50765 - Verify that the dimension fields are not required when a value is entered for Length and then removed
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "1", "", ""
	And I remove the freight value for Length
	Then the Freight Length, Width, and Height fields will not be required

Scenario: 50765 - Verify if the dimension fields are not required
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields "", "", ""
	Then the Freight Length, Width, and Height fields will not be required

Scenario: 50765 - Verify that the dimension fields are not required when the Overlength accessorial value is selected in the Shipping From field and then un-selected
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	When I enter the following values in the Freight length width and height fields "", "", ""
	And I have selected Overlength as a freight accessorial in the Shipping From field
	And I have un-selected Overlength as a freight accessorial in the Shipping From field
	Then the Freight Length, Width, and Height fields will not be required

Scenario: 50765 - Verify that the dimension fields are required when the Overlength accessorial value is selected in the Shipping From field and then un-selected and a value is entered for length
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	When I enter the following values in the Freight length width and height fields "1", "", ""
	And I have selected Overlength as a freight accessorial in the Shipping From field
	And I have un-selected Overlength as a freight accessorial in the Shipping From field
	Then the Freight Length, Width, and Height fields will be required

#ADDITIONAL ITEMS SECTION

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Length for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "1", "", ""
	Then the Freight Length, Width, and Height fields will be required for the additional item
	
Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Width for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "", "1", ""
	Then the Freight Length, Width, and Height fields will be required for the additional item

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Height for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "", "", "1"
	Then the Freight Length, Width, and Height fields will be required for the additional item

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Length and Width for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "1", "1", ""
	Then the Freight Length, Width, and Height fields will be required for the additional item

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Length and Height for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "1", "", "1"
	Then the Freight Length, Width, and Height fields will be required for the additional item

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Width and Height for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "", "1", "1"
	Then the Freight Length, Width, and Height fields will be required for the additional item

Scenario: 50765 - Verify that the dimension fields are required when a value is entered for Length, Width, and Height for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "1", "1", "1"
	Then the Freight Length, Width, and Height fields will be required for the additional item

Scenario: 50765 - Verify that the dimension fields are not required when a value is entered for Length and then cleared for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "1", "1", "1"
	And I click Clear Item for the freight additional item
	Then the Freight Length, Width, and Height fields will not be required for the additional item

Scenario: 50765 - Verify that the dimension fields are not required when a value is entered for Length and then removed for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "1", "", ""
	And I remove the value for freight Length for the additional item
	Then the Freight Length, Width, and Height fields will not be required for the additional item

Scenario: 50765 - Verify if the dimension fields are not required for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	And I have NOT selected Overlength as a freight accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the Freight length width and height fields for an additional item "", "", ""
	Then the Freight Length, Width, and Height fields will not be required for the additional item

Scenario: 50765 - Verify that the dimension fields are not required when the Overlength accessorial value is selected in the Shipping From field and then un-selected for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	When I enter the following values in the Freight length width and height fields for an additional item "", "", ""
	And I have selected Overlength as a freight accessorial in the Shipping From field
	And I have un-selected Overlength as a freight accessorial in the Shipping From field
	Then the Freight Length, Width, and Height fields will not be required for the additional item

Scenario: 50765 - Verify that the dimension fields are required when the Overlength accessorial value is selected in the Shipping From field and then un-selected and a value is entered for length for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on Add Shipment (LTL) page
	When I enter the following values in the Freight length width and height fields for an additional item "1", "", ""
	And I have selected Overlength as a freight accessorial in the Shipping From field
	And I have un-selected Overlength as a freight accessorial in the Shipping From field
	Then the Freight Length, Width, and Height fields will be required for the additional item
