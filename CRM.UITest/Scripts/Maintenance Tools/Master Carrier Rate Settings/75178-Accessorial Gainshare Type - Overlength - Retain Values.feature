@75178 @NinjaSprint32 @Regression
Feature: 75178-Accessorial Gainshare Type - Overlength - Retain Values

Scenario: 75178_Verify Overlength 8 value not cleared when gainshare type set to percent over cost
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "8" textbox
And the gainshare type "% over cost" is selected
Then the values up to and including Overlength "8" textbox should not be empty

Scenario: 75178_Verify Overlength 8 value not cleared when gainshare type set to Flat over cost
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "8" textbox
And the gainshare type "Flat over cost" is selected
Then the values up to and including Overlength "8" textbox should not be empty

Scenario: 75178_Verify Overlength 8 value not cleared when gainshare type set to Set flat amount
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "8" textbox
And the gainshare type "Set flat amount" is selected
Then the values up to and including Overlength "8" textbox should not be empty

Scenario: 75178_Verify Overlength 8 and 9 value not cleared when gainshare type set to percent over cost
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "9" textbox
And the gainshare type "% over cost" is selected
Then the values up to and including Overlength "9" textbox should not be empty

Scenario: 75178_Verify Overlength 8 and 9 value not cleared when gainshare type set to Flat over cost
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "9" textbox
And the gainshare type "Flat over cost" is selected
Then the values up to and including Overlength "9" textbox should not be empty

Scenario: 75178_Verify Overlength 8 and 9 value not cleared when gainshare type set to Set flat amount
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "9" textbox
And the gainshare type "Set flat amount" is selected
Then the values up to and including Overlength "9" textbox should not be empty

Scenario: 75178_Verify all overlength values not cleared when gainshare type set to percent over cost
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "30" textbox
And the gainshare type "% over cost" is selected
Then the values up to and including Overlength "30" textbox should not be empty

Scenario: 75178_Verify all Overlength values not cleared when gainshare type set to Flat over cost
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "30" textbox
And the gainshare type "Flat over cost" is selected
Then the values up to and including Overlength "30" textbox should not be empty

Scenario: 75178_Verify all Overlength values not cleared when gainshare type set to Set flat amount
Given that I am a pricing config or config manager user "username-CurrentSprintconfigmanager", "password-CurrentSprintconfigmanager"
And I have navigated to the Master Carrier Rate Settings page
And I select "ZZZ - GS Customer Test" from the customer dropdown
And I select a carrier from the Carrier List
And I select the Set Accessorials button
When the accessorial Overlength is selected
And I enter the value "10" up to and including the Overlength "30" textbox
And the gainshare type "Set flat amount" is selected
Then the values up to and including Overlength "30" textbox should not be empty