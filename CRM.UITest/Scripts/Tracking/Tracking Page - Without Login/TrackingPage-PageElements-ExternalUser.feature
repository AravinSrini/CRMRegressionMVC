@31878 @Sprint76
Feature: TrackingPage-PageElements-ExternalUser
	
@GUI
Scenario Outline: 31878_Verify Tracking details page without login
	Given I am a DLS user and launch crm url
	And I enter the '<validReferenceNumber>' in the search box
	When I arrive on Tracking details page
	Then I will be displaying with SignIn, Download Template, Upload Template buttons and Reference Number search field
	And I will be displaying with <verbiage> above reference number field
	And searchShipments should be renamed with <filterStatus>
	And Filter Results Feature is placed in date and status filters bar

Examples: 
| scenario | validReferenceNumber | verbiage                                                                                         | filterStatus     |
| s1       | 9900003              | Perform an additional search. Enter up to 10 comma separated reference numbers – case sensitive. | Filter results…. |

@GUI
Scenario Outline: 31878_Verify SignIn functionality from tracking page
	Given I am a DLS user and launch crm url
	And I enter the '<validReferenceNumber>' in the search box
	When I arrive on Tracking details page
	And I click on SignIn button
	Then I will be navigating to CRM signin page

Examples: 
| scenario | validReferenceNumber |
| s1       | 9900003              |
	