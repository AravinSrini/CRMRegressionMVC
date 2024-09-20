@Sprint78
Feature: Insurance Claims_Submit a Claim Page Elements
	
@Functional
Scenario: 39549 - Verify navigation to Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	When I click on Submit a claim button on claim list page
	Then I must be navigated to Submit a Claim page
	
@Functional
Scenario: 39549 - Verify navigation to Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	When I click on Submit a claim button on claim list page
	Then I must be navigated to Submit a Claim page	 

@GUI
Scenario: 39549 - Verify the existence of expected page elements in the header section of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see Submit a Claim header with verbiage - Submit a motor carrier shortage or damage claim
	And I must be able to see Back to Claim list button
	And I must be able to see a field named - Enter DLSW Ref # to Start Process
	And I must be able to see Prefill form button
	And I must be able to see a verbiage stating - Or fill out the form below manually

@GUI
Scenario: 39549 - Verify the existence of expected page elements in the header section of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see Submit a Claim header with verbiage - Submit a motor carrier shortage or damage claim
	And I must be able to see Back to Claim list button
	And I must be able to see a field named - Enter DLSW Ref # to Start Process
	And I must be able to see Prefill form button
	And I must be able to see a verbiage stating - Or fill out the form below manually

@GUI
Scenario: 39549 - Verify the existence of expected fields in the Carrier Information section of Submit a Claim page for External users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see the following fields in the Carrier Information section - DLSW Ref, DLSW Ship Date, Carrier Name, Carrier PRO #, Carrier PRO Date
	
@GUI
Scenario: 39549 - Verify the existence of expected fields in the Carrier Information section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see the following fields in the Carrier Information section - DLSW Ref, DLSW Ship Date, Carrier Name, Carrier PRO #, Carrier PRO Date

@GUI
Scenario: 39549 - Verify the required fields in the Carrier Information section of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page and click on submit button
	Then DLSW Ref, DLSW Ship Date, Carrier Name, Carrier PRO # fields of Carrier Information section should be highlighted

@GUI
Scenario: 39549 - Verify the required fields in the Carrier Information section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page and click on submit button
	Then DLSW Ref, DLSW Ship Date, Carrier Name, Carrier PRO # fields of Carrier Information section should be highlighted

@Functional
Scenario: 39549 - Verify validation of DLSW Ref # field by passing a maximum of 20 alpha numeric characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 20 alpha numeric characters

@Functional
Scenario: 39549 - Verify validation of DLSW Ref # field by passing a maximum of 20 alpha numeric characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 20 alpha numeric characters

@Functional
Scenario: 39549 - Try passing more than 20 alpha numeric characters to DLSW Ref # field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 20 alpha numeric characters to DLSW Ref # field

@Functional
Scenario: 39549 - Try passing more than 20 alpha numeric characters to DLSW Ref # field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 20 alpha numeric characters to DLSW Ref # field

@Functional
Scenario: 39549 - Verify DLSW Ship Date field validation for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see DLSW Ship Date selected prior to current date 

@Functional
Scenario: 39549 - Verify DLSW Ship Date field validation for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see DLSW Ship Date selected prior to current date 

@Functional
Scenario: 39549 - Verify validation of Carrier Name field by passing a maximum of 75 alpha numeric, text and special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 75 alpha numeric, text and special characters to Carrier Name field

@Functional
Scenario: 39549 - Verify validation of Carrier Name field by passing a maximum of 75 alpha numeric, text and special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 75 alpha numeric, text and special characters to Carrier Name field

@Functional
Scenario: 39549 - Try passing more than 75 alpha numeric, text and special characters to Carrier Name field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass a maximum of 75 alpha numeric, text and special characters to Carrier Name field

@Functional
Scenario: 39549 - Try passing more than 75 alpha numeric, text and special characters to Carrier Name field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass a maximum of 75 alpha numeric, text and special characters to Carrier Name field

@Functional
Scenario: 39549 - Verify validation of Carrier PRO # field by passing a maximum of 30 alpha numeric, text and special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 30 alpha numeric, text and special characters to Carrier PRO # field

@Functional
Scenario: 39549 - Verify validation of Carrier PRO # field by passing a maximum of 30 alpha numeric, text and special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 30 alpha numeric, text and special characters Carrier PRO # field

@Functional
Scenario: 39549 - Try passing more than 30 alpha numeric, text and special characters to Carrier PRO # field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass a maximum of 30 alpha numeric, text and special characters to Carrier PRO # field

@Functional
Scenario: 39549 - Try passing more than 30 alpha numeric, text and special characters to Carrier PRO # field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass a maximum of 30 alpha numeric, text and special characters to Carrier PRO # field

@Functional
Scenario: 39549 - Verify Carrier PRO Date field validation for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see Carrier PRO Date selected prior to current date 

@Functional
Scenario: 39549 - Verify Carrier PRO Date field validation for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see Carrier PRO Date selected prior to current date 

@Functional
Scenario: 39549 - Verify the existence of expected fields in the Shipper Information section of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see the following expected fields in the Shipper information page - Name, Address, Address2, City, StateOrProvince, ZipOrPostal, Country

@Functional
Scenario: 39549 - Verify the existence of expected fields in the Shipper Information section of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see the following expected fields in the Shipper information page - Name, Address, Address2, City, StateOrProvince, ZipOrPostal, Country

@Functional
Scenario: 39549 - Verify required fields in the Shipper Information section of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page and click on submit button
	Then I must see the following fields highlighted in the Shipper Information section -  Name, Address, City, StateOrProvince, ZipOrPostal, Country

@Functional
Scenario: 39549 - Verify required fields in the Shipper Information section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page and click on submit button
	Then I must see the following fields highlighted in the Shipper Information section -  Name, Address, City, StateOrProvince, ZipOrPostal, Country
	 	 
