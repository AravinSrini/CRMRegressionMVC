@Sprint71 @31092 @API
Feature: ShipmentList_ReturnShipment

@Functional @Regression
Scenario Outline: 31092-Verify the populated data in shipping from, shippint to and pickup section for return shipment functionality-InternalUser
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	When I click on the Yes button in the return shipment popup box,
	Then I will arrive on the Add Shipment (LTL) page,
	And I will see Shipping From section Location name,Location address, Location address line 2, Zip/postal code, Country, City, State/province  populated with Shipping To details of the original shipment
	And I will see Shipping to section Location name,Location address, Location address line 2, Zip/postal code, Country, City, State/province  populated with Shipping from details of the original shipment
	And I will see default Pickup Date to today's date, ready time to 8PM and close time to 5PM

Examples: 
 | Username   | Password | Account                  | UserType |
 |  |  | ZZZ - Czar Customer Test | Internal |
@Functional @Regression
Scenario Outline: 31092-Verify the populated data in shipping from, shippint to and pickup section for return shipment functionality-ExternalUser
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	When I click on the Yes button in the return shipment popup box,
	Then I will arrive on the Add Shipment (LTL) page,
	And I will see Shipping From section Location name,Location address, Location address line 2, Zip/postal code, Country, City, State/province  populated with Shipping To details of the original shipment
	And I will see Shipping to section Location name,Location address, Location address line 2, Zip/postal code, Country, City, State/province  populated with Shipping from details of the original shipment
	And I will see default Pickup Date to today's date, ready time to 8PM and close time to 5PM

Examples: 
| Username   | Password | Account                  | UserType |
| |  | ZZZ - Czar Customer Test | External |


@Functional @Regression
Scenario Outline: 31092-Verify the Freight Description and reference Section for return shipment functionality-InternalUser
Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	When I click on the Yes button in the return shipment popup box,
	Then I will arrive on the Add Shipment (LTL) page,
	And I will see Class, NMFC, Quantity, QuantityType, Item description, Weight, WeightType, Hazmat, Dimensions, Dimensions type of original shipment 
	And I will see default special instructions from the original shipment will be displayed <Account>

Examples: 
| Username   | Password | Account                  | UserType |
 |  |  | ZZZ - Czar Customer Test | Internal |

@Functional @Regression
Scenario Outline: 31092-Verify the Freight Description and reference Section for return shipment functionality-ExternalUser
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	When I click on the Yes button in the return shipment popup box,
	Then I will arrive on the Add Shipment (LTL) page,
	And I will see Class, NMFC, Quantity, QuantityType, Item description, Weight, WeightType, Hazmat, Dimensions, Dimensions type of original shipment 
	And I will see default special instructions from the original shipment will be displayed <Account>

Examples: 
 | Username   | Password | Account                  | UserType |
|      |  | ZZZ - Czar Customer Test | External |


@Functional
Scenario Outline: 31092 - Verify the edit functionality for the populated data in return shipment functionality
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	When I click on the Yes button in the return shipment popup box,
	Then I will arrive on the Add Shipment (LTL) page,
	And I will able to edit Shipping From section <SFLocationName>,<SFLocationAddress>, <SFLocationAddressLine2>, <SFZipPostalCode>, <SFCountry>, <SFCity> and <SFStateProvince>  populated data
	And I will able to edit Shipping To section <STLocationName>, <STLocationAddress>, <STLocationAddressLine2>, <STZipPostalCode>, <STCountry>, <STCity> and <STStateProvince> populated data
	And I will able to edit <Classification>, <NMFC>, <Quantity>, <QuantityType>, <ItemDesc>, <Weight>, <WeightType>, <Hazmat>, <Length>, <Width>, <Height> and <DimensionType> populated data 
	And I will abe able to edit <SpecialInst> populated data

Examples: 
| Scenario | Username   | Password | Account                  | UserType | SFLocationName | SFLocationAddress | SFLocationAddressLine2 | SFZipPostalCode | SFCountry     | SFCity | SFStateProvince | STLocationName | STLocationAddress | STLocationAddressLine2 | STZipPostalCode | STCountry     | STCity | STStateProvince | Classification | NMFC | Quantity | QuantityType | ItemDesc | Weight | WeightType | Hazmat | Length | Width | Height | DimensionType | SpecialInst  |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External | Ori name       | Ori Add 1         | Ori Add 2              | 33126           | United States | Miami  | FL              | Dest name      | Dest Add 1        | Dest Add 2             | 85282           | United States | Tempe  | AZ              | 50             | nmfc | 2        | Skids        | Item1    | 100    | LBS        | No     | 10     | 10    | 10     | IN            | Testing Inst |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal | Ori name       | Ori Add 1         | Ori Add 2              | 33126           | United States | Miami  | FL              | Dest name      | Dest Add 1        | Dest Add 2             | 85282           | United States | Tempe  | AZ              | 50             | nmfc | 2        | Skids        | Item1    | 100    | LBS        | No     | 10     | 10    | 10     | IN            | Testing Inst |

@Functional
Scenario Outline: 31092 - Verify the clear address, clear item and add additonal ref links for return shipment functionality
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	When I click on the Yes button in the return shipment popup box,
	Then I will arrive on the Add Shipment (LTL) page,
	And I will see the Clear Address button in the Shipping From section,
	And I will see the Clear Address button in the Shipping To section,
	And I will see the Clear Item button in the Freight Description section,
	And I am able to add additional reference numbers.

Examples: 
| Scenario | Username   | Password | Account                  | UserType |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |

