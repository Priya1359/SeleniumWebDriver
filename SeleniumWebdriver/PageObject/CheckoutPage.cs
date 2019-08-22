using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.PageObject
{
    public class CheckoutPage
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(CheckoutPage));
        public CheckoutPage()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }
        [FindsBy(How = How.Id, Using = "email")]
        
        public IWebElement txtemailaddress { get; set; }
        [FindsBy(How = How.CssSelector, Using = "h2.product-list-title")]
        
        public IWebElement productTitle { get; set; }
        [FindsBy(How = How.CssSelector, Using = "button.remove-basket-item-form-button")]

        public IWebElement removebutton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "p.price")]

        public IWebElement price { get; set; }
        [FindsBy(How = How.CssSelector, Using = "span.basket-sub-total")]

        public IWebElement totalExcludingdelivery { get; set; }


        [FindsBy(How = How.Id, Using = "link-button--basket-continue-securely")]

        public IWebElement btncontinue { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Guest checkout')]")]

        public IWebElement guestcheckoutoption { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Continue as guest')]")]

        public IWebElement btncontinueasaguest { get; set; }

        [FindsBy(How = How.CssSelector, Using = "svg.delivery-choice-tile_icon__7c04b")]

        public IWebElement deliverychoice { get; set; }

        [FindsBy(How = How.Id, Using = "title")]

        public IWebElement txttitle { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]

        public IWebElement txtfirstname { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]

        public IWebElement txtlastname { get; set; }

        [FindsBy(How = How.Id, Using = "phoneNumber-number")]

        public IWebElement txtphonenumber { get; set; }

        [FindsBy(How = How.Id, Using = "searchPostcode")]

        public IWebElement txtsearchpostcode { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Find address')]")]

        public IWebElement btnfindaddress { get; set; }

        [FindsBy(How = How.Id, Using = "addressSearchSelect")]

        public IWebElement ddladdresssselct { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Use this address')]")] 

        public IWebElement btnusethisaddress{ get; set; }


        public void assertCheckoutpage()
        {
            Logger.Info("Validating Checkout Page");
            Assert.IsTrue(removebutton.IsElementVisible());
            Assert.IsTrue(productTitle.Text.Contains("Ted Baker Arycon Small Icon Shopper Bag"));
            Assert.IsTrue(totalExcludingdelivery.IsElementVisible());
            Assert.IsTrue(price.Text.Contains("30"));
        }

        public void continueasAGuest()
        {
            Logger.Info("Continue as a guest");
            btncontinue.ClickAt();
            guestcheckoutoption.ClickAt();
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next();
            txtemailaddress.EntertText("username" + randomInt + "@gmail.com");
            btncontinueasaguest.ClickAt();
            deliverychoice.ClickAt();
        }

        public void fillDeliveryDetails(string title ,string uname ,string lname , string phoneNumber , string Postcode )
        {
            Logger.Info("Filling Mnadatory details of the user");
            txttitle.EntertText(title);
            txtfirstname.EntertText(uname);
            txtlastname.EntertText(lname);
            txtphonenumber.EntertText(phoneNumber);
            txtsearchpostcode.EntertText(Postcode);
            btnfindaddress.ClickAt();
            ddladdresssselct.SelectDropdown("1");
            btnusethisaddress.ClickAt();

           

        }

       
    }

}


 

