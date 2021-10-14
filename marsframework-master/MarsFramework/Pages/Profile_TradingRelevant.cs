﻿using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    class Profile_TradingRelevant
    {
        public Profile_TradingRelevant()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Edit profile title
        [FindsBy(How = How.XPath, Using = "//div[@class = 'title']/i[@class = 'dropdown icon']")]

        public IWebElement editTitle { get; set; }

        //Edit First Name
        [FindsBy(How = How.XPath, Using = "//input[@name = 'firstName']")]

        public IWebElement editFirstName { get; set; }

        //Edit Last Name
        [FindsBy(How = How.XPath, Using = "//input[@name = 'lastName']")]

        public IWebElement editLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text() = 'Save']")]
        public IWebElement saveBtn { get; set; }

        //Click on edit icon for Availability
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Availability']/../div/span/i[@class = 'right floated outline small write icon']")]

        public IWebElement editIconForAvailability { get; set; }

        //Click on remove icon for Availability
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Availability']/../div//i[@class = 'remove icon']")]

        public IWebElement removeIconForAvailability { get; set; }

        //Click to select availability dropdown options
        [FindsBy(How = How.XPath, Using = "//select[@name = 'availabiltyType']")]

        public IWebElement availabilityDropdown { get; set; }

        //Click on edit icon for Hours
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Hours']/../div//i[@class = 'right floated outline small write icon']")]

        public IWebElement editIconForHours { get; set; }

        //Click on remove icon for Hours
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Hours']/../div//i[@class = 'remove icon']")]

        public IWebElement removeIconForHours { get; set; }

        //Click to select Hour dropdown options
        [FindsBy(How = How.XPath, Using = "//select[@name = 'availabiltyHour']")]

        public IWebElement hourDropdown { get; set; }

        //Click on edit icon for EarnTarget
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Earn Target']/../div//i[@class = 'right floated outline small write icon']")]

        public IWebElement editIconForEarnTarget { get; set; }

        //Click on remove icon for Earn Target
        [FindsBy(How = How.XPath, Using = "//span[strong = 'Earn Target']/../div//i[@class = 'remove icon']")]

        public IWebElement removeIconForEarnTarget { get; set; }

        //Click to select Earn Target dropdown options
        [FindsBy(How = How.XPath, Using = "//select[@name = 'availabiltyTarget']")]

        public IWebElement earnTargetDropdown { get; set; }

        #endregion

        public void UpdateTradingContent()
        {
            GlobalDefinitions gd = new GlobalDefinitions();
            Thread.Sleep(5000);
            editTitle.Click();
            gd.PageScrollDown();
            Thread.Sleep(5000);
            editFirstName.Clear();
            editFirstName.SendKeys("Nunnun");
            editLastName.Clear();
            editLastName.SendKeys("MunMun");
            saveBtn.Click();
            Thread.Sleep(3000);
            editIconForAvailability.Click();
            SelectElement se = new SelectElement(availabilityDropdown);
            se.SelectByIndex(2);
            Thread.Sleep(3000);
            ValidateMsgForAvailability();
            Thread.Sleep(3000);
            editIconForHours.Click();
            SelectElement oSelect = new SelectElement(hourDropdown);
            oSelect.SelectByIndex(3);
            ValidateMsgForAvailability();
            Thread.Sleep(3000);
            editIconForEarnTarget.Click();
            SelectElement oS = new SelectElement(earnTargetDropdown);
            oS.SelectByIndex(1);
            ValidateMsgForAvailability();
            Thread.Sleep(3000);
        }
        public void ValidateMsgForAvailability()
        {
            try
            { 
                var ActualMsg_Availability = GlobalDefinitions.driver.FindElement(By.XPath(
                    "//div[@class ='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div[@class = 'ns-box-inner']")).Text;
                Console.WriteLine("Actual message is : " + ActualMsg_Availability);
                var ExpectedMsg = "Availability updated";
                //var NoMessage = string.Empty;
                var nomessage = "";
                Thread.Sleep(4000);
                if (ExpectedMsg == "Availability updated" /*|| NoMessage == string.Empty*/ || nomessage == "")
                {
                    Console.WriteLine("Either condition from above is passed");
                }
                Assert.AreEqual(ExpectedMsg, ActualMsg_Availability);
            }catch(StaleElementReferenceException sere)
            {
                Console.WriteLine("Exception occurred : " + sere);
            }


        }

    }
}

