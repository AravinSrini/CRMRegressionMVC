@Sprint85 @48169
Feature: 48169-MaintenanceTools-ConfigureAccessorials_Delete

@GUI
Scenario:48169-Verify the Delete Accessorial modal UI elements
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
And I am on the Configure Accessorials page
When I Click on the Delete icon of any displayed accessorial
Then the Delete Accessorial Modal will open
And the Delete Accessorial modal will display the accessorial name
And I will see the accessorial name to be deleted in the modal
And I will see the verbiage <Deleting will remove this accessorial from CRM.  Are you sure you want to delete this accessorial?>
And I will see a Cancel Button
And I will see a Delete Button



@Functional
Scenario:48169-Verify the Delete Accessorial modal Cancel button functionality
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
And I am on the Configure Accessorials page
And I clicked on the Delete icon of any Displayed accessorial
And the Delete Accessorial Modal opened
When I click on the Cancel Button
Then the Modal will close


@Functional
Scenario:48169-Verify the Delete Accessorial modal Delete button functionality
Given that I am a Config Manager user
And I am on the Maintenance Tools page
And I clicked On the Configure Accessorials Button
And I am on the Configure Accessorials page
And I clicked on the Delete icon of any Displayed accessorial
And the Delete Accessorial Modal opened
When I click on the Delete Button
Then the delete modal will close
And the accessorial will be deleted
And the deleted accessorial will not be displayed on the Configure Accessorials page

