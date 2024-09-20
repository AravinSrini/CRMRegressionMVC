@Sprint68 @26536 
Feature: Shipment List- Page Elements _Customer Users

@GUI
Scenario Outline: Verify the existence of page elements in Shipment List page for Customer Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to view an option to Search filtered reports 
	And I must be able to view Show report filters
	And I must be able to view Hide report filters
	And I must be able to view Reference Number Lookup
	And I must have an option to search grid column data
	And I must be able to view clear all button
	And I must be able to view expected Search grid column dropdown values
	And I must be able to view Scheduled to Deliver and Scheduled to Pickup options
	And I must be able to view Start Date Calender Selector
	And I must be able to view End Date Calender Selector

Examples: 
| Scenario | Username                     | Password |
| S1       | zzzext@user.com              | Te$t1234 |
| S2       | Userinquiry@gmail.com        | Te$t1234 |
| S3       | UserEntryNorates@gmail.com   | Te$t1234 |
| S4       | Userinquirynorates@gmail.com | Te$t1234 |

@GUI
Scenario Outline:Verify the existence grid elements in Shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to view expected grid header values
	And I must be able to view Export button in Shipment list page
	And I must be able to view Export All and Export Displayed as export dropdown options
	And I must be able to view Shipment details button
	And I must be able to view More Information button

Examples: 
| Scenario | Username                     | Password |
| S1       | zzzext@user.com              | Te$t1234 |
| S2       | Userinquiry@gmail.com        | Te$t1234 |
| S3       | UserEntryNorates@gmail.com   | Te$t1234 |
| S4       | Userinquirynorates@gmail.com | Te$t1234 |

@GUI
Scenario Outline: verify the existence of Add shipment button for shp.entry, or shp.entrynorates users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to view Add Shipment button

Examples: 
| Scenario | Username                   | Password |
| S1       | zzzext@user.com            | Te$t1234 |
| S2       | UserEntryNorates@gmail.com | Te$t1234 |

@GUI
Scenario Outline: Verify the existence of Copy and return icon in the shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to view Copy icon displayed to the right of the destination column on the shipment row for LTL Shipments
	And I must be able to view Return icon displayed to the right of the destination column on the shipment row for LTL Shipments

Examples: 
| Scenario | Username                   | Password |
| S1       | zzzext@user.com            | Te$t1234 |
| S2       | UserEntryNorates@gmail.com | Te$t1234 |