@Functional
Scenario Outline: 31092 - Verify the shipping from and shipping to contact section for return shipment when data is not present
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page,
	Then the Shipping From Contact Info section will be collapsed, if shipment did not contain any Shipping From Contact Info
	And the Shipping To Contact Info section will be collapsed , if shipment did not contain any Shipping From Contact Info

Examples: 
| Scenario | Username   | Password | Account                  | UserType |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |

@Functional
Scenario Outline: 31092 - Verify the edit functionality shipping from contact section for return shipment functionality
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page,
	Then the Shipping From Contact Info section will be expanded, if shipment contained Shipping From Contact Info
	And all the fields in shipping from contact section <SFContactName>, <SFContactPhone>, <SFContactEmail> and <SFContactFax> are editable.

Examples: 
| Scenario | Username   | Password | Account                  | UserType | SFContactName | SFContactPhone | SFContactEmail | SFContactFax   |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External | O Con Name    | (111) 111-1111 | origin@rrd.com | (222) 111-1111 |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal | O Con Name    | (111) 111-1111 | origin@rrd.com | (222) 111-1111 |

@Functional
Scenario Outline: 31092 - Verify the shipping to contact section for return shipment functionality
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page,
	Then the Shipping To Contact Info section will be expanded, if shipment contained Shipping To Contact Info
	And all the fields shipping to contact section <STContactName>, <STContactPhone>, <STContactEmail> and <STContactFax> are editable.

Examples: 
| Scenario | Username   | Password | Account                  | UserType | STContactName | STContactPhone | STContactEmail | STContactFax   |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External | O Con Name    | (111) 111-1111 | origin@rrd.com | (222) 111-1111 |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal | O Con Name    | (111) 111-1111 | origin@rrd.com | (222) 111-1111 |

@Functional
Scenario Outline: 31092 - Verify the hazmat section for return shipment functionality
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page,
	Then the Hazardous Materials section will be expanded, if the shipment contained hazardous materials
	And the Hazardous Materials fields <UNNumb>, <CCNNumb>, <HazGroup>, <HazClass>, <HazName> and <HazPhone> are editable.

Examples: 
| Scenario | Username   | Password | Account                  | UserType | UNNumb | CCNNumb | HazGroup | HazClass | HazName | HazPhone       |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External | 1111   | 1234567 | II       | 1.1      | C Name  | (111) 111-1111 |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal | 1111   | 1234567 | II       | 1.1      | C Name  | (111) 111-1111 |

@Functional
Scenario Outline: 31092 - Verify the additional item section for return shipment functionality
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page,
	Then the Additional Item section will be expanded in the Freight Description section, if the shipment contained additional items
	And I will see the Remove Item button,
	And I am able to edit any information <Classification>, <NMFC>, <Quantity>, <QuantityType>, <ItemDesc>, <Weight>, <WeightType>, <Hazmat>, <Length>, <Width>, <Height> and <DimensionType> in the Additional Item section.

Examples: 
| Scenario | Username   | Password | Account                  | UserType | Classification | NMFC | Quantity | QuantityType | ItemDesc | Weight | WeightType | Hazmat | Length | Width | Height | DimensionType | SpecialInst |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External | 50             | nmfc | 2        | Skids        | item 2   | 100    | LBS        | No     | 10     | 10    | 10     | IN            | Test Inst   |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal | 50             | nmfc | 2        | Skids        | item 2   | 100    | LBS        | No     | 10     | 10    | 10     | IN            | Test Inst   |

@Functional
Scenario Outline: 31092 - Verify the hazmat details section for additional item section for return shipment functionality
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page,
	Then the Additional Item section will be expanded in the Freight Description section, if the shipment contained additional items
	And the Hazardous Materials section of the additional item will be expanded,, if the shipment contained additional hazmat 
	And the additional Hazardous Materials fields <UNNumb>, <CCNNumb>, <HazGroup>, <HazClass>, <HazName> and <HazPhone> are editable.

Examples: 
| Scenario | Username   | Password | Account                  | UserType | UNNumb | CCNNumb | HazGroup | HazClass | HazName | HazPhone       |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External | 1111   | 1234567 | II       | 1.1      | C Name  | (111) 111-1111 |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal | 1111   | 1234567 | II       | 1.1      | C Name  | (111) 111-1111 |

@Functional
Scenario Outline: 31092 - Verify the reference number section section for additional item section for return shipment functionality
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page,
	Then the Reference Numbers section will be expanded, if the shipment contained reference numbers
	And the reference numbers from the previous shipment will be populated in the corresponding reference number fields of the return shipment,
	And I am able to edit any of the <Ref1>, <Ref2> reference numbers,
	And I am able to add additional reference numbers.

Examples: 
| Scenario | Username   | Password | Account                  | UserType | Ref1   | Ref2   |
| S1       | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External | PO 123 | Gl 111 |
| S2       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal | PO 123 | Gl 111 |

@Functional
Scenario Outline: 31092 - Verify binding station and customer name for return shipment functionality
	Given I am an operations, sales, sales management, or station owner user <Username> and <Password>
	And I am on the Shipment List page,
	And I have clicked on the Return Shipment button of an LTL shipment <Account> <UserType>
	And I clicked on the Yes button in the return shipment popup box,
	When I arrive on the Add Shipment (LTL) page,
	Then the station name - customer name associated to shipment selected will be displayed <Account>

Examples: 
| Scenario | Username   | Password | Account                  | UserType |
| S1       | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |