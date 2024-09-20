@Sprint83 @44590

Feature: InsuranceClaims_SubmitAClaimPageAutoPopulateDely Date

@Functionality
Scenario:44590-Verify Actual Delivery Date within Carrier Information Section on the submit a Claim page -MG Shipment
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
And I am on Submit a Claim page
And I have entered a valid DLSW BOL number <ZZX00209411>
And And I Clicked the Populate Form Button
When I click on the Submit Claim Form button on submit claim page
Then CRM will retrieve and store the Actual Delivery Date form valid MG BOL number <ZZX00209411>

#Currently CSA response not getting node OWNER 
#@Functionality
#Scenario:44590-Verify Actual Delivery Date within Carrier Information Section on the submit a Claim page -CSA Shipment
#Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
#And I am on Submit a Claim page
#And I have entered a valid DLSW BOL number <9920495>
#And And I Clicked the Populate Form Button
#When I click on the Submit Claim Form button on submit claim page
#Then CRM will retrieve and store the Actual Delivery Date from valid CSA Reference number <9920495>


@Functionality
Scenario:44590-Verify Actual Delivery Date should not autopopulate within Carrier Information Section on the submit a Claim page
Given I am a shp.inquiry, shp.inquirynorates, shp.entry, shp.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user
And I am on Submit a Claim page
And I have manually entered all required fields <ZZX00208761>
When I click on the Submit Claim Form button on submit claim page
Then CRM will retrieve and store the Actual Delivery Date form valid MG BOL number <ZZX00208761>
