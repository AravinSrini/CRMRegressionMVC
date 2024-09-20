@Sprint90 @76034 
Feature: 76034 - Add Shipment (LTL) 2019 - Shipping To Section Elements	

#######External Users########

Scenario: 76034 - Verify the display of expected fields on Shipping To section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	When I arrive on Add Shipment (LTL) page for an external user
	Then I will see the following in the Shipping To Section : 'Select or search for a saved dest...', 'Clear Address',  'Enter destination name...', 'Enter destination address...', 'Enter destination address line 2...', 'Enter zip/postal code...', 'Country', 'Enter city...', 'Select state/province...', 'Save Origin info', 'View Origin on Map', 'Click to add services & accessorials...', 'Enter comments...'

Scenario: 76034 - Verify the display of expected fields on Shipping To Contact Info Section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	When I arrive on Add Shipment (LTL) page for an external user
	Then I Will see the following in the Shipping To Contact Info Section : 'Contact name...', 'Contact phone...', 'Contact phone Ext.', 'Contact email...', 'Contact fax...', 'Contact fax Ext.'


Scenario: 76034 - Verify the required and optional fields on Shipping To section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	When I arrive on Add Shipment (LTL) page for an external user
	Then I will see the following as required fields on Shipping To section - Enter location name..., Enter location address..., Enter zip/postal code...., Country, Enter city..., Select state/province... 
	And I will see the following as optional fields on Shipping To section - Select or search for a saved origin..., Enter location address line 2..., Save Origin info, Contact name..., Contact phone..., Contact phone Ext., Contact email..., Contact fax..., Contact fax Ext., Click to add services & accessorials..., Enter comments...

Scenario: 76034 - Verify if 'United States' is been selected by default on Country field of Shipping To section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	When I arrive on Add Shipment (LTL) page for an external user
	Then I will see 'United States' been selected by default on Country field of Shipping To section

Scenario: 76034 - Verify the format and field validation of Shipping To Contact Info section and Comments section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	When I arrive on Add Shipment (LTL) page for an external user
	Then The Contact Phone number field on Shipping To section will be Phone number formatted 
	And The Contact Phone Ext. on Shipping To Section will take a maximum of four numeric values
	And The Contact Email field on Shipping To section will be email formatted
	And The Contact Fax field on Shipping To section will be Phone number formatted
	And The Contact Fax Ext. on Shipping To Section will take a maximum of four numeric values
	And The Comments field on Shipping To section will take a maximum of 250 characters

Scenario: 76034 - Try to pass more than 4 numeric values to Contact Phone Ext. field of Shipping To section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	When I Pass more than four numeric values to Contact Phone Ext. field  of Shipping To section
	Then The Contact Phone Ext. field  of Shipping To Section will not allow more than four numeric values

Scenario: 76034 - Try to pass less than 4 numeric values to Contact Phone Ext. field of Shipping To section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	When I Pass less than four numeric values to Contact Phone Ext. field  of Shipping To section
	Then The Contact Phone Ext. field  of Shipping To Section will allow less than four numeric values

Scenario: 76034 - Try to pass more than 4 numeric values to Contact Fax Ext. field of Shipping To section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	When I Pass more than four numeric values to Contact Fax Ext. field  of Shipping To section
	Then The Contact Fax Ext. field  of Shipping To Section will not allow more than four numeric values

Scenario: 76034 - Try to pass less than 4 numeric values to Contact Fax Ext. field of Shipping To section of Add Shipment (LTL) page_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	When I Pass less than four numeric values to Contact Fax Ext. field  of Shipping To section
	Then The Contact Fax Ext. field  of Shipping To Section will allow less than four numeric values

Scenario: 76034 - Try to pass more than 250 characters to Comments field of Shipping To section_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	When I pass more than 250 characters to Comments field of Shipping To section
	Then The Comments field of Shipping To section will not allow more than 250 characters

Scenario: 76034 - Try to pass less than 250 characters to Comments field of Shipping To section_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	When I pass less than 250 characters to Comments field of Shipping To section
	Then The Comments field of Shipping To section will allow less than 250 characters

