using OpenQA.Selenium;

namespace SeleniumHomework.pages
{
    public class CareersPage : BasePage
    {
        public CareersPage(IWebDriver driver): base(driver){
            url = "https://careers.epam.ua/";
        }

        public void SeeCareersPage(){
            RedirectPage(url);
    }
    }
}