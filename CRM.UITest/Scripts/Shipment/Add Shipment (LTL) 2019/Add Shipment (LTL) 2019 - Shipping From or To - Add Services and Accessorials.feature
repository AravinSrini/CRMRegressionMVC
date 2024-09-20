@76049 @Sprint90

Feature: Add Shipment (LTL) 2019 - Shipping From or To - Add Services and Accessorials
	
################ Internal User ##########################
Scenario: 76049 - Verify the select and remove services and accessorial in the Shipping From section_InternalUsers
	Given I am an operations or a station owner user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I have the option to select multiple services and accessorials from the searchable list field in the Shipping From section
	And I have the option to remove previously selected services and accessorials from Shipping From section

Scenario: 76049 - Verify the filtered value in services and accessorials field in the Shipping From section_InternalUsers
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	When I enter value in the Click to add services & accessorials... field in the Shipping From section
	Then the results will be filtered in the Click to add services & accessorials.. field in Shipping From section

Scenario: 76049 - Verify the select and remove services and accessorial in the Shipping To section_InternalUsers
	Given I am an operations or a station owner user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I have the option to select multiple services and accessorials from the searchable list  field in the Shipping To section
	And I have the option to remove previously selected services and accessorials from Shipping To section

Scenario: 76049 - Verify the filtered value in services and accessorials field in the Shipping To section_InternalUsers
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	When I enter value in the Click to add services & accessorials... field in the Shipping To section
	Then the results will be filtered in the Click to add services & accessorials... field in Shipping To section
	

######################### External User #################################

Scenario: 76049 - Verify the select and remove services and accessorial in the Shipping From section_ExternalUsers
	Given I am a  shp.entry, shp.entrynorates user
	When I arrive on Add Shipment (LTL) page for an external user
	Then I have the option to select multiple services and accessorials from the searchable list field in the Shipping From section
	And I have the option to remove previously selected services and accessorials from Shipping From section

Scenario: 76049 - Verify the filtered value in services and accessorials field in the Shipping From section_ExternalUsers
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	When I enter value in the Click to add services & accessorials... field in the Shipping From section
	Then the results will be filtered in the Click to add services & accessorials.. field in Shipping From section

Scenario: 76049 - Verify the select and remove services and accessorial in the Shipping To section_ExternalUsers
	Given I am a  shp.entry, shp.entrynorates user
	When I arrive on Add Shipment (LTL) page for an external user
	Then I have the option to select multiple services and accessorials from the searchable list  field in the Shipping To section
	And I have the option to remove previously selected services and accessorials from Shipping To section

Scenario: 76049 - Verify the filtered value in services and accessorials field in the Shipping To section_ExternalUsers
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an external user
	When I enter value in the Click to add services & accessorials... field in the Shipping To section
	Then the results will be filtered in the Click to add services & accessorials... field in Shipping To section

########################### Sales User ##############################################

Scenario: 76049 - Verify the select and remove services and accessorial in the Shipping From section_SalesUser
	Given I am a sales, sales management user
	When I am on the Add Shipment page for a Sales user
	Then I have the option to select multiple services and accessorials from the searchable list field in the Shipping From section
	And I have the option to remove previously selected services and accessorials from Shipping From section

Scenario: 76049 - Verify the filtered value in services and accessorials field in the Shipping From section_SalesUser
	Given I am a sales, sales management user
	And I am on the Add Shipment page for a Sales user
	When I enter value in the Click to add services & accessorials... field in the Shipping From section
	Then the results will be filtered in the Click to add services & accessorials.. field in Shipping From section

Scenario: 76049 - Verify the select and remove services and accessorial in the Shipping To section_SalesUser
	Given I am a sales, sales management user
	When I am on the Add Shipment page for a Sales user
	Then I have the option to select multiple services and accessorials from the searchable list  field in the Shipping To section
	And I have the option to remove previously selected services and accessorials from Shipping To section

Scenario: 76049 - Verify the filtered value in services and accessorials field in the Shipping To section_SalesUser
	Given I am a sales, sales management user
	And I am on the Add Shipment page for a Sales user
	When I enter value in the Click to add services & accessorials... field in the Shipping To section
	Then the results will be filtered in the Click to add services & accessorials... field in Shipping To section
	