Scenario: 76034 - Verify the popup box text display when user mouse hover on the comments field of Shipping To section for the comments more than the characters displayed in the field_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And Comments field field in the Shipping To section contains more characters than can be displayed in the field
	When I hover over the text of Comments field in the Shipping To section
	Then A popup box will display the entire text in the Ship To section

Scenario: 76034 - Verify if popup box is displayed when user mouse hover on the comments field of Shipping To section for the comments not more than the characters displayed in the field_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And Comments field in the Shipping To section does not contain more characters than can be displayed in the field
	When I hover over the text of Comments field in the Shipping To section
	Then A popup box will not get displayed in the Ship To section

Scenario: 76034 - Try to enter an invalid phone number format to Contact phone field of Shipping To section and verify the validation_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And I entered an invalid phone format to Contact Phone field of Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid phone format
	And The field with the invalid phone format will be highlighted in the Ship To section

Scenario: 76034 - Try to enter an invalid fax number format to Contact Fax field of Shipping To section and verify the validation_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And I entered an invalid fax format to Contact fax field of Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid fax format
	And The field with the invalid fax format will be highlighted in the Ship To section

Scenario: 76034 - Try to enter an invalid email address to Contact email field of Shipping to section and verify the validation_ExternalUser
	Given I am a  shp.entry, shp.entrynorates user
	And I am on the Add Shipment (LTL) page for an External user
	And I entered an invalid Email format in the Contact email field in the Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid email format
	And Contact Email field will be highlighted in the Ship From section

#######Internal Users########

Scenario: 76034 - Verify the display of expected fields on Shipping To section of Add Shipment (LTL) page_InternalUser
	Given I am an operations or a station owner user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I will see the following in the Shipping To Section : 'Select or search for a saved dest...', 'Clear Address',  'Enter destination name...', 'Enter destination address...', 'Enter destination address line 2...', 'Enter zip/postal code...', 'Country', 'Enter city...', 'Select state/province...', 'Save Origin info', 'View Origin on Map', 'Click to add services & accessorials...', 'Enter comments...'

Scenario: 76034 - Verify the display of expected fields on Shipping To Contact Info Section of Add Shipment (LTL) page_InternalUser
	Given I am an operations or a station owner user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I Will see the following in the Shipping To Contact Info Section : 'Contact name...', 'Contact phone...', 'Contact phone Ext.', 'Contact email...', 'Contact fax...', 'Contact fax Ext.'


Scenario: 76034 - Verify the required and optional fields on Shipping To section of Add Shipment (LTL) page_InternalUser
	Given I am an operations or a station owner user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I will see the following as required fields on Shipping To section - Enter location name..., Enter location address..., Enter zip/postal code...., Country, Enter city..., Select state/province... 
	And I will see the following as optional fields on Shipping To section - Select or search for a saved origin..., Enter location address line 2..., Save Origin info, Contact name..., Contact phone..., Contact phone Ext., Contact email..., Contact fax..., Contact fax Ext., Click to add services & accessorials..., Enter comments...

Scenario: 76034 - Verify if 'United States' is been selected by default on Country field of Shipping To section of Add Shipment (LTL) page_InternalUser
	Given I am an operations or a station owner user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I will see 'United States' been selected by default on Country field of Shipping To section

Scenario: 76034 - Verify the format and field validation of Shipping To Contact Info section and Comments section of Add Shipment (LTL) page_InternalUser 
	Given I am an operations or a station owner user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then The Contact Phone number field on Shipping To section will be Phone number formatted 
	And The Contact Phone Ext. on Shipping To Section will take a maximum of four numeric values
	And The Contact Email field on Shipping To section will be email formatted
	And The Contact Fax field on Shipping To section will be Phone number formatted
	And The Contact Fax Ext. on Shipping To Section will take a maximum of four numeric values
	And The Comments field on Shipping To section will take a maximum of 250 characters

Scenario: 76034 - Try to pass more than 4 numeric values to Contact Phone Ext. field of Shipping To section of Add Shipment (LTL) page_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	When I Pass more than four numeric values to Contact Phone Ext. field  of Shipping To section
	Then The Contact Phone Ext. field  of Shipping To Section will not allow more than four numeric values

