using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using MarsFramework.Global;
using System;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using AutoItX3Lib;

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
        [FindsBy(How = How.XPath, Using = "//div[10]//div[2]//div[1]//div[1]//div[1]//input[1]")]
        private IWebElement ActiveOption { get; set; }

        //Click on Hidden option
        [FindsBy(How = How.XPath, Using = "//div[10]//div[2]//div[1]//div[2]//div[1]//input[1]")]
        //[FindsBy(How = How.XPath, Using = "//label[text()='Hidden']")]
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
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\MVP_Tasks_15_Sep_2021\marsframework-master\marsframework-master\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
            ShareSkillButton.Click();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            SelectElement se = new SelectElement(CategoryDropDown);
            se.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            SelectElement sElement = new SelectElement(SubCategoryDropDown);
            sElement.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            GlobalDefinitions gd = new GlobalDefinitions();
            gd.PageScrollDown();
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Enter);
            gd.PageScrollDown();
            EnterAvailabileDays();
            ExchangeSkills();
            uploadFileBtn.Click();
            AutoItX3 autoIT = new AutoItX3();
            autoIT.WinActivate("Open");
            Thread.Sleep(2000);
            autoIT.Send(@"C:\Users\Admin\Desktop\IC_DummyFile.txt");
            Thread.Sleep(2000);
            autoIT.Send("{Enter}");
            gd.PageScrollDown();
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(hiddenOption);
            if(GlobalDefinitions.ExcelLib.ReadData(2, "Active") != "Hidden")
            {
                ActiveOption.Click();
            }
            else
            {
                hiddenOption.Click();
            }
            Save.Click();
            ValidateMsgForSharingSkill();
            //Thread.Sleep(4000);

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
            try
            { 
                var ActualMsg_ListingAdded = GlobalDefinitions.driver.FindElement(By.XPath(
                "//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
                Console.WriteLine("Actual message is : " + ActualMsg_ListingAdded);
                var ExpectedMsg = "Service Listing Added successfully";
                //var NoMessage = string.Empty;
                var nomessage = "";
                Thread.Sleep(4000);
                if (ExpectedMsg == "Selenium has been deleted" /*|| NoMessage == string.Empty*/ || nomessage == "")
                {
                    Console.WriteLine("Either condition from above is passed");
                }
                Assert.That(ActualMsg_ListingAdded, Is.EqualTo(ExpectedMsg));
                
                Assert.AreEqual(ExpectedMsg, ActualMsg_ListingAdded);
            }   catch(StaleElementReferenceException sere)
            {
                Console.WriteLine("Exception occurred" + sere);
            }
        }


        public void EnterAvailabileDays()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\MVP_Tasks_15_Sep_2021\marsframework-master\marsframework-master\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            switch(GlobalDefinitions.ExcelLib.ReadData(2, "Selectday"))
            {
                case "Sun":
                    IWebElement checkSunday = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[2]//div[1]//div[1]/input[@name = 'Available']"));
                    checkSunday.Click();
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[2]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[2]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
                    Thread.Sleep(2000);
                    break;

                case "Mon":
                    IWebElement checkMonday = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[3]//div[1]/div[1]/input[@name = 'Available']"));
                    checkMonday.Click();
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[3]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[3]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
                    Thread.Sleep(2000);
                    break;

                case "Tue":
                    IWebElement checkTuesday = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[4]//div[1]/div[1]/input[@name = 'Available']"));
                    checkTuesday.Click();
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[4]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[4]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
                    Thread.Sleep(2000);
                    break;

                case "Wed":
                    IWebElement checkWednesday = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[5]//div[1]/div[1]/input[@name = 'Available']"));
                    checkWednesday.Click();
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[5]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[5]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
                    Thread.Sleep(2000);
                    break;

                case "Thu":
                    IWebElement checkThrusday = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[6]//div[1]/div[1]/input[@name = 'Available']"));
                    checkThrusday.Click();
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[6]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[6]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
                    Thread.Sleep(2000);
                    break;

                case "Fri":
                    IWebElement checkFriday = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[7]//div[1]/div[1]/input[@name = 'Available']"));
                    checkFriday.Click();
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[7]//div[2]/input[@name = 'StartTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='twelve wide column']//div[7]//div[3]/input[@name = 'EndTime']"))
                        .SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
                    Thread.Sleep(2000);
                    break;
            }
            
        }

        public void ExchangeSkills()
        {
            if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade") == "Skill-Exchange")
            {
                SkillTradeOption_exchange.Click();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                SkillTradeOption_Credit.Click();
                CreditAmount.Clear();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }
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
            //hiddenOption.Click();
            //uploadFileBtn.Click();
            //AutoItX3 autoIT = new AutoItX3();
            //autoIT.WinActivate("Open");
            Save.Click();
            ValidateMsgForListingUpdate();
            Thread.Sleep(4000);
        }

        public void ValidateMsgForListingUpdate()
        {
            try
            {
                var ActualMsg_ListingRemoval = GlobalDefinitions.driver.FindElement(By.XPath(
                    "//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
                Console.WriteLine("Actual message is : " + ActualMsg_ListingRemoval);
                var ExpectedMsg = "Service Listing Updated Successfully";
                //var NoMessage = string.Empty;
                var nomessage = "";
                Thread.Sleep(4000);
                if (ExpectedMsg == "Selenium has been deleted" /*|| NoMessage == string.Empty*/ || nomessage == "")
                {
                    Console.WriteLine("Either condition from above is passed");
                }
                Assert.That(ActualMsg_ListingRemoval, Is.EqualTo(ExpectedMsg));
                //Assert.AreEqual(ExpectedMsg, ActualMsg_ListingRemoval);
                
            }   catch (StaleElementReferenceException sere)
            {
                Console.WriteLine("Exception occurred" + sere);
            }
        }

    }
}
