@Customer_Invoice_Filter_And_Sort_Invoices @41889 @Sprint78 
Feature: Customer_Invoice_Filter_and_Sort_Invoices


#============>> Verifying scenario for External Users

@GUI
Scenario: 41889_Verify the Search Filter functionality on Customer Invoices List Page for Ship Entry User
	Given I am a Ship entry user 
    And  I am on the Customer Invoices list Page
	When I click in the Filter displayed invoices field 
	Then I have option to type in any value 
	And Any Displayed rows that contain the values that were entered will be filtered 

@GUI
Scenario: 41889_Verify the Default Filter Unpaid Option and Default sort functionality on Customer Invoices List Page for Ship entry user
	Given I am a Ship entry user
   When I arrive on the Customer Invoices list page
    Then The default display filter will be by Unpaid invoices
    And The Default sort will be by Invoice Date and Invoice Date sort will default to earliest date to latest date

@GUI
Scenario: 41889_Verify the Click functionality of Paid Display filter Option on Customer Invoices List Page for Ship entry user
	Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
    When I click on the Paid display filter option
    Then The grid will refresh to display all Paid invoices in which I am associated
    And The Default sort will be by Invoice Date and Invoice Date sort will default to earliest date to latest date

@GUI 
Scenario: 41889_Verify the Click functionality of All Display filter Option on Customer Invoices List Page for Ship entry user
	Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
    When I click on the All display filter option
	Then the grid will refresh to display all invoices in which I am associated
    And The Default sort will be by Invoice Date and Invoice Date sort will default to earliest date to latest date

	
@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Account Number column on Customer List Page for Ship entry user
	Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Account number
	Then The Grid will be sorted as lowest to highest and clicking on Account Number column arrow again it will reverse the sort

@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Invoice Number column on Customer List Page for Ship entry user
	Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Invoice number
	Then The Grid will be sorted as lowest to highest and clicking on Invoice number column arrow again it will reverse the sort

@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Reference Number column on Customer List Page for Ship entry user
	Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Reference number
	Then The Grid will be sorted as lowest to highest and clicking on Reference number column arrow again it will reverse the sort

@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Days Past Due column on Customer List Page for Ship entry user
	Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Days Past Due
	Then The Grid will be sorted as lowest to highest and clicking on Days Past Due column arrow again it will reverse the sort

@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Dispute Code column on Customer List Page for Ship entry user
	Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Dispute Code 
	Then The Grid will be sorted as lowest to highest and clicking on Dispute Code  column arrow again it will reverse the sort

@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Sales Rep column on Customer List Page for Ship entry user
	Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Sales Rep 
	Then The Grid will be sorted as alphabetically and clicking on Sales Rep column arrow again it will reverse the sort

@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Due Date Column on Customer List Page for Ship entry User
    Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Due Date column
	Then The grid will be sorted from earliest date to latest date and clicking on Due Date Column arrow again it will reverse the sort

@GUI
Scenario: 41889_Verify the Click functionality of Customer Number / Name Column filter arrow on Customer List Page for Ship entry User
    Given I am a Ship entry user
	And  I am on the Customer Invoices list Page
    When I click on the Customer Number/Name column filter arrow once
	Then Verify grid will be sorted as lowest to highest and clicking on Customer Number / Name arrow again it will reverse the sort



#============>> Verifying scenario for Internal Users

@GUI
Scenario: 41889_Verify the Search Filter functionality on Customer Invoices List Page for Operation User
	Given I am a Operation user
    And  I am on the Customer Invoices list Page
	When I click in the Filter displayed invoices field 
	Then I have option to type in any value 
	And Any Displayed rows that contain the values that were entered will be filtered 


@GUI
Scenario: 41889_Verify the Default Filter Unpaid Option and Default sort functionality on Customer Invoices List Page for Operation User
	Given I am a Operation user
    When I arrive on the Customer Invoices list page
    Then The default display filter will be by Unpaid invoices
    And The Default sort will be by Invoice Date and Invoice Date sort will default to earliest date to latest date


@GUI
Scenario: 41889_Verify the Click functionality of Paid Display filter Option on Customer Invoices List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
    When I click on the Paid display filter option
    Then The grid will refresh to display all Paid invoices in which I am associated
    And The Default sort will be by Invoice Date and Invoice Date sort will default to earliest date to latest date


@GUI 
Scenario: 41889_Verify the Click functionality of All Display filter Option on Customer Invoices List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
    When I click on the All display filter option
	Then the grid will refresh to display all invoices in which I am associated
    And The Default sort will be by Invoice Date and Invoice Date sort will default to earliest date to latest date

	
@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Account Number column on Customer List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Account number
	Then The Grid will be sorted as lowest to highest and clicking on Account Number column arrow again it will reverse the sort


@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Invoice Number column on Customer List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Invoice number
	Then The Grid will be sorted as lowest to highest and clicking on Invoice number column arrow again it will reverse the sort


@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Reference Number column on Customer List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Reference number
	Then The Grid will be sorted as lowest to highest and clicking on Reference number column arrow again it will reverse the sort


@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Days Past Due column on Customer List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Days Past Due
	Then The Grid will be sorted as lowest to highest and clicking on Days Past Due column arrow again it will reverse the sort


@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Dispute Code column on Customer List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Dispute Code 
	Then The Grid will be sorted as lowest to highest and clicking on Dispute Code  column arrow again it will reverse the sort


@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Sales Rep column on Customer List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Sales Rep 
	Then The Grid will be sorted as alphabetically and clicking on Sales Rep column arrow again it will reverse the sort


@GUI
Scenario: 41889_Verify the Click Functionality of Sort arrow of Due Date Column on Customer List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
	When I click on the sort arrow of Due Date column
	Then The grid will be sorted from earliest date to latest date and clicking on Due Date Column arrow again it will reverse the sort


@GUI
Scenario: 41889_Verify the Click functionality of Customer Number / Name Column filter arrow on Customer List Page for Operation User
	Given I am a Operation user
	And  I am on the Customer Invoices list Page
    When I click on the Customer Number/Name column filter arrow once
	Then Verify grid will be sorted as lowest to highest and clicking on Customer Number / Name arrow again it will reverse the sort















