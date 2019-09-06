using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumExtras.PageObjects;
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

        [FindsBy(How = How.Id, Using = "search_query_top")]
        public IWebElement txtsearchfield { get; set; }

        [FindsBy(How = How.Name, Using = "submit_search")]
        public IWebElement searchButton { get; set; }

        [FindsBy(How = How.Id ,Using = "uniform-selectProductSort")]
        public IWebElement productsorttype { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[contains(.,'Price: Lowest first')]")]
        public IWebElement ddlproductsorttype { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='Faded Short Sleeve T-shirts']")]
        public IWebElement productname { get; set; }
       
        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Quick view')]")]
        public IWebElement quickView { get; set; }
        
        [FindsBy(How = How.Id, Using = "uniform-group_1")]
        public IWebElement MainsizeDdl { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[contains(.,'S')]")]
        public IWebElement sizeDdl { get; set; }
        
        [FindsBy(How = How.Id, Using = "our_price_display")]
        public IWebElement productprice { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[contains(.,'Faded Short Sleeve T-shirts')]")]
        public IWebElement txtproducttitle { get; set; }

        [FindsBy(How = How.Name, Using = "Orange")]
        public IWebElement imgproductcolor { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Add to cart')]")]
        public IWebElement btnaddtobasket { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//h2[contains(.,'Product successfully added to your shopping cart')]")]
        public IWebElement statusadded { get; set; }
        
        [FindsBy(How = How.Id, Using = "layer_cart_product_title")]
        public IWebElement product { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Proceed to checkout')]")]
        public IWebElement btnProceedToCheckout { get; set; }

        [FindsBy(How = How.Id, Using = "relative=parent")]
        public IWebElement iframe1 { get; set; }

        [FindsBy(How = How.Id, Using = "layer_cart_product_title")]
        public IWebElement productTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".continue > span")]
        public IWebElement continueButton { get; set; }

        [FindsBy(How = How.Id, Using = "layer_cart")]
        public IWebElement CheckoutIframe { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span.ajax_cart_no_product")]
        public IWebElement cartEmpty { get; set; }


        public void GetTitleOfThePage()
        {
            string expectedTitle = "Search - My Store";
            string actualTitle = ObjectRepository.Driver.Title;
            AssertHelper.AreEqual(actualTitle, expectedTitle);
            Logger.Info(" Page Title Verified");
        }

        public void search(string value)

        {
            Logger.Info("Search for a product");
            Assert.IsTrue(cartEmpty.IsElementVisible());
            txtsearchfield.EntertText(value);
            searchButton.ClickAt();
            productsorttype.ClickAt();
            ddlproductsorttype.ClickAt();
            productname.Mouseover();
            quickView.ClickAt();
            Thread.Sleep(2000);
            checkForPopup();
            Assert.IsTrue(txtproducttitle.IsElementVisible());

                      
        }

        public void AddProduct()

        {
            Logger.Info("Add product to the basket");
            Thread.Sleep(1000);
            MainsizeDdl.ClickAt();
            sizeDdl.ClickAt();
            imgproductcolor.ClickAt();
            btnaddtobasket.ClickAt();
            Thread.Sleep(3000);
            CheckoutIframe.ClickAt();
            Assert.IsTrue(statusadded.Text.Contains("Product successfully added to your shopping cart"));
            Assert.IsTrue(product.Text.Contains("Faded Short Sleeve T-shirts"));
            btnProceedToCheckout.ClickAt();
            Thread.Sleep(1000);
          
        }

        public void checkForPopup()
        {
                ObjectRepository.Driver.SwitchTo().DefaultContent();
                ObjectRepository.Driver.SwitchTo().Frame(0);
                                 
        }

    }

}

