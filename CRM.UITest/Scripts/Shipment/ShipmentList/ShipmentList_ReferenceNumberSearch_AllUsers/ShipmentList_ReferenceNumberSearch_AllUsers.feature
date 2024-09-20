@26791 @Sprint68 
Feature: ShipmentList_ReferenceNumberSearch_AllUsers
	
@Functional
Scenario Outline: Verify the Error message when user not entered the Reference Number in Reference Number lookup for all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipment list <ShipmentList_Header> page
Then I should be displayed with Reference number Lookup
And I click on the search arrow of Reference number Lookup
And I must be displayed with the '<Errormessage>' in the Error pop up

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Errormessage                                                    |
| s1       | shpent       | Te$t1234 | Shipment List       | Please enter Reference Numbers for extracting shipments detail. |
| s2       | shpinq       | Te$t1234 | Shipment List       | Please enter Reference Numbers for extracting shipments detail. |
| s3       | shpentnorts  | Te$t1234 | Shipment List       | Please enter Reference Numbers for extracting shipments detail. |
| s4       | shpinqnorts  | Te$t1234 | Shipment List       | Please enter Reference Numbers for extracting shipments detail. |
	
@Functional
Scenario Outline: Verify the Reference values in grid when user entered one or more valid Reference Numbers in Reference Numberlookup for all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipment list <ShipmentList_Header> page
And I enter the '<EnterReferenceNumber>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I should see results for the entered reference numbers '<Ref>'

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | EnterReferenceNumber                                           | Ref                                                            |
| s1       | shpent      | Te$t1234 | Shipment List       | Pit01217954                                                    | PIT01217954                                                    |
| s2       | shpinq      | Te$t1234 | Shipment List       | ZzS10510,ZzS10509                                              | ZZS10510,ZZS10509                                              |
| s3       | shpentnorts | Te$t1234 | Shipment List       | zzS10509,ZzS10506,ZzS10510                                     | ZZS10509,ZZS10506,ZZS10510                                     |
| s4       | shpinqnorts | Te$t1234 | Shipment List       | zZs10504,zZS10505,ZzS10506,zzs10507,ZZS10508,zzS10509,Zzs10510 | ZZS10504,ZZS10505,ZZS10506,ZZS10507,ZZS10508,ZZS10509,ZZS10510 |

@Functional 
Scenario Outline: Verify the user cannot enter more than 10 Reference Numbers in Reference Number Lookup for all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipment list <ShipmentList_Header> page
And I enter <MorethanTenReferenceNumbers> in the Reference number lookup
And I click on search arrow of Reference Number lookup
Then Reference number lookup is accepting maximum of nine commas seperated ten values

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | MorethanTenReferenceNumbers                                                                        |    
| s1       | shpinq      | Te$t1234 | Shipment List       | ZzS10508,ZzS10509,ZzS10507,ZzS10506,ZzS10510,ZzS10504,ZzS10505,ZzS10503,ZzS10502,ZzS10501,ZzS10498 | 
| s2       | shpentnorts | Te$t1234 | Shipment List       | ZzS10508,ZzS10509,ZzS10507,ZzS10506,ZzS10510,ZzS10504,ZzS10505,ZzS10503,ZzS10502,ZzS10501,ZzS10498 | 
| s3       | shpinqnorts | Te$t1234 | Shipment List       | ZzS10508,ZzS10509,ZzS10507,ZzS10506,ZzS10510,ZzS10504,ZzS10505,ZzS10503,ZzS10502,ZzS10501,ZzS10498 | 

@Functional 
Scenario Outline: Verify the Error message when user entered one or more invalid Reference Numbers in Reference Number lookup for all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipment list <ShipmentList_Header> page
And I enter the invalid Reference numbers '<EnterReferenceNumbers>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I can see the '<Errormessage>' 

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | EnterReferenceNumbers | Errormessage     |
| s1       | shpent      | Te$t1234 | Shipment List       | wd32                  | No Results Found |
| s2       | shpinq      | Te$t1234 | Shipment List       | ed3254,11111          | No Results Found |
| s3       | shpentnorts | Te$t1234 | Shipment List       | 103,234,45            | No Results Found |
| s4       | shpinqnorts | Te$t1234 | Shipment List       | 50006,0034            | No Results Found |

@Functional 
Scenario Outline: Verify the Reference values in the grid when user entered the combination of both invalid and valid Reference Numbers in Reference Number lookup for all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipment list <ShipmentList_Header> page
And I enter the '<EnterReferenceNumbers>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I should be displayed with the results only for the entered valid reference numbers '<Ref>'

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | EnterReferenceNumbers                                   | Ref                                           |
| s1       | shpent      | Te$t1234 | Shipment List       | rt45,PIT01217957                                        | PIT01217957                                   |
| s2       | shpinq      | Te$t1234 | Shipment List       | ed3245,ZzS10508                                         | ZZS10508                                      |
| s3       | shpentnorts | Te$t1234 | Shipment List       | 103,234,ZzS10508,ZzS10509                               | ZZS10508,ZZS10509                             |
| s4       | shpinqnorts | Te$t1234 | Shipment List       | 50006,0034,ZzS10508,ZzS10509,ZzS10507,ZzS10506,ZzS10510 | ZZS10508,ZZS10509,ZZS10507,ZZS10506,ZZS10510, |

