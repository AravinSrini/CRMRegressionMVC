 @22763 @Sprint64 @InsuredValue-LTLRateRequest @Acceptance @Functional
Feature: InsuredValue-LTLRateRequest

@Regression 	
Scenario Outline: Verify the Insured Value Tooltip on the Get Quote LTL page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then I must see the tool tip '<message>' when mousehover on the Question mark icon

Examples: 
| Scenario | Username        | Password | Service | message |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Normal method to determine insured value: Invoice Cost, plus Insurance Cost, plus any prepaid freight charges, all plus 10% |

@Regression 
Scenario Outline: Verify the drop down to select New or Used Insured Type
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field
Then the default value must be New 
And I must be able to see the options New or Used in the Insured Type drop down
And I must be able to select an option New or Used

Examples: 
| Scenario | Username        | Password | Service | Insuredvalue |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 1000         |

@Regression 
Scenario Outline: Verify the drop down to select Insured Type is disabled when Insured Value is not entered
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then the Insured Type drop down must be disabled as Insured Value is not entered yet

Examples: 
| Scenario | Username | Password     | Service |
| S1       | zzz      | Password@123 | LTL     |    
              