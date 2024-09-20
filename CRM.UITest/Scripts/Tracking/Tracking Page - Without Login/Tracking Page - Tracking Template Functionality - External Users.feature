@31879 @Sprint76
Feature: Tracking Page - Tracking Template Functionality - External Users
	
@Functional
Scenario Outline: 31879_test to verify the upload functionality with valid tracking numbers
Given I am a DLS user and launch crm url
And I enter the '<validReferenceNumber>' in the search box
When I arrive on Tracking details page
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then Ishould be able to see the results of tracking numbers for '<path>'

Examples: 
| scenario | validReferenceNumber | path                                                                                                   |
| s1       | 9900003              | ..\\..\\Scripts\\TestData\\Testfiles_trackingupload\\Allvalidreferences\\ShipmentTrackingTemplate.xlsx |


@Functional
Scenario Outline: 31879_test to verify the upload functionality with all invalid tracking numbers template
Given I am a DLS user and launch crm url
And I enter the '<validReferenceNumber>' in the search box
When I arrive on Tracking details page
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then Ishould bedisplaying with '<errorforallinvalid>' popup for all invaliddata

Examples: 
| scenario | validReferenceNumber | path                                                                                                   | errorforallinvalid                             |
| s1       | LEX83064995          | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Allinvalidrefernces\\ShipmentTrackingTemplate.xlsx | No data found for entered reference number(s). |


@functional
Scenario Outline: 31879_test to verify the upload functionality with invalid and valid tracking numbers
Given I am a DLS user and launch crm url
And I enter the '<validReferenceNumber>' in the search box
When I arrive on Tracking details page
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then I should be displayed with '<warningmessage>' for invalid tracking numbers and results for valid refrences "<path>"
  
Examples: 
| scenario | validReferenceNumber | path                                                                                                            | warningmessage                                                     |
| s1       | LEX83064995          | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Combinationofvalidandinvalid\\ShipmentTrackingTemplate.xlsx | Tracking details were not found for the following tracking numbers |