@Functional
Scenario: 39549 - Verify validation of Name field in the Shipper information section by passing a maximum of 75 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 75 alpha-numeric, text, special characters to the name field of shipper information section

@Functional
Scenario: 39549 - Verify validation of Name field in the Shipper information section by passing a maximum of 75 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 75 alpha-numeric, text, special characters to the name field of shipper information section

@Functional
Scenario: 39549 - Try passing more than 75 alpha-numeric, text, special characters to Name field of Shipper information section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 75 alpha-numeric, text, special characters to the name field of shipper information section

@Functional
Scenario: 39549 - Try passing more than 75 alpha-numeric, text, special characters to Name field of Shipper information section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 75 alpha-numeric, text, special characters to the name field of shipper information section

@Functional
Scenario: 39549 - Verify validation of Address field in the Shipper information section by passing a maximum of 150 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the address field of shipper information section

@Functional
Scenario: 39549 - Verify validation of Address field in the Shipper information section by passing a maximum of 150 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the address field of shipper information section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to Address field of Shipper information section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the address field of shipper information section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to Address field of Shipper information section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the address field of shipper information section

@Functional
Scenario: 39549 - Verify validation of Address2 field in the Shipper information section by passing a maximum of 150 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the address2 field of shipper information section

@Functional
Scenario: 39549 - Verify validation of Address2 field in the Shipper information section by passing a maximum of 150 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the address2 field of shipper information section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to Address2 field of Shipper information section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the address2 field of shipper information section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to Address2 field of Shipper information section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the address2 field of shipper information section

@Functional
Scenario: 39549 - Verify validation of city field in the Shipper information section by passing a maximum of 50 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to the city field of shipper information section

@Functional
Scenario: 39549 - Verify validation of city field in the Shipper information section by passing a maximum of 50 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to the city field of shipper information section

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to city field of Shipper information section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to the city field of shipper information section

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to city field of Shipper information section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to the city field of shipper information section

@Functional
Scenario: 39549 - Verify the validation of State or Province field in the Shipper information section when country is either United states or Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 2 text to State or Province field of shipper information section when the country is either United states or Canada

@Functional
Scenario: 39549 - Verify the validation of State or Province field in the Shipper information section when country is either United states or Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 2 text to State or Province field of shipper information section when the country is either United states or Canada

@Functional
Scenario: 39549 - Verify validation of State or Province field in the Shipper information section when country is neither United states nor Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 50 alpha-numeric, text to State or Province field of shipper information section when country is neither United states nor Canada 

@Functional
Scenario: 39549 - Verify validation of State or Province field in the Shipper information section when country is neither United states nor Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 50 alpha-numeric, text to State or Province field of shipper information section when country is neither United states nor Canada 

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text to State or Province field in the Shipper information section when country is neither United states nor Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text to State or Province field of shipper information section when country is neither United states nor Canada 

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text to State or Province field in the Shipper information section when country is neither United states nor Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text to State or Province field of shipper information section when country is neither United states nor Canada 

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Shipper information section when country is United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 5 digits including leading zeros to Zip or Postal field of shipper information section when country is United states

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Shipper information section when country is United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 5 digits including leading zeros to Zip or Postal field of shipper information section when country is United states

@Functional
Scenario: 39549 - Try passing more than or less than 5 digits to Zip or Postal field of Shipper information section when country is United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than or less than 5 digits to Zip or Postal field of Shipper information section when country is United states

@Functional
Scenario: 39549 - Try passing more than or less than 5 digits to Zip or Postal field of Shipper information section when country is United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than or less than 5 digits to Zip or Postal field of Shipper information section when country is United states

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Shipper information section when country is Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 7 alpha numeric characters to Zip or Postal field of shipper information section when a space is used after first 3 characters and the country is Canada

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Shipper information section when country is Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 7 alpha numeric characters to Zip or Postal field of shipper information section when a space is used after first 3 characters and the country is Canada

@Functional
Scenario: 39549 - Try passing more than 7 alpha numeric characters to Zip or Postal field of shipper information section when country is Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 7 alpha numeric characters to Zip or Postal field when country is Canada

@Functional
Scenario: 39549 - Try passing more than 7 alpha numeric characters to Zip or Postal field of shipper information section when country is Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 7 alpha numeric characters to Zip or Postal field when country is Canada

@Functional
Scenario: 39549 - Try passing less than 6 alpha numeric characters to Zip or Postal field of shipper information section when country is Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass less than 6 alpha numeric characters to Zip or Postal field when country is Canada

@Functional
Scenario: 39549 - Try passing less than 6 alpha numeric characters to Zip or Postal field of shipper information section when country is Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass less than 6 alpha numeric characters to Zip or Postal field when country is Canada

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Shipper information section when country is neither Canada nor United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 15 alpha numeric , text, special characters to Zip or Postal field of shipper information section when country is neither Canada nor United states for external users

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Shipper information section when country is neither Canada nor United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 15 alpha numeric , text, special characters to Zip or Postal field of shipper information section when country is neither Canada nor United states for external users

@Functional
Scenario: 39549 - Try passing more than 15 alpha numeric, text, special characters to Zip or Postal field of shipper information section when country is neither Canada nor United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 15 alpha numeric , text, special characters to Zip or Postal field when country is neither Canada nor United states

@Functional
Scenario: 39549 - Try passing more than 15 alpha numeric, text, special characters to Zip or Postal field of shipper information section when country is neither Canada nor United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 15 alpha numeric , text, special characters to Zip or Postal field when country is neither Canada nor United states

@GUI
Scenario: 39549 - Verify the existence of expected fields in the Consignee Information section of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see the following expected fields in the Consignee information page - Name, Address, Address2, City, StateOrProvince, ZipOrPostal, Country

@GUI
Scenario: 39549 - Verify the existence of expected fields in the Consignee Information section of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see the following expected fields in the Consignee information page - Name, Address, Address2, City, StateOrProvince, ZipOrPostal, Country

