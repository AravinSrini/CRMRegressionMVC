@Sprint75 @34281
Feature: IntegrationListPage_ExportButton

@mytag
@UI @Functional @Acceptance
Scenario Outline: IntegrationExport1->Verify the export button and its functionality for Admin User 
Given I am a DLS user and login into application with valid <Username> and <Password>
When  I arrive on the Dashboard page
And I click on Integration Menu
Then  I will be able to see Export button in Integration List Page
And   I click on the Export button available
And  Verify the downloaded excel file name<FileName> 
And Verify the data available matching in the Excel<FileName>matching with the UI for Admin User for InProgress status<Status>


Examples: 
| Scenario | Username | Password    | FileName | Status                    |
| S1       | Systemadmin | Te$t1234 | IntegrationListExport.xls | In Progress |

Scenario Outline: IntegrationExport2->Verify the export button and its functionality for Station Users 
Given I am a DLS user and login into application with valid <Username> and <Password>
When  I arrive on the Dashboard page
And I click on Integration Menu
Then I will be able to see Export button in Integration List Page
And I click on the Export button avaialble
And Verify the downloaded excel file name<FileName> 
And Verify the data available matching in the Excel<FileName>matching with the UI for the Station User for InProgress status<Status>

Examples: 
| Scenario | Username | Password               | FileName | Status                    |
| S1       | SalesManager@stage.com | Te$t1234 | IntegrationListExport.xls | In Progress |