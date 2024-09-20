@Sprint75 @35645
Feature: IntegrationList Page_AdminDetails
	
@GUI
Scenario Outline: Verify the Admin Details on the Integration List page of Pending Approval Status
    Given I am a DLS user and login into application with valid <userName> and <password>
	When I am on Integration Request List Page 
	And I click on the filter by status Pending Approval radio button 
	And I expand the first record details
	Then I should be displayed with Status Bar and current status highlighted
	And I can see Pending Approval includes the respective stages
	And I can see Company Contact Name, Company Contact Phone and Company Contact Email 
	And I can see IT/developer contact name,IT/developer Contact phone and IT/developer email 
	And I can see Type of Integration, Year to Date shipments and Year to Date Revenue	
	And I can see the Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status for admin users <UserType>
	And I can see the integration notes of Comment, Commenter, Date/Time and Public/Private
	And I can see the Add Comment button

Examples: 
| scenario | userName    | password | UserType |
| s1       | systemadmin | Te$t1234 | admin    |


@GUI 
Scenario Outline: Verify the Admin Details on the Integratin List page of In Progress Status
    Given I am a system admin user with valid <Userame> and <Password>
    When I am on Integration Request List Page 
	And I verify In Progress staus radio button is selected 
	And I expand the first record details
	Then I should be displayed with Status Bar and current status highlighted for In Progress status
	And I can see In Progress includes the respective stages
	And I can see Company Contact Name, Company Contact Phone and Company Contact Email 
	And I can see IT/developer contact name,IT/developer Contact phone and IT/developer email 
	And I can see Type of Integration, Year to Date shipments and Year to Date Revenue	
	And I can see the Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status for admin users <UserType>
	And I can see the integration notes of Comment, Commenter, Date/Time and Public/Private
	And I can see the Add Comment button

Examples: 
| scenario | Userame    | Password | UserType |
| s1       | systemadmin | Te$t1234 | admin    |

@GUI
Scenario Outline: 35645_Verify the Admin Details page on the Integration List page of Completed Status
    Given I am a system admin user with valid <Userame> and <Password>
    When I am on Integration Request List Page 
	And I click on the filter by status Completed radio button
	And I expand the first record details
	Then I should be displayed with Status Bar and current status highlighted for Completed status
	And I can see Completed includes the respective stages
	And I can see Company Contact Name, Company Contact Phone and Company Contact Email 
	And I can see IT/developer contact name,IT/developer Contact phone and IT/developer email 
	And I can see Type of Integration, Year to Date shipments and Year to Date Revenue	
	And I can see the Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status for admin users <UserType>
	And I can see the integration notes of Comment, Commenter, Date/Time and Public/Private
	And I can see the Add Comment button
Examples: 
| scenario | Userame    | Password | UserType |
| s1       | systemadmin | Te$t1234 | admin    |




@GUI 
Scenario Outline: Verify all the fields are editable on Admin Details of Integration List page
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then verify all the fields should be editable on Admin details page
Examples: 
| scenario | Userame    | Password | 
| s1       | systemadmin | Te$t1234 | 


@GUI
Scenario Outline: Verify submit button on Admin Details of Integration List page for the In Progress status
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then I can see the Submit button for the status other than Pending RM Approval
Examples: 
| scenario | Userame    | Password | 
| s1       | systemadmin | Te$t1234 | 


@GUI
Scenario Outline: Verify submit save changes functionality on Admin Details of Integration List page
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details	
	Then I can see the modified <CompanyContactName>, <CompanyContactPhone> and <ITDevContactPhone> values on the admin details page once I click on the Submit button
	
	
Examples: 
| scenario | Userame    | Password | CompanyContactName  | ITDevContactPhone    | CompanyContactPhone  |
| s1       | systemadmin | Te$t1234 | Suresh Request List | 12345678901234567890 | 23534536457888888333 |



@GUI
Scenario Outline: Verify required fields on Admin Details of Integration List page
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify the required fields in admin integration details page are highlighted
	
