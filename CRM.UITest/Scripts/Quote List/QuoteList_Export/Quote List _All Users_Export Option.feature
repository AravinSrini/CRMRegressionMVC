@QuoteListExport @26215 @Sprint67 
Feature: Quote List _All Users_Export Option


@GUI
Scenario Outline: Verify the Options when I click on the Export drop down button on the Quote List page for the Station Users , ShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on the Quote Icon	
	When Click on the Export drop down button
	Then I can see the Options All and Displayed in the Export drop down list
	

Examples: 
| Scenario | Username              | Password |
#| S1       | crmOperation@user.com | Te$t1234 |
| S2       | zzzext@user.com       | Te$t1234 |


@GUI @Functional 
Scenario Outline: Verify all column headers present in QuoteListExport Excel sheet
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on the Quote Icon
	When Click on the Export drop down button
	And I select the <ExportOption> for the Export drop down 	
	Then excel sheet column headers should match with UI Columns in the Quote List grid <UserType>
Examples: 
| Scenario | Username              | Password | ExportOption | UserType  |
| S1       | zzzext@user.com       | Te$t1234 | All          | ShipEntry |
#| S2       | crmOperation@user.com | Te$t1234 | Displayed    | Operation |


@GUI @Functional 
Scenario Outline: Verify the All Option selected Export functionality on the Quote List page for the Station Users , ShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on the Quote Icon
	When Click on the Export drop down button
	And I select the <ExportOption> for the Export drop down 	
	Then excel sheet count should match with the All UI count of the Quote list grid for the <UserType>
	
	

Examples: 
| Scenario | Username              | Password   | ExportOption | UserType  |
| S1       |zzzext@user.com        | Te$t1234   | All          | ShipEntry |
#| S2       | crmOperation@user.com | Te$t1234   | All          | Operation |


@GUI @Functional 
Scenario Outline: Verify the Displayed Option selected Export functionality on the Quote List page for the Station Users , ShipEntry and ShipInquiry Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on the Quote Icon	
	When Click on the Export drop down button
	And I select the <ExportOption> for the Export drop down 
	Then excel count should match with the displayed UI count of the Quote list grid for the <UserType>
	
	

Examples: 
| Scenario | Username              | Password   | ExportOption | UserType  |
| S1       | zzzext@user.com       | Te$t1234   | Displayed    | ShipEntry |
#| S2       | crmOperation@user.com | Te$t1234   | Displayed    | Operation |





