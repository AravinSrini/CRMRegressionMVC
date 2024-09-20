@LTLShipmentInformationPageDesktop @17386 @Sprint59 @Sprint64
Feature: Shipping Information screen for Desktop

#------------Sprint 64 Revamp LTL Rate Request - Shipping From - Saved Address/Clear Address---------------
@Regression 
Scenario Outline: Verify that the top 100 addresses are displayed under Shipping From saved address dropdown and cleared on click of Clear Address link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on origin saved address dropdown 
	Then the top hundred addresses must be displayed under origin saved addresses for the user with AcctNum <AcctNum>
	And I select an address from the origin saved address list
	And clicking on Clear Address link must clear the address in the origin saved address field
	And All populated fields will cleared/reset in the Shipping From section

Examples: 
| Scenario | Username                 | Password | Service | AcctNum |
| S1       | testshpentryabc@test.com | Te$t1234 | LTL     | 3870    |

@Regression 
Scenario Outline: Verify that the top 100 addresses are displayed under Shipping To saved address dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on destination saved address dropdown 
	Then the top hundred addresses must be displayed under destination saved addresses for the user with AcctNum <AcctNum>
	And I select an address from the destination saved address list
	And clicking on Clear Address link must clear the address in the destination saved address field
	And All populated fields will cleared/reset in the Shipping To section

Examples: 
| Scenario | Username                 | Password | Service | AcctNum |
| S1       | testshpentryabc@test.com | Te$t1234 | LTL     | 3870    |

@Regression 
Scenario Outline: Verify that top 100 addresses are displayed when a search criteria is applied under Shipping From saved address dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter a search criteria '<searchText>' in the origin saved address field 
	Then the top hundred addresses must be displayed under origin saved addresses for the search criteria '<searchText>' for user with AcctNum <AcctNum> 

Examples: 
| Scenario | Username                 | Password | Service | searchText | AcctNum |
| S1       | testshpentryabc@test.com | Te$t1234 | LTL     | c          | 3870    |

@Regression 
Scenario Outline: Verify that top 100 addresses are displayed when a search criteria is applied under Shipping To saved address dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter a search criteria '<searchText>' in the destination saved address field 
	Then the top hundred addresses must be displayed under destination saved addresses for the search criteria '<searchText>' for user with AcctNum '<AcctNum>'
	
Examples: 
| Scenario | Username                 | Password | Service | searchText | AcctNum |
| S1       | testshpentryabc@test.com | Te$t1234 | LTL     | c          | 3870    |

#-----------------End of Sprint 64 Revamp LTL Rate Request - Shipping From - Saved Address/Clear Address--------------------------------

#-----------------------Sprint 64 Ship From and Ship To : Populate Saved Address------------------------------------
@Regression 
Scenario Outline: Select any saved origin address and verify the populated data 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on origin saved address dropdown 
	And I select any address from the origin saved address dropdown
	Then selected address should be populated in origin fields

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Select any saved destination address and verify the populated data 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on destination saved address dropdown 
	And I select any address from the destination saved address dropdown
	Then selected address should be populated in destination fields

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

#-----------------------End of Sprint 64 Ship From and Ship To : Populate Saved Address------------------------------------
@Regression 
Scenario Outline: Verify the options present under origin country dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I click on origin country dropdown 
    Then United States <Country1> and Canada <Country2> countries options should be displayed in origin country dropdown

Examples: 
| Scenario | Username        | Password | Service | Country1      | Country2 |
| S1       | nat@extuser.com | Te$t1234 | LTL     | UNITED STATES | CANADA   |

@Regression 
Scenario Outline: Verify the options present under destination country dropdown
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I click on destination country dropdown 
    Then United States <Country1> and Canada <Country2> countries options should be displayed in destination country dropdown

Examples: 
| Scenario | Username        | Password | Service | Country1      | Country2 |
| S1       | nat@extuser.com | Te$t1234 | LTL     | UNITED STATES | CANADA   |

@Regression 
Scenario Outline: Verify the fields on selecting United states/ Canada Country from origin country dropdown 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I select <Country> from the origin country dropdown
    Then respective fields for the <Country> should be displayed <ZipPostalMaxLength> should be displayed in origin section

