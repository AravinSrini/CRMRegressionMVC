@32063 @Sprint73 @Ignore
Feature: CRM Invoicing - Payment Icon (Customer Users)

@GUI
Scenario Outline: 32063_Verify the Payments icon on the left navigational pane
Given I am a shp.entry or shp.inquiry user with access to Payment <userName> and <password>
When I am on dashboard page
Then I should be displayed with Payments icon on the left navigational pane

Examples: 
| scenario | userName | password | 
| s1       | both     | Te$t1234 | 

@GUI
Scenario Outline: 32063_Verify the launch and autologin of the PNC website in a new browser 
Given I am a shp.entry or shp.inquiry user with access to Payment <userName> and <password>
When I click on Payments icon on the left navigational pane
Then I will be auto login & launch the PNC website in a new browser tab
Examples: 
| scenario | userName              | password | 
| s1       | robert.j.brus@rrd.com | Te$t1234 | 

@GUI
Scenario Outline: 32063_Verify the launch and autologin of the PNC website in a new browser_PNC url is not present
Given I am a shp.entry or shp.inquiry user with access to Payment <userName> and <password>
When I click on Payments icon on the left navigational pane&PNC url is not present
Then <error> will be displayed
Examples: 
| scenario | userName | password | error                                      |
| s1       | both     | Te$t1234 | Error Occurred while launching Payment Site |
