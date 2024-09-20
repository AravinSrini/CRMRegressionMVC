@Requote @Sprint64 @22698
Feature: LTL_RequoteAnExpiredQuote

@GUI
Scenario Outline: Verify the navigate functionality to the get quote (LTL) page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on Quote icon 
	When I click the option to re-quote an expired LTL quote
    Then I will be taken to the Get Quote (LTL) page
	
Examples: 
| Username | Password     |
| zzz      | Password@123 |

@Functional 
Scenario Outline: Verify the populated data in get quote (LTL) page on requote 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on Quote icon 
	When I click the option to re-quote an expired LTL quote
    Then I will be taken to the Get Quote (LTL) page
	And previously saved data should be displayed in the corresponding fields <Username>
	
Examples: 
| Username | Password     |
| zzz      | Password@123 |

@Functional 
Scenario Outline: Verify the edit functionality for the populated data in get quote (LTL) page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on Quote icon 
	When I click the option to re-quote an expired LTL quote
    Then I will be taken to the Get Quote (LTL) page
	And I should be able to edit the populated data <OriginCity>, <OriginState>, <OriginZip>,<DestCity>, <DestState>,<DestZip>
	
Examples: 
| Username | Password     | OriginCity | OriginState | OriginZip | DestCity | DestState | DestZip |
| zzz      | Password@123 | Acton      | ON          | L7J 0A1   | Acton    | ON        | L7J 0A1 |

@GUI @Functional
Scenario Outline: Verify the ship data in get quote(LTL) page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on Quote icon 
	When I click the option to re-quote an expired LTL quote
    Then I will be taken to the Get Quote (LTL) page
	And ship date should be defaulted the current date
	
Examples: 
| Username | Password |
| nat      | Te$t1234 |

@Functional
Scenario Outline: Verify the multiple items populated in get quote(LTL) page
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on Quote icon 
	When I click the option to re-quote an expired LTL quote
    Then I will be taken to the Get Quote (LTL) page
	And multiple items should be displayed in Get Quote (LTL) page <Username>
	
Examples: 
| Username | Password |
| nat      | Te$t1234 |


@Functional 
Scenario Outline: Try to navigate to rate results page without modifying any populated data 
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I click on Quote icon 
	When I click the option to re-quote an expired LTL quote
    Then I will be taken to the Get Quote (LTL) page
	And I click on view quote results button 
	And rate results page/ no rate results page should be displayed based on the entered information
	
Examples: 
| Username | Password     |
| zzz      | Password@123 |

	