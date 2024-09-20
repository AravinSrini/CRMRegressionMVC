@Sprint59 @17431 @BuildLandingPage
Feature: BuildLandingPage

@GUI 
Scenario Outline: Verify that DLS Worldwide text and Sign In button in the homepage
	Given I enter the url for CRM
	When I am landing on the signin page homepage with DLS Worldwide logo
	And I must see the '<DLSWorldwidetext>' in the logo
	Then I must see the Sign In button must appear on the top right corner with the text '<SignIn>'

	Examples: 
	| Scenario | DLSWorldwidetext   | SignIn  |
	| S1       | DLS Worldwide      | Sign In |

@GUI
Scenario Outline: Verify that body text is visible and truck Image is loaded in the middle of the homepage
	Given I enter the url for CRM
	When I am landing on the signin page homepage with DLS Worldwide logo
	Then I must see the '<bodytext>' 
	And Truck image should loaded middle of the homepage

	Examples: 
	| Scenario | DLSWorldwidetext | bodytext                                            | 
	| S1       | DLS Worldwide    | Please sign in above or track your shipments below. | 

@GUI @Functional @104746
Scenario Outline: Verify that Track Up To 10 Shipments By Reference Number text and Enter Reference Number Search box
	Given I enter the url for CRM
	When I am landing on the signin page homepage with DLS Worldwide logo
	Then I must see the Track info by Reference number heading '<TrackUpTo10ShipmentsByReferenceNumbertext>'  
	And I must see the Track info by Reference number paragraph '<Paragraphtext>'
	And I must see the search box button with text '<EnterReferenceNumbertext>' 
	And I must able to enter '<ValidReferenceNumber>' into the search box and able to click the search button
	And User  able to navigate to the '<Tracking>' module

	Examples: 
	| Scenario | DLSWorldwidetext | TrackUpTo10ShipmentsByReferenceNumbertext    | Paragraphtext                                                                                                                                                                                           | EnterReferenceNumbertext       | ValidReferenceNumber | Tracking |
	| S1       | DLS Worldwide    | Perform an additional search. Enter up to 10 comma separated reference numbers – case sensitive. | Perform an additional search. Enter up to 10 comma separated reference numbers – case sensitive. | Enter Reference Number(s) Here  | 9919838              | Tracking |

@GUI @Functional
Scenario Outline: Verify that Track Multiple Shipments by File Upload text, Download Template button and Upload buttons
	Given I enter the url for CRM
	When I am landing on the signin page homepage with DLS Worldwide logo
	Then I must see the Track info by shipments by file upload heading '< TrackMultipleShipmentsbyFileUploadtext>'
	And I must see the Track info by shipments by file upload paragraph '<Paragraphtext>'
	And I must see the '<DownloadTemplate>' button and able to click the DownloadTemplate button
	And I must see the '<Upload>' button and able to click the Upload button

	Examples:
	| Scenario | DLSWorldwidetext | TrackMultipleShipmentsbyFileUploadtext  | Paragraphtext                                                                                                                                                                                     | DownloadTemplate | Upload |
	| S1       | DLS Worldwide    | Track Multiple Shipments by File Upload | To track up to 25 shipments, click the Upload button below. Excel is the only acceptable file type. If you have never uploaded a file before, you must first download and use the template below. | Download Template | Upload |

@GUI 
Scenario Outline: Verify that Footer of the homepage
	Given I enter the url for CRM
	When I am landing on the signin page homepage with DLS Worldwide logo
	Then I must see the RRD logo in the footer of the homepage
	And I must see PrivacyPolicy '<PrivacyPolicy>' link in the footer of the homepage
	And I must see TemsofUse '<TemsofUse>' link in the footer of the homepage
	And I must see RRDInformation in the footer of the homepage

	Examples: 
	| Scenario | PrivacyPolicy  | TemsofUse    |                                                                                                                                              
	| S1       | PRIVACY POLICY | TERMS OF USE |

@GUI @Functional
Scenario Outline: Verify that user can able to see the error message when enters invalid  or unfound reference number
	Given I enter the url for CRM
	When I must see the search box button with text '<EnterReferenceNumbertext>' 
	And I enter '<InvalidReferenceNumber>' into the search box and able to click the search button
	Then I must see the '<errormessage>' saying no data found for reference number
	And I click on the close button in the error pop up

	Examples: 
	| Scenario | EnterReferenceNumbertext       | InvalidReferenceNumber | Tracking | errormessage                                   |
	| S1       | Enter Reference Number(s) here | ghgfg                  | Tracking | No data found for entered reference number(s). |

