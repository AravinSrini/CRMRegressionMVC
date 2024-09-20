@Sprint81 @40780
Feature: Over Length - Quote Confirmation (LTL) - Display Dimensions	

Background: Login to CRM application
Given I am a shp.inquiry, shp.entry, operations, sales, sales management, or station owner user

@Regression 
Scenario: 40780_Verify the Dimensions column in Quote Details section of Quote Confirmation page
Given I am on Quote Confirmation LTL page 
When I expand the View Quote Details section
Then Dimensions will be displayed under Freight Information section between Class and Value columns

@Regression 
Scenario: 40780_Verify the Dimensions values displayed in Quote Details section of Quote Confirmation page when user entered dimension values
Given I am on LTL Quote Confirmation Page which contains Dimension values
When I expand the View Quote Details section
Then dimensions L W H will be displayed in bold 
And the values displayed next to L W H and dimensions type 

@Regression 
Scenario: 40780_Verify the Dimensions in Quote Details section of Quote Confirmation page when user not entered dimension values and not selected accessorials
Given I am on LTL Quote Confirmation Page which do not have Dimension values
When I expand the View Quote Details section
Then dimensions L W H will be displayed in bold 
And '--' will be displayed next to L W H and dimensions type

@Regression 
Scenario: 40780_Verify if dimension fields are highlighted when user tries to navigate to quote results page without passing values in dimensions fields
Given I am on Get Quote LTL page with no dimension values passed for selected accessorial type Overlength 
When I click on View Quote Resultsbutton
Then Length, Width and Height fields will highlight

@Regression 
Scenario: 40780_Verify the Dimensions in Quote Details section of Quote Confirmation page when user entered dimensions and not selected Overlength
Given I am on LTL Quote Confirmation Page with an accessorial type other than overlength 
When I expand the View Quote Details section
Then the values displayed next to L W H and dimensions type 
