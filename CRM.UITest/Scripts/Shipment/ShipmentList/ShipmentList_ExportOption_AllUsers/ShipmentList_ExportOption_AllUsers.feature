@ShipmentListExportOption @26800 @Sprint68 
Feature: ShipmentList_ExportOption_AllUsers

     
@GUI
Scenario Outline: Verify the Options when I click on the Export drop down button on the Shipment List page for all users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the Export dropdown button
	Then I will see the Options All and Displayed in the Export drop down list

   Examples: 
           | Scenario | Username              | Password |
           | S1       | zzzext                | Te$t1234 |
           | S2       | Stationown            | Te$t1234 |
           | S3       | crmOperation@user.com | Te$t1234 |

@Functional @Regression 
Scenario Outline: Verify all column headers present in Shipments Excel sheet for external user
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the Export dropdown button
	And I select the <ExportOption> for the Export drop down in Shipment list page
	Then Excel sheet column headers should match with UI Columns in the Shipment List grid <UserType>
   
   Examples: 
  | Username | Password | ExportOption | UserType  |
   | zzzext|  | All          | ShipEntry |
          

@Functional @Regression 
Scenario Outline: Verify all column headers present in Shipments Excel sheet for stationowner user
Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the Export dropdown button
	And I select the <ExportOption> for the Export drop down in Shipment list page
	Then Excel sheet column headers should match with UI Columns in the Shipment List grid <UserType>
   
   Examples: 
          | Username              | Password | ExportOption | UserType  |
          
           | Stationown            | Te$t1234 | All          | Operation |
		   
		   @Functional @Regression 
Scenario Outline: Verify all column headers present in Shipments Excel sheet forCRMOperations user
	Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the Export dropdown button
	And I select the <ExportOption> for the Export drop down in Shipment list page
	Then Excel sheet column headers should match with UI Columns in the Shipment List grid <UserType>
   
   Examples: 
          | Username              | Password | ExportOption | UserType  |
         | crmOperation@user.com | Te$t1234 | Displayed    | Operation |
          

@Functional @Acceptance 
Scenario Outline: Verify the All Option selected Export functionality on the Shipment List page for all users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the Export dropdown button
	And I select the <ExportOption> for the Export drop down in Shipment list page
	Then Excel sheet count should match with the All UI count of the Shipment list grid for the <UserType>

    Examples: 
           | Scenario | Username              | Password | ExportOption | UserType  |
           | S1       | zzzext@user.com       | Te$t1234 | All          | ShipEntry |
           | S2       | crmOperation@user.com | Te$t1234 | All          | Operation |
		   | S3       | Stationown            | Te$t1234 | All          | Operation |

@Functional @Acceptance
Scenario Outline: Verify the Displayed Option selected Export functionality on the Shipment List page for all users
    Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on the Export dropdown button
	And I select the <ExportOption> for the Export drop down in Shipment list page
	Then Excel count should match with the displayed UI count of the Shipment list grid for the <UserType>

   Examples: 
           | Scenario | Username              | Password | ExportOption | UserType  |
           | S1       | crmOperation@user.com | Te$t1234 | Displayed    | Operation |
           | S2       | zzzext@user.com       | Te$t1234 | Displayed    | ShipEntry |
           | S3       | Stationown            | Te$t1234 | Displayed    | Operation |





	









