@Dashboard-AddbuttonsinDashboard_Export @21567 @Sprint63
Feature: Dashboard-AddbuttonsinDashboard_Export


@UI @Functional @Acceptance
Scenario Outline: Verify the export button and its functionality
Given I am a DLS user and login into application with valid <Username> and <Password>
When  I arrive on the Dashboard page
Then  I will be able to see Export button in dashboard screen
And   I click on the Export button 
And  Verify the downloaded excel file name and data with all of the Pending CSR Report<File_Name>

Examples: 
| Scenario | Username | Password | File_Name              |
| S1       | OP       | Te$t1234 | Pending CSR Report.xls |
