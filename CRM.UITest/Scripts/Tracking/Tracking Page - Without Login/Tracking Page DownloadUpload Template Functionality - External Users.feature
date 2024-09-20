@38470 @Sprint76
Feature: Tracking Page DownloadUpload Template Functionality - External Users

@GUI @Functional
Scenario Outline: Verify the Download template functionality in the Tracking page
    Given I am a DLS user and launch crm url
	And I enter the '<validReferenceNumber>' in the search box
	When I click on the Download Template button
	Then Shipment Tracking template will be downloaded

	Examples:
	| Scenario | validReferenceNumber |
	| S1       | 9920495              |

@GUI @Functional
Scenario Outline:  Verify the upload Shipments modal template in the Tracking page
	Given I am a DLS user and launch crm url
	And I enter the '<validReferenceNumber>' in the search box
	When I click on the Upload Template button
	Then I should display Upload Shipments modal
    And I should display <message> on upload modal
    And I should display the Select File button
    And I should display the Cancel button
    And I should display the Submit button

	Examples:
	| Scenario | validReferenceNumber | message                                           |
	| S1       | 9920495              | Select an Excel file to track up to 25 shipments. |