Examples: 
| Scenario | Username        | Password | Service | Country       | ZipPostalMaxLength |
| S1       | nat@extuser.com | Te$t1234 | LTL     | UNITED STATES | 5                  |
| S2       | nat@extuser.com | Te$t1234 | LTL     | CANADA        | 7                  |

@Regression 
Scenario Outline: Verify the fields on selecting United states/ Canada Country from destination country dropdown 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I select <Country> from the destination country dropdown
    Then respective fields for the <Country> should be displayed <ZipPostalMaxLength> should be displayed in destination section

Examples: 
| Scenario | Username        | Password | Service | Country       | ZipPostalMaxLength |
| S1       | nat@extuser.com | Te$t1234 | LTL     | UNITED STATES | 5                  |
| S2       | nat@extuser.com | Te$t1234 | LTL     | CANADA        | 7                  |


#----------------Sprint 64 - 22761 - Revamp LTL Rate Request - Freight Description - Density Calculator--------------------------


@Regression  
Scenario Outline: Verify the message displayed when I mouse over on the Density calculator Icon
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then on mouse hover on the Density Calculator icon I should be able to see the message as '<Estimate_Class>'

Examples: 
| Scenario | Username        | Password | Service | Estimate_Class |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Estimate Class | 


@Regression 
Scenario Outline: Verify the error message when no data is entered in any of the fields in estimated lookup modal
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon		
	Then Verify the error message '<Error_Message>' is displayed

Examples: Error_Message
| Scenario | Username        | Password | Service | Error_Message           |
| S1       | nat@extuser.com | Te$t1234 | LTL     | PLEASE ENTER ALL VALUES |


@Regression  
Scenario Outline: Verify the warning message when I enter more than threshold value in Weight field in estimated lookup modal
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon		
	Then Verify the warning message '<Weight_Warning_Message>' is displayed when weight exceeds the LTL threshold value

Examples: 
| Scenario | Username        | Password | Service |Weight_Warning_Message                                                                                                                                                                     |
| S1       | nat@extuser.com | Te$t1234 | LTL     |The entered weight exceeds the LTL threshold of 10,000 lbs. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information.|


@Regression 
Scenario Outline: Verify the warning message when I enter more than threshold value in Quanity field in estimated lookup modal
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon		
	Then Verify the warning message '<Quantity_Warning_Message>' is displayed when quanity exceeds the LTL threshold value

Examples: 
| Scenario | Username        | Password | Service |Quantity_Warning_Message                                                                                                                                                                                      |
| S1       | nat@extuser.com | Te$t1234 | LTL     |The entered quantity exceeds the LTL threshold of 6 standard pallets or skids. An additional carrier fee may apply. Please contact your local operations representative for more accurate pricing information.|


# ---------------For Below scenarios just modified the step "And I click on the Density calculator Icon"

@Regression  
Scenario Outline: Verify the functionality of Density Calculator link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And I click on the Density calculator Icon
    Then pop-up model should be displayed to find estimated class

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression  
Scenario Outline: Verify the functionality of 'SHOW DENSITY CLASS TABLE' link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
	And I click on SHOW DENSITY CLASS TABLE link
	Then show predefined denisity table should be displayed and link should be changed to HIDE DENSITY CLASS TABLE

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression  
Scenario Outline: Verify the functionality of 'HIDE DENSITY CLASS TABLE' link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
	And I click on SHOW DENSITY CLASS TABLE link
	And I click on HIDE DENSITY CLASS TABLE
	Then show predefined denisity table should not be displayed and link should be changed to SHOW DENSITY CLASS 

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify the functionality of Apply class button in estimated class popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
	And I enter data in estimate class popup <Length>, <Width>, <Height>, <Weight>, <Quantity> and <ExpectedDensity>
	And I click on Apply class	
	Then pop-up model should be closed and passed data should be populated into respective fields '<Select_Class>' , '<Weight>' and '<Quantity>'

Examples: 
| Scenario | Username        | Password | Service | Length | Width | Height | Weight | Quantity | Select_Class | ExpectedDensity |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 10     | 10    | 10     | 100    | 5        | 60           | 34.56           |

@Regression  
Scenario Outline: Do not pass data in required fiels and verify the estimate class popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
    Then Apply class button should be disabled till the data passed in all the required fields

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify the functionality of close button in estimated class popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
    And I click on close button in esitmate class popup
    Then pop-up model should be closed

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 

