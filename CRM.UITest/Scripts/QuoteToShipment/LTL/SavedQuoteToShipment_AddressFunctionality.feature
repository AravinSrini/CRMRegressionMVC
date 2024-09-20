@SavedQuoteToShipment_AddressFunctionality @30527 @Sprint71 @API

Feature: SavedQuoteToShipment_AddressFunctionality
	
@Functional @Regression @DBVerification @API
Scenario Outline: 30527_Verify the saved address dropdown when quote doesnot contain saved address for shipping From location-ExternalUser
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then I should be able to select saved from the Shipping From drop down for the matching zip code of the saved quote <Account>

Examples: 
 | Username   | Password |   Account                | UserType |
| zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External |


@Functional @Regression @DBVerification @API
Scenario Outline: 30527_Verify the saved addressdrop down when quote doesnot contain saved address for shipping From location-InternalUser
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then I should be able to select saved from the Shipping From drop down for the matching zip code of the saved quote <Account>

Examples: 
| Username   | Password |   Account                | UserType |
| stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |
@Functional @Regression @DBVerification @API
Scenario Outline: 30527_Verify the search functionality for the shipping From location-InternalUser
Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page 
	Then Verify the search functionality for the Shipping From ZipCode <Account>
	

Examples: 
| Username   | Password |     Account              | UserType |
| stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |
@Functional @Regression @DBVerification @API
Scenario Outline: 30527_Verify the search functionality for the shipping From location-ExternalUser
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page 
	Then Verify the search functionality for the Shipping From ZipCode <Account>
	

Examples: 
| Username   | Password |     Account              | UserType |
| zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External |


@Functional @Regression @DBVerification @API
Scenario Outline: 30527_Verify the search functionality for the shipping To location-InternalUser
Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page 
    Then Verify the search functionality for the Shipping To ZipCode <Account>
	

Examples: 
| Username   | Password | Account                  | UserType |
| stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |
@Functional @Regression @DBVerification @API
Scenario Outline: 30527_Verify the search functionality for the shipping To location-ExternalUser
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page 
    Then Verify the search functionality for the Shipping To ZipCode <Account>
	

Examples: 
| Username   | Password | Account                  | UserType |
| zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External |

@Functional @Regression @API
Scenario Outline: 30527_Verify the auto Populated data when I select the saved address drop down in the shipping From location-ExternalUser
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	And I select saved address from the Shipping From for the matching zip code of the saved quote
	Then the data LocationName, LocationAddress,LocationAddress2 will be populated in the Shipping From section with the saved address and fields will be editable


Examples: 
| Username   | Password | Account                  | UserType |
| zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External |

@Functional @Regression @API
Scenario Outline: 30527_Verify the auto Populated data when I select the saved address drop down in the shipping From location-InternalUser
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	And I select saved address from the Shipping From for the matching zip code of the saved quote
	Then the data LocationName, LocationAddress,LocationAddress2 will be populated in the Shipping From section with the saved address and fields will be editable


Examples: 
 | Username   | Password | Account                  | UserType |
| stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |


@Functional @Regression @DBVerification @API
Scenario Outline: 30527_Verify the saved address dropdown selection when quote doesnot contain saved address for shipping To location-InternalUser
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then I should be able to select saved from the Shipping To drop down for the matching zip code of the saved quote <Account>

Examples: 
| Username   | Password |  Account                 | UserType |
 | stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |
@Functional @Regression @DBVerification @API
Scenario Outline: 30527_Verify the saved address dropdown selection when quote doesnot contain saved address for shipping To location-ExternalUser
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	Then I should be able to select saved from the Shipping To drop down for the matching zip code of the saved quote <Account>

Examples: 
| Username   | Password |  Account                 | UserType |
| zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External |


@Functional @Regression @API
Scenario Outline: 30527_Verify the auto populated data when I select the saved address drop down in the shipping To location-InternalUser
Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	And I select saved address from the Shipping To for the matching zip code of the saved quote
	Then the data LocationName, LocationAddress,LocationAddress2 will be populated in the Shipping To section with the saved address and fields will be editable
	

Examples: 
| Username   | Password | Account                  | UserType |
| stationown | Te$t1234 | ZZZ - Czar Customer Test | Internal |

@Functional @Regression @API
Scenario Outline: 30527_Verify the auto populated data when I select the saved address drop down in the shipping To location-ExternalUser
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
    And I am in the Quote Details Section of the non expired LTL quote <Account>,<UserType>
	And I click on the Create Shipment button
	When I arrive on the Add Shipment LTL page
	And I select saved address from the Shipping To for the matching zip code of the saved quote
	Then the data LocationName, LocationAddress,LocationAddress2 will be populated in the Shipping To section with the saved address and fields will be editable
	

Examples: 
| Username   | Password | Account                  | UserType |
 | zzzext     | Te$t1234 | ZZZ - Czar Customer Test | External |
