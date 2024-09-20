@Sprint68 @27229
Feature: ShipmentList_MoreInformation_StationUsers

@Functional @GUI
Scenario Outline: Verify the displaying fields under more information icon for MG shipment
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I search for any <Data> inside shipment search box
	And I click on information icon any MG shipment
	Then the information box will be displayed with the following fields - Quantity,Weight,Carrier


Examples: 
| Scenario | Username   | Password | Data |
| S1       | stationown | Te$t1234 | LTL  |
| S2       | Opstage    | Te$t1234 | LTL  |

@Functional @GUI
Scenario Outline: Verify the displaying fields under more information icon for CSA shipment
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I search for any <Data> inside shipment search box
	And I click on information icon any CSA shipment
	Then the information box will be displayed with the following fields - Quantity,Weight,Service Type,Service Level


Examples: 
| Scenario | Username   | Password | Data          |
| S1       | stationown | Te$t1234 | International |
| S2       | Opstage    | Te$t1234 | International |

@Functional @Regression @DBVerification
Scenario Outline: Compare and Verify the displaying data under more information icon for MG shipment for station owner
	Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I click on customer drop down in shipment list page
	And I select any customer account <Account> from the customer dropdown in shipment list
	And I search for any <Data> inside shipment search box
	And I click on information icon any MG shipment
	Then displaying data for Quantity,Weight,Carrier fields should match with API <Account>


Examples: 
| Username   | Password | Account                | Data |
| stationown |  | ZZZ - GS Customer Test | LTL  |


@Functional @Regression @DBVerification
Scenario Outline: Compare and Verify the displaying data under more information icon for MG shipment for OpStage user
	Given I Log in as Opstage user
	When I click on the Shipment Icon
	And I click on customer drop down in shipment list page
	And I select any customer account <Account> from the customer dropdown in shipment list
	And I search for any <Data> inside shipment search box
	And I click on information icon any MG shipment
	Then displaying data for Quantity,Weight,Carrier fields should match with API <Account>


Examples: 
| Username   | Password | Account                | Data |
| Opstage    |  | 32SP01-Steve Andrastek | LTL  |


@Functional @Regression @DBVerification
Scenario Outline: Compare and Verify the displaying data under more information icon for CSA shipment for stationowner
Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I click on customer drop down in shipment list page
	And I select any customer account <Account> from the customer dropdown in shipment list
	And I search for any <Data> inside shipment search box
	And I click on information icon any CSA shipment
	Then displaying data for Quantity,Weight,Service Type and Service Level fields should match with API <Account>


Examples: 
 | Data          | Account                |
| International | ZZZ - GS Customer Test |  
