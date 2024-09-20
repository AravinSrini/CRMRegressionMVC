@45683 @NinjaSprint22 
Feature: Shipment Results LTL - Display Shipment Criteria

@GUI
Scenario Outline: Verify a shipment information bar displays at the top of the page with the correct fields
	Given I am a shpentry sales sales management operations or station owner user
	When I arrive on the Shipment Results LTL page <Date>, <OriginName>, <OriginCity>, <OriginState>, <OriginAddress>, <OriginZip>, <DestinationName>, <DestinationCity>, <DestinationState>, <DestinationAddress>, <DestinationZip>, <Class>, <Description>, <Quantity>, <Weight> 
	Then I will see the following new fields:
	| Field			|
	| Pickup Date:	|
	| Origin:		|
	| Destination:	|
	| Pieces:		|
	| Class/Weight: |
	And The elements are not editable
	Examples: 
	| Scenario | Date	  | OriginName                | OriginCity | OriginState | OriginAddress  | OriginZip | DestinationName | DestinationCity | DestinationState | DestinationAddress | DestinationZip | Class | NMFC | Description | Quantity | Weight |
	| s1       | Today	  | #1 MORGAN HIGHWAY AUTO PA | Chicago    | IL          | 400 MORGAN HWY | 18508     | 11THNAME        | Los Angeles     | CA               | 11thName12         | 90087          | 50    | 234  | test1       | 400      | 432    |

@GUI
Scenario Outline: Verify a shipment information bar displays at the top of the page with the data being associated with the correct fields 
	Given I am a shpentry sales sales management operations or station owner user
	And I am on the Shipment Results LTL page and have entered <Date>, <OriginName>, <OriginCity>, <OriginState>, <OriginAddress>, <OriginZip>, <DestinationName>, <DestinationCity>, <DestinationState>, <DestinationAddress>, <DestinationZip>, <Class>, <Description>, <Quantity>, <Weight> 
	When the shipment contains one unique class
	Then the Pickup Date field will be populated with the <Date> selected on the Add Shipment LTL page
	And the Originfield will be populated with the <OriginCity>, <OriginState>, <OriginZip> from the of the Add Shipment LTL page
	And the Destination field will be populated with the <DestinationCity>, <DestinationState>, <DestinationZip> fields from the Shipping To section of the Add Shipment LTL page
	And the Pieces field will be populated with the total of all values entered in the Enter a <Quantity> fields in the Freight Description section of the Add Shipment LTL page
	And the Class/Weight field will be populated with the values entered in the class and weight fields in the previous form <Class>, <Weight>
	And I will not see a More Information icon displayed in the Class Weight field of the shipment criteria
	Examples: 
	| Scenario | Date	  | OriginName                | OriginCity | OriginState | OriginAddress  | OriginZip | DestinationName | DestinationCity | DestinationState | DestinationAddress | DestinationZip | Class | Description | Quantity | Weight |
	| s1       | Today	  | #1 MORGAN HIGHWAY AUTO PA | Chicago    | IL          | 400 MORGAN HWY | 18508     | 11THNAME        | Los Angeles     | CA               | 11thName12         | 90087          | 50    | test1       | 400      | 432    |
	| s2       | Tomorrow | 11                        | Los Angeles| CA          | 11             | 30013     | APP             | Chicago		  | IL 		         | auu  		      | 33126		   | 60    | test2		 | 400	    | 432	 |

@GUI
Scenario Outline: Verify a shipment information bar displays at the top of the page and if there are more than one unique class a more information icon is displayed
	Given I am a shpentry sales sales management operations or station owner user
	And I am on the Shipment Results LTL page <Item Count>, <ItemClass>, <Description>, <Quantity>, <Weight>
	| ItemClass | Description | Quantity | Weight |
	| 50        | test1       | 1      | 432    |
	| 60        | test2       | 2      | 500    |
	| 70        | test3       | 3      | 600    |	
	When the shipment contains more than one unique class
	Then I will see a More Information icon displayed in the Class Weight field of the shipment criteria
	And I will see a pop up displaying the pieces class and weight of each unique class when I hover over the more information icon <Item Count>
	| ItemClassWeight | ItemQuantity |
	| 50/432 LBS      | 1            |
	| 60/500 LBS      | 2            |
	| 70/600 LBS      | 3            |	
	Examples: 
	| Item Count |
	|	   2     |
	|	   3     |