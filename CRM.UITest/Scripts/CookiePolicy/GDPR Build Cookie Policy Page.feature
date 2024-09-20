@43793 @NinjaSprint19
Feature: GDPR Build Cookie Policy Page

@GUI @Functional
Scenario: 43793_Verify User will navigate to cookie details page
Given I am any user on any CRM page
When I click Read More in the cookie description popup
Then I will navigate to the new cookie details page

@GUI
Scenario: 43793_Verify User will see Sign In Button on Cookie Details Page
Given I am any user on any CRM page
And I click Read More in the cookie description popup
When I will navigate to the new cookie details page
Then I will see Sign in Button on Right Top Corner

@GUI
Scenario: 43793_Verify User will see CookiePolicy, ToReviewRRDsCookiePolicy, LastUpdate Labels
Given I am any user on any CRM page
And I click Read More in the cookie description popup
When I will navigate to the new cookie details page
Then I will see Cookie Policy label
And I will see To Review RRD's Cookie Policy label
And I will see Last Update on label

@GUI @Functional
Scenario: 43793_Verify User will see Cookie Details that is available in db
Given I am any user on any CRM page
And I click Read More in the cookie description popup
When I will navigate to the new cookie details page
Then I will see all cookie types available in db
And I will see last updated time from db
And I will see description for that cookie
And I will see cookie part type name
And I will see list of cookie name value
And I will see cookie part type name value
And I will see cookie life span value
And I will see cookie purpose description