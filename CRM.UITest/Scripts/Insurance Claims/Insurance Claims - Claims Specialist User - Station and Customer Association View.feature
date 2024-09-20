@Sprint88 @49263

Feature: Insurance Claims - Claims Specialist User - Station and Customer Association View
	

Scenario: 49263-Verify the listed station from station dropdown list in submit claim page
	Given that I am a Claims Specialist user
	And I am on the Submit a Claim page
	When I click on the Station field
	Then I will have a drop down list of ALL stations
	And the stations will be listed in numerical, then alphabetical order

Scenario: 49263-Verify the listed customer from customer dropdown list in submit claim page
	Given that I am a Claims Specialist user
	And I am on the Submit a Claim page
	And I have selected a station to which I am associated
	When I click on the Customer field
	Then I will see a list of all customers of the station selected
	And the customer will be listed in hierarchy format
	And the customers will be listed in alphabetical format