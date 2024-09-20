@Sprint60 @TrackingDetailsPage-ExportFunctionality @18408 
Feature: Tracking Details Page - Export Functionality
	
@GUI @Fixed
Scenario Outline: Verify the existence of Export button in the Tracking details page
Given I am a DLS user and login into application with valid Username and Password
And I click on Tracking Details icon
When I enter '<MultipleValidReferenceNumbers>' in the search box
And I click on search button in the Tracking page
And I navigate to <Tracking> Details page
Then I must be able to view <Export> Button

Examples: 
| MultipleValidReferenceNumbers                   | Tracking | Export |
| MKE30128897,PIT01172270,PIT01172271,ZZX00204206 | Tracking | Export |

@GUI @Fixed
Scenario Outline: Verify dropdown menu for export button in the Tracking details page
Given I am a DLS user and login into application with valid Username and Password
And I click on Tracking Details icon
And I enter the multi'<MultipleValidReferenceNumbers>' in the search box
And I navigate to <Tracking> details page
When I click on Export button 
Then I must be able to view a dropdown with option to select <All> or <Displayed>

Examples: 
| Tracking | All | Displayed | MultipleValidReferenceNumbers                   |
| Tracking | All | Displayed | MKE30128897,PIT01172270,PIT01172271,ZZX00204206 |

@Functional @Regression @Fixed
Scenario Outline: Verify and compare the functionality of export button when 'All' option is selected from the Dropdown
Given I am a DLS user and login into application with valid Username and Password
And I click on Tracking Details icon
And I enter the multi'<MultipleValidReferenceNumbers>' in the search box
And I navigate to <Tracking> details page
When I click on Export button 
And I click on All option from the export dropdown 
Then An Excel file of .xls format containing all the tracking results should get downloaded and verified

Examples: 
| Tracking | MultipleValidReferenceNumbers                   |
| Tracking | MKE30128897,PIT01172270,PIT01172271,ZZX00204206 |

@Functional @Regression @Fixed
Scenario Outline: Verify and compare the functionality of export button when 'Displayed' option is selected from the dropdown
Given I am a DLS user and login into application with valid Username and Password
And I click on Tracking Details icon
And I enter the multi'<MultipleValidReferenceNumbers>' in the search box
And I navigate to <Tracking> details page
When I click on Export button 
And I click on Displayed option from the export dropdown
Then An Excel file of .xls format containing all the tracking results of the current page should get downloaded and verified

Examples: 
| Tracking | MultipleValidReferenceNumbers                   |
| Tracking | MKE30128897,PIT01172270,PIT01172271,ZZX00204206 |

@GUI @Acceptance @Fixed
Scenario Outline: Verify that the Export button is unavailable for Mobile devices.
Given I am a DLS user and login into application with valid Username and Password
And I re-size the browser to the mobile device '<WindowWidth>' and  '<WindowHeight>'
And I click on Tracking Details icon for mobile device
And I enter the multi'<MultipleValidReferenceNumbers>' in the search box
When I navigate to <Tracking> Details page
Then I should not be able to view <Export> Button in the tracking details page

Examples: 
| Tracking | Export | WindowWidth | WindowHeight | MultipleValidReferenceNumbers                   |
| Tracking | Export | 360         | 640          | MKE30128897,PIT01172270,PIT01172271,ZZX00204206 |

@Functional @Fixed
Scenario Outline: Compare More information tracking details with exported excel
Given I am a DLS user and login into application with valid Username and Password
And I click on Tracking Details icon
And I enter the multi'<MultipleValidReferenceNumbers>' in the search box
And I navigate to <Tracking> details page
When I click on Export button 
And I click on Displayed option from the export dropdown
And I click on More Information Icon
Then I should be able to compare the more information details with the exported tracking details file

Examples: 
| Tracking | MultipleValidReferenceNumbers                   |
| Tracking | MKE30128897,PIT01172270,PIT01172271,ZZX00204206 |



