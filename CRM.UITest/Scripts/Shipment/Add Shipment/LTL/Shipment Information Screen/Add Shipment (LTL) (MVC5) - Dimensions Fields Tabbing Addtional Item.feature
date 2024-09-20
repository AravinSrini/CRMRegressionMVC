@39905 @Sprint77
Feature: Add Shipment (LTL) (MVC5) - Dimensions Fields Tabbing Addtional Item

# Scenarios for Internal Users : START
#Verifying Tab order for internal users	
@GUI
Scenario: 39905_Verify the click of Tab from Length field of Add Additional Item for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Length field of the additional item in the Freight Description section
	When I hit the Tab button
	Then I will arrive in the Width field of the additional item in the Freight Description section

@GUI
Scenario: 39905_Verify the click of Tab from Width field of Add Additional Item for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Width field of the additional item in the Freight Description section
	When I hit the Tab button
	Then I will arrive in the Height field of the additional item in the Freight Description section

@GUI
Scenario: 39905_Verify the click of Tab from Height field of Add Additional Item for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Height field of the additional item in the Freight Description section
	When I hit the Tab button
	Then I will arrive on the View Rates button

#Verifying Shift+Tab order for internal users	
@GUI
Scenario: 39905_Verify the click of Shift+Tab from Length field of Add Additional Item for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Length field of the additional item in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Weight field of the additional item in the Freight Description section

@GUI
Scenario: 39905_Verify the click of Shift+Tab from Width field of Add Additional Item for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Width field of the additional item in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Length field of the additional item in the Freight Description section

@GUI
Scenario: 39905_Verify the click of Shift+Tab from Height field of Add Additional Item for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Height field of the additional item in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Width field of the additional item in the Freight Description section

#Verifying highlight of freight description dimension field values of add additional item
@GUI
Scenario: 39905_Verify the Length value is highlighted for Add Additional Item by hitting Shift Tab for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	When there is value in Length field
	And I arrive on Length field by hitting Shift Tab from Width 	
	Then the value in the Length field of additional items will be highlighted

@GUI
Scenario: 39905_Verify the Width value is highlighted for Add Additional Item by hitting Tab for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section	
	When there is a value in Width field	
	And I arrive on Width field by hitting Tab from Length 
	Then the value in the Width field of add additional item will be highlighted

@GUI
Scenario: 39905_Verify the Width value is highlighted for Add Additional Item by hitting Shift Tab for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	When there is a value in Width field 	
	And I arrive on the Width field by hitting Shift Tab from Height 
	Then the value in the Width field of add additional item will be highlighted

@GUI
Scenario: 39905_Verify the Height value is highlighted for Add Additional Item by hitting Tab for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page 
	And I clicked on the Add Additional Item button in the Freight Description section	
	When there is a value in the Height field 	
	And I arrive at the Height field by hitting Tab from Width 
	Then the value in the Height field of add additional item will be highlighted

#Verifying Over written of freight description dimension field values of add additional item
@GUI
Scenario Outline: 39905_Verify the Length value is over-written when a value is entered for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page 
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Length field
	And I arrive at the Length field by hitting Shift Tab from Width
	When I enter any value in the Length field of Additional Item  <dimensionValueNew>
	Then the previous value in the Length of Additional Item will be over-written <dimensionValueNew>

Examples: 
	| dimensionValueNew |
	| 12                |
	 
@GUI
Scenario Outline: 39905_Verify the Width value is over-written when a value is entered by hitting Tab from Length for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field
	And I arrive at the Width field by hitting Tab from Length 
	When I enter any value in the Width fieldof Additional Item <dimensionValueNew>
	Then the previous value in the Width of Additional Item  will be over-written <dimensionValueNew>
	
Examples: 
	| dimensionValueNew |
	| 13                |

@GUI
Scenario Outline: 39905_Verify the Width value is over-written when a value is entered by hitting Shift Tab from Height for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page 
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field
	And I arrive at the Width field by hitting Shift Tab from Height 
	When I enter any value in the Width fieldof Additional Item <dimensionValueNew>
	Then the previous value in the Width of Additional Item  will be over-written <dimensionValueNew>
	
Examples: 
	| dimensionValueNew |
	| 11                |
	
@GUI
Scenario Outline: 39905_Verify the Height value is over-written when a value is entered by hitting Tab from Width for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Height field
	And I arrive at the Height field by hitting Tab from Width 
	When I enter any value in the Height fieldof Additional Item <dimensionValueNew>
	Then the previous value in the Height of Additional Item  will be over-written <dimensionValueNew>
	
