@Sprint83 @44615
Feature: Insurance Claims - Claim Details - Forwarding
	

@Functional
Scenario: 44615 - Verify the save functionality by editing the Forwarding-Specific Fields
	Given I am a Claims Specialist user
	And I am on Claim Details page,
	And I have edited Forwarding-Specific Fields - Airline
	And I have edited Forwarding-Specific Fields - Pickup Carrier
	And I have edited Forwarding-Specific Fields - Delivery Carrier
	And I have edited Forwarding-Specific Fields - Steamship Line
	And I have edited Forwarding-Specific Fields - Freight Forwarder
	And I have edited Forwarding-Specific Fields - White Glove Agent
	When I click on Save Claim Details button
	Then edited data should be saved
	

Scenario Outline: 44615 - Verify the save functionality when user edits any of the Forwarding specific fields
	Given I am a Claims Specialist user
	And I am on Claim Details page,
	And I have made an edit to any of the Forwarding specific fields <ForwardingField>
	When I click on Save Claim Details button
	Then edited data should be saved

Examples:
| ForwardingField   |
| Airline           |
| Delivery Carrier  |
| Steamship Line    |
| Freight Forwarder |
| White Glove Agent |


