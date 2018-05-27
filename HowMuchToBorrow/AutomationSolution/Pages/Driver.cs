using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationSolution
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void InitializeDriver()
        {
                Instance = new ChromeDriver();
            Instance.Manage().Window.Maximize();

            /*ChromeOptions options = new ChromeOptions();
       options.AddArguments("user-data-dir=C:/Users/user/AppData/Local/Google/Chrome/User Data");
       Instance = new ChromeDriver(options);*/

            //we could add switch case to add cross browser capability
        }
    }
}
