using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using NUnit.Framework;

namespace SeleniumHomework.pages
{
    public class BasePage
    {
        protected string url = "https://www.epam.com/";
        public static IWebDriver driver;

        public BasePage(IWebDriver driver){
            BasePage.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void RedirectPage(string link) {
            Thread.Sleep(500);
            Assert.AreEqual(link, driver.Url);
        }
    }
}