@50763 @NinjaSprint29 @Regression
Feature: Get Quote (LTL) - Dim Fields Required When Value Entered
	

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Length
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "1", "", ""
	Then the Length, Width, and Height fields will be required
	
Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Width
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "", "1", ""
	Then the Length, Width, and Height fields will be required

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Height
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "", "", "1"
	Then the Length, Width, and Height fields will be required

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Length and Width
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "1", "1", ""
	Then the Length, Width, and Height fields will be required

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Length and Height
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "1", "", "1"
	Then the Length, Width, and Height fields will be required

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Width and Height
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "", "1", "1"
	Then the Length, Width, and Height fields will be required

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Length, Width, and Height
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "1", "1", "1"
	Then the Length, Width, and Height fields will be required

Scenario: 50763 - Verify that the dimension fields are not required when a value is entered for Length and then cleared
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "1", "1", "1"
	And I click Clear Item for that item
	Then the Length, Width, and Height fields will not be required

Scenario: 50763 - Verify that the dimension fields are not required when a value is entered for Length and then removed
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "1", "", ""
	And I remove the value for Length
	Then the Length, Width, and Height fields will not be required

Scenario: 50763 - Verify if the dimension fields are not required
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields "", "", ""
	Then the Length, Width, and Height fields will not be required

Scenario: 50763 - Verify that the dimension fields are not required when the Overlength accessorial value is selected in the Shipping From field and then un-selected
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	When I enter the following values in the length width and height fields "", "", ""
	And I have selected Overlength as a accessorial in the Shipping From field
	And I have un-selected Overlength as an accessorial in the Shipping From field
	Then the Length, Width, and Height fields will not be required

Scenario: 50763 - Verify that the dimension fields are required when the Overlength accessorial value is selected in the Shipping From field and then un-selected and a value is entered for length
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	When I enter the following values in the length width and height fields "1", "", ""
	And I have selected Overlength as a accessorial in the Shipping From field
	And I have un-selected Overlength as an accessorial in the Shipping From field
	Then the Length, Width, and Height fields will be required

#ADDITIONAL ITEMS SECTION

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Length for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "1", "", ""
	Then the Length, Width, and Height fields will be required for the additional item
	
Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Width for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "", "1", ""
	Then the Length, Width, and Height fields will be required for the additional item

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Height for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "", "", "1"
	Then the Length, Width, and Height fields will be required for the additional item

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Length and Width for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "1", "1", ""
	Then the Length, Width, and Height fields will be required for the additional item

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Length and Height for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "1", "", "1"
	Then the Length, Width, and Height fields will be required for the additional item

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Width and Height for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "", "1", "1"
	Then the Length, Width, and Height fields will be required for the additional item

Scenario: 50763 - Verify that the dimension fields are required when a value is entered for Length, Width, and Height for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "1", "1", "1"
	Then the Length, Width, and Height fields will be required for the additional item

Scenario: 50763 - Verify that the dimension fields are not required when a value is entered for Length and then cleared for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "1", "1", "1"
	And I click Clear Item for that additional item
	Then the Length, Width, and Height fields will not be required for the additional item

Scenario: 50763 - Verify that the dimension fields are not required when a value is entered for Length and then removed for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "1", "", ""
	And I remove the value for Length for the additional item
	Then the Length, Width, and Height fields will not be required for the additional item

Scenario: 50763 - Verify if the dimension fields are not required for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	And I have NOT selected Overlength as a accessorial in either of the following sections: Shipping From, Shipping To
	When I enter the following values in the length width and height fields for an additional item "", "", ""
	Then the Length, Width, and Height fields will not be required for the additional item

Scenario: 50763 - Verify that the dimension fields are not required when the Overlength accessorial value is selected in the Shipping From field and then un-selected for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	When I enter the following values in the length width and height fields for an additional item "", "", ""
	And I have selected Overlength as a accessorial in the Shipping From field
	And I have un-selected Overlength as an accessorial in the Shipping From field
	Then the Length, Width, and Height fields will not be required for the additional item

Scenario: 50763 - Verify that the dimension fields are required when the Overlength accessorial value is selected in the Shipping From field and then un-selected and a value is entered for length for additional item
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	When I enter the following values in the length width and height fields for an additional item "1", "", ""
	And I have selected Overlength as a accessorial in the Shipping From field
	And I have un-selected Overlength as an accessorial in the Shipping From field
	Then the Length, Width, and Height fields will be required for the additional item

Scenario: 50763 - Verify that dimension fields are required when length is entered and additional item is added
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	When I enter the following values in the length width and height fields "12", "", ""
	And I add 1 additional items
	Then the Length, Width, and Height fields will be required
	And the Length, Width, and Height fields will not be required for the additional item

Scenario: 50763 - Verify that dimension fields are required when the length is entered and two additional items are added
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	When I enter the following values in the length width and height fields "12", "", ""
	And I add 2 additional items
	Then the Length, Width, and Height fields will be required
	And the Length, Width, and Height fields will not be required for the additional item
	And the Length, Width, and Height fields will not be required for the second additional item

Scenario: 50763 - Verify that dimension fields are required for additional item when no dimensions are set for first item and length is entered for additional item and second additional item added
	Given I am a ship inquiry, ship entry, operations, sales, sales management, or station owner user with a valid "username-Currentsprintshpentry" "password-Currentsprintshpentry"
	And I am on GetQuote (LTL) page
	When I enter the following values in the length width and height fields for an additional item "12", "", ""
	And I add 1 additional items
	Then the Length, Width, and Height fields will not be required
	And the Length, Width, and Height fields will be required for the additional item
	And the Length, Width, and Height fields will not be required for the second additional item