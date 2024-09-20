@26659 @Sprint67
Feature: QuoteList_GridDisplayOptions

@GUI
Scenario Outline: Verify default grid display option on the page load
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	Then only ten records should be displayed by default 

Examples:
| Scenario | Username           | Password |
| S1       | gbartus@dls-ww.com | Te$t1234 |

@GUI
Scenario Outline: Verify view options present in top grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on view dropdown present in top grid of quote list page
	Then I should be able to see <Options>

Examples:
| Scenario | Username           | Password | Options          |
| S1       | gbartus@dls-ww.com | Te$t1234 | 10,20,60,100,ALL |

@GUI
Scenario Outline: Verify view options present in bottom grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on view dropdown present in bottom grid of quote list page
	Then I should be able to see <Options>

Examples:
| Scenario | Username           | Password | Options          |
| S1       | gbartus@dls-ww.com | Te$t1234 | 10,20,60,100,ALL |

@GUI @Functional
Scenario Outline: Verify the functionality of right navigation icon in top grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on right navigation icon in top grid of quote list page
	Then Next set of records should be displayed in quote list page
	And left navigation should be enabled icon in top grid of the quote list page

Examples:
| Scenario | Username           | Password |
| S1       | gbartus@dls-ww.com | Te$t1234 |  

@GUI @Functional
Scenario Outline: Verify the functionality of right navigation icon in bottom grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on right navigation icon in bottom grid of quote list page
	Then Next set of records should be displayed in quote list page
	And left navigation should be enabled icon in bottom grid of the quote list page

Examples:
| Scenario | Username           | Password |
| S1       | gbartus@dls-ww.com | Te$t1234 |

@GUI @Functional
Scenario Outline: Verify the functionality of left navigation icon in top grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on right navigation icon in top grid of quote list page
	And I click on left navigation icon in top grid of quote list page
	Then previous default records should be displayed in quote list page

Examples:
| Scenario | Username           | Password |
| S1       | gbartus@dls-ww.com | Te$t1234 |

@GUI @Functional
Scenario Outline: Verify the functionality of left navigation icon in bottom grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on right navigation icon in bottom grid of quote list page
	And I click on left navigation icon in bottom grid of quote list page
	Then previous default records should be displayed in quote list page

Examples:
| Scenario | Username           | Password |
| S1       | gbartus@dls-ww.com | Te$t1234 |

@GUI @Functional
Scenario Outline: Verify number of records on chainging view option present in top grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on view dropdown present in top grid of quote list page
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then Selected <Option> records should be displayed in quote list page

Examples:
| Scenario | Username           | Password | Option |
| S1       | gbartus@dls-ww.com | Te$t1234 | 20     |

@GUI @Functional
Scenario Outline: Verify number of records on chainging view option present in bottom grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on view dropdown present in bottom grid of quote list page
	And I select any <Option> from view dropdown present in bottom grid of quote list page
	Then Selected <Option> records should be displayed in quote list page

Examples:
| Scenario | Username           | Password | Option |
| S1       | gbartus@dls-ww.com | Te$t1234 | 20     |

@GUI @Functional
Scenario Outline: Verify text on chainging view option present in top grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on view dropdown present in bottom grid of quote list page
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then text in top grid should match with selected <Option> in quote list page

Examples:
| Scenario | Username           | Password | Option |
| S1       | gbartus@dls-ww.com | Te$t1234 | 20     |

@GUI @Functional
Scenario Outline: Verify text on chainging view option present in bottom grid of quote list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I click on view dropdown present in bottom grid of quote list page
	And I select any <Option> from view dropdown present in bottom grid of quote list page
	Then text in bottom grid should match with selected <Option> in quote list page

Examples:
| Scenario | Username           | Password | Option |
| S1       | gbartus@dls-ww.com | Te$t1234 | 20     |

@GUI @Functional
Scenario Outline: Verify the right navigation icon when number of records are less than view option in top grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then right navigation icon should be disabled in top grid in quote list page when number of records are less than view <Option>

Examples:
| Scenario | Username           | Password | Option |
| S1       | gbartus@dls-ww.com | Te$t1234 | 60     |

@GUI @Functional
Scenario Outline: Verify the right navigation icon when number of records are less than view optoion in bottom grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	And I select any <Option> from view dropdown present in top grid of quote list page
	Then right navigation icon should be disabled in bottom grid in quote list page when number of records are less than view <Option>

Examples:
| Scenario | Username           | Password | Option |
| S1       | gbartus@dls-ww.com | Te$t1234 | 60     |

@GUI @Functional
Scenario Outline: Verify the left navigation icon when default records displaying
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
	Then left navigation icon should be disabled in top grid in quote list page
	And left navigation icon should be disabled in bottom grid in quote list page

Examples:
| Scenario | Username           | Password |
| S1       | gbartus@dls-ww.com | Te$t1234 | 

@GUI @Functional
Scenario Outline: Verify the navigation icons when All option is selected from view dropdown in top grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
    And I select any <Option> from view dropdown present in top grid of quote list page
	Then right navigation icon should be disabled in top grid in quote list page
	And left navigation icon should be disabled in top grid in quote list page

Examples:
| Scenario | Username           | Password | Option |
| S1       | gbartus@dls-ww.com | Te$t1234 | ALL    |

@GUI @Functional
Scenario Outline: Verify the navigation icons when All option is selected from view dropdown in bottom grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Quote Icon
    And I select any <Option> from view dropdown present in bottom grid of quote list page
	Then right navigation icon should be disabled in bottom grid in quote list page
	And left navigation icon should be disabled in bottom grid in quote list page

Examples:
| Scenario | Username           | Password | Option |
| S1       | gbartus@dls-ww.com | Te$t1234 | ALL    |
