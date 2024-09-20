@ShipmentEntry_AllowCustomerUsers_AccessToSub_Account_CopyAndReturn @32278 @Sprint79 
Feature: ShipmentEntry_AllowCustomerUsers_AccessToSub_Accounts_CopyAndReturn


@GUI @Functional 
Scenario Outline: 32278_Verify the click functionality of Copy shipment button when user selected any sub account of MG or Both type
	 Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	 And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
	 When I click on the Copy Shipment button of any displayed LTL shipment
     Then The Copy shipment model will Display 

	 Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |


@GUI @Functional 
Scenario Outline: 32278_Verify the click functionality on Cancel button of Copy shipment model when user selected sub account of MG or Both type
	 Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
     And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
     When I click on the Cancel button of the Copy Shipment modal
     Then The Copy Shipment modal will close
	  
	 Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |


@GUI @Functional @API @DBVerification
Scenario Outline: 32278_Verify the Customer Name and auto populated data on Add Shipment LTL page when user selected sub account of MG or Both type 
	 Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	 And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
	 When I click on the Copy Shipment button of the Copy Shipment modal
     Then I will arrive on the Add Shipment LTL page
     And The customer name will be displayed on the page
	 And The shipment details of the original shipment will be auto_populated on the Add Shipment LTL page
	  
	 Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |
	 
	 
@GUI @Functional
Scenario Outline: 32278_Verify the click functionality of Return Shipment Button when user selected any sub account of MG or Both type
	 Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	 And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
     When I click on the Return Shipment button of any displayed LTL shipment
	 Then The Return Shipment Modal will displayed

	 Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |

@GUI @Functional
Scenario Outline: 32278_Verify the click functionality of No button of the Create return shipment when user selected any sub account of MG or Both type
	 Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	 And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
     When I click on the No button of the Create Return Shipment modal
     Then The Create Return Shipment modal will close

	 Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |



@GUI @Functional @API @DBVerification
Scenario Outline: 32278_Verify the Customer Name is displayed on Add shipment LTL page and return functionality when user selected any sub account of MG or Both type
	 Given I am a shp.entry or shp.entrynorates user associated to a primary account that has sub accounts
	 And I selected any <Sub_Account> Name of <TMS_Type> from the customer drop down list on the shipment list page
     When I click on the Yes button of the Create Return Shipment modal
     Then I will arrive on the Add Shipment LTL page
     And The customer name will be displayed on the page
	 And Shipping To original shipment will be displayed in the Shipping From Location and Shipping From Contact information section
	 And Shipping From original shipment will be displayed in the Shipping To Location and Shipping To Contact information section
	 And The Pickup Date will be defaulted to the current date
     And The Freight Description information of the original shipment will be auto populated
     And The Reference Numbers of the original shipment will be auto populated
	 And The Special Instructions field will be auto-populated when Special Instructions have be associated to the sub_account
     And The Accessorials from the original shipment will not be applied to the Return shipment
     And The shipment value from the original shipment will not be applied to the Return shipment

	 Examples: 
	 | Sub_Account            | TMS_Type |
	 | 36691 scenario1 subacc | both     |



