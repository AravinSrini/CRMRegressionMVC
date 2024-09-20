@Customer_Invoice_NewList_Page @Sprint78 @41840

Feature: Customer_Invoice_NewList_Page


#===============> Verifying Scenario for External Users
@GUI
Scenario: 41840_Verify the Click functionality of Customer Invoices navigation icon for Ship Entry User
	Given I am a Ship entry user 
    When I click on the Customer Invoices navigation icon
	Then I will arrive on the Customer Invoices list page

@GUI
Scenario: 41840_Verify the Page Elements of the Customer Invoices List Page for Ship Entry User
    Given I am a Ship entry user 
	When I arrive on the Customer Invoices list page
	Then I will see following Page Elements : Page Header,Filter Field with the verbiage, Filter List Options
	And I Will see the Export Button,Gird Display Option at top and bottom of Grid,Back to Dashboard button

@GUI @49366 @PrioritySprint
Scenario: 41840_Verify the Columns in the Grid of the Customer Invoices List Page for Ship Entry User
    Given I am a Ship entry user 
	When I arrive on the Customer Invoices list page
	Then I will see the following Column : Sales Rep, Account Number, Customer Number/Name, Invoice Number, Reference ID Number
	And  I will see the Invoice Date, Due Date, Original Amount, Outstanding Amount, Past Due, Days Past Due, Dispute Code

@GUI
Scenario: 41840_Verify the Column Formatting of the Customer Invoices List Page for Ship Entry User
    Given I am a Ship entry user 
	When I arrive on the Customer Invoices list page
	Then The Following Column Formatting will apply : Invoices Date - Date Format, Due Date - Date Format
	And  Original Amount - Currency format, Current - Currency format

@GUI
Scenario: 41840_Verify the Make Payment Button of the Customer Invoices List Page for Ship Entry User
    Given I am a Ship entry user  
	When I arrive on the Customer Invoices list page
	Then I will see the Make Payment Button

@GUI 
Scenario: 41840_Verify the Grid Display will Default to 10 of Customer Invoices List Page for Ship Entry User
    Given I am a Ship entry user  
	When I arrive on the Customer Invoices list page
	Then The Grid Display will Default to ten 


@GUI @Functional
Scenario: 41840_Verify the Option to change the Grid Display of Customer Invoices List Page for Ship Entry User
    Given I am a Ship entry user 
	When I arrive on the Customer Invoices list page
	Then I have Options to change the Grid Display 
	And I have the option to advance to the next Page
	And I have the option to return to a previous page
	And The grid options are displayed at the bottom of the grid also

@GUI @Functional @49366 @PrioritySprint
Scenario: 49366_Verify the column Days Past Due is not present when Closed radio button is selected for Ship Entry User
	Given I am a Ship entry user
	Given I arrive on the Customer Invoices List page
	When I Select Closed radio button under Display options
	Then  I will no longer see Days Past Due column in the grid

@GUI @Functional @49366 @PrioritySprint
Scenario: 49366_Verify the new column Payment Date added to the right of column Due Date when Closed radio button is selected for Ship Entry User
	Given I am a Ship entry user
	Given I arrive on the Customer Invoices List page
	When I Select Closed radio button under Display options
	Then I will see a new column labeled Payment Date to the right of column Due Date
	And The value for this column will be the Cleared Date(Last Payment Date from Table) from SAP 

#===============> Verifying Scenario for Internal Users 
@GUI
Scenario: 41840_Verify the Click functionality of Customer Invoices navigation icon for Operation User
	Given I am a Operation user 
    When I click on the Customer Invoices navigation icon
	Then I will arrive on the Customer Invoices list page 
	

@GUI
Scenario: 41840_Verify the Page Elements of the Customer Invoices List Page for Operation User
	Given I am a Operation user 
	When I arrive on the Customer Invoices list page
	Then I will see following Page Elements : Page Header,Filter Field with the verbiage
	And I Will see the Export Button,Gird Display Option at top and bottom of Grid,Back to Dashboard button


@GUI
Scenario: 41840_Verify the Columns in the Grid of the Customer Invoices List Page for Operation User
	Given I am a Operation user
	When I arrive on the Customer Invoices list page
	Then I will see the following Column : Sales Rep, Account Number, Customer Number/Name, Invoice Number, Reference ID Number
	And  I will see the Invoice Date, Due Date, Original Amount, Outstanding Amount, Past Due, Days Past Due, Dispute Code


@GUI
Scenario: 41840_Verify the Column Formatting  of the Customer Invoices List Page for Operation User
	Given I am a Operation user
	When I arrive on the Customer Invoices list page
	Then The Following Column Formatting will apply : Invoices Date - Date Format, Due Date - Date Format
	And  Original Amount - Currency format, Current - Currency format


@GUI
Scenario: 41840_Verify the Make Payment Button of the Customer Invoices List Page for Operation User
	Given I am a Operation user
	When I arrive on the Customer Invoices list page
	Then I will see the Make Payment Button


@GUI
Scenario: 41840_Verify the Grid Display will Default to 10 of Customer Invoices List Page for Operation User
	Given I am a Operation user
	When I arrive on the Customer Invoices list page
	Then The Grid Display will Default to ten 


@GUI 
Scenario: 41840_Verify the Option to change the Grid Display of Customer Invoices List Page for Operation User
	Given I am a Operation user
    When I arrive on the Customer Invoices list page
	Then I have Options to change the Grid Display 
	And I have the option to advance to the next Page
	And I have the option to return to a previous page
	And The grid options are displayed at the bottom of the grid also

 
#-----------------------49574 Scenario-----------------------------

@GUI @49574
Scenario: 49574_Verify user not able to see Open and Closed Option on Customer Invoice List Screen
	Given I am Station owner, Operations or SalesManagement user
    When I arrived on Customer Invoice List page
	Then the grid Display label will be hidden
	And the grid display radio buttons Open and Closed will be hidden