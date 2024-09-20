@Sprint8_Ninja @35434
Feature: EmailModal
	
@GUI
Scenario Outline:35434 - Verify the UI fields of email modal navigated from the Available LoadBoard page
Given I am any user and on the Available Loads page<URL> ,
When I click on the email button of any displayed load from the grid,
Then an email modal will open,
And I should see To email address non editable text box with pre filled email id <ToEmailId> as a default value
And I should see From email address editable text box 
And I should see Subject non editable text box with pre filled value
And I should see the body of the email editable text box
And I should see a send and cancel Buttons

Examples:
| URL                                             | ToEmailId               |
| http://dlscrm-test.rrd.com/AvailableLoads/Index | tst.admnsys16@gmail.com |

@GUI
Scenario Outline:35434 - Verify max length for the body of the email text box
Given I am any user and on the Available Loads page<URL> ,
When I click on the email button of any displayed load from the grid,
Then an email modal will open,
And I should be able to enter only 250 alphanumeric and special characters <Text>

Examples:
| URL                                             | Text     |
| http://dlscrm-test.rrd.com/AvailableLoads/Index | Test@123 |

@GUI
Scenario Outline:35434 - Verify the invalid email validation for from address text box
Given I am any user and on the Available Loads page<URL> ,
When I click on the email button of any displayed load from the grid,
Then an email modal will open,
And I enter invalid email '<InvalidEmail>' in From email text box
And I click on Send button
Then email text box should be highlighted and displayed with error message for invalid 

Examples:
| URL                                             | InvalidEmail |
| http://dlscrm-test.rrd.com/AvailableLoads/Index | test         |

@GUI
Scenario Outline:35434 - Verify the functionality of cancel button within email popup
Given I am any user and on the Available Loads page<URL> ,
When I click on the email button of any displayed load from the grid,
Then an email modal will open,
And I Click on cancel button within email model popup
Then I will arrive on the Available Loads page.

Examples:
| URL                                             | 
| http://dlscrm-test.rrd.com/AvailableLoads/Index | 







