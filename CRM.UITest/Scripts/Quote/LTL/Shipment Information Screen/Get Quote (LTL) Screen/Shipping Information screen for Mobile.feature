@LTLShipmentInformationPageMobile @17386 @Sprint59
Feature: Shipping Information screen for Mobile

@Regression 
Scenario Outline: Verify the fields present in LTL shipment information page in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	Then I should be able to verify all the fields in the mobile device - Origin Country,Origin Zip/Postal code, Origin City, Origin State/Province, Destination Country, Destination Zip/Postal Code, Destination City, Destination State/Province, Classification, Weight, Pickup date, Services/accessorials, Shipment value, Terms & Conditions link, Add additional item button and View Quote Results button

Examples: 
| Scenario | Username        | Password | Service | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 320         | 568          |

@Regression 
Scenario Outline: Verify for the fields which should not present in LTL shipment information page in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	Then Select a saved origin address, Select a saved destination address, Select a saved item, Zip/Postal lookups, Estimated Class Lookups, Shipment Value ? icon,  and Back to Quote List button should be hidden

Examples: 
| Scenario | Username        | Password | Service | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 320         | 568          | 

@Regression 
Scenario Outline: Verify the LTL shipment information page when data is not passed in required fields in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And click on view quote results button 
		Then error message should be displayed by highlighting required fields

Examples: 
| Scenario | Username        | Password | Service | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 320         | 568          |

@Regression 
Scenario Outline: Verify the options present under origin country dropdown in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on origin country dropdown 
	Then United States <Country1> and Canada <Country2> countries options should be displayed in origin country dropdown

Examples: 
| Scenario | Username        | Password | Service | Country1      | Country2 | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | UNITED STATES | CANADA   | 320         | 568          |

@Regression 
Scenario Outline: Verify the options present under destination country dropdown in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data destination zip in Destination section <DestinationZip>
	And I click on destination country dropdown 
	Then United States <Country1> and Canada <Country2> countries options should be displayed in destination country dropdown

Examples: 
| Scenario | Username        | Password | Service | Country1      | Country2 | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | UNITED STATES | CANADA   | 320         | 568          |

@Regression 
Scenario Outline: Verify the fields on selecting United states/ Canada Country from origin country dropdown in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I select <Country> from the origin country dropdown
	Then respective fields for the <Country> should be displayed <ZipPostalMaxLength> should be displayed in origin section

Examples: 
| Scenario | Username        | Password | Service | WindowWidth | WindowHeight | ZipPostalMaxLength | Country       |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 320         | 568          | 5                  | UNITED STATES |

@Regression 
Scenario Outline: Verify the fields on selecting United states/ Canada Country from destination country dropdown in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data destination zip in Destination section <DestinationZip>
	And I select <Country> from the destination country dropdown
	Then respective fields for the <Country> should be displayed <ZipPostalMaxLength> should be displayed in destination section

Examples: 
| Scenario | Username        | Password | Service | WindowWidth | WindowHeight | ZipPostalMaxLength | Country       |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 320         | 568          | 5                  | UNITED STATES |



#------------Sprint 64 Terms and Conditions for non default customers---------------

@Regression 
Scenario Outline: Verify the Terms and Conditions link under Freight Description in mobile device for Non Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
Then Terms and Conditions link should be displayed

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue | WindowWidth | WindowHeight |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 1000         | 320         | 568          |

@Regression 
Scenario Outline: Verify the terms and conditions pop up in mobile device for non default customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter data in <Insuredvalue> field
    And I click on Terms and Conditions link
    Then terms and conditions popup should be displayed

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue | WindowWidth | WindowHeight |
| S1       | awg@shipentry.com | Te$t1234 | LTL     | 1000         | 320         | 568          |

@Regression 
Scenario Outline: Verify the download DLSW Claim Form in Terms and Conditions modal in mobile device for Non Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
And I click on Terms and Conditions link
And Click on Download DLSW Claim Form displaying in Terms and Conditions modal
Then DLSW Claim Form is downloaded

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue |WindowWidth | WindowHeight |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 100          |320         | 568          |

@Regression 
Scenario Outline: Verify the functionality of close button inside the terms and conditions popup in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter data in <Insuredvalue> field
	And I click on Terms and Conditions link
	Then terms and conditions popup should be displayed
	And Close button should be displayed in modal
	And I click on close button 
	Then popup should be closed and user should remain in shipment information page
	
Examples: 
| Scenario | Username          | Password | Service | Insuredvalue | WindowWidth | WindowHeight |
| S1       | awg@shipentry.com | Te$t1234 | LTL     | 1000         | 320         | 568          |

