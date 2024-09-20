@ShipmentList_CustomReportsCreate_StationUsers @27812 @Sprint68
Feature: ShipmentList_CustomReportsCreate_StationUsers

@GUI @Acceptance
Scenario Outline: Verify the absence of Customer selection and presence of the custom report text
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
Then I will not be able to see Customer selection dropdown
And I will see the text message as The custom report will be for All Customers<CustomeReport_text>
Examples: 
| Scenario | Username              | Password | CustomeReport_tex                           |
| s1       | jennifer.k.fitzgerald | Te$t1234 | The custom report will be for All Customers |
#| s2       | stationowner@test.com | Te$t1234 | The custom report will be for All Customers |
#| s3       | crmOperation@user.com | Te$t1234 | The custom report will be for All Customers |
#| s4       | crmsalesusr           | Te$t1234 | The custom report will be for All Customers |

@GUI @Acceptance
Scenario Outline: Verify the presence of Save Report popUp,report name textbox,ok and cancel button
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
And I Click on Save as New button
Then I will see Save Report Modal PopUp
And I will see free form textbox
And I will see Ok and Cancel button

Examples: 
| Scenario | Username				| Password |
| s1       | jennifer.k.fitzgerald | Te$t1234 |
#| s2       | stationowner@test.com | Te$t1234 |
#| s3       | crmOperation@user.com | Te$t1234 |
#| s4       | crmsalesusr           | Te$t1234 |


@GUI @Acceptance
Scenario Outline: Verify the Save Report Modal Pop Up closes UpOn Click on Cancel button
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
And I Click on Save as New button
Then I will see Save Report Modal PopUp
And I Click on cancel button closes the Save Report Modal Pop
Examples: 
| Scenario | Username			   | Password |
| s1       | jennifer.k.fitzgerald | Te$t1234 |
#| s2       | stationowner@test.com | Te$t1234 |
#| s3       | crmOperation@user.com | Te$t1234 |
#| s4       | crmsalesusr           | Te$t1234 |


@DBVerification
Scenario Outline: verify the Custom report Saved in Database UpOn Click on Ok button in the Save Report Modal PopUp
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
And enter the required filters<OrgCity>and<DestCity>
And I Click on Save as New button
Then I will see Save Report Modal PopUp
And I will be able to save the Report<ReportName>
And I will be able to see Report data in database<ReportName>OriginCity<OrgCity>DestinationCity<DestCity>
And the I will not see Custom Filter section
And I will be able to see created Report in the Report dropdown
And I will see Customer Account dropdown
And I will not see Custom Report text<CustomeReport_text>

Examples: 
| Scenario | Username              | Password | OrgCity   | ReportName | CustomeReport_text								  | DestCity |
| s1       | jennifer.k.fitzgerald | Te$t1234 | Woo		  | tapcity         | The custom report will be for All Customers | Hous	 |
#| s2       | stationowner@test.com | Te$t1234 | Koo       | kapcity         | The custom report will be for All Customers | Kous	 |
#| s3       | crmOperation@user.com | Te$t1234 | Poo       | papcity         | The custom report will be for All Customers | Pous	 |
#| s4       | crmsalesusr		   | Te$t1234 | Doo		  | dapcity         | The custom report will be for All Customers | Dous	 |





@Functional
Scenario Outline: verify the External Users MG API in Shipment List Grid for Custom report
Given I am a DLS user and login into application with valid <Useremail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
When I select any Custom Report from Report Dropdown<CustomReport>
Then the Shipment list displayed for the selected Custom Report and Customer Accountuser<Useremail>service<ServiceType>reference<RefNumber>startdate<StardDate>enddate<Enddate>orgincity<OrgCity>destcity<DestCity>status<Status>acc<CustomerAccount>accnumber<MgCustomerAccountNumber>report<APIReport>


Examples: 
| Scenario | Useremail                     | Password | ServiceType | RefNumber   | StardDate  | Enddate    | OrgCity | DestCity | Status		   | CustomerAccount						 | MgCustomerAccountNumber | APIReport					  | CustomReport         |
| s1       | zzzext@user.com			   | Te$t1234 | LTL         | ZZX00206515 | 09/26/2017 | 10/06/2017 |CHICAGO  | TOLEDO   | In Transit      | ZZZ - Czar Customer Test                | ZZZCZAR				   |CRM-CustomReportNoDestCityRef |       Gvaptest       |


@Functional
Scenario Outline: verify the Internal Users MG API in Shipment List Grid for Custom report
Given I am a DLS user and login into application with valid <Useremail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
When I select any Custom Report from Report Dropdown<CustomReport>
And I select any Customer Account from the drop down<CustomerAccount>
Then the Shipment list displayed for the selected Custom Report and Customer Accountuser<Useremail>service<ServiceType>reference<RefNumber>startdate<StardDate>enddate<Enddate>orgincity<OrgCity>destcity<DestCity>status<Status>acc<CustomerAccount>accnumber<MgCustomerAccountNumber>report<APIReport>


Examples: 
| Scenario | Useremail                     | Password | ServiceType | RefNumber   | StardDate  | Enddate    | OrgCity | DestCity | Status		   | CustomerAccount						 | MgCustomerAccountNumber | APIReport					  | CustomReport      |
| s1       | jennifer.k.fitzgerald@rrd.com | Te$t1234 | LTL         | ZZX00206515 | 09/26/2017 | 10/06/2017 |CHICAGO  | TOLEDO   | In Transit      | ZZZ - Czar Customer Test               | ZZZWST				   |CRM-AgentReportNoDestCityRef |       Intap       |



