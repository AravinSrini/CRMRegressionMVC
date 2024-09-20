@PartialTruckloadShipmentInformationPageMobile @17434 @Sprint59
Feature: Partial Truckload tile on Shipment Service screen in rate request process_Desktop

@Regression 
Scenario Outline: 17434_Verify that logged in user has access to the Quotes
	Given I am a DLS user with Customer dropdown and login into application
	And I am landing on DLS Worldwide homepage with RRD logo    
	And I am able to see the '<UserDropdown>' in the Dashboard page
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
    When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    Then I should see the text '<QuotespageTitle>', '<QuotespageSubtitle>' in the Quotes landing page

	Examples: 
	| Scenario | Username       | Password | UserDropdown    | QuotespageTitle | QuotespageSubtitle                                         |
	| S1       | testingtesting | Te$t1234 | Testing Testing | Quote List      | Submitted rate requests within the past 30 days are shown. |


@Regression 
Scenario Outline: 17434_Verify the Partial Tile view on the Shipment Services screen in rate request process
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo    
	And I am able to see the '<UserDropdown>' in the Dashboard page
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim		
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
    Then user should be able to see <ServiceTile> service option in a tile view of the Shipment Services screen


	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | ServiceTile       |
	| S1       | shpent   | Te$t1234 | Shp Ent      | Get Quote          | Partial Truckload |  
	

@Regression 
Scenario Outline: 17434_Verify Click functionality of Partial Truckload Tile
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo    
	And I am able to see the '<UserDropdown>' in the Dashboard page
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim	
    When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
    And I Select the <Service> type from the shipment services screen 
	Then User should be navigated to the Old Partial Truckload Shipment Information Page and able to see '<RateRequestPageHeader>' , '<RateRequestSubHeadingText>'	and '<BacktoQuoteList>'
	
	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | Service           | RateRequestPageHeader | RateRequestSubHeadingText                 | BacktoQuoteList    |
	| S1       | shpent   | Te$t1234 | Shp Ent      | Get Quote          | Partial Truckload | Rate Request          | Follow the steps below to receive a rate. | Back to Quote List |  
	

@Regression 
Scenario Outline: 17434_Verify page Header of Old Partial Truckload Shipment information screen for Desktop view
			Given I am a DLS user and login into application with valid <Username> and <Password>
			And I am landing on DLS Worldwide homepage with RRD logo    
			And I am able to see the '<UserDropdown>' in the Dashboard page
			When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
			When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
			And I Click on Submit Rate Request button
			And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
			And I Select the <Service> type from the shipment services screen
			Then User should be navigated to the Old Partial Truckload Shipment Information section header as <SectionHeader> with service as <Service> 

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader | SectionHeader        | Service           |
	| S1       | shpent   | Te$t1234 | Shp Ent      | Get Quote          | Shipment Information | Partial Truckload |  


@Regression 
Scenario Outline: 17434_Verify user is able to see the Back to Quote List button is visible in Shipment Services page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo    
	And I am able to see the '<UserDropdown>' in the Dashboard page
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim	
	When I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page
    And I Click on Submit Rate Request button
    And user should be navigated to the Shipment Services Screen in the rate request process <ServicesPageHeader>
    Then user should be able to see the Back to Quote List button

	Examples: 
	| Scenario | Username | Password | UserDropdown | ServicesPageHeader |
	| S1       | shpent   | Te$t1234 | Shp Ent      | Get Quote          |  