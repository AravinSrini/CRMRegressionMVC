@DefaultSpecialInstructions_AllUsers @28050 @Sprint69 
Feature: DefaultSpecialInstructions_All Users

@GUI @Functional
Scenario Outline: Verify the Default Special Instructions field is present for Customer users-ExternalUser
	Given I am a shp.entry,shp.entrynorates user
    And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I arrive on the Add Shipment Ltl page
	Then I should see the Default Special Instruction field 	
	And The field is editable 

Examples: 
| service | user     | customername |
| LTL     | customer |              |

@GUI @Functional
Scenario Outline: Verify the Default Special Instructions field is present for Customer users-Operations user
	Given I am an operations, sales, sales management, or station owner user
    And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I arrive on the Add Shipment Ltl page
	Then I should see the Default Special Instruction field 	
	And The field is editable 

Examples: 
| service | user     | customername |
| LTL     | station  | prakash BOTH |

@GUI  @Functional 
Scenario Outline: Verify the Saved Default Special Instruction is displayed for Customer users
	Given I am a shp.entry,shp.entrynorates user of defaultinstructions
    And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I arrive on the Add Shipment Ltl page
	Then I should see the Default Special Instruction field with saved <default_text>	
	And The field is editable 

Examples: 
| service | default_text                                          | user     | customername |
| LTL     | Default Instruction set for this user                 | customer |              |

@GUI @Functional 
Scenario Outline: Verify the Saved Default Special Instruction is displayed for Customer-Operations User
	Given I am an operations, sales, sales management, or station owner user
    And I clicked on the Shipment Module will be navigated to Shipment List page
	And I click on Add Shipment button <user> of <customername>
	And I select the tiles <service> 
	When I arrive on the Add Shipment Ltl page
	Then I should see the Default Special Instruction field with saved <default_text>	
	And The field is editable 

Examples: 
| service | default_text                                          | user     | customername |
| LTL     | Default Special Instructions is set for this Customer | station  | Prakash MG   |

		   	
		   	