Scenario: 76034 - Try to pass less than 4 numeric values to Contact Phone Ext. field of Shipping To section of Add Shipment (LTL) page_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	When I Pass less than four numeric values to Contact Phone Ext. field  of Shipping To section
	Then The Contact Phone Ext. field  of Shipping To Section will allow less than four numeric values

Scenario: 76034 - Try to pass more than 4 numeric values to Contact Fax Ext. field of Shipping To section of Add Shipment (LTL) page_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	When I Pass more than four numeric values to Contact Fax Ext. field  of Shipping To section
	Then The Contact Fax Ext. field  of Shipping To Section will not allow more than four numeric values

Scenario: 76034 - Try to pass less than 4 numeric values to Contact Fax Ext. field of Shipping To section of Add Shipment (LTL) page_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	When I Pass less than four numeric values to Contact Fax Ext. field  of Shipping To section
	Then The Contact Fax Ext. field  of Shipping To Section will allow less than four numeric values

Scenario: 76034 - Try to pass more than 250 characters to Comments field of Shipping To section_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	When I pass more than 250 characters to Comments field of Shipping To section
	Then The Comments field of Shipping To section will not allow more than 250 characters

Scenario: 76034 - Try to pass less than 250 characters to Comments field of Shipping To section_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	When I pass less than 250 characters to Comments field of Shipping To section
	Then The Comments field of Shipping To section will allow less than 250 characters

Scenario: 76034 - Verify the popup box text display when user mouse hover on the comments field of Shipping To section for the comments more than the characters displayed in the field_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	And Comments field field in the Shipping To section contains more characters than can be displayed in the field
	When I hover over the text of Comments field in the Shipping To section
	Then A popup box will display the entire text in the Ship To section

Scenario: 76034 - Verify if popup box is displayed when user mouse hover on the comments field of Shipping To section for the comments not more than the characters displayed in the field_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	And Comments field in the Shipping To section does not contain more characters than can be displayed in the field
	When I hover over the text of Comments field in the Shipping To section
	Then A popup box will not get displayed in the Ship To section

Scenario: 76034 - Try to enter an invalid phone number format to Contact phone field of Shipping To section and verify the validation_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered an invalid phone format to Contact Phone field of Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid phone format
	And The field with the invalid phone format will be highlighted in the Ship To section

Scenario: 76034 - Try to enter an invalid phone number format to Contact Fax field of Shipping To section and verify the validation_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user 
	And I entered an invalid fax format to Contact fax field of Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid fax format
	And The field with the invalid fax format will be highlighted in the Ship To section

Scenario: 76034 - Try to enter an invalid email address to Contact email field of Shipping to section and verify the validation_InternalUser
	Given I am an operations or a station owner user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered an invalid Email format in the Contact email field in the Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid email format
	And Contact Email field will be highlighted in the Ship From section

#######Sales User########

Scenario: 76034 - Verify the display of expected fields on Shipping To section of Add Shipment (LTL) page_SalesManagementUser
	Given I am a sales, sales management user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I will see the following in the Shipping To Section : 'Select or search for a saved dest...', 'Clear Address',  'Enter destination name...', 'Enter destination address...', 'Enter destination address line 2...', 'Enter zip/postal code...', 'Country', 'Enter city...', 'Select state/province...', 'Save Origin info', 'View Origin on Map', 'Click to add services & accessorials...', 'Enter comments...'

Scenario: 76034 - Verify the display of expected fields on Shipping To Contact Info Section of Add Shipment (LTL) page_SalesManagementUser
	Given I am a sales, sales management user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I Will see the following in the Shipping To Contact Info Section : 'Contact name...', 'Contact phone...', 'Contact phone Ext.', 'Contact email...', 'Contact fax...', 'Contact fax Ext.'

Scenario: 76034 - Verify the required and optional fields on Shipping To section of Add Shipment (LTL) page_SalesManagementUser
	Given I am a sales, sales management user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I will see the following as required fields on Shipping To section - Enter location name..., Enter location address..., Enter zip/postal code...., Country, Enter city..., Select state/province... 
	And I will see the following as optional fields on Shipping To section - Select or search for a saved origin..., Enter location address line 2..., Save Origin info, Contact name..., Contact phone..., Contact phone Ext., Contact email..., Contact fax..., Contact fax Ext., Click to add services & accessorials..., Enter comments...

