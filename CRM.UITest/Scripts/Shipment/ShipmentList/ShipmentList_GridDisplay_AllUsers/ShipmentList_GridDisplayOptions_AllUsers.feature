@Sprint68 @26799
Feature: ShipmentList_GridDisplayOptions_AllUsers

@GUI
Scenario Outline: Verify default grid display option on the page load
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	Then only ten records should be displayed by default in shipment list page

Examples:
| Scenario | Username       | Password |
| S1       | zzzext         | Te$t1234 |
| S2       | stationown     | Te$t1234 |


@GUI
Scenario Outline: Verify view options present in top grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on view dropdown present in top grid of shipment list page
	Then I should be able to view <Options> under dropdown in top grid of shipment list page

Examples:
| Scenario | Username   | Password | Options          |
| S1       | zzzext     | Te$t1234 | 10,20,60,100,ALL |
| S2       | stationown | Te$t1234 | 10,20,60,100,ALL |

@GUI
Scenario Outline: Verify view options present in bottom grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on view dropdown present in bottom grid of shipment list page
	Then I should be able to view <Options> under dropdown in bottom grid of shipment list page

Examples:
| Scenario | Username   | Password | Options          |
| S1       | zzzext     | Te$t1234 | 10,20,60,100,ALL |
| S2       | stationown | Te$t1234 | 10,20,60,100,ALL |

@GUI @Funcitonal
Scenario Outline: Verify the functionality of right navigation icon in top grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on right navigation icon in top grid of shipment list page
	Then Next set of records should be displayed in shipment list page
	And left navigation icon should be enabled in top grid of the shipment list page


Examples:
| Scenario | Username   | Password |
| S1       | zzzext     | Te$t1234 |
| S2       | stationown | Te$t1234 |


@GUI @Funcitonal
Scenario Outline: Verify the functionality of right navigation icon in bottom grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I arrive on shipment list page
	And I click on right navigation icon in bottom grid of shipment list page
	Then Next set of records should be displayed in shipment list page
	And left navigation icon should be enabled icon in bottom grid of the shipment list page


Examples:
| Scenario | Username   | Password |
| S1       | stationown | Te$t1234 |
| S2       | zzzext     | Te$t1234 |

@GUI @Funcitonal
Scenario Outline: Verify the functionality of left navigation icon in top grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on right navigation icon in top grid of shipment list page
	And I click on left navigation icon in top grid of shipment list page
	Then previous default records should be displayed in shipment list page


Examples:
| Scenario | Username   | Password |
| S1       | stationown | Te$t1234 |
| S2       | zzzext     | Te$t1234 |

@GUI @Funcitonal
Scenario Outline: Verify the functionality of left navigation icon in bottom grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on right navigation icon in bottom grid of shipment list page
	And I click on left navigation icon in bottom grid of shipment list page
	Then previous default records should be displayed in shipment list page


Examples:
| Scenario | Username   | Password |
| S1       | stationown | Te$t1234 |
| S2       | zzzext     | Te$t1234 |

@GUI @Funcitonal
Scenario Outline: Verify number of records on chainging view option present in top grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on view dropdown present in top grid of shipment list page
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then Selected <Option> records should be displayed in shipment list page


Examples:
| Scenario | Username   | Password | Option |
| S1       | zzzext     | Te$t1234 | 20     |
| S2       | stationown | Te$t1234 | 20     |

@GUI @Funcitonal
Scenario Outline: Verify number of records on chainging view option present in bottom grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on view dropdown present in bottom grid of shipment list page
	And I select any <Option> from view dropdown present in bottom grid of shipment list page
	Then Selected <Option> records should be displayed in shipment list page

Examples:
| Scenario | Username   | Password | Option |
| S1       | zzzext     | Te$t1234 | 20     |
| S2       | stationown | Te$t1234 | 20     |

@GUI @Funcitonal
Scenario Outline:  Verify text on chainging view option present in top grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on view dropdown present in top grid of shipment list page
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then text in top grid should match with selected <Option> in shipment list page


Examples:
| Scenario | Username | Password | Option |
| S1       | zzzext     | Te$t1234 | 20     |
| S2       | stationown | Te$t1234 | 20     |

@GUI @Funcitonal
Scenario Outline:  Verify text on chainging view option present in bottom grid of shipment list page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I click on view dropdown present in bottom grid of shipment list page
	And I select any <Option> from view dropdown present in bottom grid of shipment list page
	Then text in bottom grid should match with selected <Option> in shipment list page


Examples:
| Scenario | Username   | Password | Option |
| S1       | zzzext     | Te$t1234 | 20     |
| S2       | stationown | Te$t1234 | 20     |

@GUI @Funcitonal
Scenario Outline:  Verify the right navigation icon when number of records are less than view option in top grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then right navigation icon should be disabled in top grid in shipment list page when number of records are less than view <Option>

Examples:
| Scenario | Username   | Password | Option |
| S1       | zzzext     | Te$t1234 | 20     |
| S2       | stationown | Te$t1234 | 20     |

@GUI @Funcitonal
Scenario Outline:  Verify the right navigation icon when number of records are less than view option in bottom grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I select any <Option> from view dropdown present in bottom grid of shipment list page
	Then right navigation icon should be disabled in bottom grid in shipment list page when number of records are less than view <Option>


Examples:
| Scenario | Username   | Password | Option |
| S1       | zzzext     | Te$t1234 | 20     |
| S2       | stationown | Te$t1234 | 20     |

@GUI @Funcitonal
Scenario Outline:  Verify the left navigation icon when default records displaying
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	Then left navigation icon should be disabled in top grid in shipment list page
	And left navigation icon should be disabled in bottom grid in shipment list page

Examples:
| Scenario | Username   | Password | 
| S1       | zzzext     | Te$t1234 | 
| S2       | stationown | Te$t1234 | 

@GUI @Funcitonal
Scenario Outline:  Verify the navigation icons when All option is selected from view dropdown in top grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then right navigation icon should be disabled in top grid in shipment list page
	And left navigation icon should be disabled in top grid in shipment list page

Examples:
| Scenario | Username   | Password | Option |
| S1       | zzzext     | Te$t1234 | ALL    |
| S2       | stationown | Te$t1234 | ALL    |

@GUI @Funcitonal
Scenario Outline:  Verify the navigation icons when All option is selected from view dropdown in bottom grid
	Given I am a DLS user and login into application with valid <Username> and <Password>
	When I click on the Shipment Icon
	And I select any <Option> from view dropdown present in top grid of shipment list page
	Then right navigation icon should be disabled in bottom grid in shipment list page
	And left navigation icon should be disabled in bottom grid in shipment list page

Examples:
| Scenario | Username   | Password | Option |
| S1       | zzzext     | Te$t1234 | ALL    |
| S2       | stationown | Te$t1234 | ALL    |



