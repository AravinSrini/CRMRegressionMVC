@34273 @Sprint75 
Feature: Integration Request page elements

@GUI
Scenario Outline: 34273-Verify the existence of all the expected fields in Integration Request page
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should be able to view the following fields - Station,CompanyName,CompanyContactName,CompanyContactEmail,CompanyContactPhone,IT/DeveloperContactName,IT/DeveloperContactEmail,IT/DeveloperContactPhone,StartDate,TypeOfIntegration,YearToDateShipments,YearToDateRevenue,PotentialRevenue,AdditionalComments

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  |

@Functional
Scenario Outline: 34273- Validate Company Name field by passing alpha numeric, spaces and special characters upto a limit of 100 characters
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I must be able to pass data upto 100 characters to Company Name field including alpha numeric, spaces and special characters <CompanyName>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyName                                                                                          |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | qwert 12wert_1 !@#$% ^&*() -+= ]}[{'' "::; /.,<>? mnbvc xzasd fre43 231`~ 876 0p QWE CXZS PO908-=,Kq |

@Functional
Scenario Outline: 34273- Validate Company Name field by passing more than 100 characters including alpha numeric, spaces and special characters 
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should not be able to pass data more than 100 characters to Company Name field including alpha numeric, spaces and special characters <CompanyName>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyName                                                                                              |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | qwert 12wert_1 !@#$% ^&*() -+= ]}[{'' "::; /.,<>? mnbvc xzasd fre43 231`~ 876 0p QWE CXZS PO908-=,Kqwert |

@Functional
Scenario Outline: 34273-Validate Company Contact Name field by passing alpha numeric, spaces and special characters upto a limit of 50 characters
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I must be able to pass data upto 50 characters to Company Contact Name field including alpha numeric, spaces and special characters <CompanyContactName>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyContactName                                 |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | mklp ,./ 12QWERT !@#$%^ &*()_+"}{ bvg yui 4567 89P |

@Functional
Scenario Outline: 34273- Validate Company Contact Name field by passing more than 50 characters including alpha numeric, spaces and special characters 
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should not be able to pass data more than 50 characters to Company Contact Name field including alpha numeric, spaces and special characters <CompanyContactName>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyContactName                                    |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | mklp ,./ 12QWERT !@#$%^ &*()_+"}{ bvg yui 4567 89PBNM |

@Functional 
Scenario Outline: 34273-Validate Company Contact Email field by passing valid email id
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I enter valid email id to the Company Contact Email field along with all required fields <Station>,<CompanyName>,<CompanyContactName>,<CompanyContactPhone>,<CompanyContactEmail>,<ITDeveloperContactName>,<ITDeveloperContactPhone>,<ITDeveloperContactEmail>,<TypeOfIntegration>
And I click on Submit Button
And I should be able to navigate back to Intergration list page <IntegrationListPageTitle>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyName | CompanyContactEmail | Station        | CompanyContactName | CompanyContactPhone  | ITDeveloperContactName | ITDeveloperContactEmail | ITDeveloperContactPhone | TypeOfIntegration | IntegrationListPageTitle |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | Saggezza    | sag@yahoo.com       | TestStation013 | qwrwt              | 98765456754323456789 | etreu sjka             | sncbds@hotmail.com      | 98765456754323456789    | Invoicing         | Integration Request List |

@Functional
Scenario Outline: 34273-Validate Company Contact Email field by passing invalid email id
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I enter invalid email id to the Company Contact Email field along with all required fields <Station>,<CompanyName>,<CompanyContactName>,<CompanyContactPhone>,<CompanyContactEmail>,<ITDeveloperContactName>,<ITDeveloperContactPhone>,<ITDeveloperContactEmail>,<TypeOfIntegration>
And I click on Submit Button
And The Company Contact Email field should be highlighted 

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyName | CompanyContactEmail | Station        | CompanyContactName | CompanyContactPhone  | ITDeveloperContactName | ITDeveloperContactEmail | ITDeveloperContactPhone | TypeOfIntegration |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | Saggezza    | sag@yahoo           | TestStation013 | qwrwt              | 98765456754323456789 | etreu sjka             | sncbds@hotmail.com      | 98765456754323456789    | Invoicing         |

@Functional
Scenario Outline: 34273- Validate Company Contact phone field by passing upto 20 digits
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should be able to pass upto 20 digits to Company Contact phone field <CompanyContactPhone>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyContactPhone  |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 98765432123456786543 |

@Functional
Scenario Outline:34273- Validate Company Contact phone field by passing less than 10 digits 
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I pass less than 10 digits to Company contact field <CompanyContactPhone>
And I click on Submit Button
Then The Company Contact phone field should be highlighted

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyContactPhone |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 9876543             |

@Functional
Scenario Outline: 34273- Validate Company Contact phone field by passing more than 20 digits
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should not be able to pass more than 20 digits to Company Contact phone field <CompanyContactPhone>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyContactPhone       |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 9876543212345678654312345 |