Scenario: 76034 - Verify if 'United States' is been selected by default on Country field of Shipping To section of Add Shipment (LTL) page_SalesManagementUser
	Given I am a sales, sales management user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then I will see 'United States' been selected by default on Country field of Shipping To section

Scenario: 76034 - Verify the format and field validation of Shipping To Contact Info section and Comments section of Add Shipment (LTL) page_SalesManagementUser
	Given I am a sales, sales management user
	When I arrive on Add Shipment (LTL) page for an internal user
	Then The Contact Phone number field on Shipping To section will be Phone number formatted 
	And The Contact Phone Ext. on Shipping To Section will take a maximum of four numeric values
	And The Contact Email field on Shipping To section will be email formatted
	And The Contact Fax field on Shipping To section will be Phone number formatted
	And The Contact Fax Ext. on Shipping To Section will take a maximum of four numeric values
	And The Comments field on Shipping To section will take a maximum of 250 characters

Scenario: 76034 - Try to pass more than 4 numeric values to Contact Phone Ext. field of Shipping To section of Add Shipment (LTL) page_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	When I Pass more than four numeric values to Contact Phone Ext. field  of Shipping To section
	Then The Contact Phone Ext. field  of Shipping To Section will not allow more than four numeric values

Scenario: 76034 - Try to pass less than 4 numeric values to Contact Phone Ext. field of Shipping To section of Add Shipment (LTL) page_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	When I Pass less than four numeric values to Contact Phone Ext. field  of Shipping To section
	Then The Contact Phone Ext. field  of Shipping To Section will allow less than four numeric values

Scenario: 76034 - Try to pass more than 4 numeric values to Contact Fax Ext. field of Shipping To section of Add Shipment (LTL) _SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	When I Pass more than four numeric values to Contact Fax Ext. field  of Shipping To section
	Then The Contact Fax Ext. field  of Shipping To Section will not allow more than four numeric values

Scenario: 76034 - Try to pass less than 4 numeric values to Contact Fax Ext. field of Shipping To section of Add Shipment (LTL) page_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	When I Pass less than four numeric values to Contact Fax Ext. field  of Shipping To section
	Then The Contact Fax Ext. field  of Shipping To Section will allow less than four numeric values

Scenario: 76034 - Try to pass more than 250 characters to Comments field of Shipping To section_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	When I pass more than 250 characters to Comments field of Shipping To section
	Then The Comments field of Shipping To section will not allow more than 250 characters

Scenario: 76034 - Try to pass less than 250 characters to Comments field of Shipping To section_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	When I pass less than 250 characters to Comments field of Shipping To section
	Then The Comments field of Shipping To section will allow less than 250 characters

Scenario: 76034 - Verify the popup box text display when user mouse hover on the comments field of Shipping To section for the comments more than the characters displayed in the field_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And Comments field field in the Shipping To section contains more characters than can be displayed in the field
	When I hover over the text of Comments field in the Shipping To section
	Then A popup box will display the entire text in the Ship To section

Scenario: 76034 - Verify if popup box is displayed when user mouse hover on the comments field of Shipping To section for the comments not more than the characters displayed in the field_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And Comments field in the Shipping To section does not contain more characters than can be displayed in the field
	When I hover over the text of Comments field in the Shipping To section
	Then A popup box will not get displayed in the Ship To section

Scenario: 76034 - Try to enter an invalid phone number format to Contact phone field of Shipping To section and verify the validation_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered an invalid phone format to Contact Phone field of Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid phone format
	And The field with the invalid phone format will be highlighted in the Ship To section

Scenario: 76034 - Try to enter an invalid phone number format to Contact Fax field of Shipping To section and verify the validation_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered an invalid fax format to Contact fax field of Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid fax format
	And The field with the invalid fax format will be highlighted in the Ship To section

Scenario: 76034 - Try to enter an invalid email address to Contact email field of Shipping To section and verify the validation_SalesManagementUser
	Given I am a sales, sales management user
	And I am on the Add Shipment (LTL) page for an internal user
	And I entered an invalid Email format in the Contact email field in the Shipping To section
	When I Click on the View Rates Button
	Then I will receive an Error message indicating an Invalid email format
	And Contact Email field will be highlighted in the Ship From section