Examples: 
| scenario | Userame    | Password | 
| s1       | systemadmin | Te$t1234 |


@GUI
Scenario Outline: 35645_Validate Company name field accepts alpha numeric, spaces, special characters of 50 characters

    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then I should be able to pass fifty characters to Company Contact Name including alpha numeric, spaces, special characters <CompanyContactName>
Examples: 
| scenario | Userame     | Password | CompanyContactName                                 |
| s1       | systemadmin | Te$t1234 | mklp ,./ 12QWERT !@#$%^ &*()_+"}{ bvg yui 4567 89P |

@GUI
Scenario Outline: 35645_Validate Company name by passing more than 50 characters of alpha numeric , special characters and spaces
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then I should not be able to pass more than fifty characters in Company Name field including alpha numeric, spaces, special characters <CompanyContactName>
Examples: 
| scenario | Userame     | Password | CompanyContactName                                    |
| s1       | systemadmin | Te$t1234 | mklp ,./ 12QWERT !@#$%^ &*()_+"}{ bvg yui 4567 89PBNM |


@GUI
Scenario Outline: 35645_Validate Company Contact Phone accepts equal to 20 didgits
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then I should be able to pass equal to twenty digits in Company Contact Phone <CompanyContactPhone>
Examples: 
| scenario | Userame     | Password | CompanyContactPhone   |
| s1       | systemadmin | Te$t1234 | (546) 456-45745747474574|

@GUI
Scenario Outline: 35645_Validate the Company Contact Email by passing valid email address
   Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then I should able to pass valid email address <CompanyContactEmail>
Examples: 
| scenario | Userame     | Password | CompanyContactPhone |
| s1       | systemadmin | Te$t1234 | test@test.com       |

@GUI
Scenario Outline: 35645_validate ITDev Contact Name field accepts alpha numeric, spaces, special characters of 50 characters
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then I should be able to pass fifty characters in ITDEV Contact Name including alpha numeric , spaces and special characters <ITDEVContactName>

Examples: 
| scenario | Userame     | Password | ITDEVContactName                                   |
| s1       | systemadmin | Te$t1234 | mklp ,./ 12QWERT !@#$%^ &*()_+"}{ bvg yui 4567 89P |

@GUI
Scenario Outline: 35645_Validate the ITDEV Contact Phone accepts equal to 20 digits
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then I should able to accepts equal to twenty digits in <ITDEVContactPhone>
Examples: 
| scenario | Userame     | Password | ITDEVContactPhone    |
| s1       | systemadmin | Te$t1234 | (546) 456-45745747474574 |

@GUI
Scenario Outline: 35645_Validate the ITDEV Contact Email accepts the valid email address
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then I can able to pass valid email address in ITDEV Conatct Email <ITDEVContactEmail> 
Examples: 
| scenario | Userame     | Password | ITDEVContactEmail |
| s1       | systemadmin | Te$t1234 | testczar_123@test.com     |


@GUI
Scenario Outline: 35645 - Validate the Additional Comments field accepts 500 characters which includes alpha numeric, spaces and special characters
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify I should be able to enter five hundred characters in the Additional Comments field <AdditionalComments>
Examples: 
| scenario | Userame     | Password | AdditionalComments                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| s1       | systemadmin | Te$t1234 | WSDA 463254 HGDSFHC HFGE YEWG 23JH hdsdh fhegf 635rbe  rhgwef hdgfds bnfvesfd yfgdshc ddsbfyeg 6rre yrt34bd fs feyryehjfsd yy4t dfyewfe 64f dfj 67efe yfgewf gfy ut4357dvcds det4356375632 hsgdhsdhds hsgdufh7t64 fgewjhdfw 6324dbwhjd 763453gefb sd76t5yeedb c ydsc  yu543 56478bs 7864b!@#$% )(*&^ ~!@c 6574  fhg}{">":yfe hgsd 6532 hgdsvfyes6 bghdsahd  46532 hggsvh 13 )(*BGHBCFT 47325 dghgds $$% ysfaw++_)+ wfdy ytdfys yfwqe6r3632 dfewgdv ggfwe 6734t32 6rdhb 63rtyds 7r6wghsgf twefh 67432 6r3rvsj uygduew |