@GUI
Scenario: 39549 - Verify required fields in the Consignee Information section of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page and click on submit button
	Then I must see the following fields highlighted in the Consignee Information section -  Name, Address, City, StateOrProvince, ZipOrPostal, Country

@GUI
Scenario: 39549 - Verify required fields in the Consignee Information section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page and click on submit button
	Then I must see the following fields highlighted in the Consignee Information section -  Name, Address, City, StateOrProvince, ZipOrPostal, Country
	 	 
@Functional
Scenario: 39549 - Verify validation of Name field in the Consignee information section by passing a maximum of 75 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 75 alpha-numeric, text, special characters to the name field of Consignee information section

@Functional
Scenario: 39549 - Verify validation of Name field in the Consignee information section by passing a maximum of 75 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 75 alpha-numeric, text, special characters to the name field of Consignee information section

@Functional
Scenario: 39549 - Try passing more than 75 alpha-numeric, text, special characters to Name field of Consignee information section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 75 alpha-numeric, text, special characters to the name field of Consignee information section

@Functional
Scenario: 39549 - Try passing more than 75 alpha-numeric, text, special characters to Name field of Consignee information section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 75 alpha-numeric, text, special characters to the name field of Consignee information section

@Functional
Scenario: 39549 - Verify validation of Address field in the Consignee information section by passing a maximum of 150 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the address field of Consignee information section

@Functional
Scenario: 39549 - Verify validation of Address field in the Consignee information section by passing a maximum of 150 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the address field of Consignee information section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to Address field of Consignee information section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the address field of Consignee information section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to Address field of Consignee information section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the address field of Consignee information section

@Functional
Scenario: 39549 - Verify validation of Address2 field in the Consignee information section by passing a maximum of 150 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the address2 field of Consignee information section

@Functional
Scenario: 39549 - Verify validation of Address2 field in the Consignee information section by passing a maximum of 150 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the address2 field of Consignee information section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to Address2 field of Consignee information section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the address2 field of Consignee information section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to Address2 field of Consignee information section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the address2 field of Consignee information section

@Functional
Scenario: 39549 - Verify validation of city field in the Consignee information section by passing a maximum of 50 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to the city field of Consignee information section

@Functional
Scenario: 39549 - Verify validation of city field in the Consignee information section by passing a maximum of 50 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to the city field of Consignee information section

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to city field of Consignee information section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to the city field of Consignee information section

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to city field of Consignee information section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to the city field of Consignee information section

@Functional
Scenario: 39549 - Verify validation of State or Province field in the Consignee information section when country is either United states or Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 2 text to State or Province field of Consignee information section when country is either United states or Canada 

@Functional
Scenario: 39549 - Verify validation of State or Province field in the Consignee information section when country is either United states or Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 2 text to State or Province field of Consignee information section when country is either United states or Canada 

@Functional
Scenario: 39549 - Verify validation of State or Province field in the Consignee information section when country is neither United states nor Cannada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 50 alpha-numeric, text to State or Province field of Consignee information section when country is neither United states nor Cannada 

@Functional
Scenario: 39549 - Verify validation of State or Province field in the Consignee information section when country is neither United states nor Cannada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 50 alpha-numeric, text to State or Province field of Consignee information section when country is neither United states nor Cannada 

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text to State or Province field in the Consignee information section when country is neither United states nor Cannada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text to State or Province field of Consignee information section when country is neither United states nor Cannada 

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text to State or Province field in the Consignee information section when country is neither United states nor Cannada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text to State or Province field of Consignee information section when country is neither United states nor Cannada 

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Consignee information section when country is United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 5 digits including leading zeros to Zip or Postal field of Consignee information section when country is United states

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Consignee information section when country is United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 5 digits including leading zeros to Zip or Postal field of Consignee information section when country is United states

@Functional
Scenario: 39549 - Try passing more than or less than 5 digits to Zip or Postal field of Consignee information section when country is United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than or less than 5 digits to Zip or Postal field of Consignee information section when country is United states

@Functional
Scenario: 39549 - Try passing more than or less than 5 digits to Zip or Postal field of Consignee information section when country is United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than or less than 5 digits to Zip or Postal field of Consignee information section when country is United states

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Consignee information section when country is Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 7 alpha numeric characters to Zip or Postal field of Consignee information section when a space is used after first 3 characters and the country is Canada

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Consignee information section when country is Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 7 alpha numeric characters to Zip or Postal field of Consignee information section when a space is used after first 3 characters and the country is Canada

@Functional
Scenario: 39549 - Try passing more than 7 alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 7 alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada 

@Functional
Scenario: 39549 - Try passing more than 7 alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 7 alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada

@Functional
Scenario: 39549 - Try passing less than 6 alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass less than 6 alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada

@Functional
Scenario: 39549 - Try passing less than 6 alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass less than 6 alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Consignee information section when country is neither Canada nor United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 15 alpha numeric , text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states for external users

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Consignee information section when country is neither Canada nor United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 15 alpha numeric , text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states for external users

@Functional
Scenario: 39549 - Try passing more than 15 alpha numeric, text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 15 alpha numeric , text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states

@Functional
Scenario: 39549 - Try passing more than 15 alpha numeric, text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 15 alpha numeric , text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states

@Functional
Scenario: 39549 - Verify the existence of Claim Payable to section verbiage in Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see a verbiage beneath the claim payable section header stating - Claim must be made payable to party on the bill of lading

@Functional
Scenario: 39549 - Verify the existence of Claim Payable to section verbiage in Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see a verbiage beneath the claim payable section header stating - Claim must be made payable to party on the bill of lading

@Functional
Scenario: 39549 - Verify the existence of expected fields in the Claim Payable To section of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see the following fields in the Claim payable To section - Company Name, Address, Address2, City, StateOrProvince, ZipOrPostal, Country, Contact Name, Contact Phone, Contact Email, Contact Website

