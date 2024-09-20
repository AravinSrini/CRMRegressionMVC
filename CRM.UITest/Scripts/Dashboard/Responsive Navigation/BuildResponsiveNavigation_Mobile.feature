@Sprint59 @17389 @BuildResponsiveNavigation
Feature: BuildResponsiveNavigation_Mobile
	
@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the Dashboard module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Dashboard icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Dashboard Menu available in the Landing Page navigate to Dashboard landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     |		

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the Quotes  module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Quotes icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | 
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     | 

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the Shipments module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Shipments icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Shipments Menu available in the Landing Page navigate to Shipments landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | Shipmentstext |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     | Shipments     |

@GUI @Functional
Scenario Outline: Verify that every user can able to see the Tracking icon and able to navigate for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Tracking icon in the left navigation menu of Landing Page
	Then I Click on the Tracking icon available in the menu
	And I should see the text '<Trackingtext>' in the Tracking landing page

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | Trackingtext |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     | Tracking     |

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the Commissions module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Commissions icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Commissions Menu available in the Landing Page navigate to Commissions landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown | 
	| S1       | mem      | Te$t1234 | 640         | 768          | TEST MEM     |

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the Document Repository module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Document Repository icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Document Repository Menu available in the Landing Page navigate to Document Repository landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     |

@GUI @Functional @DBVerification
Scenario Outline: Verify that user can able to navigate to the Rating Tools module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Rating Tools icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Rating Tools Menu available in the Landing Page navigate to Rating Tools landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username        | Password | WindowWidth | WindowHeight | UserDropdown |
	| S1       | globalentryuser | Te$t1234 | 640         | 768          | DSASD SDSADD |

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the Reports module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Reports icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Reports Menu available in the Landing Page navigate to Reports landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown |
	| S1       | mem      | Te$t1234 | 640         | 768          | TEST MEM     |

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the User Management module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see User Management icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the User Management Menu available in the Landing Page navigate to User Management landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown |
	| S1       | mem      | Te$t1234 | 640         | 768          | TEST MEM     |

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the Training module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Training icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Training Menu available in the Landing Page navigate to Training landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown |
	| S1       | mem      | Te$t1234 | 640         | 768          | TEST MEM     |

@GUI @Functional
Scenario Outline: Verify that user can able to navigate to the Maintenance Tools module when user has required Priviliges for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Maintenance Tools icon in the left navigation menu of Landing Page if '<Username>' have claim
	Then I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim

	Examples: 
	| Scenario | Username       | Password | WindowWidth | WindowHeight | UserDropdown |
	| S1       | crmSystemAdmin | Te$t1234 | 640         | 768          | SYSTEM ADMIN |

@GUI @Functional
Scenario Outline: Verify that user can able to collapse left navigation when click on hamburger menu icon floating in the upper left and able to navigate for mobile device
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
	And I am landing on DLS Worldwide homepage with RRD logo
	And I should not see the '<UserDropdown>'
	And  I click on the on hamburger menu icon
	When I should see Tracking icon in the left navigation menu of Landing Page
	And  I click on the on hamburger menu icon in the mobile device
	Then I should not see Tracking icon in the left navigation menu of Landing Page

	Examples: 
	| Scenario | Username | Password | WindowWidth | WindowHeight | UserDropdown |
	| S1       | zzz      | Te$t1234 | 640         | 768          | ZZZ TEST     |
