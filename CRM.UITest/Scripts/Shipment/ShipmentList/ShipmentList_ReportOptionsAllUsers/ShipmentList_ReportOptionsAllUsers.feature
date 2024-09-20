@ShipmentList_ReportOptionsAllUsers @26790 @Sprint68
Feature: ShipmentList_ReportOptionsAllUsers

@GUI @Acceptance
Scenario Outline: Verify the presence of Standard report list for Internal  and External Users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then I will see Standard report list

Examples: 
| Scenario | Username						 | Password |
| s1       | jennifer.k.fitzgerald			 | Te$t1234 |


@GUI @Acceptance
Scenario Outline: Verify Internal and External User able to select any of Standard Reports
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then I will be able to select any of the Standard report<StdReport>

Examples: 
| Scenario   | Username						 | Password			| StdReport					   |
|       s1   |    jennifer.k.fitzgerald      |  Te$t1234        | Shipments Scheduled not Rated|

@GUI @DBVerification
Scenario Outline: Verify the presence of Private Custom report list for Internal Users
Given I am a DLS user and login into application with valid <UserEmail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then I will be able to see Custom report list<UserEmail>


Examples: 
| Scenario | UserEmail                     | Password | 
| s1       | jennifer.k.fitzgerald@rrd.com | Te$t1234 | 

@GUI @DBVerification
Scenario Outline: Verify the presence of Custom report list for External Users
Given I am a DLS user and login into application with valid <UserEmail> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then I will be able to see Custom report list<UserEmail>


Examples: 
| Scenario | UserEmail               | Password                |
| s1       | zzzext@user.com	     | Te$t1234				   |




@GUI @Acceptance
Scenario Outline: Verify Internal User able to select any of Custom Reports
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then I will be able to select any of the Custom report<CustomReport>

Examples: 
| Scenario | Username                      | Password | CustomReport |
| s1       | jennifer.k.fitzgerald@rrd.com | Te$t1234 | checkcity    |



@GUI @Acceptance
Scenario Outline: Verify External User able to select any of Custom Reports
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then I will be able to select any of the Custom report<CustomReport>

Examples: 
| Scenario | Username				 | Password		  |  CustomReport |
| s1       | zzzext@user.com         | Te$t1234		  |  amtest        |


@GUI @Acceptance
Scenario Outline: Verify the presence of Date Grid section
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
Then I will be able to see Date Grid section

Examples: 
| Scenario | Username        | Password |
| s1       | zzzext@user.com | Te$t1234 | 

@GUI @Acceptance
Scenario Outline: Verify the presence of Delete and Update button active when Custom Reports are selected for External Users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then delete and update becomes active upon selecting any Custom Report<CustomReport>

Examples: 
| Scenario | Username				 | Password		  | CustomReport |
| s1       | zzzext@user.com		 | Te$t1234		  |  amtest        |



@GUI @Acceptance 
Scenario Outline: Verify the presence of Delete and Update button active when Custom Reports are selected for Internal Users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then delete and update becomes active upon selecting any Custom Report<CustomReport>

Examples: 
| Scenario | Username | Password |  CustomReport |
| s1       | jennifer.k.fitzgerald@rrd.com | Te$t1234 | checkcity    |



@GUI @Acceptance
Scenario Outline: Verify the presence of Select All, Clear All, Save as New button, OrgCity, DestCity, Reference Number, Status Textbox
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
Then I will see UI elements in Show Filter section

Examples: 
| Scenario | Username | Password |
| s1       | zzzext@user.com | Te$t1234 | 


@GUI @DBVerification
Scenario Outline: Verify the presence of Service Type for Internal users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I Clicked on Show Filter link
Then I will be able to see different Service Types<StationID>

Examples: 
| Scenario | Username                      | Password | StationID			   |
| s1       | jennifer.k.fitzgerald		   | Te$t1234 | 99,FAR,MEM,PIT,SLC,ZZZ |


@GUI @DBVerification
Scenario Outline: Verify the MG standard Reports for MG and Both TMS Type Customer Account selected
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then i will be seeing standard reports to MG only<StationID>
Examples: 
| Scenario | Username					   | Password | StationID                  |
| s1       | jennifer.k.fitzgerald		   | Te$t1234 | 99,FAR,MEM,PIT,SLC,ZZZ	   |




@GuI @DBVerification
Scenario Outline: Verify the MG standard Reports for MG and Both TMS Type User for External users
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
Then I will see MG standard Reports<_CustomerAccount>
Examples: 
| Scenario   | Username						   | Password		  | _CustomerAccount		  |
|        s1  |    zzzext@user.com      |   Te$t1234       | ZZZ - GS Customer Test    |

@GUI @DBVerification
Scenario Outline: Verify the Saved Report Parameters are matched with UI
Given I am a DLS user and login into application with valid <Username> and <Password>
When I clicked on the Shipment Module will be navigated to Shipment List page
And I clicked on the Select a Report dropdown
When I select any Custom Report from Report Dropdown<CustomReport>
Then the Report parameter of Database should match with UI<CustomReport>

Examples: 
| Scenario | Username | Password | CustomReport |
| s1       | zzzext@user.com		 | Te$t1234 | Gvcity        |
| s2       | jennifer.k.fitzgerald@rrd.com | Te$t1234 | tastvast     |