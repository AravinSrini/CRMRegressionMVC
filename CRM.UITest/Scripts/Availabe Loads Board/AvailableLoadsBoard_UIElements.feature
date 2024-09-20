@Sprint8_Ninja @35208 @Regression
Feature: AvailableLoadsBoard_UIElements

@GUI
Scenario Outline:35208 - Verify navigation functionality to available Loads Board Page
Given that I am any user,
When I open the Available Loads URL <URL>,
Then I will arrive on the Available Loads page.

Examples:
| URL                                             |
| http://dlscrm-test.rrd.com/AvailableLoads/Index |

@GUI
Scenario Outline:35208 - Verify the fields displaying in available Loads Board Page
Given that I am any user,
When I open the Available Loads URL <URL>,
Then I will see the rrd DLS Worldwide logo,
And I will see  DLS contact phone information <844-221-6724>,
And I will see the Available Loads grid display options,
And I have the option to page forward or backward,
And I will see a search option,
And the grid will display the following columns Ref #, Pickup Range, Delivery Range, Origin, Destination, # of P/U, # of Drops, Weight(LBS), Equip Type
And each available load displayed will have an email button,
And I will have an option to refresh the available loads page.

Examples: 
| URL                                             |
| http://dlscrm-test.rrd.com/AvailableLoads/Index |

@GUI @Functional
Scenario Outline:35208 - Verify the search and highlight functionality in page
Given that I am any user,
When I open the Available Loads URL <URL>,
And I type in any value in the Search field  <SearchValue> 
Then the grid should be filtered and highlighted for matching values in all the columns <SearchValue> 

Examples:
| URL                                             | SearchValue |
| http://dlscrm-test.rrd.com/AvailableLoads/Index | 1           |

@GUI @Functional
Scenario Outline:35208 - Verify the grid when invalid data is searched

Given that I am any user,
When I open the Available Loads URL <URL>,
And I type in any value in the Search field  <InvalidSearchValue>
Then no results found message should be displayed

Examples:
| URL                                             | InvalidSearchValue |
| http://dlscrm-test.rrd.com/AvailableLoads/Index | test@12345         |

@GUI @Functional
Scenario Outline:35208 - Verify the grid filtering functionality on changing the view option
Given that I am any user,
When I open the Available Loads URL <URL>,
And I select any view <Option> 
Then selected view <Option> should be filtered in the grid

Examples:
| URL                                             | Option |
| http://dlscrm-test.rrd.com/AvailableLoads/Index | 20     |


@Functional
Scenario Outline:35208 - Compare and verify the displaying records with API
Given that I am any user,
When I open the Available Loads URL <URL>,
Then displaying values in the grid should match with API

Examples: 
| URL                                             |
| http://dlscrm-test.rrd.com/AvailableLoads/Index |

@Functional
Scenario Outline:35208 - Compare and verify the displaying records with API after refresh button
Given that I am any user,
When I open the Available Loads URL <URL>,
And I click on refresh button
Then displaying values in the grid should match with API

Examples: 
| URL                                             |
| http://dlscrm-test.rrd.com/AvailableLoads/Index |

@Functional @Sprint76 @37979
Scenario Outline: 37979 - Verify displaying Pickup and Delivery date with API
Given that I am any user,
When I open the Available Loads URL <URL>,
Then Displaying Pickup and Delivery date should match with API 

Examples: 
| URL                                             |
| http://dlscrm-test.rrd.com/AvailableLoads/Index |


#---------------------------------------------------------------------------------------------------------------#
#Scenarios for 77434 - Available Loads - Add Phone Number to Grid
#---------------------------------------------------------------------------------------------------------------#

@77434 @Sprint91
Scenario: 77434_Verify the field Contact Phone displaying in Available Loads page
Given that I navigate to the CRM Available Loads web page
When the page loads
Then the Contact Phone Column will be displayed to the right of Equip Type
And the value for Contact Phone will be the Available Load Phone from the associated Station details

@77434 @Sprint91
Scenario: 77434_Verify the Contact number empty when there is no load to the corresponding station
Given that I navigate to the CRM Available Loads web page
And corresponding station to a Load is not available in CRM
When the page loads
Then I will see the Contact Number with empty value for that load
