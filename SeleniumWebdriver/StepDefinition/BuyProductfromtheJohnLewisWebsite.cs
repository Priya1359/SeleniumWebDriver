using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;
using System;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebdriver.StepDefinition
{
    [Binding]
   public class BuyProductfromtheJohnLewisWebsite 
    {

        HomePage hPage = new HomePage();
        CheckoutPage cPage = new CheckoutPage();
        DeliveryDetailsPage dPage = new DeliveryDetailsPage();


        [Given(@"I am on (.*) Website")]
        public void GivenIAmOnJohnLewisWebsite(string url)
        {
            NavigationHelper.NavigateToUrl("https://JohnLewis.com");
            hPage.GetTitleOfThePage();
        }

        [When(@"Search for a product to buy")]
        public void WhenSearchForAProductToBuy()
        {
           
            hPage.search("Bag" , "priceLow");
        }

        [When(@"I Add product to the check out page")]
        public void WhenIAddProductToTheCheckOutPage()
        {
            
        hPage.AddProduct();
            
        }

                      
        [When(@"I verify Checkoutpage")]
        public void WhenIVerifyCheckoutpage()
        {
            cPage.assertCheckoutpage();
        }
        [When(@"I continue As a Guest user and fill the mandtory fields (.*),(.*),(.*),(.*) and (.*)")]
        public void WhenIcontinueAsaGuestuserandfillthemandtoryfields(string title ,string fname ,string lname ,string Phno,string Pcode )
        {
            cPage.continueasAGuest();
            cPage.fillDeliveryDetails(title, fname, lname, Phno, Pcode);

            ScenarioContext.Current["UserTitle"] = title;
            ScenarioContext.Current["Userfname"] = fname;
            ScenarioContext.Current["Userlname"] = lname;
            ScenarioContext.Current["phone"] = Phno;
            ScenarioContext.Current["postcode"] = Pcode;
        }

       /* [When(@"I continue As a Guest user and fill the mandtory fields")]
        public void WhenIContinueAsAGuestUserToDeliveryDeatailsPage()
        {
            cPage.continueasAGuest();
            cPage.fillDeliveryDetails("Mr", "Test", "Automation" , "7777777777" , "EN1 1DD");
            
            ScenarioContext.Current["UserTitle"] = "Mr";
           ScenarioContext.Current["Userfname"] = "Test";
            ScenarioContext.Current["Userlname"] = "Automation";
            ScenarioContext.Current["phone"] = "7777777777";
            ScenarioContext.Current["postcode"] = "EN1 1DD";


        }*/

        [When(@"I choose delivery date and continue to payment page")]
        public void WhenIChooseDeliveryDateAndContinueToPaymentPage()
        {
            string Ufname = ScenarioContext.Current["Userfname"].ToString();
            string Ulanme = ScenarioContext.Current["Userlname"].ToString();
            string utitle = ScenarioContext.Current["UserTitle"].ToString();
            string phonenumber = ScenarioContext.Current["phone"].ToString();
            string postcode = ScenarioContext.Current["postcode"].ToString();



            dPage.deliveryDetails();
            var assertuname = dPage.verifyuser.Text;
            var assertpcode = dPage.verifyPostcode.Text;
            var assertphone = dPage.verifyPhone.Text;
            Console.WriteLine("user from scenario"  + utitle + " " + Ufname + " " + Ulanme);
            Console.WriteLine("user from delivery page"  +  assertuname);

            Assert.IsTrue(assertuname.Contains(utitle + " " + Ufname +" "+ Ulanme));
            Assert.IsTrue(assertpcode.Contains(postcode));
            Assert.IsTrue(assertphone.Contains(phonenumber));

                                          
        }

        [Then(@"I Validate Delivery details and time on Review page")]
        public void ThenIValidateDeliveryDetailsAndTimeOnReviewPage()
        {
            dPage.validateReviewPage();
        }

        [Then(@"I take screenshot of the page")]
        public void ThenITakeScreenshotOfThePage()
        {
            dPage.screenshot();
        }

    }
}
