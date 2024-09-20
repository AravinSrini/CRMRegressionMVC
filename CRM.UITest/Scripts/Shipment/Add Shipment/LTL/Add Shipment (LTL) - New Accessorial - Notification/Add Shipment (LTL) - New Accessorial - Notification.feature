@44479 @Sprint83
Feature: Add Shipment (LTL) - New Accessorial - Notification
	
@GUI
Scenario: 44479_Verify new accessorial 'Notification' displayed under Shipping From section of Add Shipment LTL
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I am on the Add Shipment (LTL) page	
	When I click on add services and accessorials drop down of Shipping From section
	Then I will display with new accessorial type NOTIFICATION in Shipping From Section
	And NOTIFICATION accessorial will be displayed in alphabetically in Shipping From Section

@GUI
Scenario: 44479_Verify new accessorial 'Notification' displayed under Shipping To section of Add Shipment LTL
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I am on the Add Shipment (LTL) page	
	When I click on add services and accessorials drop down of Shipping To section
	Then I will display with new accessorial type NOTIFICATION in Shipping To Section
	And NOTIFICATION accessorial will be displayed in alphabetically in Shipping To Section

@GUI
Scenario: 44479_Verify CRM send NTFY to MG and MG returning NOT to CRM when user click on View Rates button and select Notification in Shipping From section of Add Shipment LTL
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user	
	And I selected new accessorial Notification in Shipping From section of Add Shipment (LTL) page
	When I Click on View Rates button 
	Then CRM will send the accessorial service NTFY to MG, it will return carrier charges that include the Accessorial Code NOT to CRM

@GUI
Scenario: 44479_Verify CRM send NTFY to MG and MG returning NOT to CRM when user click on View Rates button and select Notification in Shipping To section of Add Shipment LTL
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user	
	And I selected new accessorial Notification in Shipping To section of Add Shipment (LTL) page
	When I Click on View Rates button 
	Then CRM will send the accessorial service NTFY to MG, it will return carrier charges that include the Accessorial Code NOT to CRM	

@GUI
Scenario: 44479_Verify CRM send NTFY to MG and MG returning NOT to CRM when user click on View Rates button and select Notification in both Shipping From and To sections
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user	
	And I selected new accessorial Notification in Shipping From and To sections of Add Shipment (LTL) page
	When I Click on View Rates button 
	Then CRM will send the accessorial service NTFY to MG, it will return carrier charges that include the Accessorial Code NOT to CRM	

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping From Section of Review and Submit page-Create Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping From section of Add Shipment (LTL) page
	When I click on standard Create Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping From Section on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping To Section of Review and Submit page-Create Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping To section of Add Shipment (LTL) page
	When I click on standard Create Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping To Section on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping From and To Sections of Review and Submit page-Create Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping From and To sections of Add Shipment (LTL) page
	When I click on standard Create Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping From and To Sections on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping From Section of Review and Submit page-Create Insured Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping From section of Add Shipment (LTL) page
	When I click on Create Insured Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping From Section on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping To Section of Review and Submit page-Create Insured Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping To section of Add Shipment (LTL) page
	When I click on Create Insured Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping To Section on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping From and To Sections of Review and Submit page-Create Insured Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping From and To sections of Add Shipment (LTL) page
	When I click on Create Insured Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping From and To Sections on Review and Submit Shipment (LTL) Page 	

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping From Section of Review and Submit page-Guaranteed Create Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping From section of Add Shipment (LTL) page
	When I click on Guaranteed Create Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping From Section on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping To Section of Review and Submit page-Guaranteed Create Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping To section of Add Shipment (LTL) page
	When I click on Guaranteed Create Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping To Section on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping From and To Sections of Review and Submit page-Guaranteed Create Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping From and To sections of Add Shipment (LTL) page
	When I click on Guaranteed Create Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping From and To Sections on Review and Submit Shipment (LTL) Page 	

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping From Section of Review and Submit page-Guaranteed Create Insured Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping From section of Add Shipment (LTL) page
	When I click on Guaranteed Create Insured Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping From Section on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping To Section of Review and Submit page-Guaranteed Create Insured Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping To section of Add Shipment (LTL) page
	When I click on Guaranteed Create Insured Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping To Section on Review and Submit Shipment (LTL) Page 

@GUI
Scenario: 44479_Verify the Notification displayed under Shipping From and To Sections of Review and Submit page-Guaranteed Create Insured Shipment
	Given I am a shp.entry, shp.entrynorates, sales, sales management, operations or station owner user
	And I selected new accessorial Notification in Shipping From and To sections of Add Shipment (LTL) page
	When I click on Guaranteed Create Insured Shipment button on Shipment Results Page
	Then Notification will be displayed in accessorial field of Shipping From and To Sections on Review and Submit Shipment (LTL) Page 	
