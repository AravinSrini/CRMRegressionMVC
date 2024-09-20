@29496 @Sprint70 @GUI
Feature: Est Revenue_Est Cost_Est Margin-No Carrier Rates - Station Users
	
Scenario Outline: Verify the Est Revenue,Est Cost and Est Margin fields when shipment does not have carrier rates on the shipment list page
Given I am a sales, sales management, operations, or station owner user <Username> <Password>
And I click on the Shipment icon
When I enter the '<RefNoWithoutRates>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I should see results for the entered reference numbers '<RefNoWithoutRates>'
Then the Est Revenue,Est Cost and Est Margin fields should be displayed as N/A

Examples: 
| Scenario | Username     | Password | ShipmentList_Header |  RefNoWithoutRates                   | 
| s1       | crmOperation | Te$t1234 | Shipment List       |  ZZX00206577                         |





