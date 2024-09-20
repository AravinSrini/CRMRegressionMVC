@48378 @Sprint85 
Feature: 48378_Insurance Claims - Claims Details - Bind Saved Values


@GUI @Functional @DBVerification
Scenario Outline: 48378_Verify the all fields is edited and should get saved for specific claim 
	Given I am a Claims Specialist user
	And I am on the Claim Details page of any existing claim <Tab>
	And I have edited the Header Section - (DLSW Claim Rep, DLSW Ref #, Claimant, Claim Reason, Carrier Name, Carrier PRO #, Insured)	
	And I have edited the <Tab> FTL Tab -(Carrier MC #, Seal Intact, Seal #, Vehicle #), Forwarding Tab - (Airline, Pickup Carrier, Delivery Carrier, Steamship Line, Freight Forwarder, White Glove Agent)
	And I have edited the Shipper Section - (Name, Address, City, State, Zip, Country),DLSW OS&D Actions(Date Ack to Claimant, Date Filed with Carrier), Insurance Info - (Program, Amount, Company)
    And I have edited the Consignee Section - (Name, Address, City, State, Zip, Country) , Carrier OS&D Actions - (Carrier Ack, Carrier Ack Date, Carrier Claim #), Key Dates - (Carrier PRO Date, BOL/Ship Date, Delivery Date), Remarks
    And I have edited the Products Claimed Section - (Clm Type, Art Type, Qty, Item #, Desc, Unit Wt,  Unit Val, Total Shipment Weight)
    And I have edited the Freight Calculations: Original Row - Claimable <Y> (Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #)
    And I have edited the Freight Calculations: Return Row - Claimable <Y> (Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #)
    And I have edited the Freight Calculations: Replacement Row - Claimable <Y> (Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #)
	And I have edited the Freight Calculations: Comments
	When I click on Save Claim Details button on the Claim Details page
	Then All edited fields should get saved 
	Examples: 
    | Tab        |
    | FTL        |
    | Forwarding |


@GUI @Functional
Scenario Outline: 48378_Verify the all fields will be displayed with the previously edited and saved values
     Given I am a  sales, sales management, operations and station owner user
     And I have access to view claims <Tab>
	 When I arrive on the Claim Details page
     Then All fields will be displayed with the previously edited and saved values
	 Examples: 
     | Tab        |
     | FTL        |
     | Forwarding |


Scenario Outline: 92199_Verify that the values added for fields under Claimed item(s) and Freight charge(s) in Submit a Claim page is saved to Claim Details page
Given I am a Sales, Sales Management, Operations, Station Owner or Claims Specialist user <UserType>
And I am on the Submit a Claim page
And I have completed all required information
When I click the Submit Claim button
Then the claimed item(s) and freight charge(s) will be saved to the Claim Details page per the attached mapping document

Examples:
		| UserType         |
		| Internal         |
		| Sales            |
		| Claim Specialist |
  