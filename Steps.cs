using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumHomework.pages;
using TechTalk.SpecFlow;

namespace SeleniumHomework
{
    [Binding]
    public class Steps
    {
        private static IWebDriver driver;
        private static MainPage mainPage;
        private static CareersPage careersPage;
        private static SearchPage searchPage;

        [Before]
        public static void Begin(){
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver("E:\\study", options);

            mainPage = new MainPage(driver);
            searchPage = new SearchPage(driver);
            careersPage = new CareersPage(driver);
            //driver.SwitchTo().Window(driver.WindowHandles.First());
        }

        [After]
        public static void End(){
            driver.Quit();
        }
        
        [Given(@"I connect to epam.com")]
        public void OpenMain(){
            mainPage.GoTo();
            mainPage.CloseDisclaimer();
        }

        [When(@"I click on (.+) button")]
        public void ClickButton(string arg0) {
            mainPage.ClickButton(arg0);
        }

        [Then(@"I check that I come to (.+) page")]
        public void RedirectToPage(string arg0){
            mainPage.Redirection(arg0);
        }

        [Then(@"I check that page changed its careers region")]
        public void ChangeCareersRegion(){
        careersPage.SeeCareersPage();
        }

        [When(@"I enter 'RPA'")]
        public void EnterRpa() {
        mainPage.EnterSearchText("RPA");
        }

        [Then(@"I check that page changed to search result")]
        public void ChangedToSearchRpa(){
        searchPage.SeeRpaSearch();
        }

        [When(@"I point cursor to (.+)")]
        public void PointCursorToButton(string arg0) {
        mainPage.PointToButton(arg0);
        }

        [Then(@"I check that it is hovered by text")]
        public void CheckIsHovered() {
        mainPage.ConsultHover();
        }

        [Then(@"I check that (.+) opens on a new page")]
        public void GoToNewPage(string arg0) {
        mainPage.OpenInNewPage(arg0);
        }

        [Then(@"I check that investors page opens")]
        public void ToInvestorsPage(){
        mainPage.RedirectPage("https://investors.epam.com/investors/faq");
        }
    }
}