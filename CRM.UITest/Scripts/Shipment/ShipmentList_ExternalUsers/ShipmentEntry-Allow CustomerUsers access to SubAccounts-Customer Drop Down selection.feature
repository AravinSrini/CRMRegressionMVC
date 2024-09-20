@Sprint79 @32275
Feature: ShipmentEntry-Allow CustomerUsers access to SubAccounts-Customer Drop Down selection
	

@GUI
Scenario: 32275_Verify the customer drop down selection option on the Shipment List page
          Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates users 
		  When I arrive on the Shipment List page associated to a primary account that has sub accounts
		  Then the grid should be empty and display the following - Please select a customer to view Shipments
		  And the customer drop down will be set to Select... 
	 

@GUI
Scenario: 32275_Verify the options in the customer drop down on the shipment list page
          Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates users 
		  When I arrive on the Shipment List page associated to a primary account that has sub accounts
		  Then the Customer drop down list will be displayed with options Select, All Customers, primary account and mapped subaccounts
		  And ADD Shipment button will be hidden

@GUI
Scenario: 32275_Verify the hierarchy format of the customers in the drop down on the shipment list page

          Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates users 
		  And I arrive on the Shipment List page associated to a primary account that has sub accounts
		  When I click on the Customer drop down list
		  Then the customers will be displayed in hierarchy format
		  And Sub accounts associated to primary account are displayed in alphabetical order



		   
