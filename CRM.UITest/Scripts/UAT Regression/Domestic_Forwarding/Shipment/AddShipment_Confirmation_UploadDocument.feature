@32147 @Regression @Sprint71 @Ignore
Feature: AddShipment_Confirmation_UploadDocument


Scenario Outline: 32147- Verify the uploaded document in recently added page present in document repository
	Given I am on the Confirmation page of the Add Shipment process <Username>, <Password>, <Type>, <OLocationName>, <OLocationAdd>,<OZip>, <DLocationName>, <DLocationAdd>, <DZip>, <PickupReady>, <PickupClose>, <DeliveryReady>, <DeliveryClose>, <Pieces>, <Weight>, <Length>, <Width>, <Height> and <ItemDesc>
	And I have uploaded a document <Path>
	When I arrive on the Document repository page
	Then the recently uploaded document must be listed in the grid <docName>
	And the reference number must be the primary reference number of the shipment <docName>

Examples: 
| Username | Password | Type     | OLocationName   | OLocationAdd | OZip  | DLocationName   | DLocationAdd | DZip  | PickupReady | PickupClose | DeliveryReady | DeliveryClose | Pieces | Weight | Length | Width | Height | ItemDesc | Path                                                             | docName |
| both     | Te$t1234 | Same Day | o location name | o add        | 33126 | d location name | d add        | 85282 | 10:00 AM    | 11:00 AM    | 5:00 PM       | 6:00 PM       | 2      | 100    | 10     | 10    | 10     | item 1   | ..\\..\\Scripts\\TestData\\ShipmentConfirmation_Doc\\TestDoc.xls | TestDoc |

Scenario Outline: 32147 - Verify the uploaded document in BOL section present in document repository
	Given I am on the Confirmation page of the Add Shipment process <Username>, <Password>, <Type>, <OLocationName>, <OLocationAdd>,<OZip>, <DLocationName>, <DLocationAdd>, <DZip>, <PickupReady>, <PickupClose>, <DeliveryReady>, <DeliveryClose>, <Pieces>, <Weight>, <Length>, <Width>, <Height> and <ItemDesc>
	And I have uploaded a document <Path>
	When I arrive on the Document repository page
	And  I open the BOL folder
	Then the document is displayed <docName>
	And the reference number must be the primary reference number of the shipment <docName>

Examples: 
| Username | Password | Type     | OLocationName   | OLocationAdd | OZip  | DLocationName   | DLocationAdd | DZip  | PickupReady | PickupClose | DeliveryReady | DeliveryClose | Pieces | Weight | Length | Width | Height | ItemDesc | Path                                                             | docName |
| both     | Te$t1234 | Same Day | o location name | o add        | 33126 | d location name | d add        | 85282 | 10:00 AM    | 11:00 AM    | 5:00 PM       | 6:00 PM       | 2      | 100    | 10     | 10    | 10     | item 1   | ..\\..\\Scripts\\TestData\\ShipmentConfirmation_Doc\\TestDoc.xls | TestDoc |
