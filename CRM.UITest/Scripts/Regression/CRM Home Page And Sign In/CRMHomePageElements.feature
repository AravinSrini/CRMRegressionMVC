@New_Regression
Feature: CRMLandingPage

Scenario: Verify the new CRM Landing Page page elements are visible on the screen
Given I navigate to the homepage
When I am on the home page
Then I will see the rrd dls worldwide logo
And the Sign In button must appear on the top right corner with the text 'Sign In'
And I will see the track up to 10 shipments by reference number area
And I will see the track multiple shipments by file upload area
And I will see the privacy policy link
And I will see the terms of use link
And I will see the cookies section

Scenario: Clicking the logo redirects to rrdonnelley home page
Given I navigate to the homepage
When I click the rrd dls worldwide logo
Then I will be redirected to the RR Donnelley home page

Scenario: Clicking on the privacy policy link will redirect to rr donnelley privacy policy page
Given I navigate to the homepage
When I click the privacy policy link
Then I will be redirected to the privacy policy page for R R Donnelley

Scenario: Clicking on the terms of use link will redirect to rr donnelley terms of use page
Given I navigate to the homepage
When I click the terms of use link
Then I will be redirected to the terms of use page for R R Donnelley

Scenario: Clicking on I agree on cookie script removes cookie script from view
Given I navigate to the homepage
When I click on I Agree on the cookie script section
Then the cookie script section will dissappear from view

Scenario: Clicking on I disagree on cookie script removes cookie script from view
Given I navigate to the homepage
When I click on I Disagree on the cookie script section
Then the cookie script section will dissappear from view

Scenario: Clicking on read more on cookie script loads the cookie policy
Given I navigate to the homepage
When I click on read more on the cookie script section
Then I will get a new tab with the cookie policy page

Scenario Outline: Attempting to log in with valid results will log in successfully
Given I navigate to the homepage
And I click on the sign in button
And I enter login name as <Username> and password as <Password>
When I click on log in
Then I will be redirected to the dashboard
Examples: 
| Username                            | Password                            |
| username-CurrentSprintshpentry      | password-CurrentSprintshpentry      |
| username-CurrentSprintOperations    | password-CurrentSprintOperations    |
| username-CurrentSprintconfigmanager | password-CurrentSprintconfigmanager |
| username-CurrentSprintSales         | password-CurrentSprintSales         |
| username-CurrentSprintStationowner  | password-CurrentSprintStationowner  |