@Functional
Scenario Outline: 34273-Validate IT/Developer Contact name field by passing alpha numeric, spaces and special characters upto a limit of 50 characters
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I must be able to pass data upto 50 characters to IT/Developer Contact name field including alpha numeric, spaces and special characters <ITDeveloperContactName>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | ITDeveloperContactName                             |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | awqwytr <>?": _)(*n 7654321 cfg dsa 12345 !@#$% AQ |

@Functional
Scenario Outline: 34273-Validate IT/Developer Contact name field by passing more than 50 characters including alpha numeric, spaces and special characters
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I must not be able to pass data more than 50 characters to IT/Developer Contact name field including alpha numeric, spaces and special characters <ITDeveloperContactName>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | ITDeveloperContactName                               |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | awqwytr <>?": _)(*n 7654321 cfg dsa 12345 !@#$% AQPOI |

@Functional
Scenario Outline: 34273-Validate IT/developer Contact email field by passing valid email id
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I enter valid email id to the IT/developer Contact Email field along with all required fields <Station>,<CompanyName>,<CompanyContactName>,<CompanyContactPhone>,<CompanyContactEmail>,<ITDeveloperContactName>,<ITDeveloperContactPhone>,<ITDeveloperContactEmail>,<TypeOfIntegration>
And I click on Submit Button
And I should be able to navigate back to Intergration list page <IntegrationListPageTitle>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyName | CompanyContactEmail | Station        | CompanyContactName | CompanyContactPhone  | ITDeveloperContactName | ITDeveloperContactEmail | ITDeveloperContactPhone | TypeOfIntegration | IntegrationListPageTitle |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | Saggezza    | sag@yahoo.com       | TestStation013 | qwrwt              | 98765456754323456789 | etreu sjka             | sncbds@hotmail.com      | 98765456754323456789    | Invoicing         | Integration Request List |

@Functional
Scenario Outline: 34273-Validate IT/developer Contact email by passing invalid email id
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I enter invalid email id to the IT/developer Contact email along with all required fields <Station>,<CompanyName>,<CompanyContactName>,<CompanyContactPhone>,<CompanyContactEmail>,<ITDeveloperContactName>,<ITDeveloperContactPhone>,<ITDeveloperContactEmail>,<TypeOfIntegration>
And I click on Submit Button
And The IT/developer Contact email field should be highlighted 

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | CompanyName | CompanyContactEmail | Station        | CompanyContactName | CompanyContactPhone  | ITDeveloperContactName | ITDeveloperContactEmail | ITDeveloperContactPhone | TypeOfIntegration |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | Saggezza    | sag@yahoo.com       | TestStation013 | qwrwt              | 98765432123456786543 | etreu sjka             | sncbds@hotmail          | 98765432123456786543    | Invoicing         |

@Functional
Scenario Outline: 34273- Validate IT/developer Contact phone field by passing upto 20 digits
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should be able to pass upto 20 digits to IT/developer Contact phone field <ITDeveloperContactPhone>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | ITDeveloperContactPhone |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 98765434567812345678    |

@Functional
Scenario Outline: 34273- Validate IT/developer Contact phone field by passing less than 10 digits
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I pass less than 10 digits to IT/developer Contact phone field <CompanyContactPhone>
And I click on Submit Button
Then The IT/developer Contact phone field should be highlighted

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | ITDeveloperContactPhone |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 98765434                |


@Functional
Scenario Outline: 34273- Validate IT/developer Contact phone field by passing more than 20 digits
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should not be able to pass more than 20 digits to IT/developer Contact phone field <ITDeveloperContactPhone>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | ITDeveloperContactPhone  |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 987654345678123456780987 |

@GUI
Scenario Outline: 34273-Verify the existence of expected list of options in Type of Integration multi select dropdown
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should be able to view the following values in the Type of Integration multi select dropdown- Rate Request,Shipment Import,Tracking,Document Extract,Invoicing

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  |

@Functional
Scenario Outline: 34273-Validate Year to Date shipments field by passing a maximum of 6 digits which includes numeric and whole numbers
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should be able to pass data with a maximum of 6 digits to Year to Date Shipments field which includes numeric and whole numbers <YearToDateShipments>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | YearToDateShipments |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 199320              |

@Functional
Scenario Outline: 34273-Validate Year to Date shipments field by passing more than 6 digits which includes numeric and whole numbers
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should not be able to pass more than 6 digits to Year to Date Shipments field which includes numeric and whole numbers <YearToDateShipments>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | YearToDateShipments |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 19932065            |

@Functional
Scenario Outline: 34273-Validate Year to Date Revenue field by passing a maximum of 8 digits which includes currency with $ and whole numbers
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should be able to pass data with a maximum of 8 digits to Year to Date Revenue field which includes currency with $ and whole numbers <YearToDateRevenue>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | YearToDateRevenue |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 06543245          |