Examples: 
	| dimensionValueNew |
	| 20                |
	
#Verifying Removal of freight description section dimension field values of add additional item
@GUI
Scenario: 39905_Verify the Length value is removed when there is a Value and Backspace is hit, by hitting Shift Tab from Width for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Length field 
	And I arrive at the Length field by hitting Shift Tab from Width 
	When I hit Backspace
	Then the value in the Length of Additional Item will be removed

@GUI
Scenario: 39905_Verify the Width value is removed when there is a Value and Backspace is hit, by hitting Tab from Length for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page 
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field 
	And I arrive at the Width field by hitting Tab from Length 
	When I hit Backspace
	Then the value in the Width of Additional Item will be removed

@GUI
Scenario: 39905_Verify the Width value is removed when there is a Value and Backspace is hit, by hitting Shift Tab from Height for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field 
	And I arrive at the Width field by hitting Shift Tab from Height 
	When I hit Backspace
	Then the value in the Width of Additional Item will be removed
	

@GUI
Scenario: 39905_Verify the Height value is removed when there is a Value and Backspace is hit, by hitting Tab from Width for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Height field 
	And I arrive at the Height field by hitting Tab from Width 
	When I hit Backspace
	Then the value in the Height of Additional Item will be removed

@GUI
Scenario: 39905_Verify the Length value is removed when there is a Value and Space bar is hit, by hitting Shifting Tab from Width for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Length field 
	And I arrive at the Length field by hitting Shift Tab from Width 
	When I hit Space Bar
	Then the value in the Length of Additional Item will be removed
	
@GUI
Scenario: 39905_Verify the Width value is removed when there is a Value and Space bar is hit, by hitting Tab from Length for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field 
	And I arrive at the Width field by hitting Tab from Length 
	When I hit Space Bar
	Then the value in the Width of Additional Item will be removed
	
@GUI
Scenario: 39905_Verify the Width value is removed when there is a Value and Space bar is hit, by hitting Shift Tab from Height for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field 
	And I arrive at the Width field by hitting Shift Tab from Height 
	When I hit Space Bar
	Then the value in the Width of Additional Item will be removed
	
@GUI
Scenario: 39905_Verify the Height value is removed when there is a Value and Space bar is hit, by hitting Tab from Width for Internal User
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Internal User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Height field 
	And I arrive at the Height field by hitting Tab from Width 
	When I hit Space Bar
	Then the value in the Height of Additional Item will be removed

# Scenarios for Internal Users : END

# Scenarios for External Users : START
#Verifying Tab order for external users	
@GUI
Scenario: 39905_Verify the click of Tab from Length field of Add Additional Item for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Length field of the additional item in the Freight Description section
	When I hit the Tab button
	Then I will arrive in the Width field of the additional item in the Freight Description section

@GUI
Scenario: 39905_Verify the click of Tab from Width field of Add Additional Item for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Width field of the additional item in the Freight Description section
	When I hit the Tab button
	Then I will arrive in the Height field of the additional item in the Freight Description section

	
@GUI
Scenario: 39905_Verify the click of Tab from Height field of Add Additional Item for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Height field of the additional item in the Freight Description section
	When I hit the Tab button
	Then I will arrive on the View Rates button


#Verifying Shift+Tab order for external users	
@GUI
Scenario: 39905_Verify the click of Shift+Tab from Length field of Add Additional Item for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Length field of the additional item in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Weight field of the additional item in the Freight Description section

@GUI
Scenario: 39905_Verify the click of Shift+Tab from Width field of Add Additional Item for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Width field of the additional item in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Length field of the additional item in the Freight Description section


@GUI
Scenario: 39905_Verify the click of Shift+Tab from Height field of Add Additional Item for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And I clicked in the Height field of the additional item in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Width field of the additional item in the Freight Description section


#Verifying highlight of freight description dimension field values of add additional item
@GUI
Scenario: 39905_Verify the Length value is highlighted for Add Additional Item by hitting Shift Tab for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	When there is value in Length field
	And I arrive on Length field by hitting Shift Tab from Width 	
	Then the value in the Length field of additional items will be highlighted

	
@GUI
Scenario: 39905_Verify the Width value is highlighted for Add Additional Item by hitting Tab for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	When there is a value in Width field	
	And I arrive on Width field by hitting Tab from Length 
	Then the value in the Width field of add additional item will be highlighted


@GUI
Scenario: 39905_Verify the Width value is highlighted for Add Additional Item by hitting Shift Tab for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	When there is a value in Width field 	
	And I arrive on the Width field by hitting Shift Tab from Height 
	Then the value in the Width field of add additional item will be highlighted


