@TrackingShipmentReferenceNumberSearchformCRMMVCLandingPage @18391 @Sprint60
Feature: Tracking_ShipmentReferenceNumberSearchfromLandingPage_Desktop
	
@Functional
Scenario Outline: Test to verify the error message when user not entered Reference Number
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I have not entered the '<EnterReferenceNumberText>' values in the search box
And I click on Search arrow
Then I see the '<Errormsg>' message in the pop up 

Examples: 
| Scenario | EnterReferenceNumberText | Errormsg                       |
| s1       |                          | Please enter tracking numbers. |

@Acceptance@Functional
Scenario Outline: Test to verify the Reference Number Search by entering one valid Reference Number
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I click on Search arrow
Then I navigate to '<Tracking>' Details page
And I see the results for the entered single reference number '<Refno>'

Examples: 
| Scenario | EnterReferenceNumberText | Tracking | Refno   |
| s1       | 9919838                  | Tracking | 9919838 |

@Acceptance@Functional
Scenario Outline: Test to verify the Reference Number Search by entering more than one valid Reference Numbers
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I click on Search arrow
Then I navigate to '<Tracking>' Details page
And I see the results for the entered reference numbers '<Ref>'

Examples: 
| Scenario | EnterReferenceNumberText                                                                               | Tracking | Ref                                                                                                    |
| s1       | 123456789,MKE30128897,PIT01172270,PIT01172271,AWG005017348,9900003,9900002,9900001,PIT01172238,9919838 | Tracking | 123456789,MKE30128897,PIT01172270,PIT01172271,AWG005017348,9900003,9900002,9900001,PIT01172238,9919838 |

@Functional
Scenario Outline: Test to verify the Reference Number Search by entering one invalid Reference Number
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I click on Search arrow
Then I can see the '<Errormsg_invalid>' message in the pop up for entering invalid numbers
And I click on close button in the pop up
And I should be displayed with Tracking search

Examples: 
| Scenario | EnterReferenceNumberText | Tracking | Errormsg_invalid                               |
| s1       | 3453534535               | Tracking | No data found for entered reference number(s). |

@Functional
Scenario Outline: Test to verify the Reference Number Search by entering more than one invalid Reference Number
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I pass the '<EnterReferenceNumberText>' values in the search box
And I click on Search arrow
Then I can see the '<Errormsg_invalid>' message in the pop up for entering invalid numbers
And I click on close button in the pop up
And I should be displayed with Tracking search

Examples: 
| Scenario | EnterReferenceNumberText                     | Errormsg_invalid                               |
| s1       | 5.35345E+20,3.34535E+14,345354535,3453534535 | No data found for entered reference number(s). |

@Functional@Regression
Scenario Outline:Verify the Tracking with the combination of both valid and invalid Reference Numbers 
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I enter the '<EnterReferenceNumberText>' values in the search box
And I click on Search arrow
Then I should be displayed with the '<warningmsg>' message in the pop up 
And Pop up displays all the list of tracking numbers that not exist '<EnterReferenceNumberText>'
And I clicked on close button in the warning pop up
And I navigate to '<Tracking>' Details page
And I see list of Tracking Results based on the entered valid numbers '<Ref>'

Examples: 
| EnterReferenceNumberText                                                         | warningmsg                                                         | Ref                                 | Tracking |
| MKE30128897,PIT01172270,PIT01172271,5.35345E+20,3.34535E+14,345354535,3453534535 | Tracking details were not found for the following tracking numbers | MKE30128897,PIT01172270,PIT01172271 | Tracking |

@Functional
Scenario Outline: Test to verify the Reference Number Search by entering more than 10 valid Reference Numbers
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I verify the entered tracking numbers searchbox
Then I should be able to enter only ten tracking reference numbers '<EnterReferenceNumberText>'

Examples: 
| Scenario | EnterReferenceNumberText                                                                                       |
| s1       | 123456789,MKE30128897,PIT01172270,PIT01172271,AWG005017348,9900003,9900002,9900001,PIT01172238,9919838,9919837 |

@Functional@Acceptance@EndtoEnd
Scenario Outline: Test to verify the Tracking icon in the navigation menu without login 
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
And I enter the tracking numbers '<EnterReferenceNumberText>'
When I click on Search arrow
Then I navigate to '<Tracking>' Details page
And I see the results for the entered reference numbers '<Ref>'
And Navigation menu have only Tracking icon on left wizard
And I should not display with any other icons on left wizard

Examples: 
| Scenario | EnterReferenceNumberText | Tracking | Ref         |
| s1       | PIT01172271              | Tracking | PIT01172271 |

@Functional
Scenario Outline: Test to verify the Error message of Upload Tracking button Functionality when user not having any tracking numbers in the uploaded file
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I click on upload button from homepage
And I have attached the template using "<path>"
And I click on submit button from landing page
Then I should be displayed with the "<Errormsg>" 

Examples: 
| Scenario | Errormsg                                                                                    | path                                     |
| s1       | Uploaded file does not contain any tracking numbers. Enter tracking number and upload file. | \Emptyfile\ShipmentTrackingTemplate.xlsx |

@Acceptance@Functional
Scenario Outline: Test to verify the Upload Tracking button Functionality when user having valid reference numbers in the uploaded file
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I click on upload button from homepage
And I have attached the template using "<path>"
And I click on submit button from landing page
Then I should navigate to tracking details screen for uploadedfile
And Ishould be able to see the results of tracking numbers for '<path>'

Examples: 
| Scenario | Tracking | path                                                                                                   |
| s1       | Tracking | ..\\..\\Scripts\\TestData\\Testfiles_trackingupload\\Allvalidreferences\\ShipmentTrackingTemplate.xlsx |

@Acceptance@Functional
Scenario Outline: Test to verify the Upload Tracking button Functionality when user having invalid reference numbers in the uploaded file
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I click on upload button from homepage
And I have attached the template using "<path>"
And I click on submit button from landing page
Then Ishould bedisplaying with '<errormsgforallinvalid>' popup for all invaliddata

Examples: 
| Scenario | path                                               | errormsgforallinvalid                          |
| s1       | \Allinvalidrefernces\ShipmentTrackingTemplate.xlsx | No data found for entered reference number(s). |

@Functional@Regression
Scenario Outline:Upload Tracking button Functionality when user having combination of both valid and invalid reference numbers in the uploaded file
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I click on upload button from homepage
And I have attached the template using "<path>"
And I click on submit button from landing page
Then I should be displayed with '<warningmessage>' for invalid tracking numbers and results for valid refrences "<path>" from homepage upload

Examples: 
| Scenario | path                                                                                                            | warningmessage                                                     |
| s1       | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Combinationofvalidandinvalid\\ShipmentTrackingTemplate.xlsx | Tracking details were not found for the following tracking numbers |

@Functional
Scenario Outline: Test to verify the upload functionality by entering more than 25 refence numbers in the template
Given I enter the url for CRM
And I am landing on DLS Worldwide homepage with RRD logo
When I click on upload button from homepage
And I have attached the template using "<path>"
And I click on submit button from landing page
Then I should be displayed with the error poup for more than maximum "<messageformaxnumbers>"
 
Examples: 
| Scenario | path                                                                                                   | messageformaxnumbers                                 |
| s1       | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Morethan25refernces\\ShipmentTrackingTemplate.xlsx | This file exceeds the maximum of 25 tracking numbers |
