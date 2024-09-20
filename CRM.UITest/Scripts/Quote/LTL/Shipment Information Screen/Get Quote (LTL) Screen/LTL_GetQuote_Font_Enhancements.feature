@LTL_GetQuote_FontEnhancements @32027 @Sprint74 
Feature: LTL_GetQuote_Font_Enhancements

@Regression
Scenario Outline: Verify the Font Size is increased to 20  and Font Color will darker 
   Given I am an Ship Entry, Ship EntryNoRates, Ship Inquiry, Operations, Sales, or Sales Management user <Username>,<Password>
   When I am on the Get Quote LTL Page <usertype>,<Account>
   Then Verify <font_size> will be increased to Twenty and <font_color> will be darker for all fields
   
Examples: 
| Scenario | Username              | Password | usertype | Account                  | font_size | font_color       |
| S1       | crmOperation@user.com | Te$t1234 | Internal | ZZZ - Czar Customer Test | 20px      | rgba(0, 0, 0, 1) |
| S2       | zzzext                | Te$t1234 | External |                          | 20px      | rgba(0, 0, 0, 1) |


