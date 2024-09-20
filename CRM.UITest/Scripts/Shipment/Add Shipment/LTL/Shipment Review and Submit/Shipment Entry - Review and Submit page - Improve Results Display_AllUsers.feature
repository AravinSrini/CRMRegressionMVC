@Sprint79 @32146 @Acceptance @GUI @Ignore

Feature: Shipment Entry - Review and Submit page - Improve Results Display_AllUsers
	

Scenario:32146-Verify carrier info section on review and submit page - External user
Given I am a  shp.entry, operations, sales, sales management, or station owner user
And I am creating an LTL shipment, 
When I arrive on the Review and Submit (LTL) page
Then The carrier logos will be displayed in carrier info section on Review and Submit page
And The carrier name will be displayed in carrier info section on Review and Submit page
And The carrier legal liability verbiage will read: Carrier's legal liability per lb if uninsured 
And carrier max liability verbiage will read: Carrier's max liability if uninsured 
And The currency values and formatting associated to New and Used will be consistent 
And The service days will display days text in service days column
And The verbiage <Direct to Destination> will be displayed as <Direct>
And The verbiage <Indirect to Destination> will be displayed as <Indirect>
And The Distance value will be displayed as a whole number <536 miles>