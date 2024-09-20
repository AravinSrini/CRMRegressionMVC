@Sprint76 @38097 

Feature: Master Carrier Rate Settings - Delete Individual Accessorials
	
@GUI	
Scenario Outline: 38097-Verify the Delete Accessorial button on the Master Carrier Rate settings page
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   Then Verify I should be able to see the Delete Accessorial button

Examples: 
| Scenario | Username    | Password | Customer               |
| S1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |

@GUI
Scenario Outline: 38097-Verify the Delete Accessorial button is not displayed when I have not selected the customer on Master Carrier Rate Settings page
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   Then I should not be able to see the Delete Accessorial button
Examples: 
| Scenario | Username | Password |
|  S1      |systemadmin | Te$t1234 |


@GUI
Scenario Outline: 38097-Verify the Delete Accessorial button is in Active when I select the Carrier
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
       And I select any one of the listed carriers from the grid 
	   Then Verify the Delete Accessorial button is in Active state
Examples: 
| Scenario | Username    | Password | Customer               |
| S1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |   


@GUI 
Scenario Outline: 38097-Verify the Delete Accessorial button is in InActive when I select do not select the carrier
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
       Then Verify the Delete Accessorial button is in InActive State
Examples: 
| Scenario | Username    | Password | Customer               |
| S1       | systemadmin | Te$t1234 | ZZZ - GS Customer Test |


@GUI @Functional
Scenario Outline: 38097-Verify the Delete Accessorials functionality for the Single carrier of the customer associated with the one or more Individual Accessorials
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select any one of the listed carriers from the grid	   
	   Then I can see the Delete Accessorial modal with the associated accessorials of the single carrier
Examples: 
| Scenario | Username    | Password | Customer           |
| S1       | systemadmin | Te$t1234 | MGRMapprovalGSMin1 |    

@GUI @Functional
Scenario Outline: 38097-Verify the Delete Accessorials functionality for the multiple carrier of the customer associated with one or more Individual Accessorials
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select multiple carriers of the listed carriers from the grid 
	   Then I can be able to see the Delete Accessorial modal with the associated accessorials for multiple carrier


Examples: 
| Scenario | Username    | Password | Customer                   |
| S1       | systemadmin | Te$t1234 | CSARMapprovalGSMasterAcc10 |                          


@GUI @Functional 
Scenario Outline: 38097-Verify the message when selected carrier do not have any individual accessorials associated for the customer
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select any carrier which does not have accessorials 
	   And I Click on the Delete Accessorials button for no accessorials
	   Then I should see message <ErrorMessage> for the carrier selected which does not have any individual accessorials

Examples: 
| Scenario | Username    | Password | Customer         | ErrorMessage                                                    |
| S1       | systemadmin | Te$t1234 | TestingMgTab     | The carrier(s) selected do not have any individual accessorials |


@GUI @Functional 
Scenario Outline: 38097-Verify the navigation of the page after acknowledgement of the message for the selected carriers do have any individual accessorials
      Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select any carrier which does not have accessorials 
	   And I Click on the Delete Accessorials button for no accessorials
	   And when I acknowledge the error message
	   Then I should be navigated to the Master Carrier Rate Settings page <PageHeaderText>
Examples: 
| Scenario | Username    | Password | Customer         | PageHeaderText               |
| S1       | systemadmin | Te$t1234 | TestingMgTab     | Master Carrier Rate Settings |

@GUI 
Scenario Outline: 38097-Verify the Delete Accessorial modal pop up 
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select any one of the listed carriers from the grid
	   And I Click on the Delete Accessorials button
	   Then Delete Accessorial modal should be displayed <DeleteAccessorialHeaderText>
	   And I can see the verbiage instructing to select the accessorials <Verbiage>
	   And I should see the Cancel and Delete button
Examples: 
| Scenario | Username    | Password | Customer                   | DeleteAccessorialHeaderText    | Verbiage                                                                                |
| S1       | systemadmin | Te$t1234 | CSARMapprovalGSMasterAcc10 | Delete Individual Accessorials | Select any or all of the individual accessorials to delete and click the delete button. |


@GUI 
Scenario Outline: 38097-Verify the scroll bar on the Delete Accessorials modal when accessorials is more than 5 
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select any one of the listed carriers from the grid
	   And I click on the Set Accessorial button to add the accessorials more than five <Accessorial1>,<Accessorial2>,<Accessorial3>,<Accessorial4>,<Accessorial5>,<Accessorial6>
	   And I select any one of the listed carriers from the grid
	   And I Click on the Delete Accessorials button
	   Then I should see the scroll bar when accessorials is more than five
Examples: 
| Scenario | Username    | Password | Customer         | Accessorial1 | Accessorial2 | Accessorial3      | Accessorial4                        | Accessorial5                      | Accessorial6                     |
| S1       | systemadmin | Te$t1234 | CarrierBypassCSR | Appointment  | COD          | Construction Site | Convention-Exhibition Site Delivery | Convention-Exhibition Site Pickup | Excessive Overlength (LKVL Only) |


@GUI 
Scenario Outline: 38097-Verify the cancel functionality on the Delete Accessorials modal
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select any one of the listed carriers from the grid
	   Then Verify the Cancel button functionality
	   
Examples: 
| Scenario | Username    | Password | Customer         |
| S1       | systemadmin | Te$t1234 | CarrierBypassCSR |


@GUI 
Scenario Outline: 38097-Verify the Delete functionality on the Delete Accessorials modal
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select any one of the listed carriers from the grid
	   And I click on the Set Accessorial button and add the accessorials <Accessorial1>,<Accessorial2>,<Accessorial3>,<Accessorial4>
	   And I select any one of the listed carriers from the grid	  
	   Then I should not be able to see the Deleted accessorials in the grid and it should display NA for the deleted accessorials of the selected carriers
Examples: 
| Scenario | Username    | Password | Customer         | Accessorial1 | Accessorial2 | Accessorial3      | Accessorial4                        | 
| S1       | systemadmin | Te$t1234 | haritestcustomer | Appointment  | COD          | Construction Site | Convention-Exhibition Site Delivery | 




@GUI 
Scenario Outline: 38097-Verify the grid when all the listed carriers of individual accessorials is deleted
       Given I am System admin or Pricing Configuration User <Username> and <Password>
	   When I am on the Master Carrier Rate Settings page
	   And I select <Customer> from the Customer drop down list
	   And I select all the carriers in the list
	   And I click on the Set Accessorial button and add the accessorials <Accessorial1>,<Accessorial2>,<Accessorial3>,<Accessorial4>
	   And I select all the carriers in the list
	   Then no individual accessorials will be displayed in the refreshed grid when I delete all the individual accessorials
Examples: 
| Scenario | Username    | Password | Customer   | Accessorial1 | Accessorial2 | Accessorial3      | Accessorial4                        |
| S1       | systemadmin | Te$t1234 | myCRMlogic | Appointment  | COD          | Construction Site | Convention-Exhibition Site Delivery |
