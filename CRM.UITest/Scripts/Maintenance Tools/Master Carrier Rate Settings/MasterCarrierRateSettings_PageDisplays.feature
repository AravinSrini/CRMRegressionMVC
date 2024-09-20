@33386 @Sprint72
Feature: MasterCarrierRateSettings_PageDisplays

@GUI
Scenario Outline: 33386_Verify user selecting only one customer
Given I am a system admin or pricing user <userName> and <password>
When I am on Master Carrier Rate Settings Page
Then I am able to select one customer <customerName>

Examples: 
| scenario | userName    | password | customerName     | 
| s1       | systemadmin | Te$t1234 | testMCRSpage1226 | 

@GUI @DBVerification
Scenario Outline: 33386_Verify the grid when user selected customer does not have carrier specific pricing
Given I am a system admin or pricing user <userName> and <password>
And I am on Master Carrier Rate Settings Page
When I select the customer that does not have carrier specific pricing <customerName>
Then the grid will display for all carriers 
And the fields Gainshare, Minimum, Min Threshold, Min Amount and Master Accessorial Charge will update with the values submitted in CSR for the customer <customerName>

Examples: 
| scenario | userName    | password | customerName           |
| s1       | systemadmin | Te$t1234 | custolevelgainshareswa |

@GUI @DBVerification
Scenario Outline: 33386_Verify the grid when user selected customer has carrier specific pricing
Given I am a system admin or pricing user <userName> and <password>
And I am on Master Carrier Rate Settings Page
When I select the customer that has carrier specific pricing <customerName>
Then the grid will display for all carriers
And the fields Gainshare, Minimum, Min Threshold, Min Amount and Master Accessorial Charge will update with the values submitted in CSR for carriers with carrier specific pricing <customerName>

Examples: 
| scenario | userName    | password | customerName   |
| s1       | systemadmin | Te$t1234 | MasterCRSPTest |

@GUI @DBVerification
Scenario Outline: 33386_Verify the grid when the selected customer have one or more individual accessorials
Given I am a system admin or pricing user <userName> and <password>
And I am on Master Carrier Rate Settings Page
When I selected the customer <customerName> having one or more individual accessorials
Then the grid must be updated with individual accessorials associated with selected customer <customerName>

Examples: 
| scenario | userName    | password | customerName     |
| s1       | systemadmin | Te$t1234 | testMCRSpage1226 |

@GUI
Scenario Outline: 33386_Verify the grid when user excluded the carriers while submitting CSR
Given I am a system admin or pricing user <userName> and <password>
And I am on Master Carrier Rate Settings Page
When I selected <customerName> with excludedcarriers
Then the <excludedCarriers> will be inactive in grid

Examples: 
| scenario | userName    | password | customerName   | excludedCarriers       |
| s1       | systemadmin | Te$t1234 | MasterCRSPTest | Con-Way,R & L Carriers |

@GUI
Scenario Outline: 33386_Verify the carrier list of alphabetical order
Given I am a system admin or pricing user <userName> and <password>
When I am on Master Carrier Rate Settings Page
Then carriers should be displayed in alphabetical order

Examples: 
| scenario | userName    | password |
| s1       | systemadmin | Te$t1234 |
