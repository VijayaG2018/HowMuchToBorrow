using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AutomationSolution.Helper_functions;
using AutomationSolution.Utility_functions;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace AutomationSolution
{
    public class HowMuchToBorrowPage
    {
        //this page class could be further broken down as and when further functionality will be realized
        public static void GoTo()
        {
            
            Driver.InitializeDriver();
            Driver.Instance.Navigate().GoToUrl("https://www.anz.com.au/personal/home-loans/calculators-tools/much-borrow/");

            //Check if we are on the right page
            IWebElement headertext = Driver.Instance.FindElement(By.XPath("//span[contains(@class,'text--white')]  [contains(text(),'How much could I borrow?')]"));
            Assert.AreEqual("How much could I borrow?",headertext.Text);
                   
        }
             
        public static void SetSlider(int amount)
        {
            IWebElement slider = Driver.Instance.FindElement(By.CssSelector("div[class='noUi-base']"));
            Actions builder = new Actions(Driver.Instance);
            Driver.Instance.SwitchTo();

                 IWebElement otherIncomeText = Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q2q2']"));


    }

        public static void VerifyBorrowResult(string p0)
        {
            var expectedBorrowResultAmount = p0;
            var actualBorrowResultAmount = String.Empty;
            Thread.Sleep(6000);
            actualBorrowResultAmount = Driver.Instance.FindElement(By.XPath("//span[@class='borrow__result__text__amount']")).Text;
            actualBorrowResultAmount = Helper.RemoveNonNumeric(actualBorrowResultAmount);  
        
            StringAssert.IsMatch(expectedBorrowResultAmount, actualBorrowResultAmount);


        }

        public static void Close()
        {
            Driver.Instance.Close();

        }

        public static void ClickStartOverButton()
        {

            IWebElement startOverButton = Utility.WaitForElement("[class='icon icon_restart']");
            startOverButton.Click();
        }

        public static void CheckStartOverHasResetAllFields()
        {
            //Verify if ApplicationType is reset to Single
            IWebElement singleApplicationTypeButton = Driver.Instance.FindElement(By.Id("application_type_single"));
            IWebElement jointApplicationTypeButton = Driver.Instance.FindElement(By.Id("application_type_joint"));
            
            Assert.AreEqual(singleApplicationTypeButton.Selected, true);
            Assert.AreEqual(jointApplicationTypeButton.Selected, false);

            //Verify if Dependant dropdown is reset to 0
            IWebElement dependantDropdown = Driver.Instance.FindElement(By.XPath(".//*[@title='Number of dependants']"));
            SelectElement selectNoOfDependants = new SelectElement(dependantDropdown);

            Assert.AreEqual(selectNoOfDependants.SelectedOption.Text, "0");
            
            //Verify if Propertype is reset to Home to Live In
            IWebElement homePropertyTypeButton= Driver.Instance.FindElement(By.Id("borrow_type_home"));
            IWebElement investPropertyTypeButton = Driver.Instance.FindElement(By.Id("borrow_type_investment"));
           
            Assert.AreEqual(homePropertyTypeButton.Selected, true);
            Assert.AreEqual(investPropertyTypeButton.Selected, false);

            //Verify if Your Income is reset to 0
            IWebElement yourIncomeText = Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q2q1']"));
           
            Assert.AreEqual(yourIncomeText.GetAttribute("Value"), "0");

            //Verify if Other Income is reset to 0 
            IWebElement otherIncomeText = Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q2q2']"));
            
            Assert.AreEqual(otherIncomeText.GetAttribute("Value"), "0");

            //Verify if Living Expenses is reset to 0  
            IWebElement livExpText = Driver.Instance.FindElement(By.Id("expenses"));
            
            Assert.AreEqual(livExpText.GetAttribute("Value"), "0");

            //Verify if  Loan Repay is reset to 0 
            IWebElement otherLoanRepayText = Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q3q2']"));
            
            Assert.AreEqual(otherLoanRepayText.GetAttribute("Value"), "0");

            //Verify if  Other Commitment is reset to 0 
            IWebElement otherCommText = Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q3q3']"));
           
            Assert.AreEqual(otherCommText.GetAttribute("Value"), "0");

            //Verify if Credit Card Limits is reset to 0  
            IWebElement creditCardText = Driver.Instance.FindElement(By.Id("credit"));
            
            Assert.AreEqual(creditCardText.GetAttribute("Value"), "0");
        }

        public static void VerifyErrorMessage()
        {
            IWebElement errorMsg = Driver.Instance.FindElement(By.CssSelector("span[class='borrow__error__text']"));
           
            Assert.AreEqual(errorMsg.Text, ErrorMessages.borrowErrorText);
          
        }

        public static void Submit()
        {
                       
            IWebElement submitButton = Driver.Instance.FindElement(By.XPath("//*[@id='main_skip']/div/div[2]/div/div/div/div[1]/div/div[3]/div/div/div/div[1]/button"));
            //this is not working with cssselector or relative xpath??to be investigated
            //IWebElement submitButton = Driver.Instance.FindElement(By.XPath("//span[@class='btn btn--action btn--borrow__calculate']"));
            // IWebElement submitButton = Driver.Instance.FindElement(By.CssSelector("span[class='btn btn--action btn--borrow__calculate']"));
            submitButton.Click();
        }

        
        public  static FillYourDetailsCommand FillYourDetails(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7,string p8)
        {
            return new FillYourDetailsCommand(p0, p1, p2,p3,p4,p5,p6,p7,p8);
            
        }

    }

   
    public class FillYourDetailsCommand
    {
        private readonly string applicationType;
        private readonly string dependants;
        private readonly string yourIncome;
        private readonly string propertyType;
        private readonly string otherIncome;
        private readonly string livingExpenses;
        private readonly string otherLoanRepay;
        private readonly string otherCommitments;
        private readonly string creditCardLimits;
        

        public FillYourDetailsCommand(string AppType, string Dep, String PropType, String Income, String OthrIncome, String LivingExp, String OthrLoanRePay, String OtherLoanComm, String CCLim)
        {
            this.applicationType = AppType;
            this.dependants = Dep;
            this.propertyType = PropType;
            this.yourIncome = Income;
            this.otherIncome = OthrIncome;
            this.livingExpenses = LivingExp;
            this.otherLoanRepay = OthrLoanRePay;
            this.otherCommitments = OtherLoanComm;
            this.creditCardLimits = CCLim;
        }

        public void Fill()
        {
            //Enter ApplicationType
           
            try
            {
                if (applicationType == "Single")
                   Driver.Instance.FindElement(By.Id("application_type_single")).Click();

                else if (applicationType == "Joint")
                   Driver.Instance.FindElement(By.Id("application_type_joint")).Click();
            }
            catch { Console.WriteLine("applicationType not found"); }

            //Select No of Dependants
            SelectElement selectNoOfDependants = new SelectElement(Driver.Instance.FindElement(By.CssSelector("select[title='Number of dependants']")));
            selectNoOfDependants.SelectByText(dependants);

            //Enter PropertyType

            try
            {
                if (propertyType == "Home To Live In")
                  Driver.Instance.FindElement(By.Id("borrow_type_home")).Click();
                  
                else if (propertyType == "Residential Investment")
                  Driver.Instance.FindElement(By.Id("borrow_type_investment")).Click();
       
            }
            catch { Console.WriteLine("borrow type not found"); }

            //Enter Your Income
            Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q2q1']")).SendKeys(yourIncome);

            //Enter Other Income
            Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q2q2']")).SendKeys(otherIncome);

            //Enter Living Expenses
            Driver.Instance.FindElement(By.Id("expenses")).SendKeys(livingExpenses);

            //Enter Other Loan Repay
            Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q3q2']")).SendKeys(otherLoanRepay);

            //Enter Other Commitments
            Driver.Instance.FindElement(By.CssSelector("input[aria-labelledby='q3q3']")).SendKeys(otherCommitments);
            
            //Enter Credit Card Limits
            Driver.Instance.FindElement(By.Id("credit")).SendKeys(creditCardLimits);
        }
    }
}
