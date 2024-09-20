@Regression @Quote @Sprint81 @32090
Feature: Quote List - Station Users - Filtered Customer Functionality
	
@GUI
Scenario: 32090_Verify the text shown beneath the customer list 
	Given I am a sales, sales management, operations, or station owner user
	When I am on Quote List page
	#And i click on customer list dropdown
	And i select a customer from the customer list dropdown
	And customer list is placed beneath the header at center 
	Then text <Submitted rate requests within the past 30 days are shown.> is shown beneath the customer list 

@Functional
Scenario: 32090_Verify station selection 
	Given I am a sales, sales management, operations, or station owner user
	And I am on Quote List page as a internal user
	When i click on customer list dropdown
	Then I am allowed to select Station from the list
	 
@Functional
Scenario: 32090_Verify the quote list after selecting the station from the customer list dropdown
	Given I am a sales, sales management, operations, or station owner user
	And I am on Quote List page as a internal user
	And i click on customer list dropdown
	When I select Station from the list 
	Then the quote list will display any quotes associated to the station for the previous 30 days

@GUI @Functional
Scenario: 32090_Verify if the selected customer name is displpaying 
	Given I am a sales, sales management, operations, or station owner user
	And I am on Quote List page as a internal user
	When i select a customer from the customer list dropdown
	Then the customer name will be display

@Functional
Scenario: 32090_Verify if the previously filtered customer is pre-selected after return to Quote List page
   Given I am a sales, sales management, operations, or station owner user
   And I am on Quote List page as a internal user
   And I have selected a customer on the Quote List page
   And I have navigated away from Quote List page
   When I return to the Quote List page 
   Then the customer previously filtered will be pre-selected
   And the quote list will display any quotes associated to the customer for the previous 30 days
   And I have the option to select another customer, station


@Functional
 Scenario: 32090_Verify if the previously filtered customer is pre-selected after navigate to Shipment List page
   Given I am a sales, sales management, operations, or station owner user
   And I am on Quote List page as a internal user
   And I have selected a customer on the Quote List page
   When I arrive on the Shipment List page
   Then the customer selected on the Quote List page will be pre-selected
   And the shipment list will display any shipments associated to the customer for the previous 30 days
   And I have the option to select another customer, station

@GUI @Functional
Scenario: 32090_Verify if the previously filtered station is pre-selected after return to Quote List page
   Given I am a sales, sales management, operations, or station owner user
   And I am on Quote List page as a internal user
   And I have selected a station on the Quote List page
   And I have navigated away from the Quote List page
   When I return to the Quote List page 
   Then the customer previously filtered will be pre-selected
   And The quote list should display any quotes associated to the station for the previous 30 days 
   And I have the option to select another customer, station


@GUI @Functional
 Scenario: 32090_Verify if the previously filtered station is pre-selected after navigate to Shipment List page
   Given I am a sales, sales management, operations, or station owner user
   And I am on Quote List page as a internal user
   And I have selected a station on the Quote List page
   When I arrive on the Shipment List page
   Then the station selected on the Quote List page will be pre-selected
   And The shipment list should display any shipments associated to the station for the previous 30 days 


   


