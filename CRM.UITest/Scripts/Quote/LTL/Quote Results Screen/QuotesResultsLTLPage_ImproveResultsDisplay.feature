@NinjaSprint13 @39669
Feature: QuotesResultsLTLPage_ImproveResultsDisplay

#Scenarios : For External Users
@Regression
Scenario Outline: 39669_Verify_Carrier legal liability verbiage is changed to Carrier's legal liability per lb if uninsured for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier legal liability verbiage is Carrier's legal liability per lb if uninsured

Examples: 
| Scenario | UserType | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | both     | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The carrier max liability verbiage is changed to Carrier's max liability if uninsured for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier max liability verbiage is Carrier's max liability if uninsured

Examples: 
| Scenario | UserType | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | both     | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The carrier legal liability Currency value for New is formatted to xxx.xx for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier legal liability Currency value for New is formatted to xxx.xx

Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | both      | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The carrier legal liability Currency value for Used is formatted to xxx.xx for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier legal liability Currency value for Used is formatted to xxx.xx

Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | shipentry | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |
 
@Regression
Scenario Outline: 39669_Verify_The carrier max liability Currency value for New is formatted to xxx.xx for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier max liability Currency value for New is formatted to xxx.xx

Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | shipentry | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The carrier max liability Currency value for Used is formatted to xxx.xx for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier max liability Currency value for Used is formatted to xxx.xx

Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | shipentry | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The text color of the carrier liability information is in dark gray for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the text color of the carrier liability information is in dark gray

Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | both | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The service days is displayed with "days" to the right of the number of service days for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the service days is displayed with days to the right of the number of service days 
	
Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | shipentry | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The verbiage "Direct to Destination" is displayed as "Direct" and "Indirect to Destination" is displayed as "Indirect" for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the verbiage Direct to Destination is displayed as Direct and Indirect to Destination is displayed as Indirect
	
Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | shipentry | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The Insured Rate total is displayed in bold type
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify Insured Rate total is displayed in bold type for external user
	
Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | shipentry | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The Terms and Conditions link and verbiage "*Creating an insured shipment means you agree to the Terms and Conditions." is available at the bottom of the page
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And  I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And  I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the Terms and Conditions link and verbiage Creating an insured shipment means you agree to the Terms and Conditions. is available at the bottom of the page
	
Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | shipentry | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |


@Regression
Scenario Outline: 39669_Verify_The Terms and Conditions applicable to Default insurance all risk settings is displayed for External user
	Given I Am a shp.entry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	And I click on TermsAndConditions link at the bottom of the Quote results page
	Then I verify the Terms and Conditions applicable for default or customer specific insurance all risk settings is displayed
	
Examples: 
| Scenario | UserType  | OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | both | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

#Scenarios : For Internal Users
@Regression
Scenario Outline: 39669_Verify_Carrier legal liability verbiage is changed to Carrier's legal liability per lb if uninsured for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier legal liability verbiage is Carrier's legal liability per lb if uninsured

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |


@Regression
Scenario Outline: 39669_Verify_The carrier max liability verbiage is changed to Carrier's max liability if uninsured for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier max liability verbiage is Carrier's max liability if uninsured

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The carrier legal liability Currency value for New is formatted to xxx.xx for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier legal liability Currency value for New is formatted to xxx.xx

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The carrier legal liability Currency value for Used is formatted to xxx.xx for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier legal liability Currency value for Used is formatted to xxx.xx

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The carrier max liability Currency value for New is formatted to xxx.xx for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier max liability Currency value for New is formatted to xxx.xx

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The carrier max liability Currency value for Used is formatted to xxx.xx for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the carrier max liability Currency value for Used is formatted to xxx.xx

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The text color of the carrier liability information is in dark gray for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I Verify the text color of the carrier liability information is in dark gray

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The service days is displayed with "days" to the right of the number of service days for Internal user 
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the service days is displayed with days to the right of the number of service days 

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The verbiage "Direct to Destination" is displayed as "Direct" and "Indirect to Destination" is displayed as "Indirect" for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the verbiage Direct to Destination is displayed as Direct and Indirect to Destination is displayed as Indirect
	
Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The Estimated Margin total is displayed in bold type for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the Estimated Margin total is formatted to xxx.xx

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The Estimated Rate total is formatted to xxx.xx and displayed in bold type for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the Estimated Rate total is formatted to xxx.xx and displayed in bold type


Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The Rate total is displayed in bold type for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the Rate total is displayed in bold type
	
Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The Insured Rate total is displayed in bold type for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify Insured Rate total is displayed in bold type
	
Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The Terms and Conditions link and verbiage "*Creating an insured shipment means you agree to the Terms and Conditions." is available at the bottom of the page for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	Then I verify the Terms and Conditions link and verbiage Creating an insured shipment means you agree to the Terms and Conditions. is available at the bottom of the page

Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

@Regression
Scenario Outline: 39669_Verify_The Terms and Conditions applicable to Default insurance all risk settings is displayed for Internal user
	Given I am a sales, sales management, operations, or station owner user <UserType>
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	When I enter data in Origin section <OriginZip>, <OriginCity> and <OriginState>, <OriginCountry>
	And I enter data in Destination section <DestinationZip>, <DestinationCity> and <DestinationState>,<DestinationCountry>
	And I enter data in Item information section <Classification>, <Weight>, <WeightUnit>, <Quantity>, <QuantityUNIT>
	And I Click on View Quote Results button
	And I click on TermsAndConditions link at the bottom of the Quote results page
	Then I verify the Terms And Conditions applicable for default or customer specific insurance all risk settings is displayed
	
Examples: 
| Scenario | UserType        |    CustomerName			| OriginZip | OriginCity | OriginState | DestinationZip | DestinationState | DestinationCity | Classification | Weight | OriginCountry | DestinationCountry | Quantity | QuantityUNIT | WeightUnit |
| s1       | stationowner	 |  ZZZ - GS Customer Test  | 90001     | LOS ANGELS | CA          | 90001          | CA               | LOS ANGELS      | 60             | 23     | USA           | USA                | 1        | SKD          | lbs        |

#--------------------------------------------------------------------------#
#Scenarios for 90801 - Quotes - Insured Value T&C Update - PPP Customers
#--------------------------------------------------------------------------#

# Get Quote LTL Page
@90801
Scenario: 90801_Verify_The Terms and Conditions link in Get Quote LTL page applicable to PPP insurance all risk settings is displayed for external user
	Given I am a shp.entry or shp.inquiry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I entered a value in the Enter insured value field
	And the Terms and Conditions link was displayed
	When I click the Terms and Conditions link
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings is displayed

@90801
Scenario Outline: 90801_Verify_The Terms and Conditions link in Get Quote LTL page applicable to PPP insurance all risk settings is displayed for internal user
	Given I am a operations, station owner or sales Management user
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I entered a value in the Enter insured value field
	And the Terms and Conditions link was displayed
	When I click the Terms and Conditions link
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings is displayed

Examples: 
| CustomerName             |
| ZZZ - GS Customer Test | 

@90801
Scenario Outline: 90801_Verify_The Terms and Conditions link in Get Quote LTL page applicable to PPP insurance all risk settings is displayed for Sales user
	Given I am Sales user
	And I click on the Quote Icon
	And I Have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I entered a value in the Enter insured value field
	And the Terms and Conditions link was displayed
	When I click the Terms and Conditions link
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings is displayed

Examples: 
| CustomerName             |
| ZZZ - GS Customer Test |


# Quote Results LTL Page --> Insured Value entered in Get Quote LTL page
@90801
Scenario: 90801_Verify_The Terms and Conditions link next to Show Insured Rate button when Insured value is entered in Get Quote LTL page for PPP insurance all risk settings_external user
	Given I am a shp.entry or shp.inquiry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page
	And I entered a value in the Enter insured value field
	And I Click on View Quote Results button	
	When I click Terms and Conditions link next to Show Insured Rate button
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed 

