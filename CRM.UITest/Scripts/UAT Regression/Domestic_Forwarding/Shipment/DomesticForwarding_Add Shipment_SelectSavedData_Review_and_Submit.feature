@32069 @Sprint71 @Regression @DomesticForwarding_Add Shipment_SelectSavedData_Review_and_Submit
Feature: DomesticForwarding_Add Shipment_SelectSavedData_Review_and_Submit
	

@GUI
Scenario Outline: 32069 - Verify the Review and Submit Page Navigation functionality from Dashboard page
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	When I select Domestic Forwarding service<Type> and Click on Create Shipment button from Dashboard page
	And I click on Save and Continue button from Shipment Locations And Dates page<oAccessorial>,<dAccessorial>,<pickUpReadyTime>,<pickUpCloseTime>,<deliveryReadyTime>,<deliveryCloseTime>,<Item>
	Then I will be navigated to Review and Submit page

	Examples: 
| Username              | Password | Type    | oAccessorial     | dAccessorial      | pickUpReadyTime | pickUpCloseTime | deliveryReadyTime | deliveryCloseTime | Item     |
| Both@test.com         |  | Economy | Liftgate Pick-Up | Liftgate Delivery | 12:00 AM        | 12:30 AM        | 1:30 AM           | 2:00 AM           | ITEM12   |
@GUI
Scenario Outline: 32069 - Verify the Review and Submit Page Navigation functionality from Dashboard page for ShipEntryNoRates user
	Given I am shp.entryNorates
	When I select Domestic Forwarding service<Type> and Click on Create Shipment button from Dashboard page
	And I click on Save and Continue button from Shipment Locations And Dates page<oAccessorial>,<dAccessorial>,<pickUpReadyTime>,<pickUpCloseTime>,<deliveryReadyTime>,<deliveryCloseTime>,<Item>
	Then I will be navigated to Review and Submit page

	Examples: 
| Type    | oAccessorial     | dAccessorial      | pickUpReadyTime | pickUpCloseTime | deliveryReadyTime | deliveryCloseTime | Item     |
| Economy  | Liftgate Pick-Up | Liftgate Delivery | 12:00 AM        | 12:30 AM        | 1:30 AM           | 2:00 AM           | MYTest   |

@GUI
Scenario Outline: 32069 - Verify the Review and Submit Page Navigation functionality from Shipment List page
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	When I select Domestic Forwarding service<Type> from Add Shipment page
	And I click on Save and Continue button from Shipment Locations And Dates page<oAccessorial>,<dAccessorial>,<pickUpReadyTime>,<pickUpCloseTime>,<deliveryReadyTime>,<deliveryCloseTime>,<Item>
	Then I will be navigated to Review and Submit page

	Examples: 
| Username			   | Password | Type    | oAccessorial     | dAccessorial      | pickUpReadyTime | pickUpCloseTime | deliveryReadyTime | deliveryCloseTime | Item   |
| Both@test.com		   |  | Economy | Liftgate Pick-Up | Liftgate Delivery | 12:00 AM        | 12:30 AM        | 1:30 AM           | 2:00 AM           | ITEM12 |

@GUI
Scenario Outline: 32069 - Verify the Review and Submit Page Navigation functionality from Shipment List page for shipentrynorates user
	Given I am shp.entryNorates
	When I select Domestic Forwarding service<Type> from Add Shipment page
	And I click on Save and Continue button from Shipment Locations And Dates page<oAccessorial>,<dAccessorial>,<pickUpReadyTime>,<pickUpCloseTime>,<deliveryReadyTime>,<deliveryCloseTime>,<Item>
	Then I will be navigated to Review and Submit page

	Examples: 
 | Type    | oAccessorial     | dAccessorial      | pickUpReadyTime | pickUpCloseTime | deliveryReadyTime | deliveryCloseTime | Item   |
 | Economy  | Liftgate Pick-Up | Liftgate Delivery | 12:00 AM        | 12:30 AM        | 1:30 AM           | 2:00 AM           | MYTest	|
