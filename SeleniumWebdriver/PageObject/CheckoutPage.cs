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
        
        [FindsBy(How = How.LinkText, Using = "Faded Short Sleeve T-shirts")]
         public IWebElement productTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'In stock')]")]
         public IWebElement instocklabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[4]/span/span")]
        public IWebElement price { get; set; }

        [FindsBy(How = How.Id, Using = "total_price")]
         public IWebElement totalprice { get; set; }
        
        [FindsBy(How = How.Id, Using = "total_shipping")]
         public IWebElement deliveryCharge { get; set; }

        [FindsBy(How = How.LinkText, Using = "Continue shopping")]
        public IWebElement btncontinue { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".standard-checkout > span")]
         public IWebElement checkOutButton { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
         public IWebElement btncontinueasaguest { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[contains(.,'Invalid email address.')]")]
         public IWebElement errorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "email_create")]
         public IWebElement email { get; set; }

        [FindsBy(How = How.Id, Using = "id_gender2")]
         public IWebElement txttitle { get; set; }

        [FindsBy(How = How.Id, Using = "customer_firstname")]
         public IWebElement txtfirstname { get; set; }

        [FindsBy(How = How.Id, Using = "customer_lastname")]
         public IWebElement txtlastname { get; set; }

        [FindsBy(How = How.Id, Using = "phone_mobile")]
         public IWebElement txtphonenumber { get; set; }

        [FindsBy(How = How.Id, Using = "postcode")]
         public IWebElement txtsearchpostcode { get; set; }

        [FindsBy(How = How.Id, Using = "uniform-id_state")]
         public IWebElement btnfindaddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[contains(.,'Florida')]")]
         public IWebElement ddlfindaddress { get; set; }

        [FindsBy(How = How.Id, Using = "address1")]
         public IWebElement addressline1 { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
         public IWebElement password { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
         public IWebElement city { get; set; }

        [FindsBy(How = How.Id, Using = "alias")]
        public IWebElement alias { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement email2 { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement txtfirstname1 { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        public IWebElement txtlastname1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAccount']/span/i")]
        public IWebElement btnRegister { get; set; }

        [FindsBy(How = How.Id, Using = "id_address_delivery")]
        public IWebElement verifyaliasAddress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span.ajax_cart_quantity")]
        public IWebElement cartQuantity { get; set; } 

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement loginemail { get; set; } 

        [FindsBy(How = How.CssSelector, Using = "#SubmitLogin > span")]
        public IWebElement btnsignIn { get; set; }


        public void assertCheckoutpage()
        {
            Logger.Info("Validating Checkout Page");
            Assert.IsTrue(cartQuantity.Text.Contains("1"));
            Assert.IsTrue(instocklabel.IsElementVisible());
            Assert.IsTrue(btncontinue.IsElementVisible());
           
        }

        public void continueasAGuest()
        {
            Logger.Info("Continue as a guest");
            checkOutButton.ClickAt();
            Thread.Sleep(3000);
            Assert.IsTrue(btncontinueasaguest.IsElementVisible());
            Assert.IsTrue(loginemail.IsElementVisible());
            Assert.IsTrue(btnsignIn.IsElementVisible());

            btncontinueasaguest.ClickAt();
            Assert.IsTrue(errorMessage.Text.Contains("Invalid email address."));
          
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next();
            var emailId = "username" + randomInt + "@gmail.com";
            email.EntertText(emailId);
            Console.WriteLine("email ID " + emailId);
            btncontinueasaguest.ClickAt();
            Assert.IsTrue(txttitle.IsElementVisible());
            Thread.Sleep(2000);
       
        }

        public void fillDeliveryDetails(string uname ,string lname , string phoneNumber,string Postcode,string cityName ,string address)
        {
            Logger.Info("Filling Mnadatory details of the user");
            txtfirstname.EntertText(uname);
            txtlastname.EntertText(lname);
            password.EntertText("12345");
            var FirstName = txtfirstname.GetText();
            var LastName = txtlastname.GetText();
            Thread.Sleep(2000);
            addressline1.EntertText(address);
            city.EntertText(cityName);
            btnfindaddress.ClickAt();
            ddlfindaddress.ClickAt();
            txtphonenumber.EntertText(phoneNumber);
            txtsearchpostcode.EntertText(Postcode);
            alias.EntertText("Test Address");
            btnRegister.ClickAt();
            Thread.Sleep(2000);
            Assert.IsTrue(verifyaliasAddress.Text.Contains("Test Address"));

        }
       
    }

}


 