@Functional
Scenario: 39549 - Verify the existence of expected fields in the Claim Payable To section of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see the following fields in the Claim payable To section - Company Name, Address, Address2, City, StateOrProvince, ZipOrPostal, Country, Contact Name, Contact Phone, Contact Email, Contact Website

@Functional
Scenario: 39549 - Verify required fields in Claim Payable To section of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page and click on submit button
	Then I should be able to view the following fields getting highlighted - Company Name, Address, City, StateOrProvince, ZipOrPostal, Country, Contact Name, Contact Phone, Contact Email

@Functional
Scenario: 39549 - Verify required fields in Claim Payable To section of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page and click on submit button
	Then I should be able to view the following fields getting highlighted - Company Name, Address, City, StateOrProvince, ZipOrPostal, Country, Contact Name, Contact Phone, Contact Email

@Functional
Scenario: 39549 - Verify validation of Company Name field in the Claim Payable To section by passing a maximum of 75 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 75 alpha-numeric, text, special characters to the Company name field of Claim Payable To section

@Functional
Scenario: 39549 - Verify validation of Company Name field in the Claim Payable To section by passing a maximum of 75 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 75 alpha-numeric, text, special characters to the Company name field of Claim Payable To section

@Functional
Scenario: 39549 - Try passing more than 75 alpha-numeric, text, special characters to the Company name field of Claim Payable To section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 75 alpha-numeric, text, special characters to the Company name field of Claim Payable To section

@Functional
Scenario: 39549 - Try passing more than 75 alpha-numeric, text, special characters to the Company name field of Claim Payable To section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 75 alpha-numeric, text, special characters to the Company name field of Claim Payable To section

@Functional
Scenario: 39549 - Verify validation of Address field in the Claim Payable To section by passing a maximum of 150 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the Address field of Claim Payable To section

@Functional
Scenario: 39549 - Verify validation of Address field in the Claim Payable To section by passing a maximum of 150 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the Address field of Claim Payable To section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to the Address field of Claim Payable To section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the Address field of Claim Payable To section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to the Address field of Claim Payable To section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the Address field of Claim Payable To section

@Functional
Scenario: 39549 - Verify validation of Address2 field in the Claim Payable To section by passing a maximum of 150 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the Address2 field of Claim Payable To section

@Functional
Scenario: 39549 - Verify validation of Address2 field in the Claim Payable To section by passing a maximum of 150 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 150 alpha-numeric, text, special characters to the Address2 field of Claim Payable To section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to the Address2 field of Claim Payable To section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the Address2 field of Claim Payable To section

@Functional
Scenario: 39549 - Try passing more than 150 alpha-numeric, text, special characters to the Address2 field of Claim Payable To section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 150 alpha-numeric, text, special characters to the Address2 field of Claim Payable To section

@Functional
Scenario: 39549 - Verify validation of city field in the Claim Payable To Section by passing a maximum of 50 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to the city field of Claim Payable To Section

@Functional
Scenario: 39549 - Verify validation of city field in the Claim Payable To Section by passing a maximum of 50 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to the city field of Claim Payable To Section

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to city field of Claim Payable To Section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to the city field of Claim Payable To Section

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to city field of Claim Payable To Section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to the city field of Claim Payable To Section

@Functional
Scenario: 39549 - Verify validation of State or Province field in the Claim Payable To Section when country is neither United states nor Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 50 alpha-numeric, text to State or Province field of Claim Payable To Section when country is neither United states nor Canada 

@Functional
Scenario: 39549 - Verify validation of State or Province field in the Claim Payable To Section when country is neither United states nor Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 50 alpha-numeric, text to State or Province field of Claim Payable To Section when country is neither United states nor Canada 

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text to State or Province field in the Claim Payable To Section when country is neither United states nor Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text to State or Province field of Claim Payable To Section when country is neither United states nor Canada 

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text to State or Province field in the Claim Payable To Section when country is neither United states nor Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text to State or Province field of Claim Payable To Section when country is neither United states nor Canada 

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Claim Payable To Section when country is United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 5 digits including leading zeros to Zip or Postal field of Claim Payable To Section when country is United states

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Claim Payable To Section when country is United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 5 digits including leading zeros to Zip or Postal field of Claim Payable To Section when country is United states

@Functional
Scenario: 39549 - Try passing more than or less than 5 digits to Zip or Postal field of Claim Payable To Section when country is United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than or less than 5 digits to Zip or Postal field of Claim Payable To Section when country is United states

@Functional
Scenario: 39549 - Try passing more than or less than 5 digits to Zip or Postal field of Claim Payable To Section when country is United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than or less than 5 digits to Zip or Postal field of Claim Payable To Section when country is United states

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Claim Payable To Section when country is Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 7 alpha numeric characters to Zip or Postal field of Claim Payable To Section when a space is used after first 3 characters and the country is Canada

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Claim Payable To Section when country is Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 7 alpha numeric characters to Zip or Postal field of Claim Payable To Section when a space is used after first 3 characters and the country is Canada

@Functional
Scenario: 39549 - Try passing more than 7 alpha numeric characters to Zip or Postal field of Claim Payable To Section when country is Canada for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 7 alpha numeric characters to Zip or Postal field of Claim Payable To Section when country is Canada 

@Functional
Scenario: 39549 - Try passing more than 7 alpha numeric characters to Zip or Postal field of Claim Payable To Section when country is Canada for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 7 alpha numeric characters to Zip or Postal field of Claim Payable To Section when country is Canada

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 15 alpha numeric , text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states for external users

@Functional
Scenario: 39549 - Verify validation of Zip or Postal field of Claim Payable To Section section when country is neither Canada nor United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 15 alpha numeric , text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states for external users

@Functional
Scenario: 39549 - Try passing more than 15 alpha numeric, text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 15 alpha numeric , text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states

@Functional
Scenario: 39549 - Try passing more than 15 alpha numeric, text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 15 alpha numeric , text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states

