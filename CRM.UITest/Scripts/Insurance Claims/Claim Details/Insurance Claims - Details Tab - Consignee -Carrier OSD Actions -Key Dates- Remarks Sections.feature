@Sprint82 @39933
Feature: Insurance Claims - Details Tab - Consignee -Carrier OSD Actions -Key Dates- Remarks Sections
	
@GUI @Functional
Scenario: 39933-Verify the fields for the Consignee, Carrier OS&D Actions, Key Dates, and Remarks sub-sections
	 Given I am sales, sales management, operations, station owner, or claims specialist user
	 And I am on the Claims List page
	 And I clicked on the hyperlink of any displayed claim
	 When I arrive on the Details tab of the Claims Details page
	 Then I will see all the fields for the Consignee, Carrier OS&D Actions, Key Dates, and Remarks sub-sections


@GUI @Functional
Scenario: 39933-Verify the max length of the text box fields from consignee section
	 Given I am a claim specialist user
	 And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim as a claim specialist
	 When I arrive on the Details tab of the Claims Details page
	 Then The name field will not allow more than 75 character
	 And The address field will not allow more than 50 character
	 And the city field will not allow more than 50 character

@GUI @Functional
Scenario: 39933-Verify by entering alpha numeric value in the fields of consignee section
	 Given I am a claim specialist user
	 And I am on the Claims List page
	 And I clicked on the hyperlink of any displayed claim as a claim specialist
	 When I arrive on the Details tab of the Claims Details page
	 Then It will allow to enter alpha numeric value to Name, address and city fields
	 

@GUI @Functional
Scenario: 39933-Verify by editing the fields from Consignee, Carrier OS&D Actions, Key Dates, and Remarks sub-sections
	 Given I am a claims specialist user
	 And I am on the Claims List page
	 And I clicked on the hyperlink of any displayed claim as a claim specialist
	 When I am on the Details tab of the Claims Details page
	 Then I will be able to edit the fields from the Consignee, Carrier OS&D Actions, Key Dates, and Remarks sub-sections

@GUI @Functional
Scenario: 39933-Verify state or province field when country is selected United States or Canada
     Given I am a claims specialist user
	 And I am on the Claims List page
	 And I clicked on the hyperlink of any displayed claim as a claim specialist
	 And I am on the Details tab of the Claims Details page
	 When country is selcted as United States or Canada
	 Then State or Province field will be a dropdown

Scenario: 39933-Verify state or province field when country is not selected as United States or Canada
     Given I am a claims specialist user
	 And I am on the Claims List page
	 And I clicked on the hyperlink of any displayed claim as a claim specialist
	 And I am on the Details tab of the Claims Details page
	 When country is not selected as United States or Canada
	 Then State or province field will allow to enter alpha numeric value
	 And It will not allow more than 50 character

@GUI @Functional
Scenario: 39933-Verify Zip or Postal field when country is selected as United States
	Given I am a claims specialist user
	And I am on the Claims List page
    And I clicked on the hyperlink of any displayed claim as a claim specialist
	And I am on the Details tab of the Claims Details page
	When Country is selected as United States
	Then Zip or postal field will allow to enter numeric value
	And It will allow 5 character to enter
	And It will allow leading zero

@GUI @Functional
Scenario: 39933-Verify Zip or Postal field when country is selected as Canada
   Given I am a claims specialist user
   And I am on the Claims List page
   And I clicked on the hyperlink of any displayed claim as a claim specialist
   And I am on the Details tab of the Claims Details page
   When Country is selected as Canada
   Then Zip or postal field will allow to enter alpha numeric value
   And It will allow minimum 6 and Maximum 7 character to enter

@GUI @Functional
Scenario: 39933-Verify Zip or Postal field when is not selected as United States or Canada
   Given I am a claims specialist user
   And I am on the Claims List page
   And I clicked on the hyperlink of any displayed claim as a claim specialist
   And I am on the Details tab of the Claims Details page
   When country is not selected as United States or Canada
   Then Zip or postal field will allow to enter alpha numeric value
   And It will allow to enter special character
   And It will enter 15 character
   

@GUI @Functional
Scenario: 39933-Verify the Carrier Ack field for Carrier OS&D Actions Sub-section
	Given I am a claims specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim as a claim specialist
	When I am on the Details tab of the Claims Details page
	Then It will contain two value in the dropdown, Y or N
	And It's default display will be blank

@GUI
Scenario: 39933-Verify the Carried Ack Date field from Carrier OS&D Actions Sub-section
	Given I am a claims specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim as a claim specialist
	When I am on the Details tab of the Claims Details page
	Then Carrier Ack Date will be optional field
	And It will not allow to select future date
	And Calender selection will follow the mm/dd/yyyy format

@GUI @Functional
Scenario: 39933-Verify the Carrier Claim number field from Carrier OS&D Actions Sub-section
	Given I am a claims specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim as a claim specialist
	When I am on the Details tab of the Claims Details page
	Then Carrier Claim number field will be optional
	And It will allow alpha-numeric values
	And It will allow special characters 
	And It will allow Max 50 character it to enter

@GUI @Functional
Scenario: 39933-Verify Carrier PRO Date,BOL,Delivery Date fields from Key Dates Sub-section
	Given I am a claims specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim as a claim specialist
	When I am on the Details tab of the Claims Details page
	Then It will not allow to select future date
	And Calender selection will follow the mm/dd/yyyy format

Scenario: 39933-Verify the auto populate values from Consignee section
	Given I am a claims specialist user
	And I am on the Claims List page
	And I clicked on the hyperlink of any displayed claim having shipment as LTL
	Then Consignee data will bind in Consignee section