using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.PageObject
{
   public class DeliveryDetailsPage 
    {
        

        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(DeliveryDetailsPage));
         
        public DeliveryDetailsPage()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Change address')]")]
        public IWebElement btnChangeaddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Next or named day delivery')]")]

        public IWebElement selectdeliveryoption { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "div.calendar_displayDates__75859")]

        //public IWebElement selectdeliverydateUI { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Continue to payment')]")]

        public IWebElement btnContinuePayment { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Edit delivery details')]")]

        public IWebElement btneditdeliverydate { get; set; }
        [FindsBy(How = How.XPath, Using = "/dt[contains(.,'Next or named day delivery')]")]

        public IWebElement verifydeliverytext1 { get; set; }
        [FindsBy(How = How.CssSelector, Using = "strong:nth-child(1)")]

        public IWebElement verifydeliverydate { get; set; }
        [FindsBy(How = How.CssSelector, Using = "//h4[contains(.,'Delivery details')]")]

        public IWebElement verifydeliverydetailsHeader { get; set; }
        [FindsBy(How = How.CssSelector, Using = "span:nth-child(5)")]

        public IWebElement verifydeliverycity { get; set; }
        [FindsBy(How = How.CssSelector, Using = "*[data-test='addressee']")]

        public IWebElement verifyuser { get; set; }
        [FindsBy(How = How.CssSelector, Using = "*[data-test='address-postcode']")]
        public IWebElement verifyPostcode { get; set; }
        [FindsBy(How = How.CssSelector, Using = "*[data-test='address-phone']")]

        public IWebElement verifyPhone { get; set; }
        [FindsBy(How = How.CssSelector, Using = "*[data-test='message-title']")]

        public IWebElement verifymessageindeliverypage { get; set; }
        [FindsBy(How = How.CssSelector, Using = "*[data-test='calendar-additional-information']")]
        public IWebElement verifytimeindeliverypage { get; set; }
        [FindsBy(How = How.CssSelector, Using = "*[data-test='delivery-details-message']")]

        public IWebElement verifydateandtimeonreviewpage { get; set; }
        

        //div class="edr_lb"> 

        public void deliveryDetails()
        {
            Logger.Info("Selecting delivery date and proceeding to payment page");
            Assert.IsTrue(btnChangeaddress.IsElementVisible());
            selectdeliveryoption.ClickAt();
            DateTime date = DateTime.Today.AddDays(2);
            var Day = (int)date.Day;
            Console.WriteLine(Day + " Chosen date for delivery");
            ObjectRepository.Driver.FindElement(By.XPath("//button/span[contains(text()," + Day + ")]")).Click();
            Thread.Sleep(3000);
           

           
        }
       
            public void validateReviewPage()
        {
            string messageonDDPage = verifymessageindeliverypage.Text;
            string timefromDDPage = verifytimeindeliverypage.Text;
            string[] message = messageonDDPage.Split(' ');
            string[] time = timefromDDPage.Split(' ');

            string getdate = message[2] + " " + message[3].Replace("th", "") + " " + message[4];
            Console.WriteLine(getdate);
            string gettime = time[12] + " " + time[13] + " " + time[14];
            Console.WriteLine(gettime);
            btnContinuePayment.ClickAt();
            Thread.Sleep(3000);
            string dayandtimeonReviewpage = verifydateandtimeonreviewpage.Text;
            //Delivery on Sunday 25th August 2019
            //Delivery on a date of your choice, available 7 days a week 7.30am - 6pm (excluding public holidays). Order by 8pm for delivery following day. Other exclusions may apply.
            Console.WriteLine(dayandtimeonReviewpage);

            Assert.IsTrue(dayandtimeonReviewpage.Contains(getdate));
            Assert.IsTrue(dayandtimeonReviewpage.Contains(gettime));


            Assert.IsTrue(btneditdeliverydate.IsElementVisible());
          
            
        }

        public void screenshot()
        {
            Logger.Info("Taking screenshot of Review Page");
            string name = ScenarioContext.Current.ScenarioInfo.Title + ".jpeg";
            GenericHelper.TakeScreenShot(name);
        }

    }
}
