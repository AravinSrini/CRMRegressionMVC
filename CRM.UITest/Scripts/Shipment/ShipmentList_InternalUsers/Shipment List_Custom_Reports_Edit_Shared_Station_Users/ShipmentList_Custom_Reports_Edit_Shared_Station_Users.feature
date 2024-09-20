@Sprint69 @28271
Feature: ShipmentList_Custom_Reports_Edit_Shared_Station_Users
	
@GUI @DBVerification	
Scenario Outline: verify Update Report Parameters button and Delete Report button are disabled Upon selecting Custom Report
Given I am a DLS user and login into application with valid <UserEmail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
And I selected Custom Report which I did not create<UserEmail>,<CustomReport>
And I Clicked on Show Filter link
Then Update Report Parameters button and Delete Report button are disabled
Examples: 
| Scenario | UserEmail                 | Password | CustomReport |
| s1       | testoperation@testenv.com | Te$t1234 | jitfitshared |

@GUI @DBVerification
Scenario Outline: verify the options Preview,Save,Share the Report present
Given I am a DLS user and login into application with valid <UserEmail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
And I selected Custom Report which I did not create<UserEmail>,<CustomReport>
And I Clicked on Show Filter link
And I Update the any Report Parameter<OrgCity>
Then I will see options as Preview and Save and Share buttons
Examples: 
| Scenario | UserEmail                 | Password            | CustomReport | OrgCity     |
| s1       | testoperation@testenv.com | Te$t1234            | jitfitshared | ChiCago     |

@DBVerification @API
Scenario Outline: verify the Shipment list updated with updated results of Report Parameters upon click on Preview button-MG Report
Given I am a DLS user and login into application with valid <Useremail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
And I selected Custom Report which I did not create<UserEmail>,<CustomReport>
And I Clicked on Show Filter link
And I Update the any Report Parameter<OrgCity>
And I Click on the Preview button
Then Shipment list displayed for the selected Custom Report and Customer Accountuser<Useremail>service<ServiceType>reference<RefNumber>startdate<StardDate>enddate<Enddate>orgincity<OrgCity>destcity<DestCity>status<Status>acc<CustomerAccount>accnumber<StationData>report<APIReport>
Examples: 
| Scenario | Useremail                    | Password | ServiceType | RefNumber   | StardDate  | Enddate    | OrgCity | DestCity | Status	      | CustomerAccount                        | StationData                  | APIReport	                 | CustomReport	|
| s1       | testoperation@testenv.com	  | Te$t1234 | LTL         | ZZX00206515 | 09/26/2017 | 10/06/2017 |CHICAGO  | TOLEDO   | In Transit      | ZZZ - Czar Customer Test               | ZZZ,PIT	                  |CRM-AgentReportNoDestCityRef  |       jitfitshared       |

@DBVerification @API
Scenario Outline: verify the Shipment list updated with updated results of Report Parameters upon click on Preview button -CSA Reports
Given I am a DLS user and login into application with valid <Useremail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
And I selected Custom Report which I did not create<Useremail>,<CustomReport>
And I Clicked on Show Filter link
And I am Update the any Report Parameter of CSA <StartDate>,<Enddate>
And I Click on the Preview button
Then the Shipment list for Internal User will be displayed for the created Report<servType>reference<RefNumber>startdate<StartDate>enddate<Enddate>orgincity<OrgCity>destcity<DestCity>status<Status_UI>acc<CustomerAccount>StationId<StationData>

Examples: 
| Scenario | Useremail			            | Password			| servType				| RefNumber | StartDate			  | Enddate			  | OrgCity | DestCity | Status_UI | CustomerAccount | CustomReport                      | StationData		|
|    s1    | testoperation@testenv.com      |   Te$t1234        | International         |           |  11/08/2016         |  10/13/2017       |         |          |           |                 |   DonDeleteSharedReport           |  ZZZ,PIT         |
