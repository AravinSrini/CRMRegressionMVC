@Sprint59 @17435 
Feature: IntermodaltileOnShipmentServiceScreenInRateRequestProcess_Desktop

@Regression 
Scenario Outline: Verify that logged in user has access to the Quotes
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	And I am able to see the '<UserDropdown>'
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	And I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '<Username>' have claim
	Then I should see the text '<QuotespageTitle>', '<QuotespageSubtitle>' in the Quotes landing page

	Examples: 
	| Scenario | Username       | Password | UserDropdown    | QuotespageTitle | QuotespageSubtitle                                         |
	| S1       | testingtesting | Te$t1234 | Testing Testing | Quote List      | Submitted rate requests within the past 30 days are shown. |

@Regression 
Scenario Outline: Verify that user navigated to the existing Intermodal shipment information screen
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	And I am able to see the '<UserDropdown>'
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<GetQuotetext>', '<BacktoQuoteListBtn>' button in the Quotes landing page
	And I must see the Intermodel '<Intermodel>' tile in the Quotes landing page
	And  I click on the Intermodel tile
	Then I should navigate to the shipment information screen and can able to see the '<RateRequestHeading>','<RateRequestSubheading>','<ShipmentInformation>' and '<BacktoQuoteList>'
	And I should able to see the '<ServiceType>'

	Examples: 
	| Scenario | Username | Password | UserDropdown | GetQuotetext | BacktoQuoteListBtn | RateRequestHeading | RateRequestSubheading                     | ShipmentInformation  | BacktoQuoteList    | ServiceType |
	| S1       | shpent   | Te$t1234 | Shp Ent      | Get Quote    | Back to Quote List | Rate Request       | Follow the steps below to receive a rate. | Shipment Information | Back to Quote List | Intermodal  |
