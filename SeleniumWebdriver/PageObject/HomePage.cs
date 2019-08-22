using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net;
using System.Threading;

namespace SeleniumWebdriver.PageObject
{
    public class HomePage
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(HomePage));
        public HomePage()
        {
            //test
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "desktopSearch")]

        public IWebElement txtsearchfield { get; set; }

        [FindsBy(How = How.LinkText, Using = "Ted Baker Bag")]

        public IWebElement searchItem { get; set; }

        [FindsBy(How = How.Id, Using = "product-sort")]

        public IWebElement ddlproductsorttype { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign in")]

        public IWebElement Signinlink { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]

        public IWebElement btnsignin { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='Ted Baker Arycon Small Icon Shopper Bag']")]

        public IWebElement imgproduct { get; set; }
        [FindsBy(How = How.CssSelector, Using = "h1.product-header__title")]

        public IWebElement imgproducttitle { get; set; }


        [FindsBy(How = How.Id, Using = "button--add-to-basket")]

        public IWebElement btnaddtobasket { get; set; }

        [FindsBy(How = How.LinkText, Using = "Go to your basket")]

        public IWebElement btngotobasket { get; set; }
        [FindsBy(How = How.XPath, Using = "//p[contains(.,'Currently in stock online')]")]

        public IWebElement txtstock { get; set; }
        [FindsBy(How = How.XPath, Using = "//h2[contains(.,'Added to your basket:')]")]

        public IWebElement statusadded { get; set; }
        [FindsBy(How = How.CssSelector, Using = "a.privacy-message-close--1b44d")]

        public IWebElement cookiepolicy{ get; set; }
        [FindsBy(How = How.Id, Using = "edr_l_first")]

        public IWebElement popup { get; set; }

        public void checkForcookiepolicy()
        {
            if (cookiepolicy.Displayed)
            {
                cookiepolicy.Click();
            }
        }

        public void GetTitleOfThePage()
        {
            string expectedTitle = "John Lewis & Partners | Homeware, Fashion, Electricals & More";
            string actualTitle = ObjectRepository.Driver.Title;
            AssertHelper.AreEqual(actualTitle, expectedTitle );
            Logger.Info(" Page Title Verified");
        }
        public void search(string value, string option)

        {
            checkForcookiepolicy();
            Logger.Info("Search for a product");
            txtsearchfield.EntertText(value);
            searchItem.ClickAt();
            ddlproductsorttype.ClickAt();
            ddlproductsorttype.SelectDropdown(option);
            checkForPopupAndClose();
            string bagName = imgproduct.GetText();
            imgproduct.ClickAt();
            Assert.IsTrue(imgproducttitle.IsElementVisible());
            AssertHelper.AreEqual(bagName, imgproducttitle.Text);
           
            checkForPopupAndClose();
        }
        public void AddProduct()

        {
            Logger.Info("Add product to the basket");
            Assert.IsTrue(txtstock.Text.Contains("Currently in stock online"));
            Thread.Sleep(1000);
            btnaddtobasket.ClickAt();
            Thread.Sleep(1000);
            Assert.IsTrue(statusadded.Text.Contains("Added to your basket:"));
            btngotobasket.ClickAt();
            Thread.Sleep(1000);
            checkForPopupAndClose();
        }

        public void checkForPopupAndClose()
        {
            if (ObjectRepository.Driver.FindElement(By.TagName("iframe")).Displayed)
            {
                ObjectRepository.Driver.SwitchTo().DefaultContent();
                ObjectRepository.Driver.SwitchTo().Frame(popup);
                ObjectRepository.Driver.FindElement(By.Id("close")).Click();
                return;
            }
            else
            {

            }
        }

    }



        

       
}
