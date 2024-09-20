@38471 @Sprint76
Feature: TrackingPage-TrackingTemplateValidations-ExternalUsers
	
@GUI
Scenario Outline: 38471_Verify Cancel Button functionality while uploading template
	Given I am a DLS user and launch crm url
	And I enter the '<validReferenceNumber>' in the search box
	And I arrive on Tracking details page
	And I clicked on Upload Template button
	When I click on Cancel button in upload shipments modal
	Then upload shipments modal will close

Examples: 
| scenario | validReferenceNumber |
| s1       | PIT01217989          |

@GUI
Scenario Outline: 38471_Verify error message when user click on submit without selecting any file in modal
	Given I am a DLS user and launch crm url
	And I enter the '<validReferenceNumber>' in the search box
	And I arrive on Tracking details page
	And I clicked on Upload Template button
	When I click on upload shipments modal Submit button
	Then I will display with '<errorMessage>'

Examples: 
| scenario | validReferenceNumber | errorMessage           |
| s1       | 9920495              | Please select the file |

@GUI
Scenario Outline: 38471_Verify Select file button functionality in Upload shipments modal
	Given I am a DLS user and launch crm url
	And I enter the '<validReferenceNumber>' in the search box
	And I arrive on Tracking details page
	And I clicked on Upload Template button	
	When I uploaded a file <filePath>
	Then selected file should be displayed

Examples: 
| scenario | validReferenceNumber | filePath                                                                                               |
| s1       | 9900003              | ..\\..\\Scripts\\TestData\\Testfiles_trackingupload\\Allvalidreferences\\ShipmentTrackingTemplate.xlsx |

@GUI
Scenario Outline: 38471_Verify error message when user uploaded invalid file in modal
	Given I am a DLS user and launch crm url
	And I enter the '<validReferenceNumber>' in the search box
	And I arrive on Tracking details page
	And I clicked on Upload Template button	
	When I have uploaded the invalid file <invalidFilePath>
	And I click on upload shipments modal Submit button
	Then I will see an error message <errorMessage> in popup and file will not be uploaded
	And upload shipments modal will be opened

Examples: 
| scenario | validReferenceNumber | invalidFilePath                                                                 | errorMessage        |
| s1       | LEX83064995          | ..\\..\\Scripts\\TestData\\Testfiles_trackingupload\\Invalidextension\\test.PNG | Invalid input file. |