@Regression  
Scenario Outline: Verify the maximum character limits for Density calculator model
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on the Density calculator Icon
	Then I should be able to verify the maximum character limits for all the fields

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

#--------------------End of Story 22761 Density Calculator----------------------------------------------------



#------------Start of Sprint 64 - 22580 - Revamp LTL Rate Request - Freight Description - Add Additional Item ---
@Regression 
Scenario Outline: Verify the functionality of add additional item link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	Then another set of Select Class , Density calculator Icon, Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should be displayed
	
Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify the functionality of remove additional item link
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on add additional item link 
	And I click on remove additional item link
	Then another set of Select Class , Density calculator Icon, Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should disappear
	

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 

# ----------- End of Sprint 64 - 22580 - Revamp LTL Rate Request - Freight Description - Add Additional Item----



#------------Sprint 64 Terms and Conditions for non default customers---------------

@Regression 
Scenario Outline: Verify the Terms and Conditions link under Freight Description for Non Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
Then Terms and Conditions link should be displayed

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 1000         |

@Regression 
Scenario Outline: Verify the Terms and Conditions modal when user clicks on it under Freight Description for Non Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
And I click on Terms and Conditions link
Then terms and conditions popup should be displayed

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 100          |

@Regression 
Scenario Outline: Verify the download DLSW Claim Form in Terms and Conditions modal for Non Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
And I click on Terms and Conditions link
And Click on Download DLSW Claim Form displaying in Terms and Conditions modal
Then DLSW Claim Form is downloaded

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 100          |

@Regression 
Scenario Outline: Verify the functionality of close button inside the terms and conditions popup
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
And I click on Terms and Conditions link
Then terms and conditions popup should be displayed
And Close button should be displayed in modal
And I click on close button 
Then popup should be closed and user should remain in shipment information page

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue |
| s1       | awg@shipentry.com | Te$t1234 | LTL     | 100          |

@Regression 
Scenario Outline: Verify the Terms and Conditions link when user not entered Insured Value for non Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I have not entered the data in <Insuredvalue> field of Freight Description section
Then Terms and Conditions link should not be displayed

Examples: 
| Scenario | Username          | Password | Service | Insuredvalue |
| s1       | awg@shipentry.com | Te$t1234 | LTL     |              |

@Regression 
Scenario Outline: Verify the Terms and Conditions link under Freight Description for Default customer
Given I am a DLS user and login into application with valid <Username> and <Password>
And I clicked on <Service> button on the select type screen of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I enter data in <Insuredvalue> field 
Then Terms and Conditions link should not be displayed

Examples: 
| Scenario | Username | Password | Service | Insuredvalue |
| s1       | nat      | Te$t1234 | LTL     | 1000         |

#------------End of Sprint 64 Terms and Conditions for non default customers---------------

@Regression 
Scenario Outline: Verify the error message on entering maximum shipment value
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter data in <ShipmentValue> field
	Then error message should be displayed for entering maximum shipment value

Examples: 
| Scenario | Username        | Password | Service | ShipmentValue |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 1000000       |


#------------Sprint 64 Revamp LTL Rate Request -  View Quote Results Button---------------
@Regression 
Scenario Outline: Verify the functionality of View Quote Results button by passing USA addresses
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I enter valid data in Shipping From Section <ShippingFromZip>
	And I enter valid data in Shipping To Section <ShippingToZip>
	And I enter valid data in Freight Description Section <Classification>, <Weight>
	And I click on view quote results button
    Then rate results page should be displayed

Examples: 
| Scenario | Username        | Password | Service | ShippingFromZip | ShippingToZip | Classification | Weight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33126           | 85282         | 70             | 100    | 


@Regression 
Scenario Outline: Verify the functionality of View Quote Results button by passing Canada addresses
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I select Canada Country from origin country dropdown
	And I enter valid data in Origin section <OriginPostal>, <OriginCity> and <OriginProvince>
	And I select Canada Country from destination country dropdown
	And I enter valid data in Destination section <DestinationProvince>, <DestinationCity> and <DestinationPostal>
	And I enter valid data in Freight Description Section <Classification>, <Weight>
	And I click on view quote results button
    Then no rate results page should be displayed

