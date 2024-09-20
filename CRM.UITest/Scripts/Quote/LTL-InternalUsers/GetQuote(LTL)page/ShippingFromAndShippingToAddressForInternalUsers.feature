@ShippingFromAndShippingToAddressForInternalUsers @Sprint67
Feature: ShippingFromAndShippingToAddressForInternalUsers


#===================================Shipping From saved address-sataion users=======================
	
@Regression 
Scenario Outline: Select any saved Origin address and verify the populated data for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on origin saved address dropdown 
And I select any address from the origin saved address dropdown
Then selected address should be populated in the origin Address fields<Customer_Name>

Examples: 
| Scenario | Username               | Password | Customer_Name          | Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts          | LTL     |

@Regression 
Scenario Outline: Select any searched saved Origin address and verify the populated data for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on origin saved address dropdown
And I enter a search criteria '<searchText>' in the origin saved address field
And I select any address from the origin saved address dropdown
Then selected address for the search should be populated in the origin Address fields<Customer_Name>,<searchText>

Examples: 
| Scenario | Username               | Password | Customer_Name | Service | searchText   |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts | LTL     | VTESTINGNAME |

@Regression 
Scenario Outline: Verify the addresses displayed under Shipping From saved address dropdown should match with database for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on origin saved address dropdown
Then addresses displayed under origin saved addresses should match with database for the Customer Account Name selected<Customer_Name>

Examples: 
| Scenario | Username               | Password | Customer_Name  | Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts  | LTL     |

@Regression 
Scenario Outline: Verify the top 100 addresses displayed under origin addresses dropdown should match with top 100 address of Database for Internal Non-Admin Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on origin saved address dropdown
Then the top hundred addresses displayed under origin saved addresses should match with Database for the Customer Account Name selected<Customer_Name>

Examples: 
| Scenario | Username               | Password | Customer_Name | Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts | LTL     |

#==================================Shipping From Clear Address-stations users======================

@Regression 
Scenario Outline: Verify the fields are cleared in the Shipping from section up-on click on the Clear Address button in the Shipping from section for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on origin saved address dropdown
And I select any address from the origin saved address dropdown
Then clicking on Clear Address link must clear the address in the origin saved address field
And All populated fields will cleared/reset in the Shipping From section

Examples: 
| Scenario | Username               | Password | Customer_Name | Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts | LTL     |

@Regression 
Scenario Outline: Verify the Country dropdown is reset to United States in the Shipping from section up-on click on the Clear Address button in the Shipping from section for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I select Origin Country as Canada
Then clicking on Clear Address link must clear the address in the origin saved address field
And the Country will reset to United States in the Shipping From section


Examples: 
| Scenario | Username               | Password | Customer_Name | Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts | LTL     |

#==================================Shipping To Clear Address-stations users======================
@Regression 
Scenario Outline: Verify the fields are cleared in the Shipping To section up-on click on the Clear Address button in the Shipping To section for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on destination saved address dropdown
And I select any address from the destination saved address dropdown
Then clicking on Clear Address link must clear the address in the destination saved address field
And All populated fields will cleared/reset in the Shipping To section

Examples: 
| Scenario | Username               | Password | Customer_Name | Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts | LTL     |


@Regression 
Scenario Outline: Verify the Country dropdown is reset to United States in the Shipping To section up-on click on the Clear Address button in the Shipping To section for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I select destination Country as Canada
Then clicking on Clear Address link must clear the address in the destination saved address field
And the Country will reset to United States in the Shipping To section

Examples: 
| Scenario | Username               | Password | Customer_Name | Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts | LTL     |

#===================================Shipping To saved address-sataion users=======================

@Regression 
Scenario Outline: Select any saved destination address and verify the populated data for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on destination saved address dropdown 
And I select any address from the destination saved address dropdown
Then selected address should be populated in the destination Address fields<Customer_Name>

Examples: 
| Scenario | Username               | Password | Customer_Name        	| Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts          | LTL     |

@Regression 
Scenario Outline: Select any searched saved destination address and verify the populated data for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on destination saved address dropdown
And I enter a search criteria '<searchText>' in the destination saved address field
And I select any address from the destination saved address dropdown
Then selected address for the search should be populated in the destination Address fields<Customer_Name>,<searchText>

Examples: 
| Scenario | Username               | Password | Customer_Name | Service | searchText   |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts | LTL     | VTESTINGNAME |

@Regression 
Scenario Outline: Verify the addresses displayed under Shipping To saved address dropdown should match with database for Internal Non-Admin Users

Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on destination saved address dropdown
Then addresses displayed under destination saved addresses should match with database for the Customer Account Name selected<Customer_Name>

Examples: 
| Scenario | Username               | Password | Customer_Name        	| Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts          | LTL     |


@Regression 
Scenario Outline: Verify the top 100 addresses displayed under destination addresses dropdown should match with top 100 address of Database for Internal Non-Admin Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on destination saved address dropdown
Then the top hundred addresses displayed under destination saved addresses should match with Database for the Customer Account Name selected<Customer_Name>

Examples: 
| Scenario | Username               | Password | Customer_Name         	| Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts          | LTL     |

#====================================RateRequest_DefaultShipper/Consignee========================

@Regression 
Scenario Outline: Verify Shipping From section when user mapped account has default Shipper address for Internal Non-Admin Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
	Then the address information of default Shipper address should auto-populate in the Shipping From section for Internal Non-Admin Users<Customer_Name>

Examples: 
| Scenario | Username               | Password | Service | Customer_Name      |
| s1       | SalesManager@stage.com | Te$t1234 | LTL     |    Dunkin Donuts   |

@Regression 
Scenario Outline: Verify Shipping From section when user mapped account does not have default Shipper address for Internal Non-Admin Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
	Then The Shipper address information section should be empty for Internal Non-Admin Users<Customer_Name>

Examples: 
| Scenario | Username               | Password | Service | Customer_Name                 |
| s1       | SalesManager@stage.com | Te$t1234 | LTL     |    American Analytical Labs   |



@Regression 
Scenario Outline: Verify shipping From dropdown when default Shipper address exists for Internal Non-Admin Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then shipping saved address dropdown should be binded to default Shipper address for Internal Non-Admin Users<Customer_Name>

Examples: 
| Scenario | Username               | Password | Service | Customer_Name            |
| s1       | SalesManager@stage.com | Te$t1234 | LTL     |    Dunkin Donuts   |



@Regression 
Scenario Outline: Verify Shipping To section when user mapped account has default Consignee address for Internal Non-Admin Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then The address information of default Consignee address should auto-populate in the Shipping To section for Internal Non-Admin Users<Customer_Name>

Examples: 
| Scenario | Username               | Password | Customer_Name            	| Service |
| s1       | SalesManager@stage.com | Te$t1234 | Dunkin Donuts          | LTL     |


@Regression 
Scenario Outline: Verify Shipping To section when user mapped account does not have default consignee address for Internal Non-Admin Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then The consignee address information section should be empty for Internal Non-Admin Users<Customer_Name> 

Examples: 
| Scenario | Username               | Password | Service | Customer_Name              |
| s1       | SalesManager@stage.com | Te$t1234 | LTL     | American Analytical Labs   |



@Regression 
Scenario Outline: Verify shipping To dropdown when default Consignee address exists for Internal Non-Admin Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
Then Shipping saved address dropdown should be binded to default Consignee address for Internal Non-Admin Users<Customer_Name>

Examples: 
| Scenario | Username               | Password | Service | Customer_Name      |
| s1       | SalesManager@stage.com | Te$t1234 | LTL     |    Dunkin Donuts   |
