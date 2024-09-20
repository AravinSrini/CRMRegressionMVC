@NinjaSprint12 @AddShipmentLTL_DimensionsFieldsTabbing @39045  
Feature: AddShipmentLTL_DimensionsFieldsTabbing

# Scenarios for Internal Users : START
#Scenarios: Verify Tab order for freight description section dimension fields
@GUI
Scenario Outline: 39045_Verify that the click of TAB from Items Length field will focus to Width field for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And I clicked in the Length field in the Freight Description section
	When I hit the Tab button
	Then I will arrive in the Width field in the Freight Description section

Examples: 
	| Scenario | Username     | Password | CustomerAccount |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   |

@GUI
Scenario Outline: 39045_Verify that the click of TAB from Items Width field will focus to Height field  for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And I clicked in the Width field in the Freight Description section
	When I hit the Tab button
	Then I will arrive in the Height field in the Freight Description section

Examples: 
	| Scenario | Username     | Password | CustomerAccount |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   |

@GUI
Scenario Outline: 39045_Verify that the click of TAB from Items Height field will focus to ViewRates button for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And I clicked in the Height field in the Freight Description section
	When I hit the Tab button
	Then I will arrive on the View Rates button

Examples: 
	| Scenario | Username     | Password | CustomerAccount |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   |

#Scenarios: Verify <Shift + Tab> order for freight description section dimension fields
@GUI
Scenario Outline: 39045_Verify that the click of Shift+TAB from Items Length field will focus to Weight field  for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And I clicked in the Length field in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Weight field in the Freight Description section

Examples: 
	| Scenario | Username     | Password | CustomerAccount |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   |

@GUI
Scenario Outline: 39045_Verify that the click of Shift+TAB from Items Width field will focus to Length field  for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And I clicked in the Width field in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Length field in the Freight Description section

Examples: 
	| Scenario | Username     | Password | CustomerAccount |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   |

@GUI
Scenario Outline: 39045_Verify that the click of Shift+TAB from Items Height field will focus to Width field  for Internal User 
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And I clicked in the Height field in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Width field in the Freight Description section

Examples: 
	| Scenario | Username     | Password | CustomerAccount |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   |

#Scenarios: Verify Highlighting of freight description section dimension field values
@GUI
Scenario Outline: 39045_Verify that the Length value is highlighted when there is a Value and I arrive at Length by hitting Shift Tab from Width for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	When there is a value in the Length field <DimensionValue>
	And I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section	
	Then the value in the Length field will be highlighted

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValue |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts  | 10 |

@GUI
Scenario Outline: 39045_Verify that the Width value is highlighted when there is a Value and I arrive at Width by hitting Tab from Length for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	When there is a value in the Width field <DimensionValue>
	And I arrive at the Width field by hitting Tab from Length in the Freight Description section
	Then the value in the Width field will be highlighted

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValue |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10             |

@GUI
Scenario Outline: 39045_Verify that the Width value is highlighted when there is a Value and I arrive at Width by hitting Shift Tab from Height for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	When there is a value in the Width field <DimensionValue>
	And I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section
	Then the value in the Width field will be highlighted

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValue |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10             |

@GUI
Scenario Outline: 39045_Verify that the Height value is highlighted when there is a Value and I arrive at Height by hitting Tab from Width for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	When there is a value in the Height field <DimensionValue>
	And I arrive at the Height field by hitting Tab from Width in the Freight Description section
	Then the value in the Height field will be highlighted

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValue |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10             |

#Scenarios: Verify Override of freight description section dimension field values
@GUI
Scenario Outline: 39045_Verify that the Length value is over-written when a value is entered and I arrive at Length by hitting Shift Tab from Width for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Length field <DimensionValueOld>
	And I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section	
	When I enter any value in the Length field  <DimensionValueNew>
	Then the previous value in the Length will be over-written <DimensionValueNew>

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld | DimensionValueNew |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                | 25                |

@GUI
Scenario Outline: 39045_Verify that the Width value is over-written when a value is entered and I arrive at Width by hitting Tab from Length for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Tab from Length in the Freight Description section
	When I enter any value in the Width field <DimensionValueNew>
	Then the previous value in the Width will be over-written <DimensionValueNew>
	
Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld | DimensionValueNew |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                | 25                |

