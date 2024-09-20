@45682 @NinjaSprint22
Feature: Display quote criteria on quote results page

@Regression 
Scenario Outline: 45682_When on the quote results (LTL) page then I will see a new area for quote criteria
	Given I am a shpinquiry, shpentry, sales, sales management, operations, or station owner user
	When I arrive on the Get Quote (LTL) page
	And I have chose a pickup date <Pickup Date>
	And I choose a <Origin City> <Origin State> and <Origin Zip Code> for the origin
	And I choose a <Destination City> <Destination State> and <Destination Zip Code> for the Destination
	And I choose a <Pieces> <Weight> <Length> <Width> <Height> and <Class> for the item
	And I click on view quote results button on the Get Quote LTL page
	Then I will see the following new fields on the quote results page:
	| Field         |
	| Pickup Date:  |
	| Origin:       |
	| Destination:  |
	| Pieces:       |
	| Class/Weight: |
	Examples:
	| Pickup Date | Origin City | Origin State | Origin Zip Code | Destination City | Destination State | Destination Zip Code | Pieces | Weight | Length | Width | Height | Class |
	| Today       | Chicago     | IL           | 60606           | Beverly Hills    | CA                | 90210                | 4      | 1000   | 10     | 10    | 10     | 50    |

@Regression 
Scenario Outline: 45682_When entering information in get quote LTL page binds to quote results for quote criteria
	Given I am a shpinquiry, shpentry, sales, sales management, operations, or station owner user
	And I Arrive on the Get Quote (LTL) page
	When the quote contains one unique class
	And I have chose a pickup date <Pickup Date>
	And I choose a <Origin City> <Origin State> and <Origin Zip Code> for the origin
	And I choose a <Destination City> <Destination State> and <Destination Zip Code> for the Destination
	And I choose a <Pieces> <Weight> <Length> <Width> <Height> and <Class> for the item
	And I click on view quote results button on the Get Quote LTL page
	Then the Pickup Date field will be populated with the Pickup Date selected on the Get Quote (LTL) page <Pickup Date>
	And the Origin field will be populated with the City, State and Zip Code from the fields in the Shipping From section of the Get Quote (LTL) page <Origin City> <Origin State> <Origin Zip Code>
	And the Destination field will be populated with the City, State and Zip Code from the fields in the  Shipping To section of the Get Quote (LTL) page <Destination City> <Destination State> <Destination Zip Code>
	And the Pieces field will be populated with the total of all values entered in the Enter a quantity... fields in the Freight Description section of the Get Quote (LTL) page <Pieces>
	And the Class/Weight field will be populated with the class selected in the Select or search for a class or saved item... field in the Freight Description section of the Get Quote (LTL) page <Class> <Weight>
	And the following new fields are not editable:
	| Field        |
	| Pickup Date  |
	| Origin       |
	| Destination  |
	| Pieces       |
	| Class/Weight |
	Examples:
	| Pickup Date | Origin City   | Origin State | Origin Zip Code | Destination City | Destination State | Destination Zip Code | Pieces | Weight | Length | Width | Height | Class |
	| Today       | Chicago       | IL           | 60606           | Beverly Hills    | CA                | 90210                | 4      | 1000   | 10     | 10    | 10     | 50    |
	| Tomorrow    | Beverly Hills | CA           | 90210           | Chicago          | IL                | 60606                | 2      | 14     | 1      | 1     | 1      | 100   |

@Regression 
Scenario Outline: 45682_Entering mutiple classes on get quote shows a more information icon for class in quote criteria
	Given I am a shpinquiry, shpentry, sales, sales management, operations, or station owner user
	And I Arrive on the Get Quote (LTL) page
	And I have chose a pickup date <Pickup Date>
	And I choose a <Origin City> <Origin State> and <Origin Zip Code> for the origin
	And I choose a <Destination City> <Destination State> and <Destination Zip Code> for the Destination
	And the quote contains more than one unique class <Count>
	| Pieces | Weight | Class |
	| 4      | 100    | 50    |
	| 2      | 14     | 100   |
	| 1      | 1000   | 70    |
	When I click on view quote results button on the Get Quote LTL page
	Then I will see a More Information icon displayed in the Class/Weight field of the quote criteria
	Examples: 
	| Pickup Date | Origin City   | Origin State | Origin Zip Code | Destination City | Destination State | Destination Zip Code | Count |
	| Tomorrow    | Beverly Hills | CA           | 90210           | Chicago          | IL                | 60606                | 2     |
	| Tomorrow    | Beverly Hills | CA           | 90210           | Chicago          | IL                | 60606                | 3     |

@Regression 
Scenario Outline: 45682_Hovering over more information icon pops up information for each class
	Given I am a shpinquiry, shpentry, sales, sales management, operations, or station owner user
	And I Arrive on the Get Quote (LTL) page
	And I have chose a pickup date <Pickup Date>
	And I choose a <Origin City> <Origin State> and <Origin Zip Code> for the origin
	And I choose a <Destination City> <Destination State> and <Destination Zip Code> for the Destination
	And the quote contains more than one unique class <Count>
	| Pieces | Weight | Class |
	| 4      | 100    | 50    |
	| 2      | 14     | 100   |
	| 1      | 1000   | 70    |
	When I click on view quote results button on the Get Quote LTL page
	And I hover over the More Information icon in the Class/Weight field
	Then I will see a pop up displaying the pieces, class, and weight of each unique class <Count>
	| Pieces | Class/Weight |
	| 4      | 50/100 lbs   |
	| 2      | 100/14 lbs   |
	| 1      | 70/1000 lbs  |
	Examples: 
	| Pickup Date | Origin City   | Origin State | Origin Zip Code | Destination City | Destination State | Destination Zip Code | Count |
	| Tomorrow    | Beverly Hills | CA           | 90210           | Chicago          | IL                | 60606                | 2     |
	| Tomorrow    | Beverly Hills | CA           | 90210           | Chicago          | IL                | 60606                | 3     |