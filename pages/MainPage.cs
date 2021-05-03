using System;
using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace SeleniumHomework.pages
{
    public class MainPage : BasePage
    {
        private Actions actions;

        public MainPage(IWebDriver _driver) : base(_driver)
        {
            actions = new Actions(driver);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Services')]")]
        private IWebElement servicesButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'location-selector__button')][ contains(text(),'Global (EN)')]")]
        private IWebElement languageButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'CONTACT US')]")]
        private IWebElement contactUsButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'https://careers.epam.ua')]")]
        private IWebElement ukraineButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'header-search__button header__icon')]")]
        private IWebElement searchButton;

        [FindsBy(How = How.Id, Using = "new_form_search")]
        private IWebElement searchField;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'About')][contains(@href, '/about')]")]
        private IWebElement aboutButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Careers')][contains(@href, '/careers')]")]
        private IWebElement careersButton;

        [FindsBy(How = How.XPath, Using = "//img[contains(@class, 'rollover-tiles__image')][contains(@src, '/content/dam/epam/what_we_do/Consult-Yellow.svg')]")]
        private IWebElement consultButton;

        [FindsBy(How = How.XPath, Using = "//strong[contains(@class, 'rollover-tiles__title')][contains(text(), 'Consult')]")]
        private IWebElement consultHover;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '/about/investors/faq')]")]
        private IWebElement faqButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '/careers/blog')]")]
        private IWebElement blogButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/how-we-do-it')]")]
        private IWebElement howWeDoItButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/our-work')]")]
        private IWebElement ourWorkButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'https://www.telescopeai.com/')]")]
        private IWebElement telescopeAiButton;

        [FindsBy(How = How.XPath,
            Using = "//*[contains(@class,'button-ui bg-color-light-blue cookie-disclaimer__button')]")]
        private IWebElement disclaimerButton;
        
        public void GoTo(){
            driver.Navigate().GoToUrl(url);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url == url);
        }
        
        public void CloseDisclaimer(){
            disclaimerButton.Click();
        }

        public void EnterSearchText(string searchText){
            searchField.SendKeys(searchText);
            searchField.Submit();
        }

        public void PointToButton(string button){
            actions.MoveToElement(FindButton(button)).Build().Perform();
        }

        private IWebElement FindButton(string name){
            switch (name){
                case "CONSULT":
                    return consultButton;
                case "ABOUT":
                    return aboutButton;
                case "FAQ":
                    return faqButton;
                case "Contact Us":
                    return contactUsButton;
                case "Blog":
                    return blogButton;
                case "TELESCOPEAI":
                    return telescopeAiButton;
                case "SERVICES":
                    return servicesButton;
                case "HOW WE DO IT":
                    return howWeDoItButton;
                case "OUR WORK":
                    return ourWorkButton;
                case "language":
                    return languageButton;
                case "search":
                    return searchButton;
                case "CAREERS":
                    return careersButton;
                default:
                    return ukraineButton;
            }
        }

        public void ClickButton(string button){
            IWebElement but = FindButton(button);
            new WebDriverWait(driver,TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(but));
            but.Click();
        }

        
        public void Redirection(string page){
            RedirectPage(url + page);
        }

        public void ConsultHover(){
            Assert.AreEqual(consultHover.Displayed, true);
        }

        public void OpenInNewPage(string link){
            ArrayList tabs = new ArrayList(driver.WindowHandles);
            driver.SwitchTo().Window((string) tabs[1]);
            Assert.AreEqual(driver.Url, link);
        }
    }
}