@GUI
Scenario Outline: 39045_Verify that the Width value is over-written when a value is entered and I arrive at Width by hitting Shift Tab from Height for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section
	When I enter any value in the Width field <DimensionValueNew>
	Then the previous value in the Width will be over-written <DimensionValueNew>
	
Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld | DimensionValueNew |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                | 25                |

@GUI
Scenario Outline: 39045_Verify that the Height value is over-written when a value is entered and I arrive at Height by hitting Tab from Width for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Height field <DimensionValueOld>
	And I arrive at the Height field by hitting Tab from Width in the Freight Description section
	When I enter any value in the Height field <DimensionValueNew>
	Then the previous value in the Height will be over-written <DimensionValueNew>
	
Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld | DimensionValueNew |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                | 25                |

#Scenarios: Verify Removal of freight description section dimension field values
@GUI
Scenario Outline: 39045_Verify that the Length value is removed when there is a Value and Backspace is hit and I arrive at Length by hitting Shift Tab from Width for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Length field <DimensionValueOld>
	And I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section	
	When I hit Backspace
	Then the value in the Length will be removed
	
Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                |

@GUI
Scenario Outline: 39045_Verify that the Width value is removed when there is a Value and Backspace is hit and I arrive at Width by hitting Tab from Length for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Tab from Length in the Freight Description section
	When I hit Backspace
	Then the value in the Width will be removed

	Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                |

@GUI
Scenario Outline: 39045_Verify that the Width value is removed when there is a Value and Backspace is hit and I arrive at Width by hitting Shift Tab from Height for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section
	When I hit Backspace
	Then the value in the Width will be removed

	Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                |

@GUI
Scenario Outline: 39045_Verify that the Height value is removed when there is a Value and Backspace is hit and I arrive at Height by hitting Tab from Width for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Height field <DimensionValueOld>
	And I arrive at the Height field by hitting Tab from Width in the Freight Description section
	When I hit Backspace
	Then the value in the Height will be removed

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                |

@GUI
Scenario Outline: 39045_Verify that the Length value is removed when there is a Value and Space bar is hit and I arrive at Length by hitting Shifting Tab from Width for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Length field <DimensionValueOld>
	And I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section	
	When I hit Space Bar
	Then the value in the Length will be removed

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                |

@GUI
Scenario Outline: 39045_Verify that the Width value is removed when there is a Value and Space bar is hit and I arrive at Width by hitting Tab from Length for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Tab from Length in the Freight Description section
	When I hit Space Bar
	Then the value in the Width will be removed

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                |

@GUI
Scenario Outline: 39045_Verify that the Width value is removed when there is a Value and Space bar is hit and I arrive at Width by hitting Shift Tab from Height for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section
	When I hit Space Bar
	Then the value in the Width will be removed

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                |

@GUI
Scenario Outline: 39045_Verify that the Height value is removed when there is a Value and Space bar is hit and I arrive at Height by hitting Tab from Width for Internal User
	Given I am a CRM operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Internal User LTL Add Shipment page <CustomerAccount>
	And there is a value in the Height field <DimensionValueOld>
	And I arrive at the Height field by hitting Tab from Width in the Freight Description section
	When I hit Space Bar
	Then the value in the Height will be removed

Examples: 
	| Scenario | Username     | Password | CustomerAccount | DimensionValueOld |
	| S1       | crmOperation | Te$t1234 | Dunkin Donuts   | 10                |

# Scenarios for Internal Users : END

# Scenarios for External Users : START
#Scenarios: Verify Tab order for freight description section dimension fields
@GUI
Scenario Outline: 39045_Verify that the click of TAB from Items Length field will focus to Width field for External user
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And I clicked in the Length field in the Freight Description section
	When I hit the Tab button
	Then I will arrive in the Width field in the Freight Description section

Examples: 
	| Scenario | Username  | Password |
	| S1       | shpentry | Te$t1234 |

@GUI
Scenario Outline: 39045_Verify that the click of TAB from Items Width field will focus to Height field for External user
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And I clicked in the Width field in the Freight Description section
	When I hit the Tab button
	Then I will arrive in the Height field in the Freight Description section

Examples: 
	| Scenario | Username  | Password |
	| S1       | shpentry | Te$t1234 |

@GUI
Scenario Outline: 39045_Verify that the click of TAB from Items Height field will focus to ViewRates button for External user
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And I clicked in the Height field in the Freight Description section
	When I hit the Tab button
	Then I will arrive on the View Rates button

