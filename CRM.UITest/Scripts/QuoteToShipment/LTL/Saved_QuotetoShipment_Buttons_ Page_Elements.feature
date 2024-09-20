@SavedQuoteToShipment_ButtonsAndPageElements @28055 @Sprint71 

Feature: SavedQuotetoShipment_Buttons_ Page_Elements

@GUI @Regression
Scenario Outline: 28055_Verify the data is auto populated and not editable when I convert the Saved Quote to Shipment
Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
And I am on the Quote Details Section of the non expired LTL quote <usertype>,<Account>
And I click on the Create Shipment button
When I arrive on the Add Shipment LTL page
Then Verify that in Shipping From Section Zipcode, Country ,City ,State and Service and Assessorials are auto populated and not editable
And Verify that in Shipping To Section Zipcode, Country ,City ,State and Service and Assessorials are auto populated and not editable
And I will not see the clear address button for Shipping from and Shipping To section
And Verify that in Pick up Date section Date should be autopopulated and not editable
And Verify that in Freight Description Section Item ,Quantity ,Quantity type ,Weight and weight type are auto populated and not editable 
And Verify that Insured Value and Insured type is autopopulated and not editable 


Examples: 
| Username              | Password | usertype | Account      |
| crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test |
@GUI @Regression
Scenario Outline: 28055_Verify the data is auto populated and not editable when I convert the Saved Quote to Shipment for External User
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
And I am on the Quote Details Section of the non expired LTL quote <usertype>,<Account>
And I click on the Create Shipment button
When I arrive on the Add Shipment LTL page
Then Verify that in Shipping From Section Zipcode, Country ,City ,State and Service and Assessorials are auto populated and not editable
And Verify that in Shipping To Section Zipcode, Country ,City ,State and Service and Assessorials are auto populated and not editable
And I will not see the clear address button for Shipping from and Shipping To section
And Verify that in Pick up Date section Date should be autopopulated and not editable
And Verify that in Freight Description Section Item ,Quantity ,Quantity type ,Weight and weight type are auto populated and not editable 
And Verify that Insured Value and Insured type is autopopulated and not editable 
	Examples: 
| Username | Password | usertype | Account      |
| zzzext| Te$t1234 |          |                          |

@GUI @Regression
Scenario Outline: 28055_Verify the field is editable when i convert the Saved Quote to Shipment
Given I am a shp.entry, operations, sales, sales management or station user <Username> <Password>
And I am on the Quote Details Section of the non expired LTL quote <usertype>,<Account>
And I click on the Create Shipment button
When I arrive on the Add Shipment LTL page
Then Verfy the fields are editable <LocationName>,<LocationAddress>,<LocationAddress2>,<Destination>,<DestinationAddress>,<DestinationAddress2>,<nmfc>,<item>,<length>,<width>,<height>,<dimensions>,<defaultspecialins>
And Verify the in Date section for <ReadyDate>,<CloseDate> is editable

Examples: 
| Username              | Password | Usertype | Account                  | LocationName | LocationAddress | LocationAddress2 | Destination | DestinationAddress | DestinationAddress2 | nmfc | item | length | width | height | dimensions | defaultspecialins | ReadyDate | CloseDate |
| crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | Name         | Origin          | Origin2          | NameDes     | Destination        | Destination2        | 1234 | desc | 10     | 12    | 12     | IN         | default special   | 11:00 AM  | 10:00 PM  |
@GUI @Regression
Scenario Outline: 28055_Verify the field is editable when i convert the Saved Quote to Shipment for ExternalUser
Given I am a shp.entry, shp.entrynorates, operations, sales, sales management, or station owner user <Username> <Password>
And I am on the Quote Details Section of the non expired LTL quote <usertype>,<Account>
And I click on the Create Shipment button
When I arrive on the Add Shipment LTL page
Then Verfy the fields are editable <LocationName>,<LocationAddress>,<LocationAddress2>,<Destination>,<DestinationAddress>,<DestinationAddress2>,<nmfc>,<item>,<length>,<width>,<height>,<dimensions>,<defaultspecialins>
And Verify the in Date section for <ReadyDate>,<CloseDate> is editable

Examples: 
| Username              | Password | Usertype | Account                  | LocationName | LocationAddress | LocationAddress2 | Destination | DestinationAddress | DestinationAddress2 | nmfc | item | length | width | height | dimensions | defaultspecialins | ReadyDate | CloseDate |
| zzzext                | Te$t1234 |          |                          | Name         | Origin          | Origin2          | NameDes     | Destination        | Destination2        | 1234 | desc | 10     | 12    | 12     | IN         | default special   | 11:00 AM  | 10:00 PM  |



