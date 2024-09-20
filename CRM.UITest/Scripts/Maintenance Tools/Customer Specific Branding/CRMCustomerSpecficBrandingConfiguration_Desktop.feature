@CRMCustomerSpecficBrandingConfiguration @19300 @Sprint62 
Feature: CRMCustomerSpecficBrandingConfiguration_Desktop

@GUI @Acceptance
Scenario Outline: Verify that user have the option to configure Customer Specific Branding
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	Then I will have the option '<CustomerSpecificBranding>' to configure Customer Specific Branding
	And I will have the '<description>' for the Customer Specific Branding option

	Examples: 
	| Scenario | Username       | Password | CustomerSpecificBranding   | description |
	| S1       | crmSystemAdmin | Te$t1234 | Customer Specific Branding | Replace the DLS logo with a customer logo. |

@GUI @Acceptance @Functional
Scenario Outline: Verify that user can able to directed to the Customer Specific Branding page if user has the required claim
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	Then I will have the option '<CustomerSpecificBranding>' to configure Customer Specific Branding
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim

	Examples: 
	| Scenario | Username       | Password | 
	| S1       | crmSystemAdmin | Te$t1234 | 

@GUI
Scenario Outline: Verify the Customer Specific Branding page for the correctness
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
    And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	Then I should see an option to go back to the Maintenance Tool Screen with the default text as '<backtoMaintenanceTool>'
	And I should see an option to select a station with lable '<StationLbl>' and '<Selectstation>' as default text
	And I should see an option to select a customer account based on the station that was selected with lable '<CustomerLbl>' and with the default text as '<Selectcustomer>'
	And I should see an option to upload a custom logo and with the lable '<AddLogoFileLbl>', default text to '<browse>' and '<Filesizeinfo>'
	And I should see an option to Save the uploaded file with the default text as '<Save>'
	And I should see list of existing Customer Specific Logos with lable '<CustomerSpecificLogosLbl>', Pagination header view '<View>', '<StationDD>', '<CustomernameDD>', '<LogoFile>'

	Examples: 
	| Scenario | Username       | Password |  backtoMaintenanceTool     | StationLbl | Selectstation     | CustomerLbl | Selectcustomer     | AddLogoFileLbl  | browse | Filesizeinfo                                                                           | Save | CustomerSpecificLogosLbl | View | StationDD | CustomernameDD | LogoFile  |
	| S1       | crmSystemAdmin | Te$t1234 |  Back to Maintenance Tools | STATION *  | Select station... | CUSTOMER *  | Select customer... | ADD LOGO FILE * | browse | ** File size limit: 20MB Acceptable file type is PNG or JPG Only one file per customer | Save | Customer Specific Logos  | VIEW | STATION   | CUSTOMER NAME  | LOGO FILE |
		 
@Functional 
Scenario Outline: Verify that the custom logo flag will be set to On by default when user uploaded new logo to the customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	And I click on the station drop down and select one station from drop down list
	And I click on the customer drop down and select one customer from drop down list
	And I delete the customer account if present in the customer specific logos grid
	And I upload a file from '<filepath>' through file explorer
	And I click on the save button	
	Then Verify the logo name '<Filename>' updated in the Customer Specific Logos list and Custom logo flag set to On by default

	Examples: 
	| Scenario | Username       | Password |  filepath                                                                       | Filename |
	| S1       | crmSystemAdmin | Te$t1234 |  ../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/BrandingLogo.jpg | BrandingLogo.jpg |

@Functional @GUI
Scenario Outline: Verify that a pop up should display when there is already a logo saved for the customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	And I click on the station drop down and select one station from drop down list
	And I click on the customer drop down and select one customer from drop down list
	And Verify the customer account has already uploaded with '<Filename>'
	And I upload a file from '<filepath>' through file explorer
	And I click on the save button
    Then verify the pop up window with '<overwrite>', '<OverwriteDescription>' and buttons with '<Yes>' and '<No>'
	
	Examples: 
	| Scenario | Username       | Password | filepath                                                                       | Filename         | overwrite    | OverwriteDescription                         | Yes | No |
	| S1       | crmSystemAdmin | Te$t1234 | ../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/BrandingLogo.jpg | BrandingLogo.jpg | Confirmation | Are you sure you want to overwrite the logo? | Yes | No |

@Functional
Scenario Outline: Verify that file overwritten functionality when there is already a logo saved for the customer
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
    And I click on the station drop down and select one station from drop down list
	And I click on the customer drop down and select one customer from drop down list
	And Verify the customer account has already uploaded with '<Filename>'
	And I upload a file from '<filepath>' through file explorer
	And I click on the save button
	And I click on the yes button
	Then Verify the old logo file name '<Filename>' should overwritten by the new logo file name '<NewFilename>'

	Examples: 
	| Scenario | Username       | Password |  Filename         | filepath                                                                       | NewFilename      |
	| S1       | crmSystemAdmin | Te$t1234 | BrandingLogo.jpg | ../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/testJuneLogo.png | testJuneLogo.png |

