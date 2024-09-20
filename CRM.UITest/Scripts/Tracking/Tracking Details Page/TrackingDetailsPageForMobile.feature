
@18054 @TrackingDetailsPage @Sprint59

Feature: TrackingDetailsPageforMobile
	

@GUI 
Scenario Outline:Verify tracking details page in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will be able to see Tracking Deatils Page Header <TrackingTitleText>
Examples: 
| Scenario | Username | Password		 | TrackingNumber | TrackingTitleTex  |	 WindowWidth | WindowHeight |
|      S1  |  ZZZ     |   Te$t1234       |  ZZX00204203   |      Tracking     |     320      | 568       |


@GUI @Functional 
Scenario Outline:Verify an option New Search and its functionality in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will have option for creating a New  Search <NewSearchOption>,<App_Url>,<View>
Examples: 
| Scenario | Username | Password | TrackingNumber |  NewSearchOption | WindowWidth | WindowHeight | View				|
| S1       | ZZZ      | Te$t1234 | ZZX00204203    | New Search      | 320         | 568          | Applicationloggedin |




@GUI 
Scenario Outline:Verify columns present in tracking details grid in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And   I will be able to see  Reference and status column in grid <RefText>, <StatusText>
Examples: 
| Scenario | Username | Password | TrackingNumber |  RefText    | StatusText	   | WindowWidth | WindowHeight |
| S1       | ZZZ      | Te$t1234 | ZZX00204203    |  REF #      |    STATUS        |320			 | 568          |



@GUI 
Scenario Outline:Verify the absence of Export and Print button inside the tracking details page in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see export and print button
Examples: 
| Scenario | Username   | Password | TrackingNumber | WindowWidth       | WindowHeight | 
| S1       | ZZZ		| Te$t1234 | ZZX00204203    | 320				| 568          |

@GUI 
Scenario Outline:Verify the absence of Export button in the tracking details page in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see export button
Examples: 
| Scenario | Username   | Password | TrackingNumber | WindowWidth       | WindowHeight | 
| S1       | ZZZ		| Te$t1234 | ZZX00204203    | 320				| 568          |


@GUI 
Scenario Outline:Verify the absence of more information icon on tracking details page in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see more information icon
Examples: 
| Scenario | Username | Password		 | TrackingNumber            |  WindowWidth | WindowHeight |
| s1       | ZZZ      |   Te$t1234       |     ZZX00204203           |   320        | 568          |


@GUI 
Scenario Outline:Verify the absence of Filter By section  on tracking details page in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see Filter By section 
Examples: 
| Scenario | Username | Password		 | TrackingNumber            |  WindowWidth | WindowHeight |
| s1       | ZZZ      |   Te$t1234       |     ZZX00204203           |  320         | 568          |



@GUI 
Scenario Outline:Verify the absence of arrow button next to Search shipments text field in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see arrow button next to Search shipments text field
Examples: 
| Scenario | Username | Password		 | TrackingNumber            |  WindowWidth | WindowHeight |
| s1       | ZZZ      |   Te$t1234       |     ZZX00204203           |   320        | 568          |




@GUI 
Scenario Outline:Verify the presence of arrow button to expand for each shipment record in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And   I will be able to see Tracking Details Arrow button on shipment record 
Examples: 
| Scenario | Username | Password		 | TrackingNumber            |  WindowWidth | WindowHeight |
| s1       | ZZZ      |   Te$t1234       |     ZZX00204203           |  320         | 568          |




@GUI 
Scenario Outline:Verify search shipments option in tracking details page in mobile
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And   I will be able to see search shipment text box in tracking details page
Examples: 
| Scenario | Username | Password		 | TrackingNumber            |  WindowWidth | WindowHeight |
| s1       | ZZZ      |   Te$t1234       |     ZZX00204203           |   320        | 568          |



@Functional 
Scenario Outline:Verfiy search functionality in tracking details page in mobile device
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And   I am able to search any data through Search Textbox <SearchCriteria>,<TestData>
Examples: 
| Scenario | Username | Password | TrackingNumber					 |  WindowWidth | WindowHeight | SearchCriteria | TestData    |
| s1       | ZZZ      | Te$t1234 | 3358766320,ZZX00204203,ZZS11842   |  320         | 568		   | RefNumber		| ZZX00204203 |
| s1       | ZZZ      | Te$t1234 | 3358766320,ZZX00204203,ZZS11842   |  320         | 568          | Status		    | Delivered	  |
| s1       | ZZZ      | Te$t1234 | 3358766320,ZZX00204203,ZZS11842   |  320         | 568          | ETA			| 10/14/2014  |
| s1       | ZZZ      | Te$t1234 | 3358766320,ZZX00204203,ZZS11842   |  320         | 568          | Service		| LTL		  |
| s1       | ZZZ      | Te$t1234 | 3358766320,ZZX00204203,ZZS11842   |  320         | 568          | Destination	| PARIS	      |
| s1       | ZZZ      | Te$t1234 | 3358766320,ZZX00204203,ZZS11842   |  320         | 568          | Origin			| WINTER 	  |
| s1       | ZZZ      | Te$t1234 | 3358766320,ZZX00204203,ZZS11842   |  320         | 568          | Location		| IL 		  |


