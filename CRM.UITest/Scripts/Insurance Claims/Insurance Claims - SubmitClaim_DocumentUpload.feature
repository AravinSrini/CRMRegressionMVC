@Sprint 79 
Feature: Insurance Claims - SubmitClaim_DocumentUpload


@GUI
Scenario: 32041 - Verify the document section on Submit A Claim page
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	When I am on the Submit A Claim form
	Then I will see the Documents section below the Claim Details section

@GUI
Scenario: 32041 - Verify the verbiage from document section 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist 
	When I am on the Submit A Claim form
	Then the verbiage beneath the Documents section header will be, Note: Claim should be supported by the following documents.  Failure to include sufficient documentation may delay conclusion of your claim.  Acceptable file types are: .doc .docx .xls .xlsx .ppt .pptx .pdf .txt .tif .jpg .png  Individual file size must not exceed 10MB.


@GUI
Scenario: 32041 - Verify the required document type displaying by default
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist 
	When I am on the Submit A Claim form
	Then the required document displayed is <Complete Vendor Invoice>

@GUI
Scenario: 32041 - Verify the information hover icon next to the <Complete Vendor Invoice> document name 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	When I am on the Submit A Claim form
	Then I will see an information hover icon next to the <Complete Vendor Invoice> document name


@GUI
Scenario: 32041 - Verify the document upload button 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	When I am on the Submit A Claim form
	Then I will see a document upload button


@GUI
Scenario: 32041 - Verify if the document upload button is active 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	When I am on the Submit A Claim form
	Then the document upload button will be active


@GUI
Scenario: 32041- Verify the verbiage next to the document upload button 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	When I am on the Submit A Claim form
	Then I will see the verbiage next to the document upload button: <No file currently uploaded>



@GUI
Scenario: 32041 - Verify the Add Additional Document button 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist 
	When I am on the Submit A Claim form
	Then I will see an Add Additional Document button


@GUI
Scenario: 32041 - Verify the verbiage which is displaying in the tool tip 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	And I am on the Submit A Claim form
	When I hover over the Tool Tip icon displayed next to the required document <Complete Vendor Invoice>
	Then I will see the verbiage stating : This invoice should show your cost for the product being claimed. 



@GUI
Scenario: 32041 - Verify the file name displayed on the claim form as a hyperlink 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	And I am on the Submit A Claim form
	When I have uploaded a document
	Then the file name will be displayed on the Claim Form as a hyperlink



@GUI
Scenario: 32041 - Verify if "No file currently uploaded" verbiage is present after uploading a document 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	And I am on the Submit A Claim form
	When I have uploaded a document
	Then I will not see the verbiage: No file currently uploaded


@GUI
Scenario: 32041 - Verify the delete option after uploading a document 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	And I am on the Submit A Claim form
	When I have uploaded a document
	And I have the option to delete the document



@GUI @Functional
Scenario: 32041 - Verify the delete confirmation popup before deleting a document 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	And I am on the Submit A Claim form
	And I have uploaded a document
	When I click on the delete document button 
	Then I will be asked to confirm if I want to remove the document



@GUI @Functional
Scenario: 32041 - Verify if the delete modal is getting close after clicking on cancel button 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	And I am on the Submit A Claim form
	And I have uploaded a document
	And I click on the delete document button 
	When I click on Cancel button from the delete confirmation popup
	Then the modal will close and document will not be removed


@GUI @Functional
Scenario: 32041 - Verify by clicking on Delete button from the delete confirmation popup 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	And I am on the Submit A Claim form
	And I have uploaded a document
	And I click on the delete document button 
	When I click on Delete button from the delete confirmation popup
	Then the document will be removed from the claim form



@GUI
Scenario: 32041 - Verify the message by uploading a non acceptable file 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist  
	And I am on the Submit A Claim form
	When  I have selected a document to upload which is not an acceptable file type.
	Then I will receive a message: The selected file type is not allowed.  Please select an approved file type



@GUI 
Scenario: 32041 - Verify by trying to upload a document which exceeds the file size limit
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist 
	And I am on the Submit A Claim form
	When I have selected a document to upload which exceeds the file size limit
	Then I will receive a message: The selected file size exceeds 10MB. Please attach a file that is less than 10MB.


