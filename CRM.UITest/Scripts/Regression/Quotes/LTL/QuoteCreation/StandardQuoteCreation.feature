@Quote
Feature: Regression - Standard Quote creation and verification in Quote List Page 

@Functional
Scenario Outline: Regression_Shp.Entry_Create standard quote and Verify in the Quote list Page
	Given I am a Ship entry user
	And I Navigate to quotelist page
	And I Click on Create Quote Button
	And I Click on LTL Tile
	And I Enter Address information <OriginZipcode> , <destinationZipcode>
	And I Enter Item Information <Classification>, <Weight>, <Quantity>
	And I Click on View Quotes button
	And I Click on Create Quote for a standard Carrier
	And I Arrive on the Quote Confirmation Page
	When I Navigate to quotelist page 
	Then Verify that the Quote is available in Quotelist page
	And I Verify the quote details in quote details section <OriginZipcode> , <destinationZipcode>,<Classification>, <Weight>, <Quantity>

Examples: 
| Scenarios | OriginZipcode | destinationZipcode | Classification | Weight | Quantity |
| Scenario1 | 60606         | 60606              | 55             | 4      | 4        |
