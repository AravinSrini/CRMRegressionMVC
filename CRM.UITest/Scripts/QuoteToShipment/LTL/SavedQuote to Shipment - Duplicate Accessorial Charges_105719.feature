Feature: SavedQuote to Shipment - Duplicate Accessorial Charges_105719
	105719-Tech Debt -  105210 -  Automation Scripts - Quote to Shipment - Duplicate Accessorial Charge
	To validate whether "Ins ALL Risk" is Present twice in the Pricesheet under Customer Charge 

@Sprint92 @105719
Scenario: 105719 - Verify that pricesheet does not contains duplicate Accessorial charges
	Given I am a External user
	And I have created a Quote
	When I create a Shipment from non-expired LTL quote
	Then Pricesheet should not contain duplicate charges for accessorials 
