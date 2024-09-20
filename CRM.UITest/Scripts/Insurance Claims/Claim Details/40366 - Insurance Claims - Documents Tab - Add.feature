@Sprint84 @40366 

Feature: 40366 - Insurance Claims - Documents Tab - Add
	
@GUI
Scenario: 40366-Verify the display and behaviour of the Add Additional Document button 
          Given I am a Claims Specialist User
          And I clicked on the hyperlink of any displayed claim on the Claim list
          And I arrive on the Claim Details page of the selected claim
          And I clicked on the Document Tab
		  When I click on the Add Additional Document button on the Document tab
		  Then I will see a Document Type drop down list
		  And the default selection in the drop down list will be <Select document type...>
          And I will see an inactive document upload icon
          And I will see the verbiage <No file currently uploaded> next to the document upload icon
          And I will see a Remove button for the Additional Document Type section
          And I will see an Add Additional Document button on the Document Tab

@GUI
Scenario: 40366-Verify the Document Type drop down list values and order of the list 
          Given I am a Claims Specialist User
          And I clicked on the hyperlink of any displayed claim on the Claim list
          And I arrive on the Claim Details page of the selected claim
          And I clicked on the Document Tab
		  And I clicked on the Add Additional Document button
		  When I click in the Document Type drop down list
		  Then I will see list of Document types <"Complete Vendor Invoice", "Airway Bill", "Bill of Lading", "Claimant's Form W-9", "Concealed Damage Notification", "Customs Document", "Delivery Receipt", "Inspection Report", "Ocean Bill of Lading", "Packing List", "Pictures - On Receipt", "Pictures - Prior to Shipment", "Repair Invoice", "Other">
		  And <Complete Vendor Invoice> will be displayed first in the list
		  And <Other> will be displayed last in the list 
		  And all other documents will displayed alphabetically after <Complete Vendor Invoice>
		  And the document list is configurable

@GUI
Scenario: 40366-Verify the behaviour of the upload icon when I select the Document Type from the drop down list
          Given I am a Claims Specialist User
          And I clicked on the hyperlink of any displayed claim on the Claim list
          And I arrive on the Claim Details page of the selected claim
          And I clicked on the Document Tab
		  And I clicked on the Add Additional Document button
		  When I choose a document type from the document type drop down list
		  Then the document upload icon should be active

@GUI 
Scenario: 40366-Verify the Acceptable file type validation while uploading a document 
          Given I am a Claims Specialist User
          And I clicked on the hyperlink of any displayed claim on the Claim list
          And I arrive on the Claim Details page of the selected claim
          And I clicked on the Document Tab
		  And I have selected a valid document to upload <.doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf, .txt, .tif, .jpg, .png> from Add Additional Document
		  When I close the search dialogue box
		  Then the selected file must pass the Acceptable file type validation



@GUI  
Scenario: 40366-Verify the Document display on Document Tab when it passes the Acceptable file type validation
          Given I am a Claims Specialist User
          And I clicked on the hyperlink of any displayed claim on the Claim list
          And I arrive on the Claim Details page of the selected claim
          And I clicked on the Document Tab
		  And I clicked on the Add Additional Document button
		  And I selected a document type from the drop down list
		  And I clicked on the file upload icon to select a valid document to upload
		  When the document passes the Acceptable file type and size validation
		  Then I should see uploaded document displayed on the Document Tab


@GUI 
Scenario: 40366-Verify the message displayed when the document selected is not an acceptable type
          Given I am a Claims Specialist User
          And I clicked on the hyperlink of any displayed claim on the Claim list
          And I arrive on the Claim Details page of the selected claim
          And I clicked on the Document Tab
		  And I clicked on the Add Additional Document button
		  And I selected a document type from the drop down list
		  And I clicked on the file upload icon to select a invalid document to upload
		  And I closed the search dialogue box
		  When the document selected is not an acceptable type
		  Then I will see a message : <The selected file type is not allowed.  Please select an approved file type.>
		  And the document will not be displayed on the Document Tab

@GUI 
Scenario: 40366-Verify the message displayed when the document selected is greater than 10MB
          Given I am a Claims Specialist User
          And I clicked on the hyperlink of any displayed claim on the Claim list
          And I arrive on the Claim Details page of the selected claim
          And I clicked on the Document Tab
		  And I clicked on the Add Additional Document button
		  And I selected a document type from the drop down list
		  And I clicked on the file upload icon to select a file greater than tenMB
		  And I closed the search dialogue box
		  When the document selected size is greater than 10MB
		  Then I will see a message as <The selected file size exceeds 10MB. Please attach a file that is less than 10MB.>
		  And the document will not be displayed on the Document Tab

@GUI  @Ignore
Scenario: 40366-Verify the behaviour of the Remove button 
          Given I am a Claims Specialist User
          And I clicked on the hyperlink of any displayed claim on the Claim list
          And I arrive on the Claim Details page of the selected claim
          And I clicked on the Document Tab
		  And I clicked on the Add Additional Document button
		  When I click on the Remove button for the Additional Document
		  Then the additional Document Type section should be removed

@GUI
Scenario: 40366-Verify the non existance of Remove button for station users
          Given I am a sales, sales management, operations, or station owner
		  And I clicked on the hyperlink of any displayed claim on the Claim list for station users
          And I arrive on the Claim Details page of the selected claim
          When I click on the Document tab
          Then I should not see the Remove button

@GUI
Scenario: 40366-Verify the non existance of Add Additional Document button for station users
          Given I am a sales, sales management, operations, or station owner
          And I clicked on the hyperlink of any displayed claim on the Claim list for station users
          And I arrive on the Claim Details page of the selected claim
          When I click on the Document tab
          Then I should not see the Add Additional Document button
