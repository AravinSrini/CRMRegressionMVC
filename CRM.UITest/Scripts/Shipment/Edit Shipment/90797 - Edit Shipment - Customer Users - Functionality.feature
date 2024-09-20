@Sprint91 @90797 
Feature: 90797 - Edit Shipment - Customer Users - Functionality

Scenario Outline: 90797 - Verify if the user has access to Edit option when the LTL Shipment falls under the following status : Pending, Pre-Plan, Rated, Unscheduled, Tender Rejected, Scheduled 
	Given I am a Shp.entry, Shp.entrynorates user
	And I am on Shipment List page
	When The displayed LTL Shipment is in <StatusType> status
	Then I will have the option to edit the shipment

Examples: 
| StatusType  |
| Pending     |
| Scheduled   |
| Unscheduled |

#Scenario Outline: 90797 - Verify if the user has access to Edit option when the LTL Shipment falls under any of the status apart from the following status : Pending, Pre-Plan, Rated, Unscheduled, Tender Rejected, Scheduled 
#	Given I am a Shp.entry, Shp.entrynorates user
#	And I am on Shipment List page
#	When Displayed LTL Shipment is in <StatusType> status
#	Then I will not have an option to edit the shipment
#
#Examples: 
#| StatusType |
#| InTransit  |
#| Delivered  |
#| Booked     |

Scenario: 90797 - Verify the display of Add Shipment (LTL) page onclick of Edit shipment button for any eligible LTL shipment
	Given I am a shp.entry or shp.entrynorates user
	And I am on Shipment List page
	When I click on the Edit button for any eligible LTL shipment
	Then I will arrive on the Add Shipment (LTL) page
	And All of the data from the shipment will be auto-populated on the Add Shipment (LTL) page
	And All of the fields are editable
	And I will see the shipment number displayed
	And I will see verbiage indicating that the shipment is being edited

Scenario: 90797 - Verify the functionality of PickUp Date calander on Add Shipment (LTL) page of Edit Shipment 
	Given I am a shp.entry or shp.entrynorates user
	And I am on Shipment List page
	And I clicked on the Edit button for any eligible LTL shipment
	And I arrive on the Add Shipment (LTL) page
	When I click on the Pickup Date calendar
	Then I am Unable to Select a date prior to the date of the original shipment

Scenario: 90797 - Verify the display of Shipment Results page when the shipment has rates - Edit Shipment
	Given I am a shp.entry User
	And I am on Shipment List page
	And I clicked on the Edit button for any eligible LTL shipment
	And I clicked on the View Rates button on the Add Shipment (LTL) page
	When I arrive on the Shipment Results (LTL) page
	Then I have the option to select displayed carrier
	And I will see a Shipment Number displayed on shipment results page
	And I will see a Verbiage on Shipment Results page indicating that the shipment is being edited 
	And The Create Shipment button(s) will be renamed Update Shipment
	And The Create Insured Shipment button will be renamed Update Insured Shipment


Scenario Outline: 90797 - Verify the display of Review and Submit Page when the shipment has rates - Edit Shipment
	Given I am a shp.entry User
	And I am on Shipment List page
	And I clicked on the Edit button for any eligible LTL shipment
	And I clicked on the View Rates button on the Add Shipment (LTL) page
	And I am on Shipment Results (LTL) page
	When I click on either of the following buttons for any displayed carrier - <ShipmentType>
	Then I will arrive on the Review and Submit (LTL) page
	And I will see the shipment number displayed on Review and Shipment page
	And I will see verbiage on Review and Submit page indicating that the shipment is being edited
	And The Submit Shipment button will be renamed to Submit Updated Shipment button

Examples: 
| ShipmentType            |
| Update Shipment         |
| Update Insured Shipment |

Scenario: 90797 - Verify the display of Shipment Results page when the shipment has no rates - Edit Shipment
	Given I am a shp.entry User
	And I am on Shipment List page
	And I clicked on Edit button for any eligible LTL shipment
	And I clicked on the View Rates button on the Add Shipment (LTL) page
	And I arrived on the Shipment Results (LTL) page
	When There are no rates available for the shipment
	Then I have the option to update the shipment without carrier rates
	And Create Shipment without Carrier rate button will be renamed Update Shipment without Carrier rate button


Scenario: 90797 - Verify the display of Review and Submit page when the shipment has no rates - Edit Shipment 
	Given I am a shp.entrynorates user
	And I am on Shipment List page
	And I clicked on the Edit button for any eligible LTL shipment
	When I click on View Rates button on the Add Shipment (LTL) page
	Then I will arrive on the Review and Submit (LTL) page
	And I will see the shipment number displayed on Review and Shipment page
	And I will see verbiage on Review and Submit page indicating that the shipment is being edited
	And The Submit Shipment button will be renamed to Submit Updated Shipment button

Scenario: 90797 - Verify if the verbiage "You will receive a confirmation email shortly with the Bill of Lading attached." is displayed on Shipment Confirmation Page - Edit Shipment
	Given I am a shp.entry or shp.entrynorates user
	And I am on Shipment List page
	And I clicked on the Edit button for any eligible LTL shipment
	And I am on the Review and Submit (LTL) page
	And I Clicked on Submit Updated Shipment Button
	When I arrive on the Shipment Confirmation (LTL) page
	Then I will not see the Verbiage <You will receive a confirmation email shortly with the Bill of Lading attached.> on Shipment confirmation page