@GUI @Functional @Regression 
Scenario Outline:  Verify that user is able to export the download shipment tracking template file by clicking on the Download Template Button
	Given I enter the url for CRM
	And I am landing on the signin homepage with DLS Worldwide logo
	When I click the Download Template button in the homepage
	Then The file must be Downloaded with '<ShipmentTrackingTemplatefilename>' and open the sheet with the name '<Sheetname>' and also with '<alldata>'

	Examples: 
	| ShipmentTrackingTemplatefilename | Sheetname        | alldata                                                                                                                                                                                                                              |
	| ShipmentTrackingTemplate.xlsx    | Tracking Details | Shipment Tracking Template;The following types are acceptable: Bill of Lading, PO Number or PRO Number.;One entry per row required. No comma separated entries;Note: Maximum of 25 Tracking Numbers can be tracked;Tracking  Numbers |

@GUI  
Scenario Outline: Verify that user can able to see the 'Upload Shipments' modal with options to Select File, Cancel and Submit
	Given I enter the url for CRM
	And I am landing on the signin homepage with DLS Worldwide logo
	When I click on the Upload button in the homepage
	Then I can able to see the '<UploadShipmentsTitle>' and '<subtitle>' in the modal
	And Upload Shipment modal should have the option to select a file '<SelectFile>' button and '<Cancel>', '<Submit>' buttons
	
	Examples:
	| Scenario | UploadShipmentsTitle | subtitle                                         | SelectFile  | Cancel | Submit |
	| S1       | Upload Shipments     | Select an Excel file to track up to 25 shipments | SELECT FILE | Cancel | Submit |

@GUI @Functional 
Scenario Outline: Verify that user can able to select a file through file explorer in Upload Shipments modal
	Given I enter the url for CRM
	And I am landing on the signin homepage with DLS Worldwide logo
	When I click on the Upload button in the homepage
	And I can able to see the '<UploadShipments>' modal 
	#And I click select file button in the Upload Shipment modal
	Then User can able to select a valid file through file explorer
	And User can able to see the selected '<filename>' name in the Upload Shipments modal

	Examples: 
	| Scenario | UploadShipments  | filename                      |
	| S1       | Upload Shipments | ShipmentTrackingTemplate.xlsx |

@GUI @Functional 
Scenario Outline: Verify that user can able to close the Upload Shipments modal by clicking on the Cancel button
	Given I enter the url for CRM
	And I am landing on the signin homepage with DLS Worldwide logo
	When I click on the Upload button in the homepage
	And I can able to see the '<UploadShipments>' modal
	And I click the Cancel button in the Upload Shipment modal
	Then User should not able to see the '<UploadShipments>'modal 
	And I must see the '<Upload>' button and able to click the Upload button

	Examples:
	| Scenario | UploadShipments  | Upload | 
	| S1       | Upload Shipments | Upload | 

@GUI @Functional 
Scenario Outline: Verify that user can able to see the error message by clicking on the submit button with out selecting any file
	Given I enter the url for CRM
	And I am landing on the signin homepage with DLS Worldwide logo
	When I click on the Upload button in the homepage
	And I can able to see the '<UploadShipments>' modal
	And I click on the Submit button in the Upload Shipment modal
	Then I must see the '<errormessage>' in the Upload Shipment modal

	Examples:
	| Scenario | UploadShipments  | errormessage           | 
	| S1       | Upload Shipments | PLEASE SELECT THE FILE | 

@GUI @Functional 
Scenario Outline: Verify that user can able to see the invalid input file error message by clicking on the submit button if invalid file name selected
	Given I enter the url for CRM
	And I am landing on the signin homepage with DLS Worldwide logo
	When I click on the Upload button in the homepage
	And I can able to see the '<UploadShipments>' modal
	#And I click select file button in the Upload Shipment modal
	And User select a Invalid file through file explorer
	And  I click on the Submit button in the Upload Shipment modal
	Then User must see the invalid input file pop up '<popuptitle>', '<invalidinputerrormessage>', '<Close>' button

	Examples:
	| Scenario | UploadShipments  | popuptitle | invalidinputerrormessage | Close |
	| S1       | Upload Shipments | Error      | Invalid input file.      | Close |