Examples: 
	| Scenario | Username  | Password |
	| S1       | shpentry | Te$t1234 |

#Scenarios: Verify <Shift + Tab> order for freight description section dimension fields
@GUI
Scenario Outline: 39045_Verify that the click of Shift+TAB from Items Length field will focus to Weight field for External user
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And I clicked in the Length field in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Weight field in the Freight Description section

Examples: 
	| Scenario | Username  | Password |
	| S1       | shpentry | Te$t1234 |

@GUI
Scenario Outline: 39045_Verify that the click of Shift+TAB from Items Width field will focus to Length field for External user
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And I clicked in the Width field in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Length field in the Freight Description section

Examples: 
	| Scenario | Username  | Password |
	| S1       | shpentry | Te$t1234 |

@GUI
Scenario Outline: 39045_Verify that the click of Shift+TAB from Items Height field will focus to Width field for External user
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And I clicked in the Height field in the Freight Description section
	When I back tab out of the field Shift Tab
	Then I will arrive in the Width field in the Freight Description section

Examples: 
	| Scenario | Username  | Password |
	| S1       | shpentry | Te$t1234 |

#Scenarios: Verify Highlighting of freight description section dimension field values
@GUI
Scenario Outline: 39045_Verify that the Length value is highlighted when there is a Value and I arrive at Length by hitting Shift Tab from Width for External user
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	When there is a value in the Length field <DimensionValue>
	And I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section	
	Then the value in the Length field will be highlighted

Examples: 
	| Scenario | Username  | Password | DimensionValue |
	| S1       | shpentry | Te$t1234 | 10             |

@GUI
Scenario Outline: 39045_Verify that the Width value is highlighted when there is a Value and I arrive at Width by hitting Tab from Length for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	When there is a value in the Width field <DimensionValue>
	And I arrive at the Width field by hitting Tab from Length in the Freight Description section
	Then the value in the Width field will be highlighted

Examples: 
	| Scenario | Username  | Password | DimensionValue |
	| S1       |  shpentry | Te$t1234 | 10             |

@GUI
Scenario Outline: 39045_Verify that the Width value is highlighted when there is a Value and I arrive at Width by hitting Shift Tab from Height for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	When there is a value in the Width field <DimensionValue>
	And I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section
	Then the value in the Width field will be highlighted

Examples: 
	| Scenario | Username  | Password | DimensionValue |
	| S1       |  shpentry | Te$t1234 | 10             |

@GUI
Scenario Outline: 39045_Verify that the Height value is highlighted when there is a Value and I arrive at Height by hitting Tab from Width for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	When there is a value in the Height field <DimensionValue>
	And I arrive at the Height field by hitting Tab from Width in the Freight Description section
	Then the value in the Height field will be highlighted

Examples: 
	| Scenario | Username  | Password | DimensionValue |
	| S1       | shpentry | Te$t1234 | 10             |

#Scenarios: Verify Override of freight description section dimension field values
@GUI
Scenario Outline: 39045_Verify that the Length value is over-written when a value is entered and I arrive at Length by hitting Shift Tab from Width for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Length field <DimensionValueOld>
	And I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section	
	When I enter any value in the Length field  <DimensionValueNew>
	Then the previous value in the Length will be over-written <DimensionValueNew>

Examples: 
	| Scenario | Username  | Password | DimensionValueOld | DimensionValueNew |
	| S1       | shpentry | Te$t1234 | 10                | 25                |

@GUI
Scenario Outline: 39045_Verify that the Width value is over-written when a value is entered and I arrive at Width by hitting Tab from Length for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Tab from Length in the Freight Description section
	When I enter any value in the Width field <DimensionValueNew>
	Then the previous value in the Width will be over-written <DimensionValueNew>
	
Examples: 
	| Scenario | Username  | Password | DimensionValueOld | DimensionValueNew |
	| S1       | shpentry | Te$t1234 | 10                | 25                |

@GUI
Scenario Outline: 39045_Verify that the Width value is over-written when a value is entered  and I arrive at Width by hitting Shift Tab from Height for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section
	When I enter any value in the Width field <DimensionValueNew>
	Then the previous value in the Width will be over-written <DimensionValueNew>
	