@Functional	 
Scenario: 39549 - Verify validation of Contact Name field im Claim Payable To section of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to Contact Name field

@Functional
Scenario: 39549 - Verify validation of Contact Name field im Claim Payable To section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to Contact Name field

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to Contact Name field of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to Contact Name field

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to Contact Name field of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to Contact Name field

@Functional
Scenario: 39549 - Verify validation of Contact Phone field im Claim Payable To section of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 20 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field

@Functional
Scenario: 39549 - Verify validation of Contact Phone field im Claim Payable To section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 20 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field

@Functional
Scenario: 39549 - Try passing more than 20 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 20 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field

@Functional
Scenario: 39549 - Try passing more than 20 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 20 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field

@Functional
Scenario: 39549 - Try passing less than 10 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass less than 10 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field

@Functional
Scenario: 39549 - Try passing less than 10 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass less than 10 numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field

@Functional
Scenario: 39549 - Try passing invalid email id to Contact Email field in Claim Payable To section of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page i pass an invalid Email id to Contact email field of Claim Payable To section and click on submit button
	Then I must be able to see Contact email field of Claim Payable To section getting highlighted

@Functional	
Scenario: 39549 - Try passing invalid email id to Contact Email field in Claim Payable To section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page i pass an invalid Email id to Contact email field of Claim Payable To section and click on submit button
	Then I must be able to see Contact email field of Claim Payable To section getting highlighted

@Functional	
Scenario: 39549 - Verify validation of Contact Website field im Claim Payable To section of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to Contact Website field

@Functional 
Scenario: 39549 - Verify validation of Contact Website field im Claim Payable To section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to pass a maximum of 50 alpha-numeric, text, special characters to Contact Website field
 
@Functional  
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to Contact Website field of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to Contact Website field
 
@Functional 
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to Contact Website field of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to Contact Website field
 
@Functional
Scenario: 39549 - Verify verbiage of Claim Details section on Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see a verbiage beneath claim details section as - Claims must be supported by a detailed statement showing how the amount of your claim was determined. Please include a complete description of the damaged or lost items and include item numbers or model numbers which should coincide with the invoice you are submitting.

@Functional
Scenario: 39549 - Verify verbiage of Claim Details section on Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see a verbiage beneath claim details section as - Claims must be supported by a detailed statement showing how the amount of your claim was determined. Please include a complete description of the damaged or lost items and include item numbers or model numbers which should coincide with the invoice you are submitting.

@Functional
Scenario: 39549 - Verify the existence and default value selected for Articles Insured field in Claims details section of Submit a Claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see Articles Insured field and it should be defaulted to NO.

@Functional
Scenario: 39549 - Verify the existence and default value selected for Articles Insured field in Claims details section of Submit a Claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I must be able to see Articles Insured field and it should be defaulted to NO.

@Functional
Scenario: 39549 - Verify Insured Value amount field when Articles Insured is selected as 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I select 'Yes' as Articles Insured 
	Then I should be able to view Insured value amount as a required field
	And I should be able to pass value to Insured Value amount field

@Functional
Scenario: 39549 - Verify Insured Value amount field when Articles Insured is selected as 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I select 'Yes' as Articles Insured 
	Then I should be able to view Insured value amount as a required field
	And I should be able to pass value to Insured Value amount field

@Functional	 
Scenario: 39549 - Verify validation for Insured value amount field when Articles Insured is selected as 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I select 'Yes' as Articles Insured 
	Then The data entered in Insured value amount field should be in currency format

@Functional
Scenario: 39549 - Verify validation for Insured value amount field when Articles Insured is selected as 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I select 'Yes' as Articles Insured 
	Then The data entered in Insured value amount field should be in currency format

@Functional
Scenario: 39549 - Verify Insured value amount field when Articles Insured is selected as 'No' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	When 'No' is selected as Articles Insured by default
	Then The Insured value amount field should be hidden

@Functional
Scenario: 39549 - Verify Insured value amount field when Articles Insured is selected as 'No' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When 'No' is selected as Articles Insured by default 
	Then The Insured value amount field should be hidden

@Functional
Scenario: 39549 - Verify the existence and functionality of Claim type field in claim details section of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Claim type label with Damage and Shortage as options to select
	And No option should be selected by default
	And I should be able to select either Damage or Shortage option

@Functional
Scenario: 39549 - Verify the existence and functionality of Claim type field in claim details section of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Claim type label with Damage and Shortage as options to select
	And No option should be selected by default
	And I should be able to select either Damage or Shortage option

@Functional
Scenario: 39549 - Verify the existence and functionality of Article type field in claim details section of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Article type label with New and Used as options to select
	And No option should be selected by default for articles type
	And I should be able to select either New or Used option

@Functional
Scenario: 39549 - Verify the existence and validation of Article type field in claim details section of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Article type label with New and Used as options to select
	And No option should be selected by default for articles type
	And I should be able to select either New or Used option

@Functional
Scenario: 39549 - Verify validation for Item or Model number by passing a maximum of 50 alpha-numeric, text, special characters on Claim details section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 50 alpha-numeric, text, special characters to Item or Model number field

@Functional
Scenario: 39549 - Verify validation for Item or Model number by passing a maximum of 50 alpha-numeric, text, special characters on Claim details section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 50 alpha-numeric, text, special characters to Item or Model number field

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to Item or Model field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to Item or Model number field

@Functional
Scenario: 39549 - Try passing more than 50 alpha-numeric, text, special characters to Item or Model field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 50 alpha-numeric, text, special characters to Item or Model number field

@Functional
Scenario: 39549 - Verify validation for Unit Value field of claim details section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass value to Unit value field and the format should be currency

@Functional
Scenario: 39549 - Verify validation for Unit Value field of claim details section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass value to Unit value field and the format should be currency

