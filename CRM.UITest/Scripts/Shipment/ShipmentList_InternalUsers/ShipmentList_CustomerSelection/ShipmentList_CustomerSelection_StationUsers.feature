@Sprint68 @27339
Feature: ShipmentList_CustomerSelection_StationUsers

@Functional @Regression @DBVerification
Scenario Outline: Compare and verify the displaying customer accounts with API for stationowners
	Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on customer drop down in shipment list page
	Then list of customers to which I am associated will be displayed and should match with database <StationData>

Examples: 
| Username   | Password | StationData |
| stationown |  | ZZZ,ZZX     |

@Functional @Regression @DBVerification
Scenario Outline: Compare and verify the displaying customer accounts with API for OpStage user
	Given I Log in as Opstage user
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on customer drop down in shipment list page
	Then list of customers to which I am associated will be displayed and should match with database <StationData>

Examples: 
 | Username   | Password | StationData |
| Opstage|  | ATW         |


@Functional @GUI
Scenario Outline: Verify default selected option in the customer dropdown list
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	Then All Customers option should be selected by default in shipment list page

Examples: 
| Scenario | Username   | Password |
| S1       | stationown | Te$t1234 |
| S2       | Opstage    | Te$t1234 | 

@Functional @Regression @DBVerification
Scenario Outline: MG account from customer station dropdown and verify shipment list with API-StationOwmer
	Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on customer drop down in shipment list page
	And I select any customer account <Account> from the customer dropdown in shipment list
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then all the associated past 30days MG shipments for the selected customer should be displayed and should match with API <Account> 

Examples: 
| Username   | Password | Option | Account                  |
| stationown | Te$t1234 | ALL    | ZZZ - Czar Customer Test |


@Functional @Regression @DBVerification
Scenario Outline: Select any MG account from customer station dropdown and verify shipment list with API
	Given I Log in as Opstage user
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on customer drop down in shipment list page
	And I select any customer account <Account> from the customer dropdown in shipment list
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then all the associated past 30days MG shipments for the selected customer should be displayed and should match with API <Account> 

Examples: 
 | Username   | Password | Option | Account                  |
| Opstage    | Te$t1234 | ALL    | 32SP01-Steve Andrastek   | 

@Functional @Regression @DBVerification
Scenario Outline: Select any CSA account from customer station dropdown and verify shipment list with API
Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on customer drop down in shipment list page
	And I select any customer account <Account> from the customer dropdown in shipment list
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then all the associated past 30days CSA shipments for the selected customer should be displayed and should match with API <Account> 

Examples: 
| Username   | Password | Option | Account           |
| stationown | Te$t1234 | ALL    | Kim Manufacturing |

@Functional @Regression @DBVerification
Scenario Outline: Select any account of TMS type both account from customer station dropdown and verify shipment list with API
	Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on customer drop down in shipment list page
	And I select any customer account <Account> from the customer dropdown in shipment list
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then all the associated past 30days MG and CSA shipments for the selected customer should be displayed and should match with API <Account> 

Examples: 
| Username   | Password | Option | Account                |
| stationown | Te$t1234 | ALL    | ZZZ - GS Customer Test |

@Functional @GUI
Scenario Outline: Try to select multiple accounts from customer station dropdown and verify quote list with API
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on customer drop down in shipment list page
	And I select any customer account <Account1> from the customer dropdown in shipment list
	And I click on customer drop down in shipment list page
	And I select All customers from the dropdown in shipment list page
	And I click on customer drop down in shipment list page
	And I select any customer account <Account2> from the customer dropdown in shipment list
	Then recently selected <Account2> should be binded in shipment list page

Examples: 
| Scenario | Username   | Password | Option | Account1          | Account2           |
| S1       | stationown | Te$t1234 | ALL    | Kim Manufacturing | The Clorox Company |


@Functional @GUI
Scenario Outline: Verify the grid when user does not have any mapped accounts
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	Then shipment list grid should be empty

Examples: 
| Scenario | Username        | Password |
| S1       | nostat@user.com | Te$t1234 |

@Functional @GUI
Scenario Outline: Verify the grid when user does not have any shipments
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on customer drop down in shipment list page
	And I select any customeraccount <Account> from the customer dropdown in shipment list
	Then message will be displayed in shipment list grid section along with <Account> name

Examples: 
| Scenario | Username   | Password | Account            |
| S1       | stationown | Te$t1234 | The Clorox Company |