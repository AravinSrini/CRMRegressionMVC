@28301 @Sprint70
Feature: ShipmentConfirmationLTL_MVC5_ShipmentSummarybutton_AllUsers
	
@GUI @Functional
Scenario Outline: Verify Shipment Summary button options on Shipment confirmation page
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Shipment Summary button
Then I should be displaying with <twooptions>

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2    | dName    | dZip  | dAdd1    | Customer_Name       | oComments | dComments | classification | nmfc    | quantity | weight | desc | twooptions                                   |
| Internal | asd   | 90502 | DName | OAddress | eyrieuwr | DAddress | 74464 | Daddress | 101 Telco Solutions | Dname     |           | 55             | q123asd | 1        | 1      | desc | View Shipment Summary,Email Shipment Summary |

@Functional
Scenario Outline: Verify Shipment summary document on click on View Shipment Summary
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Shipment Summary button
When I click on View Shipment Summary option
Then New tab will be opened which will display the shipment summary document

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name       | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| Internal | asd   | 60606 | DName | OAddress | eutwr | DAddress | 60606 | Daddress | 101 Telco Solutions | Dname     | eruwttew  | 55             | q123asd | 1        | 1      | desc |

@Functional @GUI
Scenario Outline: Verify the elements of Email Shipment Summary popup
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Shipment Summary button
When I click on Email Shipment Summary option
Then Email Shipment Summary modal will be displayed
And I should be displayed with Enter an email address text box and Add Additional Email button
And I should be displayed valid verbiage and able to edit the verbiage for Shipment Summary
And I should be displayed with copy check box by default checked
And I should be able to uncheck the copy check box
And I should be displayed with cancel and send email options

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name       | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| Internal | asd   | 90502 | DName | OAddress |       | DAddress | 74464 | Daddress | 101 Telco Solutions | Dname     |           | 55             | q123asd | 1        | 1      | desc |

@Functional
Scenario Outline: Verify the Add Additional Email and remove button functionality
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Shipment Summary button
When I click on Email Shipment Summary option
And I click on Add Additional Email button in Email Shipment Summary modal
Then I should be displayed with new email address text box and remove button
And I click on remove button
And the additional email address text box has been removed

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name       | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| Internal | asd   | 60606 | DName | OAddress | eutwr | DAddress | 60606 | Daddress | 101 Telco Solutions | Dname     | eruwttew  | 55             | q123asd | 1        | 1      | desc |

@Functional
Scenario Outline: Verify the Cancel button functionality of Email Shipment summary modal
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
When I click on the drop down arrow of the Shipment Summary button
When I click on Email Shipment Summary option
And I click on cancel button of Email shipment summary modal
Then the Email shipment summary modal will be closed

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name       | oComments | dComments | classification | nmfc    | quantity | weight | desc |
| Internal | asd   | 60606 | DName | OAddress | eutwr | DAddress | 60606 | Daddress | 101 Telco Solutions | Dname     | eruwttew  | 55             | q123asd | 1        | 1      | desc |

@Functional
Scenario Outline: Verify the error message when user entered invalid email address format
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
And I entered invalid Email address <email> on email shipment summary modal
When I click on Send Email button
Then Email text box should highlighted in Red color and displayed with <errormessage>

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name       | oComments | dComments | classification | nmfc    | quantity | weight | desc | email     | errormessage                             |
| Internal | asd   | 60606 | DName | OAddress | eutwr | DAddress | 60606 | Daddress | 101 Telco Solutions | Dname     | eruwttew  | 55             | q123asd | 1        | 1      | desc | dewfe@@@  | INVALID EMAIL ADDRESS. PLEASE TRY AGAIN. |

@Functional
Scenario Outline: Verify the functionality when user not checked in Send A Copy to My Email box 
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
And I entered all required data <email> and not checked the Send A Copy to My Email box 
When I click on Send Email button
Then modal will be closed 
And displaying with <confirmation_message>
And Confirmation message displays only entered <email>

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name       | oComments | dComments | classification | nmfc    | quantity | weight | desc | email                          | confirmation_message                                             |
| Internal | asd   | 60606 | DName | OAddress | eutwr | DAddress | 60606 | Daddress | 101 Telco Solutions | Dname     | eruwttew  | 55             | q123asd | 1        | 1      | desc | swathirayadurgam@gmail.com     | Your email has been sent to the following addresses successfully |

@Functional
Scenario Outline: Verify the functionality when user checked in Send A Copy to My Email box 
Given I am a shp.entry, operations, sales, sales management or station user
And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
And I entered required data <email> and checked the Send A Copy to My Email box 
When I click on Send Email button
Then modal will be closed 
And displaying with <confirmation_message>
And Confirmation message displays logged in user email <Username> and entered <email>

Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name       | oComments | dComments | classification | nmfc    | quantity | weight | desc | email                          | confirmation_message                                             |
| Internal | asd   | 60606 | DName | OAddress | eutwr | DAddress | 60606 | Daddress | 101 Telco Solutions | Dname     | eruwttew  | 55             | q123asd | 1        | 1      | desc | swathirayadurgam@gmail.com     | Your email has been sent to the following addresses successfully |