@Functional
Scenario: 39549 - Verify validation for Quantity field by passing a value greater than zero for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a value greater than zero to Quantity field of claim details section

@Functional
Scenario: 39549 - Verify validation for Quantity field by passing a value greater than zero for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a value greater than zero to Quantity field of claim details section

@Functional
Scenario: 39549 - Try passing zero to Quantity field of claim details section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass zero to Quantity field of claim details section

@Functional
Scenario: 39549 - Try passing zero to Quantity field of claim details section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass zero to Quantity field of claim details section

@Functional
Scenario: 39549 - Verify validation for Weight field of claim details section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass value to weight field and # should be displayed after value, two decimal places

@Functional
Scenario: 39549 - Verify validation for Weight field of claim details section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass value to weight field and # should be displayed after value, two decimal places

@Functional
Scenario: 39549 - Verify existence and functionality of Description of Claimed Articles field by passing a maximum of 500 alpha-numeric, text, special characters for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 500 alpha-numeric, text, special characters to Description of Claimed Articles field

@Functional
Scenario: 39549 - Verify existence and functionality of Description of Claimed Articles field by passing a maximum of 500 alpha-numeric, text, special characters for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to pass a maximum of 500 alpha-numeric, text, special characters to Description of Claimed Articles field

@Functional
Scenario: 39549 - Try passing more than 500 alpha-numeric, text, special characters to Description of Claimed Articles field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 500 alpha-numeric, text, special characters to Description of Claimed Articles field

@Functional
Scenario: 39549 - Try passing more than 500 alpha-numeric, text, special characters to Description of Claimed Articles field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 500 alpha-numeric, text, special characters to Description of Claimed Articles field

@Functional
Scenario: 39549 - Verify the existence of Add Another Item hyperlink on claim details section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Add Another Item hyperlink on claim details section

@Functional
Scenario: 39549 - Verify the existence of Add Another Item hyperlink on claim details section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Add Another Item hyperlink on claim details section

@Functional
Scenario: 39549 - Verify default selection and functionality of Do you wish to add freight charges? field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view 'No' as default selection for Do you wish to add freight charges? field
	And I should be able to select 'Yes' or 'No' option

@Functional
Scenario: 39549 - Verify default selection and functionality of Do you wish to add freight charges? field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view 'No' as default selection for Do you wish to add freight charges? field
	And I should be able to select 'Yes' or 'No' option

@Functional
Scenario: 39549 - Verify the existence and functionality of Original Freight Charges option field when Do you wish to add freight charges is equal to 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Original Freight Charges option field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to Click Original Freight Charges option field

@Functional
Scenario: 39549 - Verify the existence and functionality of Original Freight Charges option field when Do you wish to add freight charges is equal to 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Original Freight Charges option field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to Click Original Freight Charges option field

@Functional
Scenario: 39549 - Verify the existence and functionality of Original Freight Charges Value field when Do you wish to add freight charges is equal to 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Original Freight Charges Value field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to pass value to Original Freight Charges Value field and format should be currency

@Functional
Scenario: 39549 - Verify the existence and functionality of Original Freight Charges Value field when Do you wish to add freight charges is equal to 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Original Freight Charges Value field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to pass value to Original Freight Charges Value field and format should be currency

@Functional
Scenario: 39549 - Verify the existence and functionality of Return Freight Charges option field when Do you wish to add freight charges is equal to 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Return Freight Charges option field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to select Return Freight Charges option field

@Functional
Scenario: 39549 - Verify the existence and functionality of Return Freight Charges option field when Do you wish to add freight charges is equal to 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Return Freight Charges option field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to select Return Freight Charges option field

@Functional
Scenario: 39549 - Verify the existence and functionality of Return Freight Charges Value field when Do you wish to add freight charges is equal to 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Return Freight Charges Value field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to pass value to Return Freight Charges Value field and format should be currency

@Functional
Scenario: 39549 - Verify the existence and functionality of Return Freight Charges Value field when Do you wish to add freight charges is equal to 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Return Freight Charges Value field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to pass value to Return Freight Charges Value field and format should be currency

@Functional
Scenario: 39549 - Verify the existence and functionality of DLSW Ref # field when Do you wish to add freight charges is equal to 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view DLSW Ref # field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to pass a maximum of 20 alpha-numeric value to DLSW Ref # field 

@Functional
Scenario: 39549 - Verify the existence and functionality of DLSW Ref # field when Do you wish to add freight charges is equal to 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view DLSW Ref # field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to pass a maximum of 20 alpha-numeric value to DLSW Ref # field 

@Functional
Scenario: 39549 - Try passing more than 20 alpha-numeric characters to DLSW Ref # field when Do you wish to add freight charges is equal to 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view DLSW Ref # field when Do you wish to add freight charges is equal to 'Yes'
	And I should not be able to pass more than 20 alpha-numeric value to DLSW Ref # field

@Functional
Scenario: 39549 - Try passing more than 20 alpha-numeric characters to DLSW Ref # field when Do you wish to add freight charges is equal to 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view DLSW Ref # field when Do you wish to add freight charges is equal to 'Yes'
	And I should not be able to pass more than 20 alpha-numeric value to DLSW Ref # field

@Functional
Scenario: 39549 - Verify the existence and functionality of Replacement Freight Charges option field when Do you wish to add freight charges is equal to 'Yes' for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Replacement Freight Charges option field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to select Replacement Freight Charges option field 

@Functional
Scenario: 39549 - Verify the existence and functionality of Replacement Freight Charges option field when Do you wish to add freight charges is equal to 'Yes' for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Replacement Freight Charges option field when Do you wish to add freight charges is equal to 'Yes'
	And I should be able to select Replacement Freight Charges option field  

@Functional
Scenario: 39549 - Verify the existence and functionality of Subtotal All Claim Value field for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Subtotal All Claim Value field
	And Subtotal All Claim Value field should display sum of Original Freight Charges+Return Freight Charges+Replacement Freight Charges values
	And Subtotal All Claim Value field format should be currency

