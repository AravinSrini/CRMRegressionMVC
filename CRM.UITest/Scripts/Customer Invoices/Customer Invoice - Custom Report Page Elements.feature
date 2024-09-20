@35768 @NinjaSprint16 
Feature: Customer Invoice - Custom Report Page Elements

@GUI @Functional
Scenario: 35768_Verify Create Custom Report section will be expandable/collapsable
         Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and  access rrd user
         When I arrived on Customer Invoice List page
         Then I will see a section - Create Custom Report
		 And It will be collapsed by default
		 And The section will be expandable/collapsable
         

@GUI
Scenario: 35768_Verify Create Custom Report section fields        
         Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and  access rrd user
	     And I arrived on Customer Invoice List page
         When I expand the Create Custom Report section
		 Then I will see Criteria Section
		 And I will see Invoice Type as required field with Open as default, Closed and All options
		 And I will see Days Past Due selector 
		 And I will see Invoice Value field as optional field
		 And I will see Date Range selector as optional field
		 And I will see Station selection field as required field
		 And I will see Accounts selection field as required field
		 And I will see Report Name field as required field
		 And I will see Delete button, Create New button, Preview/Run Now button, Schedule Report button

@GUI @DBVerification
Scenario: 35768_Verify data for the Criteria and Report Name of existing custom report will be displayed
          Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and  access rrd user
         And I arrived on Customer Invoice List page
		 And I selected a Custom Report from the Select Existing Custom Report list in customer invoice page
		 When I expand the Create Custom Report section
		 Then The data for the Criteria and Report Name of the custom report will be display
		 And The Delete button will be active
		 And The Preview/Run Now button will be active
		 And The Schedule Report button will be active
		 And The Create New button will be inactive


@GUI
Scenario: 35768_Verify Create New, Preview/Run Now button will be active, Schedule Report button is hidden and Delete button will be inactive
         Given I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner and  access rrd user
         And I arrived on Customer Invoice List page
		 When I expand the Create Custom Report section
		 Then The Create New button will be active
		 And The Preview/Run Now button will be active
		 And The Schedule Report button will be hidden
		 And The Delete button will be inactive


