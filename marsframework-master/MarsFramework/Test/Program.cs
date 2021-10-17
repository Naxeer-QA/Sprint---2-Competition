using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MarsFramework
{
    public class Program
    {
        //[TestFixture]
        [Category("Sprint1")]
        //private class User : Global.Base
        //{
            //This is newly created solution tonight as the previous file producing issues
            //due to version misconfigurations.

            [Test, Order(1)]
            public void Test()
            {
                Base bs = new Base();
                bs.Inititalize();
                Profile_TradingRelevant ptr = new Profile_TradingRelevant();
                ptr.UpdateTradingContent();
                bs.TearDown();
            }

            [Test, Order(2)]
            public void TradeSkills()
            {
                Base bs = new Base();
                bs.Inititalize();
                ShareSkill sSkill = new ShareSkill();
                sSkill.EnterShareSkill();
                bs.TearDown();
        }

            [Test, Order(3)]
            public void EditTradeSkills()
            {
                Base bs = new Base();
                bs.Inititalize();
                ManageListings ml = new ManageListings();
                ml.EditListings();
                ShareSkill sSkill = new ShareSkill();
                sSkill.EditShareSkill();
                bs.TearDown();
            }

            [Test, Order(4)]
            public void RemoveListings()
            {
                Base bs = new Base();
                bs.Inititalize();
                ManageListings ml = new ManageListings();
                ml.DeleteListings();
                bs.TearDown();
            }

            [Test]
            public void TableFinding()
            {
            Base bs = new Base();
            bs.Inititalize();
            ManageListings ml = new ManageListings();
            ml.manageListingsLink.Click();
            IWebElement table = GlobalDefinitions.driver.FindElement(By.XPath("//table [@class = 'ui striped table']"));
            
            if (table.Displayed)
            {
                IList<IWebElement> tableColumn = GlobalDefinitions.driver.FindElements(By.XPath("//table [@class = 'ui striped table']/thead/tr/th"));
                IList<IWebElement> tableRows = GlobalDefinitions.driver.FindElements(By.XPath("//table[@class = 'ui striped table']/tbody/tr"));
                var allRows = GlobalDefinitions.driver.FindElements(By.XPath(
                        "//table[@class = 'ui striped table']/tbody/tr"));
                int ListingsCount = tableRows.Count;
                int columnCount = tableColumn.Count;
                int selectRow = allRows.Count;
                

                System.Console.WriteLine("Total listings are : " + ListingsCount);
                System.Console.WriteLine("Total columns are : " + columnCount);

            }
                bs.TearDown();

        }

        }
    }
//}