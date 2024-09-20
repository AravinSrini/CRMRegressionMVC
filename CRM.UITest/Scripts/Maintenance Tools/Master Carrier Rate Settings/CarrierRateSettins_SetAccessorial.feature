@CarrierRateSettings @25387 @Sprint66 
Feature: CarrierRateSettins_SetAccessorial	

@GUI
Scenario Outline: Verify the Set Accessorial button when user select any station
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Station> from the stations drop down list
	Then I should be able to see the <Set_Accessorial> button

	Examples: 
	| S1 | username       | password | Station   | Set_Accessorial  |
	| S1 | crmSystemAdmin | Te$t1234 | James | Set Accessorials |


@GUI
Scenario Outline: Verify the Set Accessorial button when user select any customer account
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	Then I should be able to see the <Set_Accessorial> button

	Examples: 
	| S1  |username       | password |Customer_Account|Set_Accessorial  |
	| S1 | crmSystemAdmin | Te$t1234 | Customer A     | Set Accessorials|


@GUI @Functional
Scenario Outline: Verify the pop up modal when user click on the Set Accessorial button 
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	Then Set Individual Accessorials modal should be opened with <PopHeader>
	
	Examples: 
	| S1 | username       | password | Customer_Account | Carrier | PopHeader | 
	| S1 | crmSystemAdmin | Te$t1234 | Customer A       | Conway  |Set Individual Accessorials|

	
@GUI @Functional
Scenario Outline: Verify the options on Set Accessorial pop up modal 
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	Then I should see the options to select the accessorials <SelectAccessorial> with label <SelectAccessorialType>, Gainshare with label <SetGainShare>, <ADDAnotherAccessorial> link, <Cancel> and <Save> buttons

Examples: 
	| S1 | username       | password | Customer_Account | Carrier | SelectAccessorial | SelectAccessorialType   | SetGainShare  | ADDAnotherAccessorial   | Cancel | Save |
	| S1 | crmSystemAdmin | Te$t1234 | Customer A       | Conway  | Select...         | SELECT ACCESSORIAL TYPE | SET GAINSHARE | ADD ANOTHER ACCESSORIAL | Cancel | Save |


@GUI @Functional
Scenario Outline: Verify user is able to select the accessorial from the drop down list
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	Then I should be able to select the accessorial <SelectAccessorial> from the list

Examples: 
	| S1 | username       | password | Customer_Account | Carrier | SelectAccessorial |
	| S1 | crmSystemAdmin | Te$t1234 | 010-test account | Conway  | Appointment       |

@GUI @Functional
Scenario Outline: Verify the formats to enter the Gainshare values
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	And I click on the Set Gainshare drop down list
	Then I should be able see the format as <Percentage> and <Currency>
Examples: 
	| S1 | username       | password | Customer_Account | Carrier | Percentage | Currency |
	| S1 | crmSystemAdmin | Te$t1234 | 010-test account | Conway  | %          | $        |


@GUI @Functional
Scenario Outline: Verify the Add Another Accessorial link functionality
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	And I click on the ADD Another Accessorial link
	Then another set of <SelectAccessorial> , <SetGainShare>, <ADDAnotherAccessorial> link, and <Remove> button


Examples: 
	| S1 | username       | password | Customer_Account | Carrier | SelectAccessorial | SetGainShare | ADDAnotherAccessorial | Remove |
	| S1 | crmSystemAdmin | Te$t1234 | 010-test account | Conway  | Select...         | GainShareTextBox|ADD ANOTHER ACCESSORIAL | Remove |

@GUI @Functional
Scenario Outline: Verify the Remove additional accessorial functionality
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	And I click on the ADD Another Accessorial link
    Then another set of <SelectAccessorial> , <SetGainShare>, <ADDAnotherAccessorial> link, and <Remove> button
	And I click on the Remove button
	And I should not be able to see the additional fields <SelectAccessorial> , <SetGainShare>, and <Remove> button


Examples: 
	| S1 | username       | password | Customer_Account | Carrier | SelectAccessorial | SetGainShare     | Remove |
	| S1 | crmSystemAdmin | Te$t1234 | 010-test account | Conway  | Select...         | GainShareTextBox | Remove |



@GUI @Functional
Scenario Outline: Verify the single accessorial is added in the master carrier rate settings grid when user clicks on the Save button
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	And I select the first accessorial <SelectAccessorial1> from the list
	And I enter the first gainshare value <SetGainsharevalue1> with the gainshare type <GainshareType1>
	And I click on the save button of the Set Accessorial Modal pop up
	Then selected accessorial <SelectAccessorial1> with <SetGainsharevalue1> value should be added to the Grid on the Master Carrier Rate Settings page 

Examples: 
	| S1 | username       | password | Customer_Account | Carrier | SelectAccessorial1 | SetGainsharevalue1 | GainshareType1 |
	| S1 | crmSystemAdmin | Te$t1234 | 010-test account | Conway  | Appointment        | 11                 | $              |



@GUI @Functional
Scenario Outline: Verify the Cancel button functionality for the Set Accessorial button
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	And I select the first accessorial <SelectAccessorial1> from the list
	And I enter the first gainshare value <SetGainsharevalue1> with the gainshare type <GainshareType1>
	And I click on the cancel button of the Set Accessorial Modal pop up
	Then the selected <SelectAccessorial1> should not be added in the Master Carrier Rate Settings page

Examples: 
	|S1|username|password|Customer_Account|Carrier|SelectAccessorial1|SetGainsharevalue1|GainshareType1|
	| S1 | crmSystemAdmin | Te$t1234 | 010-test account | Conway  | Appointment        | 11                 | $              |

@GUI 
Scenario Outline: Verify the error message when duplicate Set Accessorial is added
    Given I am a DLS system admin user and login into application with valid <username>,<password>
    When  I Click on the Maintenance tool icon in the navigation menu
	When I click on Pricing button from Maintenance tool page
	And I select the <Customer_Account> from the customer account drop down list
	And I select single <Carrier> from the list of the carriers
	And I click on the Set Accessorial button
	And I select the first accessorial <SelectAccessorial1> from the list
	And I enter the first gainshare value <SetGainsharevalue1> with the gainshare type <GainshareType1>
	And I click on the ADD Another Accessorial link
	And I select the second accessorial <SelectAccessorial2> from the list
	And I enter the second gainshare value <SetGainsharevalue2> with the gainshare type <GainshareType2>
	And I click on the save button of the Set Accessorial Modal pop up
	Then I should get the error message <ErrorMsg>
Examples: 
	| S1 | username       | password | Customer_Account | Carrier | SelectAccessorial1 | SetGainsharevalue1 | GainshareType1 | SelectAccessorial2 | SetGainsharevalue2 | GainshareType2 |ErrorMsg|
	| S1 | crmSystemAdmin | Te$t1234 | 010-test account | Conway  | Appointment        | 11                 | $              | Appointment        | 12                 | $              | ACCESSORIAL TYPE SHOULD BE UNIQUE |
	
