@InsurenceClaims_DetailsTab_Shipper_DLSW_OS&D_Actions_InsuranceInfoSection_ClaimSpecialistUser @Sprint81 @43571 
Feature: Insurance Claims - Details Tab - Shipper, DLSW OS and  D Actions, Insurance Info Sections - Claim Specialist User

@GUI @Functional
Scenario: Verify i am unable to edit the Cycle Time field
Given I am a claims specialist user
And I clicked on the hyperlink of any displayed claim on Claims List page
When I am on the Details tab of the Claims Details page
Then I am unable to edit the Cycle Time field


@GUI @Functional
Scenario: Validate and verify the Name, Address and City fields in Shipper sub section
Given I am a claims specialist user
And I clicked on the hyperlink of any displayed claim on Claims List page
When I am on the Details tab of the Claims Details page
Then Validate and Verify the Name field (Optional, alpha-numeric, text, special characters, max length 75)
And Validate and Verify the Address field (Optional, alpha-numeric, text, special characters, max length 150)
And Validate and Verify the City field (Optional, alpha-numeric, text, special characters, max length 50)


@GUI @Functional
Scenario: Validate and verify the State/Province field in Shipper sub section
Given I am a claims specialist user
And I clicked on the hyperlink of any displayed claim on Claims List page
When I am on the Details tab of the Claims Details page
Then Validate and Verify the State/Prov (Optional) field If Country = United States or Canada (drop down list, text, max length 2)
And  Validate and Verify the State/Prov (Optional) field If Country NOT United States or Canada (alpha-numeric, text, max length 50)

@GUI @Functional
Scenario: Validate and verify the Zip/Postal field in Shipper sub section
Given I am a claims specialist user
And I clicked on the hyperlink of any displayed claim on Claims List page
When I am on the Details tab of the Claims Details page
Then Validate and Verify the Zip/Postal (Optional) field If Country is United States (numeric, min length & max length = 5, allow leading zero)
And  Validate and Verify the Zip/Postal (Optional) field If Country is  Canada (alpha-numeric, min length = 6, max length = 7 when a space is used after first 3 characters)
And  Validate and Verify the Zip/Postal (Optional) field If Country NOT United States or Canada (alpha-numeric, text, special characters, min length 1, max length 15)


@GUI @Functional
Scenario: Validate and verify the Country field in Shipper sub section
Given I am a claims specialist user
And I clicked on the hyperlink of any displayed claim on Claims List page
When I am on the Details tab of the Claims Details page
Then Validate and Verify the Country field (optional, drop down list, text)

@GUI @Functional
Scenario: Validate and verify the Date Ack to Claimant, Date Filed w/ Carrier and Cycle Time fields in DLSW OS&D Actions section
Given I am a claims specialist user
And I clicked on the hyperlink of any displayed claim on Claims List page
When I am on the Details tab of the Claims Details page
Then Validate and Verify the Date Ack to Claimant field (optional, calendar option, unable to select future date, field editable - format mm/dd/yyyy)
And Validate and Verify the Date Filed w/ Carrier field (optional, calendar option, unable to select future date, field editable - format mm/dd/yyyy)
And Validate and Verify the Cycle Time field (not editable, system calculation)

@GUI @Functional
Scenario: Validate and verify the Program, Amount and Company fields in Insurance Info section
Given I am a claims specialist user
And I clicked on the hyperlink of any displayed claim on Claims List page
When I am on the Details tab of the Claims Details page
Then Validate and verify the Program (optional, drop down list, list configurable)
And Validate and verify the Amount (currency, allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal places; $xx,xxx.xx)
And Validate and verify the Company field (optional, drop down list, list configurable)

@GUI @Functional
Scenario: verify the Save Claim button on the claim Details page of claim specialist user
Given I am a claims specialist user
And I clicked on the hyperlink of any displayed claim on Claims List page
When I am on the Details tab of the Claims Details page
Then  I should see Save Claims button on the Claim Details Page