@Functional 
Scenario Outline: Verify the Reference Number lookup field validations for all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipment list <ShipmentList_Header> page
And I enter the incorrect reference number '<EnterReferenceNumbers>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I can see the '<Errormessage>' 

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | EnterReferenceNumbers                         | Errormessage     |
| s1       | shpent      | Te$t1234 | Shipment List       | S!23#@$%^Yt7*(o)_p{L<?, 9.99999999999999E+168 | No Results Found |
| s2       | shpinq      | Te$t1234 | Shipment List       | Ss0& 789b, 7.99999999999999E+168              | No Results Found |
| s3       | shpentnorts | Te$t1234 | Shipment List       | 0Lxa8$, 9.99999999999999E+168                 | No Results Found |
| s4       | shpinqnorts | Te$t1234 | Shipment List       | l#dfTRRFFFD, 9.99999999999999E+168            | No Results Found |

@Functional
Scenario Outline: Verify the Report dropdown when user entered atleast one valid reference number in reference number lookup for all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
When I navigate to shipment list <ShipmentList_Header> page
And I enter the '<EnterReferenceNumbers>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I should see results for the entered reference numbers '<Ref>'
And Report dropdown should be defaulted to Select Report

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | EnterReferenceNumbers | Ref         |
| s1       | shpent      | Te$t1234 | Shipment List       | PIT01217954           | PIT01217954 |
| s2       | shpinq      | Te$t1234 | Shipment List       | ZZS10504              | ZZS10504    |
| s3       | shpentnorts | Te$t1234 | Shipment List       | ZZS10498              | ZZS10498    |
| s4       | shpinqnorts | Te$t1234 | Shipment List       | ZZS10509              | ZZS10509    |

@Functional
Scenario Outline: Verify the Error message when user not entered the Reference Number in Reference Number lookup for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipment list <ShipmentList_Header> page
Then I should be displayed with Reference number Lookup
And I click on the search arrow of Reference number Lookup
And I must be displayed with the '<Errormessage>' in the Error pop up

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Errormessage                                                    | 
| s1       | crmOperation | Te$t1234 | Shipment List       | Please enter Reference Numbers for extracting shipments detail. | 
| s2       | saleTest     | Te$t1234 | Shipment List       | Please enter Reference Numbers for extracting shipments detail. | 
| s3       | stationowner | Te$t1234 | Shipment List       | Please enter Reference Numbers for extracting shipments detail. | 
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | Please enter Reference Numbers for extracting shipments detail. | 

@Functional
Scenario Outline: Verify the Reference values in grid when user entered one or more valid Reference Numbers in Reference Number lookup for non admin users 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipment list <ShipmentList_Header> page
And  I have selected Customer from the dropdown <Customer_Name>
And I enter the '<EnterReferenceNumber>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I should see results for the entered reference numbers '<Ref>'

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | EnterReferenceNumber                | Ref                                 | Customer_Name            |
| s1       | crmOperation | Te$t1234 | Shipment List       | ZzX00206522,zzx00206527             | ZZX00206522,ZZX00206527             | ZZZ - GS Customer Test   |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZX00206524,ZZX00206525,ZZX00206520 | ZZX00206524,ZZX00206525,ZZX00206520 | ZZZ - Czar Customer Test |
| s3       | stationowner | Te$t1234 | Shipment List       | zzX00206522                         | ZZX00206522                         | ZZZ - GS Customer Test   |

@Functional
Scenario Outline: Verify the user cannot enter more than 10 Reference Numbers in Reference Number Lookup for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipment list <ShipmentList_Header> page
And  I have selected Customer from the dropdown <Customer_Name>
And I enter <MorethanTenReferenceNumbers> in the Reference number lookup
And I click on search arrow of Reference Number lookup
Then Reference number lookup is accepting maximum of nine commas seperated ten values

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | MorethanTenReferenceNumbers                                                                                                         | Customer_Name          |
| s1       | crmOperation | Te$t1234 | Shipment List       | ZZX00206522,ZZX00206527,ZZX00206526,ZZX00206521,ZZX00206523,ZZX00206519,ZZX00206518,ZZX00206517,ZZX00206516,ZZX00206513,ZZX00206514 | ZZZ - GS Customer Test |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZX00206513,ZZX00206516,ZZX00206517,ZZX00206518,ZZX00206519,ZZX00206506,ZZX00206507,ZZX00206521,ZZX00206523,ZZX00206526,ZZX00206527 | ZZZ - GS Customer Test |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZX00206513,ZZX00206516,ZZX00206517,ZZX00206518,ZZX00206519,ZZX00206507,ZZX00206521,ZZX00206522,ZZX00206523,ZZX00206526,ZZX00206527 | ZZZ - GS Customer Test |

