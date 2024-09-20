Feature: RateRequestToShipment_SavedItemDetails

@Functional @NinjaSprint15 @22177
Scenario Outline:22177_Verify the Item details are populated in Add Shipment Page while creating a standard shipment from Rate with saved item containing HazMat for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I arrive at external user Get Quote screen
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I arrive at Quote Results screen
	And I click on Create Shipment button for External User
	When I arrive on the Add Shipment LTL page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material details are auto-populated in the Freight Description Hazmat section <CustomerName> <Item>

Examples: 
| Scenario | UserType  | CustomerName             | Item           |
| s1       | shipentry | ZZZ - Czar Customer Test | TEST-HAZARDOUS |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a Insured shipment from Rate with saved item containing HazMat for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I arrive at external user Get Quote screen
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I enter Insured Value <ShipmentValue>
	And I arrive at Quote Results screen
	And I click on Create Insured Shipment button for External User
	When I arrive on the LTL Add Shipment page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material details are auto-populated in the Freight Description Hazmat section <CustomerName> <Item>

Examples: 
| Scenario | UserType  | CustomerName             | Item           | ShipmentValue |
| s1       | shipentry | ZZZ - Czar Customer Test | TEST-HAZARDOUS | 1000          |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a standard shipment from Rate with saved item not containing HazMat for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I arrive at external user Get Quote screen
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I arrive at Quote Results screen
	And I click on Create Shipment button for External User
	When I arrive on the Add Shipment LTL page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material is selected as NO

Examples: 
| Scenario | UserType  | CustomerName             | Item  | 
| s1       | shipentry | ZZZ - Czar Customer Test | NOHAZ |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a Insured shipment from Rate with saved item not containing HazMat for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I arrive at external user Get Quote screen
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I enter Insured Value <ShipmentValue>
	And I arrive at Quote Results screen
	And I click on Create Insured Shipment button for External User
	When I arrive on the LTL Add Shipment page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material is selected as NO

Examples: 
| Scenario | UserType  | CustomerName             | Item  | ShipmentValue |
| s1       | shipentry | ZZZ - Czar Customer Test | NOHAZ | 1000          |

#Scenarios when a saved item is selected and a field is modified for External users
@Functional @NinjaSprint15 @22177
Scenario Outline:22177_Verify the Item details are populated in Add Shipment Page while creating a standard shipment from Rate with saved item containing HazMat and Weight value is modified for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I arrive at external user Get Quote screen
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I Modify Weight field <DimensionValue>
	And I arrive at Quote Results screen
	And I click on Create Shipment button for External User
	When I arrive on the Add Shipment LTL page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material details are auto-populated in the Freight Description Hazmat section <CustomerName> <Item>

Examples: 
| Scenario | UserType  | CustomerName             | Item           | DimensionValue |
| s1       | shipentry | ZZZ - Czar Customer Test | TEST-HAZARDOUS | 10             |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a Insured shipment from Rate with saved item containing HazMat and Quantity value is modified for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I arrive at external user Get Quote screen
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I Modify Quantity field <DimensionValue>
	And I enter Insured Value <ShipmentValue>
	And I arrive at Quote Results screen
	And I click on Create Insured Shipment button for External User
	When I arrive on the LTL Add Shipment page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material details are auto-populated in the Freight Description Hazmat section <CustomerName> <Item>

Examples: 
| Scenario | UserType  | CustomerName             | Item           | ShipmentValue | DimensionValue |
| s1       | shipentry | ZZZ - Czar Customer Test | TEST-HAZARDOUS | 1000          | 10             |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a standard shipment from Rate with saved item not containing HazMat and Weight value is modified for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I arrive at external user Get Quote screen
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I Modify Weight field <DimensionValue>
	And I arrive at Quote Results screen
	And I click on Create Shipment button for External User
	When I arrive on the Add Shipment LTL page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material is selected as NO

Examples: 
| Scenario | UserType  | CustomerName             | Item  | DimensionValue |
| s1       | shipentry | ZZZ - Czar Customer Test | NOHAZ | 10             |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a Insured shipment from Rate with saved item not containing HazMat and Quantity value is modified for External user
	Given I am Shp.Inquiry, Shp.Entry user logged in to CRM Application <UserType>
	And I arrive at external user Get Quote screen
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I Modify Quantity field <DimensionValue>
	And I enter Insured Value <ShipmentValue>
	And I arrive at Quote Results screen
	And I click on Create Insured Shipment button for External User
	When I arrive on the LTL Add Shipment page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material is selected as NO

Examples: 
| Scenario | UserType  | CustomerName             | Item  | ShipmentValue | DimensionValue |
| s1       | shipentry | ZZZ - Czar Customer Test | NOHAZ | 1000          | 10             |

#Scenarios for Internal users
@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a standard shipment from Rate with saved item containing HazMat for Internal user
	Given I am operations, sales, sales management or station owner user logged in to CRM Application <UserType>
	And I arrive at internal user Get Quote screen <CustomerName>
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I arrive at Quote Results screen
	And I click on Create Shipment button for Internal User
	When I arrive on the Add Shipment LTL page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material details are auto-populated in the Freight Description Hazmat section <CustomerName> <Item>

Examples: 
| Scenario | UserType     | CustomerName             | Item           |
| s1       | stationowner | ZZZ - Czar Customer Test | TEST-HAZARDOUS | 

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a Insured shipment from Rate with saved item containing HazMat for Internal user
	Given I am operations, sales, sales management or station owner user logged in to CRM Application <UserType>
	And I arrive at internal user Get Quote screen <CustomerName>
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I enter Insured Value <ShipmentValue>
	And I arrive at Quote Results screen
	And I click on Create Insured Shipment button for Internal User
	When I arrive on the LTL Add Shipment page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material details are auto-populated in the Freight Description Hazmat section <CustomerName> <Item>

