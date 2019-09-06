using log4net;
using SeleniumExtras.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.PageObject
{
   public class ShippingPage
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(DeliveryDetailsPage));

        public ShippingPage()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='carrier_area']/h1")]
        public IWebElement txtShippingheader { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[3]")]

        public IWebElement Infodelivery { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[4]/div")]

        public IWebElement getdeliveryPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='form']/div/p[2]/label")]

        public IWebElement getTermsOfService { get; set; }

        [FindsBy(How = How.Id, Using = "uniform-cgv")]

        public IWebElement termsandCons { get; set; }

        [FindsBy(How = How.LinkText, Using = "(Read the Terms of Service)")]

        public IWebElement lnkterms { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".standard-checkout > span")]

        public IWebElement btncheckout { get; set; }

        [FindsBy(How = How.LinkText, Using = "Pay by bank wire (order processing will be longer)")]

        public IWebElement btnwire { get; set; }

        [FindsBy(How = How.LinkText, Using = "Pay by check (order processing will be longer)")]

        public IWebElement btnsCheck { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".bankwire > span")]

        public IWebElement btnWireclk { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".page-subheading")]

        public IWebElement headingWire { get; set; }

        [FindsBy(How = How.LinkText, Using = "Other payment methods")]

        public IWebElement btnotherpayments { get; set; }

        [FindsBy(How = How.Id, Using = "cart_navigation")]

        public IWebElement btnpayment{ get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'I confirm my order')]")]

        public IWebElement btnconfirm { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cheque-indent > .dark")]

        public IWebElement txtOrderComplete { get; set; }

        [FindsBy(How = How.CssSelector, Using = "price > strong")]

        public IWebElement confirmPrice { get; set; }

        [FindsBy(How = How.LinkText, Using = "Faded Short Sleeve T-shirts")]

        public IWebElement productTitleonpaypage { get; set; }

        [FindsBy(How = How.Id, Using = "total_price")]

        public IWebElement totalpriceonpaypage { get; set; }

        [FindsBy(How = How.XPath, Using = "//p/button/span")]

        public IWebElement btnshippingButton { get; set; }

        public void shippingDetails()
        {
            Logger.Info("Verify SHipping date and proceeding to payment page");
            btnshippingButton.ClickAt();
            Thread.Sleep(1000);
            Assert.IsTrue(txtShippingheader.Text.Contains("SHIPPING"));
            Assert.IsTrue(Infodelivery.Text.Contains("My carrier Delivery next day!"));
            Assert.IsTrue(getdeliveryPrice.Text.Contains("$2.00"));
            Assert.IsTrue(getTermsOfService.Text.Contains("I agree to the terms of service and will adhere to them unconditionally."));
            Assert.IsTrue(lnkterms.IsElementVisible());
            termsandCons.ClickAt();
            btncheckout.ClickAt();
            Thread.Sleep(1000);

        }

        public void ChoosePaymentDetails()
        {
            Logger.Info("Verify Payment Type");
            Assert.IsTrue(productTitleonpaypage.Text.Contains("Faded Short Sleeve T-shirts"));
            Assert.IsTrue(totalpriceonpaypage.Text.Contains("$18.51"));
            Assert.IsTrue(btnsCheck.IsElementVisible());
            Assert.IsTrue(btnwire.IsElementVisible());
            btnWireclk.ClickAt();
            Thread.Sleep(1000);

        }
        public void ConfirmPaymentDetails()
        {
            Logger.Info("Confirm Payment Details");
            Assert.IsTrue(headingWire.Text.Contains("BANK-WIRE PAYMENT."));
            Assert.IsTrue(btnotherpayments.IsElementVisible());
            
            btnconfirm.ClickAt();
            Assert.IsTrue(txtOrderComplete.Text.Contains("Your order on My Store is complete."));
            Assert.IsTrue(confirmPrice.Text.Contains("$18.51"));
            Thread.Sleep(1000);

        }

        public void screenshot()
        {
            Logger.Info("Taking screenshot of Review Page");
            string name = ScenarioContext.Current.ScenarioInfo.Title + ".jpeg";
            GenericHelper.TakeScreenShot(name);
        }



    }
}
