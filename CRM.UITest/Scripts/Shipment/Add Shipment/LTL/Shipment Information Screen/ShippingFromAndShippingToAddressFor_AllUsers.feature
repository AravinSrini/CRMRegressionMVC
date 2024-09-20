@ShippingFromAndShippingToAddressFor_AllUsers @Sprint69

Feature: ShippingFromAndShippingToAddressFor_AllUsers

#------------------------------------------------Shipping From Address-------------------------------------------------------#
	
@27952 @DBVerification @Functional
Scenario Outline: Verify the top 100 addresses under Origin addresses dropdown should match with top 100 address of Database
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on origin saved address dropdown of the Shipment
Then the top hundred addresses are displayed under Origin saved addresses should match with Database for the Customer Account Name selected of the Shipment<Customer_Name>
Examples: 
| Scenario | Username               | Password | Customer_Name | UserType |
| s1       | shpentry@test.com      | Te$t1234 | Dunkin Donuts | External |
| s2       | salesmanager@stage.com |Te$t1234 | Dunkin Donuts | Internal |

@27952 @DBVerification @Functional
Scenario Outline: Select any saved Origin address and verify the populated data
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on origin saved address dropdown of the Shipment
And I select any address from the origin saved address dropdown of the Shipment
Then the selected address should be populated in the Origin Address fields of the Shipment<Customer_Name>
And I unable to select another saved address from the Origin Address dropdown
And the Shipping from Contact Info section will be expanded and User able to see Contact Info fields
And I able to edit Shipping from Location and Contacts Fields<_locName>,<_address1>,<_address2>,<_city>,<_state>,<Zip_PostalCode>,<_country>,<_comments>,<_contactName>,<_contactPhone>,<_contactEmail>,<_contactFax>

Examples: 
| Scenario | Username				| Password          | UserType	   | Customer_Name | _locName      | _address1    | _address2    | _city        | _state         | Zip_PostalCode | _country      | _comments     | _contactName | _contactPhone | _contactEmail | _contactFax |
| s1       | shpentry@test.com		| Te$t1234		   | External      | Dunkin Donuts | testloc	   | testaddress1 | testaddress2 | testcity		| AZ             | 33333		  | United States | testcomments  |testcontname  | 9999000088    | s@s.com       | 7890567822 |
| s2       | salesmanager@stage.com | Te$t1234		   | Internal      | Dunkin Donuts |testloc	       | testaddress1 | testaddress2 | testcity		| AZ             | 33333		  | United States | testcomments  |testcontname  | 9999000088    | s@s.com       | 7890567822 |

@27952 @DBVerification @Functional
Scenario Outline: Verify the top 100 saved Address loaded for the entered search in the Saved Origin Address dropdown
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on origin saved address dropdown of the Shipment
And I enter a search criteria '<searchText>' in the Origin saved address field of the Shipment
Then the top Hundred Address loaded in the Origin dropdown for the entered search<Customer_Name>,<searchText>

Examples: 
| Scenario | Username                  | Password | UserType | searchText | Customer_Name |
| s1       | shpentry@test.com         | Te$t1234 | External | vtest      | Dunkin Donuts |
| s2       | salesmanager@stage.com	   | Te$t1234 | Internal | vtest      | Dunkin Donuts |

#------------------------------------------------Shipping To Address-------------------------------------------------------#
@27952 @DBVerification @Functional
Scenario Outline: Verify the top 100 addresses under destination addresses dropdown should match with top 100 address of Database
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on destination saved address dropdown of the Shipment
Then the top hundred addresses are displayed under destination saved addresses should match with Database for the Customer Account Name selected of the Shipment<Customer_Name>
Examples: 
| Scenario | Username				| Password		   | UserType      | Customer_Name |
| s1       | shpentry@test.com		| Te$t1234		   | External      | Dunkin Donuts |
| s2       | salesmanager@stage.com | Te$t1234		   | Internal      | Dunkin Donuts |


