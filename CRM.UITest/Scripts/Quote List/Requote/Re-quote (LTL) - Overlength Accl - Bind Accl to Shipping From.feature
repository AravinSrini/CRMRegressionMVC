@48512 @Sprint87
Feature: Re-quote (LTL) - Overlength Accl - Bind Accl to Shipping From
	
@Functional
Scenario: 48512_Verify the Overlength Accessorial binded in Shipment Information Page while doing Re-Quote
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
	And I am in the Quote Details of an expired quote
	And the expired quote had an Overlength accessorial
	When i click on the Re-quote button	
	Then I will see an accessorial Overlength selected in the Shipping From section of Get Quote (LTL) Page
		
@Functional
Scenario: 48512_Verify the non overlength Accessorial binded in Shipment Information Page while doing Re-Quote
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
	And I am in the Quote Details of an expired quote other than overlength
	And the expired quote had an accessorial
	When i click on the Re-quote button	
	Then I will see the selected accessorial in the Shipping From section of Get Quote (LTL) Page
