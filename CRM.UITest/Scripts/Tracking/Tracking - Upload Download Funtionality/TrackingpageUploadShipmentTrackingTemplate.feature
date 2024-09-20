@Sprint60 @TrackingDetailsPage-uploadFunctionality @18388
Feature: TrackingpageUploadShipmentTrackingTemplate

@GUI
Scenario Outline: test to verify the Track Multiple Shipments by File Upload area fields in desktop
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
Then I will be displayed with Track Multiple Shipments by File Upload area with the all fields

Examples: 
| Username | Password | trackingpage   |
| zzz      | Te$t1234 |Tracking        |

@GUI
Scenario Outline: test to verify the Track Multiple Shipments by File Upload area fields in mobile
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
When I will be navigated to "<trackingpage>"
Then I should not be displayed with Track Multiple Shipments by File Upload area with the all fields 

Examples: 
| Username | Password | trackingpage | WindowWidth  | WindowHeight  |
| zzz      | Te$t1234 | Tracking      |  768         |  640          |
| zzz      | Te$t1234 | Tracking      |  768         |  992          |
| zzz      | Te$t1234 | Tracking      |  992         |  1200         |

@Functional
Scenario Outline: test to verify the upload button functionality for tracking page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button 
Then I should display with the upload shipments modal

Examples: 
| Username | Password | trackingpage   |
| zzz      | Te$t1234 | Tracking       |

@GUI
Scenario Outline: test to verify the fields on upload modal for tracking page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button 
Then I should display with the upload shipments modal
And I should be displayed "Upload Shipments" <header>
And I should be displayed "Select an Excel file to track up to 25 shipments" <subheader> 
And I should be display with label no file Selected "<label>"
And I should be displayed with option to select file
And I should have option to cancel
And I should have option to submit

Examples: 
| Username | Password | trackingpage | header             | subheader                                       | label             |
| zzz      | Te$t1234 | Tracking       | Upload Shipments | Select an Excel file to track up to 25 shipments| no file selected  |

@Functional
Scenario Outline: test to verify the cancel button functionality on upload modal for tracking page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button 
And I displayed with upload modal
And I click on cancel button
Then upload modal should be closed

Examples: 
| Username | Password | trackingpage   |
| zzz      | Te$t1234 | Tracking       |

@GUI
Scenario Outline: test to verify the upload button functionality when no files added on upload modal for tracking page
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<tracking page>"
And I click on upload button 
And I displayed with upload modal
And I click on submit button
Then I should be displayed with "PLEASE SELECT THE FILE" <errormessage>
 
Examples: 
| Username | Password | tracking page  | errormessage           |
| zzz      | Te$t1234 | Tracking       | PLEASE SELECT THE FILE |


@Functional 
Scenario Outline: test to verify the upload functionality 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button
And I attached the template from "<path>"
Then I should be able to upload the document

 
Examples: 
| Username | Password | trackingpage | path                                                                                                   |
| zzz      | Te$t1234 | Tracking     | ..\\..\\Scripts\\TestData\\Testfiles_trackingupload\\Allvalidreferences\\ShipmentTrackingTemplate.xlsx |

@Acceptance @Functional @Regression @UploadTest
Scenario Outline: test to verify the upload functionality with valid tracking numbers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then I should navigate to tracking details screen
And I should see the results of tracking numbers for '<uploadedfilepath>'


Examples: 
| Username       | Password | trackingpage | path                                                                                                   | errormessage | uploadedfilepath                                                                                       |
| crmSystemAdmin | Te$t1234 | Tracking     | ..\\..\\Scripts\\TestData\\Testfiles_trackingupload\\Allvalidreferences\\ShipmentTrackingTemplate.xlsx |              | ..\\..\\Scripts\\TestData\\Testfiles_trackingupload\\Allvalidreferences\\ShipmentTrackingTemplate.xlsx |

@Acceptance 
Scenario Outline: test to verify the upload functionality with invalid file name
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then I should be display with "<errorforinvalidname>" invalidinput message popup

Examples: 
| Username | Password | trackingpage | path                                                                                      | errorforinvalidname |
| zzz      | Te$t1234 | Tracking     | ..\\..\\Scripts\\TestData\\Testfiles_trackingupload\\Invalidfilename\\TrackingDetails.xls | Invalid input file. |

@Acceptance 
Scenario Outline: Test to verify the upload functionality with invalid extension
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then I should be display with "<errorforinvalidname>" invalidinput message popup
 
Examples: 
| Username | Password | trackingpage | path                                                                           | errorforinvalidname |
| zzz      | Te$t1234 | Tracking     | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Invalidextension\\test.PNG | Invalid input file. |

@Acceptance 
Scenario Outline: Test to verify the upload functionality with more than 25 refence numbers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then I should display with the error poup for more than maximum "<messageformax>"
 
Examples: 
| Username | Password | trackingpage | path                                                                                                   | messageformax                                        |
| zzz      | Te$t1234 | Tracking     | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Morethan25refernces\\ShipmentTrackingTemplate.xlsx | This file exceeds the maximum of 25 tracking numbers |

@Acceptance
Scenario Outline: test to verify the upload functionality with empty file
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then I should be able to see the "<errormessage>" saying there are no tracking numbers


Examples: 
| Username | Password | trackingpage | path                                                                                         | errormessage                                                                                |
| zzz      | Te$t1234 | Tracking     | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Emptyfile\\ShipmentTrackingTemplate.xlsx | Uploaded file does not contain any tracking numbers. Enter tracking number and upload file. |


@functional
Scenario Outline: test to verify the upload functionality with invalid and valid tracking numbers
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then I should be displayed with '<errormessage>' for invalid tracking numbers and results for valid refrences "<path>"
 
 
Examples: 
| Username | Password | trackingpage | path                                                                                                            | errormessage                                                       |
| zzz      | Te$t1234 | Tracking     | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Combinationofvalidandinvalid\\ShipmentTrackingTemplate.xlsx | Tracking details were not found for the following tracking numbers |


@Functional
Scenario Outline: test to verify the upload functionality with invalid tracking numbers template
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on tracking module
When I will be navigated to "<trackingpage>"
And I click on upload button
And I attached the template from "<path>"
And I click on submit button
Then I should display with '<errorforallinvalid>' popup for all invaliddata

Examples: 
| Username | Password | trackingpage | path                                                                                                   | errorforallinvalid                             |
| zzz      | Te$t1234 | Tracking     | ..\\..\\Scripts\TestData\\Testfiles_trackingupload\\Allinvalidrefernces\\ShipmentTrackingTemplate.xlsx | No data found for entered reference number(s). |








