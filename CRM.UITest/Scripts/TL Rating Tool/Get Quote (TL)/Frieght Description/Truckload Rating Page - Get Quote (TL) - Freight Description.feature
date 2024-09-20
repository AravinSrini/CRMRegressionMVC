@Sprint65 @TruckloadRatingPage-GetQuote(TL)-Freight Description @24229 
Feature: Truckload Rating Page - Get Quote (TL) - Freight Description
	
@GUI @Functional @Acceptance
Scenario Outline: Verify that the Freight Description field in the Get Quote (TL) page is a required free form text field and editable
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I should see an option to enter a Freight Description with '<lable>' and'<defaulttext>'
	And I should be able to enter free form text '<descriptiontext>' in the Description text field
	And I should see Freight Description field as required field by verifying the field border color should be in Orange

	Examples: 
	| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | lable               | defaulttext            | descriptiontext |
	| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | Freight Description | Enter a description... | 123             |
	| S2       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | Freight Description | Enter a description... | ABC             |
	| S3       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | Freight Description | Enter a description... | abc             |
	| S4       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | Freight Description | Enter a description... | !@#$%^&*()_+,.  |
	| S5       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | Freight Description | Enter a description... | 123ABCabc!@#    |

@GUI @Functional @Acceptance
Scenario Outline: Verify that Quantity field in the Get Quote (TL) page is a required and editable 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I should see an option to enter a Quantity with '<Qntdefaulttext>'
	And I should see Quantity field as required field by verifying the field border color should be in Orange
	And I should be able to enter '<quantity>' in the Quantity text field
	And Verify Quantity Type field is editable field

	Examples: 
	| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Qntdefaulttext    | quantity | Skids |
	| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | Enter quantity... | 25       | Skids |

@GUI @Functional @Acceptance
Scenario Outline: Verify the Quantity drop down in the Get Quote (TL) page is defaulted to Skids and verify the options present in Quantity drop down
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I should see quantity type value is defaulted to '<Skids>'
	And I click on  Quantity Type field dropdown in the Get Quote (TL) page
	And The '<options>' should be displayed in quantity unit field dropdown list

	Examples: 
	| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Skids | options                                                                                                                                          |
	| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | Skids | Skids,Bags,Bundles,Boxes,Cabinets,Cans,Cases,Crates,Cartons,Cylinders,Drums,Pails,Pieces,Pallets,Flat Racks,Reels,Rolls,Slip Sheets,Stacks,Totes |

@GUI @Functional @Acceptance
Scenario Outline: Verify that Weight field in the Get Quote (TL) page is a required and editable 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I should see an option to enter a Weight with '<Wgtdefaulttext>'
	And I should see Weight field as required field by verifying the field border color should be in Orange
	And I should be able to enter '<weight>' in the Weight text field
	And Verify Weight field is editable field

	Examples: 
	| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Wgtdefaulttext  | weight |
	| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | Enter weight... | 100    |

@GUI @Functional @Acceptance
Scenario Outline: Verify the Weight dropdown in the Get Quote (TL) page is defaulted to LBS and verify the options present in Weight dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter data in the required fields '<OriginZipCode>', '<DestinationZipCode>' and select the PickupDate in rating tool page
	And I Click on Get Rate button in rating tool page
	And  I click on Get Quote Now button in rating tool page 
	Then I should see weight type value is defaulted to '<LBS>'
	And I click on  Weight field dropdown in the Get Quote (TL) page
	And The '<options>' should be displayed in weight unit field dropdown list

	Examples: 
	| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | LBS | options   |
	| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | LBS | LBS,KILOS |