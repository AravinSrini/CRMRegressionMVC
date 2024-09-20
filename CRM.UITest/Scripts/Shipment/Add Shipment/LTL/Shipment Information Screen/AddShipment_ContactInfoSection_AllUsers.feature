@Sprint69 @27966 
Feature: AddShipment_ContactInfoSection_AllUsers

@GUI 
Scenario Outline: Verify the shipping from and shipping to contact section 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	Then Shipping From Contact Info and Shipping To Contact Info sections should be collapsed

Examples: 
| Scenario | Username     | Password | UserType  | CustomerAccName |
| S1       | datanoentry  | Te$t1234 | ShipEntry |                 |
| S2       | crmOperation | Te$t1234 | Operation | Dunkin Donuts   |

@GUI 
Scenario Outline: Verify the fields displaying in shipping from contact section 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I expand arrow of the Shipping from contact info in add shipment ltl page
	Then Contact Name, Contact Phone, Contact Email and Contact fax fields should be displayed in shipping from section

Examples: 
| Scenario | Username     | Password | UserType  | CustomerAccName |
| S1       | datanoentry  | Te$t1234 | ShipEntry |                 |
| S2       | crmOperation | Te$t1234 | Operation | Dunkin Donuts   |

@GUI 
Scenario Outline: Verify the fields displaying in shipping To contact section 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I expand arrow of the Shipping to contact info in add shipment ltl page
	Then Contact Name, Contact Phone, Contact Email and Contact fax fields should be displayed in shipping to section

Examples: 
| Scenario | Username     | Password | UserType  | CustomerAccName |
| S1       | datanoentry  | Te$t1234 | ShipEntry |                 |
| S2       | crmOperation | Te$t1234 | Operation | Dunkin Donuts   |

@GUI @Functional
Scenario Outline: Pass invalid phone,email and fax format in shipping from contact section and verify the error message
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I expand arrow of the Shipping from contact info in add shipment ltl page
	And I enter <ContactName>, <ContactPhone>, <ContactEmail> and <ContactFax> in shipping from contact info section present in add shipment page
	And I click on View rates button in add shipment ltl page
	Then Contact Phone, Contact Email and Contact Fax in shipping from section should be highlighted
	And I should receive error popup in shipping from contact section 

Examples:
| Scenario | Username     | Password | UserType  | ContactName | ContactPhone | ContactEmail | ContactFax | CustomerAccName |
| S1       | datanoentry  | Te$t1234 | ShipEntry | test        | 123          | abc          | 123        |                 |
| S2       | crmOperation | Te$t1234 | Operation | test        | 123          | abc          | 123        | Dunkin Donuts   |

@GUI @Functional
Scenario Outline: Pass invalid phone,email and fax format in shipping to contact section and verify the error message
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I expand arrow of the Shipping to contact info in add shipment ltl page
	And I enter <ContactName>, <ContactPhone>, <ContactEmail> and <ContactFax> in shipping to contact info section present in add shipment page
	And I click on View rates button in add shipment ltl page
	Then Contact Phone, Contact Email and Contact Fax in shipping to section should be highlighted
	And I should receive error popup in shipping to contact section 

Examples: 
| Scenario | Username     | Password | UserType  | ContactName | ContactPhone | ContactEmail | ContactFax | CustomerAccName |
| S1       | datanoentry  | Te$t1234 | ShipEntry | test name   | 123          | abc          | 123        |                 |
| S2       | crmOperation | Te$t1234 | Operation | test        | 123          | abc          | 123        | Dunkin Donuts   |

@GUI @Functional
Scenario Outline: Verify the max characters for contact name phone,email and fax number fields in shipping to and shipping from section 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I Select the LTL tile
	And I expand arrow of the Shipping to contact info in add shipment ltl page
	And I expand arrow of the Shipping from contact info in add shipment ltl page
	Then max characters for Contact Phone, Contact Email and Contact Fax in shipping from section should match with the existing screen length	
	And max characters for Contact Phone, Contact Email and Contact Fax in shipping to section should match with the existing screen length

Examples: 
| Scenario | Username     | Password | UserType  | CustomerAccName |
| S1       | datanoentry  | Te$t1234 | ShipEntry |                 |
| S2       | crmOperation | Te$t1234 | Operation | Dunkin Donuts   |

