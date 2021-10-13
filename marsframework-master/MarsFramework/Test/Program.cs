using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using System.IO;
using System.Threading;

namespace MarsFramework
{
    public class Program
    {
        //[TestFixture]
        [Category("Sprint1")]
        //class User : Global.Base
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
                Thread.Sleep(3000);
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

        }
    }
//}