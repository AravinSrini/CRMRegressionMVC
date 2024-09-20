@27965 @Sprint69 
Feature: Add Shipment (LTL)_View OriginOrDestination Location - All Users

@Functional @mytest1
Scenario Outline: Verify the functionality of View Origin Location on Map button on Shipping from section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	And I click on clear address
	And I have entered all the required information in the Shipping from section - <LocationName>, <LocationAddress> and <Zipcode>
	When I Click on View Origin Location on Map button 
	Then I must be able to view a map based on Shipping from Informaion - <ShippingFromURL>
	And I must be able to view Origin name and address on the window - <OriginName_Address>

Examples: 
| Username        | Password | LocationName  | LocationAddress | Zipcode | ShippingFromURL             | OriginName_Address |
| zzzext@user.com | Te$t1234 | XCC Logistics | SA              | 33126   | https://www.google.com/maps | XCC+Logistics+SA   |

@Functional
Scenario Outline: Verify the functionality of View Origin Location on Map button without entering data in the Shipping From section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	And I click on clear address
	When I click on View Origin Location on Map button without entering all required fields on Shipping From section
	Then I should be able to view a popup reminder to enter all required information

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

@Functional @GUI
Scenario Outline: Verify the existence and functionality of Close button on the Popup remainder modal for Shipping From section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	And I click on clear address
	When I click on View Origin Location on Map button without entering all required fields on Shipping From section
	Then I should be able to view a popup reminder to enter all required information
	And I should be able to view a Close button on the popup reminder
	And I must be able to click on it and the modal should get closed

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |


@Functional
Scenario Outline: Verify the functionality of View Destination Location on Map button on Shipping To section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	And I click on clear address for destination section
	And I have entered all the required information in the Shipping To section - <LocationName>, <LocationAddress> and <Zipcode>
	When I Click on View Destination Location on Map button 
	Then I must be able to view a map based on Shipping To Informaion - <ShippingToURL>
	And I must be able to view Destination name and address on the window - <DestinationOriginName_Address>

Examples: 
| Username        | Password | LocationName  | LocationAddress | Zipcode | ShippingToURL               | DestinationOriginName_Address |
| zzzext@user.com | Te$t1234 | XCC Logistics | SA              | 33126   | https://www.google.com/maps | XCC+Logistics+SA              |


@Functional
Scenario Outline: Verify the functionality of View Destination Location on Map button without entering data in the Shipping To section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	And I click on clear address for destination section
	When I click on View Destination Location on Map button without entering all required fields on Shipping To section
	Then I should be able to view a popup reminder to enter all required destination information

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

@Functional @GUI
Scenario Outline: Verify the existence and functionality of Close button on the Popup remainder modal for Shipping To section 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	And I arrive and Shipment list page
	And I click on Add Shipment button
	And I Click on LTL service type
	And I arrive on Add shipment LTL page
	And I click on clear address for destination section
	When I click on View Destination Location on Map button without entering all required fields on Shipping To section
	Then I should be able to view a popup reminder to enter all required information for destination section
	And I should be able to view a Close button on destination map popup reminder
	And I must be able to click on Close button on destination map popup reminder and the modal should get closed

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |

