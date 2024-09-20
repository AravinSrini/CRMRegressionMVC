@Sprint80 @40781
Feature: Over Length - Quote Details - Display Dimensions

Background: Login to CRM application
Given I am a shp.inquiry, shp.entry, operations, sales, sales management, or station owner user

@Regression 
Scenario:40781_Verify the Dimensions type and values in Quote Details section of Quote List page_with Dimensions
When I am Quote Details section of saved quote with Dimensions
Then Dimensions column will be displayed between the Classification and NMFC
And dimensions L W H will be displayed in bold in Quote Details
And the values displayed next to L W H and dimensions type in Quote Details

@Regression 
Scenario:40781_Verify the Dimensions types,values displayed in Quote Details section of Quote List page_without Dimensions
When I am Quote Details section of saved quote without Dimensions
Then Dimensions column will be displayed between the Classification and NMFC
And dimensions L W H will be displayed in bold in Quote Details
And '--' displayed next to L W H and dimensions type in Quote Details