@Functional
Scenario Outline: Verify that pop up should close when click on No in the overwritten pop up
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	And I click on the station drop down and select one station from drop down list
	And I click on the customer drop down and select one customer from drop down list
	And Verify the customer account has already uploaded with '<Filename>'
	And I upload a file from '<filepath>' through file explorer
	And I click on the save button
	And I click on the No button
	Then Verify the pop up should close

	Examples: 
	| Scenario | Username       | Password | Filename         | filepath                                                                                     | NewFilename      |
	| S1       | crmSystemAdmin | Te$t1234 | BrandingLogo.jpg | ../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/testJuneLogo.png | testJuneLogo.png |

@Functional @GUI
Scenario Outline: Verify that the functionality of the Back to maintenance tools button
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	And I click on the backtoMaintenanceTool button
	Then I should navigate to the Maintenance Tools landing page '<MaintenanceTools>'

	Examples: 
	| Scenario | Username       | Password | MaintenanceTools |
	| S1       | crmSystemAdmin | Te$t1234 | Maintenance Tools|

@Functional @GUI
Scenario Outline: Verify the error message when user clicks on the save button with out selecting required fields
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	And I click on the save button
	Then I should see the '<errormsg>' error message in the add customer specific logo section

	Examples: 
	| Scenario | Username       | Password |  errormsg                              |
	| S1       | crmSystemAdmin | Te$t1234 | PLEASE ENTER ALL REQUIRED INFORMATION |

@Functional @GUI
Scenario Outline: Verify the error message when user try to upload file size more than 20MB
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	And I click on the station drop down and select one station from drop down list
	And I click on the customer drop down and select one customer from drop down list
	And I upload a file from '<filepath>' through file explorer
	Then I should see the '<errormsg>' error message in the add customer specific logo section when image size exceed limits

	Examples: 
	| Scenario | Username       | Password | filepath                                                                      | errormsg |
	| S1       | crmSystemAdmin | Te$t1234 | ../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/picsize47MB.jpg | The selected file exceeds the file size limit. |

@Functional @GUI
Scenario Outline: Verify the error message when user try to upload wrong file format
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	#And I click on the station drop down and select one station from drop down list
	#And I click on the customer drop down and select one customer from drop down list
	And I upload a file from '<filepath>' through file explorer
	Then I should see the '<errormsg>' error message in the add customer specific logo section when image wrong format

	Examples: 
	| Scenario | Username       | Password |filepath                                                                           | errormsg                                       |
	| S1       | crmSystemAdmin | Te$t1234 | ../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/WrongImageFormat.gif | The selected file is not in png or jpg format. |

@Functional @GUI
Scenario Outline: Verify the fuctionality of the toggle up button in the add customer specific logo header section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	And When I click on the add customer specific logo expand or collapse button
	And I should not see an option to select a station with lable'<StationLbl>' and with the default text as '<Selectstation>'
	And When I click on the add customer specific logo expand or collapse button
	Then I should see all the required labels <StationLbl>, <CustomerLbl>, <AddLogoFileLbl>, <browse> and <Save> buttons 

	Examples: 
	| Scenario | Username       | Password | StationLbl | CustomerLbl | AddLogoFileLbl | browse | Save |
	| S1       | crmSystemAdmin | Te$t1234 | STATION *  |  CUSTOMER * | ADD LOGO FILE *| browse | Save |   


@Functional
Scenario Outline: Verify the delete button functionality in the Customer Specific Logo section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	When I click on the station drop down and select one station from drop down list
	And I click on the customer drop down and select one customer from drop down list
	And I delete the customer account if present in the customer specific logos grid
	And I upload a file from '<filepath>' through file explorer
	And I click on the save button
	Then Delete the uploaded logo by click on the delete button in the Customer Specific Logo section
	And Verify the uploaded '<Filename>' must not be present in the grid

	Examples: 
	| Scenario | Username       | Password | filepath                                                                                | Filename |
	| S1       | crmSystemAdmin | Te$t1234 |  ../../Scripts/TestData/Testfiles_MaintenanceUpload/ValidFiles/BrandingLogo-ToDelete.jpg | BrandingLogo-ToDelete.jpg |

@Functional
Scenario Outline: Verify the Toggle button functionality in the Customer Specific Logo section
	Given I am a DLS user and login into application with valid <Username> and <Password>
	And I am landing on DLS Worldwide homepage with RRD logo
	When I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '<Username>' have claim
	And I am able to click CustomerSpecificBranding button and able to navigate to the Customer Specific Branding page when '<Username>' have the required claim
	Then Verify toggle button have '<ON>' and '<OFF>' lables 
	And Verify the Toggle on '<ON>' button state 
	And Verify the Toggle off '<OFF>' button  state

	Examples: 
	| Scenario | Username       | Password | ON | OFF |
	| S1       | crmSystemAdmin | Te$t1234 | ON | OFF |
	






	


