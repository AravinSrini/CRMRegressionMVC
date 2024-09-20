@InsurenceClaims_ClaimAgeCounter @31887 @Sprint79 
Feature: InsuranceClaims_ClaimAgeCounter


@GUI @DBverification
Scenario: 31887_Verify the Claim Age value on the Claims list page
     Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations or Station Owner user 
     When I am on the Claims List page
     Then The Claim Age value will be calculated as Current Date - Claim Date Submitted = Number of days
