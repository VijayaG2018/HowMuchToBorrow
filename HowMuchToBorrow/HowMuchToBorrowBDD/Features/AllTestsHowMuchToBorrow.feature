Feature: AllTestsHowMuchToBorrow
As a prospective loan customer 
I want to use the home loan borrow calculator 

Background:
Given I am on MuchBorrowCalculatorPage

@VerifyBorrowResultAmount
Scenario Outline: VerifyHomeLoanBorrowingPowerCalculator
Given I have entered Yourdetails <ApplicationType> and <Dependants> and <PropertyType> and <YourIncome> and <OtherIncome> and <LivingExpenses> and <OtherLoanRepay> and <OtherCommitments> and <CreditCardLimits>
When I click on Work out how much I could borrow button
Then the BorrowResult <BorrowResultAmount> will be displayed correctly
Examples: 
| ApplicationType | Dependants | PropertyType       | YourIncome | OtherIncome | LivingExpenses | OtherLoanRepay | OtherCommitments | CreditCardLimits | BorrowResultAmount |
| 'Single'         | '0'        | 'Home to live in' | '80000'    | '10000'       | '500'            | '100'            | '0'        | '10000'          | '532000'           |

@VerifyStartOver
Scenario Outline: VerifyStartOverButton
Given I have entered Yourdetails <ApplicationType> and <Dependants> and <PropertyType> and <YourIncome> and <OtherIncome> and <LivingExpenses> and <OtherLoanRepay> and <OtherCommitments> and <CreditCardLimits>
And I click on Work out how much I could borrow button
When I click on StartOver Button
Then all the fields are reset to zero
Examples: 
| ApplicationType | Dependants | PropertyType       | YourIncome | OtherIncome | LivingExpenses | OtherLoanRepay | OtherCommitments | CreditCardLimits |
| 'Single'         | '0'        | 'Home to live in' | '80000'    | '10000'       | '500'            | '100'            | '0'        | '10000'          |

@VerifyErrorMessage
Scenario Outline: VerifyErrorMessage
Given I have entered Yourdetails <ApplicationType> and <Dependants> and <PropertyType> and <YourIncome> and <OtherIncome> and <LivingExpenses> and <OtherLoanRepay> and <OtherCommitments> and <CreditCardLimits>
When I click on Work out how much I could borrow button
Then an appropriate error message will be displayed 
Examples: 
| ApplicationType | Dependants | PropertyType       | YourIncome | OtherIncome | LivingExpenses | OtherLoanRepay | OtherCommitments | CreditCardLimits |
| 'Single'        | '0'        | 'Home to live in'	| '0'	     | '0'		   | '1'            | '0'            | '0'				| '0'		       |