@27952 @DBVerification @Functional
Scenario Outline: Select any saved Destination address and verify the populated data
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on destination saved address dropdown of the Shipment
And I select any address from the destination saved address dropdown of the Shipment
Then the selected address should be populated in the destination Address fields of the Shipment<Customer_Name>
And I unable to select another saved address from the destination Address dropdown
And the Shipping To Contact Info section will be expanded and User able to see Contact Info fields
And I able to edit Shipping to Location and Contacts Fields<_locName>,<_address1>,<_address2>,<_city>,<_state>,<Zip_PostalCode>,<_country>,<_comments>,<_contactName>,<_contactPhone>,<_contactEmail>,<_contactFax>

Examples: 
| Scenario | Username				| Password          | UserType	   | Customer_Name | _locName      | _address1    | _address2    | _city        | _state         | Zip_PostalCode | _country      | _comments     | _contactName | _contactPhone | _contactEmail | _contactFax |
| s1       | shpentry@test.com		| Te$t1234		   | External      | Dunkin Donuts | testloc	   | testaddress1 | testaddress2 | testcity		| AZ             | 33333		  | United States | testcomments  |testcontname  | 9999000088    | s@s.com       | 7890567822 |
| s2       | salesmanager@stage.com | Te$t1234		   | Internal      | Dunkin Donuts |testloc	       | testaddress1 | testaddress2 | testcity		| AZ             | 33333		  | United States | testcomments  |testcontname  | 9999000088    | s@s.com       | 7890567822 |


@27952 @DBVerification @Functional
Scenario Outline: Verify the top 100 saved Address loaded for the entered search in the Saved destination Address dropdown
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on destination saved address dropdown of the Shipment
And I enter a search criteria '<searchText>' in the destination saved address field of the Shipment
Then the top Hundred Address loaded in the destination dropdown for the entered search<Customer_Name>,<searchText>
Examples: 
| Scenario | Username                  | Password | UserType | searchText | Customer_Name |
| s1       | shpentry@test.com         | Te$t1234 | External | vtest      | Dunkin Donuts |
| s2       | salesmanager@stage.com	   | Te$t1234 | Internal | vtest      | Dunkin Donuts |

#------------------------------------------------------Default Shipper And Consignee------------------------------------------------------------

@27949 @Functional @DBVerification
Scenario Outline: Verify Shipping From section when user mapped account has default Shipper address
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
Then the address information of default Shipper address should auto-populate in the Shipping From section of Shipments<Customer_Name>
Examples: 
| Scenario | Username               | Password | UserType | Customer_Name            |
| s1       | zzzext@user.com        | Te$t1234 | External | ZZZ - Czar Customer Test |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | ZZZ - Czar Customer Test |

@27949 @Functional @DBVerification
Scenario Outline: Verify Shipping From section when user mapped account does not have default Shipper address
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
Then The Shipper address information section should be empty for Shipments<Customer_Name>
Examples: 
| Scenario | Username          | Password | UserType | Customer_Name |
| s1       | shpentry@test.com | Te$t1234 | External | Dunkin Donuts |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | Dunkin Donuts |


@27949 @Functional @DBVerification
Scenario Outline: Verify shipping From dropdown when default Shipper address exists
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
Then shipping saved address dropdown should be binded to default Shipper address for Shipments<Customer_Name>
Examples: 
| Scenario | Username               | Password | UserType | Customer_Name      |
| s1       | zzzext@user.com        | Te$t1234 | External | ZZZ - Czar Customer Test |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | ZZZ - Czar Customer Test |



@27949 @Functional @DBVerification 
Scenario Outline: Verify Shipping To section when user mapped account has default Consignee address
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
Then The address information of default Consignee address should auto-populate in the Shipping To section of Shipments<Customer_Name>
Examples: 
| Scenario | Username | Password | UserType | Customer_Name             |
| s1       | zzzext@user.com        | Te$t1234 | External | ZZZ - Czar Customer Test |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | ZZZ - Czar Customer Test |


@27949 @Functional @DBVerification
Scenario Outline: Verify Shipping To section when user mapped account does not have default consignee address
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
Then The consignee address information section should be empty for Shipments<Customer_Name>
Examples: 
| Scenario | Username               | Password | UserType | Customer_Name	|
| s1       | shpentry@test.com		| Te$t1234 | External | Dunkin Donuts   |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | Dunkin Donuts |



