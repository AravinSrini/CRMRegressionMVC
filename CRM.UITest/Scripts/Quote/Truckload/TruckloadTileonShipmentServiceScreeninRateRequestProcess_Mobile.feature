@TruckloadShipmentInformationPageMobile @17433 @Sprint59 
Feature: TruckloadTileonShipmentServiceScreeninRateRequestProcess_Mobile
	
@Regression 
Scenario Outline: Verify that logged in user has access to the Quotes
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'    
	And I click on the on hamburger menu icon	
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
    And I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '<Username>' have claim
    Then I should see the text '<QuotespageTitle>', '<QuotespageSubtitle>' and '<SubmitRateRequestBtn>'  in the Quotes landing page


	Examples: 
	| Scenario | Username | Password | UserDropdown | QuotespageTitle | QuotespageSubtitle                                         | SubmitRateRequestBtn | WindowWidth | WindowHeight |
	| S1       | zzz      | Te$t1234 | ZZZ TEST     | Quote List      | Submitted rate requests within the past 30 days are below. | Submit Rate Request  | 360         | 640          |

@Regression 
Scenario Outline: Verify the Truckload Tile view on the Shipment Services screen in rate request process
	        Given I am a DLS user and login into application with valid <Username> and <Password>
	        And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
			And I am landing on DLS Worldwide homepage with RRD logo
			And I should not see the '<UserDropdown>'
	        And I click on the on hamburger menu icon
			When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
            And I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '<Username>' have claim
    		And I Click on Submit Rate Request button
			And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
			Then user should be able to see <ServiceTile> service option in a tile view of the Shipment Services screen

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | ServiceTile | WindowWidth | WindowHeight |
	| S1       | zzz      | Te$t1234 | ZZZ TEST     | Get Quote          | Truckload   |  360        |  640         |

@Regression 
Scenario Outline: Verify Click functionality of Truckload Tile
	        Given I am a DLS user and login into application with valid <Username> and <Password>
			And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'			
	        And I am landing on DLS Worldwide homepage with RRD logo
			And I should not see the '<UserDropdown>'			
	        And I click on the on hamburger menu icon		
			When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
            And I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '<Username>' have claim
    		And I Click on Submit Rate Request button
			And I Select the <Service> type from the shipment services screen
	        Then User should be navigated to the Legacy Shipment Information Page and able to see '<RateRequestPageHeader>' , '<RateRequestSubHeadingText>'	and '<BacktoQuoteList>'

	Examples: 
	| Scenario | Username | Password | UserDropdown | Service  | WindowWidth | WindowHeight | RateRequestPageHeader | RateRequestSubHeadingText                 | BacktoQuoteList    |
	| S1       | zzz      | Te$t1234 | ZZZ TEST     |Truckload |  360        | 640          | Rate Request          | Follow the steps below to receive a rate. | Back to Quote List |

