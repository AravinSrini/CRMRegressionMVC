@Sprint90 @Regression @76048
Feature: Add Shipment (LTL) 2019 - Shipping FromTo - View Origin-Destination on Map.
	
Scenario Outline: 76048 - Verify the functionality of View Origin Location on Map button on Shipping from section for external user
	Given I am a shp.entry, shp.entrynorates User
	And I am on the Add Shipment (LTL) page for an external user
	And I have entered all required information in the Shipping From section  - <LocationName>, <LocationAddress> and <Zipcode>
	When I click On the view Origin on Map button
	Then I will arrive on the Map as the default,
	And I have the option of viewing a satellite image of the location, 
	And the origin name and address will be noted on the window - <OriginName_Address>

Examples: 
| LocationName  | LocationAddress | Zipcode | OriginName_Address |
| 1419 Westwood Blvd | Los Angeles | 90024   | Los+Angeles,+CA+90024  |


Scenario Outline: 76048 - Verify the functionality of View Origin Location on Map button on Shipping from section for Internal user
	Given I am a operations or station owner user
	And I am on the Add Shipment (LTL) page for internal user
	And I have entered all required information in the Shipping From section  - <LocationName>, <LocationAddress> and <Zipcode>
	When I click On the view Origin on Map button
	Then I will arrive on the Map as the default,
	And I have the option of viewing a satellite image of the location, 
	And the origin name and address will be noted on the window - <OriginName_Address>

Examples: 
| LocationName  | LocationAddress | Zipcode | OriginName_Address |
| 1419 Westwood Blvd | Los Angeles | 90024   | Los+Angeles,+CA+90024  |


Scenario Outline: 76048 - Verify the functionality of View Origin Location on Map button on Shipping from section for sales user
	Given I am a Sales User
	And I am on the Add Shipment (LTL) page for sales user
	And I have entered all required information in the Shipping From section  - <LocationName>, <LocationAddress> and <Zipcode>
	When I click On the view Origin on Map button
	Then I will arrive on the Map as the default,
	And I have the option of viewing a satellite image of the location, 
	And the origin name and address will be noted on the window - <OriginName_Address>

Examples: 
| LocationName  | LocationAddress | Zipcode | OriginName_Address |
| 1419 Westwood Blvd | Los Angeles | 90024   | Los+Angeles,+CA+90024  |


Scenario: 76048 - Verify the functionality of View Origin Location on Map button without entering data in the Shipping From section for external user
	Given I am a shp.entry, shp.entrynorates user
    And I am on the Add Shipment (LTL) page for an external user
	And I have Not entered all required information in the Shipping from section,
	When I click On the view Origin on Map button
	Then I will receive a pop up notification requesting that I enter all required information, 
	And the pop up notification modal will have a close button.

Scenario: 76048 - Verify the functionality of View Origin Location on Map button without entering data in the Shipping From section for internal user
	Given I am a operations or station owner user
	And  I am on the Add Shipment (LTL) page for internal user
	And  I have Not entered all required information in the Shipping from section,
	When I click On the view Origin on Map button
	Then I will receive a pop up notification requesting that I enter all required information, 
	And the pop up notification modal will have a close button.

Scenario: 76048 - Verify the functionality of View Origin Location on Map button without entering data in the Shipping From section for sales user
	Given I am a Sales User
	And  I am on the Add Shipment (LTL) page for sales user
	And I have Not entered all required information in the Shipping from section,
	When I click On the view Origin on Map button
	Then I will receive a pop up notification requesting that I enter all required information, 
	And the pop up notification modal will have a close button.


Scenario: 76048 - Verify the existence and functionality of Close button on the Popup remainder modal for Shipping From section for external user
	Given I am a shp.entry, shp.entrynorates user
    And I am on the Add Shipment (LTL) page for an external user
	And I have Not entered all required information in the Shipping from section,
	And I click On the view Origin on Map button
	And I received the pop up reminder to enter all required information, 
	When I click on the Close button of the pop up reminder modal, 
	Then the modal will close.

Scenario: 76048 - Verify the existence and functionality of Close button on the Popup remainder modal for Shipping From section for internal user
	Given I am a operations or station owner user
	And  I am on the Add Shipment (LTL) page for internal user
	And I have Not entered all required information in the Shipping from section,
	And I click On the view Origin on Map button
	And I received the pop up reminder to enter all required information, 
	When I click on the Close button of the pop up reminder modal, 
	Then the modal will close.

Scenario: 76048 - Verify the existence and functionality of Close button on the Popup remainder modal for Shipping From section for sales user
	Given I am a Sales User
	And  I am on the Add Shipment (LTL) page for sales user
	And I have Not entered all required information in the Shipping from section,
	And I click On the view Origin on Map button
	And I received the pop up reminder to enter all required information, 
	When I click on the Close button of the pop up reminder modal, 
	Then the modal will close.