@GUI
Scenario: 39905_Verify the Height value is highlighted for Add Additional Item by hitting Tab for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	When there is a value in the Height field 	
	And I arrive at the Height field by hitting Tab from Width 
	Then the value in the Height field of add additional item will be highlighted

	
#Verifying Over written of freight description dimension field values of add additional item
@GUI
Scenario Outline: 39905_Verify the Length value is over-written when a value is entered for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Length field
	And I arrive at the Length field by hitting Shift Tab from Width
	When I enter any value in the Length field of Additional Item  <dimensionValueNew>
	Then the previous value in the Length of Additional Item will be over-written <dimensionValueNew>

Examples: 
| dimensionValueNew |
| 22                |

@GUI
Scenario Outline: 39905_Verify the Width value is over-written when a value is entered by hitting Tab from Length for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field
	And I arrive at the Width field by hitting Tab from Length 
	When I enter any value in the Width fieldof Additional Item <dimensionValueNew>
	Then the previous value in the Width of Additional Item  will be over-written <dimensionValueNew>
	
Examples: 
	| dimensionValueNew |
	| 32                |

@GUI
Scenario Outline: 39905_Verify the Width value is over-written when a value is entered by hitting Shift Tab from Height for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field
	And I arrive at the Width field by hitting Shift Tab from Height 
	When I enter any value in the Width fieldof Additional Item <dimensionValueNew>
	Then the previous value in the Width of Additional Item  will be over-written <dimensionValueNew>
	
Examples: 
	| dimensionValueNew |
	| 44                |
	
@GUI
Scenario Outline: 39905_Verify the Height value is over-written when a value is entered by hitting Tab from Width for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Height field
	And I arrive at the Height field by hitting Tab from Width 
	When I enter any value in the Height fieldof Additional Item <dimensionValueNew>
	Then the previous value in the Height of Additional Item  will be over-written <dimensionValueNew>
	
Examples: 
	| dimensionValueNew |
	| 60                |
	
#Verifying Removal of freight description section dimension field values of add additional item
@GUI
Scenario: 39905_Verify the Length value is removed when there is a Value and Backspace is hit, by hitting Shift Tab from Width for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Length field 
	And I arrive at the Length field by hitting Shift Tab from Width 
	When I hit Backspace
	Then the value in the Length of Additional Item will be removed
	
@GUI
Scenario: 39905_Verify the Width value is removed when there is a Value and Backspace is hit, by hitting Tab from Length for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field 
	And I arrive at the Width field by hitting Tab from Length 
	When I hit Backspace
	Then the value in the Width of Additional Item will be removed
		
@GUI
Scenario: 39905_Verify the Width value is removed when there is a Value and Backspace is hit, by hitting Shift Tab from Height for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field 
	And I arrive at the Width field by hitting Shift Tab from Height 
	When I hit Backspace
	Then the value in the Width of Additional Item will be removed
		
@GUI
Scenario: 39905_Verify the Height value is removed when there is a Value and Backspace is hit, by hitting Tab from Width for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Height field 
	And I arrive at the Height field by hitting Tab from Width 
	When I hit Backspace
	Then the value in the Height of Additional Item will be removed
	
@GUI
Scenario: 39905_Verify the Length value is removed when there is a Value and Space bar is hit, by hitting Shifting Tab from Width for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Length field 
	And I arrive at the Length field by hitting Shift Tab from Width 
	When I hit Space Bar
	Then the value in the Length of Additional Item will be removed
	
@GUI
Scenario: 39905_Verify the Width value is removed when there is a Value and Space bar is hit, by hitting Tab from Length for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field 
	And I arrive at the Width field by hitting Tab from Length 
	When I hit Space Bar
	Then the value in the Width of Additional Item will be removed
		
@GUI
Scenario: 39905_Verify the Width value is removed when there is a Value and Space bar is hit, by hitting Shift Tab from Height for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Width field 
	And I arrive at the Width field by hitting Shift Tab from Height 
	When I hit Space Bar
	Then the value in the Width of Additional Item will be removed
	
@GUI
Scenario: 39905_Verify the Height value is removed when there is a Value and Space bar is hit, by hitting Tab from Width for External User
	Given I am a shp.entry,shp.entrynorates user
	And I am on the External User LTL Add Shipment page
	And I clicked on the Add Additional Item button in the Freight Description section
	And there is a value in the Height field 
	And I arrive at the Height field by hitting Tab from Width 
	When I hit Space Bar
	Then the value in the Height of Additional Item will be removed
	
# Scenarios for External Users : END
	