@Functional
Scenario: 39549 - Verify the existence and functionality of Subtotal All Claim Value field for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Subtotal All Claim Value field
	And Subtotal All Claim Value field should display sum of Original Freight Charges+Return Freight Charges+Replacement Freight Charges values
	And Subtotal All Claim Value field format should be currency

@Functional
Scenario: 39549 - Verify all the required fields of claims details section when Do you wish to add freight charges is equal to zero for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I choose 'Yes' for Do you wish to add freight charges field
	And I choose 'Yes' for Articles Insured field
	And I click on submit button
	Then I should see the following fields getting highlighted -Insured Value Amount, Original Freight Charges Value, Return Freight Charges Value, Replacement Freight Charges Value, Subtotal All Claim Value

@Functional
Scenario: 39549 - Verify all the required fields of claims details section when Do you wish to add freight charges is equal to zero for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I choose 'Yes' for Do you wish to add freight charges field
	And I choose 'Yes' for Articles Insured field
	And I click on submit button
	Then I should see the following fields getting highlighted -Insured Value Amount, Original Freight Charges Value, Return Freight Charges Value, Replacement Freight Charges Value, Subtotal All Claim Value

@Functional
Scenario: 39549 - Verify the existence and functionality of Remarks field by passing a maximum of 500 alpha-numeric, text, special characters to sign off section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view remarks field on sign off section
	And I should be able to pass a maximum of 500 alpha-numeric, text, special characters to sign off section 

@Functional
Scenario: 39549 - Verify the existence and functionality of Remarks field by passing a maximum of 500 alpha-numeric, text, special characters to sign off section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view remarks field on sign off section
	And I should be able to pass a maximum of 500 alpha-numeric, text, special characters to sign off section 

@Functional
Scenario: 39549 - Try passing a more than 500 alpha-numeric, text, special characters to sign off section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 500 alpha-numeric, text, special characters to sign off section

@Functional
Scenario: 39549 - Try passing a more than 500 alpha-numeric, text, special characters to sign off section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should not be able to pass more than 500 alpha-numeric, text, special characters to sign off section

@GUI
Scenario: 39549 - Verify display of verbiage next to Remarks field label of sign off section for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view a verbiage next to remarks field label stating - Please describe what prompted your claim. Try to be as detailed as possible.

@GUI
Scenario: 39549 - Verify display of verbiage next to Remarks field label of sign off section for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view a verbiage next to remarks field label stating - Please describe what prompted your claim. Try to be as detailed as possible.

@GUI  @Sprint 79
Scenario: 32056 - Verify the existence of Confirmation of accuracy check box in sign off section for external users
	Given I am an external user who have access to the application
	When I am on the Submit A Claim form
	Then I should not be able to see Confirmation of accuracy check box in sign off section
	

@GUI @Sprint 79
Scenario: 32056 - Verify the existence of Confirmation of accuracy check box in sign off section for internal users
	Given I am an internal user who have access to the application
	When I am on the Submit A Claim form
	Then I should not be able to see Confirmation of accuracy check box in sign off section

@GUI @Sprint 79 
Scenario: 32056 - Verify the existence of Signature level and field for external user
	Given I am an external user who have access to the application
	When I am on the Submit A Claim form
	Then I should not be able to see Signature level and field

@GUI @Sprint 79 
Scenario: 32056 - Verify the existence of Signature level and field for internal user
	Given I am an internal user who have access to the application
	When I am on the Submit A Claim form
	Then I should not be able to see Signature level and field

@GUI @Sprint 79
Scenario: 32056 - Verify display of verbiage after the <Remarks> field for external users
	Given I am an external user who have access to the application
	When I am on the Submit A Claim form
	Then I will be able to see the verbiage after the Remarks field and prior to the Submit Claim button 

@GUI @Sprint 79
Scenario: 32056 - Verify display of verbiage after the <Remarks> field for internal users
	Given I am an internal user who have access to the application
	When I am on the Submit A Claim form
	Then I will be able to see the verbiage after the Remarks field and prior to the Submit Claim button 


@GUI
Scenario: 39549 - Verify the existence of Submit claim button on Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Submit Claim buttton on Submit a claim page

@GUI
Scenario: 39549 - Verify the existence of Submit claim button on Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then I should be able to view Submit Claim buttton on Submit a claim page

@GUI
Scenario: 39549 - Verify tool tip for Claim payable to information icon of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I hover over the Claim Payable To Tool Tip/Information icon
	Then I will see the verbiage - If you are not the beneficial owner of the goods we may require proof of payment to the beneficial owner of the goods prior to payment of the claim to you.

@GUI
Scenario: 39549 - Verify tool tip for Claim payable to information icon of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I hover over the Claim Payable To Tool Tip/Information icon
	Then I will see the verbiage - If you are not the beneficial owner of the goods we may require proof of payment to the beneficial owner of the goods prior to payment of the claim to you.

@GUI
Scenario: 39549 - Verify tool tip for Freight Charges information icon of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I hover over the Freight Charges Tool Tip/Information icon
	Then I will see the verbiage - If shipment is not a total loss, freight charges will be pro rated based on weight of the affected commodity.

@GUI
Scenario: 39549 - Verify tool tip for Freight Charges information icon of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I hover over the Freight Charges Tool Tip/Information icon
	Then I will see the verbiage - If shipment is not a total loss, freight charges will be pro rated based on weight of the affected commodity.

@GUI
Scenario: 39549 - Verify the font size and font colour of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then The font size will be 20,
	And The font color will be black.

@GUI @32314
Scenario: 39549 - Verify the font size and font colour of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then The font size will be 20,
	And The font color will be black.

@GUI @32314
Scenario: 32314 - Verify the font size of inline labels of Submit a claim page for external users
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then The font size of inline labels should be 12px