Scenario Outline: 76048 - Verify the functionality of View destination Location on Map button on Shipping To section for external user
	Given I am a shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an external user
	And I have entered all required information in the Shipping To section,  - <LocationName>, <LocationAddress> and <Zipcode>
	When I click On the view Origin on Map button in the Shipping To section
	Then I will arrive on the Map as the default,
	And I have the option of viewing a satellite image of the location, 
	And the origin name and address will be noted on the window - <OriginName_Address>
Examples: 
| LocationName  | LocationAddress | Zipcode | OriginName_Address |
| 1419 Westwood Blvd | Los Angeles | 90024   | Los+Angeles,+CA+90024  |



Scenario Outline: 76048 - Verify the functionality of View destination Location on Map button on Shipping To section for Internal user
	Given I am a operations or station owner user
	And I am on the Add Shipment (LTL) page for internal user
	And I have entered all required information in the Shipping To section,  - <LocationName>, <LocationAddress> and <Zipcode>
	When I click On the view Origin on Map button in the Shipping To section
	Then I will arrive on the Map as the default,
	And I have the option of viewing a satellite image of the location, 
	And the origin name and address will be noted on the window - <OriginName_Address>

Examples: 
| LocationName  | LocationAddress | Zipcode | OriginName_Address |
| 1419 Westwood Blvd | Los Angeles | 90024   | Los+Angeles,+CA+90024  |


Scenario Outline: 76048 - Verify the functionality of View destination Location on Map button on Shipping To section for sales user
	Given I am a Sales User
	And I am on the Add Shipment (LTL) page for sales user
	And I have entered all required information in the Shipping To section,  - <LocationName>, <LocationAddress> and <Zipcode>
	When I click On the view Origin on Map button in the Shipping To section
	Then I will arrive on the Map as the default,
	And I have the option of viewing a satellite image of the location, 
	And the origin name and address will be noted on the window - <OriginName_Address>

Examples: 
| LocationName  | LocationAddress | Zipcode | OriginName_Address |
| 1419 Westwood Blvd | Los Angeles | 90024   | Los+Angeles,+CA+90024  |


Scenario: 76048 - Verify the functionality of View destination Location on Map button without entering data in the Shipping To section for external user
	Given I am a shp.entry, shp.entrynorates user
    And I am on the Add Shipment (LTL) page for an external user
	And I have Not entered all required information in the Shipping To section,
	When I click On the view Origin on Map button in the Shipping To section
	Then I will receive a pop up notification requesting that I enter all required information from To section 
	And the pop up notification modal will have a close button.

Scenario: 76048 - Verify the functionality of View destination Location on Map button without entering data in the Shipping To section for internal user
	Given I am a operations or station owner user
	And  I am on the Add Shipment (LTL) page for internal user
	And I have Not entered all required information in the Shipping To section,
	When I click On the view Origin on Map button in the Shipping To section
	Then I will receive a pop up notification requesting that I enter all required information from To section 
	And the pop up notification modal will have a close button.

Scenario: 76048 - Verify the functionality of View destination Location on Map button without entering data in the Shipping To section for sales user
	Given I am a Sales User
	And  I am on the Add Shipment (LTL) page for sales user
	And I have Not entered all required information in the Shipping To section,
	When I click On the view Origin on Map button in the Shipping To section
	Then I will receive a pop up notification requesting that I enter all required information from To section 
	And the pop up notification modal will have a close button.

Scenario: 76048 - Verify the existence and functionality of Close button on the Popup remainder modal for Shipping To section for external user
	Given I am a shp.entry, shp.entrynorates user
    And I am on the Add Shipment (LTL) page for an external user
	And I have Not entered all required information in the Shipping To section,
	And I click On the view Origin on Map button in the Shipping To section
	And I received the pop up reminder to enter all required information from the Shipping To section 
	When I click on the Close button of the pop up reminder modal, 
	Then the modal will close.

Scenario: 76048 - Verify the existence and functionality of Close button on the Popup remainder modal for Shipping To section for internal user
	Given I am a operations or station owner user
	And  I am on the Add Shipment (LTL) page for internal user
	And I have Not entered all required information in the Shipping To section,
	And I click On the view Origin on Map button in the Shipping To section
	And I received the pop up reminder to enter all required information from the Shipping To section 
	When I click on the Close button of the pop up reminder modal, 
	Then the modal will close.

Scenario: 76048 - Verify the existence and functionality of Close button on the Popup remainder modal for Shipping To section for sales user
	Given I am a Sales User
	And  I am on the Add Shipment (LTL) page for sales user
	And I have Not entered all required information in the Shipping To section,
	And I click On the view Origin on Map button in the Shipping To section
	And I received the pop up reminder to enter all required information from the Shipping To section 
	When I click on the Close button of the pop up reminder modal, 
	Then the modal will close.