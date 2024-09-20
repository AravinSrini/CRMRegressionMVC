@60340 @NinjaSprint28 @Regression
Feature: 60340 - LTL Quote result/Confirmation- Mobile screen

Scenario: 60340_Verify the Back to Quote List button is displayed on the quote results screen when I am a specified user
Given I am Stationowner Operations Sales management or Sales user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I resize the window to the dimensions "375" "812"
When I land on quote results screen as a specified user "ZZZ - Czar Customer Test" with an origin zip "94538", origin city of "Fremont", origin state of "CA" destination zip "60657", destination city of "CHICAGO", destination state of "IL" classification "60" and weight "50"
Then I see Back to Quote List button

Scenario: 60340_Verify the Back to Quote List button is not displayed on the quote results screen when I am not a specified user
Given I am not a Stationowner Operations Sales management or Sales user "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
And I resize the window to the dimensions "375" "812"
When I land on quote results screen with an origin zip "94538", origin city of "Fremont", origin state of "CA" destination zip "60657", destination city of "CHICAGO", destination state of "IL" classification "60" and weight "50"
Then I will not see Back to Quote List button

Scenario: 60340_Verify the Back to Quote List button is displayed on the quote confirmation screen when I am a specified user
Given I am Stationowner Operations Sales management or Sales user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I resize the window to the dimensions "375" "812"
When I land on quote results screen as a specified user "ZZZ - Czar Customer Test" with an origin zip "94538", origin city of "Fremont", origin state of "CA" destination zip "60657", destination city of "CHICAGO", destination state of "IL" classification "60" and weight "50"
And I navigate to the quote confirmation page
Then I see Back to Quote List button

Scenario: 60340_Verify the Back to Quote List button is not displayed on the quote confirmation screen when I am not a specified user
Given I am not a Stationowner Operations Sales management or Sales user "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
And I resize the window to the dimensions "375" "812"
When I land on quote results screen with an origin zip "94538", origin city of "Fremont", origin state of "CA" destination zip "60657", destination city of "CHICAGO", destination state of "IL" classification "60" and weight "50"
And I navigate to the quote confirmation page
Then I will not see Back to Quote List button

Scenario: 60340_Verify the Back to Quote List button is displayed on the no quote results screen when I am a specified user
Given I am Stationowner Operations Sales management or Sales user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I resize the window to the dimensions "375" "812"
When I navigate to the no quote results page
Then I see Back to Quote List button

Scenario: 60340_Verify the Back to Quote List button is not displayed on the no quote results screen when I am not a specified user
Given I am not a Stationowner Operations Sales management or Sales user "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
And I resize the window to the dimensions "375" "812"
When I navigate to the no quote results page
Then I will not see Back to Quote List button

Scenario: 60340_Verify Est Cost and Margin is displayed below the quote results grid when I am a specified user
Given I am Stationowner Operations Sales management or Sales user "username-CurrentSprintOperations" "password-CurrentSprintOperations"
And I resize the window to the dimensions "375" "812"
When I land on quote results screen as a specified user "ZZZ - Czar Customer Test" with an origin zip "94538", origin city of "Fremont", origin state of "CA" destination zip "60657", destination city of "CHICAGO", destination state of "IL" classification "60" and weight "50"
Then I will see Est Cost below fields in results grid
And I will see Est Margin below fields in results grid

Scenario: 60340_Verify Est Cost and Margin is not displayed below the quote results grid when I am not a specified user
Given I am not a Stationowner Operations Sales management or Sales user "username-CurrentSprintshpentry" "password-CurrentSprintshpentry"
And I resize the window to the dimensions "375" "812"
When I land on quote results screen with an origin zip "94538", origin city of "Fremont", origin state of "CA" destination zip "60657", destination city of "CHICAGO", destination state of "IL" classification "60" and weight "50"
Then I will not see Est Cost below fields in results grid
Then I will not see Est Margin below fields in results grid