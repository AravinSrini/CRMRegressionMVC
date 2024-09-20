@Custom_report_edit_allusers @Sprint68 @27811
Feature: Shipment List_ Custom Reports Edit - All Users
 
@GUI
Scenario Outline:Test to Verify default customer selection will be All Customers_stationusers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipmentlist page
And I have selected the '<customreport>' which i created
And I Clicked on Show Filter link
Then I should be displayed with '<Reporteditwillbeforallcustomers>'
And I should not be displayed with customer selection option
 
Examples:
| Scenario | Username              | Password |customreport         | Reporteditwillbeforallcustomers       |
| 1        | stationowner@test.com | Te$t1234 |automationPcustomR   | Report edit will be for all customers |
| 2        | crmOperation@user.com | Te$t1234 |new report           | Report edit will be for all customers |
| 3        | saleTest              | Te$t1234 |automationPcustomR3  | Report edit will be for all customers |
| 4        | crmsalesusr           | Te$t1234 |automationPcustomR4  | Report edit will be for all customers | 

 
@GUI @Functional 
Scenario Outline:Test to Verify duplicate customreport name check when user gives the share access_stationusers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipmentlist page
And I have selected the '<customreport>' which i created and the same report name already existed with in the station
And I Clicked on Show Filter link
And I selected the shared access
And I click on Update Report Parameters button
Then I should be displayed with error message '<Sharedreportnamealreadyexists>'
 
Examples:

| Scenario | Username              | Password | customreport |Sharedreportnamealreadyexists      |
| 1        | stationowner@test.com | Te$t1234 |sharingtest2  | Shared report name already exists |
| 2        | crmsalesusr           | Te$t1234 |swathii       | Shared report name already exists |
 
 
@Functional 
Scenario Outline:Test to Verify update customreport functionality_stationusers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipmentlist page
And I have selected the '<customreport>' which i created and the same report name already existed with in the station
And I Clicked on Show Filter link
And I updated fields '<RefNumber>','<ServiceType>','<StartDate>','<Enddate>','<OrgCity>','<DestCity>','<Status>'
And I click on Update Report Parameters button
Then Custom report should be saved
And custom report edit section should be hidden
And '<Reporteditwillbeforallcustomers>' text should not be visible
And I should be displayed with customer selection option
 
Examples:
| Scenario | Username              | Password | Reporteditwillbeforallcustomers | customreport                |ServiceType |Status     | OrgCity   | DestCity | StartDate | Enddate | RefNumber |
| 1        | stationowner@test.com | Te$t1234 |                                 |automationPcustomR           |TL          |Pending    |los angeles|toronto   |           |         |           |
| 2        | crmOperation@user.com | Te$t1234 |                                 |new report                   |TL          |Delivered  |AL         |A         |           |         |           |
| 3        | saleTest              | Te$t1234 |                                 |automationPcustomR3          |LTL         |Delivered  |CA         |AL        |           |         |           |
| 4        | crmsalesusr           | Te$t1234 |                                 |automationPcustomR4          |LTL         |Delivered  |CA         |AL        |           |         |           |
 
 

 @GUI @API 
Scenario Outline:Test to Verify shipment list grid on update the customreport_stationusers_MG API 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipmentlist page
And I have selected the '<customreport>' which i created
And I Clicked on Show Filter link
And I updated field '<OrgCity>'
And I click on Update Report Parameters button
And  I have selected Customer from the dropdown <Customer_Name>
Then the Shipment list displayed for the selected Custom Report and Customer Accountuser<Useremail>service<ServiceType>reference<RefNumber>startdate<StardDate>enddate<Enddate>orgincity<OrgCity>destcity<DestCity>status<Status>acc<CustomerAccount>accnumber<MgCustomerAccountNumber>report<APIReport>



Examples: 
| Scenario | Username              | Password | ServiceType  | RefNumber | StardDate | Enddate    | OrgCity | DestCity | Status    | Customer_Name             | MgCustomerAccountNumber | APIReport                    | customreport     |
| 1        | stationowner@test.com | Te$t1234 | LTL          |ZZX00206515|09/26/2017 | 10/06/2017 | CHICAGO | TOLEDO   |In Transit | ZZZ - Czar Customer Test  |ZZZWST                   |CRM-AgentReportNoDestCityRef  |myapitestreport   |
 
@GUI @Functional 
Scenario Outline:Test to Verify update customreport functionlity_externalusers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipmentlist page
And I have selected the '<customreport>' which i created
And I Clicked on Show Filter link
And I updated fields '<RefNumber>','<ServiceType>','<StartDate>','<Enddate>','<OrgCity>','<DestCity>','<Status>'
And I click on Update Report Parameters button
Then Custom report should be saved
And custom report edit section should be hidden
 
Examples:
| Scenario | Username       | Password | customreport | ServiceType | Status | OrgCity | DestCity | StartDate | Enddate | APIReport | RefNumber | CustomerAccount |
| 1        | shpentry       | Te$t1234 |testext1      |LTL          |Pending |a        |          |           |         |           |           |                 |
| 2        | ShpInquiry     | Te$t1234 |testext2      |LTL          |Pending |         |          |           |         |           |           |                 |
| 3        | Entyrnorates   | Te$t1234 |testext3      |LTL          |Pending |         |          |           |         |           |11         |                 |
| 4        | Inquirynorates | Te$t1234 |testext4      |LTL          |Pending |         |          |           |         |           |           |                 |
 
 @GUI @API  
Scenario Outline:Test to Verify shipment list grid on update the customreport_MG_API_externalusers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipmentlist page
And I have selected the '<customreport>' which i created
And I Clicked on Show Filter link
And I updated field '<OrgCity>'
And I click on Update Report Parameters button
Then the Shipment list displayed for the selected Custom Report and Customer Accountuser<Useremail>service<ServiceType>reference<RefNumber>startdate<StardDate>enddate<Enddate>orgincity<OrgCity>destcity<DestCity>status<Status>acc<CustomerAccount>accnumber<MgCustomerAccountNumber>report<APIReport>

Examples: 
| Scenario | Username        | Password | ServiceType  | RefNumber | StardDate | Enddate    | OrgCity | DestCity | Status    | CustomerAccount           | MgCustomerAccountNumber | APIReport                    |customreport        |
| 1        | zzzext@user.com | Te$t1234 | LTL          |ZZX00206515|09/26/2017 | 10/06/2017 | CHICAGO | TOLEDO   |In Transit | ZZZ - Czar Customer Test  |ZZZCZAR                  |CRM-CustomReportNoDestCityRef |myapitestexternal    |


