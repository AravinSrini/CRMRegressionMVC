@Quote Standard Reports - Station users @Sprint68 @27811 

Feature: Standard Reports-Station Users
	
@GUI
Scenario Outline:Verify default customer selection will be All Customers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
Then the default customer selection will be All Customers

Examples: 
| Scenario | Username   | Password | 
| S1       | stationown | Te$t1234 |

@Functional  @API
Scenario Outline:Verify the shipment list display within shipment list grid default to the shipments for the previous thirty days
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
Then the default customer selection will be All Customers
Then the shipment list display will default to the shipments for the previous thirty days<StationData>,<Standard_ReportNameMG>,<Customername>
Examples:            
| Scenario | Username   | Password | Standard_ReportNameMG  | StationData | Customername |
| S1       | stationown | Te$t1234 | CRM-ShpPrev30DaysAgent | ZZZ,ZZX     | Admin        |
| S2       | Opstage    | Te$t1234 | CRM-ShpPrev30DaysAgent |ATW          | Admin        |

@Functional  @API
Scenario Outline:Verify shipment list when selected MG customer from the drop down list then selected standard report type of MG and CSA (Both)
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected MG Customer from the drop down <Customer_Name>
Then I have selected standard report type of MG and CSA (BOth) <Standard_ReportNameDropDown>
And the shipment list will update to only display the standard report from MG for the selected customer<StationData>,<Standard_ReportNameMG>,<Customer_Name>
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | ZZZ - Czar Customer Test | CRM-Shipments from Current Month Agent | Shipments from Current Month |


@Functional  @API
Scenario Outline:Verify shipment list when selected MG customer from the drop down list then selected standard report type of MG only
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected MG Customer from the drop down <Customer_Name>
Then I have selected standard report type of MG only <Standard_ReportNameDropDown>
Then the shipment list will update to only display the standard report from MG for the selected customer<StationData>,<Standard_ReportNameMG>,<Customer_Name>
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | ZZZ - Czar Customer Test | CRM-Shipments from Current Month Agent | Shipments from Current Month |


#No valid CSA customer available 

#@Functional  @API
#Scenario Outline:Verify shipment list when selected CSA customer from the drop down list then selected standard report type of MG and CSA(BOTH)
#Given I am a DLS user and login into application with valid <Username> and <Password>
#And I click on the Shipment Icon	
#And I arrive on the Shipment List page
#When  I have selected CSA Customer from the drop down <Customer_Name>
#Then I have selected standard report type of MG and CSA (BOth) <Standard_ReportName>
#Then the shipment list will update to only display the standard report from CSA for the selected customer<Customer_Name>,<Standard_ReportName>
#Examples: 
#| Scenario | Username  | Password | QuoteList_Header          | Customer_Name          |
#| s1       | zzz       | Te$t1234 | ZZZ Sandbox DLS Worldwide | CRM-ShpPrev30DaysAgent |

@Functional 
Scenario Outline:Verify shipment list when selected CSA customer from the drop down list then selected standard report type of MG only
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected CSA Customer from the drop down <Customer_Name>
Then I have selected standard report type of MG only <Standard_ReportNameDropDown>
And I will not get any report
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | EnterprisetypeTest3      | CRM-Shipments from Current Month Agent | Shipments from Current Month |


@Functional  @API
Scenario Outline:Verify shipment list when selected CSA customer from the drop down list then selected standard report type of BOTH
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected MG Customer from the drop down <Customer_Name>
Then I have selected standard report type of MG and CSA (Both) <Standard_ReportNameDropDown>
And the shipment list will update to only display the standard report from MG for the selected customer<StationData>,<Standard_ReportNameMG>,<Customer_Name>
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | ZZZ - Czar Customer Test | CRM-Shipments from Current Month Agent | Shipments from Current Month |


@Functional  @API
Scenario Outline:Verify shipment list when selected MG and CSA (Both) customer from the drop down list then selected standard report type of MG only
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected MG and CSA (Both) Customer from the drop down <Customer_Name>
Then I have selected standard report type of MG only <Standard_ReportNameDropDown>
And the shipment list will update to only display the standard report from MG for the selected customer<StationData>,<Standard_ReportNameMG>,<Customer_Name>
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | Gainshare15thTestEnv1    | CRM-Shipments from Current Month Agent | Shipments from Current Month |


