@40775 @Sprint81

Feature: Over Length - Add Shipment (LTL) -Tab Order
	
@Functional @GUI
Scenario: 40775_Verify the tab order in Add Shipment page fields
	Given I have logged in as a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
	And I am on Add Shipment (LTL) page
	When <Overlength> has been selected for both shipping from and Shipping To fields
	Then the tab order will follow the given sequence. Enter location name ,Enter location address, Enter zip/postal code (Shipping From section) , Enter destination name, Enter destination address, Enter zip/postal code (Shipping To  section), Select or search for a class or saved item field, Enter a quantity , Enter item description ,Enter a weight, Length, Width, Height 

@Functional @GUI
Scenario: 40775_Verify the tab order for additional items fields
	Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
	And I am on Add Shipment (LTL) page
	When <Overlength> has been selected for both shipping from and Shipping To fields
	Then the tab order will follow the given sequence for additionally added items. Select or search for a class or saved item field , Enter a quantity, Enter item description, Enter a weight, Length, Width, Height, View Rates button

@Functional @GUI
Scenario: 40775_Verify the back tab order in Add Shipment page fields
  Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
  And I am on Add Shipment (LTL) page
  When <Overlength> has been selected for both shipping from and Shipping To fields
  Then the back tab order will follow the given sequesnce for additionally added items. View Rates button, Height, Width, Length , Enter a weight, Enter item description, Enter a quantity , Select or search for a class or saved item, Enter zip/postal code (Shipping To section) , Enter destination address, Enter destination name, Enter zip/postal code (Shipping From section) , Enter location address, Enter location name

 @Functional @GUI  
Scenario: 40775_Verify the back tab order for additional item field
  Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user
  And I am on Add Shipment (LTL) page
  When <Overlength> has been selected for both shipping from and Shipping To fields
  Then the back tab order will follow the given sequence. View Rates button, Height, Width, Length , Enter a weight, Enter item description , Enter a quantity , Select or search for a class or saved item
   
Scenario: 40775_Verify the tab order for additional item field for internal user
  Given I am a sales, sales management, operations, or station owner user
  And I am on Add Shipment (LTL) page as a internal user
  When <Overlength> has been selected for both shipping from and Shipping To fields
  Then the back tab order will follow the given sequence. View Rates button, Height, Width, Length , Enter a weight, Enter item description , Enter a quantity , Select or search for a class or saved item