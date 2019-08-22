using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
  public static  class SeleniumMethods
    {
        public static void EntertText(this IWebElement element, string value)

        {
            element.WaitforElementtobeClikable(TimeSpan.FromSeconds(10));
            element.SendKeys(value);

        }
        public static void TakeScreenShot(string filename = "Screen")
        {
            var screen = ObjectRepository.Driver.TakeScreenshot();
            if (filename.Equals("Screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                Console.WriteLine(" ScreenShot Taken : " + filename);
                return;
            }
            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg); Console.WriteLine(" ScreenShot Taken : " + filename);
        }

        public static void ClickAt(this IWebElement element)
        {
            element.WaitforElementtobeClikable(TimeSpan.FromSeconds(10));
            element.Click();
        }

        public static void SelectDropdown(this IWebElement element, string value)

        {
            element.WaitforElementtobeClikable(TimeSpan.FromSeconds(10));
            new SelectElement(element).SelectByValue(value);

        }

        public static string GetText(this IWebElement element)

        {
            element.WaitforElementtobeClikable(TimeSpan.FromSeconds(10));
            return element.GetAttribute("value");
        }

        public static string GetTextFromDropDownList(this IWebElement element)

        {

            element.WaitforElementtobeClikable(TimeSpan.FromSeconds(10));
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;


        }

        public static bool IsElementVisible(this IWebElement element)
        {
            element.WaitforElementtobeClikable(TimeSpan.FromSeconds(10));
            return element.Displayed && element.Enabled;
        }

        public static IWebElement WaitforElementtobeClikable(this IWebElement element ,TimeSpan timeout)
        {
           
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
                var wait = GetWebdriverWait(timeout);
                var flag = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(20));
             return flag;
            
        }

        public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            
            return wait;
        }

        

        



    }
}
