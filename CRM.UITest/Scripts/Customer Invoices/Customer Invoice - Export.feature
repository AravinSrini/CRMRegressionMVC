@Sprint80 @CustomerInvoiceExport @40154
Feature: Customer Invoice - Export
	
@GUI
Scenario: 40154 - Verify the export options present in Customer Invoice list page
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on Customer Invoice page
	When I click on Export drop down arrow 
	Then I have the option to select All - Excel
	And I have the option to select All - PDF
	And I will no longer have an option to select All
	And I will no longer have an option to select Displayed

@GUI @Regression @50087 @PrioritySprint2
Scenario Outline: 40154 - Verify column headers of Customer Invoice excel
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on Customer Invoice page
	And I select a Open Saved Report <Report Name> from the dropdown
	When I click on Excel option from the export dropdown
	Then A Customer Invoice excel should get downloaded
	And The excel file should contain the following column names - Sales Rep, Account #, Station, Customer #, Customer Name, Invoice Number, Reference ID #, Invoice Date, Due Date, Original Amt, Outstanding Amt, Days Past Due, Dispute Code

	Examples: 
	| Report Name                            |
	| OpenInvoiceReport						 |


@Functional @Acceptance
Scenario: 40154 - Verify and compare the functionality of Export button when 'All - Excel' option is selected and 'Open' filer is applied
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on Customer Invoice page
	And Open filter is applied
	When I click on All - Excel option from the export dropdown
	Then A Customer Invoice excel should get downloaded
	And Excel sheet count and values should match with the UI count and values of Customer Invoice list page

@Functional @Acceptance
Scenario: 40154 - Verify and compare the functionality of Export button when 'All - Excel' option is selected and 'Closed' filer is applied
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, or access rrd user
	And I am on Customer Invoice page	
	And Closed filter is applied
	When I click on All - Excel option from the export dropdown
	Then A Customer Invoice excel should get downloaded
	And Excel sheet count and values should match with UI count and values of Customer Invoice list page	

@Functional @Acceptance
Scenario: 40154 - Verify and compare the functionality of Export button when 'All - Excel' option is selected and 'All' filer is applied
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on Customer Invoice page
	And All filter is applied
	When I click on All - Excel option from the export dropdown
	Then A Customer Invoice excel should get downloaded
	And Excel sheet count and values should match with the UI count and values of Customer Invoice list page

@Functional
Scenario: 40154 - Verify the functionality of Export button when 'All - PDF' option is selected 
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user
	And I am on Customer Invoice page
	When I click on All - PDF option from the export dropdown
	Then A Customer Invoice PDF document should get opened in an other tab

@GUI @Regression @50087 @PrioritySprint2
Scenario: 50087 - Verify column headers of Customer Invoice excel when Closed filter is applied
	Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, or access rrd user
	And I am on Customer Invoice page
	And Closed filter is applied	
	When I click on Excel option from the export dropdown
	Then A Customer Invoice excel should get downloaded
	And The excel file should contain the following column names - Sales Rep, Account #, Station, Customer #, Customer Name, Invoice Number, Reference ID #, Invoice Date, Due Date, Payment Date, Original Amt, Outstanding Amt, Dispute Code
	
@GUI @50087 @PrioritySprint2
Scenario Outline: 50087 - Verify the column Days Past Due is removed and a new column Payment Date is added next to Due Date in the exported excel file for Closed invoices searched through Search Invoices section
	Given I am a operations, sales, sales management, station owner or Access RRD User
	And I am on Customer Invoice page
	And I have selected an <Option> from the drop down list
	And I choose the <open or closed> radio button	
	And I enter data in the field <Search Text>
	And I click on the button search invoices
	When I click on Excel option from the export dropdown
	Then A Customer Invoice excel should get downloaded
	And The excel file should contain the following column names - Sales Rep, Account #, Station, Customer #, Customer Name, Invoice Number, Reference ID #, Invoice Date, Due Date, Payment Date, Original Amt, Outstanding Amt, Dispute Code

	Examples: 
	| Option          | Search Text     | open or closed |
	| Invoice Number  | 0637726704      | c              |