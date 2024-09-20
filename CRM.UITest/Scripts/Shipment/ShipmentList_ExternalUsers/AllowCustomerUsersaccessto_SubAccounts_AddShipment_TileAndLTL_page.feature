@AllowCustomerUsersAccessToSubAccounts_AddShipment_Tile_and_LTL_Page @32276 @Sprint79 
Feature: AllowCustomerUsersaccessto_SubAccounts_AddShipment_TileAndLTL_page


@GUI @Functional
Scenario Outline: 32276_Verify the Click functionality of Add Shipment Button when user selected any sub account of MG or Both type
	   Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	   And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
       When I click on the Add Shipment Button
       Then I will arrive on the Add Shipment Tile Page
       And I will only see the LTL Service Type Option

	 Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |
				
@GUI @Functional
Scenario Outline: 32276_Verify the Click functionality of the LTL Option on the Add Shipment Page when user selected any sub account of MG or Both type
	   	Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
		And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
		And I am on the service selection tiles page
		When I click on the LTL option on the tiles page
		Then I will arrive on the Add Shipment LTL page

     Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |
				
@GUI @Functional 
Scenario: 32276_Verify the Primary Account Customer Name Displayed on the Add Shipment LTL Page when user selected primary account of MG or Both type
        Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
		And I selected any Primary Account from the customer drop down list on the shipment list page
		When I will arrive on the Add Shipment LTL page
		Then I will see the Primary Account customer name displayed on the Add Shipment LTL page

				
@GUI @Functional
Scenario Outline: 32276_Verify the Sub Account Customer Name Displayed on the Add Shipment LTL Page when user selected any sub account of MG or Both type
	    Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
		And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
		When I am on the Add Shipment LTL page
		Then I will see the Sub Account customer name displayed on the Add Shipment LTL page

      Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |


@GUI @Functional @API
Scenario Outline: 32276_Verify the Previous Selected Customer in Drop down and Shipment List for associated customer previous 30 days of MG or Both type	
		Given I am a shp.entry,shp.inquiry,shp.entrynorates or shp.inquirynorates user associated to a primary account that has sub accounts
		And I have selected a <Customer> with <TMS_Type> on the Shipment List page and navigated away from shipment list page
		When I return to the Shipment List page
	    Then The customer previously selected will be selected in the customer drop down list
		And The shipment list will display any shipments associated to the customer for the previous Thirty days

		Examples: 
		| Customer               | TMS_Type |
		| 36691 scenario1 subacc | both     |
	
@GUI @Functional @API
Scenario Outline: 32276_Verify the Previous Selected Customer in Drop down and Quote list for associated customer Previous 30 days of MG or Both type
		Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
		And I have selected a <Customer> with <TMS_Type>on the Shipment List page
		When I arrive on the Quote List page
		Then The customer selected on the Shipment List page will be pre_selected
		And The Quote List will display any shipments associated to the customer for the previous Thirty days

		Examples: 
		| Customer               | TMS_Type |
		| 36691 scenario1 subacc | both     |



				
				


