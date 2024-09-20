@32065 @sprint71
Feature: DomesticForwarding_AddShipment_ZipCodeLookup
	
@Functional
Scenario Outline: 32065 - Verify Domestic Forwarding Autozip functionality from Dashboard page
 Given I shp.entry user or shp.entryNorates <Username>,<Password>
When I select Domestic Forwarding service<Type> and Click on Create Shipment button from Dashboard page
Then origine city,state and country autopopulated for valid zipcode <ocity>,<ostate>,<ocountry>,<ozip>
And destination country, state and city fields must be populated for valid zipcode <dcity>, <dstate>, <dcountry>, <dzip>


Examples: 
| Scenario | Username      | Password | Type    | ocity       | ostate | ocountry      | ozip  |dcity |dstate |dcountry	 |dzip|
| s1       | Both@test.com | Te$t1234 | Economy | Los Angeles | CA     | United States | 90001 |Miami	|FL	|United States|33130|



@Functional
Scenario Outline: 32065 - Verify Domestic Forwarding Autozip functionality from Shipment List page
Given I shp.entry user or shp.entryNorates <Username>,<Password>
When I select Domestic Forwarding service<Type> from Add Shipment page
Then origine city,state and country autopopulated for valid zipcode <ocity>,<ostate>,<ocountry>,<ozip>
And destination country, state and city fields must be populated for valid zipcode <dcity>, <dstate>, <dcountry>, <dzip>

Examples: 
| Scenario | Username              | Password       | Type        | ocity       | ostate | ocountry      | ozip |dcity | dstate | dcountry      | dzip  |
| s1       |  Both@test.com        |    Te$t1234    | Economy     | Los Angeles | CA     | United States | 90001|Miami | FL     | United States | 33130 |