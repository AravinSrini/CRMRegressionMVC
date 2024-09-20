@Quote
Feature: Regression - Standard Insured Quotes Verification

@GUI @Functional
Scenario Outline: Regression_Verify standard insured quote and verify the quote in list and MG
	Given I am a Ship entry user
	And I Navigate to quotelist page
	And I Click on Create Quote Button
	And I Click on LTL Tile
	And I Enter Address information <OriginZipcode> , <destinationZipcode>
	And I Enter Item Information <ItemDescription>, <Weight>, <Quantity>
	And I Enter Shipment value to get Insured Rates '<ShipmentValue>'
	And I Click on View Quotes button
	And I click on save insured rate as quote link for carrier
	And I Arrive on the Quote Confirmation Page
	When I Navigate to quotelist page 
	Then Verify that the Quote is available in Quotelist page
	And I Verify the quote details in quote details section <OriginZipcode> , <destinationZipcode>,<Classification>, <Weight>, <Quantity>

Examples: 
| Scenarios | OriginZipcode | destinationZipcode | ItemDescription | Classification | Weight | Quantity | ShipmentValue |
| Scenario1 | 60606         | 60606              | 55              | 55             | 4      | 4        | 10            |

@GUI @Functional
Scenario Outline:  Regression_Verify standard insured quote and verify the quote in list and MG for Internal User
	Given I am an operation user
	And I Navigate to quotelist page
	And I select customeraccount from the dropdown <Account>
	And I Click on Create Quote Button
	And I Click on LTL Tile
	And I Enter Address information <OriginZipcode> , <destinationZipcode>
	And I Enter Item Information <ItemDescription>, <Weight>, <Quantity>
	And I Enter Shipment value to get Insured Rates '<ShipmentValue>'
	And I Click on View Quotes button
	And I click on save insured rate as quote link for carrier
	And I Arrive on the Quote Confirmation Page
	When I Navigate to quotelist page 
	Then Verify that the Quote is available in Quotelist page
	And I Verify the quote details in quote details section <OriginZipcode> , <destinationZipcode>,<Classification>, <Weight>, <Quantity>

Examples: 
| Scenarios | OriginZipcode | destinationZipcode | ItemDescription | Weight | Quantity | Classification | ShipmentValue | Account                   |
| Scenario1 | 60606         | 60606              | 55              | 4      | 4        | 55             | 10            | ZZZ Sandbox DLS Worldwide |
