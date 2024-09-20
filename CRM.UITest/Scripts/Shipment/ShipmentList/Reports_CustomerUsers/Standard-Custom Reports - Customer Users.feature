@Standard-Custom Reports - Customer users @Sprint68 @28431


Feature: Standard-Custom Reports - Customer Users
	
@Functional 
Scenario Outline:Verify shipment list when selected standard reports from the drop down for Customer users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I have selected any standard report from report drop down <Stnadard_ReportNamedropDown>
Then the shipment list will update the previous 30 days shipments from MG and CSA <Customer_Name>,<Stnadard_ReportNamedropDown>,<Stnadard_ReportNameMG>
Examples: 
| Scenario  | Username        | Password |  Customer_Name            | Stnadard_ReportNamedropDown   | Stnadard_ReportNameMG                |
| s1        | Both@test.com   | Te$t1234 |   ZZZ - GS Customer Test  | Shipments from Current Month | CRM-Shipments from Current Month     |
#| s1         | awg             | Te$t1234 |   AWG - Evansville IN     | Shipments from Current Month | CRM-Shipments from Current Month     |




@Functional @API
Scenario Outline:Verify shipment list when selected custom reports from the drop down and logged in users TMS type is MG
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I have selected any custom report from report drop down <Stnadard_ReportNamedropDown>
Then the shipment list will update the previous thirty days shipments from MG<Customer_Name>,<Stnadard_ReportNamedropDown>,<Stnadard_ReportNameMG>
Examples: 
| Scenario | Username        | Password | ShipmentList_Header | Customer_Name            | Stnadard_ReportNamedropDown  | Stnadard_ReportNameMG                |
| s1       | zzzext@user.com | Te$t1234 |                     | ZZZ - Czar Customer Test | Shipments from Current Month | CRM-Shipments from Current Month     |

@GUI
Scenario Outline:Verify Delete and Update button absence when standard report selected from the drop down
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I have selected any custom report from report drop down <Standard_ReportName>
When I Click on Show Filter link
Then the Delete and Update button should be in disable mode
Examples: 
| Scenario | Username        | Password | ShipmentList_Header | Customer_Name            | Standard_ReportName          |
| s1       | zzzext@user.com | Te$t1234 |    Shipment List    | ZZZ - Czar Customer Test | Shipments from Current Month |

@GUI
Scenario Outline:Verify the Services type check boxes in Show Filter section when logged in user mapped customer TMS type MG for Customer users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I Click on Show Filter link
Then I will see services associated to mapped customer TMS type <TMS_Type>
Examples: 
| Scenario | Username        | Password | ShipmentList_Header | Customer_Name            | TMS_Type |
| s1       | zzzext@user.com | Te$t1234 |                     | ZZZ - Czar Customer Test | MG       |
##Passed valid Username must mapped to Customer mapped to MG TMS type



#Commented bcz getting pop on dasboard page as given user doesn't have shipment

@GUI @Ignore
Scenario Outline:Verify the Services type check boxes in Show Filter section when logged in user mapped customer TMS type CSA for Customer users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I Click on Show Filter link
Then I will see services associated to mapped customer TMS type <TMS_Type>
Examples: 
| Scenario | Username         | Password | ShipmentList_Header | Customer_Name            | TMS_Type |
| s1       | zzzcsa@stage.com | Te$t1234 |                     | Kim Manufacturing        | CSA      |

###Passed valid  Username must mapped to Customer mapped to CSA TMS type

@GUI @Ignore
Scenario Outline:Verify the Services type check boxes in Show Filter section when logged in user mapped customer TMS type Both for Customer users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I Click on Show Filter link
Then I will see services associated to mapped customer TMS type <TMS_Type>
Examples: 
| Scenario | Username                | Password | ShipmentList_Header | Customer_Name            | TMS_Type |
| s1       | Both@test.com           | Te$t1234 |                     | ZZZ - GS Customer Test   | BOTH     |
###Passed valid Username must mapped to Customer mapped to both TMS type


@GUI @Functional
Scenario Outline:Verify the functionality of single and multiple selection of service type check boxes
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I Click on Show Filter link
Then I will able to select one or multi service check boxes
Examples: 
| Scenario | Username        | Password | ShipmentList_Header | Customer_Name            |TMS_Type|
| s1       | zzzext@user.com | Te$t1234 |                     | ZZZ - Czar Customer Test | MG     |


@Functional
Scenario Outline:Verify the 'Select All' and 'Clear All' button functionality for Customer users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I Click on Show Filter link
And I click on Select All button 
Then All service type check boxes should be selected <TMS_Type>
When I click on Clear All button in report section
Then All service type check boxes should be UN-checked<TMS_Type>
Examples: 
| Scenario | Username        | Password | ShipmentList_Header | Customer_Name            |TMS_Type|
| s1       | zzzext@user.com | Te$t1234 |                     | ZZZ - Czar Customer Test | MG     |


#@Functional @DB
#Scenario Outline:Try to save customized reports and verify the filtered data in shipment list gird
#Given I am a DLS user and login into application with valid <Username> and <Password>
#And I click on the Shipment Icon	
#When I Click on Show Filter link
#And enter the required filters<OrgCity>and<DestCity>
#And I Click on Save as New button
#Then I will see Save Report Modal PopUp
#And I will be able to save the Report<ReportName>
#And I will see Custom Report is Updated in Database<ReportName>,<OrgCity>,<DestCity>
#Then Data should be filtered based on created custom report <SeviceType>,<ReportName>,<Date>,<OriginCity>,<DestinationCity>,<Status>,<ReferenceNumber>
#Examples: 
#| Scenario | Username              | Password | OrgCity   | ReportName | CustomeReport_text                          | DestCity |
#| s1       |  zzzext@user.com      | Te$t1234 | Woodridge | ss         | The custom report will be for All Customers | Houston  |


@Functional @DB
Scenario Outline:Verify the saved customized reports in filter report drop down under Custom Reports section for Customer users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I Click on Show Filter link
And enter the required filters<OrgCity>and<DestCity>
And I Click on Save as New button
Then I will see Save Report Modal PopUp
Then Created report should be available in report drop down under custom report section<ReportName>
Examples: 
| Scenario | Username        | Password | ShipmentList_Header | Customer_Name            | TMS_Type | ReportName | OrgCity   | DestCity |
| s1       | zzzext@user.com | Te$t1234 |                     | ZZZ - Czar Customer Test | MG       | Aptest     | Woodridge | Houston  |



@Functional
Scenario Outline:Try to give duplicate filter report name for Customer users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment Icon	
When I Click on Show Filter link
And I given duplicate filter report name<ReportName>
Then I will be presented with error message
Examples: 
| Scenario | Username        | Password | ShipmentList_Header | Customer_Name            | TMS_Type | ReportName |
| s1       | zzzext@user.com | Te$t1234 |                     | ZZZ - Czar Customer Test | MG       | Aptest     |
