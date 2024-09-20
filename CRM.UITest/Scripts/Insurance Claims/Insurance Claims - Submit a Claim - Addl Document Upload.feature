@Sprint79 @Regression
Feature: Insurance Claims - Submit a Claim - Addl Document Upload

@GUI
Scenario: 32016 - Verify document Type drop down on Submit a claim page on click of Add Additional document button
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page
	 When I click on Add Additional Document button
	 Then I should be able to view a Document Type drop down list
	 And The default selection in the drop down list should be - Select document type

@GUI
Scenario: 32016 - Verify the existence of document upload button on click of Add Additional Document button 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page
	 When I click on Add Additional Document button
	 Then I should be able to view document upload button
	 And The document upload button should be inactive

@GUI
Scenario: 32016 - Verify the verbiage next to document upload button on submit a claim page on click of Add Additional Document button
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page
	 When I click on Add Additional Document button
	 Then I should be able to view a verbiage next to document upload button stating - No file currently uploaded

@GUI
Scenario: 32016 - Verify the existence of Remove button on click of Add Additional Document button
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page
	 When I click on Add Additional Document button
	 Then I should be able to view remove button

@GUI
Scenario: 32016 - Verify document upload icon behaviour while selecting a document from the document drop down list 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I select a document from the document drop down list
	 Then The document upload icon will be active.

@GUI
Scenario: 32016 - Verify the existence of expected Document Type field drop down list values 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I click on Document Type field drop down list
	 Then I should be able to view the following values in the Document Type field drop down list - Complete Vendor Invoice, Airway Bill, Bill of Lading, Claimant's Form W-9, Concealed Damage Notification, Customs Document, Delivery Receipt, Inspection Report, Ocean Bill of Lading, Packing List, Pictures - On Receipt, Pictures - Prior to Shipment, Repair Invoice, Other

@GUI
Scenario: 32016 - Verify the first and last selectable option in the Document Type field drop down list 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I click on Document Type field drop down list
	 Then Complete Vendor Invoice should be displayed first in the list
	 And Other should be displayed last in the list

@GUI
Scenario: 32016 - Verify if document selection options in the Document Type field drop down list is in alphabetical order except for the first and last option
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I click on Document Type field drop down list
	 Then I should be able to view document selection options in the Document Type field drop down list sorted alphabetically except for the first and last option

@DBVerification
Scenario: 32016 - Verify document selection options in the Document Type field drop down list with DB 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I click on Document Type field drop down list
	 Then All the displayed document selection options should be present in DB

@GUI
Scenario: 32016 - Verify tool tip verbiage when Repair Invoice is selected as document type 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I select Repair Invoice as document type
	 Then I should be able to view a tool tip for Repair Invoice
	 And On mouse hover i should see a verbiage stating - This should be detailed out by parts and labor, including labor rate.

@GUI
Scenario: 32016 - Verify tool tip verbiage when Complete Vendor Invoice is selected as document type 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I select Complete Vendor Invoice as document type
	 Then I should be able to view a tool tip for Complete Vendor Invoice
	 And On mouse hover i should see a verbiage stating - This invoice should show your cost for the product being claimed.

@Functional
Scenario: 32016 - Verify the functionality of Remove button on Add Additional Document section 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I click on the Remove button
	 Then The additional document section will be removed.

@Functional @GUI
Scenario: 32016 - Try to submit claim without uploading document in the Add Additional Document section
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 And Document is not been uploaded 
	 When I click Submit Claim button 
	 Then I will receive an error message stating - Please add document to claim form
	 And The page will be focused to the Additional Document section.

@Functional
Scenario: 32016 - Try selecting any document type from the Document Type field drop down list and upload a document 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I click on Document Type field drop down list
	 Then I should be able to select any document type from the Document Type field drop down list
	 And I should be able to upload a document

@GUI
Scenario: 32016 - Verify document upload button behaviour when user clicks on Document Type field drop down list 
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I click on Document Type field drop down
	 Then Document upload button should be inactive

@GUI
Scenario: 32016 - Verify Document type dropdown behaviour when user uploads a Valid document
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I upload a valid document
	 Then Document type dropdown should be in disabled

@GUI
Scenario: 32016 - Verify Document type dropdown behaviour when user deletes uploaded document
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I delete an uploaded document
	 Then Document type dropdown should be enabled

@GUI
Scenario: 32016 - Verify Document Upload button behaviour when user deletes uploaded document
	 Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user
	 And I am on Submit a Claim page 
	 And Additional Document section is visible
	 When I delete an uploaded document
	 Then Document upload button will be enabled once document type is selected