@GUI @32314
Scenario: 32314 - Verify the font size of inline labels of Submit a claim page for internal users
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then The font size of inline labels should be 12px

@GUI @Functional
Scenario: 39549 - Verify the existence and functionality of Remove button when Add Another Item hyperlink is clicked for external users 
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I click on Add Another Item hyperlink
	Then I should be able to view a Remove button
	
@GUI @Functional
Scenario: 39549 - Verify the existence and functionality of Remove button when Add Another Item hyperlink is clicked for internal users 
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	When I click on Add Another Item hyperlink
	Then I should be able to view a Remove button
	
#-----------------------------------------------------------------------------------------------------------------------------------------------------
@53600 @Sprint88
Scenario: 53600_Verify 3 letter station reference in "Enter DLSW Ref # to Start Process" field when DLSW shipment reference number with lower case letters is entered
	Given I am a DLS user who have access to Insurance Claims
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	And I enter a valid DLSW shipment reference number (with station reference in lower case) in the Enter DLSW Ref # to Start Process field
	When I Click on Populate Form button	
	Then the three letter station reference in the DLSW Ref # should be displayed in Uppercase alphabets

@53600 @Sprint88
Scenario: 53600_Verify 3 letter station reference in the "DLSW Ref #" field when DLSW shipment reference number with lower case letters is entered and tabbed out
	Given I am a DLS user who have access to Insurance Claims
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	And I enter a valid DLSW shipment reference number (with station reference in lower case) in the DLSW Ref # field in Carrier Information section
	When I tab out of the DLSW Ref # field
	Then the three letter station reference in the DLSW Ref # should be displayed in Uppercase alphabets

@53600 @Sprint88
Scenario: 53600_Verify 3 letter station reference in the DLSW Ref # field when DLSW shipment reference number with lower case letters is entered and clicked anywhere outside the field
	Given I am a DLS user who have access to Insurance Claims
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	And I enter a valid DLSW shipment reference number (with station reference in lower case) in the DLSW Ref # field in Carrier Information section
	When I click anywhere outside DLSW Ref # field
	Then the three letter station reference in the DLSW Ref # should be displayed in Uppercase alphabets

@53600 @Sprint88
Scenario: 53600_Verify that the # (pound) character doesn't display when user enters valid data in Weight(LBS) field and moves out of that field
	Given I am a DLS user who have access to Insurance Claims
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	And I enter valid data in the Weight (LBS) in the Claim Details section
	When I click anywhere outside Weight (LBS) field
	Then the # character should not be displayed in the Weight (LBS) field

@53600 @Sprint88
Scenario: 53600_Verify that the # (pound) character doesn't display when user enters a valid data in Weight(LBS) field for an additional item and moves out of that field
	Given I am a DLS user who have access to Insurance Claims
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	And I Click on Add Another Item button
	And I enter valid data in the Weight (LBS) in the Claim Details section
	When I click anywhere outside Weight (LBS) field
	Then the # character should not be displayed in the Weight (LBS) field

	#Negative scenarios
@53600 @Sprint88
Scenario: 53600_Verify 3 letter station reference in "Enter DLSW Ref #" to Start Process field when DLSW shipment reference number with upper case letters is entered
	Given I am a DLS user who have access to Insurance Claims
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	And I enter a valid DLSW shipment reference number (with station reference in upper case) in the Enter DLSW Ref # to Start Process field
	When I Click on Populate Form button	
	Then the three letter station reference in the DLSW Ref # should be displayed in Uppercase alphabets

@53600 @Sprint88
Scenario: 53600_Verify 3 letter station reference in the "DLSW Ref #" field when DLSW shipment reference number with upper case letters is entered and clicked anywhere outside the field
	Given I am a DLS user who have access to Insurance Claims
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	And I enter a valid DLSW shipment reference number (with station reference in upper case) in the DLSW Ref # field in Carrier Information section
	When I click anywhere outside DLSW Ref # field
	Then the three letter station reference in the DLSW Ref # should be displayed in Uppercase alphabets

@53600 @Sprint88
Scenario: 53600_Verify that the # character doesn't display when the user enters a value with # character in Weight (LBS) field and moves out of that field
	Given I am a DLS user who have access to Insurance Claims
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	And I arrive on Submit a Claim page
	And I enter weight value along with # character in the Weight (LBS) in the Claim Details section
	When I click anywhere outside Weight (LBS) field
	Then the # character should be removed from the Weight (LBS) field

@111029 @Sprint93
Scenario: 111029 - Zero is displayed in Quantity field of Submit a claim page by default for external user
	Given I am an external user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then Quantity Field Should be Empty

@111029 @Sprint93 
Scenario: 111029 - Zero is displayed in Quantity field of Submit a claim page by default for internal user
	Given I am an internal user who have access to the application
	And I click on Insurance claim icon
	And I click on Submit a claim button on claim list page
	When I arrive on Submit a Claim page
	Then Quantity Field Should be Empty

@Sprint94 @107648
Scenario Outline: 107648 Verify the presence of new field Customer Claim Ref # (alpha-numeric, text, special characters, max length 20) in Submit a Claim page
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User <UserType>,<UserName>,<Password>
And I click on Insurance claim icon
And I click on Submit a claim button on claim list page
When I arrive on Submit a Claim page
Then I will see a new optional field Customer Claim Ref # (editable,alpha-numeric, text, special characters, max length 20)

Examples: 
		| UserType        | UserName								 | Password								   |
		| Internal        | username-CurrentSprintOperations         | password-CurrentSprintOperations        |
		| Sales           |	username-CurrentSprintSales			     | password-CurrentSprintSales			   |
		| Claimspecialist | username-CurrentsprintClaimspecialist    | password-CurrentsprintClaimspecialist   |
		| External        | username-CurrentSprintshpentry           | password-CurrentSprintshpentry          |




