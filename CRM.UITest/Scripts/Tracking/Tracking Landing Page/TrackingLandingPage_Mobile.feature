@Sprint60 @18027 @TrackingLandingPage
Feature: TrackingLandingPage_Mobile
	
@GUI @Functional
Scenario Outline: Verify that logged in user can able to navigate to the new MVC5 Tracking Page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	Then  I must navigate to the Tracking page and must see '<Title>', and not see '<SubTitle>'

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | Title    | SubTitle                                             |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     | Tracking | Find tracking information for one or more shipments. |

@GUI 
Scenario Outline: Verify the Tracking landing page for correctness
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	Then I must navigate to the Tracking page and must see '<Title>', and not see '<SubTitle>'
	And  I must see the Track shipments By Number section '<ReferenceNumberHeading>', '<ReferenceNumbersDescription>' and '<Searchtextbox>' and search arrow button
	And I must not see the '<DownloadBtn>' and '<UploadBtn>'

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | Title    | SubTitle                                             | ReferenceNumberHeading    | ReferenceNumbersDescription                                                                                                                                                                             | Searchtextbox                  | DownloadBtn       | UploadBtn |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     | Tracking | Find tracking information for one or more shipments. | TRACK BY REFERENCE NUMBER | Enter up to 10 Reference Numbers into the field below. The following types are acceptable: Bill of Lading, Purchase Order or PRO Number. All references must be comma separated and are case sensitive. | Enter Reference Number(s) here | Download Template | Upload    |

@GUI @Functional
Scenario Outline: Verify the error message when user not entered Reference Number
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	And I click on the search button in the Tracking page
	Then I must see the '<errormessage>' in the Error pop up

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | errormessage                   |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     | Please enter tracking numbers. | 

@GUI @Functional 
Scenario Outline: Verify that results is expanded in Tracking Details page when user search by one valid tracking number
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	When I enter the '<ValidReferenceNumber>' in the search box
	And I click on the search button in the Tracking page
	Then I must see the Information is expanded by default when only one shipment is tracked in '<TrackingDetails>' section in mobile
	And I must see the '<NewSearch>' button in the top right corner
	And I must see the '<SearchShipments>' button below to the Title description and also must not see the '<Export>' button
	And I must see the Tracking Details Grid with headers '<REF>', '<STATUS>', and nust not see '<ETA>', '<LOCATION>', '<ORIGIN>', '<DESTINATION>' and '<SERVICE>'
	And I must see the '<ValidReferenceNumber>' below to the REF number column

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | ValidReferenceNumber | TrackingDetails  | NewSearch  | SearchShipments     | Export | REF   | STATUS | ETA | LOCATION | ORIGIN | DESTINATION | SERVICE |
	| S1       | zzzz     | Te$t1234 | 360         | 640          | ZZZZ TEST    | 9919837              | Tracking Details | New Search | Search shipments... | Export | REF # | STATUS | ETA | LOCATION | ORIGIN | DESTINATION | SERVICE |

@GUI @Functional @Regression
Scenario Outline: Verify the Tracking Details page when user search by 2 to 10 valid tracking numbers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	And I enter the multi'<MultipleValidReferenceNumbers>' in the search box
	And I click on the search button in the Tracking page
	Then I must navigate to the Tracking Details page and must see '<Title>', and not see'<SubTitle>'
	And I must see the '<NewSearch>' button in the top right corner
	And I must see the '<SearchShipments>' button below to the Title description and also must not see the '<Export>' button
	And I must not see the filter by time and filter by status headers below to the search shipments button
	And I must not see the pagination header in the Tracking Details page
	And I must see the Tracking Details Grid with headers '<REF>', '<STATUS>', and nust not see '<ETA>', '<LOCATION>', '<ORIGIN>', '<DESTINATION>' and '<SERVICE>'
	And I must not see the pagination footer in the Tracking Details page
	And I must see all the tracking numbers '<MultipleValidReferenceNumbers>' in the Grid
	And I must not see information icon and must see expand icon for each reference number

	Examples: 
	| Username | Password | WindowWidth | WindowHeight | UserDropdown | MultipleValidReferenceNumbers                   | Title    | SubTitle                                                   | NewSearch  | SearchShipments     | Export | REF   | STATUS | ETA | LOCATION | ORIGIN | DESTINATION | SERVICE |
	 | zzz      |  | 360         | 640          | ZZZ TEST     | MKE30128897,PIT01172270,PIT01172271,ZZX00204206 | Tracking | The tracking information you requested is displayed below. | New Search | Search shipments... | Export | REF # | STATUS | ETA | LOCATION | ORIGIN | DESTINATION | SERVICE |
