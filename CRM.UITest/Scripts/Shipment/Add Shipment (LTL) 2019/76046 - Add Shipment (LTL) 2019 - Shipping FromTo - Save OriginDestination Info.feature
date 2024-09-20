@Sprint90 @76046 
Feature: 76046 - Add Shipment (LTL) 2019 - Shipping FromTo - Save OriginDestination Info

#######External Users########

Scenario: 76046 - Verify if Shipping From section details are getting saved when user clicks on Save Origin info button_ExternalUser 
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And I entered all required information in the Add Shipment (LTL) page
	And I checked the Save Origin info button in the Shipping From section
	When I Click on the View Rates Button
	Then CRM will save the following information of Shipping From section as a saved address for the associated customer: LocationName, LocationAddress, LocationAddress2, ZipOrPostal, Country, City, StateOrProvince, ContactName, ContactPhone, ContactPhoneExt, ContactEmail, ContactFax, ContactFaxExt

Scenario: 76046 - Verify if Shipping To section details are getting saved when user clicks on Save Destination info button_ExternalUser 
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And I entered all required information in the Add Shipment (LTL) page
	And I checked the Save Destination info button in the Shipping To section
	When I Click on the View Rates Button
	Then CRM will save the following information of Shipping To section as a saved address for the associated customer: LocationName, LocationAddress, LocationAddress2, ZipOrPostal, Country, City, StateOrProvince, ContactName, ContactPhone, ContactPhoneExt, ContactEmail, ContactFax, ContactFaxExt

Scenario: 76046 - Verify if duplicate address is getting saved by duplicating the information in the Shipping To section same as Shipping From section and checking Save Origin info button_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And I duplicated already existing saved address details in the Shipping From section
	And I checked the Save Origin info button in the Shipping From section
	When I Click on the View Rates Button
	Then A duplicate address will not be saved to CRM_Shipping From section

Scenario: 76046 - Verify if duplicate address is getting saved by duplicating the information in the Shipping To section same as Shipping From section and checking Save Destination info button_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And I duplicated already existing saved address details in the Shipping To section
	And I checked the Save Destination info button in the Shipping To section
	When I Click on the View Rates Button
	Then A duplicate address will not be saved to CRM_ShippingTo sectiom

#######Internal Users########

Scenario: 76046 - Verify if Shipping From section details are getting saved when user clicks on Save Origin info button_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered all required information in the Add Shipment (LTL) page
	And I checked the Save Origin info button in the Shipping From section
	When I Click on the View Rates Button
	Then CRM will save the following information of Shipping From section as a saved address for the associated customer: LocationName, LocationAddress, LocationAddress2, ZipOrPostal, Country, City, StateOrProvince, ContactName, ContactPhone, ContactPhoneExt, ContactEmail, ContactFax, ContactFaxExt

Scenario: 76046 - Verify if Shipping To section details are getting saved when user clicks on Save Destination info button_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered all required information in the Add Shipment (LTL) page
	And I checked the Save Destination info button in the Shipping To section
	When I Click on the View Rates Button
	Then CRM will save the following information of Shipping To section as a saved address for the associated customer: LocationName, LocationAddress, LocationAddress2, ZipOrPostal, Country, City, StateOrProvince, ContactName, ContactPhone, ContactPhoneExt, ContactEmail, ContactFax, ContactFaxExt

Scenario: 76046 - Verify if duplicate address is getting saved by duplicating the information in the Shipping To section same as Shipping From section and checking Save Origin info button_InternalUser 
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	And I duplicated already existing saved address details in the Shipping From section
	And I checked the Save Origin info button in the Shipping From section
	When I Click on the View Rates Button
	Then A duplicate address will not be saved to CRM_Shipping From section


Scenario: 76046 - Verify if duplicate address is getting saved by duplicating the information in the Shipping To section same as Shipping From section and checking Save Destination info button_InternalUser 
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	And I duplicated already existing saved address details in the Shipping To section
	And I checked the Save Destination info button in the Shipping To section
	When I Click on the View Rates Button
	Then A duplicate address will not be saved to CRM_ShippingTo sectiom

#######Sales User########

Scenario: 76046 - Verify if Shipping From section details are getting saved when user clicks on Save Origin info button_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered all required information in the Add Shipment (LTL) page
	And I checked the Save Origin info button in the Shipping From section
	When I Click on the View Rates Button
	Then CRM will save the following information of Shipping From section as a saved address for the associated customer: LocationName, LocationAddress, LocationAddress2, ZipOrPostal, Country, City, StateOrProvince, ContactName, ContactPhone, ContactPhoneExt, ContactEmail, ContactFax, ContactFaxExt

Scenario: 76046 - Verify if Shipping To section details are getting saved when user clicks on Save Destination info button_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered all required information in the Add Shipment (LTL) page
	And I checked the Save Destination info button in the Shipping To section
	When I Click on the View Rates Button
	Then CRM will save the following information of Shipping To section as a saved address for the associated customer: LocationName, LocationAddress, LocationAddress2, ZipOrPostal, Country, City, StateOrProvince, ContactName, ContactPhone, ContactPhoneExt, ContactEmail, ContactFax, ContactFaxExt

Scenario: 76046 - Verify if duplicate address is getting saved by duplicating the information in the Shipping To section same as Shipping From section and checking Save Origin info button_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And I duplicated already existing saved address details in the Shipping From section
	And I checked the Save Origin info button in the Shipping From section
	When I Click on the View Rates Button
	Then A duplicate address will not be saved to CRM_Shipping From section


Scenario: 76046 - Verify if duplicate address is getting saved by duplicating the information in the Shipping To section same as Shipping From section and checking Save Destination info button_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And I duplicated already existing saved address details in the Shipping To section
	And I checked the Save Destination info button in the Shipping To section
	When I Click on the View Rates Button
	Then A duplicate address will not be saved to CRM_ShippingTo sectiom