Examples: 
| Scenario | Username        | Password | Service | OriginCity | OriginProvince | OriginPostal | DestinationCity | DestinationProvince | DestinationPostal | Classification | Weight |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Acton      | ON             | L7J 0A1      | Acton           | ON                  | L7J 0A1           | 70             | 100    |

#------------End of Sprint 64 Revamp LTL Rate Request -  View Quote Results Button---------------

#----------------------------Sprint 64 Revamp LTL Rate Request - Address/Zipcode Lookup--------------------

@Regression  
Scenario Outline: Verify zipcode lookup api auto populate functionality for the Shipping From section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I enter zipcode <ValidZip> and leave focus from the origin section
	Then City <City> and State <State> fields should be populated in origin section
	And I have the ability to edit the city in shipping from section<ModifiedCity>
    And I have the option to select a state from the state drop down list in shipping from section<ModifiedState>

Examples: 
| Scenario | Username        | Password | Service | ValidZip | City       | State | ModifiedCity | ModifiedState |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 33126    | Miami      | FL    | test         | CA            |
| S2       | nat@extuser.com | Te$t1234 | LTL     | 60563    | Naperville | IL    | test         | CA            |

@Regression  
Scenario Outline: Verify zipcode lookup api auto populate functionality for the Shipping To section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I enter zipcode <ValidZip> and leave focus from the destination section
	Then City <City> and State <State> fields should be populated in destination section
	And I have the ability to edit the city in shipping to section<ModifiedCity>
    And I have the option to select a state from the state drop down list in shipping to section<ModifiedState>

Examples: 
| Scenario | Username        | Password | Service | ValidZip | City  | State | ModifiedCity | ModifiedState |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 85282    | Tempe | AZ    | test2        | CA            |

@Regression 
Scenario Outline: Verify zipcode text box on entering invalid zip in Shipping From section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I enter zipcode <InvalidZip> and leave focus from the origin section
	Then background color of the origin zip code textbox should turn red and error message should be displayed
	And  the Origin City and State will not Auto populate

Examples: 
| Scenario | Username        | Password | Service | InvalidZip |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 66666      |

@Regression 
Scenario Outline: Verify zipcode text box on entering invalid zip in Shipping To section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I enter zipcode <InvalidZip> and leave focus from the destination section
	Then background color of the destination zip code textbox should turn red and error message should be displayed
	And  the Destination City and State will not Auto populate

Examples: 
| Scenario | Username        | Password | Service | InvalidZip |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 66666      |



@Regression 
Scenario Outline: Verify  Select State/Province drop down list will be populated with a list of Canada provinces in Shipping To section
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I select Canada Country from destination country dropdown
    Then the Select State/Province drop down list will be populated with a list of Canada provinces  in Shipping To section
	Examples: 
| Scenario | Username        | Password | Service | InvalidZip | Country |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 66666      | Canada  |


@Regression 
Scenario Outline: Verify  Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section
    Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I select Canada Country from origin country dropdown
    Then the Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section
	Examples: 
| Scenario | Username        | Password | Service | InvalidZip |
| S1       | nat@extuser.com | Te$t1234 | LTL     | 66666      |
	
#----------------------------End Sprint 64 Revamp LTL Rate Request - Address/Zipcode Lookup --------------------


#------------------22579 Revamp LTL Rate Request - Shipping  From - Services & Accessorials--------------------------------

@Regression 
Scenario Outline:Verify existence of Services & Accessorials multi select field in Ship. From section of Get Quote page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then I must be able to view Services & Accessorials multi select field in the Ship.From section

Examples: 
| Scenario | Username        | Password | Service | 
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify the functionality of Services & Accessorials multi select field by selecting multiple values from the dropdown for Ship.From
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship From section
	Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.From Section
Examples: 
| Scenario | Username        | Password | Service | Accessorials1 | Accessorials2     |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Appointment   | Construction Site |

@Regression 
Scenario Outline: Try to delete services selected from the Services & Accessorials multi select Dropdown (Ship.From)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship From section
	And I select a service '<Accessorials1>' from the Ship.From section dropdown
	Then I must have an option to delete the service selected from the Ship.From dropdown

Examples: 
| Scenario | Username        | Password | Service | Accessorials1 | 
| S1       | nat@extuser.com | Te$t1234 | LTL     | Appointment   |