@Functional
Scenario Outline: 34273-Validate Year to Date Revenue field by passing more than 8 digits which includes currency with $ and whole numbers
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should not be able to pass more than 8 digits Year to Date Revenue field which includes currency with $ and whole numbers <YearToDateRevenue>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | YearToDateRevenue |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 065432456789      |

@Functional
Scenario Outline: 34273-Validate Potential Revenue field by passing a maximum of 8 digits which includes currency with $ and whole numbers
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should be able to pass data with a maximum of 8 digits to Potential Revenue field which includes currency with $ and whole numbers <PotentialRevenue>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | PotentialRevenue |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 04532456         |

@Functional
Scenario Outline: 34273-Validate Potential Revenue field by passing more than 8 digits which includes currency with $ and whole numbers
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should not be able to pass data more than 8 digits to Potential Revenue which includes currency with $ and whole numbers <PotentialRevenue>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | PotentialRevenue |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | 045324564345     |

@Functional
Scenario Outline: 34273- Validate Additional Comments field by passing a maximum of 500 characters which includes alpha numeric, spaces and special characters
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I must be able to pass a maximum of 500 characters to Additional Comments field which includes alpha numeric, spaces and special characters <AdditionalComments>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | AdditionalComments                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | WSDA 463254 HGDSFHC HFGE YEWG 23JH hdsdh fhegf 635rbe  rhgwef hdgfds bnfvesfd yfgdshc ddsbfyeg 6rre yrt34bd fs feyryehjfsd yy4t dfyewfe 64f dfj 67efe yfgewf gfy ut4357dvcds det4356375632 hsgdhsdhds hsgdufh7t64 fgewjhdfw 6324dbwhjd 763453gefb sd76t5yeedb c ydsc  yu543 56478bs 7864b!@#$% )(*&^ ~!@c 6574  fhg}{">":yfe hgsd 6532 hgdsvfyes6 bghdsahd  46532 hggsvh 13 )(*BGHBCFT 47325 dghgds $$% ysfaw++_)+ wfdy ytdfys yfwqe6r3632 dfewgdv ggfwe 6734t32 6rdhb 63rtyds 7r6wghsgf twefh 67432 6r3rvsj uygduew |

@Functional
Scenario Outline: 34273- Validate Additional Comments field by passing more than 500 characters which includes alpha numeric, spaces and special characters
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I should not be able to pass more than 500 characters to Additional Comments field which includes alpha numeric, spaces and special characters <AdditionalComments>

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle | AdditionalComments                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  | WSDA 463254 HGDSFHC HFGE YEWG 23JH hdsdh fhegf 635rbe  rhgwef hdgfds bnfvesfd yfgdshc ddsbfyeg 6rre yrt34bd fs feyryehjfsd yy4t dfyewfe 64f dfj 67efe yfgewf gfy ut4357dvcds det4356375632 hsgdhsdhds hsgdufh7t64 fgewjhdfw 6324dbwhjd 763453gefb sd76t5yeedb c ydsc  yu543 56478bs 7864b!@#$% )(*&^ ~!@c 6574  fhg}{">":yfe hgsd 6532 hgdsvfyes6 bghdsahd  46532 hggsvh 13 )(*BGHBCFT 47325 dghgds $$% ysfaw++_)+ wfdy ytdfys yfwqe6r3632 dfewgdv ggfwe 6734t32 6rdhb 63rtyds 7r6wghsgf twefh 67432 6r3rvsj uygduew 634gfdhgs kjd |

@Functional @GUI
Scenario Outline: 34273-Verify the required fields in Intergration Request page
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
And I do not pass any values to all the required fields - Station,CompanyName,CompanyContactName,CompanyContactEmail,CompanyContactPhone,IT/DeveloperContactName,IT/DeveloperContactEmail,IT/DeveloperContactPhone,StartDate,TypeOfIntegration
And I click on the Submit button
Then All the expected required fields must be highlighted - Station,CompanyName,CompanyContactName,CompanyContactEmail,CompanyContactPhone,IT/DeveloperContactName,IT/DeveloperContactEmail,IT/DeveloperContactPhone,StartDate,TypeOfIntegration

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  |

@GUI
Scenario Outline: 34273- Verify the existence of Submit Button in Integration Request page
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I must be able to view Submit Button on Integration Request page

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  |

@GUI
Scenario Outline: 34273- Verify the existence of Back to Integration list button in Integration Request page
Given I am a system admin, operations, sales, sales management or station owner user <UserName>,<Password>
When I arrive on Integration Request page <IntegrationRequestPageTitle>
Then I must be able to view Back to Integration list button on Integration Request page

Examples: 
| Scenario | UserName    | Password | IntegrationRequestPageTitle |
| S1       | systemadmin | Te$t1234 | Submit Integration Request  |
