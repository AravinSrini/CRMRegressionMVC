@ShipmentListCopyLTLOption @26811 @Sprint68 
Feature: ShipmentList_CopyLTLOption_AllUsers

@GUI @Regression
Scenario: Verify the Copy icon of any shipment in shipment list grid for stationowner
	Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	Then I must see the copy icon of any displayed shipment in shipment list grid
	    
        
 @GUI @Regression
Scenario: Verify the Copy icon of any shipment in shipment list grid for crmOperation user
	Given I am a shp.entry, operations, sales, sales management or station user 
	When I click on the Shipment Icon
	And I arrive on shipment list page
	Then I must see the copy icon of any displayed shipment in shipment list grid
	    
 @GUI @Regression
Scenario: Verify the Copy icon of any shipment in shipment list grid for external users
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
	When I click on the Shipment Icon
	And I arrive on shipment list page of externaluser
	Then I must see the copy icon of any displayed shipment in shipment list grid
	   
      
@GUI 
Scenario Outline: Verify the click functionality for Copy icon of any shipment in shipment list grid 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on copy icon for any shipment 
	Then Verify the copy shipment on <confirmationmodel> of any displayed shipment
	And The model have the Cancel and Copy Shipment buttons

	  Examples: 
           | Scenario | Username              | Password | confirmationmodel                                           |
           | S1       | crmOperation@user.com | Te$t1234 | Copy the selected shipment and create a new shipment entry? |
           | S2       | zzzext                | Te$t1234 | Copy the selected shipment and create a new shipment entry? |
           | S3       | Stationown            | Te$t1234 | Copy the selected shipment and create a new shipment entry? |


@GUI @Regression
Scenario: Verify the click functionality for cancel button on confiramtion model for stationowners
	Given I  login into application as StationOwner
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on copy icon for any shipment 
	And I have click on cancel button 
	Then I must be arrive back on shipment list page 
	
		   
@Regression
Scenario: Verify the click functionality for cancel button on confiramtion model for Operations user
	Given I am a shp.entry, operations, sales, sales management or station user 
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on copy icon for any shipment 
	And I have click on cancel button 
	Then I must be arrive back on shipment list page 
	
@Regression
Scenario: Verify the click functionality for cancel button on confiramtion model for ext user
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
	When I click on the Shipment Icon
	And I arrive on shipment list page of externaluser
	And I click on copy icon for any shipment 
	And I have click on cancel button 
	Then I must be arrive back on shipment list page 
	      









