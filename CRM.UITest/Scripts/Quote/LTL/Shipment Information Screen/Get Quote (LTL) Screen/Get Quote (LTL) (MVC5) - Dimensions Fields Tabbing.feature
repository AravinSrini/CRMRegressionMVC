@45783 @Sprint84
Feature: Get Quote (LTL) (MVC5) - Dimensions Fields Tabbing
	
Background:Navigation to Get Quote (LTL) page
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner user,
	And I am on Get Quote (LTL) page

@Regression
Scenario Outline: 45783_Verify the tab order for dimension fields
	Given I clicked on the <Dimension> field in the Freight Description section
	When I hit the Tab button on Get Quote Page
	Then I will arrive on <NextDimension> field in the Freight Description section

	Examples:
	| Dimension | NextDimension      |
	| Length    | Width              |
	| Width     | Height             |
	| Height    | View Quote Results |

@Regression
Scenario Outline: 45783_Verify the back tab order for Dimension fields
	Given I clicked on the <Dimension> field in the Freight Description section
	When I back tab out of the field Shift + Tab
	Then I will arrive on field <PreviousDimension> in Freight Description section

	Examples: 
	| Dimension | PreviousDimension |
	| Length    | Weight            |
	| Width     | Length            |
	| Height    | Width             |

@Regression
Scenario Outline: 45783_Verify the highlight functionality of Dimensions fields
	Given I clicked on the <Dimension> field in the Freight Description section
	When there is a value in the field <Dimension>
	Then the <Dimension> value in the field will be highlighted

	Examples: 
	| Dimension |
	| Length    |
	| Width     |
	| Height    |

@Regression
Scenario Outline: 45783_Verify the old values over written when user entered new values
	Given There is <Dimension> value in the field
	When I enter value <DimensionNewValue> in the field <Dimension>
	Then previous values will be over-written with <DimensionNewValue> in the field <Dimension>

	Examples: 
	| Dimension | DimensionNewValue |
	| Length    | 22                |
	| Width     | 86                |
	| Height    | 40                |

@Regression
Scenario Outline: 45783_Verify the Dimension values got removed when user hit on backspace
	Given I arrive at any of the <Dimension> fields having values in the Freight Description section
	When I click on backspace
	Then the <Dimension> value will be removed

	Examples: 
	| Dimension |
	| Length    |
	| Width     |
	| Height    |

@Regression
Scenario Outline: 45783_Verify the Dimension values got removed when user hit on Space Bar
	Given I arrive at any of the <Dimension> fields having values in the Freight Description section
	When I click on Space Bar
	Then the <Dimension> value will be removed

	Examples: 
	| Dimension |
	| Length    |
	| Width     |
	| Height    |