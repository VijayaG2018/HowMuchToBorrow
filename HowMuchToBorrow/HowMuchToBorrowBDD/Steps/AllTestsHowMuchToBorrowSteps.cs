using System;
using TechTalk.SpecFlow;
using AutomationSolution;
using AutomationSolution.Helper_functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
//using AutomationSolution.ErrorMessages;


namespace UnitTestProject1
{
    [Binding]
    public class AllTestsHowMuchToBorrowSteps
    {
        [Given(@"I am on MuchBorrowCalculatorPage")]
        public void GivenIAmOnMuchBorrowCalculatorPage()
        {
           HowMuchToBorrowPage.GoTo();
        }

        [Given(@"I have entered Yourdetails '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)'")]
        public void GivenIHaveEnteredYourdetailsAndAndAndAndAndAndAndAnd(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8)
        {

            HowMuchToBorrowPage.FillYourDetails(p0, p1, p2, p3, p4, p5, p6, p7, p8).Fill();

        }

        [Given(@"I click on Work out how much I could borrow button")]
        public void GivenIClickOnWorkOutHowMuchICouldBorrowButton()
        {
            HowMuchToBorrowPage.Submit();
        }


        [When(@"I click on Work out how much I could borrow button")]
        public void WhenIClickOnWorkOutHowMuchICouldBorrowButton()
        {
            HowMuchToBorrowPage.Submit();
        }


        [When(@"I click on StartOver Button")]
        public void WhenIClickOnStartOverButton()
        {
            HowMuchToBorrowPage.ClickStartOverButton();
        }

        [Then(@"the BorrowResult '(.*)' will be displayed correctly")]
        public void ThenTheBorrowResultWillBeDisplayedCorrectly(string p0)
        {
            HowMuchToBorrowPage.VerifyBorrowResult(p0);
            //HowMuchToBorrowPage.Close();
        }

        [Then(@"all the fields are reset to zero")]
        public void ThenAllTheFieldsAreResetToZero()
        {
            HowMuchToBorrowPage.CheckStartOverHasResetAllFields();
            //HowMuchToBorrowPage.Close();
        }

        [Then(@"an appropriate error message will be displayed")]
        public void ThenAnAppropriateErrorMessageWillBeDisplayed()
        {
            HowMuchToBorrowPage.VerifyErrorMessage();
            //HowMuchToBorrowPage.Close();
        }

        [Then(@"I click on StartOver Button")]
        public void ThenIClickOnStartOverButton()
        {
            HowMuchToBorrowPage.ClickStartOverButton();
        }

        [TestCleanup]
        public void CloseBrowser()
        { HowMuchToBorrowPage.Close();
        }
    }
}
