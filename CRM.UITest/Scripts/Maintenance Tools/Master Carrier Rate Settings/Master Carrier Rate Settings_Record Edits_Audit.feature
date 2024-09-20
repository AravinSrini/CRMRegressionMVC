@35282 @Sprint74 
Feature: Master Carrier Rate Settings_Record Edits_Audit

@Functional 
Scenario Outline: Verify if all the Column values are getting recorded in the new Record Edit DB when an edit is saved for Surge Field
Given I am a System Admin user <Username>, <Password>
And I am on the Master Carrier Rate Settings page <Title>
When I have selected a customer <CustomerName>
And I have selected one carriers
And I get surge value before editing
And I edit <Surge> value on Master Carrier Rate Settings page
Then The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Surge, Field Value - new Surge, User ID, Date/Time of edit.<CustomerName>,<Username>

Examples: 
| Scenario | Username    | Password | Title                        | CustomerName | Surge | 
| S1       | systemadmin | Te$t1234 | Master Carrier Rate Settings | Sam Demo GS  | 5     | 

@Functional 
Scenario Outline: Verify if all the colum values are getting recorded in the new Record Edit station DB when an edit is saved for Bump Field 
Given I am a System Admin user <Username>, <Password>
And I am on the Master Carrier Rate Settings page <Title>
When I have selected one Station <StationName>
And I have selected one carriers
And I get surge value before editing
And I edit <Surge> value on Master Carrier Rate Settings page
Then The following values should get saved in Station setup new Record Edit DB -Station, Customer,Carrier, Field Name, Field Value - Old Surge, Field Value - new Surge, User ID, Date/Time of edit.<StationName>,<Username>

Examples: 
| Scenario | Username    | Password | Title                        |  Surge | StationName             |
| S1       | systemadmin | Te$t1234 | Master Carrier Rate Settings |  5     | ZZZ - Web Services Test |

@Functional
Scenario Outline: Verify if all the Column values are getting recorded in the new Record Edit DB when an edit is saved for Bump Field
Given I am a System Admin user <Username>, <Password>
And I am on the Master Carrier Rate Settings page <Title>
When I have selected a customer <CustomerName>
And I have selected one carriers
And I get Bump value before editing
When I will edit <Bump> value on Master Carrier Rate Settings page
Then The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Bump, Field Value - new Bump, User ID, Date/Time of edit.<CustomerName>,<Username>

Examples: 
| Scenario | Username    | Password | Title                        | CustomerName | Bump |
| S1       | systemadmin | Te$t1234 | Master Carrier Rate Settings | Sam Demo GS  | 8    |

@Functional
Scenario Outline: Verify if all the Column values are getting recorded in the new Record Edit DB when an edit is saved for Min Field
Given I am a System Admin user <Username>, <Password>
And I am on the Master Carrier Rate Settings page <Title>
When I have selected a customer <CustomerName>
And I have selected one carriers
And I get Minimum value before editing
When I edit minimum value in Master Carrier Rate Settings page <Min>
Then The following values should get recorded in the new Record Edit DB - Station, Customer, Carrier, Field Name, Field Value - Old Min, Field Value - new Min, User ID, Date/Time of edit.<CustomerName>,<Username>

Examples: 
| Scenario | Username    | Password | Title                        | CustomerName | Min |
| S1       | systemadmin | Te$t1234 | Master Carrier Rate Settings | Sam Demo GS  | 22  |

@Functional
Scenario Outline: Verify if all the Column values are getting recorded in the new Record Edit DB when an edit is saved for Min Threshold Field
Given I am a System Admin user <Username>, <Password>
And I am on the Master Carrier Rate Settings page <Title>
When I have selected a customer <CustomerName>
And I have selected one carriers
And I get Minimum Threshold value before editing
When I edit minimum threshold value in Master Carrier Rate Settings page <MinThreshold>
Then The following values should get recorded in the new Record Edit DB - Station, Customer, Carrier, Field Name, Field Value - Old Min Threshold, Field Value - new Min Threshold, User ID, Date/Time of edit.<CustomerName>,<Username>

Examples: 
| Scenario | Username    | Password | Title                        | CustomerName | MinThreshold |
| S1       | systemadmin | Te$t1234 | Master Carrier Rate Settings | Sam Demo GS  | 43           |

@Functional
Scenario Outline: Verify if all the Column values are getting recorded in the new Record Edit DB when an edit is saved for Min Amount Field
Given I am a System Admin user <Username>, <Password>
And I am on the Master Carrier Rate Settings page <Title>
When I have selected a customer <CustomerName>
And I have selected one carriers
And I get Minimum Amount value before editing
When I edit Minimum Amount value on Master Carrier Rate Settings page <MinAmount>
Then The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Min Amount, Field Value - new Min Amount, User ID, Date/Time of edit.<CustomerName>,<Username>

Examples: 
| Scenario | Username    | Password | Title                        | CustomerName | Min Amount |
| S1       | systemadmin | Te$t1234 | Master Carrier Rate Settings | Sam Demo GS  | 54         |


@Functional
Scenario Outline: Verify if all the Column values are getting recorded in the new Record Edit DB when an edit is saved for Master Accessorial Charge Field
Given I am a System Admin user <Username>, <Password>
And I am on the Master Carrier Rate Settings page <Title>
When I have selected a customer <CustomerName>
And I have selected one carriers
And I get Master Accessorial Charge before editing
When I edit Master Accessorial Charge on Master Carrier Rate Settings page <MasterAccessorialCharge>
Then The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Master Accessorial Charge, Field Value - new Master Accessorial Charge, User ID, Date/Time of edit.<CustomerName>,<Username>

Examples: 
| Scenario | Username    | Password | Title                        | CustomerName | MasterAccessorialCharge |
| S1       | systemadmin | Te$t1234 | Master Carrier Rate Settings | Sam Demo GS  | 32                      |

@Functional
Scenario Outline: Verify if all the Column values are getting recorded in the new Record Edit DB when an edit is saved for Set Accessorial Field
Given I am a System Admin user <Username>, <Password>
And I am on the Master Carrier Rate Settings page <Title>
When I have selected a customer <CustomerName>
And I have selected one carriers
And I get Accessorial charge before editing
When I edit set Accessorial value on Master Carrier Rate Settings page <SetAccessorial>
Then The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Set Accessorial, Field Value - new Set Accessorial, User ID, Date/Time of edit.<CustomerName>,<Username>

Examples: 
| Scenario | Username    | Password | Title                        | CustomerName            | SetAccessorial |
| S1       | systemadmin | Te$t1234 | Master Carrier Rate Settings | CustomerAccountSprint73 | 34             |

