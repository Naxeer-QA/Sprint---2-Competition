using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//a[text()='Manage Listings']")]
        public IWebElement manageListingsLink { get; set; }
        [CacheLookup]

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        public IWebElement view { get; set; }
        [CacheLookup]

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]//i[@class = 'remove icon']")]
        public IWebElement deleteListings { get; set; }
        [CacheLookup]

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]//i[@class = 'outline write icon']")]
        public IWebElement editListings { get; set; }
        [CacheLookup]

        //Click on eye icon to view services
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]//i[@class = 'eye icon']")]
        public IWebElement clickToViewServices { get; set; }
        [CacheLookup]

        //Click on No button
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']/button[@class = 'ui negative button']")]
        public IWebElement clickActionNoButton { get; set; }
        [CacheLookup]

        //Click on Yes button
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']//i[@class = 'checkmark icon']")]
        public IWebElement clickActionYesButton { get; set; }

        public void DeleteListings()
        {
            //Populate the Excel Sheet
            //GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\Internship\Sprint2\marsframework-master\MarsFramework\ExcelData\TestDataManageListings.xlsx", "ManageListings");
            manageListingsLink.Click();
            deleteListings.Click();
            clickActionYesButton.Click();
            ValidateMsgForListingsRemoval();
            Thread.Sleep(4000);
        }

        public void ValidateMsgForListingsRemoval()
        {
            try
            { 
                var ActualMsg_ListingRemoval = GlobalDefinitions.driver.FindElement(By.XPath(
                "//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
                Console.WriteLine("Actual message is : " + ActualMsg_ListingRemoval);
                var ExpectedMsg = "Selenium has been deleted";
                //var NoMessage = string.Empty;
                var nomessage = "";
                Thread.Sleep(4000);
                if (ExpectedMsg == "Selenium has been deleted" /*|| NoMessage == string.Empty*/ || nomessage == "")
                {
                    Console.WriteLine("Either condition from above is passed");
                }

                Assert.AreEqual(ExpectedMsg, ActualMsg_ListingRemoval);
                
            }catch(StaleElementReferenceException sere)

            {
                Console.WriteLine("Exception occurred" + sere);
            }
            
        }
        public void EditListings()
        {
            Thread.Sleep(4000);
            manageListingsLink.Click();
            GlobalDefinitions gd = new GlobalDefinitions();
            gd.waitUntilClickable(GlobalDefinitions.driver, editListings);
            editListings.Click();
            Thread.Sleep(4000);
        }

    }
}