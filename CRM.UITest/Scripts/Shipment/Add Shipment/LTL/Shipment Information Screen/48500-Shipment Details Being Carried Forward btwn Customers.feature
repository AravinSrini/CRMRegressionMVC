@48500 @PrioritySprint2 

Feature: 48500-Shipment Details Being Carried Forward between Customers
	

@GUI @Functional
Scenario Outline: 48500-Verify the Shipment Details is not Being Carried Forward between two Customers
Given I logged into CRM with <User1> mapped to <Customer1>
And I navigate to the Shipment List page for <User1> mapped to <Customer1>
And I arrive on the Add Shipment LTL page
And I click on the <CreateShipment> button on Shipment Results page for <User1>
And I Complete the Shipment
And I logout of CRM
And I login back into CRM with <User2> as different user mapped to <Customer2>
When I selected LTL shipemnt service type from Dashboard to create Shipment
Then the <Customer1> shipment details should not be prepopulated in the Add Shipment LTL page for <Customer2>
Examples: 
| User1        | Customer1                | User2        | Customer2                | CreateShipment |
| ExternalUser | ZZZ - Czar Customer Test | ExternalUser | ZZZ - GS Customer Test   | StandardRate   |
| InternalUser | ZZZ - GS Customer Test   | ExternalUser | ZZZ - Czar Customer Test | InsuredRate    |