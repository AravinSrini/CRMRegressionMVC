@97749 @NinjaSprint36
Feature: CustomFolderForExternalUsers

Scenario: 97749 - When opening the document repository no documents are displayed and the search button is disabled
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry or shp.entrynorates user "username-CurrentSprintShpEntry" "password-CurrentSprintShpEntry"
	And I have navigated to the Document Repository Page in CRM
	When I click on the tab for my custom documents folder
	Then I will not see any documents loaded in the results grid
	And I will not see the magnifying glass icon in the Search Documents text box
	And I will see a Search button associated to the Search Documents text box
	And the Search button is inactive
	And I will see a message in the grid Please use the Search field to find your documents.

Scenario: 97749 - When opening the document repository and selecting a customer folder the search button will be enabled when any text is entered
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry or shp.entrynorates user "username-CurrentSprintShpEntry" "password-CurrentSprintShpEntry"
	And I have navigated to the Document Repository Page in CRM
	And I click on the tab for my custom documents folder
	When I enter some value in the Search Documents field 
	Then the Search button will be enabled

Scenario: 97749 - When opening the document repository and selecting a customer folder the search button will be enabled when any text is entered and disabled when the search box is cleared
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry or shp.entrynorates user "username-CurrentSprintShpEntry" "password-CurrentSprintShpEntry"
	And I have navigated to the Document Repository Page in CRM
	And I click on the tab for my custom documents folder
	And I enter some value in the Search Documents field 
	When I clear the Search Documents field
	Then the Search button is inactive

Scenario: 97749 - When opening the document repository and selecting a customer folder then results for one year will be displayed and loaded in less than 5 seconds
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry or shp.entrynorates user "username-CurrentSprintShpEntry" "password-CurrentSprintShpEntry"
	And I have navigated to the Document Repository Page in CRM
	And I click on the tab for my custom documents folder
	And I enter master in the Search Documents field 
	When I click on the Search button for the custom folder
	Then the grid will display last one year records from the custom folder that match my search parameters


Scenario: 97749 - When opening the document repository and selecting a customer folder and there are no matching results then No results found that match the entered parameters. will be displayed
	Given I am a shp.inquiry, shp.inquirynorates, shp.entry or shp.entrynorates user "username-CurrentSprintShpEntry" "password-CurrentSprintShpEntry"
	And I have navigated to the Document Repository Page in CRM
	And I click on the tab for my custom documents folder
	And I enter some value in the Search Documents field 
	When I click on the Search button for the custom folder
	Then I will see the Grid level loading icon
	And I will see a message in the grid No results found that match the entered parameters.

