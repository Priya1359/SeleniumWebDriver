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

        [FindsBy(How = How.CssSelector, Using = "#address_delivery span")]
        public IWebElement btnUpdateDeliveryAddress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#address_invoice span")]

        public IWebElement btnInvoiceUpdatebutton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#address_delivery > .address_firstname")]

        public IWebElement getFirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#address_delivery > .address_address1")]

        public IWebElement getAddressLine1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#address_delivery > .address_city")]

        public IWebElement getCity { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#address_delivery > .address_phone_mobile")]

        public IWebElement getphone { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".address_add span")]

        public IWebElement btnAddNewAddress { get; set; }

        

        


        public void deliveryDetails()
        {
            Logger.Info("Selecting delivery date and proceeding to payment page");
            Assert.IsTrue(btnInvoiceUpdatebutton.IsElementVisible());
            Assert.IsTrue(btnUpdateDeliveryAddress.IsElementVisible());
            Assert.IsTrue(btnAddNewAddress.IsElementVisible());
                    
            Thread.Sleep(3000);
           
                       
        }
       

       

    }
}
