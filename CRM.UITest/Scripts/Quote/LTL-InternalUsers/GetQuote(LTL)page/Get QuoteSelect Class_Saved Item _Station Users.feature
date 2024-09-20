@26395  @Sprint67
Feature: Get QuoteSelect Class_Saved Item _Station Users

@Regression 
Scenario Outline:Test to verify the dropdown values in saved items_for selected customer_DB
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Quote Icon
   And I should be navigated to the Quote List <QuoteList_Header>page
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I click on the Select Class field
   Then number of items displaying for the <Customer_Name> in the saveditems dropdown should be equal to database
   
 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name             |
| s1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts             |
| s2       | saleTest@sale.com     | Te$t1234 | Quote List       | GMS Company               |
| s3       | crmsalesusr@user.com  | Te$t1234 | Quote List       | ZZZ Sandbox DLS Worldwide |

@Regression 
Scenario Outline:Test to verify the dropdown values  order in saved items_for selected customer
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Quote Icon
   And I should be navigated to the Quote List <QuoteList_Header>page
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   When I click on the Select Class field
   Then I must see the list of classes in the Select Class field should be in numerical order
   And I must see the saved items should display after the list of classes in the Select Class field
   And I must see the list of saved items should be display as Class and Item Description
   And I must see the list of saved items is displayed in the Select Class field should be in numeric, then alphabetical order

 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name             |
| s1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts             |
| s2       | saleTest@sale.com     | Te$t1234 | Quote List       | GMS Company               |
| s3       | crmsalesusr@user.com  | Te$t1234 | Quote List       | ZZZ Sandbox DLS Worldwide |

@Regression 
Scenario Outline:Test to verify the dropdown value discription order in saved items_for selected customer
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Quote Icon
   And I should be navigated to the Quote List <QuoteList_Header>page
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   When I click on the Select Class field
   Then I must see the list of saved items should be display as Class and Item Description

 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name             |
| s1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts             |
| s2       | saleTest@sale.com     | Te$t1234 | Quote List       | GMS Company               |
| s3       | crmsalesusr@user.com  | Te$t1234 | Quote List       | ZZZ Sandbox DLS Worldwide |

@Regression 
Scenario Outline:Test to verify the autopopulated functionlity when i select value in saved items_for selected customer
   Given I am a DLS user and login into application with valid <Username> and <Password>
   And I click on the Quote Icon
   And I should be navigated to the Quote List <QuoteList_Header>page
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   Then  I select '<saveditem>' from the Select Class field
   Then The saved item information of '<Class>', '<Weight>', '<Quantity>', '<QuantityType>' should be auto-filled in the Freight Description section

 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name | saveditem | Class     | Weight | Quantity | QuantityType |
| S1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts | 70 MYTEST | 70 MYTEST | 100    | 10       | Skids        |

@Regression 
Scenario Outline: Verify the functionality of add additional item button under Freight description section
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on add additional item link 
Then another set of Select Class , Density calculator Icon, Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should be displayed

 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name |
| S1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts |

@Regression 
Scenario Outline: Verify the functionality of remove additional item link under Freight description section
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I click on add additional item link 
And I click on remove additional item link
Then another set of Select Class , Density calculator Icon, Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should disappear

 Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name |
| S1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts |