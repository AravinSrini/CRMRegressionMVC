@40287 @Sprint84 
Feature: 40287_Insurance Claims - Documents Tab - Elements

@GUI @Functional 
Scenario: 40287_Verify the click functionality of the document tab
Given I am a sales, sales management, operations, station owner and claims specialist user
And I clicked on the hyper link of a displayed claim of the Claims List page
And I arrive on the Details tab of the selected claim
When I click on the Document tab of the details tab
Then I will see a list of required documents 
And The required documents are <COMPLETE VENDOR INVOICE>
And I will see a list of documents associated to the claim
And I will see the document type 
And I will see the document name displayed as a hyper link


@GUI @Functional 
Scenario: 40287_Verify display of Delete icon, Add Additional Document button and note on the Document tab
Given I am a claims specialist user
And I clicked on the hyper link of a displayed claim of the Claims List page
And I arrive on the Details tab of the selected claim
When I click on the Document tab of the details tab
Then I will see a Delete icon next to each displayed document
And I will see Add Additional Document button
And I will see a note <Note: Acceptable file types are: .doc .docx .xls .xlsx .ppt .pptx .pdf .txt .tif .jpg .png. Individual file size must not exceed 10MB>

@GUI @Functional
Scenario: 40287_Verify the click functionality on the hyper link of any displayed document
Given I am a sales, sales management, operations, station owner and claims specialist user
And I clicked on the hyper link of a displayed claim of the Claims List page
And I arrive on the Details tab of the selected claim
And I clicked on the Document tab
When I click on the hyper link of any displayed document
Then The document will be displayed in a new browser tab




