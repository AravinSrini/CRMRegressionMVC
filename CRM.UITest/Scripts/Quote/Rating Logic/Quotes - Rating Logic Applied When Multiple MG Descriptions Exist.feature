@47871 @Sprint85
Feature: Quotes - Rating Logic Applied When Multiple MG Descriptions Exist
	
@Regression 
Scenario Outline: 47871_Test to Verify the CRM rating logic applied when multiple MG Description Exist for all carriers
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
	And I am submitting a rate request for LTL service type
	And I selected an accessorial with <MG Description>
	And the CRM Rating Logic is selected Yes for the customer
	When I submit the request
	And CRM receives one of the MG Descriptions of the selected accessorial
	Then the Individual Accessorial Charge will be applied to all carrier rates
	
	Examples:
	| MG Description    |
	| COD               |
	| Liftgate Delivery |
		
@Regression 
Scenario Outline: 47871_Test to Verify the CRM rating logic applied when multiple MG Description exist for a specific carrier
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
	And I am submitting a rate request for LTL service type
	And I selected an accessorial with <MG Description>
	And the CRM Rating Logic is selected Yes for the customer
	When I submit the request
	And CRM receives one of the MG Descriptions of the selected accessorial
	Then the Individual Accessorial Charge will be applied to the carrier rate

	Examples: 
	| MG Description    |
	| COD               |
	| Liftgate Delivery |

@Regression 
Scenario Outline: 47871_Test to Verify the CRM rating logic applied when No MG Description Exist for all carriers
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
	And I am submitting a rate request for LTL service type
	And I selected an accessorial with <No MG Description>
	And the CRM Rating Logic is selected Yes for the customer
	When I submit the request	
	Then the Individual Accessorial Charge will not be applied to all carrier rates
	
	Examples:
	| No MG Description |
	|                   |
		
@Regression 
Scenario Outline: 47871_Test to Verify the CRM rating logic applied when No MG Description exist for a specific carrier
	Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
	And I am submitting a rate request for LTL service type
	And I selected an accessorial with <No MG Description>
	And the CRM Rating Logic is selected Yes for the customer
	When I submit the request	
	Then the Individual Accessorial Charge will not be applied to the carrier rate

	Examples: 
	| No MG Description |
	|                   |