@Regression 
Scenario Outline: Verify the dropdown values for Services & Accessorials under Ship. From section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship From section
	Then I should be able to view specified Ship.From services in the dropdown

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |
#------------------End of 22579 Revamp LTL Rate Request - Shipping  From - Services & Accessorials--------------------------------

#------------------22705 Revamp LTL Rate Request - Shipping  To - Services & Accessorials--------------------------------
@Regression 
Scenario Outline:Verify existence of Services & Accessorials multi select field in Ship. To section of Get Quote page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then I must be able to view Services & Accessorials multi select field in the Ship.To section

Examples: 
| Scenario | Username        | Password | Service | 
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify the functionality of Services & Accessorials multi select field by selecting multiple values from the dropdown for Ship.To
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship To section
	Then I should be able to select services '<Accessorials1>' and '<Accessorials2>' from Ship.To Section

Examples: 
| Scenario | Username        | Password | Service | Accessorials1 | Accessorials2 |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Appointment   | COD           |      

@Regression 
Scenario Outline: Try to delete services selected from the Services & Accessorials multi select Dropdown (Ship.To)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship To section
	And I select a service '<Accessorials1>' from the Ship.To section dropdown
	Then I must have an option to delete the service selected from the Ship.To dropdown


Examples: 
| Scenario | Username        | Password | Service | Accessorials1 |
| S1       | nat@extuser.com | Te$t1234 | LTL     | Appointment   |

@Regression 
Scenario Outline: Verify the dropdown values for Services & Accessorials (Ship. To)
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click services and accessorials dropdown on Ship To section
	Then I should be able to view specified Ship.To Services in the dropdown

Examples: 
| Scenario | Username        | Password | Service | 
| S1       | nat@extuser.com | Te$t1234 | LTL     | 

#------------------End of 22705 Revamp LTL Rate Request - Shipping  To - Services & Accessorials-------------------

#--------------------------------- Obsolete Test Scenarios------------------------------------------------------
@Regression 
Scenario Outline: Verify the fields present in LTL shipment information page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	Then I should be able to verify fields - Select a saved origin address, Origin Country, Origin Zip/Postal code, Origin City, Origin State/Province, Select a saved destination address, Destination Country, Destination Zip/Postal Code, Destination City, Destination State/Province, Select a saved item, Classification, Weight, Pickup date, Services/accessorials, Shipment value, Terms & Conditions link, Tool tip, Estimate class lookup ,Add additional item button and View Quote Results button

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify the LTL shipment information page when data is not passed in required fields
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
    And click on view quote results button 
	Then error message should be displayed by highlighting required fields

Examples: 
| Scenario | Username        | Password | Service |
| S1       | nat@extuser.com | Te$t1234 | LTL     |

@Regression 
Scenario Outline: Verify the functionality of postal lookup in origin section and verify popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on origin postal lookup
	And I enter valid data <OriginAddress>, <OriginCity> and <OriginState> in origin lookup
	And I click on find zipcode button
	Then Valid Zip code <Zip> should be displayed for the entered origin address

Examples: 
| Scenario | Username        | Password | Service | Country       | OriginAddress          | OriginCity | OriginState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | 5200 Blue Lagoon Drive | Miami      | FL          | 33126 |

@Regression 
Scenario Outline: Verify the functionality of postal lookup in destination section and verify popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on destination postal lookup
	And I enter valid data <DestinationAddress>, <DestinationCity> and <DestinationState> in destination lookup
	And I click on find zipcode button
	Then Valid Zip code <Zip> should be displayed for the entered destination address

Examples: 
| Scenario | Username        | Password | Service | Country       | DestinationAddress                 | DestinationCity | DestinationState | Zip |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | 4500 Lakeshore Drive Suite 695 | Tempe           | AZ               | 85282 |

@Regression 
Scenario Outline: Verify the functionality of postal lookup in origin section when invalid address is entered and verify popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on origin postal lookup
	And I enter valid data <InvalidOriginAddress>, <InvalidOriginCity> and <OriginState> in origin lookup
	And I click on find zipcode button
	Then error message should be displayed inside the postal lookup popup

