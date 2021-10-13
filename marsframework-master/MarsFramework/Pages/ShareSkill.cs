using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using MarsFramework.Global;
using System;
using NUnit.Framework;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        //[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        [FindsBy(How = How.XPath, Using = "//h3[@id = 'requiredField'][text()='Tags']/../..//input[@class = 'ReactTags__tagInputField']")]
        private IWebElement Tags { get; set; }

        //Remove Tags 
        [FindsBy(How = How.XPath, Using = "//div[@class = 'ReactTags__selected']/../../../../div[2]/div/div/div[@class = 'ReactTags__selected']")]
        private IWebElement removeTags { get; set; }

        //Select the Service type
        //[FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        [FindsBy(How = How.XPath, Using = "//input[@name = 'serviceType'][@value = 0]")]
        private IWebElement ServiceTypeOptions_HourlyBasis { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'serviceType'][@value = 1]")]
        public IWebElement ServiceTypeOptions_OneOff { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'locationType'][@value = 0]")]
        private IWebElement LocationTypeOption_onSite { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//input[@name = 'locationType'][@value = 1]")]
        private IWebElement LocationTypeOption_Online { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        //[FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        [FindsBy(How = How.XPath, Using = "//div[@class = 'twelve wide column']/div[@class = 'form-wrapper']")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        //[FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        [FindsBy(How = How.XPath, Using = "//input[@name = 'StartTime'][@index = '1']")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        //[FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        [FindsBy(How = How.XPath, Using = "//input[@name = 'skillTrades'][@value = 'true']")]
        private IWebElement SkillTradeOption_exchange { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//input[@name = 'skillTrades'][@value = 'false']")]
        private IWebElement SkillTradeOption_Credit { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Hidden option
        //[FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']//label[text()='Hidden']")]
        [FindsBy(How = How.XPath, Using = "//label[text()='Hidden']")]
        public IWebElement hiddenOption { get; set; }

        //Upload file button
        [FindsBy(How = How.XPath, Using = "//i[@class = 'huge plus circle icon padding-25']")]
        public IWebElement uploadFileBtn { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        #endregion
        internal void EnterShareSkill()
        {
            ShareSkillButton.Click();
            Title.SendKeys("Automation");
            Description.SendKeys("Hi Team, I am automation tester");
            SelectElement se = new SelectElement(CategoryDropDown);
            se.SelectByText("Programming & Tech");
            SelectElement sElement = new SelectElement(SubCategoryDropDown);
            sElement.SelectByIndex(4);
            GlobalDefinitions gd = new GlobalDefinitions();
            gd.PageScrollDown();
            Tags.SendKeys("Selenium Automation");
            Tags.SendKeys(Keys.Enter);
            Tags.SendKeys("API Automation using Postman");
            Tags.SendKeys(Keys.Enter);
            gd.PageScrollDown();
            EnterAvailabileDays();
            gd.PageScrollDown();
            SkillTradeOption_Credit.Click();
            CreditAmount.SendKeys("4");
            //uploadFileBtn.Click();
            //AutoItX3 autoIT = new AutoItX3();
            //autoIT.WinActivate("Open");
            Save.Click();
            ValidateMsgForSharingSkill();
            Thread.Sleep(4000);

            #region 
            //int logoWidth = StartDateDropDown.Size.Width;
            //System.Console.WriteLine("Logo width : " + logoWidth + " pixels");
            //To get the height of the logo
            //int logoHeight = StartDateDropDown.Size.Height;
            //System.Console.WriteLine("Logo height : " + logoHeight + " pixels");

            //Point point = StartDateDropDown.Location;
            //int xcord = point.X;
            //System.Console.WriteLine("Position of the webelement from left side is " + xcord + " pixels");
            //int ycord = point.Y;
            //System.Console.WriteLine("Position of the webelement from top side is " + ycord + " pixels");

            //builder.MoveToElement(StartDateDropDown, xcord, ycord).Click().Build().Perform();
            //builder.MoveByOffset(xcord, ycord).Build().Perform();
            //builder.Release();

            #endregion
        }

        public void ValidateMsgForSharingSkill()
        {
            try { 
            String ActualMsg_ListingAdded = GlobalDefinitions.driver.FindElement(By.XPath(
                "//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
            String ExpectedMsg = "Service Listing Added successfully";
            Assert.AreEqual(ExpectedMsg, ActualMsg_ListingAdded);
            Console.WriteLine("Actual message is : " + ActualMsg_ListingAdded);
            }catch(StaleElementReferenceException sere)
            {
                Console.WriteLine("Exception occurred" + sere);
            }
        }


        public void EnterAvailabileDays()
        {
            Actions action = new Actions(GlobalDefinitions.driver);
            StartDateDropDown.Click();
            action.SendKeys(Keys.Space).Perform();
            action.SendKeys(Keys.Tab);
            action.SendKeys(Keys.Space).Perform();
            System.Threading.Thread.Sleep(3000);
            action.SendKeys(Keys.Space).Perform();
            action.SendKeys(Keys.Tab);
            action.SendKeys(Keys.Tab);
            action.SendKeys(Keys.Space).Perform();
            EndDateDropDown.SendKeys("10/10/2022");
            EndDateDropDown.Click();
            IWebElement Day1 = GlobalDefinitions.driver.FindElement(By.XPath("//input[@name = 'Available'][@index = 1]"));
            Day1.Click();
            StartTimeDropDown.SendKeys("10:00 AM");
            EndTimeDropDown.SendKeys("11:00 AM");
            EndTimeDropDown.SendKeys(Keys.Enter);
            IWebElement Day2 = GlobalDefinitions.driver.FindElement(By.XPath("//input[@name = 'Available'][@index = 2]"));
            Day2.Click();
            IWebElement time2 = GlobalDefinitions.driver.FindElement(By.XPath("//input[@name = 'StartTime'][@index = '2']"));
            time2.SendKeys("10:00 AM");
            IWebElement endTime2 = GlobalDefinitions.driver.FindElement(By.XPath("//input[@name = 'EndTime'][@index = '2']"));
            endTime2.SendKeys("11:00 AM");
            endTime2.SendKeys(Keys.Enter);
        }

        internal void EditShareSkill()
        {
            Title.Clear();
            Title.SendKeys("Selenium");
            Description.Clear();
            Description.SendKeys("Hi, I am a Selenium Automation tester");
            SelectElement se = new SelectElement(CategoryDropDown);
            se.SelectByText("Programming & Tech");
            SelectElement sElement = new SelectElement(SubCategoryDropDown);
            sElement.SelectByIndex(4);
            GlobalDefinitions gd = new GlobalDefinitions();
            gd.PageScrollDown();
            Thread.Sleep(3000);
            string b = Keys.Backspace.ToString();
            Tags.SendKeys(b + b + b + b + b);
            Tags.SendKeys("Selenium");
            Tags.SendKeys(Keys.Enter);
            Tags.SendKeys("Specflow");
            Tags.SendKeys(Keys.Enter);
            gd.PageScrollDown();
            ServiceTypeOptions_OneOff.Click();
            EnterAvailabileDays();
            gd.PageScrollDown();
            SkillTradeOption_exchange.Click();
            SkillExchange.SendKeys(b + b);
            SkillExchange.SendKeys("Cypress");
            SkillExchange.SendKeys(Keys.Enter);
            gd.PageScrollDown();
            //System.Threading.Thread.Sleep(3000);
            //hiddenOption.Click();
            //System.Threading.Thread.Sleep(3000);
            //uploadFileBtn.Click();
            //AutoItX3 autoIT = new AutoItX3();
            //autoIT.WinActivate("Open");
            Save.Click();
            Thread.Sleep(5000);
            //ValidateMsgForListingUpdate();
            //Thread.Sleep(4000);
        }

        public void ValidateMsgForListingUpdate()
        {
            try
            {
                String ActualMsg_ListingRemoval = GlobalDefinitions.driver.FindElement(By.XPath(
                    "//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
                String ExpectedMsg = "Service Listing Updated Successfully";
                Assert.AreEqual(ExpectedMsg, ActualMsg_ListingRemoval);
                Console.WriteLine("Actual message is : " + ActualMsg_ListingRemoval);
            }
            catch (StaleElementReferenceException sere)
            {
                Console.WriteLine("Exception occurred" + sere);
            }
        }

    }
}
