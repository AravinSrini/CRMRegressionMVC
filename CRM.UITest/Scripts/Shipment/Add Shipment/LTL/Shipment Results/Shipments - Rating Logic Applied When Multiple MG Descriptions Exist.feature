@Sprint85 @47872
Feature: Shipments - Rating Logic Applied When Multiple MG Descriptions Exist

@Functional
Scenario Outline: 47872_Rating Logic Applied When one or multple MG Descriptions Exist_Accessorial Charge set for customer level_Shipments
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
And I am submitting a Shipment request for LTL service type 
And I selected an accessorial for the Shipment with <MG Description>
And the CRM Rating Logic is selected Yes for the customer for Shipment	
When I submit the request for Shipment
And CRM receives one of the MG Descriptions of the selected accessorial for Shipment
Then the Individual Accessorial Charge will be applied to all carrier rates for Shipment

	Examples:
	| MG Description    |
	| COD               |
	| Liftgate Delivery |

@Functional
Scenario Outline: 47872_Rating Logic Applied When one or multple MG Descriptions Exist_Accessorial Charge set for carrier level_Shipments
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
And I am submitting a Shipment request for LTL service type 
And I selected an accessorial for the Shipment with <MG Description>
And the CRM Rating Logic is selected Yes for the customer for Shipment	
When I submit the request for Shipment
And CRM receives one of the MG Descriptions of the selected accessorial for Shipment
Then the Individual Accessorial Charge will be applied to the carrier rate for Shipment

Examples: 
	| MG Description    |
	| COD               |
	| Liftgate Delivery |

@Functional
Scenario Outline:47872_Rating Logic Applied When no MG Descriptions Exist_No Accessorial Charge set for customer level_Shipments
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
And I am submitting a Shipment request for LTL service type 
And I selected an accessorial for the Shipment with <No MG Description>
And the CRM Rating Logic is selected Yes for the customer for Shipment
When I submit the request for Shipment
Then the Individual Accessorial Charge will not be applied to all carrier rates for Shipment

Examples: 
| No MG Description |
|                   |

@Functional
Scenario Outline:47872_Rating Logic Applied When no MG Descriptions Exist_No Accessorial Charge set for carrier level_Shipments
Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner users
And I am submitting a Shipment request for LTL service type 
And I selected an accessorial for the Shipment with <No MG Description>
And the CRM Rating Logic is selected Yes for the customer for Shipment
When I submit the request for Shipment
Then the Individual Accessorial Charge will not be applied to the carrier rate for Shipment

Examples: 
| No MG Description |
|                   |