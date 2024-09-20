@43574 @Sprint82
Feature: Insurance Claims - Details Tab - Shipper DLSW OS and D Actions Insurance Info Sections - Internal and Claim Specialist User
	
@GUI
Scenario: 43574_Verify the Elements of the Shipper Section on the Details tab of the Claim Details page
	Given I am a Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
    And I clicked on the hyperlink of any displayed claim on Claims List page
    When I arrive on the Details tab's Shipper Section of the Claims Details page
	Then I should see the fields Name, Address, City, State/Prov, Zip/Postal, Country in Shipper Sub Section
	And I should see the fields Date Ack to Claimant, Date Filed w/Carrier, Cycle Time in DLSW OS&D Actions
	And I should see the fields Program, Amount, Company in Insurance Info
	And I should see Export and Claim Form button on the Claim Details Page
