@25384 @Sprint66 
Feature: CarrierRateSettings_AdminView_StationOrCustomer

@Functional @DBVerification
Scenario Outline: Compare and verify the displaying stations count with database
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should see all stations and select individual customers dropdown
	And I should see all the stations exists in the database under all stations dropdown <Username>

Examples: 
| Scenario | Username      | Password |
| S1       | tst.admnsys16 | Te$t1234 |

@Functional @DBVerification
Scenario Outline: Compare and verify the mapped accounts to the stations with database
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should see all stations and select individual customers dropdown
	And displaying accounts for a selected station <Stationname> should match with the database 

Examples: 
| Scenario | Username      | Password | Stationname  |
| S1       | tst.admnsys16 | Te$t1234 | zagg station |

@Functional @GUI
Scenario Outline: Verify the default selected option under all stations dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should see all stations and select individual customers dropdown
	And All stations should be selected by default in all stations dropdown

Examples: 
| Scenario | Username      | Password |
| S1       | tst.admnsys16 | Te$t1234 |

@Functional 
Scenario Outline: Try to select multiple stations from the all stations dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should see all stations and select individual customers dropdown
	And I should be able to select multiple stations <Station1>, <Station2> and <Station3>

Examples: 
| Scenario | Username      | Password | Station1      | Station2      | Station3     |
| S1       | tst.admnsys16 | Te$t1234 | STATIONTEST K | SAGGEZZAINDIA | test11223344 |

@Functional 
Scenario Outline: Try to select multiple accounts from the individual customers dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should see all stations and select individual customers dropdown
	And I should be able to select multiple accounts <Account1>, <Account2> and <Account3>

Examples: 
| Scenario | Username      | Password | Account1           | Account2           | Account3               |
| S1       | tst.admnsys16 | Te$t1234 | Test Customer 1045 | Test Customer 1207 | lavakumar_portal_check |

@Functional 
Scenario Outline: Verify the individual customers dropdown when any option is selected from the all station dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple stations <Station1>, <Station2> and <Station3>
	And Individual customers dropdown should be disabled

Examples: 
| Scenario | Username      | Password | Station1      | Station2      | Station3     |
| S1       | tst.admnsys16 | Te$t1234 | STATIONTEST K | SAGGEZZAINDIA | test11223344 |

@Functional 
Scenario Outline: Verify the all stations dropdown when any option is selected from the individual customers dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And All stations dropdown should be disabled

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide |

@Functional @GUI
Scenario Outline: Verify the grid when any account selected
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And I should be able to see these options within grid - Gainshare, Minimum, Min Threshold, Min Amount, Master Accessorial charge

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide |

@Functional @GUI
Scenario Outline: Verify the text boxes when any account selected
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And I should be able to see following text boxes - Minimum, Min Threshold, Min Amount and Set Accessorials

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide |

@Functional @GUI
Scenario Outline: Verify the Buttons when any account selected
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And I should be able to see following buttons - Minimum, Min Threshold, Min Amount and Set Accessorials

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide | 

@Functional @GUI
Scenario Outline: Verify the buttons when values are not passed in text boxes
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And I should be able to see following text boxes - Minimum, Min Threshold, Min Amount and Set Accessorials
	And and Minimum, Min Threshold and Min Amount buttons should be disabled

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide |

@Functional @GUI
Scenario Outline: Try to pass the data within the text boxes and verify the fields
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And I select any carrier
	And I should be able enter the data in text boxes - <Minimum>, <MinThreshold> and <MinAmount>
	And and Minimum, Min Threshold and Min Amount buttons should be enabled

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  | Minimum | MinThreshold | MinAmount |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide | 10      | 11           | 12        |

@Functional @GUI
Scenario Outline: Verify the data format for the text boxes and verify the fields
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And Minimum text box format should be currency or percentage
	And MinThreshold text box format should be currency 
	And MinAmount text box format should be currency

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide |

@Functional @GUI
Scenario Outline: Verify Min column fields when data is applied for Minimum column
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And I select any carrier
	And I should be able enter the data in <Minimum> and click on Min button 
	And Passed data in min text box should be applied for Minimum column fields <Minimum>

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  | Minimum |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide | 10.0    |


@Functional @GUI
Scenario Outline: Verify Min threshold column fields when data is applied for Minimum Threshold column
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And I select any carrier
	And I should be able enter the data in <MinimumThreshold> and click on Minimum threshold button  
	And Passed data in min text box should be applied for Minimum Threshold column fields <MinimumThreshold>

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  | MinimumThreshold |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide | 10.0             |

@Functional @GUI
Scenario Outline: Verify Min amount column fields when data is applied for Minimum Amount column
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I Click on the Maintenance tool icon in the navigation menu	
	When I click on Pricing button from Maintenance tool page
	Then I should be able to select multiple accounts <Account1>, <Account2> and <Account3>
	And I select any carrier
	And I should be able enter the data in <MinAmount> and click on Minimum ammount button  
	And Passed data in min text box should be applied for Minimum amount column fields <MinAmount>

Examples: 
| Scenario | Username      | Password | Account1         | Account2     | Account3                  | MinAmount |
| S1       | tst.admnsys16 | Te$t1234 | 010-test account | tarrif_check | ZZZ Sandbox DLS Worldwide | 10.0      |