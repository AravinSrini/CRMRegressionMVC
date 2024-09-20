@32146 @Regression @Sprint71
Feature: AddShipment_ReviewandSubmit_SubmitShipment
	
Scenario Outline: 32146_Verify the submit button functionality in Review and Submit Page
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	And I am on Review and Submit Page of Add Shipment process <type>, <OLocationName>, <OLocationAdd>,<OZip>, <DLocationName>, <DLocationAdd>, <DZip>, <PickupReady>, <PickupClose>, <DeliveryReady>, <DeliveryClose>, <Pieces>, <Weight>, <Length>, <Width>, <Height> and <ItemDesc>
	When I click on Submit button
	Then I must be displayed with Service, Type, Pick up date, House bill number and status on confirmation page
	And View Shipment details and House bill buttons must be displayed

Examples: 
| Username | Password | type     | OLocationName   | OLocationAdd | OZip  | DLocationName   | DLocationAdd | DZip  | PickupReady | PickupClose | DeliveryReady | DeliveryClose | Pieces | Weight | Length | Width | Height | ItemDesc |
    | both     | Te$t1234 | Same Day | o location name | o add        | 33126 | d location name | d add        | 85282 | 10:00 AM    | 11:00 AM    | 5:00 PM       | 6:00 PM       | 2      | 100    | 10     | 10    | 10     | item 1   |

Scenario Outline: 32146_Verify the Start New Shipment Entry button functionality on Confirmation page
	Given I am a shp.entry,shp.entrynorates, operations, sales, sales management or a station user- '<Username>','<Password>'
	And I am on Confirmation Page of Add Shipment process <type>, <OLocationName>, <OLocationAdd>,<OZip>, <DLocationName>, <DLocationAdd>, <DZip>, <PickupReady>, <PickupClose>, <DeliveryReady>, <DeliveryClose>, <Pieces>, <Weight>, <Length>, <Width>, <Height> and <ItemDesc>
	When I Click on Start New Shipment Entry button
	Then I must be navigated to Add Shipment Shipment Service page

Examples: 
| Username | Password | type     | OLocationName   | OLocationAdd | OZip  | DLocationName   | DLocationAdd | DZip  | PickupReady | PickupClose | DeliveryReady | DeliveryClose | Pieces | Weight | Length | Width | Height | ItemDesc |
|both | Te$t1234 | Same Day | o location name | o add        | 33126 | d location name | d add        | 85282 | 10:00 AM    | 11:00 AM    | 5:00 PM       | 6:00 PM       | 2      | 100    | 10     | 10    | 10     | item 1   |