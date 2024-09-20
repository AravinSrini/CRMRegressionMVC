@Sprint85 @47908
Feature: Save Quote to Shipment (LTL) - Pass Overlength accessorial to UI
	
@Functional
Scenario: 47908 - Verify accessorial in shipping from section from Add Shipment page
	Given I am a shp.entry, sales, sales management, operations, or station owner
	And I am in the Quote Details of an active LTL quote
	And the saved quote had Overlength selected in the Shipping From section
	And clicked on the Create Shipment button
	When I arrive on the Add Shipment (LTL) page
	Then the accessorial Overlength should be selected in the Shipping From section
	

@Regression @105749
Scenario Outline: 105749-Verify the Overlength is not binding in Shipping To Section when I saved Quote with Overlength accessorial in Saved Quote to Shipment Process
         Given I am a shp.entry, sales, sales management, operations, or station owner
		 And I submit a LTL Quote <QuoteType> with Overlength accessorial
		 And clicked on the Create Shipment button
		 When I arrive on the Add Shipment (LTL) page
		 Then the accessorial Overlength should be selected in the Shipping From section not in the Shipping To Section
Examples: 
| QuoteType                 |
| Standard Quote            |              
| Insured Quote             |  


@Regression @108624
Scenario: 108624-Verify the Overlength is not binding shipping to section but other accessorial should bind in Shipping To Section when I saved Quote with Overlength with other accessorial in Saved Quote to Shipment Process
         Given I am a shp.entry, sales, sales management, operations, or station owner
		 And I submit a LTL Quote with Overlength and other accessorial in shipping from accessorial and adding other accessorial in shipping To section
		 And clicked on the Create Shipment button
		 When I arrive on the Add Shipment (LTL) page
		 Then the accessorial Overlength should be selected in the Shipping From section not in the Shipping To Section
		 And Other accessorial should be selected  in shopping from and to section 
		 And MG Should contain All accessorial
            
