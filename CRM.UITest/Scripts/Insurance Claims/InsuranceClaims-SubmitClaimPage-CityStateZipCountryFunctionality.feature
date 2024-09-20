@Sprint78 @39813
Feature: InsuranceClaims_SubmitClaimPage_CityStateZipCountryFunctionality
	

@GUI
Scenario: Verify the default country selection as a ShipEntry user from Shipper Information section
	Given I have logged in as a ShipEntry user
	When I am on the Submit a Claim page
	Then the country default selection will be United States from Shipper Information section

@GUI
Scenario: Verify the default country selection as a station owner from Shipper Information section
	Given I have logged in as a station owner
	When I am on the Submit a Claim page
	Then the country default selection will be United States from Shipper Information section

@GUI
Scenario: Verify by selecting country from the dropdown in Shipper Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	When I am on the Submit a Claim page
	And the country default selection will be United States in Shipper Information section
	Then I have the option to select another country from a drop down list in Shipper Information section

@GUI
Scenario: Verify by selecting country from the dropdown in Shipper Information section as a station owner
	Given I have logged in as a station owner
	When I am on the Submit a Claim page
	And the country default selection will be United States in Shipper Information section
	Then I have the option to select another country from a drop down list in Shipper Information section

	
@GUI
Scenario: Verify the default country selection as a ShipEntry user from Claim Payable To section
	Given I have logged in as a ShipEntry user
	When I am on the Submit a Claim page
	Then the country default selection will be United States in Claim Payable To section

@GUI
Scenario: Verify the default country selection as a station owner from Claim Payable To section
	Given I have logged in as a station owner
	When I am on the Submit a Claim page
	Then the country default selection will be United States in Claim Payable To section

@GUI
Scenario: Verify by selecting country from the dropdown in Claim Payable To section as ShipEntry user  
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	When the country default selection is United States in Claim Payable To section
	Then I have the option to select another country from a drop down list in Claim Payable To section

@GUI
Scenario: Verify by selecting country from the dropdown in Claim Payable To section as station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	When the country default selection is United States in Claim Payable To section
	Then I have the option to select another country from a drop down list in Claim Payable To section

@GUI
Scenario: Verify the State dropdown from Shipper Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	When my country selection is United States in Shipper Information section
	Then I will have a drop down list of States to select the State/Province field from Shipper Information section

	
@GUI
Scenario: Verify the State dropdown from Shipper Information section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	When my country selection is United States in Shipper Information section
	Then I will have a drop down list of States to select the State/Province field from Shipper Information section

@GUI
Scenario: Verify the State dropdown from Consignee Information section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	When my country selection is United States in Consignee Information section
	Then I will have a drop down list of States to select the State/Province field from Consignee Information section

@GUI @Functional @NinjaSprint17 @41033 
Scenario: Verify the auto-fill functionality for city and state field from Shipper Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page for external user
	And my country selection is United States in Shipper Information section
	When I enter a valid US zip code in Shipper Information section
	Then the city and state fields will auto-fill with the corresponding city and state associated to the zip code in Shipper Information section

@GUI
Scenario: Verify by editing auto fill value for state from Shipper Information section for ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	And my country selection is United States in Shipper Information section
	When I enter a valid US zip code in Shipper Information section
	Then I have the ability to select a state from the drop down list from Shipper Information section

@GUI
Scenario: Verify if the auto filled values of city are editable for station owner from Shipper Information section
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Shipper Information section
	When I enter a valid US zip code in Shipper Information section
	Then I have the ability to edit the city from Shipper Information section


@GUI
Scenario: Verify by editing auto fill value for state as a station owner from Shipper Information section
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Shipper Information section
	When I enter a valid US zip code in Shipper Information section
	Then I have the ability to select a state from the drop down list from Shipper Information section

@GUI @Functional @NinjaSprint17 @41033 
Scenario: Verify the auto-fill functionality for city and state field from Consignee Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page for external user
	And my country selection is United States in Consignee Information section
	When I enter a valid US zip code in Consignee Information section
	Then the city and state fields will auto-fill with the corresponding city and state associated to the zip code in Consignee Information section

@GUI
Scenario: Verify by editing auto fill value for city from Consignee Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	And my country selection is United States in Consignee Information section
	When I enter a valid US zip code in Consignee Information section
	Then I have the ability to edit the city from Consignee Information section

@GUI
Scenario: Verify by editing auto fill value for state from Consignee Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	And my country selection is United States in Consignee Information section
	When I enter a valid US zip code in Consignee Information section
	Then I have the ability to select a state from the drop down list in Consignee Information section

	
@GUI @Functional @NinjaSprint17 @41033 
Scenario: Verify the auto-fill functionality for city and state field from Consignee Information section as a station owner 
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Consignee Information section
	When I enter a valid US zip code in Consignee Information section
	Then the city and state fields will auto-fill with the corresponding city and state associated to the zip code in Consignee Information section

@GUI
Scenario: Verify by editing auto fill value for city from Consignee Information section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Consignee Information section
	When the city and state fields are auto-filled with the corresponding city and state associated to the zip code in Consignee Information section
	Then I have the ability to edit the city from Consignee Information section

	
@GUI
Scenario: Verify by editing auto fill value for state from Consignee Information section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Consignee Information section
	When the city and state fields are auto-filled with the corresponding city and state associated to the zip code in Consignee Information section
	Then I have the ability to select a state from the drop down list from Consignee Information section

