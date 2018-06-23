using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationSolution.Utility_functions
{
    public class Utility
    {
        public static IWebElement WaitForElement(String s)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance,TimeSpan.FromSeconds(6));
            IWebElement webElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(s)));
            return webElement;
        }

        /*
        public enum ElementType
        {
            Id,
            XPath,
            CssSelector,
            LinkText,
            ClassName,
            Name
        }

      
            public static By GetMyElement(ElementType type, string locator)
            {
                switch (type)
                {
                    case ElementType.ClassName:
                        return By.ClassName(locator);
                    case ElementType.Name:
                        return By.Name(locator);
                    case ElementType.XPath:
                        return By.XPath(locator);
                    case ElementType.CssSelector:
                        return By.CssSelector(locator);
                    case ElementType.LinkText:
                        return By.LinkText(locator);
                    case ElementType.Id:
                    default:
                        return By.Id(locator);
                }
            }

   public static void AssertElementDisplayed(this IWebDriver driver, ElementType elementType, string locator)
            {
                Assert.IsTrue(driver.FindElement(GetMyElement(elementType, locator)).Displayed);
            }
            */

                        
    }
}
