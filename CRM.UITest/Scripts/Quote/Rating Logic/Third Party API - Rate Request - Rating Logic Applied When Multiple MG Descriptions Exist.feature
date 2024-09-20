@48310 @Sprint85
Feature: Third Party API - Rate Request - Rating Logic Applied When Multiple MG Descriptions Exist
	
@Regression 
Scenario Outline: 48310_Test to Verify the CRM rating logic applied when multiple MG Description Exist for all carriers_3rd party API
	Given that a user has submitted a request to the RateShop API via proxy <MG Description>
	And the request contains an accessorial with <MG Description>
	And the CRM Rating Logic is selected Yes for the customer
	When the request is processed
	Then the Individual Accessorial Charge will be applied to all carrier rates of Rate Request

	Examples: 
	| MG Description    |
	| COD               |
	| Liftgate Delivery |

@Regression 
Scenario Outline: 48310_Test to Verify the CRM rating logic applied when multiple MG Description Exist for a specific carriers_3rd party API
	Given that a user has submitted a request to the RateShop API via proxy <MG Description>
	And the request contains an accessorial with <MG Description>
	And the CRM Rating Logic is selected Yes for the customer	
	When the request is processed
	Then the Individual Accessorial Charge will be applied to the carrier rate of Rate Request

	Examples: 
	| MG Description    |
	| COD               |
	| Liftgate Delivery |

@Regression 
Scenario Outline: 48310_Test to Verify the CRM rating logic applied when No MG Description Exist for all carriers_3rd party API
	Given that a user has submitted a request to the RateShop API via proxy <No MG Description>
	And the request contains an accessorial with <No MG Description>
	And the CRM Rating Logic is selected Yes for the customer	
	When the request is processed
	Then the Individual Accessorial Charge will not be applied to all carrier rates of Rate Request

	Examples: 
	| No MG Description |
	|                   |

@Regression 
Scenario Outline: 48310_Test to Verify the CRM rating logic applied when No MG Description Exist for a specific carriers_3rd party API
	Given that a user has submitted a request to the RateShop API via proxy <No MG Description>
	And the request contains an accessorial with <No MG Description>
	And the CRM Rating Logic is selected Yes for the customer	
	When the request is processed
	Then the Individual Accessorial Charge will not be applied to the carrier rate of Rate Request

	Examples: 
	| No MG Description |
	|                   |
