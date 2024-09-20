@26370  @Sprint67
Feature: Get Quote (LTL) _Page Elements_internalUsers

@Regression 
   Scenario Outline:Test to verify the all fields in get quote(LTL) page_addresssection
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Quote Icon
   And I should be navigated to the Quote List <QuoteList_Header>page
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   Then I should be displayed with shipfrom section
   And I should be displayed with the saved address ship from drop down
   And I should be displayed with the clear address option
   And I should be displayed Shipping From zip
   And I should be displayed with Shipping From city
   And I should be displayed with Shipping From country
   And I should be displayed with state/province
   And I should be displayed with Shipping From services & accessorial
   And I should be displayed US state by default in Shipping From country
   And I should be displayed with shipto section
   And I should be displayed with the saved address ship To drop down
   And I should be displayed with the clear address option
   And I should be displayed Shipping To zip
   And I should be displayed with Shipping To city
   And I should be displayed with Shipping To country
   And I should be displayed with state/province
   And I should be displayed with Shipping To services & accessorial
   And I should be displayed US state by default in Shipping To country

 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name             |
| s1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts             |
| s2       | saleTest@sale.com     | Te$t1234 | Quote List       | GMS Company               |
| s3       | crmsalesusr@user.com  | Te$t1234 | Quote List       | ZZZ Sandbox DLS Worldwide |



@Regression 
   Scenario Outline:Test to verify the all fields get quote(LTL)_item section
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Quote Icon
   And I should be navigated to the Quote List <QuoteList_Header>page
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   Then I should be displayed Select Class
   And I should be displayed Enter a Weight
   And I should be displayed with Quantity
   And I should be displayed with Quantity Type
   And I should be displayed with Insured Value
   And I should be displayed with Insured Value New or Used selection
   And Quantity Type should be default to skids
   And Insured Value New or Used selection dropdown is binded with default value 'New'
   And I should be displayed with pickup date 
   Then I pickup date should be binded with by default todays date
   And I should be displayed density calculator button next to class selection
   And I should be displayed with Add Additional Item button

 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name             |
| s1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts             |
| s2       | saleTest@sale.com     | Te$t1234 | Quote List       | GMS Company               |
| s3       | crmsalesusr@user.com  | Te$t1234 | Quote List       | ZZZ Sandbox DLS Worldwide |


@Regression 
   Scenario Outline:Test to verify the all fields in get quote(LTL) screen_buttons
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Quote Icon
   And I should be navigated to the Quote List <QuoteList_Header>page
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
  Then I should be displayed with Calendar icon in pickup date selection field
   And I should be displayed with tool tip next to insured type selection field
   And I should be displayed back to quote list button 
   And I should be displayed with View Quote Results button
    
 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name |
| s1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts |

@Regression 
Scenario Outline:Test to verify mandatory field functionality in get quote(LTL)
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Quote Icon
   And I should be navigated to the Quote List <QuoteList_Header>page
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   When I  keep Shipping From zip is blank
   And  I  keep Shipping To zip is blank
   And I keep Weight field is blank
   And I click on viewquote results button 
   Then All the Required fields should be highlight in the pink color
  
    
 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name             |
| s1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts             |
| s2       | saleTest@sale.com     | Te$t1234 | Quote List       | GMS Company               |
| s3       | crmsalesusr@user.com  | Te$t1234 | Quote List       | ZZZ Sandbox DLS Worldwide |





