@Sprint69 @27962
Feature: AddShipment_SaveOriginDestinationInformation_AllUsers

@GUI @Functional
Scenario Outline: Try to save any origin and destination address and verify the database
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I pass unique <CustomerAccName> <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
	And I expand arrow of the Shipping from contact info in add shipment ltl page
	And I enter <ContactName>, <ContactPhone>, <ContactEmail> and <ContactFax> in shipping from contact info section present in add shipment page
	And I check save origin information check box in shipping from location present in add shipment page
	And I pass unique <CustomerAccName> <DZip> <DName> <DAddress1> in shipping to location info section present in add shipment page
	And I expand arrow of the Shipping to contact info in add shipment ltl page
	And I enter <ContactName>, <ContactPhone>, <ContactEmail> and <ContactFax> in shipping to contact info section present in add shipment page
	And I check save destination information check box in shipping to location present in add shipment page
	And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
	And I click on View rates button in add shipment ltl page
	Then passed shipping from address should be saved in database <CustomerAccName> <OZip> <OName> <OAddress1> 
	And passed shipping to address should be saved in database <CustomerAccName> <DZip> <DName> <DAddress1> 

Examples: 
| Scenario | Username             | Password | UserType  | CustomerAccName              | OZip  | OName   | OAddress1 | DZip  | DName   | DAddress1 | Classification | NMFC | Quantity | Description | Weight | ContactName | ContactPhone   | ContactEmail | ContactFax     |
| S1       | hotlineuser@test.com | Te$t1234 | ShipEntry | Seaman Corp - Parent Company | 33126 | zzzname | address   | 85282 | zzzname | add       | 50             | 1234 | 1        | item 1      | 100    | test        | (123)-456-7890 | abc@test.com | (123)-456-7890 |

@GUI @Functional
Scenario Outline: Try to save any duplicate origin and destination address and verify the database
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I enter <OZip> <OName> <OAddress1> in shipping from location info section present in add shipment page
	And I expand arrow of the Shipping from contact info in add shipment ltl page
	And I enter <ContactName>, <ContactPhone>, <ContactEmail> and <ContactFax> in shipping from contact info section present in add shipment page
	And I check save origin information check box in shipping from location present in add shipment page
	And I enter <DZip> <DName> <DAddress1> in shipping to location info section present in add shipment page
	And I expand arrow of the Shipping to contact info in add shipment ltl page
	And I enter <ContactName>, <ContactPhone>, <ContactEmail> and <ContactFax> in shipping to contact info section present in add shipment page
	And I check save destination information check box in shipping to location present in add shipment page
	And I enter data in <Classification>,  <NMFC> , <Quantity>,  <Description> and <Weight> freight description present in add shipment page
	And I click on View rates button in add shipment ltl page
	Then passed shipping from address should not be saved in database <CustomerAccName> <OName>
	And passed shipping to address should not be saved in database <CustomerAccName> <DName>

Examples: 
| Scenario | Username             | Password | UserType  | CustomerAccName              | OZip  | OName   | OAddress1 | DZip  | DName   | DAddress1 | Classification | NMFC | Quantity | Description | Weight | ContactName | ContactPhone   | ContactEmail | ContactFax     |
| S1       | hotlineuser@test.com | Te$t1234 | ShipEntry | Seaman Corp - Parent Company | 33126 | zzzname | add       | 33126 | zzzname | add       | 50             | 1234 | 1        | item 1      | 100    | test        | (123)-456-7890 | abc@test.com | (123)-456-7890 |
