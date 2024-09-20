@41890 @Sprint78
Feature: Customer Invoice - Invoice Number Hyperlink
	
@Functional @Acceptance @GUI
Scenario: 41890_Test to verify customer invoice displayed in new tab for internal users
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Customer Invoices list page
	When I click on any invoice number	
	Then Invoice will be displayed in new tab of pdf format

@Functional @Acceptance @GUI
Scenario: 41890_Test to verify customer invoice displayed in new tab for external users
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
	And I am on the Customer Invoices list page
	When I click on any invoice number	
	Then Invoice will be displayed in new tab of pdf format

@Functional @Acceptance @GUI
Scenario: 41890_Test to verify the error message when customer invoice doesnot exist for internal users
	Given I am an operations, sales, sales management, or station owner user
	And I am on the Customer Invoices list page
	When I click on any invoice number which not exist
	Then I will receive a message of Invoice not available

@Functional @Acceptance @GUI
Scenario: 41890_Test to verify the error message when customer invoice doesnot exist for external users
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates user
	And I am on the Customer Invoices list page
	When I click on any invoice number which not exist	
	Then I will receive a message of Invoice not available
	