@Functional  @API
Scenario Outline:Verify shipment list when selected MG and CSA (Both) customer from the drop down list then selected standard report type of BOTH
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected MG and CSA (Both) Customer from the drop down <Customer_Name>
Then I have selected standard report type of MG and CSA (Both) <Standard_ReportNameDropDown>
And the shipment list will update to only display the standard report from MG and CSA(Both) for the selected customer <Customer_Name>,<Standard_ReportNameMG>
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | ZZZ - GS Customer Test   | CRM-Shipments from Current Month Agent | Shipments from Current Month |

@Functional  @API
Scenario Outline:Verify shipment list when standard reports type of MG then selected MG customer from the drop down
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected Standard report <Standard_ReportNameDropDown>
Then  I have a MG customer <Customer_Name>
And the shipment list will update to only display the standard report from MG for the selected customer<StationData>,<Standard_ReportNameMG>,<Customer_Name>
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | ZZZ - Czar Customer Test | CRM-Shipments from Current Month Agent | Shipments from Current Month |


@Functional  @API
Scenario Outline:Verify shipment list when standard reports type of CSA and MG (Both) then selected MG and CSA (Both) customer from the drop down
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected Standard report <Standard_ReportNameDropDown>
Then  I have selected MG and CSA (Both) customer <Customer_Name>
And the shipment list will update to only display the standard report from MG and CSA(Both) for the selected customer <Customer_Name>,<Standard_ReportNameMG>
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | ZZZ - GS Customer Test   | CRM-Shipments from Current Month Agent | Shipments from Current Month |


#No valid CSA customer available 
#@Functional  @API
#Scenario Outline:Verify shipment list when standard reports then selected CSA customer from the drop down
#Given I am a DLS user and login into application with valid <Username> and <Password>
#And I click on the Shipment Icon	
#And  I arrive on the Shipment List page
#When I have selected Standard report <Standard_ReportName>
#Then  I have a CSA customer <Customer_Name>
#And the shipment list will update to only display the standard report from CSA for the selected customer
#Examples: 
#| Scenario | Username  | Password | ShipmentList_Header | Customer_Name |






@Functional  @API
Scenario Outline:Verify shipment list when selected default option from the report drop down list
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected any customer from drop down <Customer_Name>
When  I have selected Standard report <Standard_ReportNameDropDown>
Then I select SELECT A REPORT option from the report drop down list
And the shipment list will update to only display the standard report from MG and CSA(Both) for the selected customer <Customer_Name>,<Standard_ReportNameMG>
Examples:            
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | ZZZ - GS Customer Test   | CRM-Shipments from Current Month Agent | Shipments from Current Month |




@Functional  @API
Scenario Outline:Verify shipment list when selected ALL Customer option from the drop down list
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected any customer from drop down <Customer_Name>
When  I have selected Standard report <Standard_ReportNameDropDown>
Then I select ALL CUSTOMER from the report drop down list
And the shipment list display will default to the shipments for the previous thirty days<StationData>,<Standard_ReportNameMG>,<Customername>
Examples:            
| Scenario | Username   | Password | Standard_ReportNameMG                   | StationData | Customername |
| S1       | stationown | Te$t1234 | CRM-Shipments from Current Month Agent  | ZZZ,ZZX     | Admin        |

@Functional 
Scenario Outline:Verify message within shipment list grid when selection criteria does not return any records
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I arrive on shipment list page
When  I have selected any customer from drop down <Customer_Name>
And I have selected any standard report  <Standard_ReportNameDropDown>
And my selection criteria does not return any records
Then the shipment list will update to display message no results found in the shipment list grid 
Examples: 
| Scenario | Username        | Password | Customer_Name            | Standard_ReportNameMG                  | Standard_ReportNameDropDown  |
| s1       | stationown      | Te$t1234 | EnterprisetypeTest3      | CRM-Shipments from Current Month Agent | Shipments from Current Month |

