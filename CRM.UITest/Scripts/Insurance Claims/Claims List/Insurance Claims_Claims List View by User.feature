@Sprint79 @31990 

Feature: Insurance Claims_Claims List View by User


@GUI
Scenario: 31990-Verify the default status selection on the Claims List page 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner, Claim Specialist users
	When I arrive on the Claims List page
	Then I can see Open status is selected by default
	And I have option to select to different status Pending, Denied, Paid, Cancelled
	

@Functional 
Scenario: 31990-Verify the Open status claims are displayed by the most recent submit date 
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner, Claim Specialist users
	When I arrive on the Claims List page
	Then all the claims in the Open status should be displayed by most recent date


@Functional 
Scenario: 31990-Verify the list of claims for the customer to which user is associated for external users
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, or shp.entrynorates user
	When I arrive on the Claims List page
	Then I should see a list of claims for the customer to which user is associated


@Functional 
Scenario: 31990-Verify the list of claims for the customer to which user is associated for sales user
    Given I am a sales user
	When I arrive on the Claims List page
	Then I should see a list of claims for the customer(s) to which user is associated

@GUI
Scenario Outline: 31990-Verify the color code of the all the status in the claims list page 
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner, Claim Specialist users
	When I arrive on the Claims List page
	Then Verify the color code <Color> of <status> Open, Pending, Denied, Paid, Cancelled in the claims list page
Examples: 
| status    | Color   |
| Open      | #4f81bd |
| Pending   | #674ea7 |
| Paid      | #6aa84f |
| Denied    | #a61c00 |
| Cancelled | #f6b26b |


@Functional
Scenario: 31990-Verify the claims List grid display when I unselect all the status options for external users
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, or shp.entrynorates user
  	When I arrive on the Claims List page
	And I uncheck all the display status options Paid, Open, Pending, Denied, Cancelled
	Then Grid should be updated to display all claims for the customer associated to the user


@Functional
Scenario: 31990-Verify the claims List grid display when I unselect all the status options for sales user
    Given I am a sales user
  	When I arrive on the Claims List page
	And I uncheck all the display status options Paid, Open, Pending, Denied, Cancelled
	Then Grid should be updated to display all claims for the customer(s) associated to the user

	#----------Sprint 94 - 108304 - Insurance Claims - Claims List - No Carrier Selected----#

@Sprint94 @108304
Scenario Outline: 108304_Test to verify that the Carrier name column status displayed as Not Assigned when no carrier name assigned
	Given I am a user and login into application with valid <UserName> and <Password>,	
	And I have claim(s) with <NoCarrierName> for <user>
	When I arrive on claim list page
	Then I will see Not Assigned as the carrier name in the Carrier column for those claims
	And I will not be displayed with Select... as the carrier name in the Carrier column for those claims

Examples: 
| UserName                              | Password                              | NoCarrierName | user            |
| username-CurrentSprintOperations      | password-CurrentSprintOperations      | Select...     | Internal        |
| username-CurrentSprintSales           | password-CurrentSprintSales           | Select...     | Sales           |
| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | Select...     | External        |
| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | Select...     | claimspecialist |

@Sprint94 @108304
Scenario Outline: 108304_Test to verify that the Carrier name column status when carrier name assigned
	Given I am a user and login into application with valid <UserName> and <Password>,	
	And I have claim(s) with <CarrierName> for <user>
	When I arrive on claim list page
	Then I will not see Not Assigned as the carrier name in the Carrier column for those claims

Examples: 
| UserName                              | Password                              | CarrierName    | user            |
| username-CurrentSprintOperations      | password-CurrentSprintOperations      | R & L Carriers | Internal        |
| username-CurrentSprintSales           | password-CurrentSprintSales           | Con-Way        | Sales           |
| username-CurrentSprintshpentry        | password-CurrentSprintshpentry        | R & L Carriers | External        |
| username-CurrentsprintClaimspecialist | password-CurrentsprintClaimspecialist | Con-Way        | claimspecialist |