using System;
using TechTalk.SpecFlow;
using AutomationSolution;

namespace UnitTestProject1
{
    [Binding]
    public class HowMuchToBorrowSteps
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
        
        [When(@"I click on Work out how much I could borrow button")]
        public void WhenIClickOnWorkOutHowMuchICouldBorrowButton()
        {
            HowMuchToBorrowPage.Submit();
        }
        
        [Then(@"the BorrowResult '(.*)' will be displayed correctly")]
        public void ThenTheBorrowResultWillBeDisplayedCorrectly(string p0)
        {
            HowMuchToBorrowPage.VerifyBorrowResult(p0);
        }

        [Given(@"StartOver Button appears")]
        public void GivenStartOverButtonAppears()
        {
            HowMuchToBorrowPage.WaitForStartOverButton();
        }

        [When(@"I click on StartOver Button")]
        public void WhenIClickOnStartOverButton()
        {
            HowMuchToBorrowPage.ClickOnStartOverButton();
        }

        [Then(@"all the fields are reset to zero")]
        public void ThenAllTheFieldsAreResetToZero()
        {
            HowMuchToBorrowPage.VerifyStartOver();

        }

    }
}