@27949 @Functional @DBVerification
Scenario Outline: Verify shipping To dropdown when default Consignee address exists
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
Then shipping saved address dropdown should be binded to default Consignee address for Shipments<Customer_Name>

Examples: 
| Scenario | Username               | Password | UserType | Customer_Name            |
| s1       | zzzext@user.com        | Te$t1234 | External | ZZZ - Czar Customer Test |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | ZZZ - Czar Customer Test |





#-------------------------------------------------Clear Address------------------------------------------------------------------
@27960 @GUI
Scenario Outline: Verify the fields are cleared in the Shipping from section up-on click on the Clear Address button in the Shipping from section
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on origin saved address dropdown of the Shipment
And I select any address from the origin saved address dropdown of the Shipment
And I have selected services and accessorials from the origin section<Accessorials>
Then clicking on Clear Address link must clear the address in the origin saved address field of the Shipment
And All populated fields will be cleared/reset in the Add Shipment LTL Shipping From section of the Shipment
Then Shipping From Contact Information section will be expanded

Examples: 
| Scenario | Username               | Password | UserType | Customer_Name            | Accessorials |
| s1       | shpentry@test.com		| Te$t1234 | External | Dunkin Donuts			 | Appointment  |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | Dunkin Donuts			 | Appointment  |


@27960 @GUI
Scenario Outline: Verify the Country dropdown is reset to United States up-on click on the Clear Address button in the Shipping from section
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on origin saved address dropdown of the Shipment
And I select any address from the origin saved address dropdown of the Shipment
Then clicking on Clear Address link must clear the address in the origin saved address field of the Shipment
And the Country will reset to United States in the Shipping From section of the Shipment
Examples: 
| Scenario | Username               | Password | UserType	| Customer_Name			 |
| s1       | shpentry@test.com		| Te$t1234 | External | Dunkin Donuts			 |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | Dunkin Donuts			 |


@27960 @GUI
Scenario Outline: Verify the fields are cleared in the Shipping To section up-on click on the Clear Address button in the Shipping To section
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on destination saved address dropdown of the Shipment
And I select any address from the destination saved address dropdown of the Shipment
And I have selected services and accessorials from the destination section<Accessorials>
Then clicking on Clear Address link must clear the address in the destination saved address field of the Shipment
And All populated fields will cleared/reset in the Add Shipment Shipping To section of the Shipment
Then Shipping To Contact Information section will be expanded

Examples: 
| Scenario | Username               | Password | UserType | Customer_Name | Accessorials |
| s1       | shpentry@test.com      | Te$t1234 | External | Dunkin Donuts | Appointment  |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | Dunkin Donuts | Appointment  |

@27960 @GUI
Scenario Outline: Verify the Country dropdown is reset to United States up-on click on the Clear Address button in the Shipping To section
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
And I have click on Add Shipment button based on User Type<UserType>
And I will be navigated to Add Shipment Tiles page
And I Click on LTL Tile page
And I will be navigated to Add Shipment LTL page
And I click on destination saved address dropdown of the Shipment
And I select any address from the destination saved address dropdown of the Shipment
Then clicking on Clear Address link must clear the address in the destination saved address field of the Shipment
And the Country will reset to United States in the Shipping To section of the Shipment
Examples: 
| Scenario | Username               | Password | UserType	|	Customer_Name      |
| s1       | shpentry@test.com		| Te$t1234 | External | Dunkin Donuts			 |
| s2       | salesmanager@stage.com | Te$t1234 | Internal | Dunkin Donuts			 |



#----------------------------Sprint 69-27959 Address/Zip code Lookup--------------------


@27959 @Functional @NinjaSprint17 @41033 
Scenario Outline: Verify zip code lookup auto populate functionality for the Shipping From section of Shipment Information page  -All Users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
    When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	When I enter zip code <ValidUSZip> and leave focus from the origin section in shipment request process
	Then City <City> and State <State> fields should be populated in origin section in shipment request process
	And I will be able to edit the city in shipping from section<ModifiedCity> in shipment request process
    And I will have the option to select a state from the state drop down list in shipping from section<ModifiedState> in shipment request process

