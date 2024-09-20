@Sprint79 @31964 
Feature: Insurance Claims_Claims List Page Elements


@GUI @Acceptance
Scenario: 31964-Verify the navigation to the claim list page 
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
	When I click on the claim navigation icon
	Then I should be navigated to the Claim List page

@GUI
Scenario: 31964-Verify the claims list page elements for customers and station users
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
	When I arrive on the claim list page
	Then Verify the page elements on the claim list page for header with instructional verbiage
	And Verify a Submit a Claim button 
	And default Selection is Open status
	And Verify the search text box
	And Export button on the Claim list page
	And Grid View Option at top and bottom of the grid list


@GUI
Scenario: 31964-Verify the view options present in top grid display of the cliam list page 
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
	When I arrive on the claim list page
	Then I should be able to view Options '10 20 60 100 ALL' under dropdown in top grid of the cliam list page



@GUI
Scenario: 31964-Verify the default grid display option on the claim list page load 
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
	When I arrive on the claim list page
	Then only ten records should be displayed on the claim list page load

@GUI
Scenario: 31964-Verify the view options present in bottom grid display of the cliam list page 
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
	When I arrive on the claim list page
	Then I should be able to view Options 10, 20, 60, 100, and ALL under dropdown in bottom grid of the cliam list page

@GUI @Functional
Scenario: 31964-Verify the right navigation icon functionality on the claim list page 
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
	And I arrive on the claim list page
	When I click on the right navigation icon in the top grid on the claim list page
	Then Next set of records should be displayed on the claim list page
	And left navigation icon should be enabled on the claim list page

@GUI @Functional
Scenario: 31964-Verify the left navigation icon functionality on the claim list page 
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
	And I arrive on the claim list page
	When I click on the the left navigation icon in the top grid on the claim list page from the next set of records page
	Then I should see the previous default set of records on the cliam list page

@GUI
Scenario: 31964-Verify the column names on the claim list page for Customer and Station Users
    Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
	When I arrive on the claim list page
	Then verify the column names on the claim list page

@GUI
Scenario: 31964-Verify the Export dropdown arrow options on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   And I arrive on the claim list page
   When I click on the Export dropdown arrow
   Then I should see the dropdown options to select All or Displayed

@GUI @Functional
Scenario: 31964-Verify column names and validate data for the Export dropdown select All option functionality for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   And I arrive on the claim list page
   When I click on the Export dropdown and select All option
   Then Report should be generated of all records on the claim list page 
   And all the column names and data from the claim list page should be displayed in the exported report

@GUI @Functional
Scenario: 31964-Verify column names and validate data for the Export dropdown select Displayed option functionality for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   And I arrive on the claim list page
   When I click on the Export dropdown and select Displayed option
   Then Report should be generated of displayed records on the claim list page 
   And all the column names and data from the claim list page should be displayed in the exported report

@GUI @Acceptance
Scenario: 31964-Verify the search field functionality on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   And I arrive on the claim list page
   When I click in the search field
   Then I have the option to type in any value 'ZZZ - Czar Customer Test'
   And any rows that contain the values 'ZZZ - Czar Customer Test' that were entered will be highlighted

  

@GUI @Acceptance
Scenario: 31964-Verify the navigation to the submit claim form page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   And I arrive on the claim list page
   When I click on the Submit a Claim button
   Then I will arrive on the Submit a Claim form page

@GUI
Scenario Outline: 31964-Verify the information Icon is displayed only for Open, Denied, Cancelled and Paid status in Status column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   And I arrive on the claim list page
   When I select the show status <options> in the claims list page
   Then I should see an Information Icon I displayed next to only Open, Denied, Cancelled and Paid <options> status
Examples: 
| options   |
| Open      |
| Denied    |
| Cancelled |
| Paid      |


@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Customer column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the Customer column on the Claims List page
   Then Customer column will be sorted alphabetically 
   And clicking on Customer column arrow again will reverse the sort


@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Insured column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the Insured column on the Claims List page
   Then Insured column will be sorted alphabetically
   And clicking on Insured column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the DLSW Claim # column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the DLSW Claim # column on the Claims List page
   Then DLSW Claim # column will be sorted numerically lowest to highest 
   And clicking on DLSW Claim # column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the DLSW Ref # column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the DLSW Ref # column on the Claims List page
   Then DLSW Ref # column will be sorted alphabetically
   And clicking on DLSW Ref # arrow again will reverse the sort


@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Amount column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the Amount column on the Claims List page
   Then Amount column will be sorted numerically lowest to highest and clicking on Amount column arrow again will reverse the sort
   And clicking on Amount column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Carrier column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the Carrier column on the Claims List page
   Then Carrier column will be sorted alphabetically based on Carrier Name 
   And clicking on Carrier column arrow again will reverse the sort


@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Status column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the Status column on the Claims List page
   Then Status column will be sorted alphabetically
   And clicking on Status column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Submit Date column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the Submit Date column on the Claims List page
   Then Submit Date column will be sorted numerically from oldest to newest 
   And clicking on Submit Date column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Claim Age column on the claim list page for Customer and Station Users
   Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales Management, Operations, Station Owner users
   When I click on the sort arrow of the Claim Age column on the Claims List page
   Then Claim Age column will be sorted numerically from lowest to highest 
   And clicking on Claim Age column arrow again will reverse the sort