@Functional 
Scenario Outline:Verfiy expand by default functionality for one tracking number in mobile
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And   I clicked on Tracking Module from hamburger menu icon
When   I have entered valid tracking numbers in track by reference number text box and click on search arrow button<TrackingNumber>
Then  I have arrived on the tracking details page
And   Expandable details will be expanded by default<MapHeader>
Examples: 
| Scenario | Username | Password | TrackingNumber |  WindowWidth | WindowHeight | MapHeader |
| s1       | ZZZ      | Te$t1234 | ZZX00204203    |  320         | 568          |    Map       |

@GUI  
Scenario Outline:Verify tracking details page in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will be able to see Tracking Deatils Page Header <TrackingTitleText>
Examples: 
| Scenario |  TrackingNumber | TrackingTitleTex  |	 WindowWidth | WindowHeight |
|      S1  |   ZZX00204203   |      Tracking     |        320    | 568          |

@GUI @Functional 
Scenario Outline:Verify an option New Search and its functionality in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will have option for creating a New  Search <NewSearchOption>,<App_Url>,<View>
Examples: 
| Scenario | TrackingNumber |  NewSearchOption | WindowWidth | WindowHeight | View					|
| S1       | ZZX00204203    |  New Search      | 320         | 568          | ApplicationNotloggedin|

@GUI 
Scenario Outline:Verify columns present in tracking details grid in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And   I will be able to see  Reference and status column in grid <RefText>, <StatusText>
Examples: 
| Scenario |  TrackingNumber |  RefText    | StatusText	   | WindowWidth | WindowHeight |
| S1       |  ZZX00204203    |  REF #      |    STATUS        |320			 | 568          |



@GUI 
Scenario Outline:Verify the absence of Export and Print button inside the tracking details page in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see export and print button
Examples: 
| Scenario | TrackingNumber | WindowWidth       | WindowHeight | 
| S1       | ZZX00204203    | 320				| 568          |

@GUI 
Scenario Outline:Verify the absence of Export button in the tracking details page in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see export button
Examples: 
| Scenario |  TrackingNumber | WindowWidth       | WindowHeight | 
| S1       |  ZZX00204203    | 320				 | 568          |

@GUI 
Scenario Outline:Verify the absence of more information icon on tracking details page in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see more information icon
Examples: 
| Scenario |  TrackingNumber            | WindowWidth | WindowHeight |
| s1       |      ZZX00204203           |   320       | 568          |


@GUI 
Scenario Outline:Verify the absence of Filter By section  on tracking details page in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see Filter By section 
Examples: 
| Scenario | TrackingNumber            |  WindowWidth | WindowHeight |
| s1       |      ZZX00204203          |   320        | 568          |



@GUI 
Scenario Outline: Verify the absence of arrow button next to Search shipments text field in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And  I will not be able to see arrow button next to Search shipments text field
Examples: 
| Scenario |  TrackingNumber            |  WindowWidth | WindowHeight |
| s1       |     ZZX00204203            |   320        | 568          |




@GUI 
Scenario Outline:Verify the presence of arrow button to expand for each shipment record in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And   I will be able to see Tracking Details Arrow button on shipment record 
Examples: 
| Scenario |  TrackingNumber								|  WindowWidth | WindowHeight |
| s1       |     3358766320,ZZX00204203,ZZS11842            |  320         | 568          |




@GUI 
Scenario Outline:Verify search shipments option in tracking details page in mobile without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And   I will be able to see search shipment text box in tracking details page
Examples: 
| Scenario |  TrackingNumber            |  WindowWidth | WindowHeight |
| s1       |      ZZX00204203           |   320        | 568          |



@Functional 
Scenario Outline:Verify search functionality in tracking details page in mobile device without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And   I am able to search any data through Search Textbox <SearchCriteria>,<TestData>
Examples: 
| Scenario |  TrackingNumber					 |  WindowWidth | WindowHeight | SearchCriteria | TestData    |
| s1       | 3358766320,ZZX00204203,ZZS11842     |  320         | 568		   | RefNumber		| ZZX00204203 |
| s1       |  3358766320,ZZX00204203,ZZS11842    |  320         | 568          | Status		    | Delivered	  |
| s1       |  3358766320,ZZX00204203,ZZS11842    |  320         | 568          | ETA			| 10/14/2014  |
| s1       |  3358766320,ZZX00204203,ZZS11842    |  320         | 568          | Service		| LTL		  |
| s1       |  3358766320,ZZX00204203,ZZS11842    |  320         | 568          | Destination	| PARIS	      |
| s1       |  3358766320,ZZX00204203,ZZS11842    |  320         | 568          | Origin			| WINTER 	  |
| s1       |  3358766320,ZZX00204203,ZZS11842    |  320         | 568          | Location		| IL 		  |


@Functional
Scenario Outline:Verify expand by default functionality for one tracking number in mobile without logging in to the Application
Given I am a DLS user and launch crm url
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When   I have entered valid tracking numbers in login page<TrackingNumber>
Then  I have arrived on the tracking details page
And   Expandable details will be expanded by default<MapHeader>
Examples: 
| Scenario |  TrackingNumber |  WindowWidth | WindowHeight | MapHeader	   |
| s1       |  ZZX00204203    |  320         | 568          |    Map        |


