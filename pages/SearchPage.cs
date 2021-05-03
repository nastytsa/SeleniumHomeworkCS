using OpenQA.Selenium;

namespace SeleniumHomework.pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver) {
            url += "search";
        }

        public void SeeRpaSearch(){
            RedirectPage(url + "?q=RPA");
    }
    }
}