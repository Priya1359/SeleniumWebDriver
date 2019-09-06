
I have followed Page object Model to write the tests as it is easy to maintain if any ids , xpaths changes in the future.

Technologies : Visual Studio 2017 or any higher version , Specflow , MsTest , C# and Selenium. 

Folder structure : 

Base classes Folder: Contains browser setup and teardown methods.
Component Helper Folder: Contains Selenium reuable methods. 
Config Folder : Contains Appconfig Keys 
Feature Files Folder : Contains Test Scenario
PageObject Folder : Page Objects of the relavent pages (Which has getter , setter methods )
StepDefination Folder : Main Class for the test.
Interfaces ,Resources,Reports and Setting folders are some of the utilities. 
Specify Browser type in AppConfig file to run test in specific browser.

Improvements can be done in Reporting , Using dynamic test data and improve assertions. 



