@31880 @Sprint76
Feature: TrackingPage-ReferenceNumberSearch-ExternalUsers
	
@GUI
Scenario: 31880_Verify tracking by passing traking page url
	Given I am a DLS user and launch crm url
	When I browse the tracking page url
	Then Tracking page will display

@GUI @Functional
Scenario Outline: 31880_Verify tracking reference number search by entering one valid reference number in tracking page
	Given I am a DLS user and launch crm url
	And I am on tracking page
	And I have entered <validRefNumber> in reference number search field
	When I click on submit arrow
	Then Searched shipment information will be displayed in grid <validRefNumber>

Examples: 
| scenario | validRefNumber |
| s1       | 9900003        |

@GUI @Functional
Scenario Outline: 31880_Verify tracking reference number search by entering one or more valid reference numbers in tracking page
	Given I am a DLS user and launch crm url
	And I am on tracking page
	And I have entered <validRefNumber> in reference number search field
	When I click on submit arrow
	Then Searched shipment information will be displayed in grid <validRefNumber>

Examples: 
| scenario | validRefNumber                                  |
| s1       | LEX83064995,PIT01217989,9920495,9900001,9900003 |

@GUI @Functional
Scenario Outline: 31880_Verify tracking reference number search by entering one invalid reference number in tracking page
	Given I am a DLS user and launch crm url
	And I am on tracking page
	And I entered <invalidRefNumber> in reference number search field
	When I click on submit arrow
	Then The <errorMessage> will display

Examples: 
| scenario | invalidRefNumber | errorMessage                                   |
| s1       | SWA223           | No data found for entered reference number(s). |

@GUI @Functional
Scenario Outline: 31880_Verify tracking reference number search by entering more invalid reference numbers in tracking page
	Given I am a DLS user and launch crm url
	And I am on tracking page
	And I entered <invalidRefNumber> in reference number search field
	When I click on submit arrow
	Then The <errorMessage> will display

Examples: 
| scenario | invalidRefNumber                       | errorMessage                                   |
| s1       | swa1234,euwi893475,eiuwry85943,ariu834 | No data found for entered reference number(s). |

@GUI @Functional @Regression
Scenario Outline: 31880_Verify tracking reference number search by entering both valid and invalid reference numbers in tracking page
	Given I am a DLS user and launch crm url
	And I am on tracking page
	And I enteredboth combination of <refNumbers> in reference number search field
	When I click on submit arrow
	Then The<errorMessage> will display for invalid reference numbers
	And Pop up displays all the list of tracking numbers that not exist '<refNumbers>'
	And I clicked on close button in the warning pop up
	And I see list of Tracking Results based on the entered valid numbers '<refNumbers>'

Examples: 
| refNumbers                                | errorMessage                                                       | 
| LEX83064995,PIT01217989,swa1234,1sw254910 | Tracking details were not found for the following tracking numbers | 

@GUI @Functional
Scenario Outline: 31880_Verify Filter Results functionality in tracking page
	Given I am a DLS user and launch crm url
	And I am on tracking page
	And I have entered <Ref> in reference number search field
	When I click on submit arrow
	Then Searched values will highlight in grid <Ref>				
	
Examples: 
| scenario | Ref     | 
| s1       | 9900003 | 