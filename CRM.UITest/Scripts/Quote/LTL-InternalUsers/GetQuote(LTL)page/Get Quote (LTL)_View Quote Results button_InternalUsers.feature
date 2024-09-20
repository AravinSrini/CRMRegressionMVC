@26404 @Sprint67
Feature: Get Quote (LTL)_View Quote Results button_InternalUsers
	
@Regression 
Scenario Outline: 26404_Verify the View Quote Results button functionality when user passed USA addresses in both Shipping From and Shipping To fields
Given I am a DLS user and Login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I have entered valid zipcode <ShippingFrom> in Shipping From section
And I have entered valid zipcode <ShippingTo> in Shipping To section
And I enter valid data <Classification>, <Weight> in Freight Description Section
And I Click on View Quote Results button
Then I should be navigated to Quote Results Page displayed with rates

Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name            | ShippingFrom | ShippingTo | Classification | Weight |
| s1       | saleTest@sale.com     | Te$t1234 | Quote List       | GMS Company              | 90001        | 60606      | 50             | 350    |
| s2       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts            | 33126        | 60563      | 60             | 800    |
| s3       | crmsalesusr@user.com  | Te$t1234 | Quote List       | ZZZ - Czar Customer Test | 90001        | 60606      | 55             | 1000   |

@Regression 
Scenario Outline: 26404_Verify the View Quote Results button functionality when user passed Canada addresses in both Shipping From and Shipping To fields
Given I am a DLS user and Login into application with valid <Username> and <Password>
And I click on the Quote Icon
And I should be navigated to the Quote List <QuoteList_Header>page
And I have select the <Customer_Name> from customer dropdown list
And I have clicked on Submit Rate Request button
And I have clicked on LTL Tile of rate request process
When I am taken to the new responsive LTL Shipment Information screen
And I Select Canada from Shipping From Country dropdown
And I enter valid data in Shipping From section <ShippingFromPostal>, <ShippingFromCity> and <ShippingFromProvince>
And I Select Canada from Shipping To Country dropdown
And I enter valid data in Shipping To section <ShippingToPostal>, <ShippingToCity> and <ShippingToProvince>
And I enter valid data <Classification>, <Weight> in Freight Description Section
And I Click on View Quote Results button
Then I should be navigated to Quote Results Page displayed with no rates

Examples: 
| Scenario | Username              | Password | QuoteList_Header | Customer_Name            | ShippingFromPostal | ShippingFromCity | ShippingFromProvince | ShippingToPostal | ShippingToCity | ShippingToProvince | Classification | Weight |
| s1       | crmOperation@user.com | Te$t1234 | Quote List       | Dunkin Donuts            | L7J 0A1            | Acton            | ON                   | M4W 3L4          | Toronto        | ON                 | 55             | 350    |
| s2       | crmsalesusr@user.com  | Te$t1234 | Quote List       | ZZZ - Czar Customer Test | L7J 0A1            | Acton            | ON                   | M4W 3L4          | Toronto        | ON                 | 55             | 900    |
| s3       | saleTest@sale.com     | Te$t1234 | Quote List       | GMS Company              | L7J 0A1            | Acton            | ON                   | M4W 3L4          | Toronto        | ON                 | 55             | 1000   |
| s4       | stationown@stage.com  | Te$t1234 | Quote List       | Dunkin Donuts            | L7J 0A1            | Acton            | ON                   | M4W 3L4          | Toronto        | ON                 | 55             | 1200   |