Examples: 
| Scenario | UserType     | CustomerName             | Item           | ShipmentValue |
| s1       | stationowner | ZZZ - Czar Customer Test | TEST-HAZARDOUS | 1000          |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a standard shipment from Rate with saved item not containing HazMat for Internal user
	Given I am operations, sales, sales management or station owner user logged in to CRM Application <UserType>
	And I arrive at internal user Get Quote screen <CustomerName>
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I arrive at Quote Results screen
	And I click on Create Shipment button for Internal User
	When I arrive on the Add Shipment LTL page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material is selected as NO

Examples: 
| Scenario | UserType     | CustomerName             | Item  |
| s1       | stationowner | ZZZ - Czar Customer Test | NOHAZ | 

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a Insured shipment from Rate with saved item not containing HazMat for Internal user
	Given I am operations, sales, sales management or station owner user logged in to CRM Application <UserType>
	And I arrive at internal user Get Quote screen <CustomerName>
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I enter Insured Value <ShipmentValue>
	And I arrive at Quote Results screen
	And I click on Create Insured Shipment button for Internal User
	When I arrive on the LTL Add Shipment page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material is selected as NO

Examples: 
| Scenario | UserType     | CustomerName             | Item  | ShipmentValue |
| s1       | stationowner | ZZZ - Czar Customer Test | NOHAZ | 1000          |

#Scenarios when a saved item is selected and a field is modified for Internal users
@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a standard shipment from Rate with saved item containing HazMat and Weight value is modified for Internal user
	Given I am operations, sales, sales management or station owner user logged in to CRM Application <UserType>
	And I arrive at internal user Get Quote screen <CustomerName>
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I Modify Weight field <DimensionValue>
	And I arrive at Quote Results screen
	And I click on Create Shipment button for Internal User
	When I arrive on the Add Shipment LTL page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material details are auto-populated in the Freight Description Hazmat section <CustomerName> <Item>

Examples: 
| Scenario | UserType     | CustomerName             | Item           | DimensionValue |
| s1       | stationowner | ZZZ - Czar Customer Test | TEST-HAZARDOUS | 10             |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a Insured shipment from Rate with saved item containing HazMat and Quantity value is modified for Internal user
	Given I am operations, sales, sales management or station owner user logged in to CRM Application <UserType>
	And I arrive at internal user Get Quote screen <CustomerName>
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I Modify Quantity field <DimensionValue>
	And I enter Insured Value <ShipmentValue>
	And I arrive at Quote Results screen
	And I click on Create Insured Shipment button for Internal User
	When I arrive on the LTL Add Shipment page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material details are auto-populated in the Freight Description Hazmat section <CustomerName> <Item>

Examples: 
| Scenario | UserType     | CustomerName             | Item           | ShipmentValue | DimensionValue |
| s1       | stationowner | ZZZ - Czar Customer Test | TEST-HAZARDOUS | 1000          | 10             |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a standard shipment from Rate with saved item not containing HazMat and Weight value is modified for Internal user
	Given I am operations, sales, sales management or station owner user logged in to CRM Application <UserType>
	And I arrive at internal user Get Quote screen <CustomerName>
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I Modify Weight field <DimensionValue>
	And I arrive at Quote Results screen
	And I click on Create Shipment button for Internal User
	When I arrive on the Add Shipment LTL page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material is selected as NO

Examples: 
| Scenario | UserType     | CustomerName             | Item  | DimensionValue |
| s1       | stationowner | ZZZ - Czar Customer Test | NOHAZ | 10             |

@Functional @NinjaSprint15 @22177
Scenario Outline: 22177_Verify the Item details are populated in Add Shipment Page while creating a Insured shipment from Rate with saved item not containing HazMat and Quantity value is modified for Internal user
	Given I am operations, sales, sales management or station owner user logged in to CRM Application <UserType>
	And I arrive at internal user Get Quote screen <CustomerName>
	And I enter Address data in Get Quote LTL Page
	And I select a saved item <Item>
	And I Modify Quantity field <DimensionValue>
	And I enter Insured Value <ShipmentValue>
	And I arrive at Quote Results screen
	And I click on Create Insured Shipment button for Internal User
	When I arrive on the LTL Add Shipment page
	Then Saved item details are auto-populated in the Freight Description section <CustomerName> <Item>
	And Hazardous material is selected as NO

Examples: 
| Scenario | UserType     | CustomerName             | Item  | ShipmentValue | DimensionValue |
| s1       | stationowner | ZZZ - Czar Customer Test | NOHAZ | 1000          | 10             |

    @GUI @49390 @PrioritySprint
	Scenario: Verify Rate to Shipment Freight Description binding when freight Information data entered manually in Get Quote(LTL)
    Given I am User with access to Rate To Shipment Process
	And I arrive at Get Quote(LTL) screen
	And I enter Address data in Get Quote LTL Page
	And I enter the Item details <Classification>,<Quantity>,<Weight>
	And I arrive at Quote Results screen
	And I Click on Create Shipment button
	And the Insured Modal popUp Appears
	And I click the Continue without Insured Rates button
	When I arrive on the Add Shipment LTL page
	Then I will see <Classification>,<Quantity>,<Weight> will be binded in the Freight Description section with data from Get Quote(LTL) page


	

