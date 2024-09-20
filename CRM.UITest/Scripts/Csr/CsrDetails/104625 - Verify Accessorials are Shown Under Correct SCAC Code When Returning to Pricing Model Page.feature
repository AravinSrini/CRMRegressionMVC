@NinjaSprint34 @104625 @Regression

Feature: 104625 - Verify Accessorials are Shown Under Correct SCAC Code When Returning to Pricing Model Page

Scenario: 104625 - Verify Accessorials are Shown Under Correct SCAC Code When Returning to Pricing Model Page
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
And my Pricing Model Type is Gainshare
And I have entered valid information to the Gainshare fields
And I have added two accessorials to the Gainshare area
And I click Add Carrier-Specific Gainshare
And I click Add Carrier-Specific Gainshare
And I click Add Carrier-Specific Gainshare
And I have selected "ABFL" for the SCAC Code on Carrier-Specific Gainshare One
And I have selected "AVRT" for the SCAC Code on Carrier-Specific Gainshare Two
And I have selected "AACT" for the SCAC Code on Carrier-Specific Gainshare Three
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare One
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare Two
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare Three
And I click Set Individual Accessorials on Carrier-Specific Gainshare Three
And I have selected "OVERLENGTH" on the Set Individual Accessorials Modal
And I have set the Gainshare Type to "FLAT OVER COST" on the Set Individual Accessorials modal
And I have entered valid information for the overlength fields on the Set Individual Accessorials modal
And I click save on the Set Individual Accessorials modal
And I click save and continue on the Pricing Model page
When I click the Back button on the Saved Items and Addresses page
Then the accessorial will be displayed under the correct SCAC code

Scenario: 104625 - Verify Set Flat Amount field is shown after returning to Pricing Model page
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
And my Pricing Model Type is Gainshare
And I have entered valid information to the Gainshare fields
And I have added two accessorials to the Gainshare area
And I click Add Carrier-Specific Gainshare
And I click Add Carrier-Specific Gainshare
And I click Add Carrier-Specific Gainshare
And I have selected "ABFL" for the SCAC Code on Carrier-Specific Gainshare One
And I have selected "AVRT" for the SCAC Code on Carrier-Specific Gainshare Two
And I have selected "AACT" for the SCAC Code on Carrier-Specific Gainshare Three
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare One
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare Two
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare Three
And I click Set Individual Accessorials on Carrier-Specific Gainshare Three
And I have selected "OVERLENGTH" on the Set Individual Accessorials Modal
And I have set the Gainshare Type to "FLAT OVER COST" on the Set Individual Accessorials modal
And I have entered valid information for the overlength fields on the Set Individual Accessorials modal
And I click save on the Set Individual Accessorials modal
And I click save and continue on the Pricing Model page
When I click the Back button on the Saved Items and Addresses page
And I click Set Individual Accessorials on Carrier-Specific Gainshare One
And I enter valid information on the Individual Accessorials modal for one accessorial
Then I will see the Set Flat Amount field on the modal

Scenario: 104625 - Verify Set Individual Accessorials Modal Can Be Opened
Given I am a sales, sales management, operations, station owner, pricing config, system config, or config manager user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I am submitting a new csr
And I am on the Pricing Model page for a new CSR
And my Pricing Model Type is Gainshare
And I have entered valid information to the Gainshare fields
And I have added two accessorials to the Gainshare area
And I click Add Carrier-Specific Gainshare
And I click Add Carrier-Specific Gainshare
And I click Add Carrier-Specific Gainshare
And I have selected "ABFL" for the SCAC Code on Carrier-Specific Gainshare One
And I have selected "AVRT" for the SCAC Code on Carrier-Specific Gainshare Two
And I have selected "AACT" for the SCAC Code on Carrier-Specific Gainshare Three
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare One
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare Two
And I have entered "50" for the Gainshare Percentage on Carrier-Specific Gainshare Three
And I click Set Individual Accessorials on Carrier-Specific Gainshare Three
And I have selected "OVERLENGTH" on the Set Individual Accessorials Modal
And I have set the Gainshare Type to "FLAT OVER COST" on the Set Individual Accessorials modal
And I have entered valid information for the overlength fields on the Set Individual Accessorials modal
And I click save on the Set Individual Accessorials modal
And I click save and continue on the Pricing Model page
When I click the Back button on the Saved Items and Addresses page
And I click Set Individual Accessorials
Then the Set Individual Accessorials modal will be visible