@GUI
Scenario: 31964-Verify the column names on the claim list page for claim specialist user
    Given I am a claim specialist user
	When I arrive on the claim list page
	Then verify the column names on the claim list page for claim specialist user



@GUI @Functional
Scenario: 31964-Verify column names and validate data for the Export dropdown select All option functionality for claim specialist user
   Given I am a claim specialist user
   And I arrive on the claim list page
   When I click on the Export dropdown and select All option
   Then Report should be generated of all records on the claim list page for Claim Specialist user
   And all the column names and data from the claim list page should be displayed in the exported report for cliam specialist user

@GUI @Functional
Scenario: 31964-Verify column names and validate data for the Export dropdown select Displayed option functionality for claim specialist user
   Given I am a claim specialist user
   And I arrive on the claim list page
   When I click on the Export dropdown and select Displayed option
   Then Report should be generated of displayed records on the claim list page for Claim Specialist user
   And all the column names and data from the claim list page should be displayed in the exported report for cliam specialist user


@GUI
Scenario: 31964-Verify the associated code for the Open, Denied and Cancelled status on the claim list page for Claim Specialist user
   Given I am a claim specialist user
   When I click on the claim navigation icon
   Then I will see the status and associated code for Open, Denied and Cancelled status on the claim list page



@GUI
Scenario: 31964-Verify the information Icon is displayed only for Paid status in Status column on the claim list page for Claim Specialist user
   Given I am a claim specialist user
   When I arrive on the claim list page
   Then I should see an Information Icon I displayed next to only Paid Status



@GUI @Functional
Scenario: 31964-Verify the sort functionality of the STA/CUS column on the claim list page for claim specialist user
   Given I am a claim specialist user
   When I click on the sort arrow of the STA/CUS column on the claim list page
   Then STA/CUS column will be sorted alphabetically based on Customer Name 
   And clicking on STA/CUS column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Dates column on the claim list page for claim specialist user
   Given I am a claim specialist user
   When I click on the sort arrow of the Dates column on the claim list page
   Then Dates column will be sorted by most recent date based on Submit date  
   And clicking on Dates column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Claim # column on the claim list page for claim specialist user
   Given I am a claim specialist user
   When I click on the sort arrow of the Claim # column on the claim list page
   Then Claim # column will be sorted by lowest to highest based on DLSW Claim # 
   And clicking on Claim # column arrow again will reverse the sort 

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Carrier column on the claim list page for claim specialist user
   Given I am a claim specialist user
   When I click on the sort arrow of the Carrier column on the claim list page
   Then Carrier column should be sorted alphabetically based on Carrier Name 
   And clicking on Carrier column arrow again should reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Insured column on the claim list page for claim specialist user
   Given I am a claim specialist user
   When I click on the sort arrow of the Insured column on the claim list page
   Then Insured column should be sorted alphabetically 
   And clicking on Insured column arrow again should reverse the sort


@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Amount column on the claim list page for claim specialist user
   Given I am a claim specialist user
   When I click on the sort arrow of the Amount column on the claim list page
   Then Amount column will be sorted lowest to highest 
   And clicking on Amount column arrow again should reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the DLSW Ref # column on the claim list page for claim specialist users
   Given I am a claim specialist user
   When I click on the sort arrow of the DLSW Ref # column on the claim list page
   Then DLSW Ref # column should be sorted alphabetically 
   And clicking on DLSW Ref # column arrow again will reverse the sort


@GUI @Functional
Scenario: 31964-Verify the sort functionality of the DLSW Claim Specialist column on the claim list page for claim specialist users
   Given I am a claim specialist user
   When I click on the sort arrow of the DLSW Claim Specialist column on the claim list page
   Then DLSW Claim Specialist column will be sorted alphabetically 
   And clicking on DLSW Claim Specialist column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Submitted By column on the claim list page for claim specialist users
   Given I am a claim specialist user
   When I click on the sort arrow of the Submitted By column on the claim list page
   Then Submitted By column will be sorted alphabetically 
   And clicking on Submitted By column arrow again will reverse the sort

@GUI @Functional
Scenario: 31964-Verify the sort functionality of the Status column on the claim list page for claim specialist users
   Given I am a claim specialist user
   When I click on the sort arrow of the Status column on the claim list page
   Then Status column should be sorted alphabetically 
   And clicking on Status column arrow again should reverse the sort



@GUI 
Scenario: 31964-Verify the horizontal scroll view functionality when the grid is larger than the screen size for claim specialist user
  Given I am a claim specialist user
  When the grid is larger than the screen size on the claim list page
  Then I will have the horizontal scroll to view the  remaining columns


@91189
Scenario: 91189_Verify the Saved Date Ack To Claimant displayed in Claims List under Dates column
	Given I am a claim specialist user
	And I am on the Claims List page
	When the Date Ack To Claimant information from the Details tab of the Claim Details page has been saved to the claim
	Then I will see the date that was saved in the Ack field of the Dates column
	And the date in the Ack field will displayed as a link