@Functional
Scenario Outline: Verify the Error message when user entered one or more invalid Reference Numbers in Reference Number lookup for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipment list <ShipmentList_Header> page
And  I have selected Customer from the dropdown <Customer_Name>
And I enter the invalid Reference numbers '<EnterReferenceNumbers>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I can see the '<Errormessage>' 

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | EnterReferenceNumbers | Errormessage     | Customer_Name             |
| s1       | crmOperation | Te$t1234 | Shipment List       | gtrghtrhuTTG67        | No Results Found | Dunkin Donuts             |
| s2       | saleTest     | Te$t1234 | Shipment List       | d45,rt43656           | No Results Found | GMS Company               |
| s3       | stationowner | Te$t1234 | Shipment List       | 1234                  | No Results Found | Dunkin Donuts             |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | 2ftttg4y              | No Results Found | ZZZ Sandbox DLS Worldwide |

@Functional
Scenario Outline: Verify the Reference values in the grid when user entered the combination of both invalid and valid Reference Numbers in Reference Number lookup for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipment list <ShipmentList_Header> page
And  I have selected Customer from the dropdown <Customer_Name>
And I enter the '<EnterReferenceNumbers>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I should be displayed with the results only for the entered valid reference numbers '<Ref>'

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | EnterReferenceNumbers                              | Ref                                 | Customer_Name          |
| s1       | crmOperation | Te$t1234 | Shipment List       | ZZX00206522,ZZX00206527,gtrghtrhuTTG67             | ZZX00206522,ZZX00206527             | ZZZ - GS Customer Test |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZX00206513,d45,2ftttg4y                           | ZZX00206513                         | ZZZ - GS Customer Test |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZX00206517,ZZX00206518,ZZX00206519,gtrghtrhuTTG67 | ZZX00206517,ZZX00206518,ZZX00206519 | ZZZ - GS Customer Test |

@Functional
Scenario Outline: Verify the Reference Number lookup field validations for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipment list <ShipmentList_Header> page
And  I have selected Customer from the dropdown <Customer_Name>
And I enter the incorrect reference number '<EnterReferenceNumbers>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I can see the '<Errormessage>' 

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | EnterReferenceNumbers                 | Errormessage     | Customer_Name                |
| s1       | crmOperation | Te$t1234 | Shipment List       | Te$3*                                 | No Results Found | ZZZ - GS Customer Test       |
| s2       | saleTest     | Te$t1234 | Shipment List       | S!t7*, 9.9999999999999                | No Results Found | ZZZ - GS Customer Test       |
| s3       | stationowner | Te$t1234 | Shipment List       | 3#@$%^Yt7*(L<?, 8.9999999             | No Results Found | DunkinZZZ - GS Customer Test |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | 3#@$%^Yt7*(L<?, 9.99999999999999E+168 | No Results Found | ZZZ Sandbox DLS Worldwide    |

@Functional
Scenario Outline: Verify the Report dropdown when user entered atleast one valid reference number in reference number lookup for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipment list <ShipmentList_Header> page
And  I have selected Customer from the dropdown <Customer_Name>
And I enter the '<EnterReferenceNumbers>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I should see results for the entered reference numbers '<Ref>'
And Report dropdown should be defaulted to Select Report

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | EnterReferenceNumbers | Ref         | Customer_Name          |
| s1       | crmOperation | Te$t1234 | Shipment List       | ZZX00206522           | ZZX00206522 | ZZZ - GS Customer Test |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZX00206513           | ZZX00206513 | ZZZ - GS Customer Test |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZX00206517           | ZZX00206517 | ZZZ - GS Customer Test |


@Functional
Scenario Outline: Verify the functionality when user clicks the reference number search by selecting all customer from the customer drop down for all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon
When I navigate to shipment list <ShipmentList_Header> page
And I enter the '<EnterReferenceNumber>' in Reference Number lookup
And I click on search arrow of Reference Number lookup
Then I will be displayed with <Error_message>

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | EnterReferenceNumber  | Error_message                                                                          |
| s1       | crmOperation | Te$t1234 | Shipment List       | ZZX00206522           | Please select a customer account to extract shipment detail based on Reference Numbers |
| s2       | saleTest     | Te$t1234 | Shipment List       | ZZX00206513           | Please select a customer account to extract shipment detail based on Reference Numbers |
| s3       | stationowner | Te$t1234 | Shipment List       | ZZX00206517           | Please select a customer account to extract shipment detail based on Reference Numbers |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | ZZX00206514           | Please select a customer account to extract shipment detail based on Reference Numbers |

