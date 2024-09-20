@26721 @Sprint68 
Feature: Shipment List (MVC5)- Page Elements-Station Users

  @GUI
  Scenario Outline:Test to verify the new fields_shipment list page
  Given I am a DLS user and login into application with valid <Username> and <Password>
  And I click on the Shipment icon
  When I navigate to shipmentlist page
  Then I should be displayed with new Customer drop down list field
  And I should be displayed with All Customers selection binding in Customer drop down by default

 Examples: 
| Scenario | Username              | Password | 
| 1        | stationowner@test.com | Te$t1234 | 
| 2        | crmOperation@user.com | Te$t1234 | 
| 3        | saleTest              | Te$t1234 | 
| 4        | crmsalesusr           |Te$t1234  |  


 @GUI
  Scenario Outline:Test to verify the new additional search fields_shipment list page
  Given I am a DLS user and login into application with valid <Username> and <Password>
  And I click on the Shipment icon
  When I navigate to shipmentlist page
  And I click on search option 
  Then I should be displayed with new StationName '<StationName>' option
  And I should be displayed with new CustomerName '<CustomerName>' option
  And I should be displayed with new EstRevenue '<EstRevenue>' option
  And I should be displayed with new EstCost '<EstCost>' option
  And I should be displayed with new EstMargin '<EstMargin>' option
 Examples: 
| Scenario | Username                | Password  | StationName  | CustomerName  | EstRevenue | EstCost | EstMargin |
| 1        | stationowner@test.com   |Te$t1234   | Station Name | Customer Name | Est Revenue | Est Cost | Est Margin % |
| 2        | crmOperation@user.com   |Te$t1234   | Station Name | Customer Name | Est Revenue | Est Cost | Est Margin % |
| 3        | saleTest                |Te$t1234   | Station Name | Customer Name | Est Revenue | Est Cost | Est Margin % |
| 4        | crmsalesusr             |Te$t1234   | Station Name | Customer Name | Est Revenue | Est Cost | Est Margin % |

@GUI @Regression
Scenario Outline: Verify the existence of page elements in Shipment List page for internal Users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to view an option to Search filtered reports 
	And I must be able to view Show report filters
	And I must be able to view Hide report filters
	And I must be able to view Reference Number Lookup
	And I must have an option to search grid column data
	And I must be able to view clear all button
	And I must be able to view expected Search grid column dropdown values
	And I must be able to view Scheduled to Deliver and Scheduled to Pickup options
	And I must be able to view Start Date Calender Selector
	And I must be able to view End Date Calender Selector

Examples: 
| Scenario | Username                     | Password |
| S1       | zzzext@user.com              | Te$t1234 |
| S2       | Userinquiry@gmail.com        | Te$t1234 |
| S3       | UserEntryNorates@gmail.com   | Te$t1234 |
| S4       | Userinquirynorates@gmail.com | Te$t1234 |

@GUI @Regression
Scenario Outline:Verify the existence grid elements in Shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to view expected grid header values
	And I must be able to view Export button in Shipment list page
	And I must be able to view Export All and Export Displayed as export dropdown options
	And I must be able to view Shipment details button
	And I must be able to view More Information button
 Examples: 
| Scenario | Username              | Password| 
| 1        | stationowner@test.com |Te$t1234 | 
| 2        | crmOperation@user.com |Te$t1234 | 
| 3        | saleTest              |Te$t1234 | 
| 4        | crmsalesusr           |Te$t1234 |  

@GUI @Regression
Scenario Outline: verify the existence of Add shipment button for shp.entry, or shp.entrynorates users
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to view Add Shipment button

 Examples: 
| Scenario | Username              | Password| 
| 1        | stationowner@test.com |Te$t1234 | 
| 2        | crmOperation@user.com |Te$t1234 | 
| 3        | saleTest              |Te$t1234 | 
| 4        | crmsalesusr           |Te$t1234 |  

@GUI @Regression
Scenario Outline: Verify the existence of Copy and return icon in the shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to Shipment Button
	When I arrive on Shipment list page
	Then I must be able to view Copy icon displayed to the right of the destination column on the shipment row for LTL Shipments
	And I must be able to view Return icon displayed to the right of the destination column on the shipment row for LTL Shipments

 Examples: 
| Scenario | Username              | Password| 
| 1        | stationowner@test.com |Te$t1234 | 
| 2        | crmOperation@user.com |Te$t1234 | 
| 3        | saleTest              |Te$t1234 | 
| 4        | crmsalesusr           |Te$t1234 |  


  @GUI
  Scenario Outline:Test to verify the new column _Station/Customer Name_shipment list grid
  Given I am a DLS user and login into application with valid <Username> and <Password>
  And I click on the Shipment icon
  When I navigate to shipmentlist page
  Then I should be displayed with '<StationCustomerName>' column in shipment list grid
 Examples: 
|Scenario|Username              |Password|StationCustomerName|
|1       |stationowner@test.com |Te$t1234|Station / Cust Name|
|2       |crmOperation@user.com |Te$t1234|Station / Cust Name|
|3       |saleTest              |Te$t1234|Station / Cust Name|
|4       |crmsalesusr           |Te$t1234|Station / Cust Name|
 
  @GUI
  Scenario Outline:Test to verify the new column _Rates_shipment list grid
  Given I am a DLS user and login into application with valid <Username> and <Password>
  And I click on the Shipment icon
  When I navigate to shipmentlist page
  Then I should be displayed with new '<Rates>' column in shipment list grid
  
 Examples: 
|Scenario|Username             |Password|Rates|
|1       |stationowner@test.com|Te$t1234|Rates|
|2       |crmOperation@user.com|Te$t1234|Rates|
|3       |saleTest             |Te$t1234|Rates|
|4       |crmsalesusr          |Te$t1234|Rates|


  @Functional
   Scenario Outline:Test to verify the sorted order of the column_Station/Customer Name_shipment list grid
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Shipment icon
   When I navigate to shipmentlist page
   And I click On Station/Customer Name column sort option
   Then Station/Customer Name column should be sorted by Customer Name


 Examples: 
| Scenario | Username              | Password | 
| 1        | stationowner@test.com | Te$t1234 | 
| 2        | crmOperation@user.com | Te$t1234 | 
| 3        | saleTest              | Te$t1234 | 
| 4        | crmsalesusr           |Te$t1234  |  



  @Functional
  Scenario Outline:Test to verify the sorted order of the column_Est Revenue_shipment list grid
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Shipment icon
   When I navigate to shipmentlist page
   And I click On Rates column sort option
   Then Rates column should be sorted by Est Revenue


 Examples: 
| Scenario | Username              | Password | 
| 1        | stationowner@test.com | Te$t1234 | 
| 2        | crmOperation@user.com | Te$t1234 | 
| 3        | saleTest              | Te$t1234 | 
| 4        | crmsalesusr           |Te$t1234  |  



