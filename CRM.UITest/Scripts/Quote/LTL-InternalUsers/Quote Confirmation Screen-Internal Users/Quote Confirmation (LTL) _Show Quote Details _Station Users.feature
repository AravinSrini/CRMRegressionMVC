@26523 @Get Quote_Page Elements @Sprint67 
Feature: Quote Confirmation (LTL) _Show Quote Details _Station Users

@Regression 
Scenario Outline: 26523_Test to verify Quote Amount section confirmation page when standard  rates selected 
   Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
   And I click on the Quote Icon
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process   
   When I am taken to the new responsive LTL Shipment Information screen
   And I have entered valid zipcode <ShippingFrom> in Shipping From section
   And I have entered valid zipcode <ShippingTo> in Shipping To section
   And I enter valid data in Item information section <Classification>, <Weight>
   And I Click on view quote results button
   And  I click on save rate as quote link  for selected carrier in resultsint page
   Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
   And I click on Show Quote Details link
   And I will see Quote Amount section
   And I should be displayed with quote amount
   And I should be displayed with Est Cost
   And I should be displayed with Est Margin

Examples: 
| Customer_Name             | ShippingFrom | ShippingTo | Classification | Weight | QuoteConfirmationpageText |
| ZZZ - GS Customer Test    | 33126        | 60563      | 60             | 800    | Quote Confirmation        |

@Regression 
Scenario Outline: 26523_Test to verify Quote Amount section confirmation page when insured rates selected 
   Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
   And I click on the Quote Icon
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I have entered valid zipcode <ShippingFrom> in Shipping From section
   And I have entered valid zipcode <ShippingTo> in Shipping To section
   And I enter valid data in Item information section <Classification>, <Weight>
   And   I enter data in <Insuredvalue> field 
   And I Click on view quote results button
   And I click on save insured rate as quote link  for selected carrierinternaluser
   Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
   And I click on Show Quote Details link
   And I will see Quote Amount section
   And I should be displayed with quote amount
   And I should be displayed with Est Cost
   And I should be displayed with Est Margin

Examples: 
| Customer_Name             | ShippingFrom | ShippingTo | Classification | Weight | QuoteConfirmationpageText | Insuredvalue |
| ZZZ - GS Customer Test    | 33126        | 60563      | 60             | 800    | Quote Confirmation        | 100          |
   
@Regression 
   Scenario Outline: 26523_Test to verify  fields in Quote Amount section confirmation page when guaranteed  rates selected 
   Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
   And I click on the Quote Icon
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I have entered valid zipcode <ShippingFrom> in Shipping From section
   And I have entered valid zipcode <ShippingTo> in Shipping To section
   And I enter valid data in Item information section <Classification>, <Weight>
   And I Click on view quote results button
   And I will be navigated to Guaranteed Rate carriers grid
   And I click on guaranteed save rate as quote link  for selected carrierintuser
   Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
   And I click on Show Quote Details link
   And I will see Quote Amount section
   And I should be displayed with quote amount
   And I should be displayed with Est Cost
   And I should be displayed with Est Margin

Examples: 
| Customer_Name             | ShippingFrom | ShippingTo | Classification | Weight | QuoteConfirmationpageText |
| ZZZ - GS Customer Test    | 33126        | 60563      | 60             | 800    | Quote Confirmation        |

@Regression 
Scenario Outline: 26523_Test to verify  fields in Quote Amount section confirmation page when guaranteed insured rates selected 
   Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
   And I click on the Quote Icon
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I have entered valid zipcode <ShippingFrom> in Shipping From section
   And I have entered valid zipcode <ShippingTo> in Shipping To section
   And I enter valid data in Item information section <Classification>, <Weight>
   And I enter data in <Insuredvalue> field 
   And I Click on view quote results button
   And I will be navigated to Guaranteed Rate carriers grid
   And I click on guaranteed save insured rate as quote link  for selected carrierintuser
   Then I will be navigated to quote confirmation page '<QuoteConfirmationpageText>'
   And I click on Show Quote Details link
   And I will see Quote Amount section
   And I should be displayed with quote amount
   And I should be displayed with Est Cost
   And I should be displayed with Est Margin

Examples: 
| Customer_Name             | ShippingFrom | ShippingTo | Classification | Weight | QuoteConfirmationpageText | Insuredvalue |
| ZZZ - GS Customer Test    | 33126        | 60563      | 60             | 800    | Quote Confirmation        | 100          |

@Regression 
Scenario Outline: 26523_Test to verify Quote Amount section values in confirmation page when standard  rates selected 
   Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
   And I click on the Quote Icon
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I have entered valid zipcode <ShippingFrom> in Shipping From section
   And I have entered valid zipcode <ShippingTo> in Shipping To section
   And I enter valid data in Item information section <Classification>, <Weight>
   And I Click on view quote results button
   Then I should disply the quote amount,Est Cost,Est margin values in confirmation page on saving the rate on results page 

Examples: 
| Customer_Name             | ShippingFrom | ShippingTo | Classification | Weight | QuoteConfirmationpageText | Insuredvalue |
| ZZZ - GS Customer Test    | 33126        | 60563      | 60             | 800    | Quote Confirmation        | 100          |

@Regression 
Scenario Outline: 26523_Test to verify Quote Amount section values in confirmation page when guaranteed rates selected 
   Given I am a shp.inquiry, shp.entry, sales, sales management, operations, or station owner 
   And I click on the Quote Icon
   And I have select the <Customer_Name> from customer dropdown list
   And I have clicked on Submit Rate Request button
   And I have clicked on LTL Tile of rate request process
   When I am taken to the new responsive LTL Shipment Information screen
   And I have entered valid zipcode <ShippingFrom> in Shipping From section
   And I have entered valid zipcode <ShippingTo> in Shipping To section
   And I enter valid data in Item information section <Classification>, <Weight>
   And I Click on view quote results button
   Then I should disply the quote amount,Est Cost,Est margin values in confirmation page on saving the guaranteed rates on results page 

Examples: 
| Customer_Name             | ShippingFrom | ShippingTo | Classification | Weight | QuoteConfirmationpageText | Insuredvalue |
| ZZZ - GS Customer Test    | 33126        | 60563      | 60             | 800    | Quote Confirmation        | 100          |