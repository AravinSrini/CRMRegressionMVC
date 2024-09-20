@NinjaSprint36 @112736

Feature: Shipping Documents Performance

Scenario Outline: 112736 - Testing the Shipping Document section load within 15 seconds
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, sales, sales management, operations, or a station owner <username> <password>
	And I navigate to the Shipment List page
	And I search for the shipment shipref using the shipment reference lookup <referenceNumber>
	And I have clicked on the View Shipment Details button of any displayed shipment on Shipment List Page
	When I expand the Shipping Documents section,
	Then the search for documents will be completed within 18 seconds
	Examples: 
	| username                         | password                         | referenceNumber |
	| username-CurrentSprintshpentry   | password-CurrentSprintshpentry   | ZZX002016779    |
	| username-CurrentSprintOperations | password-CurrentSprintOperations | ZZX002016779    |
	| username-CurrentSprintSales      | password-CurrentSprintSales      | ZZX002016779    |
	| username-CurrentSprintshpentry   | password-CurrentSprintshpentry   | INT555685       |
	| username-CurrentSprintOperations | password-CurrentSprintOperations | INT555685       |
	| username-CurrentSprintSales      | password-CurrentSprintSales      | INT555685       |