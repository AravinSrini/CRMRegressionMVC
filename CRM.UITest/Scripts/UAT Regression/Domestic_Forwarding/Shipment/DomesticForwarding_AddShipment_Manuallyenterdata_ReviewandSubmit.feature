@DomesticForwardingAddShipmentManuallyEnterDataReviewAndSubmit @32144 @Sprint71 @Ignore
Feature: DomesticForwarding_AddShipment_Manuallyenterdata_ReviewandSubmit


@GUI @Regression
Scenario: Verify the sections and fields on review and sumit page of domestic forwarding for ship entry and no rates users
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType>and entered <OLocationName>,<OAddress1>,<OZip>,<OService&Accessorials>,<OReady>,<OClose>,<DLocationName>,<DAddress>,<DZip>,<DService&Accessorials>,<DReady>,<DClose>,<FDPices>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>,<hazmat>,<DefaultSpecialInstructions>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified <OLocation>,<OContactInformatrion>,<OServices_Accessorials>,<DLocation>,<DContactinformation>,<DServices_Accessorials>,<Dates>,<FreightDesc>,<Services_Accessorials>,<DefaultSpecialInstructions>
And I will see the <service> and <DForwardingType>


@GUI @Regression
Scenario: Verify the data binding for Origin section on review and sumit page 
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType> and entered <OLocationName>,<OAddress1>,<Oaddress2>,<Ocountry>,<ozip>,<OState>,<OCity>,<Ocomments>,<OReady>,<OClose>,<DLocationName>,<DAddress>,<DZip>,<DService&Accessorials>,<DReady>,<DClose>,<FDPices>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified <OLocationName>,<OAddress1>,<Oaddress2>,<Ocountry>,<ozip>,<OState>,<OCity>,<Ocomments>



@GUI @Regression
Scenario: Verify the data binding for Origin from section on review and sumit page 
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType> and entered <OLocationName>,<OAddress1>,<OZip>,<Contact_Name>,<Phoneno>,<Faxnumber>,<Email>,<Service_Accessioral>,<PickUpDate>,<OReady>,<OClose>,<DLocationName>,<DAddress>,<DZip>,<DService&Accessorials>,<DReady>,<DClose>,<FDPices>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified <Contact_Name>,<Phoneno>,<Faxnumber>,<Email>,<Service_Accessioral>,<PickUpDate>,<OReady>,<OClose>

 
@GUI @Regression
Scenario: Verify the data binding for Destination section on review and sumit page 
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType> and entered <OLocationName>,<OAddress1>,<OZip>,<OReady>,<OClose>,<DLocationName>,<DAddress1>,<DAddress2>,<DCountry>,<Dzip>,<DState>,<DCity>,<DComments>,<DReady>,<DClose>,<FDPices>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified <DLocationName>,<DAddress1>,<DAddress2>,<DCountry>,<Dzip>,<DState>,<DCity>,<DComments>



@GUI @Regression
Scenario: Verify the data binding for Destination from section on review and sumit page
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType> and entered <OLocationName>,<OAddress1>,<OZip>,<OReady>,<OClose>,<DLocationName>,<DAddress1>,<Dzip>,<DContactName>,<DPhoneNo>,<DFaxNo>,<DEmail>,<DServices_Accessorials>,<DDeliveryDate>,<DReady>,<DClose>,<FDPices>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified  <DContactName>,<DPhoneNo>,<DFaxNo>,<DEmail>,<DServices_Accessorials>,<DDeliveryDate>,<DReady>,<DClose>

@GUI @Regression
Scenario: Verify the data binding for Freight Description section on review and sumit page
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType> and entered <OLocationName>,<OAddress1>,<OZip>,<OReady>,<OClose>,<DLocationName>,<DAddress1>,<Dzip>,<DReady>,<DClose>,<FDPices>,<Type>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified <FDPices>,<Type>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>


@GUI @Regression
Scenario: Verify the data binding for Reference Number section on review and sumit page
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType> and entered <OLocationName>,<OAddress1>,<OZip>,<OReady>,<OClose>,<DLocationName>,<DAddress1>,<Dzip>,<DReady>,<DClose>,<FDPices>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>,<Reference_Type>,<Reference_Number>,<Customer_Type>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified <Reference_Type>,<Reference_Number>,<Customer_Type>


@GUI @Regression
Scenario: Verify the data binding for Additional Services and Accessorials section on review and sumit page
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType> and entered <OLocationName>,<OAddress1>,<OZip>,<OReady>,<OClose>,<DLocationName>,<DAddress1>,<Dzip>,<DReady>,<DClose>,<FDPices>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>,<service_accessorials>,<shipment_value>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified <service_accessorials>,<shipment_value>

@GUI @Regression
Scenario: Verify the data binding for Default special instructions section on review and sumit page
Given I am a shp.entry or shp.entry no rates user - <Username> and <Password>
And I am on the Add Shipment Page of Domestic Forwarding <service>,<DForwardingType> and entered <OLocationName>,<OAddress1>,<OZip>,<OReady>,<OClose>,<DLocationName>,<DAddress1>,<Dzip>,<DReady>,<DClose>,<FDPices>,<FDWeight>,<FDDimensionsLength>,<FDDimensionsWidth>,<FDDimensionsHeight>,<Description>,<DefaultSpecial_Ins>
When I click on Save and Continue on Add Shipment Page
Then I must land on Review and Submit page and verified <DefaultSpecial_Ins>