@GUI @Functional @NinjaSprint17 @41033 
Scenario: Verify the auto-fill functionality for city and state field from Claim Payable To section as a ShipEntry user
	 Given I have logged in as a ShipEntry user
	 And I am on the Submit a Claim page for external user
	 And my country selection is United States in Claim Payable To section
	 When I enter a valid US zip code in Claim Payable To section
	 Then the city and state fields will auto-fill with the corresponding city and state associated to the zip code in Claim Payable To section

@GUI
Scenario: Verify by editing auto fill value for city from Claim Payable To section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	And my country selection is United States in Claim Payable To section 
	When the city and state fields are auto-filled with the corresponding city and state associated to the zip code in Claim Payable To section
	Then I have the ability to edit the city from Claim Payable To section


@GUI
Scenario: Verify by editing auto fill value for state from Claim Payable To section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page
	And my country selection is United States in Claim Payable To section
	When the city and state fields are auto-filled with the corresponding city and state associated to the zip code in Claim Payable To section
	Then I have the ability to select a state from the drop down list in Claim Payable To section

@GUI @Functional @NinjaSprint17 @41033 
Scenario: Verify the auto-fill functionality for city and state field from Claim Payable To section as a station owner 
	 Given I have logged in as a station owner
	 And I am on the Submit a Claim page
	 And my country selection is United States in Claim Payable To section
	 When I enter a valid US zip code in Claim Payable To section
	 Then the city and state fields will auto-fill with the corresponding city and state associated to the zip code in Claim Payable To section

@GUI
Scenario: Verify by editing auto fill value for city from Claim Payable To section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Claim Payable To section
	When the city and state fields are auto-filled with the corresponding city and state associated to the zip code in Claim Payable To section
	Then I have the ability to edit the city from Claim Payable To section

@GUI
Scenario: Verify by editing auto fill value for state from Claim Payable To section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Claim Payable To section
	When the city and state fields are auto-filled with the corresponding city and state associated to the zip code in Claim Payable To section
	Then I have the ability to select a state from the drop down list in Claim Payable To section

@GUI @NinjaSprint17 @41033 
Scenario: Verify by entering invalid US zip code in the Zip/Postal field in shipper Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page for external user
	When my country selection is United States in Shipper Information section
	And I enter an invalid US zip code in shipper Information section
	Then Zip/Postal field of the Shipper Information section will be highlighted in red

@GUI @NinjaSprint17 @41033 
Scenario: Verify by entering invalid US zip code in the Zip/Postal field in shipper Information section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Shipper Information section
	When I enter an invalid US zip code in shipper Information section
	Then Zip/Postal field of the Shipper Information section will be highlighted in red

@GUI @NinjaSprint17 @41033 
Scenario: Verify by entering invalid US zip code in the Zip/Postal field in Consignee Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page for external user
	And my country selection is United States in Consignee Information section
	When I enter an invalid US zip code in Consignee Information section
	Then the Zip/Postal field of the Consignee Information section will be highlighted in red

@GUI @NinjaSprint17 @41033 
Scenario: Verify by entering invalid US zip code in the Zip/Postal field in Consignee Information section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Consignee Information section
	When I enter an invalid US zip code in Consignee Information section
	Then the Zip/Postal field of the Consignee Information section will be highlighted in red

@GUI @NinjaSprint17 @41033 
Scenario: Verify by entering invalid US zip code in the Zip/Postal field in Claims Payable To section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page for external user
	And my country selection is United States in Claims Payable To section
	When I enter an invalid US zip code in Claims Payable To section
	Then the Zip/Postal field of the Claim Payable To section will be highlighted in red

	
@GUI @NinjaSprint17 @41033 
Scenario: Verify by entering invalid US zip code in the Zip/Postal field in Claims Payable To section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	And my country selection is United States in Claims Payable To section
	When I enter an invalid US zip code in Claims Payable To section
	Then the Zip/Postal field of the Claim Payable To section will be highlighted in red
	

@GUI
Scenario: Verify State/Province drop down list from Shipper information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page for external user
	When my country selection is Canada in Shipper information section
	Then State/Province drop down list will be populated with a list of Canada provinces in Shipper information section

@GUI
Scenario: Verify State/Province drop down list from Consignee Information section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page for external user
	When my country selection is Canada in Consignee Information section
	Then State/Province drop down list will be populated with a list of Canada provinces in Consignee Information section

@GUI
Scenario: Verify State/Province drop down list from Consignee Information section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	When my country selection is Canada in Consignee Information section
	Then State/Province drop down list will be populated with a list of Canada provinces in Consignee Information section

@GUI
Scenario: Verify State/Province drop down list from Claim Payable To section as a ShipEntry user
	Given I have logged in as a ShipEntry user
	And I am on the Submit a Claim page for external user
	When my country selection is Canada in Claim Payable To section
	Then the State/Province drop down list will be populated with a list of Canada provinces in Claim Payable To section

	
@GUI
Scenario: Verify State/Province drop down list from Claim Payable To section as a station owner
	Given I have logged in as a station owner
	And I am on the Submit a Claim page
	When my country selection is Canada in Claim Payable To section
	Then the State/Province drop down list will be populated with a list of Canada provinces in Claim Payable To section