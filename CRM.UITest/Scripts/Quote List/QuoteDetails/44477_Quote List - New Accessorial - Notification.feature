@44477 @Sprint83 
Feature: 44477_Quote List - New Accessorial - Notification

@GUI @API
Scenario: Verify that user will see the Notification displayed in the Additional Service and Accessorial section of Quote details
Given I am a shp.inquiry, shp.entry, sales, sales management, operations and station owner user
And I am navigated to the Quote List page
And I expand the Quote Details of any displayed LTL quote
When The quote contained the accessorial <Notification>
Then I will see <Notification> displayed in the Additional Services and Accessorials section