Examples: 
	| Scenario | Username  | Password | DimensionValueOld | DimensionValueNew |
	| S1       | shpentry | Te$t1234 | 10                | 25                |

@GUI
Scenario Outline: 39045_Verify that the Height value is over-written when a value is entered and I arrive at Height by hitting Tab from Width for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Height field <DimensionValueOld>
	And I arrive at the Height field by hitting Tab from Width in the Freight Description section
	When I enter any value in the Height field <DimensionValueNew>
	Then the previous value in the Height will be over-written <DimensionValueNew>
	
Examples: 
	| Scenario | Username  | Password | DimensionValueOld | DimensionValueNew |
	| S1       | shpentry | Te$t1234 | 10                | 25                |

#Scenarios: Verify Removal of freight description section dimension field values
@GUI
Scenario Outline: 39045_Verify that the Length value is removed when there is a Value and Backspace is hit and I arrive at Length by hitting Shift Tab from Width for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Length field <DimensionValueOld>
	And I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section	
	When I hit Backspace
	Then the value in the Length will be removed
	
Examples: 
	| Scenario | Username  | Password | DimensionValueOld |
	| S1       | shpentry | Te$t1234 | 10                |

@GUI
Scenario Outline: 39045_Verify that the Width value is removed when there is a Value and Backspace is hit and I arrive at Width by hitting Tab from Length for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Tab from Length in the Freight Description section
	When I hit Backspace
	Then the value in the Width will be removed

	Examples: 
	| Scenario | Username | Password | DimensionValueOld |
	| S1       | shpentry | Te$t1234 | 10                |

@GUI
Scenario Outline: 39045_Verify that the Width value is removed when there is a Value and Backspace is hit and I arrive at Width by hitting Shift Tab from Height for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section
	When I hit Backspace
	Then the value in the Width will be removed

	Examples: 
	| Scenario | Username | Password | DimensionValueOld |
	| S1       | shpentry | Te$t1234 | 10                |

@GUI
Scenario Outline: 39045_Verify that the Height value is removed when there is a Value and Backspace is hit and I arrive at Height by hitting Tab from Width for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Height field <DimensionValueOld>
	And I arrive at the Height field by hitting Tab from Width in the Freight Description section
	When I hit Backspace
	Then the value in the Height will be removed

Examples: 
	| Scenario | Username | Password | DimensionValueOld |
	| S1       | shpentry | Te$t1234 | 10                |

@GUI
Scenario Outline: 39045_Verify that the Length value is removed when there is a Value and Space bar is hit and I arrive at Length by hitting Shift Tab from Width for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Length field <DimensionValueOld>
	And I arrive at the Length field by hitting Shift Tab from Width in the Freight Description section	
	When I hit Space Bar
	Then the value in the Length will be removed

Examples: 
	| Scenario | Username | Password | DimensionValueOld |
	| S1       | shpentry | Te$t1234 | 10                |

@GUI
Scenario Outline: 39045_Verify that the Width value is removed when there is a Value and Space bar is hit and I arrive at Width by hitting Tab from Length for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Tab from Length in the Freight Description section
	When I hit Space Bar
	Then the value in the Width will be removed

Examples: 
	| Scenario | Username | Password | DimensionValueOld |
	| S1       | shpentry | Te$t1234 | 10                |

@GUI
Scenario Outline: 39045_Verify that the Width value is removed when there is a Value and Space bar is hit and I arrive at Width by hitting Shift Tab from Height for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Width field <DimensionValueOld>
	And I arrive at the Width field by hitting Shift Tab from Height in the Freight Description section
	When I hit Space Bar
	Then the value in the Width will be removed

Examples: 
	| Scenario | Username | Password | DimensionValueOld |
	| S1       | shpentry | Te$t1234 | 10                |

@GUI
Scenario Outline: 39045_Verify that the Height value is removed when there is a Value and Space bar is hit and I arrive at Height by hitting Tab from Width for External User
	Given I am a CRM shp.entry, shp.entrynorates user <Username> <Password>
	And I am on the External User LTL Add Shipment page
	And there is a value in the Height field <DimensionValueOld>
	And I arrive at the Height field by hitting Tab from Width in the Freight Description section
	When I hit Space Bar
	Then the value in the Height will be removed

Examples: 
	| Scenario | Username | Password | DimensionValueOld |
	| S1       | shpentry | Te$t1234 | 10                |

# Scenarios for External Users : END