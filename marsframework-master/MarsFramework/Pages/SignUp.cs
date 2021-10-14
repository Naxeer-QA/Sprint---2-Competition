using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    class SignUp
    {
        public SignUp()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Join from home page
        [FindsBy(How = How.XPath, Using = "//button[contains (text(), 'Join')]")]
        private IWebElement Join { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui page modals dimmer transition visible active']//a[text() = ' Join']")]
        public IWebElement JoinFromLoginFailure { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'firstName']")]
        private IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'lastName']")]
        private IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'email']")]
        private IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'password']")]
        private IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'confirmPassword']")]
        private IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name = 'terms']")]
        private IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        private IWebElement JoinBtn { get; set; }
        #endregion

        internal void register()
        {
            //Populate the excel data
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\MVP_Tasks_15_Sep_2021\marsframework-master\marsframework-master\MarsFramework\ExcelData\TestData.xlsx", "SignUp");

            //Click on Join button
            Join.Click();

            //Enter FirstName
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();
        }

        public void RegisterUponLoginFailed()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\Internship\Sprint2\marsframework-master\MarsFramework\ExcelData\TestData.xlsx", "SignUp");

            //Click on Join button - Yet to write the correct xpath when the new user tries to logs in and fails
            

            //Enter FirstName
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();
        }
    }
}
