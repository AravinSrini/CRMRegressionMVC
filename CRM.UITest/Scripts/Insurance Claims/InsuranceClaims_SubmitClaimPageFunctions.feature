@Sprint 78
Feature: Insurance Claims - Submit Claim Page Functions
	

@Functional
Scenario: Verify Submit Claim button as a shpInquiry user
	Given I have logged in as a shpInquiry user
	And I am on the Claims List page
	When I click on the Submit a Claim button
	Then I arrive on the  Submit a Claim page

@Functional
Scenario: Verify Submit Claim button as a Operations Owner
	Given I have logged in as a Operations user
	And I am on the Claims List page
	When I click on the Submit a Claim button
	Then I arrive on the  Submit a Claim page

@Functional
Scenario: Verify Back to Claim List button as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	When I click on the Back to Claims List button,
	Then I will arrive on the Claims List

@Functional
Scenario: Verify Back to Claim List button as a Operations user
	Given I have logged in as a Operations user
	And I am on the Submit a Claim page
	When I click on the Back to Claims List button,
	Then I will arrive on the Claims List

@GUI @Functional
Scenario: Verify the validation message for required field as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	And I have not completed all required fields
	When I click on the Submit a Claim button
	Then I will see a message "Please complete all required fields"

@GUI @Functional
Scenario: Verify the validation message for required field as a Operations user
	Given I have logged in as a Operations user
	And I am on the Submit a Claim page
	And I have not completed all required fields 
	When I click on the Submit a Claim button
	Then I will see a message "Please complete all required fields"


@GUI
Scenario: Verify required field where data is missing as a shpInquiry user
	Given I have logged in as a shpInquiry user
	And I am on the Submit a Claim page
	And I have not completed all required fields
	When I click on the Submit a Claim button
	Then every required field where data is missing will be highlighted


@GUI
Scenario: Verify required field where data is missing as a Operations user
	Given I have logged in as a Operations user
	And I am on the Submit a Claim page
	And I have not completed all required fields 
	When I click on the Submit a Claim button
	Then every required field where data is missing will be highlighted

@GUI	
Scenario: Verify the page focus as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	And I have not completed all required fields 
	When I click on the Submit a Claim button
	Then  the page will focus to the first required field that is missing information

@GUI	
Scenario: Verify the page focus as a Station Owner
	Given I have logged in as a Station Owner
	And I am on the Submit a Claim page
	And I have not completed all required fields 
	When I click on the Submit a Claim button
	Then  the page will focus to the first required field that is missing information

@Functional
Scenario: Verify by navigate away from claim form as a ShipEntry user
	Given I have logged in as a Station Owner
	And I am on the Submit a Claim page
	And I have entered all required fields  
	When I navigate away from the claim form
	Then no data will be saved
	And I will not receive a DLSW Claim number

@Functional
Scenario: Verify by navigate away from claim form as a Station Owner
	Given I have logged in as a Station Owner
	And I am on the Submit a Claim page
	And I have entered all required fields  
	When I navigate away from the claim form
	Then no data will be saved
	

