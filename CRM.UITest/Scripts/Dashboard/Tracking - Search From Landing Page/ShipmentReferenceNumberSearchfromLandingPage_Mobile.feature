@TrackingShipmentReferenceNumberSearchformCRMMVCLandingPage @18391 @Sprint60
Feature: Tracking_ShipmentReferenceNumberSearchfromLandingPage_Mobile
	
@Functional
Scenario Outline: Test to verify the error message when user not entered Reference Number
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When I have not entered the '<EnterReferenceNumberText>' values in the search box
And I click on Search arrow
Then I see the '<Errormsg>' message in the pop up 

Examples: 
| Scenario | WindowWidth | WindowHeight | EnterReferenceNumberText | Errormsg                       |
| s1       | 768         | 640          |                          | Please enter tracking numbers. |

@Acceptance@Functional
Scenario Outline: Test to verify the Reference Number Search by entering one valid Reference Number
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I click on Search arrow
Then I navigate to '<Tracking>' Details page
And I see the results for the entered single reference number in mobile device '<Refno>' 

Examples: 
| Scenario | WindowWidth | WindowHeight | EnterReferenceNumberText | Tracking | Refno       |
| s1       | 768         | 640          | PIT01172271              | Tracking | PIT01172271 |

@Acceptance@Functional
Scenario Outline: Test to verify the Reference Number Search by entering more than one valid Reference Number
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I click on Search arrow
Then I navigate to '<Tracking>' Details page
And I see the results for the entered reference numbers in mobile device '<Ref>'

Examples: 
| Scenario | WindowWidth | WindowHeight | EnterReferenceNumberText                    | Tracking | Ref                                         |
| s1       | 768         | 640          | 9900003,9900002,9900001,PIT01172238,9919838 | Tracking | 9900003,9900002,9900001,PIT01172238,9919838 |

@Functional
Scenario Outline: Test to verify the Error message for entering one invalid Reference Numbers
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When I pass the '<EnterReferenceNumberText>' values in the search box
And I click on Search arrow
Then I can see the '<Errormsg_invalid>' message in the pop up for entering invalid numbers
And I click on close button in the pop up
And I should be displayed with Tracking search

Examples: 
| Scenario | WindowWidth | WindowHeight | EnterReferenceNumberText | Errormsg_invalid                               |
| s1       | 768         | 640          | 3453534535               | No data found for entered reference number(s). |

@Functional
Scenario Outline: Test to verify the Error message for entering more than one invalid Reference Numbers
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When I pass the '<EnterReferenceNumberText>' values in the search box
And I click on Search arrow
Then I can see the '<Errormsg_invalid>' message in the pop up for entering invalid numbers
And I click on close button in the pop up
And I should be displayed with Tracking search

Examples: 
| Scenario | WindowWidth | WindowHeight | EnterReferenceNumberText                     | Errormsg_invalid                               |
| s1       | 768         | 640          | 5.35345E+20,3.34535E+14,345354535,3453534535 | No data found for entered reference number(s). |

@Functional@Regression
Scenario Outline:Tracking with the combination of both valid and invalid Reference Numbers 
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When I enter the '<EnterReferenceNumberText>' values in the search box
And I click on Search arrow
Then I should be displayed with the '<warningmsg>' message in the pop up 
And Pop up displays all the list of tracking numbers that not exist '<EnterReferenceNumberText>'
And I clicked on close button in the warning pop up
And I navigate to '<Tracking>' Details page
And I see the results for the entered reference numbers in mobile device '<Ref>'

Examples: 
| WindowWidth | WindowHeight | EnterReferenceNumberText                                                         | Tracking | warningmsg                                                         | Ref                                 | 
| 768         | 640          | MKE30128897,PIT01172270,PIT01172271,5.35345E+20,3.34535E+14,345354535,3453534535 | Tracking | Tracking details were not found for the following tracking numbers | MKE30128897,PIT01172270,PIT01172271 | 

@Functional
Scenario Outline: Test to verify the Reference Number Search by entering more than 10 valid Reference Numbers
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I verify the entered tracking numbers searchbox
Then I should be able to enter only ten tracking reference numbers '<EnterReferenceNumberText>'

Examples: 
| Scenario | WindowWidth | WindowHeight | EnterReferenceNumberText                                                                                       |
| s1       | 768         | 640          | 123456789,MKE30128897,PIT01172270,PIT01172271,AWG005017348,9900003,9900002,9900001,PIT01172238,9919838,9919837 |                        

@Functional@Acceptance
Scenario Outline: Test to verify the Navigation menu for Tracking without login 
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I click on Search arrow
Then I navigate to '<Tracking>' Details page
And I see the results for the entered single reference number '<Refno>'
And  I click on the on hamburger menu icon in the mobile device
And Navigation menu have only Tracking icon on left wizard
And I should not display with any other icons on left wizard

Examples: 
| Scenario | WindowWidth | WindowHeight | EnterReferenceNumberText | Tracking | Refno       |
| s1       | 768         | 640          | PIT01172271              | Tracking | PIT01172271 |

@Functional
Scenario Outline: Test to verify file upload area is hidden
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I Re-size the browser to mobile device '<WindowWidth>' and '<WindowHeight>'
Then I should not be displayed with Upload Button in landing page <Upload>

Examples: 
| Scenario | WindowWidth | WindowHeight | Upload |
| s1       | 768         | 640          |        |