Examples: 
| Scenario | Username        | Password | Service | Country       | InvalidOriginAddress | InvalidOriginCity | OriginState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | abcd                 | abcd              | FL          | 33126 |

@Regression 
Scenario Outline: Verify the functionality of postal lookup in destination section when invalid address is entered and verify popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on destination postal lookup
	And I enter valid data <InvalidDestinationAddress>, <InvalidDestinationCity> and <DestinationState> in destination lookup
	And I click on find zipcode button
	Then error message should be displayed inside the postal lookup popup

Examples: 
| Scenario | Username        | Password | Service | Country       | InvalidDestinationAddress | InvalidDestinationCity | DestinationState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | abcd                      | abcd                   | AZ               | 85282 |

@Regression 
Scenario Outline: Verify the functionality of save and close button of postal lookup in origin section and verify popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on origin postal lookup
	And I enter valid data <OriginAddress>, <OriginCity> and <OriginState> in origin lookup
	And I click on find zipcode button
    And I click on save and close button 
    Then entered address details in the lookup should be populated in origin fields <Zip>, <OriginCity> and <OriginState> 

Examples: 
| Scenario | Username        | Password | Service | Country       | OriginAddress          | OriginCity | OriginState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | 5200 Blue Lagoon Drive | Miami      | FL          | 33126 |

@Regression 
Scenario Outline: Verify the functionality of save and close button of postal lookup in destination section and verify popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on destination postal lookup
	And I enter valid data <DestinationAddress>, <DestinationCity> and <DestinationState> in destination lookup
	And I click on find zipcode button
    And I click on save and close button 
    Then entered address details in the lookup should be populated in destination fields <Zip>, <DestinationCity> and <DestinationState> 

Examples: 
| Scenario | Username        | Password | Service | Country       | DestinationAddress             | DestinationCity | DestinationState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | 4500 Lakeshore Drive Suite 695 | Tempe           | AZ               | 85282 |

@Regression 
Scenario Outline: Verify the functionality of new lookup button of postal lookup in origin section and verify popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on origin postal lookup
	And I enter valid data <OriginAddress>, <OriginCity> and <OriginState> in origin lookup
	And I click on find zipcode button
    And I click on New lookup 
    Then empty lookup should be displayed

Examples: 
| Scenario | Username        | Password | Service | Country       | OriginAddress          | OriginCity | OriginState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | 5200 Blue Lagoon Drive | Miami      | FL          | 33126 |

@Regression 
Scenario Outline: Verify the functionality of new lookup button of postal lookup in destination section and verify popup
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on destination postal lookup
	And I enter valid data <DestinationAddress>, <DestinationCity> and <DestinationState> in destination lookup
	And I click on find zipcode button
    And I click on New lookup 
    Then empty lookup should be displayed

Examples: 
| Scenario | Username        | Password | Service | Country       | DestinationAddress             | DestinationCity | DestinationState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | 4500 Lakeshore Drive Suite 695 | Tempe           | AZ               | 85282 |

@Regression 
Scenario Outline: Verify the functionality of Cancel button of postal lookup in origin section and verify page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on origin postal lookup
	And I enter valid data <OriginAddress>, <OriginCity> and <OriginState> in origin lookup
    And I click on Cancel button
    Then entered address in the lookup should not be populated in origin respective fields

Examples: 
| Scenario | Username        | Password | Service | Country       | OriginAddress          | OriginCity | OriginState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | 5200 Blue Lagoon Drive | Miami      | FL          | 33126 |

@Regression 
Scenario Outline: Verify the functionality of Cancel button of postal lookup in destination section and verify page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I clicked on <Service> button on the select type screen of rate request process
	When I am taken to the new responsive LTL Shipment Information screen
	And I click on destination postal lookup
	And I enter valid data <DestinationAddress>, <DestinationCity> and <DestinationState> in destination lookup
    And I click on Cancel button
    Then entered address in the lookup should not be populated in destination respective fields

Examples: 
| Scenario | Username        | Password | Service | Country       | DestinationAddress             | DestinationCity | DestinationState | Zip   |
| S1       | nat@extuser.com | Te$t1234 | LTL     | United States | 4500 Lakeshore Drive Suite 695 | Tempe           | AZ               | 85282 |

#--------------------------------- Obsolete Test Scenarios------------------------------------------------------