@18387 @Sprint60 @DownloadShipmentTrackingTemplate
Feature: DownloadShipmentTrackingTemplate_Desktop
	
@GUI
Scenario Outline: Verify that user can able to see the Download template button in the Tracking landing page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	And I am able to see the '<UserDropdown>'
	When I Click on the Tracking icon in the navigation menu
	Then I must see the Download template button '<DownloadBtn>'

	Examples:
	| Scenario | Username | Password | UserDropdown | DownloadBtn       |
	| S1       | zzz      | Te$t1234 | ZZZ TEST     | Download Template |

@GUI @Functional @Regression 
Scenario Outline:  Verify that user can able to export the download shipment tracking template file by clicking on the Download Template Button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	And I am able to see the '<UserDropdown>'
	When I Click on the Tracking icon in the navigation menu
	And I click the Download Template button in the tracking landing page
	Then The file must be Downloaded with '<ShipmentTrackingTemplatefilename>' and open the sheet with the name '<Sheetname>' and also with '<alldata>'

	Examples: 
	| Username | Password | UserDropdown | ShipmentTrackingTemplatefilename | Sheetname        | alldata                                                                                                                                                                                                                              |
	| zzz      |  | ZZZ TEST     | ShipmentTrackingTemplate.xlsx    | Tracking Details | Shipment Tracking Template;The following types are acceptable: Bill of Lading, PO Number or PRO Number.;One entry per row required. No comma separated entries;Note: Maximum of 25 Tracking Numbers can be tracked;Tracking  Numbers |