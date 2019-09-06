Feature: Purchasing an item from a website
          In order to buy an item 
          As a customer 
          I want to create account and proceed to payment using wire

@mytag
Scenario Outline: purchase an item from an online website using Wire
	     Given I have landed on http://automationpractice.com Website
         When I Search for a product to buy
         And I Add product to the basket 
         And I verify Checkout Page deatils
         And I continue As a Guest user 
	     And fill the mandtory fields <Firstname>,<Lastname >,<PhoneNumber>,<PostCode>,<City> and <AddressLine>
         And I verify delivery details 
         And I Pay using Wire
		 Then I Verify Order confirmation
	     Examples: 
         | Firstname | Lastname   | PhoneNumber | PostCode | City    | AddressLine        |
         | Test      | Automation | 7777777777  | 32013    | Florida | Test Address Line1 |