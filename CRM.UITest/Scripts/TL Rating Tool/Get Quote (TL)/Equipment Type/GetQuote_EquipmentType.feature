@24142 @Sprint65
Feature: GetQuote_EquipmentType
	
@Functional
Scenario Outline: Verify default selected option from Equipment type dropdown in get quote TL page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then I should see the <DefaultEquipmentType> selected as a default Equipment Type in dropdown 
	
Examples: 
| Scenario | Username    | Password | OriginZipCode | DestinationZipCode | Weight | DefaultEquipmentType | PickupDate |
| S1       | stationtest | Te$t1234 | 33126         | 85282              | 100    | 53 Ft Van Only       | 0          |

@Functional
Scenario Outline: Verify the options present in Equipment type dropdown in get quote TL page	
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then I should see all the options in Equipment Type dropdown <EquipmentOptions>
	
Examples: 
| Scenario | Username    | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate | EquipmentOptions                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| S1       | stationtest | Te$t1234 | 33126         | 85282              | 100    | 0          | 48 Ft Flatbed,48 Ft Step Deck,48 Ft Van Only,53 Ft Flatbed,53 Ft Step Deck,53 Ft Van Only,Air Freight,Cargo Van,20 IML Container,40 IML Container,53 IML Container,Flatbed,Flatbed Conestoga,Flatbed Drop Deck,Flatbed Low Boy,Flatbed Removal Gooseneck,Flatbed Step Deck,Partial,Volume Full Pup,Power Only,Reefer,Tanker,Straight or Box Truck,Van Only,Van Air Ride,Van Curtain Side,Logistics or E-Track Trailer,Plate Trailer,Van or Reefer,Vented Van |

@Functional 
Scenario Outline: Try to select any option from the Equipment type dropdown in get quote TL page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on Get Rate button in rating tool page
	And  I have click on Get Quote Now button in rating tool page
	Then I should able to select any option from the Equipment type dropdown <EquipmentOption>
	
Examples: 
| Scenario | Username    | Password | OriginZipCode | DestinationZipCode | Weight | EquipmentOption | PickupDate |
| S1       | stationtest | Te$t1234 | 33126         | 85282              | 100    | Vented Van      | 0          |