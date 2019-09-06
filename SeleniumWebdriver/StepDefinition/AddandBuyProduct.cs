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
        HomePage hPage = new HomePage();
        CheckoutPage cPage = new CheckoutPage();
        DeliveryDetailsPage dPage = new DeliveryDetailsPage();
        ShippingPage sPage = new ShippingPage();

        [Given(@"I have landed on(.*) Website")]
        public void GivenIHaveLandedOnHttpAutomationpracticecomWebsite(string url)
        {
            NavigationHelper.NavigateToUrl(url);
            hPage.GetTitleOfThePage();
        }

        [When(@"I Search for a product to buy")]
        public void WhenSearchForAProductToBuy()
        {

            hPage.search("Dresses");
        }
        [When(@"I Add product to the basket")]
        public void WhenIAddProductToTheBasket()
        {
            hPage.AddProduct();
        }
        [When(@"I verify Checkout Page deatils")]
        public void WhenIVerifyCheckoutPageDeatils()
        {
            cPage.assertCheckoutpage();
        }

        [When(@"I continue As a Guest user")]
        public void WhenIContinueAsAGuestUser()
        {
            cPage.continueasAGuest();
        }

        [When(@"fill the mandtory fields (.*),(.*),(.*),(.*),(.*) and (.*)")]
        public void WhenFillTheMandtoryFieldsTestFloridaAndTestAddressLine(string fname, string lname, string Phno, string Pcode ,string CityName ,string addressln)
        {
            cPage.fillDeliveryDetails(fname, lname, Phno, Pcode ,CityName,addressln);

            ScenarioContext.Current["UserCity"] = CityName;
            ScenarioContext.Current["Userfname"] = fname;
            ScenarioContext.Current["Userlname"] = lname;
            ScenarioContext.Current["phone"] = Phno;
            ScenarioContext.Current["postcode"] = Pcode;
            ScenarioContext.Current["ADDRESS"] = addressln;

        }
        
        [When(@"I verify delivery deatils")]
        public void WhenIverifydeliverydeatils()
        {
            string Ufname = ScenarioContext.Current["Userfname"].ToString();
            string Ulanme = ScenarioContext.Current["Userlname"].ToString();
            string ucity = ScenarioContext.Current["UserCity"].ToString();
            string phonenumber = ScenarioContext.Current["phone"].ToString();
            string postcode = ScenarioContext.Current["postcode"].ToString();
            string addressln1 = ScenarioContext.Current["ADDRESS"].ToString();



            dPage.deliveryDetails();
            var assertuname = dPage.getFirstName.Text;
            var assertcity = dPage.getCity.Text;
            var assertphone = dPage.getphone.Text;
            var assertAddress = dPage.getAddressLine1.Text;

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
            sPage.shippingDetails();
            sPage.ChoosePaymentDetails();
        }

        [Then(@"I Verify Order confirmation")]
        public void ThenIVerifyOrderConfirmation()
        {
            sPage.ConfirmPaymentDetails();
            sPage.screenshot();
        }



    }
}
