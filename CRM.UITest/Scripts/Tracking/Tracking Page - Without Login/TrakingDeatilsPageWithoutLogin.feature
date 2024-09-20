@18054 @TrackingDetailsPageWithoutLogin @Sprint59

Feature: TrackingDetailsPageWithoutLogin
	
@GUI
Scenario Outline:Verify tracking details page without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
Then  I will be able to see A title of Tracking with a description <TrackingTitleText> and <TrackingDescriptionText>
Examples: 
| Scenario | ValidReferenceNumber  | Username                    | Password    |  TrackingTitleText | TrackingDescriptionText                                    |
| S1       | 3358766320            | shipentry@gmail.com         |Te$t1234     | Tracking           | The tracking information you requested is displayed below. |


@GUI
Scenario Outline:Verify an export button on tracking details page without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
Then  I will be able to see An option to export the search results<ExportButton>
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password | ExportButton |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 | Export       |

@GUI
Scenario Outline:Verify columns present in tracking details grid without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I will be able to see  <Ref#Text>, <StatusText>, <ETAText>, <LocationText>, <OriginText>, <DestinationText>, <ServiceText> within tracking details grid
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password | Ref#Text | StatusText | ETAText | LocationText | OriginText | DestinationText | ServiceText |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 | REF #    | STATUS     | ETA     | LOCATION     | ORIGIN     | DESTINATION     | SERVICE     |


@GUI
Scenario Outline:Verify 'Tracking Details' button on each shipment record without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I will be able to see 'Tracking Details' button on each shipment record 
Examples: 
| Scenario | ValidReferenceNumber                              | Username            | Password |
| S1       | 3358766320,PIT01172238,9900003,9900004            | shipentry@gmail.com | Te$t1234 |

##Pass valid reference no always


@GUI
Scenario Outline:Verify search shipments option in tracking details page without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I will be able to see search shipment text box in tracking details page
Examples: 
| Scenario | ValidReferenceNumber  | Username            | Password |
| S1       | 3358766320            | shipentry@gmail.com | Te$t1234 |

#An option to filter the search results based on
@GUI
Scenario Outline:Verify available options to filter the tracking details results without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I will be able to see different avaiable options to filter the tracing details <FilterByText>,<ScheduleToDeliver>,<BetweenText>,<StartDateText>,<AndText>,<EndDateText>,<OntimeCheckBoxOption>,<Exception/delaysOption>
Examples: 
| Scenario | ValidReferenceNumber  | Username            | Password | FilterByText | ScheduleToDeliver    | BetweenText | StartDateText | AndText | EndDateText | OntimeCheckBoxOption | Exception/delaysOption |
| S1       | 3358766320            | shipentry@gmail.com | Te$t1234 | FILTER BY :  | SCHEDULED TO DELIVER | BETWEEN :   | START DATE    | AND :   | END DATE    | ON TIME              | Exceptions/Delays      |


@GUI
Scenario Outline:Verify the search options present under the search dropdown without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I have clicked on arrow in the search bar
And   I can see different avaiable search checkboxes <select_all>,<reference_number>,<status>,<eta>,<location>,<service>,<origin>,<destination>,<carrier>,<scheduled_pickup>,<scheduled_delivery>,<clear_all>
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password | select_all | reference_number | status | eta | location | service | origin | destination | carrier | scheduled_pickup | scheduled_delivery | clear_all  |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 | Select All | REFERENCE NUMBER | STATUS | ETA | LOCATION | SERVICE | ORIGIN | DESTINATION | CARRIER | SCHEDULED PICKUP | SCHEDULED DELIVERY | Clear All  |                                                                                                                                                                                 

@GUI
Scenario Outline:Verfiy default selected check boxes as search option without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I have clicked on arrow in the search bar
And   Check box <reference_number>,<status>,<eta>,<location>,<service>,<origin>,<destination><carrier>,<scheduled_pickup>,<scheduled_delivery> should be selected by default
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password |reference_number  | status | eta | location | service | origin | destination | carrier | scheduled_pickup | scheduled_delivery |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 |REFERENCE NUMBER  | STATUS | ETA | LOCATION | SERVICE | ORIGIN | DESTINATION | CARRIER | SCHEDULED PICKUP | SCHEDULED DELIVERY |