@Regression 
Scenario Outline: Verify the Terms and Conditions link when user not entered Insured Value for non Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I have not entered the data in <Insuredvalue> field of Freight Description section
Then Terms and Conditions link should not be displayed

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue | WindowWidth | WindowHeight |
| s1       | awg@shipentry.com | Te$t1234 | LTL     |              |320          | 568          |

@Regression 
Scenario Outline: Verify the Terms and Conditions link under Freight Description for Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
Then Terms and Conditions link should not be displayed

Examples: 
| Scenario | Username        | Password | Service | Insuredvalue | WindowWidth | WindowHeight |
| s1       | nat@extuser.com |Te$t1234  | LTL     | 100          | 320         | 568          |

#------------End of Sprint 64 Terms and Conditions for non default customers---------------

@Regression 
Scenario Outline: Verify the error message on entering maximum shipment value in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter data in <ShipmentValue> field
	Then error message should be displayed for entering maximum shipment value

Examples: 
| Scenario | Username        | Password | Service | ShipmentValue | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 1000000       | 320         | 568          |


#------------Sprint 64 Revamp LTL Rate Request -  View Quote Results Button---------------
@Regression 
Scenario Outline: Verify the functionality of View Quote Results button in mobile device by passing USA addresses
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in Shipping From Section <ShippingFromZip>
	And I enter valid data in Shipping To Section <ShippingToZip>
	And I enter valid data in Freight Description Section <Classification>, <Weight>
	And I click on view quote results button
    Then rate results page should be displayed

Examples: 
| Scenario | Username        | Password | Service | ShippingFromZip | ShippingToZip | Classification | Weight | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33126           | 85282         | 70             | 100    | 320         | 568          |


@Regression 
Scenario Outline: Verify the functionality of View Quote Results button in mobile by passing Canada addresses
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
    And I select Canada Country from origin country dropdown
	And I enter valid data in Origin section <OriginPostal>, <OriginCity> and <OriginProvince>
	And I select Canada Country from destination country dropdown
	And I enter valid data in Destination section <DestinationProvince>, <DestinationCity> and <DestinationPostal>
	And I enter valid data in Freight Description Section <Classification>, <Weight>
	And I click on view quote results button
    Then no rate results page should be displayed

Examples: 
| Scenario | Username        | Password | Service | OriginCity | OriginProvince | OriginPostal | DestinationCity | DestinationProvince | DestinationPostal | Classification | Weight | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Acton      | ON             | L7J 0A1      | Acton           | ON                  | L7J 0A1           | 70             | 100    | 320         | 568          |

#------------End of Sprint 64 Revamp LTL Rate Request -  View Quote Results Button---------------

#----------------------------Sprint 64 Revamp LTL Rate Request - Address/Zipcode Lookup--------------------

@Regression 
Scenario Outline: Verify zipcode lookup api auto populate functionality for the Shipping From section in Mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter zipcode <ValidZip> and leave focus from the origin section
	Then City <City> and State <State> fields should be populated in origin section
	And I have the ability to edit the city in shipping from section<ModifiedCity>
    And I have the option to select a state from the state drop down list in shipping from section<ModifiedState>

Examples: 
| Scenario | Username        | Password |WindowWidth  | WindowHeight | Service | ValidZip | City  | State | ModifiedCity | ModifiedState |
| S1       | nat@extuser.com | Te$t1234 | 320         | 568          |LTL      | 33126    | Miami | FL    | test         | CA            |

@Regression 
Scenario Outline: Verify zipcode lookup api auto populate functionality for the Shipping To section in Mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter zipcode <ValidZip> and leave focus from the destination section
	Then City <City> and State <State> fields should be populated in destination section
	And I have the ability to edit the city in shipping to section<ModifiedCity>
    And I have the option to select a state from the state drop down list in shipping to section<ModifiedState>

Examples: 
| Scenario | Username        | Password | WindowWidth  | WindowHeight |Service | ValidZip | City  | State | ModifiedCity | ModifiedState |
| S1       | nat@extuser.com | Te$t1234 | 320          | 568          |LTL     | 85282    | Tempe | AZ    | test2        | CA            |

@Regression 
Scenario Outline: Verify zipcode text box on entering invalid zip in Shipping From section in Mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter zipcode <InvalidZip> and leave focus from the origin section
	Then background color of the origin zip code textbox should turn red and error message should be displayed
	And  the Origin City and State will not Auto populate

Examples: 
| Scenario | Username        | Password | WindowWidth  | WindowHeight |Service | InvalidZip |
| S1       | nat@extuser.com | Te$t1234 | 320          | 568          |LTL     | 66666      |

