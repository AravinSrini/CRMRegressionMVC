@MaintenanceToolsProductProtectionFunctionality_Delete_Export_Customers @20844 @Sprint62
Feature: MaintenanceToolsProductProtectionFunctionality_Delete_Export_Customers
	
@GUI @Acceptance
Scenario Outline: Verify the presence of Delete button for Deleting the Customer from the Grid
Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option
	And   I will be able to see the presence of Delete button for Deleting the Customer Account from the Grid <StationName>, <CustomerAccount>
	Examples: 
	| Scenario | username       | password | StationName | CustomerAccount |
	| S1       | crmSystemAdmin | Te$t1234 | James       | v-vasee         |
	
	@GUI @Acceptance
Scenario Outline: Verify the presence of Ok and Cancel button in the Delete Confirmation PopUp
	Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I will be able to see the presence of Ok and Cancel button in the Delete confirmation popup upon click on Delete button <StationName>, <CustomerAccount>

	Examples: 
	| Scenario | username       | password | StationName | CustomerAccount |
	| S1       | crmSystemAdmin | Te$t1234 | James       | v-vasee         |

		@GUI @Acceptance
Scenario Outline: Verify the presence of Delete Confirmation Message in Delete Confirmation PopUp
	Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I will be able to see presence of Delete Confirmation Message in Delete Confirmation PopUp upon clicking on Delete button <StationName>, <CustomerAccount>

	Examples: 
	| Scenario | username       | password | StationName | CustomerAccount |
	| S1       | crmSystemAdmin | Te$t1234 | James       | v-vasee         |

	@Functional @Acceptance
Scenario Outline:	Verify the Customer not Deleted from the Product Protection Grid upon click on the cancel button from the Delete Confirmation PopUp
Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I clicked on the cancel button from the Delete Confirmation PopUp then the Corresponding Customer Account will not be deleted from the Product Protection Grid <StationName>, <CustomerAccount>
	Examples: 
	| Scenario | username       | password | StationName | CustomerAccount |
   | S1        | crmSystemAdmin | Te$t1234 | James       | v-vasee         |

   	@Functional @Acceptance
Scenario Outline:	Verify the Customer Deleted from the Product Protection Grid upon click on the Ok button from the Delete Confirmation PopUp
Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And   I clicked on the Ok button from the Delete Confirmation PopUp then the Corresponding Customer Account will be deleted from the Product Protection Grid <StationName>, <CustomerAccount>

	Examples: 
	| Scenario | username       | password | StationName | CustomerAccount |
   | S1        | crmSystemAdmin | Te$t1234 | James       | v-vasee         |

   @Functional @DBVerification
   Scenario Outline: Verify the Default Insurance All value from the Database for the Deleted Customer
   Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
And I will be able to verify the Default Insurance All value from the Database for the Deleted Customer <StationName>, <CustomerAccount>

Examples: 
	| Scenario | username       | password | StationName | CustomerAccount |
	| S1       | crmSystemAdmin |Te$t1234  | James       | v-vasee         |

	@GUI @Acceptance
	   Scenario Outline: Verify the presence of Export button
	   Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And I will be able to see presence of Export button

	Examples: 
	| Scenario | username       | password |
	| S1       | crmSystemAdmin | Te$t1234 | 

	@Functional @Acceptance
	Scenario Outline:Verify the Export button Functionality
	Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option
	And   I able to see the Exported Customer Account count in Excel and the Grid Count same when clicking on the Export button <StationName>, <CustomerAccount>,<PPPCustomersExcel>

	Examples: 
	| Scenario | username       | password | StationName | CustomerAccount | PPPCustomersExcel |
	| S1       | crmSystemAdmin | Te$t1234 | James       | v-vasee         |PPPCustomers.xlsx|

	@Functional @Acceptance
	Scenario Outline:Verify the Exported Excel data Content Grid data
	Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option
	And I able to see the Exported Customer Account Matches with the Grid <StationName>, <CustomerAccount>,<PPPCustomersExcel>

	Examples: 
	| Scenario | username       | password | StationName | CustomerAccount | PPPCustomersExcel |
	| S1       | crmSystemAdmin | Te$t1234 | James       | v-vasee         | PPPCustomers.xlsx|

	@Acceptance @NotAuotmated @Manual @Ignore
Scenario:Verify rate caculation for propduct protection customer account for Default Customer
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	Then  I will have a Product Protection option
	And   I click on Product Protection option 
	And  I Delete the Customer from the Production Protection setting
	And   Logout from the application and login into application with exteranl user mapped to above Deleted default customer account and user must have access quote or shipment module
	And   Click on quote or shipment module and enter valaid data in all the fields and navigate till results page.
	And   Verify Carrier insured rates 
	And   And rates should be displayed as per the Default Customer default INS calculation