@GUI@Functional
Scenario Outline:Verfiy Select all and Clear all check box functionality without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I have clicked on arrow in the search bar
And   I have clikced on clear all check box <reference_number>,<status>,<eta>,<location>,<service>,<origin>,<destination>,<carrier>,<scheduled_pickup>,<scheduled_delivery>
And   I have clicked on select all check box <reference_number>,<status>,<eta>,<location>,<service>,<origin>,<destination>,<carrier>,<scheduled_pickup>,<scheduled_delivery>
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password | reference_number | status | eta | location | service | origin | destination | carrier | scheduled_pickup | scheduled_delivery |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 | REFERENCE NUMBER | STATUS | ETA | LOCATION | SERVICE | ORIGIN | DESTINATION | CARRIER | SCHEDULED PICKUP | SCHEDULED DELIVERY |

@Functional
Scenario Outline:Verfiy search functionality in tracking details page without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I have clicked on arrow in the search bar
And   I will be able to filer tracking details by entering different availabe option <search_option>,<data>
Examples: 
| Scenario | ValidReferenceNumber  | Username            | Password | search_option     | data        |
| S1       | PIT01172238,3358766320| shipentry@gmail.com | Te$t1234 | CARRIER           | 	Averitt Express | 

@Functional
Scenario Outline:Verfiy fields are displayed within information details modal without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I have clicked on more informaation icon for any availabe record
And   I will be able to see field within information modal <Pro_Number>,<PO>,<Ship_Reference>,<Scheduled_Pickup>,<Scheduled_Delivery>,<Quantity>,<Weight>,<Carrier>
Examples: 
| Scenario | ValidReferenceNumber  | Username            | Password | Pro_Number | PO | Ship_Reference | Scheduled_Pickup | Scheduled_Delivery | Quantity | Weight | Carrier |
| S1       | 3358766320            | shipentry@gmail.com | Te$t1234 | Pro Number | PO | Ship Reference | Scheduled Pickup | Scheduled Delivery | Quantity | Weight | Carrier |


@Functional
Scenario Outline:Verfiy expand by default functionality for one tracking number without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   the expandable details will be expanded by default <MapHeader>,<TrackingDetils_Header>
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password | MapHeader | TrackingDetils_Header |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 | Map       | Tracking Details      |


@Functional@GUI
Scenario Outline: Verify the right navigation icon
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And   I click on the search button
Then  I have arrived on the tracking details page
Then  Vefiy right navigation icon visibility 
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 |

@Functional@GUI
Scenario Outline: Verify the left navigation icon without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And   I click on the search button
Then  I have arrived on the tracking details page
Then  Vefiy left navigation icon visibility 
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 |



@Functional@Ignore
Scenario Outline:Verfiy result grid when none checbox is checked within search option without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
And   I have clicked on arrow in the search bar
And   I have uncheck all checboxes and try to search results <data>
Examples: 
| Scenario | ValidReferenceNumber  | Username            | Password | search_option     | data       |
| S1       | PIT01172238,3358766320| shipentry@gmail.com | Te$t1234 | CARRIER           | Averitt Express | 



@GUI@Functional
Scenario Outline:Verify tracking details page without login into the Application
Given I am a DLS user and launch crm url
When   I enter the '<ValidReferenceNumber>' in the search box
And   I click on the search button
Then  I have arrived on the tracking details page
Examples: 
| Scenario | ValidReferenceNumber | 
| S1       | 3358766320           | 

@GUI@Functional
Scenario Outline:Verify an option New Search and its functionality without login
Given I am a DLS user and launch crm url
When I enter the '<ValidReferenceNumber>' in the search box
And I click on the search button
Then  I have arrived on the tracking details page
Then  Verify New  Search and its functionality <App_Url>,<NewSearchOption>
Examples: 
| Scenario | ValidReferenceNumber | Username            | Password | TrackingTitleText | NewSearchOption |
| S1       | 3358766320           | shipentry@gmail.com | Te$t1234 | Tracking          | New Search      |