@GUI
Scenario Outline: 35645 - Validate the Year to Date Shipments field accepts max 6 digits
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify the Year to Date Shipments able to enter only six digits in the Year to Date Shipments field <YearToDateShipments>
Examples: 
| scenario | Userame     | Password | YearToDateShipments |
| s1       | systemadmin | Te$t1234 | 123456              |

@GUI
Scenario Outline: 35645 - Validate the Year To Date Shipments field by passing more than 6 digits
Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Year to Date Shipment field does not accepts more than six digits in <YearToDateShipments>
Examples: 
| scenario | Userame     | Password | YearToDateShipments |
| s1       | systemadmin | Te$t1234 | 12345678454564656   |

@GUI
Scenario Outline: 35645 - Validate the Year to Date Revenue accepts max of 8 digits including currency $ with whole numbers
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify I should be able to pass only eight digits including dollar sign with whole numbers <YeartoDateRevenue>
Examples: 
| scenario | Userame     | Password | YeartoDateRevenue |
| S1       | systemadmin | Te$t1234 | 12345678          |

@GUI
Scenario Outline: 35645 - Validate the Year to Date Revenue does not accepts more than 8 digits
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify Year to Date Revenue does not accepts more than eight digits including dollar sign with whole numbers <YeartoDateRevenue>
Examples: 
| scenario | Userame     | Password | YeartoDateRevenue |
| S1       | systemadmin | Te$t1234 | 8989891211        |


@GUI
Scenario Outline: 35645 - Validate the Potential Revenue field accepts max 8 digits including currency with whole numbers
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify Potential Revenue accepts max eight digits including currency with whole numbers <PotentialRevenue>
Examples: 
| scenario | Userame     | Password | PotentialRevenue |
| S1       | systemadmin | Te$t1234 | 67678989         |

@GUI
Scenario Outline: 35645 - Validate the Potential Revenue field does not accepts more than digits including currency with whole numbers
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Potential Revenue does accepts more than eight digits including currency with whole numbers <PotentialRevenue>
Examples: 
| scenario | Userame     | Password | PotentialRevenue |
| S1       | systemadmin | Te$t1234 | 676789891098     |


@GUI
Scenario Outline: 35645 - Validate the MGCSA Total hours field accepts only 4 digits of whole numbers
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify the MGCSA Total Hours accepts max four digits of whole numbers <MGCSATotalHours>
Examples: 
| scenario | Userame     | Password | MGCSATotalHours |
| S1       | systemadmin | Te$t1234 | 2356            |

@GUI
Scenario Outline: 35645 - Validate the MGCSA Total hours field does not accepts more than 4 digits of whole numbers
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify the MGCSA Total hours field does not accepts more than four digits of whole numbers <MGCSATotalHours>
Examples: 
| scenario | Userame     | Password | MGCSATotalHours |
| S1       | systemadmin | Te$t1234 | 23563435        |

@GUI
Scenario Outline: 35645 - Validate the Integration Team Total Hours accepts max 4 digits of whole numbers
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Verify the Integration Total Hours field accepts max of four digits of whole numbers <IntegrationTotalHours>
Examples: 
| scenario | Userame     | Password | IntegrationTotalHours |
| S1       | systemadmin | Te$t1234 | 2347                  |

@GUI
Scenario Outline: 35645_Validate the Integration Team total hours field doe not accepts more than 4 digits of whole numbers
    Given I am a system admin user with valid <Userame> and <Password>
	When I am on Integration Request List Page 
	And I expand the first record details
	Then Integration Team Total Hours field does not accepst more than four digits of whole numbers <IntegrationTotalHours>
Examples: 
| scenario | Userame     | Password | IntegrationTotalHours |
| S1       | systemadmin | Te$t1234 | 2347345345            |