@AllowCustomerUsersAccessToSub_Accounts_Shipment_List_GridDisplay @32277 @Sprint79 
Feature: AllowCustomerUsersaccesstoSub_Accounts_Shipment_List_GridDisplay


@API 
Scenario: 32277_Verify Shipment list grid shows shipments for past 30 days when user selected All Customer of MG or Both type
	  Given I am a shp.entry,shp.inquiry,shp.entrynorates or shp.inquirynorates user associated to a primary account that has sub accounts
	  When I select All Customers from the customer drop down list on shipment list page
	  Then The Shipment List grid will refresh to display the shipments associated to the primary account and sub_accounts for the past Thirty days 

	 
@GUI
Scenario: 32277_Verify the all buttons are hidden when user selected All Customer of MG or Both type
	  Given I am a shp.entry,shp.inquiry,shp.entrynorates or shp.inquirynorates user associated to a primary account that has sub accounts
	  When I select All Customers from the customer drop down list on shipment list page
	  Then The Add Shipment button will be hidden
	  And The Copy Shipment button will be hidden
	  And The Create Return Shipment button will be hidden

	  
@GUI @API
Scenario: 32277_Verify the Add Shipment button and shows shipment for past 30 days when user selected Primary Customer of MG or Both type
	  Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	  When I select the Primary Account Name from the customer drop down list
	  Then The Add Shipment button will be visible
      And The shipment list will refresh to display the shipments associated to the primary account for the past Thirty days
	  
@GUI @Functional
Scenario: 32277_Verify Add Shipments tile navigation when user selected Primary Customer of MG or Both type
	 Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	 And I selected the Primary Account Name from the customer drop down list on shipment list page
	 When I click on the Add Shipment Button
     Then I will arrive on the Add Shipment tile page
     And I will see all of the service type selections that I am associated to

@GUI @API
Scenario Outline: 32277_Verify the Add Shipment button and shows shipment for past 30 days when user selected Sub Account of MG or Both type
	 Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	 When I select any <Sub_Account> Name of <TMS_Type> from the customer drop down list on shipment list page
	 Then The Add Shipment button will be visible
     And The shipment list will refresh to display the shipments associated to the sub account selected for the past Thirty days
	
     Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |

@GUI
Scenario Outline: 32277_Verify the Copy and Return shipment button when user selected Sub Account of MG or Both type 
	Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	When I select any <Sub_Account> Name of <TMS_Type> from the customer drop down list on shipment list page
	Then I will see any shipment with the Copy Shipment button and Return shipment button 

     Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |
