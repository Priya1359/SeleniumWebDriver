Feature: BuyProductfromtheJohnLewisWebsite
	In order to buy a product 
	As a JohnLewis Customer
	I want to Search and Add proct to the Basket

@mytag
Scenario Outline: Search and Buy a Product from JohnLewis Website
	Given I am on JohnLewis Website 
	When Search for a product to buy
	And I Add product to the check out page 
	And I verify Checkoutpage 
	And I continue As a Guest user and fill the mandtory fields <Title>,<Firstname>,<Lastname >,<PhoneNumber> and <PostCode>
	And I choose delivery date and continue to payment page 
	Then I Validate Delivery details and time on Review page 
	And I take screenshot of the page
	Examples: 
	| Title | Firstname | Lastname    | PhoneNumber | PostCode |
	| Mr    | Test      | Automation | 7777777777  | EN1 1DD  |
	
