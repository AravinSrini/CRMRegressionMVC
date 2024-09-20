@26679 @Sprint67 

Feature: Quote List Info Icon for DomForAnd Intl Quotes

@GUI
Scenario Outline: Verify existence of Information icon in the quote list grid for service type in the Service column
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button for external users
When I arrive on quotes list page
Then I must be able to view Information icon displayed next to the service type in the Service column

Examples: 
| Username         | Password |
| zzzcsa@stage.com | Te$t1234 |

@GUI
Scenario Outline:Verify display of Service type and Service level values on click of Information icon for service type Domestic Forwarding or International
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button for external users
When I arrive on quotes list page
And I click on Information icon
Then I must be able to view a pop-up modal with <ServiceType> and <ServiceLevel> values

Examples: 
| Username         | Password | ServiceType     | ServiceLevel | 
| zzzcsa@stage.com | Te$t1234 | Next Flight Out | N/A          |

@Functional 
Scenario Outline:Compare and verify Service type and Service level values displayed in UI with API 
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button for external users
When I arrive on quotes list page
And I click on Information icon
Then The values in UI should match the API values <Account>

Examples: 
| Username         | Password | Account           |
| zzzcsa@stage.com | Te$t1234 | Kim Manufacturing |

Scenario Outline: Verify that the Info icon is not present for MG Users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Quotes button
When I arrive on quotes list page
Then I should not be able to view Information Icon

Examples: 
| Username        | Password |
| zzzext@user.com | Te$t1234 |