Examples: 
| Scenario | Username   | Password | Service | ValidUSZip | City    | State | ModifiedCity | ModifiedState | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | 60606      | Chicago | IL    | MAIMI        | CA            | External |                          |
| s2       | stationown | Te$t1234 | LTL     | 60606      | Chicago | IL    | MAIMI        | CA            | Internal | ZZZ - Czar Customer Test |

@27959 @Functional @NinjaSprint17 @41033 
Scenario Outline: Verify zipcode lookup auto populate functionality for the Shipping To section of Shipment Information page  -All Users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	When I enter zip code <ValidUSZip> and leave focus from the destination section in shipment request process
	Then City <City> and State <State> fields should be populated in destination section in shipment request process
	And I will be able to edit the city in shipping to section<ModifiedCity> in shipment request process
    And I will have the option to select a state from the state drop down list in shipping to section<ModifiedState> in shipment request process

Examples: 
| Scenario | Username   | Password | Service | ValidUSZip | City    | State | ModifiedCity | ModifiedState | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | 60606      | Chicago | IL    | MAIMI        | CA            | External |                          |
| s2       | stationown | Te$t1234 | LTL     | 60606      | Chicago | IL    | MAIMI        | CA            | Internal | ZZZ - Czar Customer Test |


@27959 @Functional @NinjaSprint17 @41033 
Scenario Outline: Verify zip code text box on entering invalid zip in Shipping From section of Shipment Information page  -All Users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page	
	When I enter zip code <InvalidZip> and leave focus from the origin section in shipment request process
	Then background color of the origin zip code text box should turn red and error message should be displayed in shipment request process
	And  Origin City and State will not Auto populate  in shipment request process

Examples: 
| Scenario | Username   | Password | Service | InvalidZip | City    | State | ModifiedCity | ModifiedState | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | 11111      | Chicago | IL    | MAIMI        | CA            | External |                          |
| s2       | stationown | Te$t1234 | LTL     | 11111      | Chicago | IL    | MAIMI        | CA            | Internal | ZZZ - Czar Customer Test |

@27959 @Functional @NinjaSprint17 @41033 
Scenario Outline: Verify zip code text box on entering invalid zip in Shipping To section of Shipment Information page  -All Users
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page	
	When I enter zip code <InvalidZip> and leave focus from the destination section in shipment request process
	Then background color of the destination zip code text box should turn red and error message should be displayed in shipment request process
	And  Destination City and State will not Auto populate in shipment request process

Examples: 
| Scenario | Username   | Password | Service | InvalidZip | City    | State | ModifiedCity | ModifiedState | UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     | 11111      | Chicago | IL    | MAIMI        | CA            | External |                          |
| s2       | stationown | Te$t1234 | LTL     | 11111      | Chicago | IL    | MAIMI        | CA            | Internal | ZZZ - Czar Customer Test |

@27959 @Functional
Scenario Outline: Verify  Select State/Province drop down list will be populated with a list of Canada provinces in Shipping To section of Shipment Information page  -All Users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	When I select Canada Country from destination country drop down  in shipment request process	
    Then the Select State/Province drop down list will be populated with a list of Canada provinces  in Shipping To section  in shipment request process
 
Examples: 
| Scenario | Username   | Password | Service |  UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     |  External |                          |
| s2       | stationown | Te$t1234 | LTL     |  Internal | ZZZ - Czar Customer Test |


@27959 @Functional
Scenario Outline: Verify  Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section of Shipment Information page  -All Users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I clicked on the Shipment Module will be navigated to Shipment List page <UserType>
    And I have select any Customer Account from the drop down<UserType>,<Customer_Name>
    And I have click on Add Shipment button based on User Type<UserType>
    And I will be navigated to Add Shipment Tiles page
    And I Click on LTL Tile page
    And I will be navigated to Add Shipment LTL page
	When I select Canada Country from origin country drop down  in shipment request process
    Then the Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section in shipment request process

Examples: 
| Scenario | Username   | Password | Service |  UserType | Customer_Name            |
| S1       | zzzext     | Te$t1234 | LTL     |  External |                          |
| s2       | stationown | Te$t1234 | LTL     |  Internal | ZZZ - Czar Customer Test |	