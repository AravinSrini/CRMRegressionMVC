@Sprint90 @Regression @76044
Feature: Add Shipment (LTL) 2019 - Shipping FromTo - Clear Address	

Scenario: 76044 -Verify on clicking on Clear Address button in the <Shipping From> section all field should cleared off for external user
	Given I am a shp.entry, shp.entrynorates user
	And  I am on the Add Shipment (LTL) page for an external user
	And  I fill all the empty fileds in shipping From section
	When I click on the Clear Address button in the Shipping From section
	Then the following fields will be cleared in the Shipping From section: <Select or search for a saved origin...>,<Enter location name...>,<Enter location address...>,<Enter location address line 2...>,<Enter zip/postal code...>,<Country> (default selected <United States>),<Enter city...>,<Select state/province...>,<Contact name...>,<Contact phone...>,<Contact phone Ext.>,<Contact email...>,<Contact fax...>,<Contact fax Ext.>,<Click to add services & accessorials...>,<Enter comments...>

Scenario: 76044 -Verify on clicking on Clear Address button in the <Shipping From> section all field should cleared off for Internal user
	Given I am a operations or station owner user
	And  I am on the Add Shipment (LTL) page for internal user
	And  I fill all the empty fileds in shipping From section
	When I click on the Clear Address button in the Shipping From section
	Then the following fields will be cleared in the Shipping From section: <Select or search for a saved origin...>,<Enter location name...>,<Enter location address...>,<Enter location address line 2...>,<Enter zip/postal code...>,<Country> (default selected <United States>),<Enter city...>,<Select state/province...>,<Contact name...>,<Contact phone...>,<Contact phone Ext.>,<Contact email...>,<Contact fax...>,<Contact fax Ext.>,<Click to add services & accessorials...>,<Enter comments...>

Scenario: 76044 -Verify on clicking on Clear Address button in the <Shipping From> section all field should cleared off for Sale user
	Given I am a Sales User
	And  I am on the Add Shipment (LTL) page for sales user
	And  I fill all the empty fileds in shipping From section
	When I click on the Clear Address button in the Shipping From section
	Then the following fields will be cleared in the Shipping From section: <Select or search for a saved origin...>,<Enter location name...>,<Enter location address...>,<Enter location address line 2...>,<Enter zip/postal code...>,<Country> (default selected <United States>),<Enter city...>,<Select state/province...>,<Contact name...>,<Contact phone...>,<Contact phone Ext.>,<Contact email...>,<Contact fax...>,<Contact fax Ext.>,<Click to add services & accessorials...>,<Enter comments...>

Scenario: 76044 -Verify on clicking on Clear Address button in the <Shipping To> section all field should cleared off for external user
	Given I am a shp.entry, shp.entrynorates user
	And  I am on the Add Shipment (LTL) page for an external user
	And  I fill all the empty fileds in shipping To section
	When I click on the Clear Address button in the Shipping To section
	Then the following fields will be cleared in the Shipping To section: <Select or search for a saved origin...>,<Enter location name...>,<Enter location address...>,<Enter location address line 2...>,<Enter zip/postal code...>,<Country> (default selected <United States>),<Enter city...>,<Select state/province...>,<Contact name...>,<Contact phone...>,<Contact phone Ext.>,<Contact email...>,<Contact fax...>,<Contact fax Ext.>,<Click to add services & accessorials...>,<Enter comments...>

Scenario: 76044 -Verify on clicking on Clear Address button in the <Shipping To> section all field should cleared off for Internal user
	Given I am a operations or station owner user
	And  I am on the Add Shipment (LTL) page for internal user
	And  I fill all the empty fileds in shipping To section
	When I click on the Clear Address button in the Shipping To section
	Then the following fields will be cleared in the Shipping To section: <Select or search for a saved origin...>,<Enter location name...>,<Enter location address...>,<Enter location address line 2...>,<Enter zip/postal code...>,<Country> (default selected <United States>),<Enter city...>,<Select state/province...>,<Contact name...>,<Contact phone...>,<Contact phone Ext.>,<Contact email...>,<Contact fax...>,<Contact fax Ext.>,<Click to add services & accessorials...>,<Enter comments...>

Scenario: 76044 -Verify on clicking on Clear Address button in the <Shipping To> section all field should cleared off for Sales user
	Given I am a Sales User
	And  I am on the Add Shipment (LTL) page for sales user
	And  I fill all the empty fileds in shipping To section
	When I click on the Clear Address button in the Shipping To section
	Then the following fields will be cleared in the Shipping To section: <Select or search for a saved origin...>,<Enter location name...>,<Enter location address...>,<Enter location address line 2...>,<Enter zip/postal code...>,<Country> (default selected <United States>),<Enter city...>,<Select state/province...>,<Contact name...>,<Contact phone...>,<Contact phone Ext.>,<Contact email...>,<Contact fax...>,<Contact fax Ext.>,<Click to add services & accessorials...>,<Enter comments...>
