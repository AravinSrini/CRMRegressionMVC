@Sprint59 @17437
Feature: InternationalTileOnShipmentServiceScreenInRateRequestProcess_Mobile

@GUI @Functional
Scenario Outline: Verify that logged in user has access to the Quotes
	Given I am a DLS User and login into application with valid Username and Password
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	And I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '<Username>' have claim
	Then I should See the text '<QuotespageTitle>', '<QuotespageSubtitle>' in the quotes landing page

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | QuotespageTitle | QuotespageSubtitle                                         | SubmitRateRequestBtn |
	| S1       | zzzz     | Te$t1234 | 640         | 768          | ZZZZ TEST    | Quote List      | Submitted rate requests within the past 30 days are shown. | Submit Rate Request  |

@GUI @Functional
Scenario Outline: Verify that user can able to see the International Type model when click on the International Tile
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<GetQuotetext>' and should see '<BacktoQuoteListBtn>' button in the Quotes landing page
	And I must see the '<International>' tile in the Quotes landing page
	And I click on the International tile
	Then  I should see the International Type '<InternationalTypetext>' model

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | GetQuotetext | BacktoQuoteListBtn | International | InternationalTypetext |
	| S1       | zzzz     | Te$t1234 | 640         | 768          | ZZZZ TEST    | Get Quote    | Back to Quote List | International | International Type    |

@GUI @Functional
Scenario Outline: Verify that user can able to see Type Drop down and can able to select an option from Type drop down in the  International Type model
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<Quotestext>' and should see '<BacktoQuoteList>' button in the Quotes landing page
	And I click on the International tile
	Then I should see Type Drop down with '<defaulttext>'
	And I click on the Type drop down
	And I should able to select any option in the Type drop down list

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | Quotestext | BacktoQuoteList    | defaulttext    | 
	| S1       | zzzz     | Te$t1234 | 640         | 768          | ZZZZ TEST    | Get Quote  | Back to Quote List | Select Type... | 

@GUI @Functional
Scenario Outline: Verify that user can able to see Level Drop down and can able to select an option from Level drop down in the International Type model
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<GetQuotetext>' and should see '<BacktoQuoteListBtn>' button in the Quotes landing page
	And I click on the International tile
	And I click on the Type drop down
	And I should able to select any option in the Type drop down list
	Then I should see Level Drop down with '<defaulttext>'
	And I click on the Level drop down
	And I should able to select any option in the Level drop down list

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | GetQuotetext | BacktoQuoteListBtn | defaulttext     | 
	| S1       | zzzz     | Te$t1234 | 640         | 768          | ZZZZ TEST    | Get Quote    | Back to Quote List | Select Level... |

@GUI @Functional
Scenario Outline: Verify that user can able to see the Continue button and can able to click on the Continue button in the International Type model
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<GetQuotetext>' and should see '<BacktoQuoteListBtn>' button in the Quotes landing page
	And I click on the International tile
	Then I should see Continue button with '<defaulttext>'
	And Continue button should be in enabled
	And I click on the Continue button

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | GetQuotetext | BacktoQuoteListBtn | defaulttext  |
	| S1       | zzzz     | Te$t1234 | 640         | 768          | ZZZZ TEST    | Get Quote    | Back to Quote List | Continue     |

@GUI @Functional
Scenario Outline: Verify that user can able to see the Cancel button and International Type model should close by clicking on the Cancel button in the International Type model
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<GetQuotetext>' and should see '<BacktoQuoteListBtn>' button in the Quotes landing page
	And I click on the International tile
	Then I should see Cancel button with '<defaulttext>'
	And I click on the Cancel button
	And I should not see the International Type '<InternationalTypetext>' model
	And I should see the text '<Quotestext>' and should see '<BacktoQuoteList>' button in the Quotes landing page

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | GetQuotetext | BacktoQuoteListBtn | defaulttext | InternationalTypetext | Quotestext | BacktoQuoteList    |
	| S1       | zzzz     | Te$t1234 | 640         | 768          | ZZZZ TEST    | Get Quote    | Back to Quote List | Close       | International Type    | Get Quote  | Back to Quote List |

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the existing International shipping information screen when click the continue button with selection of valid Type & Level
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<GetQuotetext>' and should see '<BacktoQuoteListBtn>' button in the Quotes landing page
	And I click on the International tile
	Then I click on the Type drop down and select Type
	And I click on the Level drop down and select Level
	And I click on the Continue button
	And I should navigate to the shipment information screen and can able to see the '<RateRequestHeading>','<RateRequestSubheading>','<ShipmentInformation>' and '<BacktoQuoteList>'
	And I should able to see the '<ServiceType>' 

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | GetQuotetext | BacktoQuoteListBtn | RateRequestHeading | RateRequestSubheading                     | ShipmentInformation  | BacktoQuoteList    | ServiceType   |
	| S1       | zzzz     | Te$t1234 | 640         | 768          | ZZZZ TEST    | Get Quote    | Back to Quote List | Rate Request       | Follow the steps below to receive a rate. | Shipment Information | Back to Quote List | International |

@GUI @Functional
Scenario Outline: Verify that user can able to see the error message when click on Continue butoon without selecting any options in the International Type model
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page
	And I click on Submit Rate Request button in Quotes page
	And I should see the text '<GetQuotetext>' and should see '<BacktoQuoteListBtn>' button in the Quotes landing page
	And I click on the International tile
	Then I should see Continue button with '<defaulttext>'
	And I click on the Continue button
	And I should able to see the error '<Errormessage>' message

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | GetQuotetext | BacktoQuoteListBtn | defaulttext  | Errormessage                          |
	| S1       | zzzz     | Te$t1234 | 640         | 768          | ZZZZ TEST    | Get Quote    | Back to Quote List | Continue     | PLEASE ENTER ALL REQUIRED INFORMATION |