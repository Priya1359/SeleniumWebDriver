using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.StepDefinition
{
    [Binding]
    class AddandBuyProduct
    {
        HomePage homePage = new HomePage();
        CheckoutPage checkoutPage = new CheckoutPage();
        DeliveryDetailsPage deliveryPage = new DeliveryDetailsPage();
        ShippingPage shipPage = new ShippingPage();

        public string aPrice;
        public string aProduct;
        public string atotalPrice;

        [Given(@"I have landed on(.*) Website")]
        public void GivenIHaveLandedOnHttpAutomationpracticecomWebsite(string url)
        {
            NavigationHelper.NavigateToUrl(url);
            homePage.GetTitleOfThePage();
        }

        [When(@"I Search for a product to buy")]
        public void WhenSearchForAProductToBuy()
        {
            homePage.search("Dresses");
            ScenarioContext.Current["actualPrice"] = homePage.productprice.Text;
            ScenarioContext.Current["actualProduct"] = homePage.txtproducttitle.Text;
        }

        [When(@"I Add product to the basket")]
        public void WhenIAddProductToTheBasket()
        {
            homePage.AddProduct();
        }

        [When(@"I verify Checkout Page deatils")]
        public void WhenIVerifyCheckoutPageDeatils()
        {
            aPrice = ScenarioContext.Current["actualPrice"].ToString();
            aProduct = ScenarioContext.Current["actualProduct"].ToString();

            checkoutPage.assertCheckoutpage();
            var assertprice = checkoutPage.price.Text;
            var assertproduct = checkoutPage.productTitle.Text;

            Console.WriteLine("actual price" + aPrice);
            Console.WriteLine("actual product" + aProduct);

            Assert.IsTrue(assertprice.Contains(aPrice));
            Assert.IsTrue(assertproduct.Contains(aProduct));

            ScenarioContext.Current["deliveryPrice"] = checkoutPage.deliveryCharge.Text;
            ScenarioContext.Current["actualtotalPrice"] =checkoutPage.totalprice.Text;
            
        }

        [When(@"I continue As a Guest user")]
        public void WhenIContinueAsAGuestUser()
        {
            checkoutPage.continueasAGuest();
        }

        [When(@"fill the mandtory fields (.*),(.*),(.*),(.*),(.*) and (.*)")]
        public void WhenFillTheMandtoryFieldsTestFloridaAndTestAddressLine(string fname, string lname, string Phno, string Pcode ,string CityName ,string addressln)
        {
            checkoutPage.fillDeliveryDetails(fname, lname, Phno, Pcode ,CityName,addressln);

            ScenarioContext.Current["UserCity"] = CityName;
            ScenarioContext.Current["Userfname"] = fname;
            ScenarioContext.Current["Userlname"] = lname;
            ScenarioContext.Current["phone"] = Phno;
            ScenarioContext.Current["postcode"] = Pcode;
            ScenarioContext.Current["ADDRESS"] = addressln;

        }
        
        [When(@"I verify delivery details")]
        public void WhenIverifydeliverydetails()
        {
            string Ufname = ScenarioContext.Current["Userfname"].ToString();
            string Ulanme = ScenarioContext.Current["Userlname"].ToString();
            string ucity = ScenarioContext.Current["UserCity"].ToString();
            string phonenumber = ScenarioContext.Current["phone"].ToString();
            string postcode = ScenarioContext.Current["postcode"].ToString();
            string addressln1 = ScenarioContext.Current["ADDRESS"].ToString();
            
            deliveryPage.deliveryDetails();
            var assertuname = deliveryPage.getFirstName.Text;
            var assertcity = deliveryPage.getCity.Text;
            var assertphone = deliveryPage.getphone.Text;
            var assertAddress = deliveryPage.getAddressLine1.Text;

            Console.WriteLine("user from scenario" + " " + Ufname + " " + Ulanme);
            Console.WriteLine("user from delivery page" + assertuname);
            Console.WriteLine("user from delivery page" + ucity + "," + "Florida" + " " + postcode);

            Assert.IsTrue(assertuname.Contains(Ufname + " " + Ulanme));
            Assert.IsTrue(assertcity.Contains(ucity));
            Assert.IsTrue(assertphone.Contains(phonenumber));
            Assert.IsTrue(assertAddress.Contains(addressln1));

        }

        [When(@"I Pay using Wire")]
        public void WhenIPayUsingWire()
        {
            atotalPrice = ScenarioContext.Current["actualtotalPrice"].ToString();
            shipPage.shippingDetails();
            var asserttotal = shipPage.totalpriceonpaypage.Text;
            var assertProductPP = shipPage.productTitleonpaypage.Text;

            Console.WriteLine("actual total price" + asserttotal);
            Console.WriteLine("actual product " + assertProductPP);

            Assert.IsTrue(asserttotal.Contains(atotalPrice));
            Assert.IsTrue(assertProductPP.Contains(aProduct));

            shipPage.ChoosePaymentDetails();
        }

        [Then(@"I Verify Order confirmation")]
        public void ThenIVerifyOrderConfirmation()
        {
            var confirmtotal = shipPage.confirmPrice.Text;
            Console.WriteLine("Confirm page total price" + confirmtotal);

            Assert.IsTrue(confirmtotal.Contains(atotalPrice));
            shipPage.ConfirmPaymentDetails();
            shipPage.screenshot();
        }

    }
}
