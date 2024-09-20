@78278 @NinjaSprint32 @Regression
Feature: 78278 - External API Call to MercuryGate

Scenario: 78278 - Verify that call to /MercuryGate/Rate Request is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "RateRequest" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/Rate Request is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "RateRequest" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/Shipment Import is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "ShipmentImport" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/Shipment Import is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "ShipmentImport" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/Oidlookup is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "OidLookup" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/Oidlookup Import is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "OidLookup" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/ListScreenExtract is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "ListScreenExtract" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/ListScreenExtract is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "ListScreenExtract" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/ShipmentExtract is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "ShipmentExtract" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/ShipmentExtract is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "ShipmentExtract" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/CodeTableLookup is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "CodeTableLookup" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/CodeTableLookup is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "CodeTableLookup" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/DocumentExtract is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "DocumentExtract" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/DocumentExtract is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "DocumentExtract" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/Tracking is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "Tracking" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/Tracking is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "Tracking" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/CommonExtract is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "CommonExtract" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/CommonExtract is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "CommonExtract" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/CommonImport is blocked and given a 401 response for non CRM or Admin user for v1
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "CommonImport" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/CommonImport is not blocked for Admin user for v1
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "CommonImport" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v1"
Then I will not be blocked

Scenario: 78278 - Verify that call to /MercuryGate/Rate Request is blocked and given a 401 response for non CRM or Admin user for v2
Given I am a user named "RIM Logistics"
When I make a call to the Mercury Gate method "RateRequest" with an ApiKey "02914f61-f91a-f6f2-2a00-c92ff447281a" and Customer "ZZZ Sandbox DLS Worldwide" for "v2"
Then I will be blocked and given a 401 response

Scenario: 78278 - Verify that call to /MercuryGate/Rate Request is not blocked for Admin user for v2
Given I am a user named "Admin"
When I make a call to the Mercury Gate method "RateRequest" with an ApiKey "39375be6-5a41-0169-7992-608eeb8e4b4a" and Customer "ZZZ Sandbox DLS Worldwide" for "v2"
Then I will not be blocked