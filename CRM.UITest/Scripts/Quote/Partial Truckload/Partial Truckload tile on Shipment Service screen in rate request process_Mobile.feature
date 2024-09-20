@PartialTruckloadShipmentInformationPageMobile @17434 @Sprint59
Feature: Partial Truckload tile on Shipment Service screen in rate request process_Mobile

@Regression 
Scenario Outline: 17434_Verify that logged in user has access to the Quotes_Mobile
	Given I am a DLS user with Customer dropdown and login into application
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'    
	And I click on the on hamburger menu icon	
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
    And I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '<Username>' have claim
    Then I should see the text '<QuotespageTitle>', '<QuotespageSubtitle>' in the Quotes landing page

	Examples: 
	| Scenario | Username       | Password | WindowWidth | WindowHeight | UserDropdown | QuotespageTitle | QuotespageSubtitle                                         |
	| S1       | testingtesting | Te$t1234 | 640         | 768          | ZZZ TEST     | Quote List      | Submitted rate requests within the past 30 days are shown. |

@Regression 	
Scenario Outline: 17434_Verify the Partial Truckload Tile view on the Shipment Services screen in rate request process_Mobile
			Given I am a DLS user and login into application with valid <Username> and <Password>
			And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
			And I am landing on DLS Worldwide homepage with RRD logo
			And I should not see the '<UserDropdown>'
	        And I click on the on hamburger menu icon
			When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
			And I Click on Submit Rate Request button
			And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
			Then user should be able to see <ServiceTile> service option in a tile view of the Shipment Services screen

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | ServicesPageHeader | ServiceTile       |
	| S1       | shpent   | Te$t1234 | 640         | 768          | ZZZ TEST     | Get Quote          | Partial Truckload |  

@Regression 
Scenario Outline: 17434_Verify Click functionality of Partial Truckload Tile_Mobile
	        Given I am a DLS user and login into application with valid <Username> and <Password>
			And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
			And I am landing on DLS Worldwide homepage with RRD logo
			And I should not see the '<UserDropdown>'			
	        And I click on the on hamburger menu icon
			When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
			And I Click on Submit Rate Request button
            And I Select the <Service> type from the shipment services screen
	        Then I should navigate to the shipment information screen and can able to see the '<RateRequestHeading>','<RateRequestSubheading>','<ShipmentInformation>' and '<BacktoQuoteList>'


	Examples: 
	| Scenario | Username | Password | Service           | WindowWidth | WindowHeight | UserDropdown | RateRequestHeading | RateRequestSubheading                     | ShipmentInformation  | BacktoQuoteList    |
	| S1       | shpent   | Te$t1234 | Partial Truckload | 640         | 768          | ZZZ TEST     | Rate Request       | Follow the steps below to receive a rate. | Shipment Information | Back to Quote List |  


