@Sprint69 @29394 
Feature: AddShipmen_ServiceSelection_DomFor_CustomerUsers

@GUI @Functional
Scenario Outline: Compare and verify the displaying Domestic forwarding types 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I click on the Domestic Forwarding tile in add shipment page
	Then service type option should be displayed
	And I click on service type dropdown 
	And Displaying types should match with <ServiceOptions>

Examples:
| Scenario | Username         | Password | UserType         | ServiceOptions                                                                                                                         |
| S1       | datanoentry      | Te$t1234 | ShipEntry        | Next Flight Out,Same Day,Next Day,Next Day AM,2 Day,2 Day AM,3 Day,3 Day AM,Economy,White Glove,Hot Shot,Local,Full Truck Load,Charter |
| S2       | zzzcsa@stage.com | Te$t1234 | ShipEntryNoRates | Next Flight Out,Same Day,Next Day,Next Day AM,2 Day,2 Day AM,3 Day,3 Day AM,Economy,White Glove,Hot Shot,Local,Full Truck Load,Charter |

@GUI
Scenario Outline: Verify domestic forwarding type selection popup 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I click on the Domestic Forwarding tile in add shipment page
	Then service type option should be displayed
	And should have continue and close buttons

Examples:
| Scenario | Username         | Password | UserType         |
| S1       | datanoentry      | Te$t1234 | ShipEntry        |
| S2       | zzzcsa@stage.com | Te$t1234 | ShipEntryNoRates |

@GUI
Scenario Outline: Verify functionality of close button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I click on the Domestic Forwarding tile in add shipment page
	And I click on close button in service type popup
	Then popup should be closed and user should remain in add shipment page

Examples:
| Scenario | Username         | Password | UserType         |
| S1       | datanoentry      | Te$t1234 | ShipEntry        |
| S2       | zzzcsa@stage.com | Te$t1234 | ShipEntryNoRates |

@GUI
Scenario Outline: Verify the error message when service type is not selected
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I click on the Domestic Forwarding tile in add shipment page
	And I click on continue button in service type popup
	Then I should receive a message <ErrorMessage>
	And service type field should be highlighted

Examples:
| Scenario | Username         | Password | UserType         | ErrorMessage                          |
| S1       | datanoentry      | Te$t1234 | ShipEntry        | PLEASE ENTER ALL REQUIRED INFORMATION |
| S2       | zzzcsa@stage.com | Te$t1234 | ShipEntryNoRates | PLEASE ENTER ALL REQUIRED INFORMATION |


@GUI
Scenario Outline: Verify functionality of continue button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on add shipment button depending on the UserType <UserType> for the <CustomerAccName>
	And I click on the Domestic Forwarding tile in add shipment page
	And I select any <ServiceType> from the dropdown
	And I click on continue button in service type popup
	Then I should be navigated to the Domestic Forwarding Locations and Dates page
	And selected service type displayed at the top of the page <ServiceType>

Examples:
| Scenario | Username         | Password | ServiceType     | UserType         |
| S1       | datanoentry      | Te$t1234 | Next Flight Out | ShipEntry        |
| S2       | zzzcsa@stage.com | Te$t1234 | Hot Shot        | ShipEntryNoRates |