@Functional
Scenario Outline: verify the API response for CSA Report for External Users
Given I am a DLS user and login into application with valid <Useremail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
And I create Custom Report<servType>,<StardDate>,<Enddate>,<Status_UI>,<OrgCity>,<DestCity>,<RefNumber>
And I Click on Save as New button
Then I will see Save Report Modal PopUp
And I will be able to save the Report<ReportName>
And I selecting any customer Account<CustomerAccount><UserType>
Then the Shipment list will be displayed for the created Report<servType>reference<RefNumber>startdate<StardDate>enddate<Enddate>orgincity<OrgCity>destcity<DestCity>status<Status_UI>acc<CustomerAccount>


Examples: 
| Scenario | Useremail					   | Password                      | servType				   | RefNumber     | StardDate  | Enddate    | OrgCity    | DestCity  | Status_UI       | CustomerAccount          | ReportName                   |UserType |
| s1       | Both@test.com				   | Te$t1234					   | International			   |               | 11/08/2016 | 10/13/2017 |            |           |                 |ZZZ - GS Customer Test    |  TCSAp                       |	External|
| s2       | Both@test.com				   | Te$t1234					   | DomForwarding			   |               | 11/08/2016 | 10/13/2017 |            |           |                 |ZZZ - GS Customer Test    |  TVCSAM                       |	External|

@Functional
Scenario Outline: verify the API Response for CSA Report for Internal Users of TMS CSA or Both
Given I am a DLS user and login into application with valid <Useremail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
And I create Custom Report<servType>,<StardDate>,<Enddate>,<Status_UI>,<OrgCity>,<DestCity>,<RefNumber>
And I Click on Save as New button
Then I will see Save Report Modal PopUp
And I will be able to save the Report<ReportName>
Then the Shipment list for Internal User will be displayed for the created Report<servType>reference<RefNumber>startdate<StardDate>enddate<Enddate>orgincity<OrgCity>destcity<DestCity>status<Status_UI>acc<CustomerAccount>StationId<StationData>


Examples: 
| Scenario | Useremail			 | Password			| servType				| RefNumber | StardDate			  | Enddate			  | OrgCity | DestCity | Status_UI | CustomerAccount | ReportName       | StationData		|
|    s1    |     stationown      |   Te$t1234       | International         |           |  11/08/2016         |  10/13/2017       |         |          |           |                 |   TPVCSAp         |  ZZZ,ZZX          |
|    s2    |     stationown      |   Te$t1234       | DomForwarding         |           |  11/08/2016         |  10/13/2017       |         |          |           |                 |   TSPVCSAp        |  ZZZ,ZZX          |

@GUI 
Scenario Outline: verify the Internal User able to select any one customer from Customer Account dropdown
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
And I select any Custom Report from Report Dropdown<CustomReport>
Then I will see default Customer Selection will be All customer
And I able to select any one customer<CustomerAccount>
Examples: 
| Scenario | Username              | Password | CustomerAccount               | CustomReport |
| s1       | jennifer.k.fitzgerald | Te$t1234 | Abt Electronics & Applicances | s            |
#| s1       | stationowner@test.com | Te$t1234 | Dunkin Donuts                 | mkdontdelete |

@GUI
Scenario Outline: Verify for the text No Results found for Custom Reports
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I have select any Report which has No shipments from Report Dropdown<CustomReport>
Then I will see No Results found text message
Examples: 
| Scenario   | Username						 | Password			| CustomReport			|
|   s1       | jennifer.k.fitzgerald         |   Te$t1234       |  Norecords            |

@GUI 
Scenario Outline: Verify for the text No Results found for Standard Reports
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I have select any Report which has No shipments from Report Dropdown<StandardReport>
Then I will see No Results found text message
Examples: 
| Scenario | Username								    | Password		   | StandardReport							     |
| s1       |  jennifer.k.fitzgerald					    |  Te$t1234        |        Shipments Tendered not Booked        |


#------------------------------------Shared Report----------------------------------------------------------
@GUI
Scenario Outline: Verify the Shared Report check box
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
Then I Should see Shared Report Checkbox

Examples: 
| Scenario | Username              | Password |
| s1       | jennifer.k.fitzgerald | Te$t1234 |

@Functional @DBVerification
Scenario Outline: Verify the functionality of creating shared report
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
And I enter the required filters<OrgCity><DestCity>
And I clicked on Shared Checkbox
And I Click on Save as New button
Then Created share Custom Report should Updated in Database <ReportName>

Examples: 
| Scenario | Username              | Password | OrgCity   | ReportName | DestCity |
| s1       | jennifer.k.fitzgerald | Te$t1234 | Woodridge | SR         | Houston  |

@GUI
Scenario Outline: Verify the Error message when shared Report name already exists for another shared report with in station
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
And I enter the required filters<OrgCity><DestCity>
And I clicked on Shared Checkbox
And I Click on Save as New button
Then I try to save the shared Report which already exist for another report will be getting error message<DuplicateReportName>
Examples: 
| Scenario | Username              | Password | OrgCity   | DuplicateReportName | DestCity |
| s1       | jennifer.k.fitzgerald | Te$t1234 | Woodridge | Dont Delete         | Houston  |


@DBVerification
Scenario Outline: Verify Shared Report accessibility with any user which has access to my station
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
Then I will be able to see shared Report in drop down<SharedReportName>
Examples: 
| Scenario | Username              | Password | OrgCity   | SharedReportName | DestCity |
| s1       | stationown@stage.com  | Te$t1234 | Woodridge | Dont Delete         | Houston  |

