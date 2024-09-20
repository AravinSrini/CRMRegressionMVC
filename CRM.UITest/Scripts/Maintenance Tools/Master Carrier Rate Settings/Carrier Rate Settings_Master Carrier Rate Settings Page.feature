@25383 @Sprint66 
Feature: Carrier Rate Settings_Master Carrier Rate Settings Page

@GUI	
Scenario Outline:Verify the title of "Master Carrier Rate Settings Page"
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And The '<title>' of the page should read Master Carrier Rate Settings Page

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | title                        |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | Master Carrier Rate Settings |

@GUI
Scenario Outline:Verify the subtitle of "Master Carrier Rate Settings Page"
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And The '<subtitle>' of the page must read Adjust the rate settings for carriers

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | subtitle                              |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | Adjust the rate settings for carriers |

@Functional @GUI
Scenario Outline:Verify the existence and functionality of Back to Maintenance Tools button in the "Master Carrier Rate Settings Page"
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I must be able able to view Back to Maintenance Tools <Button> in the Master Carrier Rate Settings Page
	And Onclick of Back to Maintenence Tools button i must be navigated back to <MaintenanceTools> page

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | Button                    |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | Back to Maintenance Tools |

@Functional
Scenario Outline:Try to select one station from the stations multi select dropdown box
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I must be able to select one <station> from the stations multi select dropdown box

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | station |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | James   |

@Functional
Scenario Outline: Try to select multiple stations from the stations multi select dropdown box
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I click on Stations multi select dropdown box
	And I must be able to select multiple stations <Station1> and <station2> from  multi select dropdown box

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | Station1 | station2 |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | James    | Cust     |

@Functional
Scenario Outline:Try to select one Customer from the customers multi select dropdown box
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I must be able to select one <customer> from the customers multi select dropdown box

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | customer |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | 10thPV1  |

@Functional
Scenario Outline: Try to select multiple Customers from the customers multi select multi select dropdown box
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I click on Customers multi select dropdown box
	And I must be able to select multiple customers <Customer1> and <customer2> from  multi select dropdown box

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | Customer1 | customer2        |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | 10thPV1   | 007_010_test_sub |

@GUI
Scenario Outline:Verify the default value for Stations multi select dropdown box
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And The default value for stations multi select dropdown must read All Stations
	
Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | 
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | 

@GUI
Scenario Outline:Verify the default value for Customers multi select dropdown box
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And The default value for customers multi select dropdown box must read All customers
	
Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | 
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | 

@Functional
Scenario Outline:Try to enter data into the Surge value textbox given in the "Master Carrier Rate Settings Page"
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I must be able to enter Surge value with validations
	And I must be able to view % <symbolSurge> as Surge value format
	And I must be able to view surge '<SButton>' in the Master Carrier Rate Settings Page


Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | symbolSurge | SButton |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | %           | Surge   |


@Functional
Scenario Outline:Try to enter data into the Bump value texbox given in the "Master Carrier Rate Settings Page"
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I must be able to enter value to Bump textbox
	And I must be able to view % <symbolBump> as Bump value format
	And I must be able to view Bump <BButton> in the Master Carrier Rate Settings Page

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | symbolBump | BButton |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | %          | Bump    |

@GUI
Scenario Outline:Verify "Master Carrier Rate Settings Page" grid header values
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I must be able to view master carrier rate grid with expected headers

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | 
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | 

@GUI
Scenario Outline:Verify the option to select or unselect all or selected carriers from the "Master Carrier Rate Settings Page" grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I must have an option to select all carriers
	And I must be able to unselect all the selected carriers
	And I must have an option to choose selected carriers
	And I must be able to unselect selected carriers

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings |

@GUI @Functional
Scenario Outline:Verify if the Carrier names are sorted in ascending order in the "Master Carrier Rate Settings Page" grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I must be able to view carrier names sorted in ascending order

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings |

@GUI @Functional
Scenario Outline: Verify surge column field value when data is applied for Surge field
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I select a carrier
	And I must be able to enter Surge value - <Surge>
	And I Click on Surge button
	And The value passed from the surge textbox should be applied to surge column fields - <Surge>

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | Surge |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | 10.05 |

@GUI @Functional
Scenario Outline: Verify Bump column field value when data is applied for Bump field
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I have access to <MaintenanceTools> page
	When I click on <PricingButton> from the Maintenance Tools page
	Then I must be navigated to <MasterCarrierRateSettings> Page
	And I select a carrier
	And I must be able to enter Bump value - <Bump>
	And I Click on Bump button
	And The value passed from the Bump textbox should be applied to Bump column fields - <Bump>

Examples: 
| Username       | Password | MaintenanceTools  | PricingButton | MasterCarrierRateSettings    | Bump  |
| crmSystemAdmin | Te$t1234 | Maintenance Tools | Pricing       | Master Carrier Rate Settings | 99.00 |