@GUI @Functional @Regression
Scenario Outline: Verify the Tracking Details page when user search by 2 to 10 valid tracking numbers when logged in as zzzzUser
	Given I log in to the application as user zzzz
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	And I enter the multi'<MultipleValidReferenceNumbers>' in the search box
	And I click on the search button in the Tracking page
	Then I must navigate to the Tracking Details page and must see '<Title>', and not see'<SubTitle>'
	And I must see the '<NewSearch>' button in the top right corner
	And I must see the '<SearchShipments>' button below to the Title description and also must not see the '<Export>' button
	And I must not see the filter by time and filter by status headers below to the search shipments button
	And I must not see the pagination header in the Tracking Details page
	And I must see the Tracking Details Grid with headers '<REF>', '<STATUS>', and nust not see '<ETA>', '<LOCATION>', '<ORIGIN>', '<DESTINATION>' and '<SERVICE>'
	And I must not see the pagination footer in the Tracking Details page
	And I must see all the tracking numbers '<MultipleValidReferenceNumbers>' in the Grid
	And I must not see information icon and must see expand icon for each reference number

	Examples: 
	| Username | Password | WindowWidth | WindowHeight | UserDropdown | MultipleValidReferenceNumbers                   | Title    | SubTitle                                                   | NewSearch  | SearchShipments     | Export | REF   | STATUS | ETA | LOCATION | ORIGIN | DESTINATION | SERVICE |
	| zzzz     |  | 360         | 640          | ZZZ TEST     | 9919837,9919838                                 | Tracking | The tracking information you requested is displayed below. | New Search | Search shipments... | Export | REF # | STATUS | ETA | LOCATION | ORIGIN | DESTINATION | SERVICE |
	
@Functional @Acceptance
Scenario Outline: Verify the user cannot enter more than 10 valid tracking numbers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	And I enter the more than ten'<MorethanTenReferenceNumbers>' in the search box 
	Then I must see the only '<nine>' commas in search field of Tracking Laning page 

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | MorethanTenReferenceNumbers | nine |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     | ,,,,,,,,,,,,,,              | 9    |

@Functional
Scenario Outline: Verify the error message pop up when user search by multiple invalid tracking numbers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	And I enter invalid '<MultipleInvalidTrackingNumbers>' in the search field 
	And I click on the search button in the Tracking page
	Then I must see the '<errormessage>' saying No data found for entered reference numbers 

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | MultipleInvalidTrackingNumbers     | errormessage                                   |
	| S1       | zzz      | Te$t1234 | 360         | 640          | ZZZ TEST     | 43676476                           | No data found for entered reference number(s). |
	| S1       | zzz      | Te$t1234 | 360         | 640          | ZZZ TEST     | 73676746,43676476,76547647,6746746 | No data found for entered reference number(s). |

@Functional
Scenario Outline: Verify the Tracking Details page when user search by Invalid and Valid tracking numbers
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I Click on the Tracking icon in the navigation menu
	And I enter valid and invalid tracking numbers '<ValidandInvalidReferenceNumbers>' in the search field 
	And I click on the search button in the Tracking page
	Then I must navigate to the Tracking Details page and must see '<Title>', and not see'<SubTitle>'
	And I must see the '<warningmessage>' saying Tracking details were not found for the following tracking numbers
	And I must see the list of all the tracking numbers that do not exist in the pop up '<ValidandInvalidReferenceNumbers>'
	And I click on close button in the warning pop up 
	And I must not see the pagination header in the Tracking Details page
	And I must see the Tracking Details Grid with headers '<REF>', '<STATUS>', and nust not see '<ETA>', '<LOCATION>', '<ORIGIN>', '<DESTINATION>' and '<SERVICE>'
	And I must not see the pagination footer in the Tracking Details page
	And I must see all the valid tracking numbers '<ValidandInvalidReferenceNumbers>' in the Grid
	And I must not see information icon and must see expand icon for each reference number
	
	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | ValidandInvalidReferenceNumbers                    | Title    | SubTitle                                                   | warningmessage                                                     | Export | REF   | STATUS | ETA | LOCATION | ORIGIN | DESTINATION | SERVICE |
	| S1       | zzzz     | Te$t1234 | 360         | 640          | ZZZZ TEST    | 73676746,43676476,76547647,6746746,9919837,9919838 | Tracking | The tracking information you requested is displayed below. | Tracking details were not found for the following tracking numbers | Export | REF # | STATUS | ETA | LOCATION | ORIGIN | DESTINATION | SERVICE |

