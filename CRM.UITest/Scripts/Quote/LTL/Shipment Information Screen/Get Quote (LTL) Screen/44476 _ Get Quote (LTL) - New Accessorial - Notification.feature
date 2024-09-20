@44476 @Sprint83 
Feature: 44476 _ Get Quote (LTL) - New Accessorial - Notification

@Regression
Scenario Outline: Verify the new dropdown selection Notification in Shipping From and Shipping To section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations and station owner user
And I am on the Get Quote LTL page
And I click in the <Click to add services & accesorials...> field in either of the following locations: <Sections>
Then I will see a new selection: <Notification> in dropdown
And The new selection <Notification> will be displayed alphabetically within the list

Examples: 
| Sections      |
| Shipping From |
| Shipping To   |

@Regression
Scenario Outline: Verify the CRM will send the Accessorial Service NTFY to MG for Shipping From and Shipping To section
Given I am a shp.inquiry, shp.entry, sales, sales management, operations and station owner user
And I am on the Get Quote LTL page
And I click in the <Click to add services & accesorials...> field in either of the following locations: <Sections>
And I selected <Notification> from dropdown 
When I click on the <View Quote Results> button
Then CRM will send the Accessorial Service <NTFY> to MG

Examples: 
| Sections      |
| Shipping From |
| Shipping To   |

@Regression
Scenario Outline: Verify MG will return carrier charges that includes the Accessorial Code <NOT> to CRM
Given I am a shp.inquiry, shp.entry, sales, sales management, operations and station owner user
And I am on the Get Quote LTL page
And I click in the <Click to add services & accesorials...> field in either of the following locations: <Sections>
And I selected <Notification> from dropdown 
And I clicked on the View Quote Results button
When CRM sends the Accessorial Service <NTFY> to MG
Then MG will return carrier charges that include the Accessorial Code <NOT> to CRM

Examples: 
| Sections      |
| Shipping From |
| Shipping To   |

