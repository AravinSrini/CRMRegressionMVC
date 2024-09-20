Feature: InsuranceClaimsListE2E
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@RamaTests

Scenario: ClaimSpecialistUser Claim Details Page
	Given I am a Logged in ClaimSpecialist User and on ClaimList Page
	When I arrive on the page and see all the displayed data
	Then verify the data displayed is correct

