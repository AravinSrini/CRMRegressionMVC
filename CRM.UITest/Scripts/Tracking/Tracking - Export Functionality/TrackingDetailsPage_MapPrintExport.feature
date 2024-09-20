@18400 @TrackingDetailsPage_MapPrintExport @Sprint59

Feature: TrackingDetailsPage_MapPrintExport
	

@GUI@Functional @Fixed
Scenario Outline: Verify 'Tracking Details' button functionality which is replaced with down arrow
Given I am a DLS user and login into application with valid Username and Password
When  I Click on the Tracking icon in the navigation menu
And I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then the expandable details will be expanded by default <MapHeader>,<TrackingDetils_Header>
Examples: 
| ValidReferenceNumber | MapHeader | TrackingDetils_Header | 
|3358766320            | Map       |Tracking Details       |


@GUI @Fixed
Scenario Outline: Verify Map section within extended section
Given I am a DLS user and login into application with valid Username and Password
When  I Click on the Tracking icon in the navigation menu
And I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then shipment details should be expanded <MapHeader>
Examples: 
| ValidReferenceNumber | MapHeader | 
| 3358766320           | Map       | 

@GUI @Fixed
Scenario Outline: Verify Tracking details section within extended section
Given I am a DLS user and login into application with valid Username and Password
When  I Click on the Tracking icon in the navigation menu
And I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then Shipment details should be expanded with tracking detail section <TrackingDetailsText>
Examples: 
| ValidReferenceNumber | TrackingDetailsText |
| 3358766320           | Tracking Details    |

@GUI @Fixed
Scenario Outline: Verify all headers present in Tracking details section 
Given I am a DLS user and login into application with valid Username and Password
When  I Click on the Tracking icon in the navigation menu
And I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then I will be able to see three columns <DateHeader>,<DetailsHeader>,<LocationHeader>
Examples: 
| ValidReferenceNumber | DateHeader | DetailsHeader | LocationHeader | 
| 3358766320           | DATE       | DETAILS       | LOCATION       |


@GUI @Fixed
Scenario Outline: Verify Print button within expanded section
Given I am a DLS user and login into application with valid Username and Password
When  I Click on the Tracking icon in the navigation menu
And I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then I will be able to see Print option
Examples: 
| ValidReferenceNumber |
| 3358766320           |

@Functional @Fixed
Scenario Outline: Verify Tracking details excel file with UI
Given I am a DLS user and login into application with valid Username and Password
When  I Click on the Tracking icon in the navigation menu
And I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
#And   I will click on down arrow button 
Then I will be able to see Export button
And   it will download the tracking details in a .xls file named TrackingDetails.xls <TrackingDetailsfilename>
Examples: 
| ValidReferenceNumber |TrackingDetailsfilename |
| 3358766320           |TrackingDetails.xls     |               