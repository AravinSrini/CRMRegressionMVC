@ShippingFrom_ShippingTo @Sprint65 @Functional
Feature: ShippingFrom_ShippingTo 
	

@24137 @NinjaSprint17 @41033 
Scenario Outline: Verify zipcode lookup auto populate functionality for the Shipping From section
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the DatePicker calender to select the <PickupDate>
	And  Click on GetRate button in rating tool page
	And  I have clicked on Get Quote Now button in rating tool page
	And  I enter zipcode <ValidOriginZip> and leave focus from the origin section in GetQuote(TL) page
    Then City <City> and State <State> fields should be populated in origin section in GetQuote(TL) page
	And  User have the ability to edit the city in shipping from section<ModifiedCity> in GetQuote (TL) page
    And  User have the option to select a state from the state drop down list in shipping from section<ModifiedState> in GetQuote(TL) page

Examples: 
| Scenario | Username              | Password | OriginZipCode | DestinationZipCode | Weight | ValidOriginZip | City  | State | ModifiedCity | ModifiedState | PickupDate |
| S1       | stationowner@test.com | Te$t1234 | 90001         | 90001              | 100    | 33126          | Miami | FL    | test         | CA            | 0          |


@24140 @NinjaSprint17 @41033 
Scenario Outline: Verify zipcode lookup auto populate functionality for the Shipping To section
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on GetRate button in rating tool page
	And  I have clicked on Get Quote Now button in rating tool page
	And  I enter zipcode <ValidDestinationZip> and leave focus from the destination section in GetQuote(TL) page
	Then City <City> and State <State> fields should be populated in destination section in GetQuote(TL) page
	And  User have the ability to edit the city in shipping to section <ModifiedCity> in GetQuote(TL) page
    And  User have the option to select a state from the state drop down list in shipping to section<ModifiedState> in GetQuote(TL) page

Examples: 
| Scenario | Username              | Password | OriginZipCode | DestinationZipCode | Weight | ValidDestinationZip | City  | State | ModifiedCity | ModifiedState | PickupDate |
| S1       | stationowner@test.com | Te$t1234 | 90001         | 90001              | 100    | 85282               | Tempe | AZ    | test2        | CA            | 0          |


@GUI @24137 @NinjaSprint17 @41033 
Scenario Outline: Verify zipcode text box on entering invalid zip in Shipping From section
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on GetRate button in rating tool page
	And  I have clicked on Get Quote Now button in rating tool page
	And  I enter zipcode <InvalidOriginZip> and leave focus from the origin section in GetQuote(TL) page
	Then background color of the origin zip code textbox should turn red and error message should be displayed in GetQuote(TL) page
	And  the Origin City and State will not Auto populate in GetQuote(TL) page

Examples: 
| Scenario | Username              | Password | OriginZipCode | DestinationZipCode | Weight | InvalidOriginZip | PickupDate |
| S1       | stationowner@test.com | Te$t1234 | 90001         | 90001              | 100    | 66666            | 0          |


@GUI @24140 @NinjaSprint17 @41033 
Scenario Outline: Verify zipcode text box on entering invalid zip in Shipping To section
	Given I am a DLS user and loggedin into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on GetRate button in rating tool page
	And  I have clicked on Get Quote Now button in rating tool page
	And  I enter zipcode <InvalidDestinationZip> and leave focus from the destination section in GetQuote(TL) page
	Then background color of the destination zip code textbox should turn red and error message should be displayed in GetQuote(TL) page
	And  the Destination City and State will not Auto populate in GetQuote(TL) page

Examples: 
| Scenario | Username              | Password | OriginZipCode | DestinationZipCode | Weight | InvalidDestinationZip | PickupDate |
| S1       | stationowner@test.com | Te$t1234 | 90001         | 90001              | 100    | 66666                 | 0          |


@24140
Scenario Outline: Verify Select State/Province drop down list will be populated with a list of Canada provinces in Shipping To section
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on GetRate button in rating tool page
	And  I have clicked on Get Quote Now button in rating tool page
	And  I select Canada Country from destination country dropdown in GetQuote(TL) page
    Then the Select State/Province drop down list will be populated with a list of Canada provinces  in Shipping To section in GetQuote(TL) page
	Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate |
| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | 100    | 0          |


@24137
Scenario Outline: Verify Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And  I clicked on Rating Tool icon
	When I enter required fields <OriginZipCode>,<DestinationZipCode>,<Weight> in rating tool page
	And I click on the calender to select the <PickupDate>
	And  Click on GetRate button in rating tool page
	And  I have clicked on Get Quote Now button in rating tool page
	And I select Canada Country from origin country dropdown in GetQuote(TL) page
    Then the Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section in GetQuote(TL) page
	Examples: 
| Scenario | Username            | Password | OriginZipCode | DestinationZipCode | Weight | PickupDate |
| S1       | stationtest@rrd.com | Te$t1234 | 90001         | 90001              | 100    | 0          |
