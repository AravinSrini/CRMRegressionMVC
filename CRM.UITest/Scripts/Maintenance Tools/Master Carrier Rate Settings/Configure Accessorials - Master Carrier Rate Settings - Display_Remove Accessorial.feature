@Sprint85 @46949 
Feature: Configure Accessorials - Master Carrier Rate Settings - Display_Remove Accessorial

@Functional
Scenario Outline: 46949_Test to verify the Added Accessorials on Master Carrier Rate Settings page_Set Individual Accessorials modal
Given I am a pricing config or config manager user
And an accessorial was added on the Configure Accessorials page
And I am on the Master Carrier Rate Settings page
And I selected a customer
And I selected one or more carriers <Number of Carriers selected>
And I click on the Set Accessorials button
When I click in the Select Accessorial Type field of the Set Individual Accessorials modal
Then I should see the accessorial displayed in the drop down list

Examples:
| Number of Carriers selected |
| One                         |
| More                        |

@Functional
Scenario Outline: 46949_Test to verify the Added Accessorials on Master Carrier Rate Settings page_Set Individual Accessorials modal_Add Another Accessorial
Given I am a pricing config or config manager user
And an accessorial was added on the Configure Accessorials page
And I am on the Master Carrier Rate Settings page
And I selected a customer
And I selected one or more carriers <Number of Carriers selected>
And I click on the Set Accessorials button
And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
When I click in the second Select Accessorial Type dropdown of the Set Individual Accessorials modal
Then I should see the accessorial displayed in the drop down list of add another accessorial

Examples:
| Number of Carriers selected |
| One                         |
| More                        |

@Functional
Scenario Outline: 46949_Test to verify the deleted Accessorials on Master Carrier Rate Settings page_Set Individual Accessorials modal
Given I am a pricing config or config manager user
And an accessorial was deleted on the Configure Accessorials page
And I am on the Master Carrier Rate Settings page
And I selected a customer
And I selected one or more carriers <Number of Carriers selected>
And I click on the Set Accessorials button
When I click in the Select Accessorial Type field of the Set Individual Accessorials modal
Then I will NOT see the deleted accessorial displayed in the drop down list

Examples:
| Number of Carriers selected |
| One                         |
| More                        |

@Functional
Scenario Outline: 46949_Test to verify the deleted Accessorials on Master Carrier Rate Settings page_Set Individual Accessorials modal_Add Another Accessorial
Given I am a pricing config or config manager user
And an accessorial was deleted on the Configure Accessorials page
And I am on the Master Carrier Rate Settings page
And I selected a customer
And I selected one or more carriers <Number of Carriers selected>
And I click on the Set Accessorials button
And I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal
When I click in the second Select Accessorial Type dropdown of the Set Individual Accessorials modal
Then I will NOT see the deleted accessorial displayed in the drop down list for add another accessorial

Examples:
| Number of Carriers selected |
| One                         |
| More                        |