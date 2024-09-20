@Sprint70 @28300
Feature: Shipment Confirmation (LTL) (MVC5) – Bill of Lading button – All Users
@GUI 
Scenario Outline: Test to verify Bill of Lading button options_Shipment Confirmation_Shipment Document Preference of BOL
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When I click on the drop down arrow of the Bill of Lading button
   Then I should display with <twoptions>
 
  Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | twoptions                              | 
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |View Bill Of Lading,Email Bill Of Lading |
| Internal | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc |View Bill Of Lading,Email Bill Of Lading | 

@GUI 
Scenario Outline: Test to verify  Email Bill of Lading modal_Shipment Confirmation_Shipment Document Preference of BOL
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When I select the Email Bill of Lading option from BOL options
   Then I should be displayed with Email Bill of Lading modal
   And I should be displayed with email address text box and add additional email addresses link
   And I should be displayed valid verbiage and able to edit the verbiage
   And I should be displayed with copy check box by default checked
   And I should be able to uncheck the copy check box 
   And I should display cancel and send email options
 
 Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | twoptions                              | 
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |View Bill of Lading,Email Bill of Lading| 
| Internal | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc |View Bill of Lading,Email Bill of Lading| 

@GUI 
Scenario Outline: Test to verify Addextraemail and removebutton and cancel button_function_Shipment Confirmation
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When  I am on  Email Bill of Lading modal
   And I click on Add Additional Email button
   Then I should be displayed with new email address text box and remove button
   And I click on remove button
   Then Additional Email text box should be removed
   When I click on cancel button on email modal
   Then I should be returned to the Shipment Confirmation (LTL) page
 
  Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | twoptions                              | 
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc |View Bill of Lading,Email Bill of Lading| 
| Internal | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc |View Bill of Lading,Email Bill of Lading| 


@GUI 
Scenario Outline: Test to verify invalid email functionality and mandatory_Shipment Confirmation_Shipment Document Preference of BOL
   Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
   And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
   When  I am on  Email Bill of Lading modal
   And I enter invalid email '<email>' on Email Bill of Lading modal
   And I enter invalid email '<email2>' in additional email text box
   And I click on Send Email button
   Then email text boxes should be highlighted and displayed with error message for invalid '<message>'
   When I keep email text box and additional email text box keep blank on Email Bill of Lading modal 
   Then email text boxes should be highlighted and displayed with error message for empty scenario'<message1>'
   
Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | message                                  | email          | email2  | message1                      |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc | INVALID EMAIL ADDRESS. PLEASE TRY AGAIN. | vasundhara.com | swa.com | PLEASE ENTER AN EMAIL ADDRESS |
| Internal | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc | INVALID EMAIL ADDRESS. PLEASE TRY AGAIN. | vasundhara.com | swa.com | PLEASE ENTER AN EMAIL ADDRESS | 


@GUI 
Scenario Outline: Test to verify confirmation popup for email_copyme option_Shipment Confirmation_Shipment Document Preference of BOL
 Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
 And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
 When  I am on  Email Bill of Lading modal
 And I entered all required information '<email>','<email1>' on Email Bill of Lading modal
 And I click on the Send Email button
 Then The modal will be closed
 And I will receive a confirmation popup with email passed '<email>','<email1>'

  Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | message                                                          | email               | email1 |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc | Your email has been sent to the following addresses successfully |test@gmail.com       |test1@gmail.com        |
| Internal | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc | Your email has been sent to the following addresses successfully |test@gmail.com       |test1@gmail.com        |


@GUI 
Scenario Outline: Test to verify confirmation popup for email_copyme option not checkedin_Shipment Confirmation_Shipment Document Preference of BOL
 Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user 
 And I am on the Shipment Confirmation (LTL) page  <Usertype>, <oAdd2>, <oZip>,<oName>, <oAdd1>, <dAdd2>,<dName>,<dAdd1>,<Customer_Name>, <oComments>,<dComments>, <dZip>, <classification>,<nmfc>, <quantity>, <weight>, <desc>
 When  I am on  Email Bill of Lading modal
 Then I should be able to uncheck the copy check box 
 And pass '<email>' value in email text box
 When I click on the Send Email button
 Then The modal will be closed
 And I will receive a confirmation popup with email passed '<email>' not the created user email

  Examples: 
| Usertype | dAdd2 | oZip  | oName | oAdd1    | oAdd2 | dName    | dZip  | dAdd1    | Customer_Name            | oComments | dComments | classification | nmfc    | quantity | weight | desc | message                                                          | email               | email1 |
| External | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress |                          | Dname     |           | 55             | q123asd | 1        | 1      | desc | Your email has been sent to the following addresses successfully |test@gmail.com       |test1@gmail.com        |
| Internal | asd   | 60606 | DName | OAddress |       | DAddress | 60606 | Daddress | ZZZ - Czar Customer Test | Dname     |           | 55             | q123asd | 1        | 1      | desc | Your email has been sent to the following addresses successfully |test@gmail.com       |test1@gmail.com        |







