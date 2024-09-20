@DomesticShipmentInformationPageNavigationDesktop @17436 @Sprint59 
Feature: Domestic Forwarding tile on Shipment Service screen in rate request processSteps_Desktop
	

@Regression
Scenario Outline: 17436_Verify that logged in user has access to the Quotes
	Given I am a DLS User and login into application with valid Username and Password
	And I am landing on DLS Worldwide homepage   
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
    And I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '<Username>' have claim
    Then I should See the text '<QuotespageTitle>', '<QuotespageSubtitle>' in the quotes landing page

	Examples: 
	| Scenario | Username       | Password | UserDropdown    | QuotespageTitle | QuotespageSubtitle                                         |
	| S1       | testingtesting | Te$t1234 | TESTING TESTING | Quote List      | Submitted rate requests within the past 30 days are shown. |

@Regression
Scenario Outline: 17436_Verify the Domestic Forwarding Tile view on the Shipment Services screen in rate request process
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage    
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
    Then user should be able to see <ServiceTile> service option in a tile view of the Shipment Services screen

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | ServiceTile         |
	| S1       | shpent   | Te$t1234 | SHP ENT      | Get Quote          | Domestic Forwarding |

@Regression
Scenario Outline: 17436_Verify the Domestic Forwarding Type modal pop up displayed when user clicks on the Domestic Forwarding Tile
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage    
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
	And I Select the <Service> type from the shipment services screen 
	Then User should be displayed with the Domestic Forwarding Type pop <PopUpHeaderText>

	Examples: 
	| Scenario | Username | Password | UserDropdown | Service             | ServicesPageHeader | PopUpHeaderText          |
	| S1       | shpent   | Te$t1234 | SHP ENT      | Domestic Forwarding | Get Quote          | Domestic Forwarding Type |
 

@Regression
Scenario Outline: 17436_Verify the user is able to see the Type drop down and able to select the option from the drop down in Domestic Forwarding Type modal
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage    
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
	And I Select the <Service> type from the shipment services screen
	Then User should be displayed with the Domestic Forwarding Type pop <PopUpHeaderText>
	And Verify user is able to see Type Drop down and able to select the option from the drop down '<TypeOption>'

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | Service             | PopUpHeaderText          | TypeOption      |
	| S1       | shpent   | Te$t1234 | SHP ENT      | Get Quote          | Domestic Forwarding | Domestic Forwarding Type | Next Flight Out |

@Regression
Scenario Outline: 17436_Verify user is able to see the Continue button in the modal pop up
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage    
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
	And I Select the <Service> type from the shipment services screen 
	Then User should be displayed with the Domestic Forwarding Type pop <PopUpHeaderText>
	And Verify user is able to see the Continue button <ContinueBtn> in the pop up 

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | Service             | PopUpHeaderText          | ContinueBtn |
	| S1       | shpent   | Te$t1234 | SHP ENT      | Get Quote          | Domestic Forwarding | Domestic Forwarding Type | Continue    |

@Regression
Scenario Outline: 17436_Verify user is able to see the Close button in the modal pop up
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage    
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
	And I Select the <Service> type from the shipment services screen 
	Then User should be displayed with the Domestic Forwarding Type pop <PopUpHeaderText>
	And Verify user is able to see the Close button '<CloseBtn>' in the pop up

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | Service             | PopUpHeaderText          | CloseBtn |
	| S1       | shpent   | Te$t1234 | SHP ENT      | Get Quote          | Domestic Forwarding | Domestic Forwarding Type | Close    |


@Regression
Scenario Outline: 17436_Verify the error message when user clicks on the Continue button with out selecting the Type from drop down
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage    
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
	And I Select the <Service> type from the shipment services screen 
	Then User should be displayed with the Domestic Forwarding Type pop <PopUpHeaderText>
	When I click on the Continue button in the pop up
	Then Verify user is able to see the error message <ErrorMsg> in the pop up

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | Service             | PopUpHeaderText          | ErrorMsg                              |
	| S1       | shpent   | Te$t1234 | SHP ENT      | Get Quote          | Domestic Forwarding | Domestic Forwarding Type | Please Enter All Required Information |


 

@Regression
Scenario Outline: 17436_Verify the navigation functionality for Close button in the Domestic Forwarding Type modal pop up
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage   
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
	And I Select the <Service> type from the shipment services screen  
	Then User should be displayed with the Domestic Forwarding Type pop <PopUpHeaderText>
	When I click on the Type drop down and select any option '<TypeOption>' from the list 
	When I click on the Close button in the pop up
	Then Verify user is still in the Shipment Services screen <ServicesPageHeader>

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | Service             | PopUpHeaderText          | TypeOption |
	| S1       | shpent   | Te$t1234 | SHP ENT      | Get Quote          | Domestic Forwarding | Domestic Forwarding Type | Next Day   |


@Regression
Scenario Outline: 17436_Verify Click functionality of Domestic Forwarding Tile
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage    
	And I am able to see the '<UserDropdown>' in the Dashboard page for the user
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
	And I Select the <Service> type from the shipment services screen  
	When I click on the Type drop down and select any option '<TypeOption>' from the list 
	And I click on the Continue button in the pop up
	Then User should be navigated to the old Shipment Locations and Dates screen and able to see '<RateRequestPageHeader>' , '<RateRequestSubHeadingText>' and '<BacktoQuoteList>'
	Then Verify the service Type and level in the Shipment Locations and Dates screen '<DomFor_SectionHeaderText>', '<ServiceType>' and '<ServiceLevel>'

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | Service             | TypeOption | RateRequestPageHeader | RateRequestSubHeadingText                 | BacktoQuoteList    | DomFor_SectionHeaderText     | ServiceType         | ServiceLevel |
	| S1       | shpent   | Te$t1234 | SHP ENT      | Get Quote          | Domestic Forwarding | Next Day   | Rate Request          | Follow the steps below to receive a rate. | Back to Quote List | Shipment Locations and Dates | Domestic Forwarding | Next Day     |