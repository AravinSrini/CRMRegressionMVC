@28803 @Sprint68
Feature: ShipmentList_CustomReportsDelete_AllUsers
	
@GUI
Scenario Outline: Verify the presence of Delete Report hyperlink when user selected the custom report_all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I create a customreport <Customreport>
And I have selected the custom report <Customreport> which i created
When I Clicked on Show Filter link
Then I should be displayed with Delete Report link

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | crmOperation | Te$t1234 | Shipment List       | CusRepDel1   |
| s2       | saleTest     | Te$t1234 | Shipment List       | CusRepDel2   |
| s3       | stationowner | Te$t1234 | Shipment List       | CusRepDel3   |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | CusRepDel4   |

@Functional @Acceptance
Scenario Outline: Verify Delete Report modal on click of Delete Report hyperlink when user selected the custom report_all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected the custom report <Customreport> which i created
And I Clicked on Show Filter link
When I click on Delete Report link
Then I should be displayed with Delete Report modal pop up

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | crmOperation | Te$t1234 | Shipment List       | CusRepDel1   |
| s2       | saleTest     | Te$t1234 | Shipment List       | CusRepDel2   |
| s3       | stationowner | Te$t1234 | Shipment List       | CusRepDel3   |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | CusRepDel4   |

@Functional @Acceptance
Scenario Outline: Verify Cancel button functionality in Delete Report modal_all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected the custom report <Customreport> which i created
And I Clicked on Show Filter link
When I click on Delete Report link
And I click on Cancel button in Delete report modal
Then I will be navigated to shipment list page
And Reports in grid will be displayed still
And Show filter section will be displayed still

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | crmOperation | Te$t1234 | Shipment List       | CusRepDel1   |
| s2       | saleTest     | Te$t1234 | Shipment List       | CusRepDel2   |
| s3       | stationowner | Te$t1234 | Shipment List       | CusRepDel3   |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | CusRepDel4   |

@Functional @Acceptance
Scenario Outline: Verify Yes button functionality in Delete Report modal_all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I have selected the custom report <Customreport> which i created
And I Clicked on Show Filter link
When I click on Delete Report link
And I click on Yes button in Delete Report modal
Then I will be navigated to shipment list page
And the Report will be default to Select a Report 
And Shipment list will be updated to display all shipments for the past thirty days for all customers
And Created custom report will be removed from the report list <Customreport>

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | crmOperation | Te$t1234 | Shipment List       | CusRepDel1   |
| s2       | saleTest     | Te$t1234 | Shipment List       | CusRepDel2   |
| s3       | stationowner | Te$t1234 | Shipment List       | CusRepDel3   |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | CusRepDel4   |

@Functional @DBVerification
Scenario Outline: Verify the custom report deleted from database once deleted from UI_all non admin users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I click on the Shipment icon 
And I navigate to shipment list <ShipmentList_Header> page
And I create a customreport <Customreport>
And I have selected the custom report which i created
And I Clicked on Show Filter link
When I click on Delete Report link
And I click on Yes button in Delete Report modal
Then Created custom report will be removed from the report list <Customreport>
And Created custom report will be deleted from DB <Customreport>

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | crmOperation | Te$t1234 | Shipment List       | CusRepDel11  |
| s2       | saleTest     | Te$t1234 | Shipment List       | CusRepDel22  |
| s3       | stationowner | Te$t1234 | Shipment List       | CusRepDel33  |
| s4       | crmsalesusr  | Te$t1234 | Shipment List       | CusRepDel44  |

@GUI
Scenario Outline: Verify the presence of Delete Report hyperlink when user selected the custom report_all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I create a customreport <Customreport>
And I have selected the custom report <Customreport> which i created
When I Clicked on Show Filter link
Then I should be displayed with Delete Report link

Examples: 
| Scenario | Username    | Password | ShipmentList_Header | Customreport |
| s1       | shpent      | Te$t1234 | Shipment List       | CusRepDel    |
| s2       | shpinq      | Te$t1234 | Shipment List       | CusRepDel5   |
| s3       | shpentnorts | Te$t1234 | Shipment List       | CusRepDel6   |
| s4       | shpinqnorts | Te$t1234 | Shipment List       | CusRepDel7   |

@Functional @Acceptance
Scenario Outline: Verify Delete Report modal on click of Delete Report hyperlink when user selected the custom report_all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I have selected the custom report <Customreport> which i created
And I Clicked on Show Filter link
When I click on Delete Report link
Then I should be displayed with Delete Report modal pop up

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | shpent       | Te$t1234 | Shipment List       | CusRepDel    |
| s2       | shpinq       | Te$t1234 | Shipment List       | CusRepDel5   |
| s3       | shpentnorts  | Te$t1234 | Shipment List       | CusRepDel6   |
| s4       | shpinqnorts  | Te$t1234 | Shipment List       | CusRepDel7   |

@Functional @Acceptance
Scenario Outline: Verify Cancel button functionality in Delete Report modal_all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I have selected the custom report <Customreport> which i created
And I Clicked on Show Filter link
When I click on Delete Report link
And I click on Cancel button in Delete report modal
Then I will be navigated to shipment list page
And Reports in grid will be displayed still
And Show filter section will be displayed still

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | shpent       | Te$t1234 | Shipment List       | CusRepDel    |
| s2       | shpinq       | Te$t1234 | Shipment List       | CusRepDel5   |
| s3       | shpentnorts  | Te$t1234 | Shipment List       | CusRepDel6   |
| s4       | shpinqnorts  | Te$t1234 | Shipment List       | CusRepDel7   |

@Functional @Acceptance
Scenario Outline: Verify Yes button functionality in Delete Report modal_all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I have selected the custom report <Customreport> which i created
And I Clicked on Show Filter link
When I click on Delete Report link
And I click on Yes button in Delete Report modal
Then I will be navigated to shipment list page
And the Report will be default to Select a Report 
And Shipment list will be updated to display all shipments for the past thirty days for all customers
And Created custom report will be removed from the report list <Customreport>

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | shpent       | Te$t1234 | Shipment List       | CusRepDel    |
| s2       | shpinq       | Te$t1234 | Shipment List       | CusRepDel5   |
| s3       | shpentnorts  | Te$t1234 | Shipment List       | CusRepDel6   |
| s4       | shpinqnorts  | Te$t1234 | Shipment List       | CusRepDel7   |

@Functional @DBVerification
Scenario Outline: Verify the custom report deleted from database once deleted from UI_all external users
Given I am a DLS user and login into application with valid <Username> and <Password>
And I have access to Shipment button for external users
And I navigate to shipment list <ShipmentList_Header> page
And I create a customreport <Customreport>
And I have selected the custom report which i created
And I Clicked on Show Filter link
When I click on Delete Report link
And I click on Yes button in Delete Report modal
Then Created custom report will be removed from the report list <Customreport>
And Created custom report will be deleted from DB <Customreport>

Examples: 
| Scenario | Username     | Password | ShipmentList_Header | Customreport |
| s1       | shpent       | Te$t1234 | Shipment List       | CusRepDel55  |
| s2       | shpinq       | Te$t1234 | Shipment List       | CusRepDel66  |
| s3       | shpentnorts  | Te$t1234 | Shipment List       | CusRepDel77  |
| s4       | shpinqnorts  | Te$t1234 | Shipment List       | CusRepDel88  |