@90801
Scenario Outline: 90801_Verify_The Terms and Conditions link next to Show Insured Rate button when Insured value is entered in Get Quote LTL page for PPP insurance all risk settings_internal user
	Given I am a operations, station owner or sales Management user
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page
	And I entered a value in the Enter insured value field	
	And I Click on View Quote Results button	
	When I click Terms and Conditions link next to Show Insured Rate button
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed

Examples: 
| CustomerName             |
| ZZZ - GS Customer Test | 

@90801
Scenario Outline: 90801_Verify_The Terms and Conditions link next to Show Insured Rate button when Insured value is entered in Get Quote LTL page for PPP insurance all risk settings_sales user
	Given I am Sales user
	And I click on the Quote Icon
	And I Have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page
	And I entered a value in the Enter insured value field
	And I Click on View Quote Results button	
	When I click Terms and Conditions link next to Show Insured Rate button
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed

Examples: 
| CustomerName             |
| ZZZ - GS Customer Test |


# Quote Results LTL Page --> Insured Value entered in Quote Results LTL page --> T&C link next to Show Insured rate
@90801
Scenario: 90801_Verify_The Terms and Conditions link next to Show Insured Rate button when Insured Value is entered in Quote Results LTL page for PPP insurance all risk settings_external user
	Given I am a shp.entry or shp.inquiry User
	And I click on the Quote Icon	
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page
	And I Click on View Quote Results button
	And I entered a value in the Enter insured value field
	When I click Terms and Conditions link next to Show Insured Rate button
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed

@90801
Scenario Outline: 90801_Verify_The Terms and Conditions link next to Show Insured Rate button when Insured Value is entered in Quote Results LTL page for PPP insurance all risk settings_internal user
	Given I am a operations, station owner or sales Management user
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page
	And I Click on View Quote Results button
	And I entered a value in the Enter insured value field
	When I click Terms and Conditions link next to Show Insured Rate button
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed

Examples: 
| CustomerName             |
| ZZZ - GS Customer Test |  

@90801
Scenario Outline: 90801_Verify_The Terms and Conditions link next to Show Insured Rate button when Insured Value is entered in Quote Results LTL page for PPP insurance all risk settings_Sales user
	Given I am Sales user
	And I click on the Quote Icon
	And I Have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page
	And I Click on View Quote Results button
	And I entered a value in the Enter insured value field
	When I click Terms and Conditions link next to Show Insured Rate button
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed

Examples: 
| CustomerName             |
| ZZZ - GS Customer Test |


# Quote Results LTL Page --> Insured Value entered in Quote Results LTL page --> T&C link at the bottom of the page
@90801
Scenario: 39669_Verify_The Terms and Conditions applicable to PPP insurance all risk settings_External user
	Given I am a shp.entry or shp.inquiry User
	And I click on the Quote Icon
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page		
	And I Click on View Quote Results button
	When I click on TermsAndConditions link at the bottom of the Quote results page
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed

@90801
Scenario Outline: 39669_Verify_The Terms and Conditions applicable to PPP insurance all risk settings_Internal user
	Given I am a operations, station owner or sales Management user
	And I click on the Quote Icon
	And I have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page	
	And I Click on View Quote Results button
	When I click on TermsAndConditions link at the bottom of the Quote results page
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed

Examples: 
| CustomerName             |
| ZZZ - GS Customer Test | 

@90801
Scenario Outline: 90801_Verify_The Terms and Conditions applicable to PPP insurance all risk settings_Sales user
	Given I am Sales user
	And I click on the Quote Icon
	And I Have selected the <CustomerName> from customer dropdown list
	And I have clicked on Submit Rate Request button
	And I click on Ltl Quote service Tile
	And I enter required data in the Get Quote LTL page
	And I Click on View Quote Results button
	When I click on TermsAndConditions link at the bottom of the Quote results page
	Then I verify the Terms and Conditions applicable to PPP insurance all risk settings displayed

Examples: 
| CustomerName             |
| ZZZ - GS Customer Test |