@Regression 
Scenario Outline: Verify zipcode text box on entering invalid zip in Shipping To section in Mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	When I enter zipcode <InvalidZip> and leave focus from the destination section
	Then background color of the destination zip code textbox should turn red and error message should be displayed
	And  the Destination City and State will not Auto populate

Examples: 
| Scenario | Username        | Password | WindowWidth  | WindowHeight |Service | InvalidZip |
| S1       | nat@extuser.com | Te$t1234 | 320          | 568          |LTL     | 66666      |



@Regression 
Scenario Outline: Verify  Select State/Province drop down list will be populated with a list of Canada provinces in Shipping To section in Mobile device
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	When I select Canada Country from destination country dropdown
    Then the Select State/Province drop down list will be populated with a list of Canada provinces  in Shipping To section
	Examples: 
| Scenario | Username        | Password | WindowWidth  | WindowHeight |Service | InvalidZip | Country |
| S1       | nat@extuser.com | Te$t1234 |320           | 568          | LTL     | 66666      | Canada  |


@Regression 
Scenario Outline: Verify  Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section in Mobile device
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	When I select Canada Country from origin country dropdown
    Then the Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section
	Examples: 
| Scenario | Username        | Password | WindowWidth  | WindowHeight |Service | InvalidZip |
| S1       | nat@extuser.com | Te$t1234 | 320          | 568          |LTL     | 66666      |
	
#----------------------------End Sprint 64 Revamp LTL Rate Request - Address/Zipcode Lookup --------------------




#------------------22579 Revamp LTL Rate Request - Shipping  From - Services & Accessorials--------------------------------

@Regression 
Scenario Outline: Verify existence of Services & Accessorials multi select field in Ship. From section of Get Quote page in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	Then I must be able to view Services & Accessorials multi select field in the Ship.From section 

Examples: 
| Scenario | Username        | Password | Service | WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 320         | 568          | 

@Regression 
Scenario Outline: Verify the functionality of Services & Accessorials multi select field by selecting multiple values from the dropdown for Ship.From (Mobile Device)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship From section
	Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.From Section 

Examples: 
| Scenario | Username        | Password | Service | Accessorials1 | Accessorials2     |WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Appointment   | Construction Site |320         | 568          |

@Regression 
Scenario Outline: Verify the dropdown values of Services & Accessorials under Ship. From section for Mobile Device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship From section
	Then I should be able to view specified Ship.From services in the dropdown


Examples: 
| Scenario | Username        | Password | Service |WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     |320         | 568          |

#------------------End of 22579 Revamp LTL Rate Request - Shipping  From - Services & Accessorials--------------------------------


#------------------22705 Revamp LTL Rate Request - Shipping  To - Services & Accessorials--------------------------------

@Regression 
Scenario Outline: Verify existence of Services & Accessorials multi select field in Ship. To section of Get Quote page in mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	Then I must be able to view Services & Accessorials multi select field in the Ship.From section 

Examples: 
| Scenario | Username        | Password | Service |WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     |320         | 568          |


@Regression 
Scenario Outline: Verify the functionality of Services & Accessorials multi select field by selecting multiple values from the dropdown for Ship.To (Mobile Device)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship To section
	Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.To Section

Examples: 
| Scenario | Username        | Password | Service | Accessorials1 | Accessorials2 |WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Appointment   | COD           |320         | 568          |

@Regression 
Scenario Outline: Verify the dropdown values of Services & Accessorials for Mobile Device (Ship. To)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship To section
	Then I should be able to view specified Ship.To Services in the dropdown

Examples: 
| Scenario | Username        | Password | Service |WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     |320         | 568          |

#------------------End of 22705 Revamp LTL Rate Request - Shipping  To - Services & Accessorials--------------------------------


# ------ Start of Sprint 64 - 22580 - Revamp LTL Rate Request --- Add addiyional Item

@Regression 
Scenario Outline: Verify the functionality of add additional item link for Mobile
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 	
	Then another set of Select Class , Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should be displayed for mobile
	
Examples: 
| Scenario | Username        | Password | Service |WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     |320         | 568          |

@Regression 
Scenario Outline: Verify the functionality of remove additional item link for Mobile
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I clicked on <Service> button on the select type screen of rate request process from mobile device
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	And I click on remove additional item link	
	Then another set of Select Class , Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should disappear for mobile
	

Examples: 
| Scenario | Username        | Password | Service |WindowWidth | WindowHeight |
| S1       | nat@extuser.com | Te$t1234 | LTL     |320         | 568          | 


#-----------End of Sprint 64 - 22580 - Revamp LTL Rate Request --- Add addiyional Item